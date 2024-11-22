using System;
using System.Collections.Generic;
using System.Reflection;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.CustomParams;
using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SystemParams;
using dosymep.Revit;
using dosymep.SimpleServices;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;
using pyRevitLabs.Json.Serialization;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class JsonSerializationService : ISerializationService {
        private readonly JsonSerializerSettings _settings;

        public JsonSerializationService(JsonSerializerSettings settings) {
            _settings = settings ?? new JsonSerializerSettings();
            _settings.Converters = new List<JsonConverter>() {new ElementIdConverter(), new RevitParamConverter()};
            
#if REVIT2021_OR_GREATER
            _settings.Converters.Add(new ForgeTypeIdConverter());
#endif
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

#if REVIT2021_OR_GREATER

    internal class ForgeTypeIdConverter : JsonConverter<ForgeTypeId> {
        public override void WriteJson(JsonWriter writer, ForgeTypeId value, JsonSerializer serializer) {
            writer.WriteValue(value.TypeId);
        }

        public override ForgeTypeId ReadJson(
            JsonReader reader, Type objectType, ForgeTypeId existingValue, bool hasExistingValue, JsonSerializer serializer) {
            return reader.Value == null ? ForgeTypeIdExtensions.EmptyForgeTypeId : new ForgeTypeId(reader.Value.ToString());
        }
    }

#endif

    internal class ElementIdConverter : JsonConverter<ElementId> {
        public override void WriteJson(
            JsonWriter writer, ElementId value, JsonSerializer serializer) {
            writer.WriteValue(value.GetIdValue());
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

#if REVIT2024_OR_GREATER
            return new ElementId(Convert.ToInt64(reader.Value));
#else
            return new ElementId(Convert.ToInt32(reader.Value));
#endif
        }
    }

    internal class RevitParamConverter : JsonConverter<RevitParam> {
        public override void WriteJson(
            JsonWriter writer, RevitParam value, JsonSerializer serializer) {
            value.SaveToJson(writer, serializer);
        }

        public override RevitParam ReadJson(
            JsonReader reader, Type objectType, RevitParam existingValue, bool hasExistingValue,
            JsonSerializer serializer) {

            JToken token = JToken.ReadFrom(reader);

            if(CustomParam.CheckType(token)) {
                return CustomParam.ReadFromJson(token);
            } else if(SystemParam.CheckType(token)) {
                return SystemParam.ReadFromJson(token);
            } else if(ProjectParam.CheckType(token)) {
                return ProjectParam.ReadFromJson(token);
            } else if(SharedParam.CheckType(token)) {
                return SharedParam.ReadFromJson(token);
            }

            throw new InvalidOperationException("Revit param type is unknown.");
        }
    }
}