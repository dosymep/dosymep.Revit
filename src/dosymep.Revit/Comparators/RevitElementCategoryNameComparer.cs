using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators;

internal sealed class RevitElementCategoryNameComparer : RevitElementComparer {
    public static readonly RevitElementCategoryNameComparer Default = new();

    public override int Compare(Element x, Element y) {
        if(x?.Category?.Name is null && y?.Category?.Name is null) {
            return 0;
        }

        if(x?.Category?.Name is null) {
            return -1;
        }

        if(y?.Category?.Name is null) {
            return 1;
        }

        return NamingUtils.CompareNames(x.Category.Name, y.Category.Name);
    }

    public override bool Equals(Element x, Element y) {
        if(x?.Category?.Name is null && y?.Category?.Name is null) {
            return true;
        }

        if(x?.Category?.Name is null) {
            return false;
        }

        if(y?.Category?.Name is null) {
            return false;
        }

        return NamingUtils.CompareNames(x.Category.Name, y.Category.Name) == 0;
    }

    public override int GetHashCode(Element obj) {
        return obj.Category?.Name?.GetHashCode() ?? 0;
    }
}