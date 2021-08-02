using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SharedParams;
using dosymep.Revit;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс расширения элемента
    /// </summary>
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

            return element.GetParamValueOrDefault(sharedParam.Name, @default);
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

            return element.GetParamValue(sharedParam.Name);
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

            element.SetParamValue(sharedParam.Name, paramValue);
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

            element.SetParamValue(sharedParam.Name, paramValue);
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

            element.SetParamValue(sharedParam.Name, paramValue);
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

            element.SetParamValue(sharedParam.Name, paramValue);
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="sharedParam">Общий параметр.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, SharedParam sharedParam) {
            var param = element.GetParam(sharedParam.Name);
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
