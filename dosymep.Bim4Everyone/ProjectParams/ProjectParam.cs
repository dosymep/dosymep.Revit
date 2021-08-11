using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.ProjectParams {
    /// <summary>
    /// Класс параметров проекта Revit.
    /// </summary>
    public class ProjectParam : RevitParam {
        /// <summary>
        /// Содержит все описания параметров проекта.
        /// </summary>
        private readonly static Dictionary<string, string> _description = new Dictionary<string, string>() {

        };

        /// <summary>
        /// Содержит все типы параметров проекта.
        /// </summary>
        private readonly static Dictionary<string, StorageType> _projectParamTypes = new Dictionary<string, StorageType>() {

        };

        /// <summary>
        /// Конструктор класса параметра проекта.
        /// </summary>
        internal ProjectParam() { }

        /// <inheritdoc/>
        [JsonIgnore]
        public override string Description {
            get { return _description.TryGetValue(PropertyName, out string value) ? value : null; }
        }

        /// <inheritdoc/>
        [JsonIgnore]
        public override StorageType SharedParamType {
            get { return _projectParamTypes.TryGetValue(PropertyName, out StorageType value) ? value : StorageType.None; }
        }
    }
}
