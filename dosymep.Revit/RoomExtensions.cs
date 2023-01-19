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
        /// Опции получения границ помещений по умолчанию.
        /// </summary>
        public static readonly SpatialElementBoundaryOptions DefaultBoundaryOptions
            = new SpatialElementBoundaryOptions();

        /// <summary>
        /// Проверяет является элемент избыточным.
        /// </summary>
        /// <param name="room">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является избыточным, иначе false.</returns>
        public static bool IsRedundant(this Room room,
            SpatialElementBoundaryOptions options = default) {
            double roomArea = room.GetParamValueOrDefault<double>(BuiltInParameter.ROOM_AREA);
            return roomArea == 0 && room.GetBoundarySegments(options ?? DefaultBoundaryOptions).Count > 0;
        }

        /// <summary>
        /// Проверяет является элемент не избыточным.
        /// </summary>
        /// <param name="room">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является не избыточным, иначе false.</returns>
        public static bool IsNotRedundant(this Room room,
            SpatialElementBoundaryOptions options = default) {
            return !room.IsRedundant(options);
        }

        /// <summary>
        /// Проверяет является элемент замкнутым.
        /// </summary>
        /// <param name="room">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является замкнутым, иначе false.</returns>
        public static bool IsEnclosed(this Room room,
            SpatialElementBoundaryOptions options = default) {
            double roomArea = room.GetParamValueOrDefault<double>(BuiltInParameter.ROOM_AREA);
            return roomArea > 0 && room.GetBoundarySegments(options ?? DefaultBoundaryOptions).Count > 0;
        }

        /// <summary>
        /// Проверяет является элемент не замкнутым.
        /// </summary>
        /// <param name="room">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является не замкнутым, иначе false.</returns>
        public static bool IsNotEnclosed(this Room room,
            SpatialElementBoundaryOptions options = default) {
            return !room.IsEnclosed(options);
        }
    }
}
