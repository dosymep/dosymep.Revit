using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис параметров Revit.
    /// </summary>
    public interface IRevitParamsService {
        /// <summary>
        /// Сохраняет конфигурацию по заданному пути.
        /// </summary>
        /// <param name="configPath">Путь до файла конфигурации.</param>
        void Save(string configPath);
        
        /// <summary>
        /// Возвращает параметр Revit по его имени (идентификатору).
        /// </summary>
        /// <param name="paramId">Идентификатор параметра Revit.</param>
        RevitParam this[string paramId] { get; }

        /// <summary>
        /// Возвращает весь список настроек параметров.
        /// </summary>
        /// <returns>Возвращает весь список настроек параметров.</returns>
        IEnumerable<RevitParam> GetRevitParams();
    }
}