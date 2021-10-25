using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit;

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
            { nameof(ProjectParamsConfig.ViewNumberOnSheet), "Описание ViewNumberOnSheet" },
            { nameof(ProjectParamsConfig.WithFullSheetNumber), "Описание WithFullSheetNumber" },
            { nameof(ProjectParamsConfig.WithSheetNumber), "Описание WithSheetNumber" },
            { nameof(ProjectParamsConfig.ViewGroup), "Описание ViewGroup" },
            { nameof(ProjectParamsConfig.ProjectStage), "Описание ProjectStage" },
            { nameof(ProjectParamsConfig.CheckIsNormalGrid), "Описание CheckIsNormalGrid" },
            { nameof(ProjectParamsConfig.CheckCorrectDistanceGrid ), "Описание CheckCorrectDistanceGrid" },


            { nameof(ProjectParamsConfig.RoomAreaRatio ), "Описание RoomAreaRatio" },
            { nameof(ProjectParamsConfig.RoomGroupName ), "Описание RoomGroupName" },
            { nameof(ProjectParamsConfig.FireCompartmentName ), "Описание FireCompartmentName" },
            { nameof(ProjectParamsConfig.RoomSectionName ), "Описание RoomSectionName" },
            { nameof(ProjectParamsConfig.RoomTypeGroupName ), "Описание RoomTypeGroupName" },
            { nameof(ProjectParamsConfig.RoomTypeCountGroup ), "Описание RoomTypeCountGroup" },
            { nameof(ProjectParamsConfig.RoomName ), "Описание RoomName" },
            { nameof(ProjectParamsConfig.IsRoomBalcony ), "Описание IsRoomBalcony" },
            { nameof(ProjectParamsConfig.IsRoomLiving ), "Описание IsRoomLiving" },
            { nameof(ProjectParamsConfig.ApartmentTypeNumsInSection ), "Описание ApartmentTypeNumsInSection" },
            { nameof(ProjectParamsConfig.IsRoomNumberFix ), "Описание IsRoomNumberFix" },

#if D2020 || R2020 || D2021 || R2021
            { nameof(ProjectParamsConfig.ApartmentGroupName ), "Описание ApartmentGroupName" },
            { nameof(ProjectParamsConfig.RoomGroupShortName ), "Описание RoomGroupShortName" },
            { nameof(ProjectParamsConfig.FireCompartmentShortName ), "Описание FireCompartmentShortName" },
            { nameof(ProjectParamsConfig.RoomSectionShortName ), "Описание RoomSectionShortName" },
            { nameof(ProjectParamsConfig.RoomTypeGroupShortName ), "Описание RoomTypeGroupShortName" },
            { nameof(ProjectParamsConfig.ApartmentAreaMinSpec ), "Описание ApartmentAreaMinSpec" },
            { nameof(ProjectParamsConfig.ApartmentAreaMaxSpec ), "Описание ApartmentAreaMaxSpec" },
            { nameof(ProjectParamsConfig.ApartmentAreaSpec ), "Описание ApartmentAreaSpec" },
#endif
        };

        /// <summary>
        /// Содержит все типы параметров проекта.
        /// </summary>
        private readonly static Dictionary<string, StorageType> _projectParamTypes = new Dictionary<string, StorageType>() {
            { nameof(ProjectParamsConfig.ViewNumberOnSheet), StorageType.String },
            { nameof(ProjectParamsConfig.WithFullSheetNumber), StorageType.Integer },
            { nameof(ProjectParamsConfig.WithSheetNumber), StorageType.Integer },
            { nameof(ProjectParamsConfig.ViewGroup), StorageType.String },
            { nameof(ProjectParamsConfig.ProjectStage), StorageType.String },
            { nameof(ProjectParamsConfig.CheckIsNormalGrid), StorageType.Integer },
            { nameof(ProjectParamsConfig.CheckCorrectDistanceGrid), StorageType.Integer },

            { nameof(ProjectParamsConfig.RoomAreaRatio ), StorageType.Double },
            { nameof(ProjectParamsConfig.RoomGroupName ), StorageType.String },
            { nameof(ProjectParamsConfig.FireCompartmentName ), StorageType.String },
            { nameof(ProjectParamsConfig.RoomSectionName ), StorageType.String },
            { nameof(ProjectParamsConfig.RoomTypeGroupName ), StorageType.String },
            { nameof(ProjectParamsConfig.RoomTypeCountGroup ), StorageType.Integer },
            { nameof(ProjectParamsConfig.RoomName ), StorageType.String },
            { nameof(ProjectParamsConfig.ApartmentTypeNumsInSection ), StorageType.Integer },
            { nameof(ProjectParamsConfig.IsRoomBalcony ),StorageType.Integer },
            { nameof(ProjectParamsConfig.IsRoomLiving ),StorageType.Integer },
            { nameof(ProjectParamsConfig.IsRoomNumberFix ), StorageType.Integer },

#if D2020 || R2020 || D2021 || R2021
            { nameof(ProjectParamsConfig.ApartmentGroupName ), StorageType.String },
            { nameof(ProjectParamsConfig.RoomGroupShortName ), StorageType.String },
            { nameof(ProjectParamsConfig.FireCompartmentShortName ), StorageType.String },
            { nameof(ProjectParamsConfig.RoomSectionShortName ), StorageType.String },
            { nameof(ProjectParamsConfig.RoomTypeGroupShortName ), StorageType.String },
            { nameof(ProjectParamsConfig.ApartmentAreaSpec ), StorageType.String },
            { nameof(ProjectParamsConfig.ApartmentAreaMinSpec ), StorageType.Double },
            { nameof(ProjectParamsConfig.ApartmentAreaMaxSpec ), StorageType.Double },
#endif
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

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.IsExistsProjectParam(Name);
        }

        /// <inheritdoc/>
        public override Parameter GetParam(Element element) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            var param = element.GetParameters(Name).FirstOrDefault(item => !item.IsShared);
            if(param is null) {
                throw new ArgumentException($"Параметр проекта с заданным именем \"{Name}\" не был найден.");
            }

            if(param.StorageType != SharedParamType) {
                throw new ArgumentException($"Переданный Параметр проекта \"{Name}\" не соответствует типу параметра у элемента.");
            }

            return param;
        }
    }
}
