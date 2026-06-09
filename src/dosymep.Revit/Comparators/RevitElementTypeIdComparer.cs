using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    internal sealed class RevitElementTypeIdComparer : RevitElementComparer {
        public static readonly RevitElementTypeIdComparer Default = new RevitElementTypeIdComparer();

        public override int Compare(Element x, Element y) {
            ElementId xTypeId = x?.GetTypeId();
            ElementId yTypeId = y?.GetTypeId();

            if(xTypeId is null && yTypeId is null) {
                return 0;
            }

            if(xTypeId is null) {
                return -1;
            }

            if(yTypeId is null) {
                return 1;
            }

            return xTypeId.Compare(yTypeId);
        }

        public override bool Equals(Element x, Element y) {
            ElementId xTypeId = x?.GetTypeId();
            ElementId yTypeId = y?.GetTypeId();

            if(xTypeId is null && yTypeId is null) {
                return true;
            }

            if(xTypeId is null) {
                return false;
            }

            if(yTypeId is null) {
                return false;
            }

            return xTypeId.Equals(yTypeId);
        }

        public override int GetHashCode(Element obj) {
            return obj.GetTypeId()?.GetHashCode() ?? 0;
        }
    }
}