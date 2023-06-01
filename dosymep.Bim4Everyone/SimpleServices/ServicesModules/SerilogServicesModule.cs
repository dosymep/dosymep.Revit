using System;
using System.IO;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

using dosymep.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

using Serilog;
using Serilog.Configuration;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class SerilogServicesModule : NinjectModule {
        public override void Load() {
            Bind<ILogger>().ToMethod(InitLogger).InSingletonScope();
            Bind<ILoggerService>().To<SerilogService>().InSingletonScope();
        }

        private static ILogger InitLogger(IContext context) {
            var uiApplication = context.Kernel.Get<UIApplication>();
            var platformFileName =
                Path.Combine(
                    @"T:\Проектный институт\Отдел стандартизации BIM и RD\BIM-Ресурсы\4-Dynamo\Архив\BIM-отдел\LOG",
                    "Bim4Everyone", uiApplication.Application.VersionNumber, "Bim4Everyone_.log");

            RollingInterval rollingInterval = RollingInterval.Day;
            int fileSizeLimitBytes = 50000000;
            bool rollOnFileSizeLimit = true;
            int retainedFileCountLimit = 100;
            string outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {PluginName} "
                                    + "{{\"UserName\": \"{EnvironmentUserName}\", \"MachineName\": \"{EnvironmentMachineName}\", \"$type\": \"Windows\"}} "
                                    + "{{\"RevitVersion\": \"{RevitVersion}\", \"UserName\": \"{RevitUserName}\", \"$type\": \"Autodesk\"}} "
                                    + "{Message}{NewLine}{Exception}";

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("SessionId", Guid.NewGuid())
                .Enrich.WithProperty("PluginName", "Bim4Everyone")
                .Enrich.WithProperty("PluginSessionId", Guid.NewGuid())
                .Enrich.WithProperty("EnvironmentUserName", Environment.UserName)
                .Enrich.WithProperty("EnvironmentMachineName", Environment.MachineName)
                .Enrich.WithRevitBuild(uiApplication)
                .Enrich.WithRevitVersion(uiApplication)
                .Enrich.WithRevitLanguage(uiApplication)
                .Enrich.WithRevitUserName(uiApplication)
                .Enrich.WithRevitDocumentTitle(uiApplication)
                .Enrich.WithRevitDocumentPathName(uiApplication)
                .Enrich.WithRevitDocumentModelPath(uiApplication)
                .WriteTo.RevitJournal(uiApplication)
                .WriteTo.File(platformFileName, shared: true, rollingInterval: rollingInterval,
                    fileSizeLimitBytes: fileSizeLimitBytes, rollOnFileSizeLimit: rollOnFileSizeLimit,
                    retainedFileCountLimit: retainedFileCountLimit, outputTemplate: outputTemplate)
                .MinimumLevel.Verbose();
            
            return loggerConfiguration.CreateLogger();
        }
    }
}