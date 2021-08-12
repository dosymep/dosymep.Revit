using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Revit;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс расширения элемента
    /// </summary>
    public static class ElementExtensions {
        #region SharedParam

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
                throw new ArgumentException($"Переданный Параметр проекта \"{sharedParam.Name}\" не соответствует типу параметра у элемента.", nameof(sharedParam));
            }

            return param;
        }

        #endregion

        #region ProjectParam

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static object GetParamValueOrDefault(this Element element, ProjectParam projectParam, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(projectParam is null) {
                throw new ArgumentNullException(nameof(projectParam));
            }

            return element.GetParamValueOrDefault(projectParam.Name, @default);
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static object GetParamValue(this Element element, ProjectParam projectParam) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(projectParam is null) {
                throw new ArgumentNullException(nameof(projectParam));
            }

            return element.GetParamValue(projectParam.Name);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ProjectParam projectParam, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(projectParam is null) {
                throw new ArgumentNullException(nameof(projectParam));
            }

            element.SetParamValue(projectParam.Name, paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ProjectParam projectParam, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(projectParam is null) {
                throw new ArgumentNullException(nameof(projectParam));
            }

            element.SetParamValue(projectParam.Name, paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ProjectParam projectParam, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(projectParam is null) {
                throw new ArgumentNullException(nameof(projectParam));
            }

            element.SetParamValue(projectParam.Name, paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <param name="paramValue">Значение общего параметра.</param>
        public static void SetParamValue(this Element element, ProjectParam projectParam, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(projectParam is null) {
                throw new ArgumentNullException(nameof(projectParam));
            }

            element.SetParamValue(projectParam.Name, paramValue);
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="projectParam">Параметр проекта.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, ProjectParam projectParam) {
            var param = element.GetParam(projectParam.Name);
            if(param.IsShared) {
                throw new ArgumentException($"Параметр с заданным именем \"{projectParam.Name}\" не является параметром проекта.", nameof(projectParam));
            }

            if(param.StorageType != projectParam.SharedParamType) {
                throw new ArgumentException($"Переданный Параметр проекта \"{projectParam.Name}\" не соответствует типу параметра у элемента.", nameof(projectParam));
            }

            return param;
        }

        #endregion
    }
}
