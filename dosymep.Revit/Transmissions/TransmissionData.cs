using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using OpenMcdf;

namespace dosymep.Revit.Transmissions {
    [Serializable]
    public class TransmissionData {
        private const string TransmissionDataFileName = "TransmissionData";

        [XmlAttribute("isTransmitted")]
        public bool IsTransmitted { get; set; }

        [XmlAttribute("userData")]
        public string UserData { get; set; }

        [XmlAttribute("version")]
        public int Version { get; set; }

        [XmlElement("ExternalFileReference")]
        public List<ExternalFileReference> ExternalFileReferences { get; set; }

        public static TransmissionData ReadTransmissionData(string revitFileName) {
            using(CompoundFile cf = new CompoundFile(revitFileName)) {
                if(cf.RootStorage.TryGetStream(TransmissionDataFileName, out CFStream rawBasicInfoData)) {
                    byte[] bytes = rawBasicInfoData.GetData();
                    return GetXmlTransmissionData(bytes);
                }
            }

            return null;
        }

        public static void WriteTransmissionData(string revitFileName, TransmissionData transmissionData) {
            using(CompoundFile cf = new CompoundFile(revitFileName, CFSUpdateMode.Update, CFSConfiguration.Default)) {
                if(cf.RootStorage.TryGetStream(TransmissionDataFileName, out CFStream rawBasicInfoData)) {
                    string xmlData = Serialize(transmissionData);

                    var bytes = GetByteArray(xmlData);
                    rawBasicInfoData.SetData(bytes);
                }

                cf.Commit();
            }
        }

        public static bool DocumentIsNotTransmitted(string revitFileName) {
            return !IsDocumentTransmitted(revitFileName);
        }

        public static bool IsDocumentTransmitted(string revitFileName) {
            using(CompoundFile cf = new CompoundFile(revitFileName)) {
                return cf.RootStorage.TryGetStream(TransmissionDataFileName, out CFStream rawBasicInfoData);
            }
        }

        private static TransmissionData GetXmlTransmissionData(byte[] bytes) {
            using(var reader = new BinaryReader(new MemoryStream(bytes), Encoding.GetEncoding("UTF-16"))) {
                int length = reader.ReadInt32();
                string xmlData = new string(reader.ReadChars(length));

                using(var textReader = new StringReader(xmlData)) {
                    return Deserialize<TransmissionData>(textReader);
                }
            }
        }

        private static byte[] GetByteArray(string textTransmissionData) {
            using(var stream = new MemoryStream()) {
                using(var writer = new BinaryWriter(stream, Encoding.GetEncoding("UTF-16"))) {
                    writer.Write(textTransmissionData.Length);
                    writer.Write(textTransmissionData.ToArray());

                    return stream.ToArray();
                }
            }
        }

        private static string Serialize<T>(T @object) {
            var builder = new StringBuilder();

            using(var xmlWriter = XmlWriter.Create(builder, new XmlWriterSettings() { Indent = false })) {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(xmlWriter, @object, ns);
            }

            return builder.ToString();
        }

        private static T Deserialize<T>(TextReader textReader) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T) xmlSerializer.Deserialize(textReader);
        }
    }
}
