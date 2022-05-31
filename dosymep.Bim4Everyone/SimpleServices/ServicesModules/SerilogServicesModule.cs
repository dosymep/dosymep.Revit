using System;
using System.IO;

using Autodesk.Revit.UI;

using dosymep.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

using Serilog;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class SerilogServicesModule : NinjectModule {
        public override void Load() {
            Bind<ILogger>().ToMethod(InitLogger).InSingletonScope();
            Bind<ILoggerService>().To<SerilogService>().InSingletonScope();
        }

        private static ILogger InitLogger(IContext context) {
            var uiApplication = context.Kernel.Get<UIApplication>();
            var localFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "pyRevit", uiApplication.Application.VersionNumber, "platform_.log");

            var platformFileName =
                Path.Combine(
                    @"T:\Проектный институт\Отдел стандартизации BIM и RD\BIM-Ресурсы\4-Dynamo\Архив\BIM-отдел\LOG",
                    "Bim4Everyone", uiApplication.Application.VersionNumber, "platform_.log");

            RollingInterval rollingInterval = RollingInterval.Day;
            int fileSizeLimitBytes = 50000000;
            bool rollOnFileSizeLimit = true;
            int retainedFileCountLimit = 10;
            string outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {PluginName} "
                                    //+ "{{\"MachineName\": \"{MachineName}\", \"UserName\": \"{EnvironmentUserName}\", \"$type\": \"Windows\"}} "
                                    + "{{\"RevitVersion\": \"{RevitVersion}\", \"UserName\": \"{AutodeskUsername}\", \"LoginUserId\": \"{AutodeskLoginUserId}\", \"$type\": \"Autodesk\"}} "
                                    + "{Message}{NewLine}{Exception}";

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("PluginName", "Bim4Everyone")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("EnvironmentUserName", Environment.UserName)
                .Enrich.WithProperty("RevitVersion", uiApplication.Application.VersionBuild)
                .Enrich.WithProperty("AutodeskUsername", uiApplication.Application.Username)
                .Enrich.WithProperty("AutodeskLoginUserId", uiApplication.Application.LoginUserId)
                .WriteTo.File(localFileName, rollingInterval: rollingInterval,
                    fileSizeLimitBytes: fileSizeLimitBytes, rollOnFileSizeLimit: rollOnFileSizeLimit,
                    retainedFileCountLimit: retainedFileCountLimit, outputTemplate: outputTemplate)
                .WriteTo.File(platformFileName, shared: true, rollingInterval: rollingInterval,
                    fileSizeLimitBytes: fileSizeLimitBytes, rollOnFileSizeLimit: rollOnFileSizeLimit,
                    retainedFileCountLimit: retainedFileCountLimit, outputTemplate: outputTemplate)
                .MinimumLevel.Verbose();

            return loggerConfiguration.CreateLogger();
        }
    }
}