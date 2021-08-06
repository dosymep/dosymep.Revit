using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace dosymep.Revit {
    /// <summary>
    /// Класс расширения UIDocument
    /// </summary>
    public static class UIDocumentExtensions {
        #region Selection

        /// <summary>
        /// Возвращает выделенные элементы в документе.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает выделенные элементы в документе.</returns>
        public static IEnumerable<Element> GetSelectedElements(this UIDocument document) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.Selection.GetElementIds().Select(item => document.Document.GetElement(item));
        }

        /// <summary>
        /// Выделяет переданные элементы.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="elements">Выделяемые элементы.</param>
        public static void SetSelectedElements(this UIDocument document, params Element[] elements) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(elements is null) {
                throw new ArgumentNullException(nameof(elements));
            }

            document.SetSelectedElements(elements.AsEnumerable());
        }

        /// <summary>
        /// Выделяет переданные элементы.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="elements">Выделяемые элементы.</param>
        public static void SetSelectedElements(this UIDocument document, IEnumerable<Element> elements) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(elements is null) {
                throw new ArgumentNullException(nameof(elements));
            }

            document.SetSelectedElements(elements.Select(item => item.Id));
        }

        /// <summary>
        /// Выделяет переданные элементы.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="elementIds">Идентификаторы выделяемых элементов.</param>
        public static void SetSelectedElements(this UIDocument document, params ElementId[] elementIds) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(elementIds is null) {
                throw new ArgumentNullException(nameof(elementIds));
            }

            document.SetSelectedElements(elementIds.AsEnumerable());
        }

        /// <summary>
        /// Выделяет переданные элементы.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="elementIds">Идентификаторы выделяемых элементов.</param>
        public static void SetSelectedElements(this UIDocument document, IEnumerable<ElementId> elementIds) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(elementIds is null) {
                throw new ArgumentNullException(nameof(elementIds));
            }

            document.Selection.SetElementIds(elementIds.ToArray());
        }

        #endregion
    }
}
