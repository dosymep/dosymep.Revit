using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit.Geometry;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения для элемента Revit.
    /// </summary>
    public static class ElementExtensions {
        #region Получение параметра по его имени

        /// <summary>
        /// Проверяет на существование параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Element element, string paramName) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(paramName));
            }

            try {
                return element.TryGetParam(paramName, out _);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на существование значение параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает true - если значение параметра существует, иначе false.</returns>
        public static bool IsExistsParamValue(this Element element, string paramName) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(paramName));
            }

            return element.GetParamValueOrDefault(paramName) != default;
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static T GetParamValueOrDefault<T>(this Element element, string paramName, T @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            try {
                object value = element.GetParamValue(paramName);
                return value == null ? @default : (T) value;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static object GetParamValueOrDefault(this Element element, string paramName, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            try {
                return element.GetParamValue(paramName) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static T GetParamValue<T>(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            object value = element.GetParam(paramName).AsObject();
            return value == null ? default : (T) value;
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static object GetParamValue(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return element.GetParam(paramName).AsObject();
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, string paramName, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, string paramName, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, string paramName, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, string paramName, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Удаляет параметр по его имени.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает признак удаления параметра true - если был удален, иначе false.</returns>
        public static bool RemoveParamValue(this Element element, string paramName) {
            try {
                element.GetParam(paramName).RemoveValue();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            bool isExists = TryGetParam(element, paramName, out Parameter param);
            if(!isExists) {
                throw new ArgumentException($"Параметра с заданным именем \"{paramName}\" у элемента не существует.", nameof(paramName));
            }

            return param;
        }

        #endregion

        #region Получение общего параметра по его имени

        /// <summary>
        /// Проверяет на существование общего параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает true - если общий параметр существует, иначе false.</returns>
        public static bool IsExistsSharedParam(this Element element, string paramName) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(paramName));
            }

            try {
                return element.TryGetSharedParam(paramName, out _);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на существование значение общего параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает true - если значение общего параметра существует, иначе false.</returns>
        public static bool IsExistsSharedParamValue(this Element element, string paramName) {
            return element.GetSharedParamValueOrDefault(paramName) != default;
        }

        /// <summary>
        /// Возвращает значение общего параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение общего параметра либо значение по умолчанию.</returns>
        public static T GetSharedParamValueOrDefault<T>(this Element element, string paramName, T @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            try {
                object value = element.GetSharedParamValue(paramName);
                return value == null ? @default : (T) value;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение общего параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение общего параметра либо значение по умолчанию.</returns>
        public static object GetSharedParamValueOrDefault(this Element element, string paramName, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            try {
                return element.GetSharedParamValue(paramName) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение общего параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <returns>Возвращает значение общего параметра элемента.</returns>
        public static T GetSharedParamValue<T>(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            object value = element.GetSharedParam(paramName).AsObject();
            return value == null ? default : (T) value;
        }

        /// <summary>
        /// Возвращает значение общего параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <returns>Возвращает значение общего параметра элемента.</returns>
        public static object GetSharedParamValue(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return element.GetSharedParam(paramName).AsObject();
        }

        /// <summary>
        /// Устанавливает значение общего параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего  параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetSharedParamValue(this Element element, string paramName, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetSharedParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение общего параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetSharedParamValue(this Element element, string paramName, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetSharedParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение общего параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetSharedParamValue(this Element element, string paramName, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetSharedParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение общего параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetSharedParamValue(this Element element, string paramName, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetSharedParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Удаляет общий параметр по его имени.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <returns>Возвращает признак удаления общего параметра true - если был удален, иначе false.</returns>
        public static bool RemoveSharedParamValue(this Element element, string paramName) {
            try {
                element.GetSharedParam(paramName).RemoveValue();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование общего параметра.</param>
        /// <returns>Возвращает общий параметр.</returns>
        public static Parameter GetSharedParam(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            bool isExists = element.TryGetSharedParam(paramName, out Parameter param);
            if(!isExists) {
                throw new ArgumentException($"Общего параметра с заданным именем \"{paramName}\" у элемента не существует.", nameof(paramName));
            }

            return param;
        }

        /// <summary>
        /// Возвращает общий параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramGuid">Guid общего параметра.</param>
        /// <returns>Возвращает общий параметр.</returns>
        public static Parameter GetSharedParam(this Element element, Guid paramGuid) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            bool isExists = element.TryGetSharedParam(paramGuid, out Parameter param);
            if(!isExists) {
                throw new ArgumentException($"Общего параметра с заданным Guid \"{paramGuid}\" у элемента не существует.", nameof(paramGuid));
            }

            return param;
        }

        #endregion

        #region Получение параметра проекта по его имени

        /// <summary>
        /// Проверяет на существование параметра проекта в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает true - если параметр проекта существует, иначе false.</returns>
        public static bool IsExistsProjectParam(this Element element, string paramName) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(paramName));
            }

            try {
                return element.TryGetProjectParam(paramName, out _);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на существование значения параметра проекта в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает true - если значение параметра проекта существует, иначе false.</returns>
        public static bool IsExistsProjectParamValue(this Element element, string paramName) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(paramName));
            }

            return element.GetProjectParamValueOrDefault(paramName) != default;
        }

        /// <summary>
        /// Возвращает значение параметра проекта либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра проекта либо значение по умолчанию.</returns>
        public static T GetProjectParamValueOrDefault<T>(this Element element, string paramName, T @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            try {
                object value = element.GetProjectParamValue(paramName);
                return value == null ? @default : (T) value;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра проекта либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра проекта либо значение по умолчанию.</returns>
        public static object GetProjectParamValueOrDefault(this Element element, string paramName, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            try {
                return element.GetProjectParamValue(paramName) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра проекта элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает значение параметра проекта элемента.</returns>
        public static T GetProjectParamValue<T>(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            object value = element.GetProjectParam(paramName).AsObject();
            return value == null ? default : (T) value;
        }

        /// <summary>
        /// Возвращает значение параметра проекта элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает значение параметра проекта элемента.</returns>
        public static object GetProjectParamValue(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return element.GetProjectParam(paramName).AsObject();
        }

        /// <summary>
        /// Устанавливает значение параметра проекта.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <param name="paramValue">Значение параметра проекта.</param>
        public static void SetProjectParamValue(this Element element, string paramName, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetProjectParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра проекта.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <param name="paramValue">Значение параметра проекта.</param>
        public static void SetProjectParamValue(this Element element, string paramName, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetProjectParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра проекта.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <param name="paramValue">Значение параметра проекта.</param>
        public static void SetProjectParamValue(this Element element, string paramName, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetProjectParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра проекта.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра. проекта</param>
        /// <param name="paramValue">Значение параметра проекта.</param>
        public static void SetProjectParamValue(this Element element, string paramName, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            element.GetProjectParam(paramName).Set(paramValue);
        }

        /// <summary>
        /// Удаляет параметр проекта по его имени.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает признак удаления параметра проекта true - если был удален, иначе false.</returns>
        public static bool RemoveProjectParamValue(this Element element, string paramName) {
            try {
                element.GetProjectParam(paramName).RemoveValue();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Возвращает параметр проекта.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра проекта.</param>
        /// <returns>Возвращает параметр проекта.</returns>
        public static Parameter GetProjectParam(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            bool isExists = element.TryGetProjectParam(paramName, out Parameter param);
            if(!isExists) {
                throw new ArgumentException($"Параметра с заданным именем \"{paramName}\" у элемента не существует.", nameof(paramName));
            }

            return param;
        }

        #endregion

        #region Получение параметра по BuiltInParameter

        /// <summary>
        /// Проверяет на существование параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Element element, BuiltInParameter builtInParameter) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            try {
                return element.TryGetParam(builtInParameter, out _);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на существование значения параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <returns>Возвращает true - если значение параметра существует, иначе false.</returns>
        public static bool IsExistsParamValue(this Element element, BuiltInParameter builtInParameter) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            return element.GetParamValueOrDefault(builtInParameter) != default;
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static T GetParamValueOrDefault<T>(this Element element, BuiltInParameter builtInParameter, T @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            try {
                object value = element.GetParamValue(builtInParameter);
                return value == null ? @default : (T) value;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static object GetParamValueOrDefault(this Element element, BuiltInParameter builtInParameter, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            try {
                return element.GetParamValue(builtInParameter) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static T GetParamValue<T>(this Element element, BuiltInParameter builtInParameter) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            object value = element.GetParam(builtInParameter).AsObject();
            return value == null ? default : (T) value;
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static object GetParamValue(this Element element, BuiltInParameter builtInParameter) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            return element.GetParam(builtInParameter).AsObject();
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, BuiltInParameter builtInParameter, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(builtInParameter).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, BuiltInParameter builtInParameter, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(builtInParameter).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, BuiltInParameter builtInParameter, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(builtInParameter).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        public static void SetParamValue(this Element element, BuiltInParameter builtInParameter, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(builtInParameter).Set(paramValue);
        }

        /// <summary>
        /// Удаляет параметр по его встроенному типу.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <returns>Возвращает признак удаления параметра true - если был удален, иначе false.</returns>
        public static bool RemoveParamValue(this Element element, BuiltInParameter builtInParameter) {
            try {
                element.GetParam(builtInParameter).RemoveValue();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Встроенный тип параметра.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, BuiltInParameter builtInParameter) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            bool isExists = element.TryGetParam(builtInParameter, out Parameter param);
            if(!isExists) {
                throw new ArgumentException($"Параметра с заданным именем \"{builtInParameter}\" у элемента не существует.", nameof(builtInParameter));
            }

            return param;
        }

        #endregion

#if REVIT2022_OR_GREATER

        #region Получение параметра по ForgeTypeId

        /// <summary>
        /// Проверяет на существование параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Element element, ForgeTypeId forgeTypeId) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            try {
                return element.TryGetParam(forgeTypeId, out _);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на существование значения параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает true - если значение параметра существует, иначе false.</returns>
        public static bool IsExistsParamValue(this Element element, ForgeTypeId forgeTypeId) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            return element.GetParamValueOrDefault(forgeTypeId) != default;
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static T GetParamValueOrDefault<T>(this Element element, ForgeTypeId forgeTypeId, T @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            try {
                object value = element.GetParamValue(forgeTypeId);
                return value == null ? @default : (T) value;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static object GetParamValueOrDefault(this Element element, ForgeTypeId forgeTypeId, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            try {
                return element.GetParamValue(forgeTypeId) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static T GetParamValue<T>(this Element element, ForgeTypeId forgeTypeId) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            object value = element.GetParam(forgeTypeId).AsObject();
            return value == null ? default : (T) value;
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static object GetParamValue(this Element element, ForgeTypeId forgeTypeId) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            return element.GetParam(forgeTypeId).AsObject();
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ForgeTypeId forgeTypeId, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(forgeTypeId).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ForgeTypeId forgeTypeId, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(forgeTypeId).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ForgeTypeId forgeTypeId, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(forgeTypeId).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ForgeTypeId forgeTypeId, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(forgeTypeId).Set(paramValue);
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, ForgeTypeId forgeTypeId) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            bool isExists = element.TryGetParam(forgeTypeId, out Parameter param);
            if(!isExists) {
                throw new ArgumentException($"Параметра с заданным именем \"{forgeTypeId}\" у элемента не существует.", nameof(forgeTypeId));
            }

            return param;
        }

        /// <summary>
        /// Удаляет параметр по его встроенному типу.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает признак удаления параметра true - если был удален, иначе false.</returns>
        public static bool RemoveParamValue(this Element element, ForgeTypeId forgeTypeId) {
            try {
                element.GetParam(forgeTypeId).RemoveValue();
                return true;
            } catch {
                return false;
            }
        }

        #endregion

#endif

        /// <summary>
        /// Проверяет элемент является ли он <see cref="Autodesk.Revit.DB.ElementType"/>
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает true - если элемент является типом элемента, иначе false.</returns>
        public static bool IsElementType(this Element element) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            return element is ElementType;
        }

        /// <summary>
        /// Проверяет есть ли тип у элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает true - если у элемента есть тип, иначе false.</returns>
        public static bool HasElementType(this Element element) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            return element.GetTypeId().IsNotNull();
        }

        /// <summary>
        /// Возвращает тип элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает тип элемента.</returns>
        public static ElementType GetElementType(this Element element) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(element.IsElementType()) {
                throw new ArgumentException("Был передан тип элемента.", nameof(element));
            }

            if(!element.HasElementType()) {
                throw new ArgumentException("У элемента нет элемента типа", nameof(element));
            }

            return (ElementType) element.Document.GetElement(element.GetTypeId());
        }

        /// <summary>
        /// Возвращает тип элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает тип элемента.</returns>
        public static T GetElementType<T>(this Element element) where T : ElementType {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(element.IsElementType()) {
                throw new ArgumentException("Был передан тип элемента.", nameof(element));
            }

            if(!element.HasElementType()) {
                throw new ArgumentException("У элемента нет элемента типа", nameof(element));
            }

            return (T) element.GetElementType();
        }

        /// <summary>
        /// Возвращает <see cref="BoundingBoxXYZ"/> по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает <see cref="BoundingBoxXYZ"/> по умолчанию.</returns>
        /// <remarks>Может вернуть Null, если у элемента нет <see cref="BoundingBoxXYZ"/>.</remarks>
        public static BoundingBoxXYZ GetBoundingBox(this Element element) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            return element.get_BoundingBox(null);
        }

        /// <summary>
        /// Возвращает <see cref="BoundingBoxXYZ"/> по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="view">Вид у которого будет браться <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает <see cref="BoundingBoxXYZ"/> по умолчанию.</returns>
        /// <remarks>Может вернуть Null, если у элемента нет <see cref="BoundingBoxXYZ"/>.</remarks>
        public static BoundingBoxXYZ GetBoundingBox(this Element element, View view) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(view == null) {
                throw new ArgumentNullException(nameof(view));
            }

            return element.get_BoundingBox(view);
        }

        /// <summary>
        /// Проверяет принадлежность элемента к переданной категории.
        /// </summary>
        /// <param name="element">Проверяемый элемент.</param>
        /// <param name="category">Проверяемая категория.</param>
        /// <returns>Возвращает true - если элемент является переданной категории, иначе false.</returns>
        public static bool InAnyCategory(this Element element, BuiltInCategory category) {
            return (BuiltInCategory) element.Category.Id.GetIdValue() == category;
        }

        /// <summary>
        /// Проверяет принадлежность элемента к переданным категориям.
        /// </summary>
        /// <param name="element">Проверяемый элемент.</param>
        /// <param name="categories">Проверяемые категории.</param>
        /// <returns>Возвращает true - если элемент является переданным категориям, иначе false.</returns>
        public static bool InAnyCategory(this Element element, params BuiltInCategory[] categories) {
            return element.InAnyCategory(categories.AsEnumerable());
        }

        /// <summary>
        /// Проверяет принадлежность элемента к переданным категориям.
        /// </summary>
        /// <param name="element">Проверяемый элемент.</param>
        /// <param name="categories">Проверяемые категории.</param>
        /// <returns>Возвращает true - если элемент является переданным категориям, иначе false.</returns>
        public static bool InAnyCategory(this Element element, IEnumerable<BuiltInCategory> categories) {
            return categories.Any(item => element.InAnyCategory(item));
        }

        internal static IEnumerable<BoundingBoxXYZ> GetBoundingBoxes(this IEnumerable<Element> elements,
            View view,
            Dictionary<string, Transform> transforms) {
            foreach(Element element in elements) {
                string uniqId = element.Document.GetUniqId();
                Transform transform = transforms.TryGetValue(uniqId, out Transform trans) ? trans : Transform.Identity;
                BoundingBoxXYZ bb = element.GetBoundingBox(view);
                if(bb != null) {
                    yield return bb.TransformBoundingBox(transform);
                }
            }
        }

        internal static BoundingBoxXYZ CreateCommonBoundingBox(this IEnumerable<Element> elements,
            View view,
            Dictionary<string, Transform> transforms) {
            return elements.GetBoundingBoxes(view, transforms).ToArray().CreateCommonBoundingBox();
        }

        /// <summary>
        /// Пытается найти параметр у элемента по названию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Название параметра.</param>
        /// <param name="param">Параметр, если он найден.</param>
        /// <returns>True, если параметр найден и не равен null, иначе False.</returns>
        private static bool TryGetParam(this Element element, string paramName, out Parameter param) {
            param = element.LookupParameter(paramName);
            return param != null;
        }

        /// <summary>
        /// Пытается найти общий параметр у элемента по названию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Название общего параметра.</param>
        /// <param name="param">Параметр, если он найден.</param>
        /// <returns>True, если параметр найден и не равен null, иначе False.</returns>
        private static bool TryGetSharedParam(this Element element, string paramName, out Parameter param) {
            param = element.GetParameters(paramName).FirstOrDefault(item => item.IsShared);
            return param != null;
        }

        /// <summary>
        /// Пытается найти общий параметр у элемента по Guid.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramGuid">Guid общего параметра.</param>
        /// <param name="param">Параметр, если он найден.</param>
        /// <returns>True, если параметр найден и не равен null, иначе False.</returns>
        private static bool TryGetSharedParam(this Element element, Guid paramGuid, out Parameter param) {
            param = element.get_Parameter(paramGuid);
            return param != null;
        }

        /// <summary>
        /// Пытается найти параметр проекта у элемента по названию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Название параметра проекта.</param>
        /// <param name="param">Параметр, если он найден.</param>
        /// <returns>True, если параметр найден и не равен null, иначе False.</returns>
        private static bool TryGetProjectParam(this Element element, string paramName, out Parameter param) {
            param = element.GetParameters(paramName).FirstOrDefault(item => !item.IsShared);
            return param != null;
        }

        /// <summary>
        /// Пытается найти параметр у элемента по <see cref="BuiltInParameter"/>.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="builtInParameter">Значение <see cref="BuiltInParameter"/> параметра.</param>
        /// <param name="param">Параметр, если он найден.</param>
        /// <returns>True, если параметр найден и не равен null, иначе False.</returns>
        private static bool TryGetParam(this Element element, BuiltInParameter builtInParameter, out Parameter param) {
            param = element.get_Parameter(builtInParameter);
            return param != null;
        }

#if REVIT2022_OR_GREATER

        /// <summary>
        /// Пытается найти параметр проекта у элемента по <see cref="Autodesk.Revit.DB.ForgeTypeId"/>.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Значение <see cref="Autodesk.Revit.DB.ForgeTypeId"/> параметра.</param>
        /// <param name="param">Параметр, если он найден.</param>
        /// <returns>True, если параметр найден и не равен null, иначе False.</returns>
        private static bool TryGetParam(this Element element, ForgeTypeId forgeTypeId, out Parameter param) {
            param = element.GetParameter(forgeTypeId);
            return param != null;
        }

#endif
    }
}
