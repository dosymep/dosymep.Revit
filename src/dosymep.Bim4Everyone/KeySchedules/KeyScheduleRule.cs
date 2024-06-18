using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SystemParams;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Настройки проверки ключевых спецификаций.
    /// </summary>
    public class KeyScheduleRule : RevitScheduleRule {
        /// <summary>
        /// Создает экземпляр настроек проверки ключевых спецификаций.
        /// </summary>
        internal KeyScheduleRule() { }

        /// <summary>
        /// Ключевой параметр спецификации.
        /// </summary>
        public string KeyRevitParamName { get; set; }

        /// <summary>
        /// Общие параметры, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<string> FilledSharedParamNames { get; set; } = new List<string>();

        /// <summary>
        /// Параметры проекта, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<string> FilledProjectParamNames { get; set; } = new List<string>();

        /// <summary>
        /// Обязательные общие параметры в спецификации.
        /// </summary>
        public List<string> RequiredSharedParams { get; set; } = new List<string>();

        /// <summary>
        /// Обязательные параметры проекта в спецификации.
        /// </summary>
        public List<string> RequiredProjectParams { get; set; } = new List<string>();

#if REVIT2020 || REVIT2021

        /// <summary>
        /// Обязательные системные параметры проекта в спецификации.
        /// </summary>
        public List<BuiltInParameter> RequiredSystemParams { get; set; } = new List<BuiltInParameter>();

        /// <summary>
        /// Системные параметры проекта, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<BuiltInParameter> FilledSystemParams { get; set; } = new List<BuiltInParameter>();
        
#else
        
        /// <summary>
        /// Обязательные системные параметры проекта в спецификации.
        /// </summary>
        public List<ForgeTypeId> RequiredSystemParams { get; set; } = new List<ForgeTypeId>();

        /// <summary>
        /// Системные параметры проекта, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<ForgeTypeId> FilledSystemParams { get; set; } = new List<ForgeTypeId>();

#endif

        /// <summary>
        /// Создает объект класса проверок для спецификации.
        /// </summary>
        /// <param name="viewSchedule">Проверяемая спецификация.</param>
        /// <returns>Возвращает объект проверок спецификации</returns>
        public KeyScheduleTesting CreateKeyScheduleTesting(ViewSchedule viewSchedule) {
            if(viewSchedule is null) {
                throw new ArgumentNullException(nameof(viewSchedule));
            }

            if(!ScheduleName.Equals(viewSchedule.Name)) {
                throw new ArgumentException($"Переданная спецификация имеет другое наименование \"{viewSchedule.Name}\".", nameof(viewSchedule));
            }

            return new KeyScheduleTesting(viewSchedule, GetKeyScheduleRuleInternal(viewSchedule));
        }

        /// <summary>
        /// Возвращает внутренние настройки проверки ключевых спецификаций.
        /// </summary>
        /// <returns>Возвращает внутренние настройки проверки ключевых спецификаций.</returns>
        private KeyScheduleRuleInternal GetKeyScheduleRuleInternal(ViewSchedule viewSchedule) {
            Dictionary<string, RevitParam> propertySharedParams = SharedParamsConfig.Instance
                .GetRevitParams()
                .Select(item=>item.AsRevitParam())
                .ToDictionary(item => item.Id);

            Dictionary<string, RevitParam> propertyProjectParams = ProjectParamsConfig.Instance
                .GetRevitParams()
                .Select(item=>item.AsRevitParam())
                .ToDictionary(item => item.Id);

            var keyRevitParam = propertyProjectParams[KeyRevitParamName];

            var filledSharedParams = FilledSharedParamNames.Select(item => propertySharedParams[item]);
            var filledProjectParams = FilledProjectParamNames.Select(item => propertyProjectParams[item]);
            var filledSystemParams = FilledSystemParams.Select(item => SystemParamsConfig.Instance.CreateRevitParam(viewSchedule.Document, item));

            var requiredSharedParams = RequiredSharedParams.Select(item => propertySharedParams[item]);
            var requiredProjectParams = RequiredProjectParams.Select(item => propertyProjectParams[item]);
            var requiredSystemParams = RequiredSystemParams.Select(item => SystemParamsConfig.Instance.CreateRevitParam(viewSchedule.Document, item));

            return new KeyScheduleRuleInternal() {
                KeyScheduleRule = this,
                
                KeyRevitParam = keyRevitParam,
                FilledParams = new List<RevitParam>(filledSharedParams.Union(filledProjectParams).Union(filledSystemParams)),
                RequiredParams = new List<RevitParam>(requiredSharedParams.Union(requiredProjectParams).Union(requiredSystemParams)),
            };
        }
    }
}
