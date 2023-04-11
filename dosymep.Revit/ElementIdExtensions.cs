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
        /// Проверяет идентификатор на не null.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает true - если идентификатор элемента не null или <see cref="Autodesk.Revit.DB.ElementId.InvalidElementId"/>, иначе false.</returns>
        public static bool IsNotNull(this ElementId elementId) {
            return !elementId.IsNull();
        }

        /// <summary>
        /// Проверяет идентификатор, является ли он системным.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает true - если идентификатор элемента является системным, иначе false.</returns>
        public static bool IsSystemId(this ElementId elementId) {
            return !elementId.IsNull() && elementId.GetIdValue() < 0;
        }

        /// <summary>
        /// Проверяет идентификатор, является ли он не системным.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает true - если идентификатор элемента является не системным, иначе false.</returns>
        public static bool IsNotSystemId(this ElementId elementId) {
            return !elementId.IsNull() && elementId.GetIdValue() > 0;
        }

        /// <summary>
        /// Возвращает числовое значение идентификатора элемента.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns> Возвращает числовое значение идентификатора элемента.</returns>
#if REVIT_2023_OR_LESS
        public static int GetIdValue(this ElementId elementId) {
            return elementId.IntegerValue;
        }
#else
        public static long GetIdValue(this ElementId elementId) {
            return elementId.Value;
        }
#endif
    }
}