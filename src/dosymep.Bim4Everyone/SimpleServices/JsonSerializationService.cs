using System;
using System.Collections.Generic;
using System.Reflection;

using Autodesk.Revit.DB;

using dosymep.SimpleServices;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Serialization;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class JsonSerializationService : ISerializationService {
        private readonly JsonSerializerSettings _settings;

        public JsonSerializationService(JsonSerializerSettings settings) {
            _settings = settings ?? new JsonSerializerSettings();
            _settings.Converters = new List<JsonConverter>() {new ElementIdConverter()};
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

    internal class ElementIdConverter : JsonConverter<ElementId> {
        public override void WriteJson(JsonWriter writer, ElementId value, JsonSerializer serializer) {
#if REVIT_2023_OR_LESS
            writer.WriteValue(value.IntegerValue);
#else
            writer.WriteValue(value.Value);
#endif
        }

        public override ElementId ReadJson(
            JsonReader reader,
            Type objectType,
            ElementId existingValue,
            bool hasExistingValue,
            JsonSerializer serializer) {
            
            if(reader.Value is null) {
                return ElementId.InvalidElementId;
            }
            
#if REVIT_2023_OR_LESS
            return new ElementId(Convert.ToInt32(reader.Value));
#else
            return new ElementId(Convert.ToInt64(reader.Value));
#endif
        }
    }
}