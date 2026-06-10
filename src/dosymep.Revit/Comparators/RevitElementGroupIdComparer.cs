using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators;

internal sealed class RevitElementGroupIdComparer : RevitElementComparer {
    public static readonly RevitElementGroupIdComparer Default = new();

    public override int Compare(Element x, Element y) {
        if(x?.GroupId is null && y?.GroupId is null) {
            return 0;
        }

        if(x?.GroupId is null) {
            return -1;
        }

        if(y?.GroupId is null) {
            return 1;
        }

        return x.GroupId.Compare(y.GroupId);
    }

    public override bool Equals(Element x, Element y) {
        if(x?.GroupId is null && y?.GroupId is null) {
            return true;
        }

        if(x?.GroupId is null) {
            return false;
        }

        if(y?.GroupId is null) {
            return false;
        }

        return x.GroupId.Equals(y.GroupId);
    }

    public override int GetHashCode(Element obj) {
        return obj.GroupId?.GetHashCode() ?? 0;
    }
}