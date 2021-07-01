using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    public static class ElementExtensions {
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
                return element.GetParamValue(paramName);
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

            Parameter param = element.GetParam(paramName);
            if(param.StorageType == StorageType.Double) {
                return param.AsDouble();
            }

            if(param.StorageType == StorageType.Integer) {
                return param.AsInteger();
            }

            if(param.StorageType == StorageType.String) {
                return param.AsString();
            }

            if(param.StorageType == StorageType.ElementId) {
                return param.AsElementId();
            }

            return null;
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
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="paramName">Наименование параметра.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, string paramName) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            var param = element.LookupParameter(paramName);
            if(param is null) {
                throw new ArgumentException($"Общего параметра с заданным именем \"{paramName}\" не существует.", nameof(paramName));
            }

            if(!param.HasValue) {
                throw new ArgumentException($"Общего параметра с заданным именем \"{paramName}\" не существует.", nameof(paramName));
            }

            return param;
        }
    }
}
