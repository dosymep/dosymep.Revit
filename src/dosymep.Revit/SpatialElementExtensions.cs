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
            IList<IList<BoundarySegment>> boundarySegments =
                spatialElement.GetBoundarySegments(options ?? DefaultBoundaryOptions);

            BoundarySegment[] segments = boundarySegments
                .SelectMany(item => item)
                .ToArray();

            for(int indexLeft = 0; indexLeft < segments.Length; indexLeft++) {
                Curve leftCurve = segments[indexLeft].GetCurve();

                for(int indexRight = 1; indexRight < segments.Length; indexRight++) {
                    if(indexLeft - indexRight >= 0) {
                        // pass duplicates: 1-3 and 3-1
                        continue;
                    }

                    // true for connected segments (they overlapped)
                    // but needs check they can be inside each other 
                    // others overlapped and cross
                    bool result = indexRight - indexLeft == 1
                                  || (indexRight - indexLeft) == (segments.Length - 1);
                    
                    Curve rightCurve = segments[indexRight].GetCurve();
                    SetComparisonResult intersect = leftCurve.Intersect(rightCurve);
                    
                    if(result) {
                        if(intersect == SetComparisonResult.Equal
                           || intersect == SetComparisonResult.Subset
                           || intersect == SetComparisonResult.Superset) {
                            return true;
                        }
                    } else {
                        if(intersect == SetComparisonResult.Overlap) {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Проверяет является элемент избыточным.
        /// </summary>
        /// <param name="spatialElement">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является избыточным, иначе false.</returns>
        internal static bool IsRedundant(this SpatialElement spatialElement,
            SpatialElementBoundaryOptions options = default) {
            double roomArea = spatialElement.GetParamValueOrDefault<double>(BuiltInParameter.ROOM_AREA);
            return roomArea == 0 && spatialElement.GetBoundarySegments(options ?? DefaultBoundaryOptions).Count > 0;
        }

        /// <summary>
        /// Проверяет является элемент не избыточным.
        /// </summary>
        /// <param name="spatialElement">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является не избыточным, иначе false.</returns>
        internal static bool IsNotRedundant(this SpatialElement spatialElement,
            SpatialElementBoundaryOptions options = default) {
            return !spatialElement.IsRedundant(options);
        }

        /// <summary>
        /// Проверяет является элемент замкнутым.
        /// </summary>
        /// <param name="spatialElement">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является замкнутым, иначе false.</returns>
        internal static bool IsEnclosed(this SpatialElement spatialElement,
            SpatialElementBoundaryOptions options = default) {
            double roomArea = spatialElement.GetParamValueOrDefault<double>(BuiltInParameter.ROOM_AREA);
            return roomArea > 0 && spatialElement.GetBoundarySegments(options ?? DefaultBoundaryOptions).Count > 0;
        }

        /// <summary>
        /// Проверяет является элемент не замкнутым.
        /// </summary>
        /// <param name="spatialElement">Проверяемый элемент.</param>
        /// <param name="options">Опции получение границ элемента.</param>
        /// <returns>Возвращает true если элемент является не замкнутым, иначе false.</returns>
        internal static bool IsNotEnclosed(this SpatialElement spatialElement,
            SpatialElementBoundaryOptions options = default) {
            return !spatialElement.IsEnclosed(options);
        }
    }
}