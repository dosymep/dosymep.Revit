using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SharedParams {
    public class SharedParam {
        internal SharedParam() { }

        public string Name { get; set; }
        public StorageType SharedParamType { get; set; }
    }
}
