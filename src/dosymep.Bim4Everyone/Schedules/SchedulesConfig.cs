using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.Schedules {
    /// <summary>
    /// Класс конфигурации спецификаций.
    /// </summary>
    public class SchedulesConfig : RevitSchedulesConfig {
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static SchedulesConfig Instance { get; internal set; }

        #region Квартирография

        /// <summary>
        /// КВГ_(Проверка) Без группы
        /// </summary>
        public ScheduleRule RoomsCheckGroup { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Без группы" };

        /// <summary>
        /// КВГ_(Проверка) Без наименования
        /// </summary>
        public ScheduleRule RoomsCheckName { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Без наименования" };

        /// <summary>
        /// КВГ_(Проверка) Без секции
        /// </summary>
        public ScheduleRule RoomsCheckSection { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Без секции" };

        /// <summary>
        /// КВГ_(Проверка) Не прошедшие Квартирографию
        /// </summary>
        public ScheduleRule RoomsCheck { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Не прошедшие Квартирографию" };

        /// <summary>
        /// КВГ_(Проверка) Неокружённые и избыточные
        /// </summary>
        public ScheduleRule RoomsCheckInvalidArea { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Неокружённые и избыточные" };

        /// <summary>
        /// КВГ_(Проверка) Несовпадение Площадей
        /// </summary>
        public ScheduleRule RoomsCheckAreas { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Несовпадение Площадей" };

        /// <summary>
        /// КВГ_(Проверка) Высота помещений
        /// </summary>
        public ScheduleRule RoomsCheckHeights { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Высота помещений" };

        /// <summary>
        /// КВГ_Все помещения и параметры
        /// </summary>
        public ScheduleRule RoomsCheckParams { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_Все помещения и параметры" };

        /// <summary>
        /// КВГ_Удаление помещений по этажам
        /// </summary>
        public ScheduleRule RoomsCheckRemoves { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_Удаление помещений по этажам" };
        
        /// <summary>
        /// КВГ_(Проверка) Отклонение от площади по ТЗ
        /// </summary>
        public ScheduleRule RoomsCheckDeviationAreas { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Отклонение от площади по ТЗ" };
        
        /// <summary>
        /// КВГ_(Проверка) Квартирография по типам
        /// </summary>
        public ScheduleRule RoomsCheckTypes { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Квартирография по типам" };
        
        /// <summary>
        /// КВГ_(Проверка) Тип группы
        /// </summary>
        public ScheduleRule RoomsCheckGroupTypes { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Тип группы" };

        /// <summary>
        /// КВГ_(Проверка) Фиксированные площади
        /// </summary>
        public ScheduleRule RoomsCheckFixedAreas{ get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_(Проверка) Фиксированные площади" };

        /// <summary>
        /// КВГ_Многоуровневые квартиры
        /// </summary>
        public ScheduleRule RoomsMultiLevel { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_Многоуровневые квартиры" };

        /// <summary>
        /// КВГ_Летние помещения
        /// </summary>
        public ScheduleRule RoomsSummer { get; internal set; } = new ScheduleRule() { ScheduleName = "КВГ_Летние помещения" };

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
        public static SchedulesConfig Load(string configPath) {
            return File.Exists(configPath) ? JsonConvert.DeserializeObject<SchedulesConfig>(File.ReadAllText(configPath)) : GetDefaultConfig();
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static SchedulesConfig GetDefaultConfig() {
            return new SchedulesConfig();
        }
    }
}
