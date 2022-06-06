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
        /// Перечень всех общих параметров проекта.
        /// </summary>
        protected Dictionary<string, RevitParam> _revitParams;

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
        public RevitParam this[string paramId] => GetRevitParam(paramId);

        /// <inheritdoc />
        public virtual IEnumerable<RevitParam> GetRevitParams() {
            return _revitParams.Values
                .OrderBy(item => item.Id);
        }

        private RevitParam GetRevitParam(string paramId) {
            if(string.IsNullOrEmpty(paramId)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(paramId));
            }

            if(_revitParams.TryGetValue(paramId, out RevitParam revitParam)) {
                return revitParam;
            }

            throw new Exception($"Не был найден параметр с идентификатором \"{paramId}\".");
        }
    }
}