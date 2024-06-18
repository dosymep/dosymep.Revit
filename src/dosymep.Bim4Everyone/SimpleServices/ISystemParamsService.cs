using System;
using System.Collections.Generic;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SystemParams;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Сервис предоставляет доступ к системным параметрам.
    /// </summary>
    public interface ISystemParamsService : IRevitParamsService {
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        [Obsolete]
        SystemParam CreateRevitParam(BuiltInParameter systemParamId);
        
        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam CreateRevitParam(Document document, BuiltInParameter systemParamId);

        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// /// <param name="languageType">Язык возвращаемого параметра.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam CreateRevitParam(Document document, BuiltInParameter systemParamId, LanguageType languageType);
        
#if REVIT2022_OR_GREATER

        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam CreateRevitParam(Document document, ForgeTypeId systemParamId);

        /// <summary>
        /// Возвращает системный параметр.
        /// </summary>
        /// <param name="document">Документ системного параметра.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        /// /// <param name="languageType">Язык возвращаемого параметра.</param>
        /// <returns>Возвращает системный параметр.</returns>
        SystemParam CreateRevitParam(Document document, ForgeTypeId systemParamId, LanguageType languageType);

        /// <summary>
        /// Возвращает системный параметр по его имени (идентификатору).
        /// </summary>
        /// <param name="paramId">Идентификатор параметра Revit.</param>
        SystemParam this[ForgeTypeId paramId] { get; }

#endif
        
        /// <summary>
        /// Возвращает системный параметр по его имени (идентификатору).
        /// </summary>
        /// <param name="paramId">Идентификатор параметра Revit.</param>
        SystemParam this[BuiltInParameter paramId] { get; }
        
        /// <summary>
        /// Возвращает системный параметр по его имени (идентификатору).
        /// </summary>
        /// <param name="paramId">Идентификатор параметра Revit.</param>
        new SystemParam this[string paramId] { get; }
        
        /// <summary>
        /// Возвращает весь список системных параметров.
        /// </summary>
        /// <returns>Возвращает весь список системных параметров.</returns>
        new IEnumerable<SystemParam> GetRevitParams();
    }
}