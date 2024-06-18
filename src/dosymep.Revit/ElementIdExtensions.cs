using System;

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
        /// Конвертирует идентификатор в <see cref="BuiltInCategory"/>.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает <see cref="BuiltInCategory"/>.</returns>
        /// <exception cref="System.ArgumentException">Если идентификатор не является встроенной категорией.</exception>
        public static BuiltInCategory AsBuiltInCategory(this ElementId elementId) {
            if(elementId.IsNotSystemId()) {
                throw new ArgumentException(
                    $"Идентификатор \"{elementId.GetIdValue()}\" не является системным.", nameof(elementId));
            }

            return (BuiltInCategory) elementId.GetIdValue();
        }

        /// <summary>
        /// Конвертирует идентификатор в <see cref="BuiltInParameter"/>.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает <see cref="BuiltInParameter"/>.</returns>
        /// <exception cref="System.ArgumentException">Если идентификатор не является встроенным параметром.</exception>
        public static BuiltInParameter AsBuiltInParameter(this ElementId elementId) {
            if(elementId.IsNotSystemId()) {
                throw new ArgumentException(
                    $"Идентификатор \"{elementId.GetIdValue()}\" не является системным.", nameof(elementId));
            }

            return (BuiltInParameter) elementId.GetIdValue();
        }

        /// <summary>
        /// Возвращает числовое значение идентификатора элемента.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns> Возвращает числовое значение идентификатора элемента.</returns>
#if REVIT2024_OR_GREATER
        public static long GetIdValue(this ElementId elementId) {
            return elementId.Value;
        }
#else
        public static int GetIdValue(this ElementId elementId) {
            return elementId.IntegerValue;
        }
#endif
    }
}