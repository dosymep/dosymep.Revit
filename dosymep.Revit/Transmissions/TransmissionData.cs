using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    [Serializable]
    public class TransmissionData {

        [XmlAttribute("isTransmitted")]
        public bool IsTransmitted { get; set; }

        [XmlAttribute("userData")]
        public string UserData { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("ExternalFileReference")]
        public List<ExternalFileReference> ExternalFileReferences { get; set; }
    }
}
