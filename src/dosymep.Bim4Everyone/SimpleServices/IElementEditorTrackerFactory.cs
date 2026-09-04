namespace dosymep.Bim4Everyone.SimpleServices;

/// <summary>
///     Фабрика трекеров доступности элементов для редактирования.
/// </summary>
public interface IElementEditorTrackerFactory {
    /// <summary>
    ///     Создает трекер для документа, зарегистрированного в контейнере зависимостей.
    /// </summary>
    /// <returns>Новый трекер доступности элементов.</returns>
    IElementEditorTracker Create();
}
