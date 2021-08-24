using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    /// <summary>
    /// Типы путей.
    /// </summary>
    public enum PathType {
        /// <summary>
        /// Абсолютный путь.
        /// </summary>
        Absolute,

        /// <summary>
        /// Относительный путь.
        /// </summary>
        Relative,

        /// <summary>
        /// Путь с Revit Server или BIM360.
        /// </summary>
        [XmlEnum(Name = "Server Location")]
        ServerLocation,

        /// <summary>
        /// Relative to Central Model.
        /// </summary>
        [XmlEnum(Name = "Relative to Central Model")]
        RelativeCentralModel,

        /// <summary>
        /// Relative to Library Locations.
        /// </summary>
        [XmlEnum(Name = "Relative to Library Locations")]
        RelativeLibraryLocations
    }
}
