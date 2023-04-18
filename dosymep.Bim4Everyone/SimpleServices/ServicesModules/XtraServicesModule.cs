using System.Windows;
using System.Windows.Interop;

using Autodesk.Revit.UI;

using dosymep.SimpleServices;
using dosymep.Xpf.Core.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class XtraServicesModule : NinjectModule {
        public override void Load() {
            Bind<IUIThemeService>()
                .To<XtraWindowsThemeService>()
                .InSingletonScope();

            Bind<IUIThemeUpdaterService>()
                .To<XtraThemeUpdaterService>()
                .InSingletonScope();

            Bind<IDispatcherService>()
                .To<XtraDispatcherService>();

            Bind<IMessageBoxService>()
                .To<XtraMessageBoxService>();

            Bind<IOpenFileDialogService>()
                .To<XtraOpenFileDialogService>();

            Bind<ISaveFileDialogService>()
                .To<XtraSaveFileDialogService>();

            Bind<IOpenFolderDialogService>()
                .To<XtraOpenFolderDialogService>();

            Bind<IProgressDialogService>()
                .To<XtraProgressDialogService>()
                .WithPropertyValue(nameof(XtraProgressDialogService.UIThemeService),
                    c => c.Kernel.Get<IUIThemeService>())
                .WithPropertyValue(nameof(XtraProgressDialogService.UIThemeUpdaterService),
                    c => c.Kernel.Get<IUIThemeUpdaterService>());

            Bind<INotificationService>()
                .To<XtraNotificationService>()
                .WithConstructorArgument(typeof(string), "Bim4Everyone")
                .WithPropertyValue(nameof(XtraProgressDialogService.UIThemeService),
                    c => c.Kernel.Get<IUIThemeService>());
        }
    }
}