using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Geometry {
    /// <summary>
    /// Расширения для <see cref="Solid"/>
    /// </summary>
    public static class SolidExtensions {
        /// <summary>
        /// Возвращает новый <see cref="BoundingBoxXYZ"/> с примененной трансформацией.
        /// </summary>
        /// <param name="solid"><see cref="Solid"/> у которого берется <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает новый <see cref="BoundingBoxXYZ"/> с примененной трансформацией.</returns>
        public static BoundingBoxXYZ GetTransformedBoundingBox(this Solid solid) {
            BoundingBoxXYZ bb = solid.GetBoundingBox();
            return bb.TransformBoundingBox(bb.Transform);
        }

        /// <summary>
        /// Объединяет коллекцию <see cref="Solid"/>.
        /// </summary>
        /// <param name="solids">Коллекция <see cref="Solid"/>.</param>
        /// <returns>Возвращает максимально возможные объединения <see cref="Solid"/>.</returns>
        public static IList<Solid> CreateUnitedSolids(IList<Solid> solids) {
            Solid union = solids[0];
            var result = new List<Solid>();
            for(int index = 1; index < solids.Count; index++) {
                Solid solid = solids[index];
                try {
                    union = BooleanOperationsUtils.ExecuteBooleanOperation(union, solid, BooleanOperationsType.Union);
                } catch {
                    result.Add(union);
                    union = solid;
                }
            }

            result.Add(union);
            return result;
        }
    }
}