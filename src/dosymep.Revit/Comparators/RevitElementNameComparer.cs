using System;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    internal sealed class RevitElementNameComparer : RevitElementComparer {
        private readonly StringComparer _stringComparer;
        private readonly bool _useNamingUtils;

        public RevitElementNameComparer(bool useNamingUtils, StringComparer stringComparer) {
            _useNamingUtils = useNamingUtils;
            _stringComparer = stringComparer;
        }

        public override int Compare(Element x, Element y) {
            if(x?.Name is null && y?.Name is null) {
                return 0;
            }

            if(x?.Name is null) {
                return -1;
            }

            if(y?.Name is null) {
                return 1;
            }

            return _useNamingUtils
                ? NamingUtils.CompareNames(x.Name, y.Name)
                : _stringComparer.Compare(x.Name, y.Name);
        }

        public override bool Equals(Element x, Element y) {
            if(x?.Name is null && y?.Name is null) {
                return true;
            }

            if(x?.Name is null) {
                return false;
            }

            if(y?.Name is null) {
                return false;
            }

            return _stringComparer.Equals(x.Name, y.Name);
        }

        public override int GetHashCode(Element obj) {
            return _stringComparer.GetHashCode(obj.Name);
        }
    }
}