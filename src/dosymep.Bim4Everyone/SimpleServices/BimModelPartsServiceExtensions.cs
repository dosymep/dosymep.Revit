using System;
using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
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
        public static BimModelPart GetBimModelPart(this IBimModelPartsService service, Document document) {
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

        /// <summary>
        /// Получает раздел по переданному документу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkType">Тип связи Revit.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        internal static BimModelPart GetBimModelPart(this IBimModelPartsService service, RevitLinkType revitLinkType) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkType == null) {
                throw new ArgumentNullException(nameof(revitLinkType));
            }

            return service.GetBimModelPart(revitLinkType.Name);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkType">Тип связи Revit.</param>
        /// <param name="bimModelPart">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service, RevitLinkType revitLinkType,
            BimModelPart bimModelPart) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkType == null) {
                throw new ArgumentNullException(nameof(revitLinkType));
            }

            if(bimModelPart == null) {
                throw new ArgumentNullException(nameof(bimModelPart));
            }

            return service.InAnyBimModelParts(revitLinkType.Name, bimModelPart);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkType">Тип связи Revit.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service, RevitLinkType revitLinkType,
            params BimModelPart[] bimModelParts) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkType == null) {
                throw new ArgumentNullException(nameof(revitLinkType));
            }

            if(bimModelParts == null) {
                throw new ArgumentNullException(nameof(bimModelParts));
            }

            return service.InAnyBimModelParts(revitLinkType.Name, bimModelParts);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkType">Тип связи Revit.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service, RevitLinkType revitLinkType,
            IEnumerable<BimModelPart> bimModelParts) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkType == null) {
                throw new ArgumentNullException(nameof(revitLinkType));
            }

            if(bimModelParts == null) {
                throw new ArgumentNullException(nameof(bimModelParts));
            }

            return service.InAnyBimModelParts(revitLinkType.Name, bimModelParts);
        }

        /// <summary>
        /// Получает раздел по переданному документу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkInstance">Экземпляр связи Revit.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        internal static BimModelPart GetBimModelPart(this IBimModelPartsService service,
            RevitLinkInstance revitLinkInstance) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkInstance == null) {
                throw new ArgumentNullException(nameof(revitLinkInstance));
            }

            return service.GetBimModelPart(revitLinkInstance.Name);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkInstance">Экземпляр связи Revit.</param>
        /// <param name="bimModelPart">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service,
            RevitLinkInstance revitLinkInstance,
            BimModelPart bimModelPart) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkInstance == null) {
                throw new ArgumentNullException(nameof(revitLinkInstance));
            }

            if(bimModelPart == null) {
                throw new ArgumentNullException(nameof(bimModelPart));
            }

            return service.InAnyBimModelParts(revitLinkInstance.Name, bimModelPart);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkInstance">Экземпляр связи Revit.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service,
            RevitLinkInstance revitLinkInstance,
            params BimModelPart[] bimModelParts) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkInstance == null) {
                throw new ArgumentNullException(nameof(revitLinkInstance));
            }

            if(bimModelParts == null) {
                throw new ArgumentNullException(nameof(bimModelParts));
            }

            return service.InAnyBimModelParts(revitLinkInstance.Name, bimModelParts);
        }

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="revitLinkInstance">"Экземпляр связи Revit.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        public static bool InAnyBimModelParts(this IBimModelPartsService service,
            RevitLinkInstance revitLinkInstance,
            IEnumerable<BimModelPart> bimModelParts) {
            if(service == null) {
                throw new ArgumentNullException(nameof(service));
            }

            if(revitLinkInstance == null) {
                throw new ArgumentNullException(nameof(revitLinkInstance));
            }

            if(bimModelParts == null) {
                throw new ArgumentNullException(nameof(bimModelParts));
            }

            return service.InAnyBimModelParts(revitLinkInstance.Name, bimModelParts);
        }
    }
}