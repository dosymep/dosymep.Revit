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
        /// <returns>Возвращает общий параметр.</returns>
        SharedParam GetRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="revitParamElement">Элемент общего параметра.</param>
        /// <returns>Возвращает общий параметр.</returns>
        SharedParam GetRevitParam(Document document, ParameterElement revitParamElement);

        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamName">Наименование общего параметра.</param>
        /// <returns>Возвращает общий параметр.</returns>
        SharedParam GetRevitParam(Document document, string propertyName, string revitParamName);

        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamElement">Элемент общего параметра.</param>
        /// <returns>Возвращает общий параметр.</returns>
        SharedParam GetRevitParam(Document document, string propertyName, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает весь список общих параметров.
        /// </summary>
        /// <returns>Возвращает весь список общих параметров.</returns>
        new IEnumerable<SharedParam> GetRevitParams();
    }
}