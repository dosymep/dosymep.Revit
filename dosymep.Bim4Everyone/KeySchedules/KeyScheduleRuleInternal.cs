using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Внутренние настройки проверки ключевых спецификаций.
    /// </summary>
    internal class KeyScheduleRuleInternal {
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

        /// <summary>
        /// Обязательные системные параметры проекта в спецификации.
        /// </summary>
        public List<BuiltInParameter> RequiredSystemParams { get; set; }

        /// <summary>
        /// Системные параметры, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<BuiltInParameter> FilledSystemParams { get; internal set; }
    }
}
