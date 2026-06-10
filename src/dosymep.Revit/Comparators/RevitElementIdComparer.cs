using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators;

internal sealed class RevitElementIdComparer : RevitElementComparer {
    public static readonly RevitElementIdComparer Default = new();

    public override int Compare(Element x, Element y) {
        if(x?.Id is null && y?.Id is null) {
            return 0;
        }

        if(x?.Id is null) {
            return -1;
        }

        if(y?.Id is null) {
            return 1;
        }

        return x.Id.Compare(y.Id);
    }

    public override bool Equals(Element x, Element y) {
        if(x?.Id is null && y?.Id is null) {
            return true;
        }

        if(x?.Id is null) {
            return false;
        }

        if(y?.Id is null) {
            return false;
        }

        return x.Id.Equals(y.Id);
    }

    public override int GetHashCode(Element obj) {
        return obj.Id.GetHashCode();
    }
}