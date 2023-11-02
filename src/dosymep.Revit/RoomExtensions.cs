using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса <see cref="Room"/>.
    /// </summary>
    public static class RoomExtensions {
        /// <summary>
        /// Проверяет является помещение избыточным.
        /// </summary>
        /// <param name="room">Проверяемое помещение.</param>
        /// <param name="options">Опции получение границ помещения.</param>
        /// <returns>Возвращает true если помещение является избыточным, иначе false.</returns>
        public static bool IsRedundant(this Room room,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) room).IsRedundant(options);
        }

        /// <summary>
        /// Проверяет является помещение не избыточным.
        /// </summary>
        /// <param name="room">Проверяемое помещение.</param>
        /// <param name="options">Опции получение границ помещения.</param>
        /// <returns>Возвращает true если помещение является не избыточным, иначе false.</returns>
        public static bool IsNotRedundant(this Room room,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) room).IsNotRedundant(options);
        }

        /// <summary>
        /// Проверяет является помещение замкнутым.
        /// </summary>
        /// <param name="room">Проверяемое помещение.</param>
        /// <param name="options">Опции получение границ помещения.</param>
        /// <returns>Возвращает true если помещение является замкнутым, иначе false.</returns>
        public static bool IsEnclosed(this Room room,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) room).IsEnclosed(options);
        }

        /// <summary>
        /// Проверяет является помещение не замкнутым.
        /// </summary>
        /// <param name="room">Проверяемое помещение.</param>
        /// <param name="options">Опции получение границ помещения.</param>
        /// <returns>Возвращает true если помещение является не замкнутым, иначе false.</returns>
        public static bool IsNotEnclosed(this Room room,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) room).IsNotEnclosed(options);
        }
    }
}
