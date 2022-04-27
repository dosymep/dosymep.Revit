using System.Collections.Generic;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к параметрам проекта.
    /// </summary>
    public interface IProjectParamsService : IRevitParamsService {
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns></returns>
        ProjectParam GetRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns></returns>
        ProjectParam GetRevitParam(Document document, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns></returns>
        ProjectParam GetRevitParam(Document document, string propertyName, string revitParamName);
        
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns></returns>
        ProjectParam GetRevitParam(Document document, string propertyName, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает весь список параметров проекта.
        /// </summary>
        /// <returns>Возвращает весь список параметров проекта.</returns>
        new IEnumerable<ProjectParam> GetRevitParams();
    }
}