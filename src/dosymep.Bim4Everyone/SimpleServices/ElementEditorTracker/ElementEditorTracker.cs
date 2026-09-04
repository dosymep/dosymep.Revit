using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices.ElementEditorTracker;

internal class ElementEditorTracker : IElementEditorTracker {
    private readonly Document _document;
    private readonly bool _isWorkshared;
    private readonly HashSet<string> _owners = new(StringComparer.OrdinalIgnoreCase);
    private bool _hasUpdatedInCentralElements;

    public ElementEditorTracker(Document document) {
        _document = document ?? throw new ArgumentNullException(nameof(document));
        _isWorkshared = document.IsWorkshared;
    }

    /// <inheritdoc />
    public bool IsEditAvailable(Element element) {
        if(element == null) {
            throw new ArgumentNullException(nameof(element));
        }

        if(!_isWorkshared) {
            return true;
        }

        if(TryRegisterOwner(element)) {
            return false;
        }

        if(IsUpdatedInCentral(element)) {
            _hasUpdatedInCentralElements = true;
            return false;
        }

        return true;
    }

    /// <inheritdoc />
    public (bool RequiresSynchronization, IReadOnlyCollection<string> Owners) GetUnavailabilityInfo() {
        bool requiresSynchronization = _hasUpdatedInCentralElements;
        string[] owners = _owners
            .OrderBy(item => item, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        return (requiresSynchronization, owners);
    }

    /// <inheritdoc />
    public void Reset() {
        _hasUpdatedInCentralElements = false;
        _owners.Clear();
    }

    private bool TryRegisterOwner(Element element) {
        CheckoutStatus status = WorksharingUtils.GetCheckoutStatus(
            _document,
            element.Id,
            out string owner);

        bool isOwnedByOtherUser = status == CheckoutStatus.OwnedByOtherUser;
        if(isOwnedByOtherUser && !string.IsNullOrWhiteSpace(owner)) {
            _owners.Add(owner);
        }

        return isOwnedByOtherUser;
    }

    private bool IsUpdatedInCentral(Element element) {
        ModelUpdatesStatus updateStatus = WorksharingUtils.GetModelUpdatesStatus(_document, element.Id);
        return updateStatus == ModelUpdatesStatus.UpdatedInCentral;
    }
}
