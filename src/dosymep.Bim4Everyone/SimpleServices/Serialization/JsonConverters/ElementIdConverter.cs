using System;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization.JsonConverters {
    internal class ElementIdConverter : JsonConverter<ElementId> {
        public override void WriteJson(JsonWriter writer, ElementId value, JsonSerializer serializer) {
            writer.WriteValue(value?.GetIdValue());
        }

        public override ElementId ReadJson(
            JsonReader reader, Type objectType,
            ElementId existingValue, bool hasExistingValue, JsonSerializer serializer) {

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
}