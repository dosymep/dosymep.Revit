using System.Reflection;

using dosymep.Bim4Everyone.ProjectConfigs;
using dosymep.Revit.ServerClient;
using dosymep.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Serialization;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class JsonSerializationServicesModule : NinjectModule {
        public override void Load() {
            Bind<ISerializer>().To<JsonSerializationService>();
            Bind<IConfigSerializer>().To<JsonSerializationService>();
            Bind<ISerializationService>().To<JsonSerializationService>();
            
            Bind<JsonSerializerSettings>().ToSelf()
                .WithPropertyValue(nameof(JsonSerializerSettings.Formatting), Formatting.Indented)
                .WithPropertyValue(nameof(JsonSerializerSettings.TypeNameHandling), TypeNameHandling.None);
        }
    }
}