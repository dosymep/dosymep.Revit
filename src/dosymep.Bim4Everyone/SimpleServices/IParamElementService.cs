using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Интерфейс по получению параметров Revit.
    /// </summary>
    public interface IParamElementService : IRevitParamsService {
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        RevitParam CreateRevitParam(Document document, string revitParamName);
        
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        RevitParam CreateRevitParam(Document document, ParameterElement revitParamElement);
        
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamName">Наименование параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        RevitParam CreateRevitParam(Document document, string propertyName, string revitParamName);
        
        /// <summary>
        /// Создает параметр проекта.
        /// </summary>
        /// <param name="document">Документ параметра проекта.</param>
        /// <param name="propertyName">Уникальное название параметра.</param>
        /// <param name="revitParamElement">Элемент параметра проекта.</param>
        /// <returns>Возвращает новый созданный параметр проекта.</returns>
        RevitParam CreateRevitParam(Document document, string propertyName, ParameterElement revitParamElement);
        
        /// <summary>
        /// Возвращает весь список параметров.
        /// </summary>
        /// <param name="document">Документ из которого берутся параметры.</param>
        /// <returns>Возвращает весь список общих параметров.</returns>
        IEnumerable<RevitParam> GetRevitParams(Document document);
    }
}