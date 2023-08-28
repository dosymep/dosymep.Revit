using System;
using System.Windows;
using System.Windows.Interop;

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
#if REVIT_2023_OR_LESS
            Kernel?.UseXtraTheme();
#else
            Bind<IUIThemeService>()
                .To<RevitThemeService>()
                .InSingletonScope();
#endif
            Kernel?.UseXtraMessageBox();
            Kernel?.UseXtraThemeUpdater();
            Kernel?.UseXtraProgressDialog();

            Kernel?.UseXtraNotifications(
                applicationId: "Revit " + ModuleEnvironment.RevitVersion,
                defaultAuthor: "dosymep",
                defaultFooter: "Revit " + ModuleEnvironment.RevitVersion);

            Kernel?.UseXtraOpenFileDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            Kernel?.UseXtraSaveFileDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            Kernel?.UseXtraOpenFolderDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}