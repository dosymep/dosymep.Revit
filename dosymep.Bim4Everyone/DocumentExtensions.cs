using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Revit;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс расширения документа.
    /// </summary>
    public static class DocumentExtensions {
        /// <summary>
        /// Проверяет на существование параметра проекта.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="revitParam">Параметр проекта.</param>
        /// <returns></returns>
        public static bool IsExistsParam(this Document document, ProjectParam revitParam) {
            return document.IsExistsProjectParam(revitParam.Name);
        }

        /// <summary>
        /// Проверяет на существование общего параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="revitParam">Параметр проекта.</param>
        /// <returns></returns>
        public static bool IsExistsParam(this Document document, SharedParam revitParam) {
            return document.IsExistsSharedParam(revitParam.Name);
        }
    }
}
