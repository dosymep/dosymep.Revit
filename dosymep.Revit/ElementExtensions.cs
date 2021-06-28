using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SharedParams;

namespace dosymep.Revit {
    public static class ElementExtensions {
        public static object GetParamValueOrDefault(this Element element, SharedParam sharedParam, object @default = default) {
            try {
                return element.GetParamValue(sharedParam);
            } catch(ArgumentException) {
                return @default;
            }
        }

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

        public static void SetParamValue(this Element element, SharedParam sharedParam, double paramValue) {
            element.GetParam(sharedParam).Set(paramValue);
        }

        public static void SetParamValue(this Element element, SharedParam sharedParam, int paramValue) {
            element.GetParam(sharedParam).Set(paramValue);
        }

        public static void SetParamValue(this Element element, SharedParam sharedParam, string paramValue) {
            element.GetParam(sharedParam).Set(paramValue);
        }

        public static void SetParamValue(this Element element, SharedParam sharedParam, ElementId paramValue) {
            element.GetParam(sharedParam).Set(paramValue);
        }

        private static Parameter GetParam(this Element element, SharedParam sharedParam) {
            var param = element.LookupParameter(sharedParam.Name);
            if(param is null) {
                throw new ArgumentException("Не был найден параметр.");
            }

            if(!param.HasValue) {
                throw new ArgumentException("Не был найден параметр.");
            }

            if(param.StorageType != sharedParam.SharedParamType) {
                throw new ArgumentException("Не соответствует тип.");
            }

            return param;
        }
    }
}
