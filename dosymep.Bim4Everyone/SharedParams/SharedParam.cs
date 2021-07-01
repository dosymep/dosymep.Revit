using Autodesk.Revit.DB;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SharedParams {
    public class SharedParam {
        internal SharedParam() { }

        public string Name { get; set; }

        [JsonIgnore]
        public string Description { get; }

        [JsonIgnore]
        public string PropertyName { get; internal set; }

        [JsonIgnore]
        public StorageType SharedParamType { get; }
    }
}
