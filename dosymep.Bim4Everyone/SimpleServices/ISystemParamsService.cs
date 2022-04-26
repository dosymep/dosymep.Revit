using System.Collections.Generic;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SystemParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к системным параметрам.
    /// </summary>
    public interface ISystemParamsService : IRevitParamsService {
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns></returns>
        RevitParam GetRevitParam(Document document, BuiltInParameter systemParamId);
        
        /// <summary>
        /// Возвращает весь список системных параметров.
        /// </summary>
        /// <returns>Возвращает весь список системных параметров.</returns>
        new IEnumerable<SystemParam> GetRevitParams();
    }
}