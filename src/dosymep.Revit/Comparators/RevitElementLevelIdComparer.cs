using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    internal sealed class RevitElementLevelIdComparer : RevitElementComparer {
        public override int Compare(Element x, Element y) {
            if(x?.LevelId is null && y?.LevelId is null) {
                return 0;
            }

            if(x?.LevelId is null) {
                return -1;
            }

            if(y?.LevelId is null) {
                return 1;
            }

            return x.LevelId.Compare(y.LevelId);
        }

        public override bool Equals(Element x, Element y) {
            if(x?.LevelId is null && y?.LevelId is null) {
                return true;
            }

            if(x?.LevelId is null) {
                return false;
            }

            if(y?.LevelId is null) {
                return false;
            }

            return x.LevelId.Equals(y.LevelId);
        }

        public override int GetHashCode(Element obj) {
            return obj.LevelId.GetHashCode();
        }
    }
}