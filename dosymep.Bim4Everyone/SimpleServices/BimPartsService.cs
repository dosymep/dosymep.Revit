using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class BimModelPartsService : IBimModelPartsService {
        /// <summary>
        /// Получает раздел по переданному документу.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public BimModelPart GetBimModelPart(Document document) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            return GetBimModelPart(document.Title);
        }

        /// <summary>
        /// Получает раздел по переданному имени документа.
        /// </summary>
        /// <param name="documentName">Имя документа.</param>
        /// <returns>Возвращает раздел модели по имени документа.</returns>
        public BimModelPart GetBimModelPart(string documentName) {
            if(string.IsNullOrEmpty(documentName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(documentName));
            }

            return GetBimModelParts()
                .OrderBy(item=> item.GetType() == typeof(BimModelSubPart))
                .FirstOrDefault(item => item.IsBimPart(documentName));
        }

        public bool IsBimModelPart(Document document, BimModelPart bimModelPart) {
            return IsBimModelPart(document.Title, bimModelPart);
        }

        public bool IsBimModelPart(string documentName, BimModelPart bimModelPart) {
            return GetBimModelPart(documentName) == bimModelPart;
        }

        public IEnumerable<BimModelPart> GetBimModelParts() {
            return typeof(BimModelPart)
                .GetFields(BindingFlags.Static)
                .Select(item => item.GetValue(null))
                .OfType<BimModelPart>();
        }

        public IEnumerable<BimModelPart> GetBimModelSubParts(BimModelPart parentPart) {
            if(parentPart == null) {
                throw new ArgumentNullException(nameof(parentPart));
            }

            return GetBimModelParts()
                .OfType<BimModelSubPart>()
                .Where(item => item.Parent == parentPart);
        }
    }
}