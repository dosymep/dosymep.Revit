using System.Collections.Generic;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SharedParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к общим параметрам.
    /// </summary>
    public interface ISharedParamsService : IRevitParamsService {
        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="revitParamName">Наименование общего параметра.</param>
        /// <returns></returns>
        SharedParam GetRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="revitParamElement">Элемент общего параметра.</param>
        /// <returns></returns>
        SharedParam GetRevitParam(Document document, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает весь список общих параметров.
        /// </summary>
        /// <returns>Возвращает весь список общих параметров.</returns>
        new IEnumerable<SharedParam> GetRevitParams();
    }
}