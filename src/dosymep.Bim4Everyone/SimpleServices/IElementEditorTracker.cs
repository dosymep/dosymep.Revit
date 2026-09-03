using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices;

/// <summary>
///     Проверяет доступность элементов для редактирования в модели с совместной работой
///     и накапливает сведения о причинах их недоступности.
/// </summary>
public interface IElementEditorTracker {
    /// <summary>
    ///     Проверяет, доступен ли элемент для редактирования, и сохраняет причину недоступности.
    /// </summary>
    /// <param name="element">Проверяемый элемент.</param>
    /// <returns>
    ///     <see langword="true" />, если элемент доступен для редактирования;
    ///     иначе <see langword="false" />. Для модели без совместной работы всегда возвращает
    ///     <see langword="true" />.
    /// </returns>
    bool IsEditAvailable(Element element);

    /// <summary>
    ///     Возвращает накопленные сведения о причинах недоступности проверенных элементов.
    /// </summary>
    /// <returns>
    ///     Именованный кортеж, в котором <c>RequiresSynchronization</c> указывает, что хотя бы один элемент
    ///     обновлен в файле хранилища, а <c>Owners</c> содержит отсортированный список уникальных имен
    ///     пользователей, занявших элементы. Если такие элементы отсутствуют, список пуст.
    /// </returns>
    (bool RequiresSynchronization, IReadOnlyCollection<string> Owners) GetUnavailabilityInfo();

    /// <summary>
    ///     Очищает накопленные сведения о причинах недоступности элементов.
    /// </summary>
    void Reset();
}
