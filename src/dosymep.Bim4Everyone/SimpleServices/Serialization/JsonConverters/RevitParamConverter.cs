using System;
using System.IO;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.CustomParams;
using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SystemParams;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization.JsonConverters {
    internal class RevitParamConverter : JsonConverter<RevitParam> {
        public override void WriteJson(JsonWriter writer, RevitParam value, JsonSerializer serializer) {
            value?.SaveToJson(writer, serializer);
        }

        public override RevitParam ReadJson(
            JsonReader reader, Type objectType,
            RevitParam existingValue, bool hasExistingValue, JsonSerializer serializer) {
            
            if(reader.TokenType != JsonToken.StartObject) {
                return default;
            }
           
            JObject jObject = JObject.Load(reader);
            string paramType = jObject.Value<string>("$type");

            if(CheckType<SharedParam>(paramType)) {
                return SharedParam.ReadFromJson(jObject, serializer);
            }

            if(CheckType<ProjectParam>(paramType)) {
                return ProjectParam.ReadFromJson(jObject, serializer);
            }

            if(CheckType<SystemParam>(paramType)) {
                return SystemParam.ReadFromJson(jObject, serializer);
            }

            if(CheckType<CustomParam>(paramType)) {
                return CustomParam.ReadFromJson(jObject, serializer);
            }

            throw new InvalidOperationException("Revit param type is unknown.");
        }

        private bool CheckType<T>(string paramType) {
            string fullName = typeof(T).FullName;
            return fullName != null && paramType?.StartsWith(fullName) == true;
        }
    }
}