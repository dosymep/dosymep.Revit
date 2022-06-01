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
                .To<XtraWindowsThemeService>();

            Bind<WindowInteropHelper>()
                .ToSelf()
                .WithPropertyValue(nameof(WindowInteropHelper.Owner),
                    c => c.Kernel.Get<UIApplication>().MainWindowHandle);

            Bind<IDispatcherService>()
                .To<XtraDispatcherService>()
                .WithConstructorArgument(typeof(Window), GetRootWindow);

            Bind<IMessageBoxService>()
                .To<XtraMessageBoxService>()
                .WithConstructorArgument(typeof(Window), GetRootWindow);

            Bind<IOpenFileDialogService>()
                .To<XtraOpenFileDialogService>()
                .WithConstructorArgument(typeof(Window), GetRootWindow);

            Bind<ISaveFileDialogService>()
                .To<XtraSaveFileDialogService>()
                .WithConstructorArgument(typeof(Window), GetRootWindow);

            Bind<IOpenFolderDialogService>()
                .To<XtraOpenFolderDialogService>()
                .WithConstructorArgument(typeof(Window), GetRootWindow);

            Bind<IProgressDialogService>()
                .To<XtraProgressDialogService>()
                .WithConstructorArgument(typeof(Window), GetRootWindow);

            Bind<INotificationService>()
                .To<XtraNotificationService>()
                .WithConstructorArgument(typeof(string), "Bim4Everyone")
                .WithConstructorArgument(typeof(Window), GetRootWindow);
        }

        private Window GetRootWindow(IContext context) {
            return context.Kernel.Get<IRootWindowService>().RootWindow;
        }
    }
}