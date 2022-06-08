using System.Collections.Generic;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SharedParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к общим параметрам.
    /// </summary>
    public interface ISharedParamsService : IParamElementService {
        /// <summary>
        /// Создает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="revitParamName">Наименование общего параметра.</param>
        /// <returns>Возвращает новый созданный общий параметр.</returns>
        new SharedParam CreateRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Создает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="revitParamElement">Элемент общего параметра.</param>
        /// <returns>Возвращает новый созданный общий параметр.</returns>
        new SharedParam CreateRevitParam(Document document, ParameterElement revitParamElement);

        /// <summary>
        /// Создает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamName">Наименование общего параметра.</param>
        /// <returns>Возвращает новый созданный общий параметр.</returns>
        new SharedParam CreateRevitParam(Document document, string propertyName, string revitParamName);

        /// <summary>
        /// Создает общий параметр.
        /// </summary>
        /// <param name="document">Документ общего параметра.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamElement">Элемент общего параметра.</param>
        /// <returns>Возвращает новый созданный общий параметр.</returns>
        new SharedParam CreateRevitParam(Document document, string propertyName, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает общий параметр по его имени (идентификатору).
        /// </summary>
        /// <param name="paramId">Идентификатор параметра Revit.</param>
        new SharedParam this[string paramId] { get; }
        
        /// <summary>
        /// Возвращает весь список общих параметров.
        /// </summary>
        /// <returns>Возвращает весь список общих параметров.</returns>
        new IEnumerable<SharedParam> GetRevitParams();
        
        /// <summary>
        /// Возвращает весь список общих параметров.
        /// </summary>
        /// <param name="document">Документ из которого берутся параметры.</param>
        /// <returns>Возвращает весь список общих параметров.</returns>
        new IEnumerable<SharedParam> GetRevitParams(Document document);
    }
}