#if REVIT2021_OR_GREATER

using System;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization.JsonConverters {
    internal class ForgeTypeIdConverter : JsonConverter<ForgeTypeId> {
        public override void WriteJson(JsonWriter writer, ForgeTypeId value, JsonSerializer serializer) {
            writer.WriteValue(value?.TypeId);
        }

        public override ForgeTypeId ReadJson(
            JsonReader reader, Type objectType,
            ForgeTypeId existingValue, bool hasExistingValue, JsonSerializer serializer) {
            
            return reader.Value is null
                ? ForgeTypeIdExtensions.EmptyForgeTypeId
                : new ForgeTypeId(reader.Value.ToString());
        }
    }
}

#endif