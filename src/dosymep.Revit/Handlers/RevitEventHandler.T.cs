using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

using Autodesk.Revit.UI;

namespace dosymep.Revit.Handlers {
    /// <summary>
    /// Класс для регистрации и обработки событий <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
    /// </summary>
    public sealed class RevitEventHandler<T> : IExternalEventHandler, INotifyCompletion {
        private readonly string _name;
        private T _result;
        private ExternalEvent _externalEvent;
        private Action _continuation;
        private Exception _exception;

        /// <summary>
        /// Создает экземпляр обработчика.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Исключение, если обязательный параметр null.</exception>
        /// <exception cref="System.ArgumentException">Исключение, если название обработчика пустая строка или состоит только из пробелов.</exception>
        internal RevitEventHandler() {
            _name = Guid.NewGuid().ToString();
        }


        /// <summary>
        /// Флаг, показывающий, завершилось ли выполнение <see cref="HandleFunction"/>, или нет.
        /// </summary>
        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Делегат, который вызывается при обработке события <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
        /// </summary>
        internal Func<UIApplication, T> HandleFunction { get; private set; }


        /// <inheritdoc/>
        public void Execute(UIApplication app) {
            try {
                if(HandleFunction != null) {
                    _result = HandleFunction.Invoke(app);
                }
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
        /// экземпляр которого был создан при создании текущего экземпляра <see cref="RevitEventHandler{T}"/>.
        /// </summary>
        /// <returns>Возвращает текущий объект <see cref="RevitEventHandler{T}"/>.</returns>
        public RevitEventHandler<T> Raise() {
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
        public RevitEventHandler<T> GetAwaiter() {
            return this;
        }

        /// <summary>
        /// Заканчивает ожидание завершения асинхронной задачи и возвращает результат выполнения. 
        /// Если в процессе выполнения <see cref="HandleFunction"/> возникло исключение, оно будет выброшено здесь.
        /// </summary>
        public T GetResult() {
            if(_exception != null) {
                ExceptionDispatchInfo.Capture(_exception).Throw();
            }
            return _result;
        }

        /// <summary>
        /// Назначает делегат <see cref="HandleFunction"/>.
        /// </summary>
        /// <param name="function">Функция, которая будет вызвана при обработке события <see cref="Autodesk.Revit.UI.ExternalEvent"/>.</param>
        /// <returns>Возвращает текущий объект <see cref="RevitEventHandler{T}"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если обязательный параметр null.</exception>
        internal RevitEventHandler<T> SetHandleFunction(Func<UIApplication, T> function) {
            HandleFunction = function ?? throw new ArgumentNullException(nameof(function));
            return this;
        }

        internal RevitEventHandler<T> SetExternalEvent(ExternalEvent externalEvent) {
            _externalEvent = externalEvent;
            return this;
        }
    }
}
