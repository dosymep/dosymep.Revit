using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Настройки проверки ключевых спецификаций.
    /// </summary>
    public class KeyScheduleRule {
        /// <summary>
        /// Наименование спецификации.
        /// </summary>
        public string ScheduleName { get; set; }

        /// <summary>
        /// Ключевой параметр спецификации.
        /// </summary>
        public string KeyRevitParamName { get; set; }

        /// <summary>
        /// Общие параметры, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<string> FilledSharedParamNames { get; set; }

        /// <summary>
        /// Параметры проекта, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<string> FilledProjectParamNames { get; set; }

        /// <summary>
        /// Обязательные общие параметры в спецификации.
        /// </summary>
        public List<string> RequiredSharedParams { get; set; }

        /// <summary>
        /// Обязательные параметры проекта в спецификации.
        /// </summary>
        public List<string> RequiredProjectParams { get; set; }

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

            return new KeyScheduleTesting(viewSchedule, GetKeyScheduleRuleInternal());
        }

        /// <summary>
        /// Возвращает внутренние настройки проверки ключевых спецификаций.
        /// </summary>
        /// <returns>Возвращает внутренние настройки проверки ключевых спецификаций.</returns>
        private KeyScheduleRuleInternal GetKeyScheduleRuleInternal() {
            Dictionary<string, RevitParam> propertySharedParams = SharedParamsConfig.Instance
                .GetSharedParams()
                .ToDictionary(item => item.PropertyName);

            Dictionary<string, RevitParam> propertyProjectParams = ProjectParamsConfig.Instance
                .GetSharedParams()
                .ToDictionary(item => item.PropertyName);

            var keyRevitParam = propertyProjectParams[KeyRevitParamName];

            var filledSharedParams = FilledSharedParamNames.Select(item => propertySharedParams[item]);
            var filledProjectParams = FilledProjectParamNames.Select(item => propertyProjectParams[item]);

            var requiredSharedParams = RequiredSharedParams.Select(item => propertySharedParams[item]);
            var requiredProjectParams = RequiredProjectParams.Select(item => propertyProjectParams[item]);

            return new KeyScheduleRuleInternal() {
                KeyRevitParam = keyRevitParam,
                FilledParams = new List<RevitParam>(filledSharedParams.Union(filledProjectParams)),
                RequiredParams = new List<RevitParam>(requiredSharedParams.Union(requiredProjectParams)),
            };
        }
    }
}
