using Autodesk.Revit.DB;

namespace dosymep.Revit;

/// <summary>
///     Проверяет доступность элементов для редактирования в модели с совместной работой
///     и накапливает сведения о причинах их недоступности.
/// </summary>
public class ElementEditorTracker {
    private const string UnknownOwner = "неизвестный пользователь";

    private readonly Document _document;
    private readonly bool _isWorkshared;
    private readonly HashSet<string> _owners = new(StringComparer.OrdinalIgnoreCase);
    private bool _hasUpdatedInCentralElements;

    /// <summary>
    ///     Создает трекер доступности элементов для указанного документа.
    /// </summary>
    /// <param name="document">Документ, содержащий проверяемые элементы.</param>
    public ElementEditorTracker(Document document) {
        _document = document;
        _isWorkshared = document.IsWorkshared;
    }

    /// <summary>
    ///     Проверяет, занят ли элемент другим пользователем или обновлен ли он в файле хранилища,
    ///     и сохраняет причину недоступности.
    /// </summary>
    /// <param name="element">Проверяемый элемент.</param>
    /// <returns>
    ///     <see langword="true" />, если элемент занят другим пользователем или обновлен в файле хранилища;
    ///     иначе <see langword="false" />. Для модели без совместной работы всегда возвращает
    ///     <see langword="false" />.
    /// </returns>
    public bool IsUnavailableForEdit(Element element) {
        if(!_isWorkshared) {
            return false;
        }

        if(TryRegisterOwner(element)) {
            return true;
        }

        ModelUpdatesStatus updateStatus = WorksharingUtils.GetModelUpdatesStatus(_document, element.Id);
        bool isUpdatedInCentral = updateStatus == ModelUpdatesStatus.UpdatedInCentral;
        if(isUpdatedInCentral) {
            _hasUpdatedInCentralElements = true;
        }

        return isUpdatedInCentral;
    }

    private bool TryRegisterOwner(Element element) {
        CheckoutStatus status = WorksharingUtils.GetCheckoutStatus(
            _document,
            element.Id,
            out string owner);

        bool isOwnedByOtherUser = status == CheckoutStatus.OwnedByOtherUser;
        if(isOwnedByOtherUser) {
            _owners.Add(string.IsNullOrWhiteSpace(owner) ? UnknownOwner : owner);
        }

        return isOwnedByOtherUser;
    }

    /// <summary>
    ///     Возвращает накопленные сведения о причинах недоступности проверенных элементов
    ///     и очищает внутреннее состояние трекера.
    /// </summary>
    /// <returns>
    ///     Именованный кортеж, в котором <c>RequiresSynchronization</c> указывает, что хотя бы один элемент
    ///     обновлен в файле хранилища, а <c>Owners</c> содержит отсортированный список уникальных имен
    ///     пользователей, занявших элементы. Если такие элементы отсутствуют, список пуст.
    /// </returns>
    public (bool RequiresSynchronization, IReadOnlyCollection<string> Owners) GetUnavailabilityInfo() {
        bool requiresSynchronization = _hasUpdatedInCentralElements;
        string[] owners = _owners
            .OrderBy(item => item, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        _hasUpdatedInCentralElements = false;
        _owners.Clear();

        return (requiresSynchronization, owners);
    }
}
