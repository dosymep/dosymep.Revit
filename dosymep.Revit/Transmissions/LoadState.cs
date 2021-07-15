using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    public enum LoadState {
        Loaded,
        Unloaded,

        [XmlEnum(Name = "Not Found")]
        NotFound
    }
}
