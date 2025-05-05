using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Определяет фабрику для создания экземпляров RevitParam.
    /// </summary>
    public interface IRevitParamFactory {
        /// <summary>
        /// Создаёт новый экземпляр класса RevitParam.
        /// </summary>
        /// <param name="document">Revit-документ, в котором находится параметр.</param>
        /// <param name="paramId">Идентификатор создаваемого параметра.</param>
        /// <returns>Возвращает экземпляр RevitParam, соответствующий заданному идентификатору параметра.</returns>
        RevitParam Create(Document document, ElementId paramId);
        
        /// <summary>
        /// Создаёт новый экземпляр класса RevitParam.
        /// </summary>
        /// <param name="document">Revit-документ, в котором находится параметр.</param>
        /// <param name="paramDefinition"><see cref="Definition"/> создаваемого параметра.</param>
        /// <returns>Возвращает экземпляр RevitParam, соответствующий заданному <see cref="Definition"/>.</returns>
        RevitParam Create(Document document, Definition paramDefinition);
        
        /// <summary>
        /// Создаёт новый экземпляр класса RevitParam.
        /// </summary>
        /// <param name="document">Revit-документ, в котором находится параметр.</param>
        /// <param name="paramElement"><see cref="ParameterElement"/> создаваемого параметра.</param>
        /// <returns>Возвращает экземпляр RevitParam, соответствующий заданному <see cref="ParameterElement"/>.</returns>
        RevitParam Create(Document document, ParameterElement paramElement);
    }
}