﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

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
            return element.GetParamValueOrDefault(paramName) != default;
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
        /// <param name="paramValue">Значение общего параметра.</param>
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
        /// <param name="paramValue">Значение общего параметра.</param>
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
        /// <param name="paramValue">Значение общего параметра.</param>
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
        /// <param name="paramValue">Значение общего параметра.</param>
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

            var param = element.LookupParameter(paramName);
            if(param is null) {
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
            return element.GetParamValueOrDefault(builtInParameter) != default;
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
        /// <param name="paramValue">Значение общего параметра.</param>
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
        /// <param name="paramValue">Значение общего параметра.</param>
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
        /// <param name="paramValue">Значение общего параметра.</param>
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
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, BuiltInParameter builtInParameter, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            element.GetParam(builtInParameter).Set(paramValue);
        }

        /// <summary>
        /// Удаляет параметр по его имени.
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

            var param = element.get_Parameter(builtInParameter);
            if(param is null) {
                throw new ArgumentException($"Параметра с заданным именем \"{builtInParameter}\" у элемента не существует.", nameof(builtInParameter));
            }

            return param;
        }

        #endregion

#if D2022 || R2022

        #region Получение параметра по ForgeTypeId

        /// <summary>
        /// Проверяет на существование параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="forgeTypeId">Встроенный тип параметра.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Element element, ForgeTypeId forgeTypeId) {
            return element.GetParamValueOrDefault(forgeTypeId) != default;
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

            var param = element.GetParameter(forgeTypeId);
            if(param is null) {
                throw new ArgumentException($"Параметра с заданным именем \"{forgeTypeId}\" у элемента не существует.", nameof(forgeTypeId));
            }

            return param;
        }

        /// <summary>
        /// Удаляет параметр по его имени.
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
    }
}
