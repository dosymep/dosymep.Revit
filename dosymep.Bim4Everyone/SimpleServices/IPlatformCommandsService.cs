using System;
using System.Collections.Generic;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляющий доступ ко всем командам платформы.
    /// </summary>
    /// <remarks>На данный момент поддерживаются только C# команды.</remarks>
    public interface IPlatformCommandsService {
        /// <summary>
        /// Запускает команду платформы.
        /// </summary>
        /// <param name="commandId">Запускаемая команда платформы.</param>
        /// <param name="message">Описание параметра в методе <see cref="IExternalCommand.Execute"/>.</param>
        /// <param name="elements">Описание параметра <see cref="IExternalCommand.Execute"/>.</param>
        /// <returns>Возвращает результат работы команды.</returns>
        Result InvokeCommand(Guid commandId, ref string message, ElementSet elements);

        /// <summary>
        /// Запускает команду платформы.
        /// </summary>
        /// <param name="commandId">Запускаемая команда платформы.</param>
        /// <param name="message">Описание параметра в методе <see cref="IExternalCommand.Execute"/>.</param>
        /// <param name="elements">Описание параметра <see cref="IExternalCommand.Execute"/>.</param>
        /// <param name="journalData">Описание параметра в свойстве <see cref="ExternalCommandData.JournalData"/>.</param>
        /// <returns>Возвращает результат работы команды.</returns>
        Result InvokeCommand(Guid commandId, ref string message, ElementSet elements, Dictionary<string, string> journalData);
    }
}