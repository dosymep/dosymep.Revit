using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса <see cref="Area"/>.
    /// </summary>
    public static class AreaExtensions {
        /// <summary>
        /// Проверяет является зона избыточной.
        /// </summary>
        /// <param name="area">Проверяемая зона.</param>
        /// <param name="options">Опции получение границ зоны.</param>
        /// <returns>Возвращает true если зона является избыточной, иначе false.</returns>
        public static bool IsRedundant(this Area area,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) area).IsRedundant(options);
        }

        /// <summary>
        /// Проверяет является зона не избыточной.
        /// </summary>
        /// <param name="area">Проверяемая зона.</param>
        /// <param name="options">Опции получение границ зоны.</param>
        /// <returns>Возвращает true если зона является не избыточной, иначе false.</returns>
        public static bool IsNotRedundant(this Area area,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) area).IsNotRedundant(options);
        }

        /// <summary>
        /// Проверяет является зона замкнутой.
        /// </summary>
        /// <param name="area">Проверяемая зона.</param>
        /// <param name="options">Опции получение границ зоны.</param>
        /// <returns>Возвращает true если зона является замкнутой, иначе false.</returns>
        public static bool IsEnclosed(this Area area,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) area).IsEnclosed(options);
        }

        /// <summary>
        /// Проверяет является зона не замкнутой.
        /// </summary>
        /// <param name="area">Проверяемая зона.</param>
        /// <param name="options">Опции получение границ зоны.</param>
        /// <returns>Возвращает true если зона является не замкнутой, иначе false.</returns>
        public static bool IsNotEnclosed(this Area area,
            SpatialElementBoundaryOptions options = default) {
            return ((SpatialElement) area).IsNotEnclosed(options);
        }
    }
}