using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    public enum ExternalFileReferenceType {
        Decal,

        [XmlEnum(Name = "CAD Link")]
        CADLink,

        [XmlEnum(Name = "Revit Link")]
        RevitLink,

        [XmlEnum(Name = "Keynote Table")]
        KeynoteTable,

        [XmlEnum(Name = "Assembly Code Table")]
        AssemblyCodeTable,

        [XmlEnum(Name = "DWF Markup")]
        DWFMarkup
    }
}
