using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

using Autodesk.Revit.UI;

using dosymep.Bim4Everyone.SimpleServices.Configuration;
using dosymep.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Json;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class SerilogServicesModule : NinjectModule {
        public override void Load() {
            Bind<ILogger>().ToMethod(InitLogger).InSingletonScope();
            Bind<ILoggerService>().To<SerilogService>().InSingletonScope();
        }

        private static ILogger InitLogger(IContext context) {
            var uiApplication = context.Kernel.Get<UIApplication>();

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("SessionId", Guid.NewGuid())
                .Enrich.WithProperty("PluginName", "Bim4Everyone")
                .Enrich.WithProperty("PluginSessionId", Guid.NewGuid())
                .Enrich.WithProperty("EnvironmentUserName", GetUserName())
                .Enrich.WithProperty("EnvironmentMachineName", Environment.MachineName)
                .Enrich.WithRevitBuild(uiApplication)
                .Enrich.WithRevitVersion(uiApplication)
                .Enrich.WithRevitLanguage(uiApplication)
                .Enrich.WithRevitUserName(uiApplication)
                .Enrich.WithRevitDocumentTitle(uiApplication)
                .Enrich.WithRevitDocumentPathName(uiApplication)
                .Enrich.WithRevitDocumentModelPath(uiApplication)
                .WriteTo.RevitJournal(uiApplication, true)
                .MinimumLevel.Verbose();

            IPlatformSettingsService settingsService = 
                context.Kernel.Get<IPlatformSettingsService>();
            
            LogTrace logTrace = settingsService.LogTrace;
            if(logTrace.IsActive == true && !string.IsNullOrEmpty(logTrace.ServerName)) {
                loggerConfiguration.WriteTo.Bim4Everyone(logTrace.ServerName, logTrace.LogLevel ?? LogEventLevel.Debug);
            }

            return loggerConfiguration.CreateLogger();
        }

        private static string GetUserName() {
            if(string.IsNullOrEmpty(Environment.UserDomainName)) {
                return Environment.UserName;
            }

            return $"{Environment.UserDomainName}\\{Environment.UserName}";
        }
    }
}