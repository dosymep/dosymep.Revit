using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices;

/// <summary>
///     Фабрика трекеров доступности элементов для редактирования.
/// </summary>
public interface IElementEditorTrackerFactory {
    /// <summary>
    ///     Создает трекер для указанного документа.
    /// </summary>
    /// <param name="document">Документ, содержащий проверяемые элементы.</param>
    /// <returns>Новый трекер доступности элементов.</returns>
    IElementEditorTracker Create(Document document);
}
