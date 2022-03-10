using System;

using Autodesk.Revit.UI;

using dosymep.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class RevitThemeService : IUIThemeService {
        public event Action<UIThemes> UIThemeChanged;
        public UIThemes HostTheme => GetRevitUITheme(); 

        private UIThemes GetRevitUITheme() {
            if(UIThemeManager.CurrentTheme == UITheme.Dark) {
                return UIThemes.Dark;
            } else if(UIThemeManager.CurrentTheme == UITheme.Light) {
                return UIThemes.Light;
            }

            return UIThemes.Light;
        }
    }
}