using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dosymep.Revit.Transmissions {
    /// <summary>
    /// Класс содержащий информацию о связанном файле.
    /// </summary>
    public class ExternalFileReference {
        /// <summary>
        /// Идентификатор связанного файла.
        /// </summary>
        public int ElementId { get; set; }

        /// <summary>
        /// Тип связанного файла.
        /// </summary>
        public ExternalFileReferenceType ExternalFileReferenceType { get; set; }

        /// <summary>
        /// Путь последнего сохранения связанного файла.
        /// </summary>
        public string LastSavedPath { get; set; }

        /// <summary>
        /// Абсолютный путь последнего сохранения связанного файла.
        /// </summary>
        public string LastSavedAbsolutePath { get; set; }

        /// <summary>
        /// Путь последнего сохранения связанного файла на сервере. 
        /// </summary>
        public string LastSavedCentralServerLocation { get; set; }

        /// <summary>
        /// Тип пути последнего сохранения связанного файла.
        /// </summary>
        public PathType LastSavedPathType { get; set; }

        /// <summary>
        /// Состояние загрузки последнего сохранения связанного файла.
        /// </summary>
        public LoadState LastSavedLoadState { get; set; }

        /// <summary>
        /// Предпочтительный путь до связанного файла.
        /// </summary>
        public string DesiredPath { get; set; }

        /// <summary>
        /// Предпочтительный путь до связанного файла.
        /// </summary>
        public string DesiredCentralServerLocation { get; set; }

        /// <summary>
        /// Предпочтительный тип пути до связанного файла.
        /// </summary>
        public PathType DesiredPathType { get; set; }

        /// <summary>
        /// Предпочтительное состояние загрузки связанного файла.
        /// </summary>
        public LoadState DesiredLoadState { get; set; }
    }
}
