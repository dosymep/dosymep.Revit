using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    internal sealed class RevitElementCategoryIdComparer : RevitElementComparer {
        public override int Compare(Element x, Element y) {
            if(x?.Category is null && y?.Category is null) {
                return 0;
            }

            if(x?.Category is null) {
                return -1;
            }

            if(y?.Category is null) {
                return 1;
            }

            return x.Category.Id.Compare(y.Category.Id);
        }

        public override bool Equals(Element x, Element y) {
            if(x?.Category is null && y?.Category is null) {
                return true;
            }

            if(x?.Category is null) {
                return false;
            }

            if(y?.Category is null) {
                return false;
            }

            return x.Category.Id.Equals(y.Category.Id);
        }

        public override int GetHashCode(Element obj) {
            return obj.Category?.Id.GetHashCode() ?? 0;
        }
    }
}