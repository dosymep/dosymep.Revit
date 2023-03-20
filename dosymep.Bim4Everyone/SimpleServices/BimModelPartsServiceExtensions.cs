using System;
using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices
{
    /// <summary>
    /// Класс расширений сервиса по получению разделов BIM модели.
    /// </summary>
    public static class BimModelPartsServiceExtensions {
        /// <summary>
        /// Получает раздел по переданному документу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        internal static BimModelPart GetBimModelPart(this IBimModelPartsService service, Document document) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            return service.GetBimModelPart(document.Title);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="document">Документ.</param>
        /// <param name="bimModelPart">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service, Document document,
            BimModelPart bimModelPart) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(bimModelPart == null) {
                throw new ArgumentNullException(nameof(bimModelPart));
            }

            return service.InAnyBimModelParts(document.Title, bimModelPart);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="document">Документ.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service, Document document,
            params BimModelPart[] bimModelParts) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(bimModelParts == null) {
                throw new ArgumentNullException(nameof(bimModelParts));
            }

            return service.InAnyBimModelParts(document.Title, bimModelParts);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="document">Документ.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service, Document document,
            IEnumerable<BimModelPart> bimModelParts) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(bimModelParts == null) {
                throw new ArgumentNullException(nameof(bimModelParts));
            }

            return service.InAnyBimModelParts(document.Title, bimModelParts);
        }
    }
}