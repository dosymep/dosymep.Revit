using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using dosymep.Revit.Geometry;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения для документа Revit.
    /// </summary>
    public static partial class DocumentExtensions {
        #region IsExistsParam

        /// <summary>
        /// Проверяет на наличие параметра документа.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает true если параметр был добавлен в Revit, иначе false.</returns>
        /// <exception cref="System.ArgumentException">Наименование параметра не может быть null или пустым.</exception>
        public static bool IsExistsParam(this Document document, string paramName) {
            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return document.GetProjectParamElements().Any(item => item.Name.Equals(paramName));
        }

        /// <summary>
        /// Проверяет на наличие параметра проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает true если параметр проекта был добавлен в Revit, иначе false.</returns>
        /// <exception cref="System.ArgumentException">Наименование параметра проекта не может быть null или пустым.</exception>
        public static bool IsExistsProjectParam(this Document document, string paramName) {
            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return document.GetProjectParams().Any(item => item.Name.Equals(paramName));
        }

        /// <summary>
        /// Проверяет на наличие общего параметра проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="paramName">Наименование общего параметра проекта.</param>
        /// <returns>Возвращает true если общий параметр проекта был добавлен в Revit, иначе false.</returns>
        /// <exception cref="System.ArgumentException">Наименование общего параметра не может быть null или пустым.</exception>
        public static bool IsExistsSharedParam(this Document document, string paramName) {
            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return document.GetSharedParams().Any(item => item.Name.Equals(paramName));
        }
        
        /// <summary>
        /// Проверяет на наличие общего параметра проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="paramGuid">Guid общего параметра проекта.</param>
        /// <returns>Возвращает true если общий параметр проекта был добавлен в Revit, иначе false.</returns>
        /// <exception cref="System.ArgumentException">Наименование общего параметра не может быть null или пустым.</exception>
        public static bool IsExistsSharedParam(this Document document, Guid paramGuid) {
            return document.GetSharedParams().Any(item => item.GuidValue.Equals(paramGuid));
        }

        #endregion

        #region GetProjectParams

        /// <summary>
        /// Возвращает параметр проекта по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает параметр проекта по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static ParameterElement GetProjectParam(this Document document, string paramName) {
            return document.GetProjectParams().FirstOrDefault(item => item.Name.Equals(paramName));
        }
        
        /// <summary>
        /// Возвращает общий параметр по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <returns>Возвращает общий параметр по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static SharedParameterElement GetSharedParam(this Document document, string paramName) {
            return document.GetSharedParams().FirstOrDefault(item => item.Name.Equals(paramName)); 
        }
        
        /// <summary>
        /// Возвращает общий параметр по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramGuid">Guid общего параметра.</param>
        /// <returns>Возвращает общий параметр по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static SharedParameterElement GetSharedParam(this Document document, Guid paramGuid) {
            return document.GetSharedParams().FirstOrDefault(item => item.GuidValue.Equals(paramGuid)); 
        }
        
        /// <summary>
        /// Возвращает глобальный параметр по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает глобальный параметр по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static GlobalParameter GetGlobalParam(this Document document, string paramName) {
            return document.GetGlobalParams().FirstOrDefault(item => item.Name.Equals(paramName)); 
        }

        /// <summary>
        /// Возвращает список параметров проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает список параметров проекта.</returns>
        public static IEnumerable<ParameterElement> GetProjectParams(this Document document) {
            return document.GetProjectParamElements()
                .Where(item => item.IsProjectParam());
        }

        /// <summary>
        /// Возвращает список общих параметров.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает список общих параметров.</returns>
        public static IEnumerable<SharedParameterElement> GetSharedParams(this Document document) {
            return document.GetProjectParamElements()
                .Where(item => item.IsSharedParam())
                .OfType<SharedParameterElement>();
        }
        
        /// <summary>
        /// Возвращает список глобальных параметров.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает список глобальных параметров.</returns>
        public static IEnumerable<GlobalParameter> GetGlobalParams(this Document document) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(GlobalParameter))
                .OfType<GlobalParameter>();
        }

        /// <summary>
        /// Возвращает все параметры проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает все параметры проекта.</returns>
        public static IEnumerable<ParameterElement> GetProjectParamElements(this Document document) {
            return document.GetParameterBindings().Select(item => document.GetElement(((dynamic) item.Definition).Id)).OfType<ParameterElement>();
        }

        /// <summary>
        /// Возвращает связку определения параметра с привязкой.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает связку определения параметра с привязкой.</returns>
        public static IEnumerable<(Definition Definition, Binding Binding)> GetParameterBindings(this Document document) {
            var iterator = document.ParameterBindings.ForwardIterator();
            while(iterator.MoveNext()) {
                yield return (iterator.Key, (Binding) iterator.Current);
            }
        }
        
        /// <summary>
        /// Возвращает настройки привязки для системного параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает настройки привязки для системного параметра. Если параметр не был найден возвращает null.</returns>
        public static (Definition Definition, Binding Binding) GetSystemParamBinding(
            this Document document, string paramName) {
            return document.GetParameterBindings()
                .Where(item => item.Definition.Name.Equals(paramName))
                .FirstOrDefault(item => document.IsSystemParamDefinition(item.Definition));
        }

        /// <summary>
        /// Возвращает настройки привязки для общего параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает настройки привязки для общего параметра. Если параметр не был найден возвращает null.</returns>
        public static (Definition Definition, Binding Binding) GetSharedParamBinding(
            this Document document, string paramName) {
            return document.GetParameterBindings()
                .Where(item => item.Definition.Name.Equals(paramName))
                .FirstOrDefault(item => document.IsSharedParamDefinition(item.Definition));
        }
        
        /// <summary>
        /// Возвращает настройки привязки для параметра проекта.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает настройки привязки для параметра проекта. Если параметр не был найден возвращает null.</returns>
        public static (Definition Definition, Binding Binding) GetProjectParamBinding(
            this Document document,string paramName) {
            return document.GetParameterBindings()
                .Where(item => item.Definition.Name.Equals(paramName))
                .FirstOrDefault(item => document.IsProjectParamDefinition(item.Definition));
        }

        #endregion

        #region ParamDefinition

        /// <summary>
        /// Проверяет является ли определение параметра внутренним.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является внутренним, иначе false.</returns>
        public static bool IsSystemParamDefinition(this Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(definition is null) {
                throw new ArgumentNullException(nameof(definition));
            }

            return definition.GetElementId().IsSystemId() == true;
        }

        /// <summary>
        /// Проверяет является ли определение параметра общим.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является общим, иначе false.</returns>
        public static bool IsSharedParamDefinition(this Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(definition is null) {
                throw new ArgumentNullException(nameof(definition));
            }
            
            var elementId = definition.GetElementId();
            if(elementId.IsNull() || elementId.IsSystemId()) {
                return false;
            }

            return document.GetElement(elementId) is SharedParameterElement;
        }
        
        /// <summary>
        /// Проверяет является ли определение глобальным параметром.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение является глобальным параметром, иначе false.</returns>
        public static bool IsGlobalParamDefinition(this Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(definition is null) {
                throw new ArgumentNullException(nameof(definition));
            }

            var elementId = definition.GetElementId();
            if(elementId.IsNull() || elementId.IsSystemId()) {
                return false;
            }
            
            return document.GetElement(elementId) is GlobalParameter;
        }
        
        /// <summary>
        /// Проверяет является ли определение параметра проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является проекта, иначе false.</returns>
        public static bool IsProjectParamDefinition(this Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(definition is null) {
                throw new ArgumentNullException(nameof(definition));
            }

            var elementId = definition.GetElementId();
            if(elementId.IsNull() || elementId.IsSystemId()) {
                return false;
            }
            
            return document.GetElement(elementId) is ParameterElement
                   && !document.IsSharedParamDefinition(definition)
                   && !document.IsGlobalParamDefinition(definition);
        }

        #endregion

        /// <summary>
        /// Запускает транзакцию на изменение документа.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="transactionName">Название транзакции.</param>
        /// <returns>Возвращает запущенную транзакцию на изменение документа.</returns>
        public static Transaction StartTransaction(this Document document, string transactionName) {
            var transaction = new Transaction(document);
            transaction.BIMStart(transactionName);

            return transaction;
        }

        /// <summary>
        /// Запускает групповую транзакцию на изменение документа.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="transactionName">Название транзакции.</param>
        /// <returns>Возвращает запущенную групповую транзакцию на изменение документа.</returns>
        public static TransactionGroup StartTransactionGroup(this Document document, string transactionName) {
            var transaction = new TransactionGroup(document);
            transaction.BIMStart(transactionName);

            return transaction;
        }

        /// <summary>
        /// Возвращает уникальный идентификатор документа.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает уникальный идентификатор документа.</returns>
        /// <remarks>На данный момент возвращает отображаемое имя документа <see cref="Document.Title"/>.</remarks>
        public static string GetUniqId(this Document document) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.Title;
        }

        /// <summary>
        /// Показывает и выделяет элементы в документе.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="view">3D вид.</param>
        /// <param name="elements">Список элементов.</param>
        /// <param name="offset">Расстояние на которое увеличивается <see cref="BoundingBoxXYZ"/>, во внутренних координатах.</param>
        public static void ZoomToElements(this Document document, View3D view, IList<Element> elements, double offset = 5) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(view == null) {
                throw new ArgumentNullException(nameof(view));
            }

            if(elements == null) {
                throw new ArgumentNullException(nameof(elements));
            }

            var uiDocument = new UIDocument(document);

            uiDocument.ActiveView = view;
            UIView uiView = uiDocument.GetActiveUIView();

            Dictionary<string, Transform> transforms = document.GetTopLinkInstances()
                .ToDictionary(item => item.Document.GetUniqId(),
                    item => item.GetTotalTransform());

            BoundingBoxXYZ bb = elements.CreateCommonBoundingBox(view, transforms)
                .IncreaseBoundingBox(offset);
            
            using(Transaction transaction = document.StartTransaction("Установка подрезки.")) {
                view.SetSectionBox(bb);
                uiView.ZoomAndCenterRectangle(bb.Min, bb.Max);
                uiDocument.SetSelectedElements(elements);

                transaction.Commit();
            }
        }
        
        /// <summary>
        /// Возвращает признак того что элемент из связанного документа.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="element">Элемент.</param>
        /// <returns>True если элемент из связанного документа, иначе false.</returns>
        public static bool IsLinkedElement(this Document document, Element element) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            return !element.Document.GetUniqId().Equals(document.GetUniqId());
        }
        
        /// <summary>
        /// Возвращает признак того что элемент не из связанного документа.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="element">Элемент.</param>
        /// <returns>True если элемент не из связанного документа, иначе false.</returns>
        public static bool IsNotLinkedElement(this Document document, Element element) {
            return !document.IsLinkedElement(element);
        }

        /// <summary>
        /// Возвращает тип системного параметра.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="builtInParameter">Системный параметр документа.</param>
        /// <returns>Возвращает тип системного параметра.</returns>
        public static StorageType GetStorageType(this Document document, BuiltInParameter builtInParameter) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            try {
                return document.get_TypeOfStorage(builtInParameter);
            } catch(Autodesk.Revit.Exceptions.InvalidOperationException) {
                return StorageType.None;
            }
        }
        
    #if REVIT2022_OR_GREATER
        
        /// <summary>
        /// Возвращает тип системного параметра.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="forgeTypeId">Системный параметр документа.</param>
        /// <returns>Возвращает тип системного параметра.</returns>
        public static StorageType GetStorageType(this Document document, ForgeTypeId forgeTypeId) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            try {
                return document.GetTypeOfStorage(forgeTypeId);
            } catch(Autodesk.Revit.Exceptions.InvalidOperationException) {
                return StorageType.None;
            }
        }
        
    #endif
        
        /// <summary>
        /// Возвращает ссылки верхнего уровня.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает ссылки верхнего уровня.</returns>
        internal static IEnumerable<RevitLinkInstance> GetTopLinkInstances(this Document document) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            return new FilteredElementCollector(document)
                .OfClass(typeof(RevitLinkInstance))
                .Cast<RevitLinkInstance>()
                .Where(item => item.GetLinkDocument() != null)
                .Where(item => !item.GetElementType<RevitLinkType>().IsNestedLink);
        }
    }
}
