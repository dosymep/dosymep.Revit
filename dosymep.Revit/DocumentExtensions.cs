using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dosymep.Revit.Transmissions;

using InvalidOperationException = Autodesk.Revit.Exceptions.InvalidOperationException;

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
        public static bool IsExistsParam(this Autodesk.Revit.DB.Document document, string paramName) {
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
        public static bool IsExistsProjectParam(this Autodesk.Revit.DB.Document document, string paramName) {
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
        public static bool IsExistsSharedParam(this Autodesk.Revit.DB.Document document, string paramName) {
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
        public static bool IsExistsSharedParam(this Autodesk.Revit.DB.Document document, Guid paramGuid) {
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
        public static Autodesk.Revit.DB.ParameterElement GetProjectParam(this Autodesk.Revit.DB.Document document, string paramName) {
            return document.GetProjectParams().FirstOrDefault(item => item.Name.Equals(paramName));
        }
        
        /// <summary>
        /// Возвращает общий параметр по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <returns>Возвращает общий параметр по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static Autodesk.Revit.DB.SharedParameterElement GetSharedParam(this Autodesk.Revit.DB.Document document, string paramName) {
            return document.GetSharedParams().FirstOrDefault(item => item.Name.Equals(paramName)); 
        }
        
        /// <summary>
        /// Возвращает общий параметр по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramGuid">Guid общего параметра.</param>
        /// <returns>Возвращает общий параметр по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static Autodesk.Revit.DB.SharedParameterElement GetSharedParam(this Autodesk.Revit.DB.Document document, Guid paramGuid) {
            return document.GetSharedParams().FirstOrDefault(item => item.GuidValue.Equals(paramGuid)); 
        }
        
        /// <summary>
        /// Возвращает глобальный параметр по имени.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает глобальный параметр по имени. Если не параметр не был найден, то возвращается null.</returns>
        public static Autodesk.Revit.DB.GlobalParameter GetGlobalParam(this Autodesk.Revit.DB.Document document, string paramName) {
            return document.GetGlobalParams().FirstOrDefault(item => item.Name.Equals(paramName)); 
        }

        /// <summary>
        /// Возвращает список параметров проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает список параметров проекта.</returns>
        public static IEnumerable<Autodesk.Revit.DB.ParameterElement> GetProjectParams(this Autodesk.Revit.DB.Document document) {
            return document.GetProjectParamElements()
                .Where(item => item.IsProjectParam());
        }

        /// <summary>
        /// Возвращает список общих параметров.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает список общих параметров.</returns>
        public static IEnumerable<Autodesk.Revit.DB.SharedParameterElement> GetSharedParams(this Autodesk.Revit.DB.Document document) {
            return document.GetProjectParamElements()
                .Where(item => item.IsSharedParam())
                .OfType<Autodesk.Revit.DB.SharedParameterElement>();
        }
        
        /// <summary>
        /// Возвращает список глобальных параметров.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает список глобальных параметров.</returns>
        public static IEnumerable<Autodesk.Revit.DB.GlobalParameter> GetGlobalParams(this Autodesk.Revit.DB.Document document) {
            return new Autodesk.Revit.DB.FilteredElementCollector(document)
                .OfClass(typeof(Autodesk.Revit.DB.GlobalParameter))
                .OfType<Autodesk.Revit.DB.GlobalParameter>();
        }

        /// <summary>
        /// Возвращает все параметры проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает все параметры проекта.</returns>
        public static IEnumerable<Autodesk.Revit.DB.ParameterElement> GetProjectParamElements(this Autodesk.Revit.DB.Document document) {
            return document.GetParameterBindings().Select(item => document.GetElement(((dynamic) item.Definition).Id)).OfType<Autodesk.Revit.DB.ParameterElement>();
        }

        /// <summary>
        /// Возвращает связку определения параметра с привязкой.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <returns>Возвращает связку определения параметра с привязкой.</returns>
        public static IEnumerable<(Autodesk.Revit.DB.Definition Definition, Autodesk.Revit.DB.Binding Binding)> GetParameterBindings(this Autodesk.Revit.DB.Document document) {
            var iterator = document.ParameterBindings.ForwardIterator();
            while(iterator.MoveNext()) {
                yield return (iterator.Key, (Autodesk.Revit.DB.Binding) iterator.Current);
            }
        }
        
        /// <summary>
        /// Возвращает настройки привязки для системного параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает настройки привязки для системного параметра. Если параметр не был найден возвращает null.</returns>
        public static (Autodesk.Revit.DB.Definition Definition, Autodesk.Revit.DB.Binding Binding) GetSystemParamBinding(
            this Autodesk.Revit.DB.Document document, string paramName) {
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
        public static (Autodesk.Revit.DB.Definition Definition, Autodesk.Revit.DB.Binding Binding) GetSharedParamBinding(
            this Autodesk.Revit.DB.Document document, string paramName) {
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
        public static (Autodesk.Revit.DB.Definition Definition, Autodesk.Revit.DB.Binding Binding) GetProjectParamBinding(
            this Autodesk.Revit.DB.Document document,string paramName) {
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
        public static bool IsSystemParamDefinition(this Autodesk.Revit.DB.Document document, Autodesk.Revit.DB.Definition definition) {
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
        public static bool IsSharedParamDefinition(this Autodesk.Revit.DB.Document document, Autodesk.Revit.DB.Definition definition) {
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

            return document.GetElement(elementId) is Autodesk.Revit.DB.SharedParameterElement;
        }
        
        /// <summary>
        /// Проверяет является ли определение глобальным параметром.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение является глобальным параметром, иначе false.</returns>
        public static bool IsGlobalParamDefinition(this Autodesk.Revit.DB.Document document, Autodesk.Revit.DB.Definition definition) {
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
            
            return document.GetElement(elementId) is Autodesk.Revit.DB.GlobalParameter;
        }
        
        /// <summary>
        /// Проверяет является ли определение параметра проекта.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является проекта, иначе false.</returns>
        public static bool IsProjectParamDefinition(this Autodesk.Revit.DB.Document document, Autodesk.Revit.DB.Definition definition) {
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
            
            return document.GetElement(elementId) is Autodesk.Revit.DB.ParameterElement
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
        public static Autodesk.Revit.DB.Transaction StartTransaction(this Autodesk.Revit.DB.Document document, string transactionName) {
            var transaction = new Autodesk.Revit.DB.Transaction(document);
            transaction.BIMStart(transactionName);

            return transaction;
        }
        
        /// <summary>
        /// Запускает групповую транзакцию на изменение документа.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="transactionName">Название транзакции.</param>
        /// <returns>Возвращает запущенную групповую транзакцию на изменение документа.</returns>
        public static Autodesk.Revit.DB.TransactionGroup StartTransactionGroup(this Autodesk.Revit.DB.Document document, string transactionName) {
            var transaction = new Autodesk.Revit.DB.TransactionGroup(document);
            transaction.BIMStart(transactionName);

            return transaction;
        }

        /// <summary>
        /// Возвращает тип системного параметра.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="builtInParameter">Системный параметр документа.</param>
        /// <returns>Возвращает тип системного параметра.</returns>
        public static Autodesk.Revit.DB.StorageType GetStorageType(this Autodesk.Revit.DB.Document document, Autodesk.Revit.DB.BuiltInParameter builtInParameter) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            try {
                return document.get_TypeOfStorage(builtInParameter);
            } catch(InvalidOperationException) {
                return Autodesk.Revit.DB.StorageType.None;
            }
        }
        
    #if D2022 || R2022
        /// <summary>
        /// Возвращает тип системного параметра.
        /// </summary>
        /// <param name="document">Документ Revit.</param>
        /// <param name="forgeTypeId">Системный параметр документа.</param>
        /// <returns>Возвращает тип системного параметра.</returns>
        public static Autodesk.Revit.DB.StorageType GetStorageType(this Autodesk.Revit.DB.Document document, Autodesk.Revit.DB.ForgeTypeId forgeTypeId) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            try {
                return document.GetTypeOfStorage(forgeTypeId);
            } catch(InvalidOperationException) {
                return Autodesk.Revit.DB.StorageType.None;
            }
        }
    #endif
    }
}
