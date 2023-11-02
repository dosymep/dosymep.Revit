using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices
{
    /// <summary>
    /// Сервис по получению разделов BIM модели.
    /// </summary>
    public interface IBimModelPartsService {
        /// <summary>
        /// Получает раздел по переданному имени документа.
        /// </summary>
        /// <param name="documentName">Имя документа.</param>
        /// <returns>Возвращает раздел модели по имени документа.</returns>
        BimModelPart GetBimModelPart(string documentName);
        
        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="documentName">Имя документа.</param>
        /// <param name="bimModelPart">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        bool InAnyBimModelParts(string documentName, BimModelPart bimModelPart);
        
        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="documentName">Имя документа.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        bool InAnyBimModelParts(string documentName, params BimModelPart[] bimModelParts);
        
        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="documentName">Имя документа.</param>
        /// <param name="bimModelParts">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        bool InAnyBimModelParts(string documentName, IEnumerable<BimModelPart> bimModelParts);

        /// <summary>
        /// Возвращает все разделы BIM модели.
        /// </summary>
        /// <returns>Возвращает все разделы BIM модели.</returns>
        IEnumerable<BimModelPart> GetBimModelParts();

        /// <summary>
        /// Возвращает все разделы BIM модели.
        /// </summary>
        /// <param name="parentPart">Родительский раздел.</param>
        /// <returns>Возвращает все разделы BIM модели.</returns>
        IEnumerable<BimModelPart> GetBimModelSubParts(BimModelPart parentPart);
    }
}