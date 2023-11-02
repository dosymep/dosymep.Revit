using Autodesk.Revit.UI;

using dosymep.SimpleServices;
using dosymep.SimpleServices.PlatformProfiles;
using dosymep.SimpleServices.PlatformProfiles.ProfileStorages;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class ProfileServicesModule : NinjectModule {
        public override void Load() {
            Bind<IProfileStorage>()
                .To<RegStorage>()
                .WithConstructorArgument("regPath", @"Software\Bim4Everyone\Profiles")
                .WithConstructorArgument("applicationVersion", c => c.Kernel.Get<UIApplication>().Application.VersionNumber);

            Bind<IPlatformProfileService,
                    IPlatformProfileService<UserSpace>,
                    IPlatformProfileService<SystemSpace>,
                    IPlatformProfileService<OrganizationSpace>>()
                .ToMethod(InitPlatformProfileService).InSingletonScope();
        }
        
        private static PlatformProfileService InitPlatformProfileService(IContext context) {
            IProfileStorage profileStorage = context.Kernel.Get<IProfileStorage>();
            ProfileInfo currentProfileInfos = profileStorage.GetCurrentProfileInfo();

            return new PlatformProfileService(profileStorage, currentProfileInfos);
        }
    }
}