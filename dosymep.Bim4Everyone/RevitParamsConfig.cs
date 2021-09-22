using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс по работе с параметрами Revit.
    /// </summary>
    public abstract class RevitParamsConfig {
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
        /// Возвращает весь список настроек параметров.
        /// </summary>
        /// <returns>Возвращает весь список настроек параметров.</returns>
        public virtual IEnumerable<RevitParam> GetSharedParams() {
            return GetType().GetProperties().Select(item => item.GetValue(this)).OfType<RevitParam>().OrderBy(item => item.PropertyName);
        }
    }
}
