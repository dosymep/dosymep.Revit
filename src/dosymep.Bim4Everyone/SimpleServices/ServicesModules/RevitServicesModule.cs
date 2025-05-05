using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SimpleServices.InvokeButtons;
using dosymep.Bim4Everyone.SystemParams;
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
                .ToConstant(_uiApplication)
                .InTransientScope();

            Bind<Application>()
                .ToConstant(_uiApplication.Application)
                .InTransientScope();

            Bind<ILanguageService>()
                .To<RevitLanguageService>()
                .InSingletonScope();

            Bind<IPlatformCommandsService>()
                .To<PlatformCommandsService>();

            Bind<IInvokeButtonFactory>()
                .To<InvokeButtonFactory>();

            Bind<InvokeButton>().ToSelf();

            Bind<IBimModelPartsService>()
                .To<BimModelPartsService>()
                .InSingletonScope();

            Bind<IRevitParamFactory>()
                .To<RevitParamFactory>()
                .InSingletonScope();

            Bind<ISystemParamsService>()
                .ToConstant(SystemParamsConfig.Instance)
                .InSingletonScope();

            Bind<ISharedParamsService>()
                .ToConstant(SharedParamsConfig.Instance)
                .InSingletonScope();

            Bind<IProjectParamsService>()
                .ToConstant(ProjectParamsConfig.Instance)
                .InSingletonScope();
        }
    }
}