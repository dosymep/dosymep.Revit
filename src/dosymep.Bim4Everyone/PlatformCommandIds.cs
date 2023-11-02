using System;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Статический класс идентификаторов команд.
    /// </summary>
    public static class PlatformCommandIds {
        /// <summary>
        /// Имя поля данных журнал.
        /// Данное поле означает запущена команда из GUI.
        /// </summary>
        public const string ExecutedFromUI = "ExecutedFromUI";

        /// <summary>
        /// Модуль проверки уровней.
        /// </summary>
        public static readonly Guid CheckLevelsCommandId = new Guid("52C48778-652D-42E7-B31C-D269E0619703");
        
        /// <summary>
        /// Модуль настроек платформы.
        /// </summary>
        public static readonly Guid PlatformSettingsCommandId = new Guid("5AEAB5FF-80AF-472C-B8B0-947DE2F808F1");
    }
}