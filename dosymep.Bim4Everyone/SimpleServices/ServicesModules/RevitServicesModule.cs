using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

using dosymep.SimpleServices;

using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class RevitServicesModule : NinjectModule {
        private readonly UIApplication _uiApplication;

        public RevitServicesModule(UIApplication uiApplication) {
            _uiApplication = uiApplication;
        }

        public override void Load() {
            Bind<UIApplication>()
                .ToConstant(_uiApplication);
            
            Bind<Application>()
                .ToConstant(_uiApplication.Application);
            
            Bind<ILanguageService>()
                .To<RevitLanguageService>()
                .InSingletonScope();
            
            Bind<IPluginInfoService>()
                .To<PluginInfoService>()
                .InSingletonScope();

            Bind<IRootWindowService>()
                .To<RootWindowService>()
                .InSingletonScope();

            Bind<IBimModelPartsService>()
                .To<BimModelPartsService>()
                .InSingletonScope();
        }
    }
}