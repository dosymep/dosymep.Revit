using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public SystemParam CreateRevitParam(BuiltInParameter systemParamId) {
            string paramId = GetParamId(systemParamId);
            return new SystemParam(_languageType, paramId);
        }

        /// <inheritdoc/>
        public SystemParam CreateRevitParam(Document document, BuiltInParameter systemParamId) {
            string paramId = GetParamId(systemParamId);
            return new SystemParam(_languageType, paramId);
        }

        /// <inheritdoc/>
        public SystemParam CreateRevitParam(BuiltInParameter systemParamId, LanguageType languageType) {
            string paramId = GetParamId(systemParamId);
            return new SystemParam(languageType, paramId);
        }

        /// <inheritdoc/>
        public SystemParam CreateRevitParam(Document document, BuiltInParameter systemParamId,
            LanguageType languageType) {
            string paramId = GetParamId(systemParamId);
            return new SystemParam(languageType, paramId);
        }

        /// <inheritdoc/>
        public override RevitParam this[string paramId]
            => CreateRevitParam((BuiltInParameter) Enum.Parse(typeof(BuiltInParameter), paramId));

        /// <inheritdoc/>
        IEnumerable<SystemParam> ISystemParamsService.GetRevitParams() {
            return Enum.GetValues(typeof(BuiltInParameter))
                .Cast<BuiltInParameter>()
                .Select(item => CreateRevitParam(item));
        }

        /// <inheritdoc/>
        public override IEnumerable<RevitParam> GetRevitParams() {
            return Enum.GetValues(typeof(BuiltInParameter))
                .Cast<BuiltInParameter>()
                .Select(item => CreateRevitParam(item));
        }
        
        private string GetParamId(BuiltInParameter systemParamId) {
            return Enum.GetName(typeof(BuiltInParameter), systemParamId);
        }
#else
        /// <inheritdoc/>
        public SystemParam CreateRevitParam(ForgeTypeId systemParamId) {
            string paramId = GetParamId(systemParamId);
            return CreateRevitParam(_languageType, paramId);
        }

        /// <inheritdoc/>
        public SystemParam CreateRevitParam(Document document, ForgeTypeId systemParamId) {
            string paramId = GetParamId(systemParamId);
            return CreateRevitParam(_languageType, paramId);
        }

        /// <inheritdoc/>
        public SystemParam CreateRevitParam(ForgeTypeId systemParamId, LanguageType languageType) {
            string paramId = GetParamId(systemParamId);
            return CreateRevitParam(languageType, paramId);
        }

        /// <inheritdoc/>
        public SystemParam CreateRevitParam(Document document, ForgeTypeId systemParamId, LanguageType languageType) {
            string paramId = GetParamId(systemParamId);
            return CreateRevitParam(languageType, paramId);
        }

        /// <inheritdoc/>
        public override RevitParam this[string paramId] {
            get {
                if(HasParamId(paramId)) {
                    return CreateRevitParam(_languageType, paramId);
                }

                return null;
            }
        }

        /// <inheritdoc/>
        public new IEnumerable<SystemParam> GetRevitParams() {
            return typeof(ParameterTypeId)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(item => item.GetIndexParameters().Length == 0 && item.GetValue(null) is ForgeTypeId)
                .Select(item => CreateRevitParam(_languageType, item.Name));
        }

        private string GetParamId(ForgeTypeId systemParamId) {
            return typeof(ParameterTypeId)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(item => (ForgeTypeId) item.GetValue(null) == systemParamId)?.Name;
        }

        private SystemParam CreateRevitParam(LanguageType? languageType, string paramId) {
            return string.IsNullOrEmpty(paramId) ? null : new SystemParam(languageType, paramId);
        }

        private bool HasParamId(string paramId) {
            return string.IsNullOrEmpty(paramId)
                ? false
                : typeof(ParameterTypeId)
                    .GetProperty(paramId, BindingFlags.Public | BindingFlags.Static) != null;
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