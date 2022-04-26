using System.Collections.Generic;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SystemParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к системным параметрам.
    /// </summary>
    public interface ISystemParamsService : IRevitParamsService {
#if D2020 || R2020 || D2021 || R2021
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(BuiltInParameter systemParamId);
        
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(Document document, BuiltInParameter systemParamId);

        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <param name="languageType">Язык возвращаемого параметра.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(BuiltInParameter systemParamId, LanguageType languageType);
        
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// /// <param name="languageType">Язык возвращаемого параметра.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(Document document, BuiltInParameter systemParamId, LanguageType languageType);
#else
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(ForgeTypeId systemParamId);
        
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(Document document, ForgeTypeId systemParamId);

        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <param name="languageType">Язык возвращаемого параметра.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(ForgeTypeId systemParamId, LanguageType languageType);
        
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// /// <param name="languageType">Язык возвращаемого параметра.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam GetRevitParam(Document document, ForgeTypeId systemParamId, LanguageType languageType);
#endif
        
        /// <summary>
        /// Возвращает весь список системных параметров.
        /// </summary>
        /// <returns>Возвращает весь список системных параметров.</returns>
        new IEnumerable<SystemParam> GetRevitParams();
    }
}