using System;
using System.IO;
using System.Windows;

using Autodesk.Revit.UI;

using Ninject;

using dosymep.SimpleServices;
using dosymep.Xpf.Core.SimpleServices;

using Ninject.Activation;

using Serilog;
using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Класс предоставляющий доступ к внутренним сервисам платформы
    /// </summary>
    public static class ServicesProvider {
        /// <summary>
        /// Контейнер сервисов платформы.
        /// </summary>
        public static IKernel Instance { get; private set; }

        /// <summary>
        /// Загружает сервисы платформы.
        /// </summary>
        public static void LoadInstance(UIApplication uiApplication) {
            Instance?.Dispose();
            Instance = new StandardKernel();

            Instance.Bind<IDispatcherService>().To<XtraDispatcherService>().InSingletonScope();
            Instance.Bind<IMessageBoxService>().To<XtraMessageBoxService>().InSingletonScope();
            Instance.Bind<INotificationService>().To<XtraNotificationService>().InSingletonScope();
            Instance.Bind<IOpenFileDialogService>().To<XtraOpenFileDialogService>().InSingletonScope();
            Instance.Bind<ISaveFileDialogService>().To<XtraSaveFileDialogService>().InSingletonScope();
            Instance.Bind<IOpenFolderDialogService>().To<XtraOpenFolderDialogService>().InSingletonScope();

            Instance.Bind<ILoggerService>().To<SerilogService>().InSingletonScope();
            Instance.Bind<ILogger>().ToMethod(context => InitLogger(context, uiApplication)).InSingletonScope();
        }

        private static ILogger InitLogger(IContext context, UIApplication uiApplication) {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "pyRevit", "Logs", uiApplication.Application.VersionNumber, "platform_.log");

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("PluginName", "Bim4Everyone")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("EnvironmentUserName", Environment.UserName)
                .Enrich.WithProperty("RevitVersion", uiApplication.Application.VersionBuild)
                .Enrich.WithProperty("AutodeskUsername", uiApplication.Application.Username)
                .Enrich.WithProperty("AutodeskLoginUserId", uiApplication.Application.LoginUserId)
                .WriteTo.File(fileName, 
                    fileSizeLimitBytes: 50000000, rollOnFileSizeLimit: true, retainedFileCountLimit: 10,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {PluginName} "
                                    //+ "{{\"MachineName\": \"{MachineName}\", \"UserName\": \"{EnvironmentUserName}\", \"$type\": \"Windows\"}} "
                                    + "{{\"RevitVersion\": \"{RevitVersion}\", \"UserName\": \"{AutodeskUsername}\", \"LoginUserId\": \"{AutodeskLoginUserId}\", \"$type\": \"Autodesk\"}} "
                                    + "{Message}{NewLine}{Exception}")
                .MinimumLevel.Verbose();

            return loggerConfiguration.CreateLogger();
        }

        /// <summary>
        /// Возвращает сервис из контейнера.
        /// </summary>
        /// <typeparam name="T">Запрашиваемый сервис.</typeparam>
        /// <returns>Возвращает сервис из контейнера.</returns>
        public static T GetPlatformService<T>() {
            return Instance.Get<T>();
        }
    }
}