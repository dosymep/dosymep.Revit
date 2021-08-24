using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    /// <summary>
    /// Типы связанных файлов.
    /// </summary>
    public enum ExternalFileReferenceType {
        /// <summary>
        /// Decal.
        /// </summary>
        Decal,

        /// <summary>
        /// CAD связь.
        /// </summary>
        [XmlEnum(Name = "CAD Link")]
        CADLink,

        /// <summary>
        /// Revit связь.
        /// </summary>
        [XmlEnum(Name = "Revit Link")]
        RevitLink,

        /// <summary>
        /// KeynoteTable.
        /// </summary>
        [XmlEnum(Name = "Keynote Table")]
        KeynoteTable,

        /// <summary>
        /// AssemblyCodeTable
        /// </summary>
        [XmlEnum(Name = "Assembly Code Table")]
        AssemblyCodeTable,

        /// <summary>
        /// DWFMarkup
        /// </summary>
        [XmlEnum(Name = "DWF Markup")]
        DWFMarkup
    }
}
