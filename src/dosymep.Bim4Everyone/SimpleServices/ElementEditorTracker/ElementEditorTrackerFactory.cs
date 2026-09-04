using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices.ElementEditorTracker;

internal class ElementEditorTrackerFactory : IElementEditorTrackerFactory {
    private readonly Document _document;

    public ElementEditorTrackerFactory(Document document) {
        _document = document ?? throw new ArgumentNullException(nameof(document));
    }

    /// <inheritdoc />
    public IElementEditorTracker Create() {
        return new ElementEditorTracker(_document);
    }
}
