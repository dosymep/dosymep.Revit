using System.Reflection;

using dosymep.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Serialization;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class JsonSerializationServicesModule : NinjectModule {
        public override void Load() {
            Bind<JsonSerializerSettings>().ToSelf()
                .WithPropertyValue(nameof(Formatting), Formatting.Indented)
                .WithPropertyValue(nameof(TypeNameHandling), TypeNameHandling.Objects);

            Bind<ISerializationService>()
                .To<JsonSerializationService>()
                .WithConstructorArgument(typeof(JsonSerializerSettings),
                    c => c.Kernel.TryGet<JsonSerializerSettings>())
                .WithConstructorArgument(typeof(ISerializationBinder),
                    c => c.Kernel.TryGet<ISerializationBinder>());
        }
    }
}