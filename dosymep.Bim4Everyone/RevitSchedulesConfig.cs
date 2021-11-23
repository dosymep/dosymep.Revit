using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Абстрактный класс конфигурации спецификаций.
    /// </summary>
    public abstract class RevitSchedulesConfig {
        /// <summary>
        /// Сохранение текущей конфигурации.
        /// </summary>
        /// <param name="configPath">Путь до конфигурации.</param>
        public virtual void Save(string configPath) {
            if(string.IsNullOrEmpty(configPath)) {
                throw new ArgumentException($"'{nameof(configPath)}' cannot be null or empty.", nameof(configPath));
            }

            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(configPath, json);
        }

        /// <summary>
        /// Возвращает весь список правил спецификаций.
        /// </summary>
        /// <returns>Возвращает список правил спецификаций.</returns>
        public virtual IEnumerable<RevitScheduleRule> GetScheduleRules() {
            return GetType().GetProperties()
                .Select(item => item.GetValue(this))
                .OfType<RevitScheduleRule>()
                .OrderBy(item => item.ScheduleName);
        }
    }
}
