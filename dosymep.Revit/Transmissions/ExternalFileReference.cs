using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    public enum LoadState {
        Loaded,
        Unloaded,

        [XmlEnum(Name = "Not Found")]
        NotFound
    }

    public enum PathType {
        Absolute,
        Relative,

        [XmlEnum(Name = "Server Location")]
        ServerLocation,

        [XmlEnum(Name = "Relative to Central Model")]
        RelativeCentralModel,

        [XmlEnum(Name = "Relative to Library Locations")]
        RelativeLibraryLocations
    }

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

    [Serializable]
    public class ExternalFileReference {
        public int ElementId { get; set; }
        public ExternalFileReferenceType ExternalFileReferenceType { get; set; }

        public string LastSavedPath { get; set; }
        public string LastSavedAbsolutePath { get; set; }
        public string LastSavedCentralServerLocation { get; set; }
        public PathType LastSavedPathType { get; set; }
        public LoadState LastSavedLoadState { get; set; }

        public string DesiredPath { get; set; }
        public string DesiredCentralServerLocation { get; set; }
        public PathType DesiredPathType { get; set; }
        public LoadState DesiredLoadState { get; set; }
    }
}
