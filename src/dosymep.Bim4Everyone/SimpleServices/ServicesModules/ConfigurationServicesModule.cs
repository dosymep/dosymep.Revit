using dosymep.Bim4Everyone.SimpleServices.Configuration;

using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class ConfigurationServicesModule : NinjectModule {
        public override void Load() {
            Bind<IPlatformConfigurationService>()
                .To<PlatformConfigurationService>();

            Bind<IniConfigurationService>().ToSelf()
                .WithConstructorArgument("iniPath", ModuleEnvironment.CurrentConfigPath);
        }
    }
}