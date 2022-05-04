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
        private readonly StorageType? _storageType;

        /// <summary>
        /// Содержит все описания параметров проекта.
        /// </summary>
        private static readonly Dictionary<string, string> _description = new Dictionary<string, string>() {
            {nameof(ProjectParamsConfig.ViewNumberOnSheet), "Описание ViewNumberOnSheet"},
            {nameof(ProjectParamsConfig.WithFullSheetNumber), "Описание WithFullSheetNumber"},
            {nameof(ProjectParamsConfig.WithSheetNumber), "Описание WithSheetNumber"},
            {nameof(ProjectParamsConfig.ViewGroup), "Описание ViewGroup"},
            {nameof(ProjectParamsConfig.ProjectStage), "Описание ProjectStage"},
            {nameof(ProjectParamsConfig.CheckIsNormalGrid), "Описание CheckIsNormalGrid"},
            {nameof(ProjectParamsConfig.CheckCorrectDistanceGrid), "Описание CheckCorrectDistanceGrid"},
            {nameof(ProjectParamsConfig.RoomGroupName), "Описание RoomGroupName"},
            {nameof(ProjectParamsConfig.FireCompartmentName), "Описание FireCompartmentName"},
            {nameof(ProjectParamsConfig.RoomSectionName), "Описание RoomSectionName"},
            {nameof(ProjectParamsConfig.RoomTypeGroupName), "Описание RoomTypeGroupName"},
            {nameof(ProjectParamsConfig.RoomName), "Описание RoomName"},
            {nameof(ProjectParamsConfig.IsRoomBalcony), "Описание IsRoomBalcony"},
            {nameof(ProjectParamsConfig.IsRoomLiving), "Описание IsRoomLiving"},
            {nameof(ProjectParamsConfig.IsRoomNumberFix), "Описание IsRoomNumberFix"},
            {nameof(ProjectParamsConfig.NumberingOrder), "Описание NumberingOrder"},

#if D2020 || R2020 || D2021 || R2021
            {nameof(ProjectParamsConfig.RoomAreaRatio), "Описание RoomAreaRatio"},
            {nameof(ProjectParamsConfig.ApartmentGroupName), "Описание ApartmentGroupName"},
            {nameof(ProjectParamsConfig.RoomGroupShortName), "Описание RoomGroupShortName"},
            {nameof(ProjectParamsConfig.FireCompartmentShortName), "Описание FireCompartmentShortName"},
            {nameof(ProjectParamsConfig.RoomSectionShortName), "Описание RoomSectionShortName"},
            {nameof(ProjectParamsConfig.RoomTypeGroupShortName), "Описание RoomTypeGroupShortName"},
            {nameof(ProjectParamsConfig.ApartmentAreaMinSpec), "Описание ApartmentAreaMinSpec"},
            {nameof(ProjectParamsConfig.ApartmentAreaMaxSpec), "Описание ApartmentAreaMaxSpec"},
            {nameof(ProjectParamsConfig.ApartmentAreaSpec), "Описание ApartmentAreaSpec"},
#endif
        };

        /// <summary>
        /// Содержит все типы параметров проекта.
        /// </summary>
        private static readonly Dictionary<string, StorageType> _paramTypes =
            new Dictionary<string, StorageType>() {
                {nameof(ProjectParamsConfig.ViewNumberOnSheet), StorageType.String},
                {nameof(ProjectParamsConfig.WithFullSheetNumber), StorageType.Integer},
                {nameof(ProjectParamsConfig.WithSheetNumber), StorageType.Integer},
                {nameof(ProjectParamsConfig.ViewGroup), StorageType.String},
                {nameof(ProjectParamsConfig.ProjectStage), StorageType.String},
                {nameof(ProjectParamsConfig.CheckIsNormalGrid), StorageType.Integer},
                {nameof(ProjectParamsConfig.CheckCorrectDistanceGrid), StorageType.Integer},
                {nameof(ProjectParamsConfig.RoomGroupName), StorageType.ElementId},
                {nameof(ProjectParamsConfig.FireCompartmentName), StorageType.ElementId},
                {nameof(ProjectParamsConfig.RoomSectionName), StorageType.ElementId},
                {nameof(ProjectParamsConfig.RoomTypeGroupName), StorageType.ElementId},
                {nameof(ProjectParamsConfig.RoomName), StorageType.ElementId},
                {nameof(ProjectParamsConfig.IsRoomBalcony), StorageType.Integer},
                {nameof(ProjectParamsConfig.IsRoomLiving), StorageType.Integer},
                {nameof(ProjectParamsConfig.IsRoomNumberFix), StorageType.Integer},
                {nameof(ProjectParamsConfig.NumberingOrder), StorageType.Integer},

#if D2020 || R2020 || D2021 || R2021
                {nameof(ProjectParamsConfig.RoomAreaRatio), StorageType.Double},
                {nameof(ProjectParamsConfig.ApartmentGroupName), StorageType.String},
                {nameof(ProjectParamsConfig.RoomGroupShortName), StorageType.String},
                {nameof(ProjectParamsConfig.FireCompartmentShortName), StorageType.String},
                {nameof(ProjectParamsConfig.RoomSectionShortName), StorageType.String},
                {nameof(ProjectParamsConfig.RoomTypeGroupShortName), StorageType.String},
                {nameof(ProjectParamsConfig.ApartmentAreaSpec), StorageType.String},
                {nameof(ProjectParamsConfig.ApartmentAreaMinSpec), StorageType.Double},
                {nameof(ProjectParamsConfig.ApartmentAreaMaxSpec), StorageType.Double},
#endif
            };

        /// <summary>
        /// Конструктор класса параметра проекта.
        /// </summary>
        internal ProjectParam() { }

        /// <summary>
        /// Конструктор класса параметра проекта.
        /// </summary>
        /// <param name="storageType">Тип параметра проекта.</param>
        internal ProjectParam(StorageType storageType) {
            _storageType = storageType;
        }

        /// <inheritdoc/>
        [JsonIgnore]
        public override string Description => _description.TryGetValue(Id, out string value) ? value : null;

        /// <inheritdoc/>
        [JsonIgnore]
        public override StorageType StorageType => GetStorageType();

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.IsExistsProjectParam(Name);
        }

        /// <inheritdoc/>
        public override (Definition Definition, Binding Binding) GetParamBinding(Document document) {
            return document.GetProjectParamBinding(Name);
        }

        /// <inheritdoc/>
        public override ParameterElement GetRevitParamElement(Document document) {
            return document.GetProjectParam(Name);
        }

        /// <summary>
        /// Проверяет является ли определение параметра параметром проекта.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является параметром проекта, иначе false.</returns>
        public override bool IsRevitParam(Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return base.IsRevitParam(document, definition) && document.IsProjectParamDefinition(definition);
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

            if(param.StorageType != StorageType) {
                throw new ArgumentException(
                    $"Переданный Параметр проекта \"{Name}\" не соответствует типу параметра у элемента.");
            }

            return param;
        }
        
        private StorageType GetStorageType() {
            if(_storageType == null) {
                return _paramTypes.TryGetValue(Id, out StorageType value) ? value : StorageType.None;
            }

            return _storageType.Value;
        }
    }
}