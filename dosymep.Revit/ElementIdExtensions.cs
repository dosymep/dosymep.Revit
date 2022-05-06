using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения для идентификатора элемента.
    /// </summary>
    public static class ElementIdExtensions {
        /// <summary>
        /// Проверяет идентификатор на null.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает true - если идентификатор элемента null или <see cref="Autodesk.Revit.DB.ElementId.InvalidElementId"/>, иначе false.</returns>
        public static bool IsNull(this ElementId elementId) {
            return elementId == null || elementId == ElementId.InvalidElementId;
        }

        /// <summary>
        /// Проверяет идентификатор, является ли он системным.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает <see cref="bool.True"/> - если идентификатор элемента является системным, иначе false.</returns>
        public static bool IsSystemId(this ElementId elementId) {
            return !elementId.IsNull() && elementId.IntegerValue < 0;
        }

        /// <summary>
        /// Проверяет идентификатор, является ли он не системным.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает true - если идентификатор элемента является не системным, иначе false.</returns>
        public static bool IsNotSystemId(this ElementId elementId) {
            return !elementId.IsNull() && elementId.IntegerValue > 0;
        }
    }
}