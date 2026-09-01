using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices.ElementEditorTracker;

internal class ElementEditorTrackerFactory : IElementEditorTrackerFactory {
    /// <inheritdoc />
    public IElementEditorTracker Create(Document document) {
        if(document == null) {
            throw new ArgumentNullException(nameof(document));
        }

        return new ElementEditorTracker(document);
    }
}
