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
    }
}
