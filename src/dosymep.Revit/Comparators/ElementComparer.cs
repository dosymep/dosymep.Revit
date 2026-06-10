using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators;

/// <summary>
///     Компаратор для элемента.
/// </summary>
/// <remarks>
///     Используется умное сравнение <see cref="LogicalStringComparer" />. Сравнивает по свойству
///     <see cref="Autodesk.Revit.DB.Element.Name" />.
/// </remarks>
[Obsolete]
public class ElementComparer : IComparer<Element> {
    private readonly LogicalStringComparer _logicalStringComparer = new();

    /// <inheritdoc />
    public int Compare(Element x, Element y) {
        return _logicalStringComparer.Compare(x?.Name, y?.Name);
    }
}