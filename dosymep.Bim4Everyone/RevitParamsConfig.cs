using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dosymep.Bim4Everyone.SimpleServices;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс по работе с параметрами Revit.
    /// </summary>
    public abstract class RevitParamsConfig : IRevitParamsService {
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

        /// <inheritdoc />
        public virtual RevitParam this[string paramId] => (RevitParam) GetType().GetProperty(paramId)?.GetValue(this);

        /// <inheritdoc />
        public virtual IEnumerable<RevitParam> GetRevitParams() {
            return GetType().GetProperties()
                .Where(item => item.GetIndexParameters().Length == 0)
                .Select(item => item.GetValue(this))
                .OfType<RevitParam>()
                .OrderBy(item => item.Id);
        }
    }
}