using Autofac;

using dosymep.SimpleServices;
using dosymep.Xpf.Core.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Класс предоставляющий доступ к внутренним сервисам платформы
    /// </summary>
    public static class ServicesProvider {
        /// <summary>
        /// Контейнер сервисов платформы.
        /// </summary>
        public static IContainer PlatformContainer { get; }

        static ServicesProvider() {
            var builder = new ContainerBuilder();

            builder.RegisterType<XtraDispatcherService>().As<IDispatcherService>().SingleInstance();
            builder.RegisterType<XtraMessageBoxService>().As<IMessageBoxService>().SingleInstance();
            builder.RegisterType<XtraNotificationService>().As<INotificationService>().SingleInstance();
            builder.RegisterType<XtraOpenFileDialogService>().As<IOpenFileDialogService>().SingleInstance();
            builder.RegisterType<XtraSaveFileDialogService>().As<ISaveFileDialogService>().SingleInstance();
            builder.RegisterType<XtraOpenFolderDialogService>().As<IOpenFolderDialogService>().SingleInstance();

            PlatformContainer = builder.Build();
        }
    }
}