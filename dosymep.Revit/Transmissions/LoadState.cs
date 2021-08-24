using System.Xml.Serialization;

namespace dosymep.Revit.Transmissions {
    /// <summary>
    /// Типы загрузок связанных файлов.
    /// </summary>
    public enum LoadState {
        /// <summary>
        /// Загружено.
        /// </summary>
        Loaded,

        /// <summary>
        /// Выгружено.
        /// </summary>
        Unloaded,

        /// <summary>
        /// Не найдено.
        /// </summary>
        [XmlEnum(Name = "Not Found")]
        NotFound
    }
}
