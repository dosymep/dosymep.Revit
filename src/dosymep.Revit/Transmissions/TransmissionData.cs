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
    /// <summary>
    /// Данные передачи Revit модели.
    /// </summary>
    public class TransmissionData {
        /// <summary>
        /// Наименование файла содержащего данные передачи.
        /// </summary>
        private const string TransmissionDataFileName = "TransmissionData";

        /// <summary>
        /// Признак передачи модели (true - если модель была передана).
        /// </summary>
        [XmlAttribute("isTransmitted")]
        public bool IsTransmitted { get; set; }

        /// <summary>
        /// Пользовательские данные.
        /// </summary>
        [XmlAttribute("userData")]
        public string UserData { get; set; }

        /// <summary>
        /// Версия.
        /// </summary>
        [XmlAttribute("version")]
        public int Version { get; set; }

        /// <summary>
        /// Связанные файлы Revit.
        /// </summary>
        [XmlElement("ExternalFileReference")]
        public List<ExternalFileReference> ExternalFileReferences { get; set; }

        /// <summary>
        /// Чтение данных передачи.
        /// </summary>
        /// <param name="revitFileName">Путь до файла Revit.</param>
        /// <returns>Возвращает данные передачи.</returns>
        public static TransmissionData ReadTransmissionData(string revitFileName) {
            using(var rootStorage = RootStorage.OpenRead(revitFileName)) {
                if(rootStorage.TryOpenStream(TransmissionDataFileName, out CfbStream rawBasicInfoData)) {
                    try {
                        byte[] bytes = new byte[rawBasicInfoData.Length];
                        int result = rawBasicInfoData.Read(bytes, 0, bytes.Length);
                        if(result == 0) {
                            throw new InvalidDataException("Transmission data is empty.");
                        }

                        return GetXmlTransmissionData(bytes);
                    } finally {
                        rawBasicInfoData.Close();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Записывает данные передачи Revit.
        /// </summary>
        /// <param name="revitFileName">Путь до файла Revit.</param>
        /// <param name="transmissionData">Данные передачи Revit модели.</param>
        public static void WriteTransmissionData(string revitFileName, TransmissionData transmissionData) {
            using(var rootStorage = RootStorage.Open(revitFileName, FileMode.Open, StorageModeFlags.Transacted)) {
                if(rootStorage.TryOpenStream(TransmissionDataFileName, out CfbStream rawBasicInfoData)) {
                    try {
                        string xmlData = Serialize(transmissionData);

                        byte[] bytes = GetByteArray(xmlData);
                        rawBasicInfoData.Write(bytes, 0, bytes.Length);
                        rawBasicInfoData.Flush();
                    } finally {
                        rawBasicInfoData.Close();
                    }
                    
                    rootStorage.Commit();
                }
            }
        }

        /// <summary>
        /// Документ модели не является переданным.
        /// </summary>
        /// <param name="revitFileName">Путь до файла Revit.</param>
        /// <returns>Возвращает true - если документ модели не был передан.</returns>
        public static bool IsNotTransmittedDocument(string revitFileName) {
            return !IsTransmittedDocument(revitFileName);
        }

        /// <summary>
        /// Документ модели является переданным.
        /// </summary>
        /// <param name="revitFileName">Путь до файла Revit.</param>
        /// <returns>Возвращает true - если документ модели был передан.</returns>
        public static bool IsTransmittedDocument(string revitFileName) {
            using(var rootStorage = RootStorage.OpenRead(revitFileName)) {
                return rootStorage.ContainsEntry(TransmissionDataFileName);
            }
        }

        /// <summary>
        /// Десериализация байтов в данные передачи модели.
        /// </summary>
        /// <param name="bytes">Байтовый массив файла передачи модели.</param>
        /// <returns>Возвращает данные передачи модели.</returns>
        private static TransmissionData GetXmlTransmissionData(byte[] bytes) {
            using(var stream = new MemoryStream(bytes)) {
                using(var reader = new BinaryReader(stream, Encoding.GetEncoding("UTF-16"))) {
                    int length = reader.ReadInt32();
                    string xmlData = new string(reader.ReadChars(length));

                    using(var textReader = new StringReader(xmlData)) {
                        return Deserialize<TransmissionData>(textReader);
                    }
                }
            }
        }

        /// <summary>
        /// Конвертирует строку в байтовый массив данных передачи модели.
        /// </summary>
        /// <param name="textTransmissionData">XML данные передачи модели.</param>
        /// <returns>Возвращает сконвертированную строку в байтовый массив данных передачи модели.</returns>
        private static byte[] GetByteArray(string textTransmissionData) {
            using(var stream = new MemoryStream()) {
                using(var writer = new BinaryWriter(stream, Encoding.GetEncoding("UTF-16"))) {
                    writer.Write(textTransmissionData.Length);
                    writer.Write(textTransmissionData.ToArray());
                }

                return stream.ToArray();
            }
        }

        /// <summary>
        /// Сериализует объект в XML строку без отступов и пространств имен.
        /// </summary>
        /// <typeparam name="T">Тип сериализуемого объект.</typeparam>
        /// <param name="object">Сериализуемый объект.</param>
        /// <returns>Возвращает XML строку переданного объекта.</returns>
        private static string Serialize<T>(T @object) {
            var builder = new StringBuilder();

            using(var xmlWriter = XmlWriter.Create(builder, new XmlWriterSettings() {Indent = false})) {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(xmlWriter, @object, ns);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Десериализует переданный текст в объект.
        /// </summary>
        /// <typeparam name="T">Тип десериализуемого объекта.</typeparam>
        /// <param name="textReader">Текст десериализуемого объекта.</param>
        /// <returns>Возвращает десериализованный объект.</returns>
        private static T Deserialize<T>(TextReader textReader) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T) xmlSerializer.Deserialize(textReader);
        }
    }
}