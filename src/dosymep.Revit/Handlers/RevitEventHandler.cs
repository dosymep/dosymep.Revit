using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

using Autodesk.Revit.UI;

namespace dosymep.Revit.Handlers {
    /// <summary>
    /// Класс для регистрации и обработки событий <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
    /// Пример использования для вызова команд из не модальных окон:
    /// <code>
    /// // Сохраните ссылку на RevitEventHandler в приватное поле ViewModel вашего окна:
    /// private readonly RevitEventHandler;
    /// public ViewModel() {
    ///     _handler = new RevitEventHandler("RevitCommand");
    /// }
    /// 
    /// // Добавьте метод во ViewModel, который будет вызываться из не модального окна на клике кнопки.
    /// private async void DoCommand() {
    ///     try {
    ///         await _handler.SetTransactAction(app => TaskDialog.Show(
    ///                 "Handler sample",
    ///                 $"Selected elements count: {app.ActiveUIDocument.Selection.GetElementIds().Count}"))
    ///             .Raise();
    ///     } catch(Exception ex) {
    ///         TaskDialog.Show("Error", ex.Message);
    ///     }
    /// }
    /// </code>
    /// </summary>
    public sealed class RevitEventHandler : IExternalEventHandler, INotifyCompletion {
        private readonly ExternalEvent _externalEvent;
        private readonly string _name;
        private Action _continuation;
        private Exception _exception;

        /// <summary>
        /// Создает экземпляр <see cref="Autodesk.Revit.UI.ExternalEvent"/> с обработчиком в качестве текущего экземпляра <see cref="RevitEventHandler"/>.
        /// </summary>
        /// <param name="externalEventName">Название обработчика события, используемое Revit в качестве идентификатора.</param>
        /// <exception cref="System.ArgumentNullException">Исключение, если обязательный параметр null.</exception>
        /// <exception cref="System.ArgumentException">Исключение, если название обработчика пустая строка или состоит только из пробелов.</exception>
        public RevitEventHandler(string externalEventName) {
            if(externalEventName is null) {
                throw new ArgumentNullException(nameof(externalEventName));
            }
            if(string.IsNullOrWhiteSpace(externalEventName)) {
                throw new ArgumentException(nameof(externalEventName));
            }

            _externalEvent = ExternalEvent.Create(this);
            _name = externalEventName;
        }


        /// <summary>
        /// Флаг, показывающий, завершилось ли выполнение <see cref="TransactAction"/>, или нет.
        /// </summary>
        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Делегат, который вызывается при обработке события <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
        /// </summary>
        public Action<UIApplication> TransactAction { get; private set; }


        /// <summary>
        /// Назначает делегат <see cref="TransactAction"/>.
        /// </summary>
        /// <param name="action">Делегат, который будет вызван при обработке события <see cref="Autodesk.Revit.UI.ExternalEvent"/>.</param>
        /// <returns>Возвращает текущий объект <see cref="RevitEventHandler"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если обязательный параметр null.</exception>
        public RevitEventHandler SetTransactAction(Action<UIApplication> action) {
            TransactAction = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        /// <inheritdoc/>
        public void Execute(UIApplication app) {
            try {
                TransactAction?.Invoke(app);
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
        /// экземпляр которого был создан при создании текущего экземпляра <see cref="RevitEventHandler"/>.
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
        /// Если в процессе выполнения <see cref="TransactAction"/> возникло исключение, оно будет выброшено здесь.
        /// </summary>
        public void GetResult() {
            if(_exception != null) {
                ExceptionDispatchInfo.Capture(_exception).Throw();
            }
        }
    }
}
