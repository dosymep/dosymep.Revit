using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Geometry {
    /// <summary>
    /// Расширения для <see cref="BoundingBoxXYZ"/>
    /// </summary>
    public static class BoundingBoxExtensions {
        /// <summary>
        /// Возвращает <see cref="Solid"/> по <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bb"><see cref="BoundingBoxXYZ"/> по которому создается <see cref="Solid"/>.</param>
        /// <returns>Возвращает <see cref="Solid"/> по <see cref="BoundingBoxXYZ"/>.</returns>
        public static Solid CreateSolid(this BoundingBoxXYZ bb) {
            // Честно стырил с форума autodesk
            // https://forums.autodesk.com/t5/revit-api-forum/create-solid-from-boundingbox/td-p/6330376

            XYZ pt0 = new XYZ(bb.Min.X, bb.Min.Y, bb.Min.Z);
            XYZ pt1 = new XYZ(bb.Max.X, bb.Min.Y, bb.Min.Z);
            XYZ pt2 = new XYZ(bb.Max.X, bb.Max.Y, bb.Min.Z);
            XYZ pt3 = new XYZ(bb.Min.X, bb.Max.Y, bb.Min.Z);

            Line edge0 = Line.CreateBound(pt0, pt1);
            Line edge1 = Line.CreateBound(pt1, pt2);
            Line edge2 = Line.CreateBound(pt2, pt3);
            Line edge3 = Line.CreateBound(pt3, pt0);

            var edges = new List<Curve>() {edge0, edge1, edge2, edge3};
            var loopList = new List<CurveLoop>() {CurveLoop.Create(edges)};

            double height = bb.Max.Z - bb.Min.Z;
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loopList, XYZ.BasisZ, height);
            return SolidUtils.CreateTransformed(solid, bb.Transform);
        }

        /// <summary>
        /// Создает увеличенный <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bb"></param>
        /// <param name="offset">Расстояние увеличения, во внутренних координатах.</param>
        /// <returns>Создает увеличенный <see cref="BoundingBoxXYZ"/>.</returns>
        public static BoundingBoxXYZ IncreaseBoundingBox(this BoundingBoxXYZ bb, double offset = 5) {
            var offsetVec = new XYZ(offset, offset, offset);
            return new BoundingBoxXYZ() {Min = bb.Min + offsetVec, Max = bb.Max + offsetVec,};
        }

        /// <summary>
        /// Возвращает новый <see cref="BoundingBoxXYZ"/> с примененной трансформацией.
        /// </summary>
        /// <param name="bb"><see cref="BoundingBoxXYZ"/>, который трансформируют.</param>
        /// <param name="transform">Применяемый <see cref="Transform"/>.</param>
        /// <returns>Возвращает новый <see cref="BoundingBoxXYZ"/> с примененной трансформацией.</returns>
        public static BoundingBoxXYZ TransformBoundingBox(this BoundingBoxXYZ bb, Transform transform) {
            if(bb == null) {
                throw new ArgumentNullException(nameof(bb));
            }

            if(transform == null) {
                throw new ArgumentNullException(nameof(transform));
            }

            if(transform == Transform.Identity) {
                return bb;
            }

            XYZ pt0 = new XYZ(bb.Min.X, bb.Min.Y, bb.Min.Z);
            XYZ pt1 = new XYZ(bb.Max.X, bb.Min.Y, bb.Min.Z);
            XYZ pt2 = new XYZ(bb.Max.X, bb.Max.Y, bb.Min.Z);
            XYZ pt3 = new XYZ(bb.Min.X, bb.Max.Y, bb.Min.Z);

            var tpt0 = transform.OfPoint(pt0);
            var tpt1 = transform.OfPoint(pt1);
            var tpt2 = transform.OfPoint(pt2);
            var tpt3 = transform.OfPoint(pt3);

            var tMax = transform.OfPoint(bb.Max);
            var points = new[] {tpt0, tpt1, tpt2, tpt3};

            var min = new XYZ(points.Min(p => p.X), points.Min(p => p.Y), points.Min(p => p.Z));
            var max = new XYZ(points.Max(p => p.X), points.Max(p => p.Y), tMax.Z);

            return new BoundingBoxXYZ() {Min = min, Max = max};
        }

        /// <summary>
        /// Проверяет на пересечение двух <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bb1">Первый <see cref="BoundingBoxXYZ"/>.</param>
        /// <param name="bb2">Второй <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает true - если первый <see cref="BoundingBoxXYZ"/> пересекается со вторым, иначе false.</returns>
        public static bool IsIntersected(this BoundingBoxXYZ bb1, BoundingBoxXYZ bb2) {
            if(bb1 == null) {
                throw new ArgumentNullException(nameof(bb1));
            }

            if(bb2 == null) {
                throw new ArgumentNullException(nameof(bb2));
            }

            return !((bb1.Min.X > bb2.Max.X && bb1.Min.Y > bb2.Max.Y)
                     || (bb1.Min.Z > bb2.Max.Z && bb1.Min.X > bb2.Max.X)
                     || (bb1.Min.Z > bb2.Max.Z && bb1.Min.Y > bb2.Max.Y)
                     || (bb1.Max.X < bb2.Min.X && bb1.Max.Y < bb2.Min.Y)
                     || (bb1.Max.Z < bb2.Min.Z && bb1.Max.X < bb2.Min.X)
                     || (bb1.Max.Z < bb2.Min.Z && bb1.Max.Y < bb2.Min.Y));
        }

        /// <summary>
        /// Проверяет пересечение всех <see cref="BoundingBoxXYZ"/> между собой.
        /// </summary>
        /// <param name="bbs">Коллекция <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает true - если все <see cref="BoundingBoxXYZ"/> пересекаются, иначе false.</returns>
        public static bool IsIntersected(this IList<BoundingBoxXYZ> bbs) {
            if(bbs == null) {
                throw new ArgumentNullException(nameof(bbs));
            }

            BoundingBoxXYZ current = bbs[0];
            for(int i = 1; i < bbs.Count; i++) {
                if(!current.IsIntersected(bbs[i])) {
                    return false;
                }

                current = current.CreateIntersectedBoundingBox(bbs[i]);
            }

            return true;
        }

        /// <summary>
        /// Возвращает общий <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bbs">Коллекция <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает общий <see cref="BoundingBoxXYZ"/>.</returns>
        /// <remarks>Возвращает общий <see cref="BoundingBoxXYZ"/>,
        /// если у всех <see cref="BoundingBoxXYZ"/>
        /// есть общий <see cref="BoundingBoxXYZ"/>,
        /// иначе возвращает объединенный.</remarks>
        public static BoundingBoxXYZ CreateCommonBoundingBox(this IList<BoundingBoxXYZ> bbs) {
            if(bbs == null) {
                throw new ArgumentNullException(nameof(bbs));
            }

            if(bbs.IsIntersected()) {
                return bbs.CreateIntersectedBoundingBox();
            }

            return bbs.CreateUnitedBoundingBox();
        }

        /// <summary>
        /// Возвращает <see cref="BoundingBoxXYZ"/> пересечения между двумя <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bb1">Первый <see cref="BoundingBoxXYZ"/>.</param>
        /// <param name="bb2">Второй <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает <see cref="BoundingBoxXYZ"/> пересечения между двумя <see cref="BoundingBoxXYZ"/>.</returns>
        public static BoundingBoxXYZ CreateIntersectedBoundingBox(this BoundingBoxXYZ bb1, BoundingBoxXYZ bb2) {
            if(bb1 == null) {
                throw new ArgumentNullException(nameof(bb1));
            }

            if(bb2 == null) {
                throw new ArgumentNullException(nameof(bb2));
            }

            return new[] {bb1, bb2}.CreateIntersectedBoundingBox();
        }

        /// <summary>
        /// Возвращает общий <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bbs">Коллекция <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает общий <see cref="BoundingBoxXYZ"/>.</returns>
        public static BoundingBoxXYZ CreateIntersectedBoundingBox(this ICollection<BoundingBoxXYZ> bbs) {
            if(bbs == null) {
                throw new ArgumentNullException(nameof(bbs));
            }

            if(bbs.Count == 0) {
                return new BoundingBoxXYZ();
            }

            return new BoundingBoxXYZ() {Min = bbs.GetMaxPoint(), Max = bbs.GetMinPoint(),};
        }

        /// <summary>
        /// Возвращает объединенный <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bbs">Коллекция <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает объединенный <see cref="BoundingBoxXYZ"/>.</returns>
        public static BoundingBoxXYZ CreateUnitedBoundingBox(this ICollection<BoundingBoxXYZ> bbs) {
            if(bbs == null) {
                throw new ArgumentNullException(nameof(bbs));
            }

            if(bbs.Count == 0) {
                return new BoundingBoxXYZ();
            }

            return new BoundingBoxXYZ() {Min = bbs.GetMinPoint(), Max = bbs.GetMaxPoint(),};
        }

        /// <summary>
        /// Возвращает максимальную точку по всем <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bbs">Коллекция <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает максимальную точку по всем <see cref="BoundingBoxXYZ"/>.</returns>
        public static XYZ GetMaxPoint(this ICollection<BoundingBoxXYZ> bbs) {
            if(bbs == null) {
                throw new ArgumentNullException(nameof(bbs));
            }

            return new XYZ(bbs.Max(item => item.Max.X),
                bbs.Max(item => item.Max.Y),
                bbs.Max(item => item.Max.Z));
        }

        /// <summary>
        /// Возвращает минимальную точку по всем <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bbs">Коллекция <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает минимальную точку по всем <see cref="BoundingBoxXYZ"/>.</returns>
        public static XYZ GetMinPoint(this ICollection<BoundingBoxXYZ> bbs) {
            if(bbs == null) {
                throw new ArgumentNullException(nameof(bbs));
            }

            return new XYZ(bbs.Min(item => item.Min.X),
                bbs.Min(item => item.Min.Y),
                bbs.Min(item => item.Min.Z));
        }

        /// <summary>
        /// Возвращает центральную точку <see cref="BoundingBoxXYZ"/>.
        /// </summary>
        /// <param name="bb">Экземпляр <see cref="BoundingBoxXYZ"/>.</param>
        /// <returns>Возвращает центральную точку <see cref="BoundingBoxXYZ"/>.</returns>
        public static XYZ GetMidPoint(this BoundingBoxXYZ bb) {
            if(bb == null) {
                throw new ArgumentNullException(nameof(bb));
            }

            return bb.Min + (bb.Max - bb.Min) / 2;
        }
    }
}