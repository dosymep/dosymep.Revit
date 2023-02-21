using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса <see cref="SpatialElement"/>.
    /// </summary>
    public static class SpatialElementExtensions {
        /// <summary>
        /// Опции получения границ размещаемых элементов по умолчанию.
        /// </summary>
        public static readonly SpatialElementBoundaryOptions DefaultBoundaryOptions
            = new SpatialElementBoundaryOptions();

        /// <summary>
        /// Находит самопересечения у границ размещаемых элементов.
        /// </summary>
        /// <param name="spatialElement">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если были найдены самопересечения, иначе false.</returns>
        public static bool IsSelfCrossBoundaries(this SpatialElement spatialElement,
            SpatialElementBoundaryOptions options = default) {
            var boundarySegments = spatialElement.GetBoundarySegments(options ?? DefaultBoundaryOptions);
            foreach(IList<BoundarySegment> segments in boundarySegments) {
                var enumSegments = segments.Zip(segments.Skip(2),
                    (leftSegment, rightSegment) => (leftSegment, rightSegment));

            foreach((BoundarySegment leftSegment, BoundarySegment rightSegment) in enumSegments) {
                Curve leftCurve = leftSegment.GetCurve();
                Curve rightCurve = rightSegment.GetCurve();

                SetComparisonResult intersect = leftCurve.Intersect(rightCurve,
                    out IntersectionResultArray _);

                if(intersect == SetComparisonResult.Overlap) {
                    return true;
                }
            }

            return false;
        }
    }
}
