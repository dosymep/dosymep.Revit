using System;
using System.Reflection;

using dosymep.SimpleServices;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Serialization;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class JsonSerializationService : ISerializationService {
        private readonly JsonSerializerSettings _settings;

        public JsonSerializationService(JsonSerializerSettings settings, ISerializationBinder serializationBinder) {
            _settings = settings ?? new JsonSerializerSettings();
            _settings.SerializationBinder = serializationBinder;
        }

        public string FileExtension => ".json";

        public string Serialize<T>(T @object) {
            return JsonConvert.SerializeObject(@object, _settings);
        }

        public T Deserialize<T>(string text) {
            return JsonConvert.DeserializeObject<T>(text, _settings);
        }
    }

    internal class PluginSerializationBinder : ISerializationBinder {
        private readonly Assembly _pluginAssembly;
        private readonly DefaultSerializationBinder _defaultBinder = new DefaultSerializationBinder();

        public PluginSerializationBinder(Assembly pluginAssembly) {
            _pluginAssembly = pluginAssembly ?? throw new ArgumentNullException(nameof(pluginAssembly));
        }

        public Type BindToType(string assemblyName, string typeName) {
            if(assemblyName.Equals(_pluginAssembly.GetName().Name)) {
                return _pluginAssembly.GetType(typeName);
            } else {
                return _defaultBinder.BindToType(assemblyName, typeName);
            }
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName) {
            if(serializedType.Assembly.GetName().Name.Equals(_pluginAssembly.GetName().Name)) {
                typeName = serializedType.FullName;
                assemblyName = _pluginAssembly.GetName().Name;
            } else {
                _defaultBinder.BindToName(serializedType, out assemblyName, out typeName);
            }
        }
    }
}