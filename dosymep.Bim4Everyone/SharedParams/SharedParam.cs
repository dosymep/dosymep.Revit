using System.Collections.Generic;

using Autodesk.Revit.DB;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SharedParams {
    /// <summary>
    /// Класс общего параметра
    /// </summary>
    public class SharedParam : RevitParam {
        /// <summary>
        /// Содержит все описания общих параметров
        /// </summary>
        private readonly static Dictionary<string, string> _description = new Dictionary<string, string>() {
            { nameof(SharedParamsConfig.SizeDepth), "Описание SizeDepth" },
            { nameof(SharedParamsConfig.SizeWidth), "Описание SizeWidth" },
            { nameof(SharedParamsConfig.BulkheadClass), "Описание BulkheadClass" },
            { nameof(SharedParamsConfig.BulkheadDepth), "Описание BulkheadDepth" },
            { nameof(SharedParamsConfig.BulkheadExists), "Описание BulkheadExists" },
            { nameof(SharedParamsConfig.BulkheadLength), "Описание BulkheadLength" },
            { nameof(SharedParamsConfig.AlbumBlueprints), "Описание AlbumBlueprints" },
            { nameof(SharedParamsConfig.StampSheetNumber), "Описание StampSheetNumber" },
        };

        /// <summary>
        /// Содержит все типы общих параметров
        /// </summary>
        private readonly static Dictionary<string, StorageType> _sharedParamTypes = new Dictionary<string, StorageType>() {
            { nameof(SharedParamsConfig.SizeDepth), StorageType.Double },
            { nameof(SharedParamsConfig.SizeWidth), StorageType.Double },
            { nameof(SharedParamsConfig.BulkheadClass), StorageType.String },
            { nameof(SharedParamsConfig.BulkheadDepth), StorageType.String },
            { nameof(SharedParamsConfig.BulkheadExists), StorageType.String },
            { nameof(SharedParamsConfig.BulkheadLength), StorageType.String },
            { nameof(SharedParamsConfig.AlbumBlueprints), StorageType.String },
            { nameof(SharedParamsConfig.StampSheetNumber), StorageType.String },
        };

        /// <summary>
        /// Конструктор класса общего параметра
        /// </summary>
        internal SharedParam() { }

        /// <inheritdoc/>
        [JsonIgnore]
        public override string Description {
            get { return _description.TryGetValue(PropertyName, out string value) ? value : null; }
        }

        /// <inheritdoc/>
        [JsonIgnore]
        public override StorageType SharedParamType {
            get { return _sharedParamTypes.TryGetValue(PropertyName, out StorageType value) ? value : StorageType.None; }
        }
    }
}
