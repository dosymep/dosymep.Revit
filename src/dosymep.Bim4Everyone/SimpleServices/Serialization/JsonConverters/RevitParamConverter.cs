using System;

using dosymep.Bim4Everyone.CustomParams;
using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SystemParams;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization.JsonConverters {
    internal class RevitParamConverter : JsonConverter<RevitParam> {
        public override void WriteJson(JsonWriter writer, RevitParam value, JsonSerializer serializer) {
            value.SaveToJson(writer, serializer);
        }

        public override RevitParam ReadJson(
            JsonReader reader, Type objectType,
            RevitParam existingValue, bool hasExistingValue, JsonSerializer serializer) {
            
            JToken token = JToken.ReadFrom(reader);

            if(CustomParam.CheckType(token)) {
                return CustomParam.ReadFromJson(token);
            }

            if(SystemParam.CheckType(token)) {
                return SystemParam.ReadFromJson(token);
            }

            if(ProjectParam.CheckType(token)) {
                return ProjectParam.ReadFromJson(token);
            }

            if(SharedParam.CheckType(token)) {
                return SharedParam.ReadFromJson(token);
            }

            throw new InvalidOperationException("Revit param type is unknown.");
        }
    }
}