using dosymep.Bim4Everyone.SimpleServices.Configuration;

using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class ConfigurationServicesModule : NinjectModule {
        public override void Load() {
            Bind<LogTrace>().ToSelf();
            Bind<LogTraceJournal>().ToSelf();
            
            Bind<IniConfigurationService>().ToSelf()
                .WithConstructorArgument("iniPath", ModuleEnvironment.CurrentConfigPath);
        }
    }
}