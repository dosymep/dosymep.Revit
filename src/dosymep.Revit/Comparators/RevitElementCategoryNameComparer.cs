using System;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    internal sealed class RevitElementCategoryNameComparer : RevitElementComparer {
        private readonly StringComparer _stringComparer;
        private readonly bool _useNamingUtils;

        public RevitElementCategoryNameComparer(bool useNamingUtils, StringComparer stringComparer) {
            _useNamingUtils = useNamingUtils;
            _stringComparer = stringComparer;
        }

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

            return _useNamingUtils
                ? NamingUtils.CompareNames(x.Category.Name, y.Category.Name)
                : _stringComparer.Compare(x.Category.Name, y.Category.Name);
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

            return _stringComparer.Equals(x.Category.Name, y.Category.Name);
        }

        public override int GetHashCode(Element obj) {
            return _stringComparer.GetHashCode(obj.Category.Name);
        }
    }
}