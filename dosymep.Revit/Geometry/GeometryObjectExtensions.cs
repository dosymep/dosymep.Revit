using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Geometry {
    /// <summary>
    /// Расширения <see cref="GeometryObject"/>
    /// </summary>
    public static class GeometryObjectExtensions {
        /// <summary>
        /// Возвращает перечисление объектов <see cref="Solid"/>.
        /// </summary>
        /// <param name="geometryObject">Объект у которого запрашиваются объекты <see cref="Solid"/>.</param>
        /// <returns>Возвращает перечисление объектов <see cref="Solid"/>.</returns>
        public static IEnumerable<Solid> GetSolids(this GeometryObject geometryObject) {
            if(geometryObject == null) {
                throw new ArgumentNullException(nameof(geometryObject));
            }

            if(geometryObject is Solid solid) {
                yield return solid;
            } else if(geometryObject is GeometryInstance geometryInstance) {
                foreach(Solid instance in geometryInstance.GetSolids()) {
                    yield return instance;
                }
            }
        }

        /// <summary>
        ///  Возвращает перечисление объектов <see cref="Solid"/>.
        /// </summary>
        /// <param name="geometryInstance">Объект у которого запрашиваются объекты <see cref="Solid"/>.</param>
        /// <returns> Возвращает перечисление объектов <see cref="Solid"/>.</returns>
        public static IEnumerable<Solid> GetSolids(this GeometryInstance geometryInstance) {
            if(geometryInstance == null) {
                throw new ArgumentNullException(nameof(geometryInstance));
            }

            return geometryInstance.GetInstanceGeometry()
                .SelectMany(item => item.GetSolids());
        }
    }
}