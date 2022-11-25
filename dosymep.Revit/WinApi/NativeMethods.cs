using System;
using System.Runtime.InteropServices;

namespace dosymep.Revit.WinApi {
    internal class NativeMethods {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, 
            string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, 
            IntPtr hwndChildAfter, 
            string lpszClass,
            string lpszWindow);
    }
}