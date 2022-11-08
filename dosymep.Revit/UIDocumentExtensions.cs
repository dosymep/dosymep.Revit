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

            var elementIds = elements
                .Where(item => document.IsNotLinkedElement(item))
                .Select(item => item.Id);
            
            document.SetSelectedElements(elementIds);
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
        
        /// <summary>
        /// Возвращает уникальный идентификатор документа.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает уникальный идентификатор документа.</returns>
        /// <remarks>На данный момент возвращает отображаемое имя документа <see cref="Document.Title"/>.</remarks>
        public static string GetUniqId(this UIDocument document) {
            return document.Document.GetUniqId();
        }
        
        /// <summary>
        /// Возвращает активный вид.
        /// </summary>
        /// <param name="uiDocument">Документ.</param>
        /// <returns>Возвращает активный вид.</returns>
        public static UIView GetActiveUIView(this UIDocument uiDocument) {
            return uiDocument.GetOpenUIViews().First(item => item.ViewId == uiDocument.ActiveView.Id);
        }
        
        /// <summary>
        /// Возвращает признак того что элемент из связанного документа.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="element">Элемент.</param>
        /// <returns>True если элемент из связанного документа, иначе false.</returns>
        public static bool IsLinkedElement(this UIDocument document, Element element) {
            return !element.Document.IsLinkedElement(element);
        }
        
        /// <summary>
        /// Возвращает признак того что элемент не из связанного документа.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="element">Элемент.</param>
        /// <returns>True если элемент не из связанного документа, иначе false.</returns>
        public static bool IsNotLinkedElement(this UIDocument document, Element element) {
            return !document.IsLinkedElement(element);
        }
    }
}
