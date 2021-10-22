using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Класс конфигурации ключевых спецификаций.
    /// </summary>
    public class KeySchedulesConfig {
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static KeySchedulesConfig Instance { get; internal set; }

        #region Квартирография

        /// <summary>
        /// КВГ_(Ключ.) - Группа помещений
        /// </summary>
        public KeyScheduleRule RoomsGroups { get; internal set; }

        /// <summary>
        /// КВГ_(Ключ.) - Наименование пом.
        /// </summary>
        public KeyScheduleRule RoomsNames { get; internal set; }

        /// <summary>
        /// КВГ_(Ключ.) - Пожарный отсек
        /// </summary>
        public KeyScheduleRule FireCompartment { get; internal set; }

        /// <summary>
        /// КВГ_(Ключ.) - Секция
        /// </summary>
        public KeyScheduleRule RoomsSections { get; internal set; }

        /// <summary>
        /// КВГ_(Ключ.) - Тип группы
        /// </summary>
        public KeyScheduleRule RoomsTypeGroup { get; internal set; }

        #endregion

        /// <summary>
        /// Загрузка текущей конфигурации.
        /// </summary>
        /// <param name="configPath">Путь до конфигурации.</param>
        /// <remarks>Возвращает конфигурацию по умолчанию если был найден переданный файл.</remarks>
        public static void LoadInstance(string configPath) {
            Instance = Load(configPath);
        }

        /// <summary>
        /// Загрузка текущей конфигурации.
        /// </summary>
        /// <param name="configPath">Путь до конфигурации.</param>
        /// <remarks>Возвращает конфигурацию по умолчанию если был найден переданный файл.</remarks>
        public static KeySchedulesConfig Load(string configPath) {
            return File.Exists(configPath) ? JsonConvert.DeserializeObject<KeySchedulesConfig>(File.ReadAllText(configPath)) : GetDefaultConfg();
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static KeySchedulesConfig GetDefaultConfg() {
            return new KeySchedulesConfig();
        }
    }
}
