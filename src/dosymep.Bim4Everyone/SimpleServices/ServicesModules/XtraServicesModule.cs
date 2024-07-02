using System;
using System.Globalization;
using System.IO;
using System.Net.Cache;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

using Autodesk.Revit.UI;

using dosymep.SimpleServices;
using dosymep.Xpf.Core.Ninject;
using dosymep.Xpf.Core.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class XtraServicesModule : NinjectModule {
        public override void Load() {
#if REVIT2024_OR_GREATER
            Bind<IUIThemeService>()
                .To<RevitThemeService>()
                .InSingletonScope();
#else
            Kernel?.UseXtraTheme();
#endif
            Kernel?.UseXtraMessageBox();
            Kernel?.UseXtraThemeUpdater();
            Kernel?.UseXtraProgressDialog();
            
            Kernel?.UseXtraNotifications(
                applicationId: "Revit " + ModuleEnvironment.RevitVersion,
                defaultAuthor: "dosymep",
                defaultFooter: "Revit " + ModuleEnvironment.RevitVersion,
                defaultImage: new BitmapImage(new Uri("/dosymep.Bim4Everyone;component/assets/Bim4Everyone.png", UriKind.Relative)));

            Kernel?.UseXtraOpenFileDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            Kernel?.UseXtraSaveFileDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            Kernel?.UseXtraOpenFolderDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            
            Kernel?.UseXtraLocalization(
                $"/dosymep.Bim4Everyone;component/Localization/Language.xaml",
                CultureInfo.GetCultureInfo("ru-RU"));
        }
    }
}