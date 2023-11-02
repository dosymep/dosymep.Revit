using System;
using System.Collections.Generic;

namespace dosymep.Revit.ServerClient {
    /// <summary>
    /// Папка с информацией о дочерних моделях и папках.
    /// </summary>
    public class RevitContents : RevitResponse, IEquatable<RevitContents>, IComparable<RevitContents> {
        /// <summary>
        /// Полный путь до папки.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Общий размер диска (измеряется в байтах).
        /// </summary>
        public long DriveSpace { get; set; }

        /// <summary>
        /// Не занятый объем диска (измеряется в байтах).
        /// </summary>
        public long DriveFreeSpace { get; set; }

        /// <summary>
        /// Список моделей находящихся в текущей папке.
        /// </summary>
        public List<RevitModel> Models { get; set; }

        /// <summary>
        /// Список папок находящихся в текущей папке.
        /// </summary>
        public List<RevitFolder> Folders { get; set; }

        /// <inheritdoc/>
        public override string ToString() {
            return Path;
        }

        /// <inheritdoc/>
        public override int GetHashCode() {
            return Path.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return Equals(obj as RevitContents);
        }

        /// <inheritdoc/>
        public bool Equals(RevitContents obj) {
            return obj != null && Path.Equals(obj.Path);
        }

        /// <inheritdoc/>
        public int CompareTo(RevitContents other) {
            return other == null ? -1 : (Path.CompareTo(other.Path));
        }
    }
}