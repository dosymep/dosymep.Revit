using dosymep.SimpleServices;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class JsonSerializationService : ISerializationService {
        private readonly JsonSerializerSettings _settings;

        public JsonSerializationService(JsonSerializerSettings settings) {
            _settings = settings;
        }
        
        public string FileExtension => ".json";

        public string Serialize<T>(T @object) {
            return JsonConvert.SerializeObject(@object, _settings);
        }

        public T Deserialize<T>(string text) {
            return JsonConvert.DeserializeObject<T>(text, _settings);
        }
    }
}