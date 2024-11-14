using System;
using System.Threading.Tasks;

using Autodesk.Revit.UI;

namespace dosymep.Revit.Handlers {
    /// <summary>
    /// Класс для создания обработчиков событий <see cref="Autodesk.Revit.UI.ExternalEvent"/>.
    /// </summary>
    public class RevitEvent<T> {
        private readonly RevitEventHandler _revitEventHandler;
        private readonly RevitEventHandler<T> _revitEventTypedHandler;


        /// <summary>
        /// Создает билдер.
        /// </summary>
        public RevitEvent() {
            _revitEventHandler = new RevitEventHandler();
            var externalEvent = ExternalEvent.Create(_revitEventHandler);
            _revitEventHandler.SetExternalEvent(externalEvent);

            _revitEventTypedHandler = new RevitEventHandler<T>();
            var externalEventTyped = ExternalEvent.Create(_revitEventTypedHandler);
            _revitEventTypedHandler.SetExternalEvent(externalEventTyped);
        }


        /// <summary>
        /// Задает делегат на выполнение в Revit.
        /// </summary>
        /// <param name="action">Делегат, вызываемый Revit.</param>
        /// <returns>Ссылка созданную операцию.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если один из обязательных параметров null.</exception>
        public async Task Raise(Action<UIApplication> action) {
            if(action is null) {
                throw new ArgumentNullException(nameof(action));
            }

            await _revitEventHandler
                .SetTransactAction(action)
                .Raise();
        }

        /// <summary>
        /// Задает функцию на выполнение в Revit.
        /// </summary>
        /// <param name="function">Функция, вызываемая Revit.</param>
        /// <returns>Ссылка на созданную операцию.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если один из обязательных параметров null.</exception>
        public async Task<T> Raise(Func<UIApplication, T> function) {
            if(function is null) {
                throw new ArgumentNullException(nameof(function));
            }

            return await _revitEventTypedHandler
                 .SetHandleFunction(function)
                 .Raise();
        }
    }
}
