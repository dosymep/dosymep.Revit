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
            if(parameter.HasValue) {
                var storageType = parameter.StorageType;
                if(storageType == StorageType.Integer)
                    return parameter.AsInteger();
                else if(storageType == StorageType.Double)
                    return parameter.AsDouble();
                else if(storageType == StorageType.String)
                    return parameter.AsString();
                else if(storageType == StorageType.ElementId)
                    return parameter.AsElementId();
            }

            return null;
        }
    }
}
