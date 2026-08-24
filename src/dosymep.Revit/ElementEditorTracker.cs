using Autodesk.Revit.DB;

namespace dosymep.Revit;

/// <summary>
///     Проверяет доступность элементов для редактирования в модели с совместной работой.
/// </summary>
public class ElementEditorTracker {
    private const string UnknownOwner = "неизвестный пользователь";

    private readonly Document _document;
    private readonly bool _isWorkshared;
    private readonly HashSet<string> _owners = new(StringComparer.OrdinalIgnoreCase);
    private bool _hasUpdatedInCentralElements;

    /// <summary>
    ///     Создает экземпляр класса для проверки доступности элементов.
    /// </summary>
    /// <param name="document">Документ, содержащий проверяемые элементы.</param>
    /// <exception cref="System.ArgumentNullException">
    ///     Документ равен <see langword="null" />.
    /// </exception>
    public ElementEditorTracker(Document document) {
        _document = document;
        _isWorkshared = document.IsWorkshared;
    }

    /// <summary>
    ///     Проверяет, занят ли элемент другим пользователем или обновлен ли он в файле хранилища.
    /// </summary>
    /// <param name="element">Проверяемый элемент.</param>
    /// <returns><see langword="true" />, если элемент недоступен для редактирования.</returns>
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
    ///     Возвращает отчет о недоступных элементах и очищает накопленные сведения.
    /// </summary>
    /// <returns>Текст отчета или пустая строка, если недоступных элементов нет.</returns>
    public string GetReportText() {
        if(!_hasUpdatedInCentralElements && _owners.Count == 0) {
            return string.Empty;
        }

        List<string> reports = [];
        if(_hasUpdatedInCentralElements) {
            reports.Add("Вы владеете элементами, но ваш файл устарел. Выполните синхронизацию.");
        }

        if(_owners.Count > 0) {
            string owners = string.Join(", ",
                _owners.OrderBy(item => item, StringComparer.OrdinalIgnoreCase));
            reports.Add(
                "Некоторые элементы не были обработаны, так как заняты пользователем/пользователями: "
                + owners);
        }

        string reportText = string.Join(Environment.NewLine, reports);

        _hasUpdatedInCentralElements = false;
        _owners.Clear();

        return reportText;
    }
}