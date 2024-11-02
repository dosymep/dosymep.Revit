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
            IncludeNonVisibleObjects = false,
            DetailLevel = ViewDetailLevel.Fine
        };

        /// <summary>
        /// Возвращает все <see cref="Solid"/> объекты из <see cref="Autodesk.Revit.DB.Element"/> с <see cref="Autodesk.Revit.DB.Options"/> по умолчанию<br/>
        /// в координатах документа этого элемента относительно начала проекта.<br/>
        /// Настройки <see cref="Autodesk.Revit.DB.Options"/> по умолчанию:<br/>
        /// <code>
        /// ComputeReferences = true
        /// IncludeNonVisibleObjects = false
        /// DetailLevel = ViewDetailLevel.Fine.
        /// </code>
        /// </summary>
        /// <param name="element">Элемент у которого берутся <see cref="Solid"/>.</param>
        /// <returns>Возвращает все <see cref="Solid"/> объекты из <see cref="Autodesk.Revit.DB.Element"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если один из обязательных параметров null.</exception>
        public static IEnumerable<Solid> GetSolids(this Element element) {
            if(element is null) {
                throw new System.ArgumentNullException(nameof(element));
            }

            return element.GetSolids(_options);
        }

        /// <summary>
        /// Возвращает все <see cref="Solid"/> объекты из <see cref="Autodesk.Revit.DB.Element"/> с заданными <see cref="Autodesk.Revit.DB.Options"/><br/>
        /// в координатах документа этого элемента относительно начала проекта.
        /// </summary>
        /// <param name="element">Элемент у которого берутся <see cref="Solid"/>.</param>
        /// <param name="options">Настройки получения <see cref="Solid"/> из <see cref="Autodesk.Revit.DB.Element"/>.</param>
        /// <returns>Возвращает все <see cref="Solid"/> объекты из <see cref="Autodesk.Revit.DB.Element"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Исключение, если один из обязательных параметров null.</exception>
        public static IEnumerable<Solid> GetSolids(this Element element, Options options) {
            if(element is null) {
                throw new System.ArgumentNullException(nameof(element));
            }

            if(options is null) {
                throw new System.ArgumentNullException(nameof(options));
            }

            return element.get_Geometry(options)
                ?.SelectMany(item => item.GetSolids())
                .ToList() ?? Enumerable.Empty<Solid>();
        }
    }
}
