using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

using dosymep.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices;

internal class RevitThemeService :
    IUIThemeService
#if REVIT2024_OR_GREATER
    , IDisposable
#endif
{
    public event Action<UIThemes> UIThemeChanged = ui => { };

    public UIThemes HostTheme => GetRevitUITheme();

    private UIThemes GetRevitUITheme() {
        if(UIThemeManager.CurrentTheme == UITheme.Dark) {
            return UIThemes.Dark;
        }

        if(UIThemeManager.CurrentTheme == UITheme.Light) {
            return UIThemes.Light;
        }

        return UIThemes.Light;
    }

#if REVIT2024_OR_GREATER
    private readonly UIApplication _uiApplication;

    public RevitThemeService(UIApplication uiApplication) {
        _uiApplication = uiApplication;
        _uiApplication.ThemeChanged += UIApplicationOnThemeChanged;
    }

    private void UIApplicationOnThemeChanged(object sender, ThemeChangedEventArgs e) {
        UIThemeChanged?.Invoke(HostTheme);
    }

    public void Dispose() {
        _uiApplication.ThemeChanged -= UIApplicationOnThemeChanged;
    }
#endif
}