using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    public class ElementComparer : IComparer<Element> {
        private readonly LogicalStringComparer _logicalStringComparer = new LogicalStringComparer();

        public int Compare(Element x, Element y) {
            return _logicalStringComparer.Compare(x?.Name, y?.Name);
        }
    }
}
