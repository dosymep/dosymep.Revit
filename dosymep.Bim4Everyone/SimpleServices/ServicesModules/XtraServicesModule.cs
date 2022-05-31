using System.Windows;
using System.Windows.Interop;

using Autodesk.Revit.UI;

using dosymep.SimpleServices;
using dosymep.Xpf.Core.SimpleServices;

using Ninject;
using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class XtraServicesModule : NinjectModule {
        public override void Load() {
            Bind<IUIThemeService>()
                .To<XtraWindowsThemeService>();

            Bind<WindowInteropHelper>()
                .ToSelf()
                .WithPropertyValue(nameof(WindowInteropHelper.Owner),
                    c => c.Kernel.Get<UIApplication>().MainWindowHandle);

            Bind<IDispatcherService>()
                .To<XtraDispatcherService>()
                .WithConstructorArgument(typeof(Window), c => c.Kernel.TryGet<Window>());

            Bind<IMessageBoxService>()
                .To<XtraMessageBoxService>()
                .WithConstructorArgument(typeof(Window), c => c.Kernel.TryGet<Window>());

            Bind<IOpenFileDialogService>()
                .To<XtraOpenFileDialogService>()
                .WithConstructorArgument(typeof(Window), c => c.Kernel.TryGet<Window>());

            Bind<ISaveFileDialogService>()
                .To<XtraSaveFileDialogService>()
                .WithConstructorArgument(typeof(Window), c => c.Kernel.TryGet<Window>());

            Bind<IOpenFolderDialogService>()
                .To<XtraOpenFolderDialogService>()
                .WithConstructorArgument(typeof(Window), c => c.Kernel.TryGet<Window>());

            Bind<INotificationService>()
                .To<XtraNotificationService>()
                .WithConstructorArgument(typeof(string), "Bim4Everyone")
                .WithConstructorArgument(typeof(Window), c => c.Kernel.TryGet<Window>());
        }
    }
}