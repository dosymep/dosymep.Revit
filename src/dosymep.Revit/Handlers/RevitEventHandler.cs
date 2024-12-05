using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

using Autodesk.Revit.UI;

namespace dosymep.Revit.Handlers {
    /// <summary>
    /// Класс для регистрации и обработки событий <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
    /// </summary>
    internal sealed class RevitEventHandler : IExternalEventHandler, INotifyCompletion {
        private readonly string _name;
        private ExternalEvent _externalEvent;
        private Action _continuation;
        private Exception _exception;

        /// <summary>
        /// Создает экземпляр обработчика.
        /// </summary>
        internal RevitEventHandler() {
            _name = Guid.NewGuid().ToString();
        }


        /// <summary>
        /// Флаг, показывающий, завершилось ли выполнение <see cref="HandleAction"/>, или нет.
        /// </summary>
        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Делегат, который вызывается при обработке события <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
        /// </summary>
        public Action<UIApplication> HandleAction { get; private set; }


        /// <inheritdoc/>
        public void Execute(UIApplication app) {
            try {
                HandleAction?.Invoke(app);
                _exception = null;
            } catch(Exception ex) {
                _exception = ex;
            } finally {
                IsCompleted = true;
                _continuation?.Invoke();
            }
        }

        /// <inheritdoc/>
        public string GetName() {
            return _name;
        }

        /// <summary>
        /// Вызывает событие <see cref="Autodesk.Revit.UI.ExternalEvent"/>, 
        /// экземпляр которого был назначен через <see cref="SetExternalEvent"/>.
        /// </summary>
        /// <returns>Возвращает текущий объект <see cref="RevitEventHandler"/>.</returns>
        public RevitEventHandler Raise() {
            IsCompleted = false;
            _continuation = null;
            _externalEvent.Raise();
            return this;
        }

        /// <inheritdoc/>
        public void OnCompleted(Action continuation) {
            _continuation = continuation;
        }

        /// <summary>
        /// Возвращает awaiter объект.
        /// </summary>
        /// <returns>Возвращает текущий объект.</returns>
        public RevitEventHandler GetAwaiter() {
            return this;
        }

        /// <summary>
        /// Заканчивает ожидание завершения асинхронной задачи. 
        /// Если в процессе выполнения <see cref="HandleAction"/> возникло исключение, оно будет выброшено здесь.
        /// </summary>
        public void GetResult() {
            if(_exception != null) {
                ExceptionDispatchInfo.Capture(_exception).Throw();
            }
        }

        /// <summary>
        /// Назначает делегат <see cref="HandleAction"/>.
        /// </summary>
        /// <param name="action">Делегат, который будет вызван при обработке события <see cref="Autodesk.Revit.UI.ExternalEvent"/>.</param>
        /// <returns>Возвращает текущий объект <see cref="RevitEventHandler"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если обязательный параметр null.</exception>
        internal RevitEventHandler SetTransactAction(Action<UIApplication> action) {
            HandleAction = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        internal RevitEventHandler SetExternalEvent(ExternalEvent externalEvent) {
            _externalEvent = externalEvent;
            return this;
        }
    }
}
