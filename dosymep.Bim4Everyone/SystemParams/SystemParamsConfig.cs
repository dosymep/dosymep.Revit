using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SystemParams {
    /// <summary>
    /// Конфигурация системных параметров.
    /// </summary>
    public class SystemParamsConfig : RevitParamsConfig {
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
        /// <summary>
        /// Возвращает экземпляр класса системного параметра.
        /// </summary>
        /// <param name="builtInParameter">Системный параметр.</param>
        /// <returns>Возвращает экземпляр класса системного параметра.</returns>
        public SystemParam GetSystemParam(BuiltInParameter builtInParameter) {
            return new SystemParam(_languageType, builtInParameter);
        }

        /// <inheritdoc/>
        public override IEnumerable<RevitParam> GetSharedParams() {
            return Enum.GetValues(typeof(BuiltInParameter)).Cast<BuiltInParameter>().Select(item => GetSystemParam(item));
        }
#else
        /// <summary>
        /// Возвращает экземпляр класса системного параметра.
        /// </summary>
        /// <param name="forgeTypeId">Системный параметр.</param>
        /// <returns>Возвращает экземпляр класса системного параметра.</returns>
        public SystemParam GetSystemParam(ForgeTypeId forgeTypeId) {
            return new SystemParam(_languageType, forgeTypeId);
        }

        /// <inheritdoc/>
        public override IEnumerable<RevitParam> GetSharedParams() {            
            return ParameterUtils.GetAllBuiltInParameters().Select(item => GetSystemParam(item));
        }
#endif

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
