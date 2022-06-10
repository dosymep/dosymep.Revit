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
        /// <summary>
        /// Проверяет на существование параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Element element, RevitParam revitParam) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam == null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            try {
                element.GetParam(revitParam);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на существование значения параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает true - если значение параметра существует, иначе false.</returns>
        public static bool IsExistsParamValue(this Element element, RevitParam revitParam) {
            if(element == null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam == null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            return element.GetParamValueOrDefault(revitParam) != default;
        }
        
        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Встроенный тип параметра.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static T GetParamValueOrDefault<T>(this Element element, RevitParam revitParam, T @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam == null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            try {
                object value = element.GetParamValue(revitParam);
                return value == null ? @default : (T) value;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра либо значение по умолчанию.</returns>
        public static object GetParamValueOrDefault(this Element element, RevitParam revitParam, object @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            try {
                return element.GetParamValue(revitParam) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }

        /// <summary>
        /// Возвращает значение параметра с единицей измерения либо значение по умолчанию.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="default">Значение по умолчанию.</param>
        /// <returns>Возвращает значение параметра с единицей измерения либо значение по умолчанию.</returns>
        public static string GetParamValueStringOrDefault(this Element element, RevitParam revitParam, string @default = default) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            try {
                return element.GetParamValueString(revitParam) ?? @default;
            } catch(ArgumentException) {
                return @default;
            }
        }
        
        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static T GetParamValue<T>(this Element element, RevitParam revitParam) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam == null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            object value = element.GetParam(revitParam).AsObject();
            return value == null ? default : (T) value;
        }

        /// <summary>
        /// Возвращает значение параметра элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает значение параметра элемента.</returns>
        public static object GetParamValue(this Element element, RevitParam revitParam) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            return element.GetParam(revitParam).AsObject();
        }

        /// <summary>
        /// Возвращает значение параметра элемента c единицами измерения.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает значение параметра элемента c единицами измерения.</returns>
        public static string GetParamValueString(this Element element, RevitParam revitParam) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            return element.GetParam(revitParam).AsValueString();
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="paramValue">Значение параметра Revit.</param>
        public static void SetParamValue(this Element element, RevitParam revitParam, double paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            element.GetParam(revitParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="paramValue">Значение параметра Revit.</param>
        public static void SetParamValue(this Element element, RevitParam revitParam, int paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            element.GetParam(revitParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="paramValue">Значение параметра Revit.</param>
        public static void SetParamValue(this Element element, RevitParam revitParam, string paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            element.GetParam(revitParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <param name="paramValue">Значение параметра Revit.</param>
        public static void SetParamValue(this Element element, RevitParam revitParam, ElementId paramValue) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            element.GetParam(revitParam).Set(paramValue);
        }

        /// <summary>
        /// Устанавливает значение параметра по значению другого параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр в который присваивается значение.</param>
        /// <param name="otherElement">Элемент значение параметра которого присваивается.</param>
        public static void SetParamValue(this Element element, RevitParam revitParam, Element otherElement) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentException($"'{nameof(revitParam)}' cannot be null or empty.", nameof(revitParam));
            }

            if(otherElement is null) {
                throw new ArgumentException($"'{nameof(otherElement)}' cannot be null or empty.", nameof(otherElement));
            }

            element.SetParamValue(revitParam, otherElement.GetParam(revitParam));
        }

        /// <summary>
        /// Устанавливает значение параметра по значению другого параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр в который присваивается значение.</param>
        /// <param name="otherParameter">Параметр значение которого присваивается.</param>
        public static void SetParamValue(this Element element, RevitParam revitParam, Parameter otherParameter) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(revitParam is null) {
                throw new ArgumentException($"'{nameof(revitParam)}' cannot be null or empty.", nameof(revitParam));
            }

            if(otherParameter is null) {
                throw new ArgumentException($"'{nameof(otherParameter)}' cannot be null or empty.", nameof(otherParameter));
            }

            element.GetParam(revitParam).Set(otherParameter);
        }

        /// <summary>
        /// Устанавливает значение параметра по значению другого параметра.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="leftRevitParam">Параметр в который присваивается значение.</param>
        /// <param name="rightRevitParam">Параметр значение которого присваивается.</param>
        public static void SetParamValue(this Element element, RevitParam leftRevitParam, RevitParam rightRevitParam) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            if(leftRevitParam is null) {
                throw new ArgumentException($"'{nameof(leftRevitParam)}' cannot be null or empty.", nameof(leftRevitParam));
            }

            if(rightRevitParam is null) {
                throw new ArgumentException($"'{nameof(rightRevitParam)}' cannot be null or empty.", nameof(rightRevitParam));
            }

            element.GetParam(leftRevitParam).Set(element.GetParam(rightRevitParam));
        }

        /// <summary>
        /// Удаляет параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает признак удаления параметра true - если был удален, иначе false.</returns>
        public static bool RemoveParamValue(this Element element, RevitParam revitParam) {
            try {
                element.GetParam(revitParam).RemoveValue();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает параметр.</returns>
        public static Parameter GetParam(this Element element, RevitParam revitParam) {
            return revitParam.GetParam(element);
        }
    }
}
