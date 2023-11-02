using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Внутренние настройки проверки ключевых спецификаций.
    /// </summary>
    internal class KeyScheduleRuleInternal {
        /// <summary>
        /// Настройки проверки ключевых спецификаций.
        /// </summary>

        public KeyScheduleRule KeyScheduleRule { get; set; }

        /// <summary>
        /// Ключевой параметр спецификации.
        /// </summary>
        public RevitParam KeyRevitParam { get; set; }

        /// <summary>
        /// Параметры, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<RevitParam> FilledParams { get; set; }

        /// <summary>
        /// Обязательные параметры в спецификации.
        /// </summary>
        public List<RevitParam> RequiredParams { get; set; }
    }
}
