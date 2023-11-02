using System;

using Autodesk.Revit.UI;

using dosymep.Revit.WinApi;

namespace dosymep.Revit {
    /// <summary>
    /// Расширение для класса <see cref="Autodesk.Revit.UI.UIApplication"/>.
    /// </summary>
    public static class UIApplicationExtensions {
        /// <summary>
        /// Устанавливает текст в статус баре в приложении Revit.
        /// <p>https://jeremytammik.github.io/tbc/a/0534_status_bar_text.htm</p>
        /// </summary>
        /// <param name="uiApplication">Приложение.</param>
        /// <param name="text">Отображаемый текст в статус баре.</param>
        public static void SetStatusBarText(this UIApplication uiApplication, string text) {
            IntPtr statusBar = NativeMethods.FindWindowEx(uiApplication.MainWindowHandle,
                IntPtr.Zero, "msctls_statusbar32", "");

            if(statusBar != IntPtr.Zero) {
                NativeMethods.SetWindowText(statusBar, text);
            }
        }
    }
}