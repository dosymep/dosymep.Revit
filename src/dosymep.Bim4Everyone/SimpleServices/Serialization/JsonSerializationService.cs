using System;
using System.Collections.Generic;

using dosymep.Bim4Everyone.ProjectConfigs;
using dosymep.Revit.ServerClient;
using dosymep.SimpleServices;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization {
    internal class JsonSerializationService : ISerializationService, ISerializer, IConfigSerializer {
        private readonly JsonSerializerSettings _settings;

        public JsonSerializationService(JsonSerializerSettings settings) {
            _settings = settings;
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
}