using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SimpleServices;
using dosymep.Revit;

namespace dosymep.Bim4Everyone.SystemParams {
    /// <summary>
    /// Конфигурация системных параметров.
    /// </summary>
    public class SystemParamsConfig : RevitParamsConfig, ISystemParamsService {
        private readonly LanguageType? _languageType;

        /// <summary>
        /// Инициализирует конфигурацию системных параметров.
        /// </summary>
        internal SystemParamsConfig() { }

        /// <summary>
        /// Инициализирует конфигурацию системных параметров.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        internal SystemParamsConfig(LanguageType? languageType) {
            _languageType = languageType;
        }


#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="LoadInstance(Autodesk.Revit.ApplicationServices.LanguageType?)"/></remarks>
        public static SystemParamsConfig Instance { get; internal set; }
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved

#if D2020 || R2020 || D2021 || R2021
        /// <inheritdoc/>
        public SystemParam GetRevitParam(BuiltInParameter builtInParameter) {
            return new SystemParam(_languageType, builtInParameter);
        }

        /// <inheritdoc/>
        public SystemParam GetRevitParam(Document document, BuiltInParameter systemParamId) {
            return new SystemParam(_languageType, systemParamId);
        }

        /// <inheritdoc/>
        public SystemParam GetRevitParam(BuiltInParameter systemParamId, LanguageType languageType) {
            return new SystemParam(languageType, systemParamId);
        }

        /// <inheritdoc/>
        public SystemParam GetRevitParam(Document document, BuiltInParameter systemParamId, LanguageType languageType) {
            return new SystemParam(languageType, systemParamId);
        }

        /// <inheritdoc/>
        public override RevitParam this[string paramId] 
            => GetRevitParam((BuiltInParameter) Enum.Parse(typeof(BuiltInParameter), paramId));

        /// <inheritdoc/>
        IEnumerable<SystemParam> ISystemParamsService.GetRevitParams() {
            return Enum.GetValues(typeof(BuiltInParameter))
                .Cast<BuiltInParameter>()
                .Select(item => GetRevitParam(item));
        }

        /// <inheritdoc/>
        public override IEnumerable<RevitParam> GetRevitParams() {
            return Enum.GetValues(typeof(BuiltInParameter))
                .Cast<BuiltInParameter>()
                .Select(item => GetRevitParam(item));
        }
#else
        /// <inheritdoc/>
        public SystemParam GetRevitParam(ForgeTypeId systemParamId) {
            return new SystemParam(_languageType, systemParamId);
        }

        /// <inheritdoc/>
        public SystemParam GetRevitParam(Document document, ForgeTypeId systemParamId) {
            return new SystemParam(_languageType, systemParamId);
        }

        /// <inheritdoc/>
        public SystemParam GetRevitParam(ForgeTypeId systemParamId, LanguageType languageType) {
            return new SystemParam(languageType, systemParamId);
        }

        /// <inheritdoc/>
        public SystemParam GetRevitParam(Document document, ForgeTypeId systemParamId, LanguageType languageType) {
            return new SystemParam(languageType, systemParamId);
        }
        
        /// <inheritdoc/>
        public override RevitParam this[string paramId] 
            => GetRevitParam((ForgeTypeId) typeof(ParameterTypeId).GetProperty(paramId)?.GetValue(this));

        /// <inheritdoc/>
        public new IEnumerable<SystemParam> GetRevitParams() {
            return ParameterUtils.GetAllBuiltInParameters().Select(item => GetRevitParam(item));
        }
#endif
        
        /// <inheritdoc/>
        SystemParam ISystemParamsService.this[string paramId]
            => (SystemParam) this[paramId];

        /// <inheritdoc/>
        public override void Save(string configPath) {
            throw new NotSupportedException("Сохранение конфигурации для системных параметров бесполезно.");
        }

        /// <summary>
        /// Загрузка текущей конфигурации.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        public static void LoadInstance(LanguageType? languageType) {
            Instance = languageType.HasValue ? Load(languageType) : GetDefaultConfig();
        }

        /// <summary>
        /// Загрузка текущей конфигурации.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        public static SystemParamsConfig Load(LanguageType? languageType) {
            return new SystemParamsConfig(languageType);
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static SystemParamsConfig GetDefaultConfig() {
            return new SystemParamsConfig();
        }
    }
}