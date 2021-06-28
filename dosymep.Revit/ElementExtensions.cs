using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SharedParams;

namespace dosymep.Revit {
    public static class ElementExtensions {
        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="sharedParam">Общий параметр.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static object GetParamValueOrDefault(this Element element, SharedParam sharedParam, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(sharedParam is null) {
                throw new ArgumentNullException(nameof(sharedParam));
            }

            try {
                return element.GetParamValue(sharedParam);
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="sharedParam">Общий параметр.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static object GetParamValue(this Element element, SharedParam sharedParam) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(sharedParam is null) {
                throw new ArgumentNullException(nameof(sharedParam));
            }

            Parameter param = element.GetParam(sharedParam);
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
        /// <param name="sharedParam">Общий параметр.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, SharedParam sharedParam, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(sharedParam is null) {
                throw new ArgumentNullException(nameof(sharedParam));
            }

            element.GetParam(sharedParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="sharedParam">Общий параметр.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, SharedParam sharedParam, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(sharedParam is null) {
                throw new ArgumentNullException(nameof(sharedParam));
            }

            element.GetParam(sharedParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="sharedParam">Общий параметр.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, SharedParam sharedParam, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(sharedParam is null) {
                throw new ArgumentNullException(nameof(sharedParam));
            }

            element.GetParam(sharedParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="sharedParam">Общий параметр.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, SharedParam sharedParam, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(sharedParam is null) {
                throw new ArgumentNullException(nameof(sharedParam));
            }

            element.GetParam(sharedParam).Set(paramValue);
        }

        private static Parameter GetParam(this Element element, SharedParam sharedParam) {
            var param = element.LookupParameter(sharedParam.Name);
            if(param is null) {
                throw new ArgumentException($"Общего параметра с заданным именем \"{sharedParam.Name}\" не существует.", nameof(sharedParam));
            }

            if(!param.HasValue) {
                throw new ArgumentException($"Общего параметра с заданным именем \"{sharedParam.Name}\" не существует.", nameof(sharedParam));
            }

            if(!param.IsShared) {
                throw new ArgumentException($"Параметр с заданным именем \"{sharedParam.Name}\" не является общим.", nameof(sharedParam));
            }

            if(param.StorageType != sharedParam.SharedParamType) {
                throw new ArgumentException($"Переданный общий параметр \"{sharedParam.Name}\" не соответствует типу параметра у элемента.", nameof(sharedParam));
            }

            return param;
        }
    }
}
