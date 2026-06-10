using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators;

/// <summary>
///     Компаратор для листов.
/// </summary>
/// <remarks>
///     Используется умное сравнение <see cref="LogicalStringComparer" />. Сравнивает по свойству
///     <see cref="ViewSheet.SheetNumber" />.
/// </remarks>
[Obsolete]
public class ViewSheetComparer : IComparer<ViewSheet> {
    private readonly LogicalStringComparer _logicalStringComparer = new();

    /// <inheritdoc />
    public int Compare(ViewSheet x, ViewSheet y) {
        return _logicalStringComparer.Compare(x?.SheetNumber, y?.SheetNumber);
    }
}