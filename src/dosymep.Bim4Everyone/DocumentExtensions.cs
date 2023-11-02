using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SystemParams;
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
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Document document, RevitParam revitParam) {
            return revitParam.IsExistsParam(document);
        }

        /// <summary>
        /// Проверяет на существование параметра проекта.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="revitParam">Параметр проекта.</param>
        /// <returns>Возвращает true - если параметр проекта существует, иначе false.</returns>
        public static bool IsExistsParam(this Document document, ProjectParam revitParam) {
            return revitParam.IsExistsParam(document);
        }

        /// <summary>
        /// Проверяет на существование общего параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="revitParam">Параметр проекта.</param>
        /// <returns>Возвращает true - если общий параметр существует, иначе false.</returns>
        public static bool IsExistsParam(this Document document, SharedParam revitParam) {
            return revitParam.IsExistsParam(document);
        }
    }
}
