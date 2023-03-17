using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices
{
    /// <summary>
    /// Сервис по получению разделов BIM модели.
    /// </summary>
    public interface IBimModelPartsService {
        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="bimModelPart">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        bool IsBimModelPart(Document document, BimModelPart bimModelPart);

        /// <summary>
        /// Проверят является ли документ переданному разделу.
        /// </summary>
        /// <param name="documentName">Имя документа.</param>
        /// <param name="bimModelPart">Раздел BIM модели.</param>
        /// <returns>Возвращает раздел модели по документу.</returns>
        bool IsBimModelPart(string documentName, BimModelPart bimModelPart);

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