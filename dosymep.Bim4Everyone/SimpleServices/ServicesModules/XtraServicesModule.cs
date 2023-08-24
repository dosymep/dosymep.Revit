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
#if REVIT_2023_OR_LESS
            Bind<IUIThemeService>()
                .To<XtraWindowsThemeService>()
                .InSingletonScope();
#else
            Bind<IUIThemeService>()
                .To<RevitThemeService>()
                .InSingletonScope();
#endif

            Bind<IUIThemeUpdaterService>()
                .To<XtraThemeUpdaterService>()
                .InSingletonScope();

            Bind<IMessageBoxService>()
                .To<XtraMessageBoxService>()
                .WithConstructorArgument("window", c => null);

            Bind<IOpenFileDialogService>()
                .To<XtraOpenFileDialogService>()
                .WithConstructorArgument("window", c => null);

            Bind<ISaveFileDialogService>()
                .To<XtraSaveFileDialogService>()
                .WithConstructorArgument("window", c => null);

            Bind<IOpenFolderDialogService>()
                .To<XtraOpenFolderDialogService>()
                .WithConstructorArgument("window", c => null);

            Bind<IProgressDialogService>()
                .To<XtraProgressDialogService>()
                .WithPropertyValue(nameof(XtraProgressDialogService.UIThemeService),
                    c => c.Kernel.Get<IUIThemeService>())
                .WithPropertyValue(nameof(XtraProgressDialogService.UIThemeUpdaterService),
                    c => c.Kernel.Get<IUIThemeUpdaterService>())
                .WithConstructorArgument("window", c => null);

            Bind<INotificationService>()
                .To<XtraNotificationService>()
                .WithConstructorArgument(typeof(string), "Bim4Everyone")
                .WithPropertyValue(nameof(XtraProgressDialogService.UIThemeService),
                    c => c.Kernel.Get<IUIThemeService>())
                .WithConstructorArgument("window", c => null);
        }
    }
}