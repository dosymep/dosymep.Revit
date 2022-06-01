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
            Bind<UIApplication>().ToConstant(_uiApplication);

            Bind<IPluginInfoService>()
                .To<PluginInfoService>()
                .InSingletonScope();

            Bind<IRootWindowService>()
                .To<RootWindowService>()
                .InSingletonScope();
        }
    }
}