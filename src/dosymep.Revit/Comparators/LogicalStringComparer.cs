using System.Runtime.InteropServices;

namespace dosymep.Revit.Comparators;

/// <summary>
///     Умное сравнение строк.
/// </summary>
/// <remarks>Для сравнения используется метод WinApi <see cref="StrCmpLogicalW" /></remarks>
[Obsolete]
public class LogicalStringComparer : IComparer<string> {
    /// <inheritdoc />
    public int Compare(string x, string y) {
        return StrCmpLogicalW(x, y);
    }

    [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    private static extern int StrCmpLogicalW(string x, string y);
}