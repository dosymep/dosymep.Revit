using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Интерфейс по получению параметров Revit.
    /// </summary>
    public interface IParamElementService : IRevitParamsService {
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns></returns>
        RevitParam GetRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns></returns>
        RevitParam GetRevitParam(Document document, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns></returns>
        RevitParam GetRevitParam(Document document, string propertyName, string revitParamName);
        
        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns></returns>
        RevitParam GetRevitParam(Document document, string propertyName, ParameterElement revitParamElement);
    }
}