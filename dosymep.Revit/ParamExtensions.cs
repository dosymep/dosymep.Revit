using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса параметров.
    /// </summary>
    public static class ParamExtensions {
        /// <summary>
        /// Возвращает значение параметра.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает значение параметра.</returns>
        public static object AsObject(this Parameter parameter) {
            if(parameter is null) {
                throw new ArgumentNullException(nameof(parameter));
            }

            if(parameter.HasValue) {
                var storageType = parameter.StorageType;
                switch(storageType) {
                    case StorageType.Integer:
                    return parameter.AsInteger();
                    case StorageType.Double:
                    return parameter.AsDouble();
                    case StorageType.String: {
                        var value = parameter.AsString();
                        return string.IsNullOrWhiteSpace(value) ? null : value;
                    }

                    case StorageType.ElementId:
                    return parameter.AsElementId();
                }
            }

            return null;
        }

        /// <summary>
        /// Присваивает значение параметра по значению другого параметра.
        /// </summary>
        /// <param name="leftParameter">Параметр в который присваивается значение.</param>
        /// <param name="rightarameter">Параметр значение которого присваивается.</param>
        public static void Set(this Parameter leftParameter, Parameter rightarameter) {
            if(leftParameter is null) {
                throw new ArgumentNullException(nameof(leftParameter));
            }

            if(rightarameter is null) {
                throw new ArgumentNullException(nameof(rightarameter));
            }

            if(leftParameter.StorageType != StorageType.String && leftParameter.StorageType != rightarameter.StorageType) {
                throw new ArgumentException("У переданного параметра не соответствует тип данных.", nameof(rightarameter));
            }

            var storageType = rightarameter.StorageType;
            switch(storageType) {
                case StorageType.Integer:
                leftParameter.Set(rightarameter.AsInteger());
                break;
                case StorageType.Double:
                leftParameter.Set(rightarameter.AsDouble());
                break;
                case StorageType.String:
                leftParameter.Set(rightarameter.AsObject()?.ToString());
                break;
                case StorageType.ElementId:
                leftParameter.Set(rightarameter.AsElementId());
                break;
                default:
                leftParameter.Set((string) null);
                break;
            }
        }
    }
}
