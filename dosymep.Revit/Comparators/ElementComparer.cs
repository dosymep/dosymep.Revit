using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Comparators {
    /// <summary>
    /// Компаратор для элемента.
    /// </summary>
    /// <remarks>Используется умное сравнение <see cref="LogicalStringComparer"/></remarks>
    public class ElementComparer : IComparer<Element> {
        private readonly LogicalStringComparer _logicalStringComparer = new LogicalStringComparer();

        /// <inheritdoc/>
        public int Compare(Element x, Element y) {
            return _logicalStringComparer.Compare(x?.Name, y?.Name);
        }
    }
}
