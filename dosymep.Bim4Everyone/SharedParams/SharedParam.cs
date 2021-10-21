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
            { nameof(SharedParamsConfig.MechanicalSystemName), "Описание MechanicalSystemName" },


            { nameof(SharedParamsConfig.RoomArea), "Описание RoomArea" },
            { nameof(SharedParamsConfig.RoomAreaWithRatio), "Описание RoomAreaWithRatio" },
            { nameof(SharedParamsConfig.RoomAreaRatio), "Описание RoomAreaRatio" },
            { nameof(SharedParamsConfig.ApartmentAreaRatio), "Описание ApartmentAreaRatio" },
            { nameof(SharedParamsConfig.ApartmentAreaNoBalcony), "Описание ApartmentAreaNoBalcony" },
            { nameof(SharedParamsConfig.ApartmentLivingArea), "Описание ApartmentLivingArea" },
            { nameof(SharedParamsConfig.ApartmentArea), "Описание ApartmentArea" },
            { nameof(SharedParamsConfig.ApartmentFullArea), "Описание ApartmentFullArea" },
            { nameof(SharedParamsConfig.RoomGroupShortName), "Описание RoomGroupName" },
            { nameof(SharedParamsConfig.ApartmentGroupName), "Описание ApartmentGroupName" },
            { nameof(SharedParamsConfig.FireCompartmentShortName), "Описание FireCompartmentName" },
            { nameof(SharedParamsConfig.RoomSectionShortName), "Описание RoomSectionName" },
            { nameof(SharedParamsConfig.RoomTypeGroupShortName), "Описание RoomTypeGroupName" },
            { nameof(SharedParamsConfig.ApartmentAreaSpec), "Описание ApartmentAreaSpec" },
            { nameof(SharedParamsConfig.ApartmentAreaMinSpec), "Описание ApartmentAreaMinSpec" },
            { nameof(SharedParamsConfig.ApartmentAreaMaxSpec), "Описание ApartmentAreaMaxSpec" },
            { nameof(SharedParamsConfig.ApartmentNumber), "Описание ApartmentNumber" },
            { nameof(SharedParamsConfig.ApartmentNumberExtra), "Описание ApartmentNumberExtra" },
            { nameof(SharedParamsConfig.ApartmentAreaRatioFix), "Описание ApartmentAreaRatioFix" },
            { nameof(SharedParamsConfig.ApartmentAreaNoBalconyFix), "Описание ApartmentAreaNoBalconyFix" },
            { nameof(SharedParamsConfig.ApartmentLivingAreaFix), "Описание ApartmentLivingAreaFix" },
            { nameof(SharedParamsConfig.ApartmentAreaFix), "Описание ApartmentAreaFix" },
            { nameof(SharedParamsConfig.RoomAreaFix), "Описание RoomAreaFix" },
            { nameof(SharedParamsConfig.RoomAreaWithRatioFix), "Описание RoomAreaWithRatioFix" },
            { nameof(SharedParamsConfig.ApartmentFullAreaFix), "Описание ApartmentFullAreaFix" },
            { nameof(SharedParamsConfig.Level), "Описание Level" },
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
            { nameof(SharedParamsConfig.MechanicalSystemName), StorageType.String },

            { nameof(SharedParamsConfig.RoomArea), StorageType.Double },
            { nameof(SharedParamsConfig.RoomAreaWithRatio), StorageType.Double },
            { nameof(SharedParamsConfig.RoomAreaRatio), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentAreaRatio), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentAreaNoBalcony), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentLivingArea), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentArea), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentFullArea), StorageType.Double },
            { nameof(SharedParamsConfig.RoomGroupShortName), StorageType.String },
            { nameof(SharedParamsConfig.ApartmentGroupName), StorageType.String },
            { nameof(SharedParamsConfig.FireCompartmentShortName), StorageType.String },
            { nameof(SharedParamsConfig.RoomSectionShortName), StorageType.String },
            { nameof(SharedParamsConfig.RoomTypeGroupShortName), StorageType.String },
            { nameof(SharedParamsConfig.ApartmentAreaSpec), StorageType.String },
            { nameof(SharedParamsConfig.ApartmentAreaMinSpec), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentAreaMaxSpec), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentNumber), StorageType.String },
            { nameof(SharedParamsConfig.ApartmentNumberExtra), StorageType.String },
            { nameof(SharedParamsConfig.ApartmentAreaRatioFix), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentAreaNoBalconyFix), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentLivingAreaFix), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentAreaFix), StorageType.Double },
            { nameof(SharedParamsConfig.RoomAreaFix), StorageType.Double },
            { nameof(SharedParamsConfig.RoomAreaWithRatioFix), StorageType.Double },
            { nameof(SharedParamsConfig.ApartmentFullAreaFix), StorageType.Double },
            { nameof(SharedParamsConfig.Level), StorageType.String },
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
