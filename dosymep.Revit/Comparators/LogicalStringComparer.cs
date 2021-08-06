using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dosymep.Revit.Comparators {
    /// <summary>
    /// Умное сравнение строк.
    /// </summary>
    /// <remarks>Для сравнения используется метод WinApi <see cref="StrCmpLogicalW"/></remarks>
    public class LogicalStringComparer : IComparer<string> {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string x, string y);

        /// <inheritdoc/>
        public int Compare(string x, string y) {
            return StrCmpLogicalW(x, y);
        }
    }
}
