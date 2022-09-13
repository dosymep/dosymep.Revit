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
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class SerilogServicesModule : NinjectModule {
        private readonly bool _isRevitCoreConsole;

        public SerilogServicesModule(bool isRevitCoreConsole) {
            _isRevitCoreConsole = isRevitCoreConsole;
        }

        public override void Load() {
            if(_isRevitCoreConsole) {
                Bind<ILogger>().ToMethod(InitRevitCoreConsoleLogger).InSingletonScope();
            } else {
                Bind<ILogger>().ToMethod(InitLogger).InSingletonScope();
            }

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
            int retainedFileCountLimit = 10;
            string outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {PluginName} "
                                    + "{{\"MachineName\": \"{MachineName}\", \"UserName\": \"{EnvironmentUserName}\", \"$type\": \"Windows\"}} "
                                    + "{{\"RevitVersion\": \"{RevitVersion}\", \"UserName\": \"{AutodeskUsername}\", \"LoginUserId\": \"{AutodeskLoginUserId}\", \"$type\": \"Autodesk\"}} "
                                    + "{Message}{NewLine}{Exception}";

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("PluginName", "Bim4Everyone")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("EnvironmentUserName", Environment.UserName)
                .Enrich.WithProperty("RevitVersion", uiApplication.Application.VersionBuild)
                .Enrich.WithProperty("AutodeskUsername", uiApplication.Application.Username)
                .Enrich.WithProperty("AutodeskLoginUserId", uiApplication.Application.LoginUserId)
                .WriteTo.File(platformFileName, shared: true, rollingInterval: rollingInterval,
                    fileSizeLimitBytes: fileSizeLimitBytes, rollOnFileSizeLimit: rollOnFileSizeLimit,
                    retainedFileCountLimit: retainedFileCountLimit, outputTemplate: outputTemplate)
                .WriteTo.RevitJournalSink(uiApplication.Application)
                .MinimumLevel.Verbose();

            return loggerConfiguration.CreateLogger();
        }

        private static ILogger InitRevitCoreConsoleLogger(IContext context) {
            var application = context.Kernel.Get<Application>();
            var localFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "RevitCoreConsole", application.VersionNumber, "RevitCoreConsole_.log");

            RollingInterval rollingInterval = RollingInterval.Day;
            int fileSizeLimitBytes = 500000000;
            bool rollOnFileSizeLimit = true;
            int retainedFileCountLimit = 99;
            string outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {PluginName} "
                                    + "{{\"RevitVersion\": \"{RevitVersion}\", \"UserName\": \"{AutodeskUsername}\", \"$type\": \"Autodesk\"}} "
                                    + "{Message}{NewLine}{Exception}";

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("PluginName", "RevitCoreConsole")
                .Enrich.WithProperty("RevitVersion", application.VersionBuild)
                .Enrich.WithProperty("AutodeskUsername", application.Username)
                .WriteTo.File(localFileName, rollingInterval: rollingInterval,
                    fileSizeLimitBytes: fileSizeLimitBytes, rollOnFileSizeLimit: rollOnFileSizeLimit,
                    retainedFileCountLimit: retainedFileCountLimit, outputTemplate: outputTemplate)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.RevitJournalSink(application)
                .MinimumLevel.Verbose();

            return loggerConfiguration.CreateLogger();
        }
    }

    internal class RevitJournalSink : ILogEventSink {
        private readonly Application _application;
        private readonly IFormatProvider _formatProvider;

        public RevitJournalSink(Application application, IFormatProvider formatProvider) {
            _application = application;
            _formatProvider = formatProvider;
        }

        public void Emit(LogEvent logEvent) {
            _application.WriteJournalComment(logEvent.RenderMessage(_formatProvider), true);
        }
    }

    internal static class RevitJournalSinkExtensions {
        public static LoggerConfiguration RevitJournalSink(
            this LoggerSinkConfiguration loggerConfiguration,
            Application application,
            IFormatProvider formatProvider = null) {
            return loggerConfiguration.Sink(new RevitJournalSink(application, formatProvider));
        }
    }
}