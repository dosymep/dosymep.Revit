using System;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    internal sealed class RevitElementNameComparer : RevitElementComparer {
        public static readonly RevitElementNameComparer Default = new RevitElementNameComparer();

        /// <summary>
        /// Сравнивает имена элементов с использованием <see cref="NamingUtils"/>.
        /// </summary>
        public static readonly RevitElementNameComparer Naming = new RevitElementNameComparer();

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

            return NamingUtils.CompareNames(x.Name, y.Name);
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

            return NamingUtils.CompareNames(x.Name, y.Name) == 0;
        }

        public override int GetHashCode(Element obj) {
            return obj.Name?.GetHashCode() ?? 0;
        }
    }
}