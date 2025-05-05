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
        /// Проверяет возможность создания экземпляра RevitParam на основе заданного документа и идентификатора параметра.
        /// </summary>
        /// <param name="document">Revit-документ, в котором выполняется проверка.</param>
        /// <param name="paramId">Идентификатор параметра, для которого требуется проверить возможность создания.</param>
        /// <returns>Возвращает true, если возможно создать экземпляр RevitParam; в противном случае возвращает false.</returns>
        bool CanCreate(Document document, ElementId paramId);
    }
}