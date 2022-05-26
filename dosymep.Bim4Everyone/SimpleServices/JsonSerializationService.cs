using dosymep.SimpleServices;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class JsonSerializationService : ISerializationService {
        public string FileExtension => ".json";

        public string Serialize<T>(T @object) {
            return JsonConvert.SerializeObject(@object);
        }

        public T Deserialize<T>(string text) {
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}