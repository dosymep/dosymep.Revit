using System.Collections.Generic;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к параметрам проекта.
    /// </summary>
    public interface IProjectParamsService : IParamElementService {
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        new ProjectParam CreateRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        new ProjectParam CreateRevitParam(Document document, ParameterElement revitParamElement);
        
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        new ProjectParam CreateRevitParam(Document document, string propertyName, string revitParamName);
        
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        new ProjectParam CreateRevitParam(Document document, string propertyName, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает параметр проекта по его имени (идентификатору).
        /// </summary>
        /// <param name="paramId">Идентификатор параметра Revit.</param>
        new ProjectParam this[string paramId] { get; }
        
        /// <summary>
        /// Возвращает весь список параметров проекта.
        /// </summary>
        /// <returns>Возвращает весь список параметров проекта.</returns>
        new IEnumerable<ProjectParam> GetRevitParams();
        
        /// <summary>
        /// Возвращает весь список параметров проекта.
        /// </summary>
        /// <param name="document">Документ из которого берутся параметры.</param>
        /// <returns>Возвращает весь список общих параметров.</returns>
        new IEnumerable<ProjectParam> GetRevitParams(Document document);
    }
}