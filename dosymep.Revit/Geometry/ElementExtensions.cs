using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;

namespace dosymep.Revit.Geometry {
    /// <summary>
    /// Расширения <see cref="Autodesk.Revit.DB.Element"/>
    /// </summary>
    public static class ElementExtensions {
        private static readonly Options _options = new Options() {
            ComputeReferences = true, 
            IncludeNonVisibleObjects = false, DetailLevel = ViewDetailLevel.Fine
        };
        
        /// <summary>
        /// Возвращает все <see cref="Solid"/> объекты из <see cref="Autodesk.Revit.DB.Element"/>.
        /// </summary>
        /// <param name="element">Элемент у которого берутся <see cref="Solid"/>.</param>
        /// <returns>Возвращает все <see cref="Solid"/> объекты из <see cref="Autodesk.Revit.DB.Element"/>.</returns>
        public static IEnumerable<Solid> GetSolids(this Element element) {
            return element.get_Geometry(_options)
                .SelectMany(item => item.GetSolids())
                .ToList();
        } 
    }
}