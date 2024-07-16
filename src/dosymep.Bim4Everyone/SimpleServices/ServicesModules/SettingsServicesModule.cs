using dosymep.Bim4Everyone.SimpleServices.Configuration;

using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class SettingsServicesModule : NinjectModule {
        public override void Load() {
            Bind<IPlatformSettingsService>()
                .To<PlatformSettingsService>();

            Bind<IniConfigurationService>().ToSelf()
                .WithConstructorArgument("iniPath", ModuleEnvironment.CurrentConfigPath);
        }
    }
}