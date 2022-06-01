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
            if(@object == null) {
                throw new ArgumentNullException(nameof(@object));
            }

            return JsonConvert.SerializeObject(@object, _settings);
        }

        public T Deserialize<T>(string text) {
            if(string.IsNullOrEmpty(text)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(text));
            }

            return JsonConvert.DeserializeObject<T>(text, _settings);
        }
    }

    internal class PluginSerializationBinder : ISerializationBinder {
        private readonly IPluginInfoService _pluginInfoService;
        private readonly DefaultSerializationBinder _defaultBinder = new DefaultSerializationBinder();

        public PluginSerializationBinder(IPluginInfoService pluginInfoService) {
            _pluginInfoService = pluginInfoService;
        }

        public Type BindToType(string assemblyName, string typeName) {
            if(_pluginInfoService.PluginAssembly != null
               && assemblyName.Equals(_pluginInfoService.PluginAssembly.GetName().Name)) {
                return _pluginInfoService.PluginAssembly.GetType(typeName);
            } else {
                return _defaultBinder.BindToType(assemblyName, typeName);
            }
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName) {
            if(_pluginInfoService.PluginAssembly != null
               && serializedType.Assembly.GetName().Name.Equals(_pluginInfoService.PluginAssembly.GetName().Name)) {
                typeName = serializedType.FullName;
                assemblyName = _pluginInfoService.PluginAssembly.GetName().Name;
            } else {
                _defaultBinder.BindToName(serializedType, out assemblyName, out typeName);
            }
        }
    }
}