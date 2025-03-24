using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.ProjectParams {
    /// <summary>
    /// Класс параметров проекта Revit.
    /// </summary>
    public class ProjectParam : RevitParam {
        /// <summary>
        /// Конструктор класса параметра проекта.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        [JsonConstructor]
        internal ProjectParam(string id)
            : base(id) {
        }

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
        
        #region Serialization

        /// <summary>
        /// Метод чтения параметра из json
        /// </summary>
        /// <param name="token">Токен</param>
        /// <param name="serializer">Сериализатор</param>
        internal static RevitParam ReadFromJson(JObject token, JsonSerializer serializer) {
            return RevitParam.ReadFromJson(token, serializer, new ProjectParam(token.Value<string>(nameof(Id))));
        }

        /// <inheritdoc />
        protected override void SaveToJsonImpl(JsonWriter writer, JsonSerializer serializer) { }

        #endregion

#if REVIT2020

        /// <summary>
        /// Возвращает единицу измерения параметра по его идентификатору.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        /// <returns>Возвращает единицу измерения параметра по его идентификатору.</returns>
        internal static UnitType GetUnitType(string paramId) {
            switch(paramId) {
                case nameof(ProjectParamsConfig.ViewGroup):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.ProjectStage):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.ViewNumberOnSheet):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.WithFullSheetNumber):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.WithSheetNumber):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomAreaRatio):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.IsRoomBalcony):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.IsRoomLiving):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomGroupShortName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.ApartmentGroupName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomSectionShortName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomTypeGroupShortName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.FireCompartmentShortName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.ApartmentAreaSpec):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.ApartmentAreaMinSpec):
                    return UnitType.UT_Area;
                case nameof(ProjectParamsConfig.ApartmentAreaMaxSpec):
                    return UnitType.UT_Area;
                case nameof(ProjectParamsConfig.IsRoomNumberFix):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.IsRoomLevelFix):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.NumberingOrder):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.IsRoomMainLevel):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.CheckCorrectDistanceGrid):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.CheckIsNormalGrid):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomGroupName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.FireCompartmentName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomSectionName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomTypeGroupName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RoomName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RelatedRoomName):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RelatedRoomNumber):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RelatedRoomID):
                    return UnitType.UT_Number;
                case nameof(ProjectParamsConfig.RelatedRoomGroup):
                    return UnitType.UT_Number;
                default:
                    throw new ArgumentException($"Не найден параметр проекта с идентификатором \"{paramId}\".",
                        nameof(paramId));
            }
        }
        
#elif REVIT2021
        
        /// <summary>
        /// Возвращает единицу измерения параметра по его идентификатору.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        /// <returns>Возвращает единицу измерения параметра по его идентификатору.</returns>
        internal static ForgeTypeId GetUnitType(string paramId) {
            switch(paramId) {
                case nameof(ProjectParamsConfig.ViewGroup):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.ProjectStage):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.ViewNumberOnSheet):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.WithFullSheetNumber):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.WithSheetNumber):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomAreaRatio):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.IsRoomBalcony):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.IsRoomLiving):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomGroupShortName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.ApartmentGroupName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomSectionShortName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomTypeGroupShortName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.FireCompartmentShortName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.ApartmentAreaSpec):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.ApartmentAreaMinSpec):
                    return SpecTypeId.Area;
                case nameof(ProjectParamsConfig.ApartmentAreaMaxSpec):
                    return SpecTypeId.Area;
                case nameof(ProjectParamsConfig.IsRoomNumberFix):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.IsRoomLevelFix):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.NumberingOrder):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.IsRoomMainLevel):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.CheckCorrectDistanceGrid):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.CheckIsNormalGrid):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomGroupName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.FireCompartmentName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomSectionName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomTypeGroupName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RoomName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RelatedRoomName):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RelatedRoomNumber):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RelatedRoomID):
                    return SpecTypeId.Number;
                case nameof(ProjectParamsConfig.RelatedRoomGroup):
                    return SpecTypeId.Number;
                default:
                    throw new ArgumentException($"Не найден параметр проекта с идентификатором \"{paramId}\".",
                        nameof(paramId));
            }
        }

#else

        /// <summary>
        /// Возвращает единицу измерения параметра по его идентификатору.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        /// <returns>Возвращает единицу измерения параметра по его идентификатору.</returns>
        internal static ForgeTypeId GetUnitType(string paramId) {
            switch(paramId) {
                case nameof(ProjectParamsConfig.ViewGroup):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.ProjectStage):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.ViewNumberOnSheet):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.WithFullSheetNumber):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.WithSheetNumber):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.IsRoomBalcony):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.IsRoomLiving):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.IsRoomNumberFix):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.IsRoomLevelFix):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.NumberingOrder):
                    return SpecTypeId.Int.Integer;
                case nameof(ProjectParamsConfig.IsRoomMainLevel):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(ProjectParamsConfig.CheckIsNormalGrid):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.CheckCorrectDistanceGrid):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.RelatedRoomName):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.RelatedRoomNumber):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.RelatedRoomID):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.RelatedRoomGroup):
                    return SpecTypeId.String.Text;
                case nameof(ProjectParamsConfig.RoomGroupName):
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case nameof(ProjectParamsConfig.FireCompartmentName):
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case nameof(ProjectParamsConfig.RoomSectionName):
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case nameof(ProjectParamsConfig.RoomTypeGroupName):
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case nameof(ProjectParamsConfig.RoomName):
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case nameof(ProjectParamsConfig.RoomFinishingType):
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                default:
                    throw new ArgumentException($"Не найден параметр проекта с идентификатором \"{paramId}\".",
                        nameof(paramId));
            }
        }

#endif
    }
}