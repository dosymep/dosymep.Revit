using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.SharedParams {
    /// <summary>
    /// Класс общего параметра
    /// </summary>
    public class SharedParam : RevitParam {
        /// <summary>
        /// Конструктор класса общего параметра.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        /// <param name="guid">Guid общего параметра.</param>
        [JsonConstructor]
        internal SharedParam(string id, Guid guid)
            : base(id) {
            Guid = guid;
        }

        /// <summary>
        /// Guid общего параметра.
        /// </summary>
        public Guid Guid { get; }

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.IsExistsSharedParam(Guid) || document.IsExistsSharedParam(Name);
        }

        /// <inheritdoc/>
        public override (Definition Definition, Binding Binding) GetParamBinding(Document document) {
            return document.GetSharedParamBinding(Name);
        }

        /// <inheritdoc/>
        public override ParameterElement GetRevitParamElement(Document document) {
            return document.GetSharedParam(Guid) ?? document.GetSharedParam(Name);
        }

        /// <summary>
        /// Проверяет является ли определение параметра общим параметром.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является общим параметром, иначе false.</returns>
        public override bool IsRevitParam(Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return base.IsRevitParam(document, definition) && document.IsSharedParamDefinition(definition);
        }

        /// <inheritdoc/>
        public override Parameter GetParam(Element element) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            Parameter param = null;
            try {
                param = element.GetSharedParam(Guid);
            } catch(System.ArgumentException) {
                try {
                    param = element.GetSharedParam(Name);
                } catch(System.ArgumentException) {
                }
            }

            if(param is null) {
                throw new ArgumentException(
                    $"Общий параметр с заданным именем \"{Name}\" или Guid \"{Guid}\" не был найден.");
            }

            if(param.StorageType != StorageType) {
                throw new ArgumentException(
                    $"Переданный общий параметр \"{Name}\" или Guid \"{Guid}\" не соответствует типу параметра у элемента.");
            }

            return param;
        }

        /// <summary>
        /// Возвращает описание общего параметра из ФОП.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает описание общего параметра из ФОП.</returns>
        public ExternalDefinition GetExternalDefinition(Application application) {
            DefinitionFile definitionFile = application.OpenSharedParameterFile();

            ExternalDefinition[] definitions = definitionFile.Groups
                .SelectMany(item => item.Definitions)
                .OfType<ExternalDefinition>()
                .ToArray();

            return definitions.FirstOrDefault(item => item.GUID.Equals(Guid))
                   ?? definitions.FirstOrDefault(item => item.Name.Equals(Name));
        }

        /// <summary>
        /// Возвращает описание общего параметра из ФОП.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <param name="groupName">Наименование группы параметров.</param>
        /// <returns>Возвращает описание общего параметра из ФОП.</returns>
        public ExternalDefinition GetExternalDefinition(Application application, string groupName) {
            DefinitionFile definitionFile = application.OpenSharedParameterFile();

            return definitionFile.Groups.get_Item(groupName).Definitions
                       .OfType<ExternalDefinition>()
                       .FirstOrDefault(item => item.GUID == Guid)
                   ?? (ExternalDefinition) definitionFile.Groups.get_Item(groupName)?.Definitions.get_Item(Name);
        }
        
        #region Serialization

        /// <summary>
        /// Метод чтения параметра из json
        /// </summary>
        /// <param name="token">Токен</param>
        /// <param name="serializer">Сериализатор</param>
        internal static RevitParam ReadFromJson(JObject token, JsonSerializer serializer) {
            return RevitParam.ReadFromJson(
                token, serializer, new SharedParam(
                    token.Value<string>(nameof(Id)), token[nameof(Guid)].ToObject<Guid>(serializer)));
        }

        /// <inheritdoc />
        protected override void SaveToJsonImpl(JsonWriter writer, JsonSerializer serializer) {
            writer.WritePropertyName(nameof(Guid));
            writer.WriteValue(Guid);
        }
        
        #endregion

#if REVIT2020
        /// <summary>
        /// Возвращает единицу измерения параметра по его идентификатору.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        /// <returns>Возвращает единицу измерения параметра по его идентификатору.</returns>
        internal static UnitType GetUnitType(string paramId) {
            switch(paramId) {
                case nameof(SharedParamsConfig.AlbumBlueprints):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.StampSheetNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.MechanicalSystemName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomArea):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.RoomAreaWithRatio):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.RoomAreaRatio):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.ApartmentAreaRatio):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentAreaNoBalcony):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentLivingArea):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentArea):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentFullArea):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.ApartmentNumberExtra):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.Level):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomsCount):
                    return UnitType.UT_Currency;
                case nameof(SharedParamsConfig.ApartmentGroupName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomGroupShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.FireCompartmentShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomSectionShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomBuildingShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomTypeGroupShortName):
                    return UnitType.UT_Number;                
                case nameof(SharedParamsConfig.RoomMultilevelGroup):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.ApartmentAreaSpec):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.ApartmentAreaMaxSpec):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentAreaMinSpec):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.VISGrouping):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISUnit):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISMass):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISMinDuctThickness):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISCombinedName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISSpecNumbers):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISSpecNumbersCurrency):
                    return UnitType.UT_Currency;
                case nameof(SharedParamsConfig.ApartmentAreaFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentAreaNoBalconyFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentFullAreaFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentAreaRatioFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.ApartmentLivingAreaFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.RoomAreaFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.RoomAreaWithRatioFix):
                    return UnitType.UT_Area;
                case nameof(SharedParamsConfig.BuildingWorksBlock):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.BuildingWorksSection):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.BuildingWorksTyping):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.BuildingWorksLevel):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.FixBuildingWorks):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.FixComment):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISOutSystemName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISSystemShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISCrossSection):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISLocalResistanceCoef):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISEconomicFunction):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISHvacSystemFunction):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISHvacSystemForcedFunction):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISSystemName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISSystemNameForced):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISItemCode):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISManufacturer):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISGroupingForced):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISNameForced):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISNameAddition):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISMarkAxisToZero):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISMarkBottomToZero):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISPosition):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISMarkNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISNote):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISIndividualStock):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISMaxDuctThickness):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISJunction):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISExcludeFromJunction):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISDiameterNominal):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISDiameterNominalXThikness):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISDiameterExternalXThikness):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISIsPipeNameFromSegment):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISIsPaintCalculation):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISIsClampsCalculation):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISIsFasteningMetalCalculation):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISConsiderPipeFittingsByType):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISConsiderDuctFittings):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISConsiderPipeFittings):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationReserve):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISDuctInsulationReserve):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISPipeInsulationReserve):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISPipeDuctReserve):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISParamReplacementUnit):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISParamReplacementManufacturer):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISParamReplacementItemCode):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISParamReplacementMarkNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISParamReplacementName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Name):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1MarkNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Manufacturer):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Unit):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1ConsumptionPerSqM):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1ConsumptionPerMetr):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Name):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2MarkNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Manufacturer):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Unit):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2ConsumptionPerSqM):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2ConsumptionPerMetr):
                    return UnitType.UT_Number;                
                case nameof(SharedParamsConfig.VISInsulationConsumable3Name):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3MarkNumber):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3Manufacturer):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3Unit):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3ConsumptionPerSqM):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3ConsumptionPerMetr):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.EconomicFunction):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.ElementMirroring):
                    return UnitType.UT_Currency;
                default:
                    throw new ArgumentException($"Не найден общий параметр с идентификатором \"{paramId}\".",
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
                case nameof(SharedParamsConfig.AlbumBlueprints):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.StampSheetNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.MechanicalSystemName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaWithRatio):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaRatio):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ApartmentAreaRatio):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaNoBalcony):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentLivingArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentFullArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ApartmentNumberExtra):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.Level):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomsCount):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.ApartmentGroupName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomGroupShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomMultilevelGroup):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.FireCompartmentShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomSectionShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomBuildingShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomTypeGroupShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ApartmentAreaSpec):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ApartmentAreaMaxSpec):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaMinSpec):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.VISGrouping):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISUnit):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMass):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMinDuctThickness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISCombinedName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISSpecNumbers):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISSpecNumbersCurrency):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.ApartmentAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaNoBalconyFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentFullAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaRatioFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentLivingAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaWithRatioFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.BuildingWorksBlock):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.BuildingWorksSection):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.BuildingWorksTyping):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.BuildingWorksLevel):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.FixBuildingWorks):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.FixComment):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISOutSystemName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISSystemShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISCrossSection):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISLocalResistanceCoef):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISEconomicFunction):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISHvacSystemFunction):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISHvacSystemForcedFunction):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISSystemName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISSystemNameForced):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISItemCode):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISManufacturer):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISGroupingForced):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISNameForced):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISNameAddition):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMarkAxisToZero):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMarkBottomToZero):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISPosition):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMarkNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISNote):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISIndividualStock):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMaxDuctThickness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISJunction):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISExcludeFromJunction):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISDiameterNominal):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISDiameterNominalXThikness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISDiameterExternalXThikness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISIsPipeNameFromSegment):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISIsPaintCalculation):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISIsClampsCalculation):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISIsFasteningMetalCalculation):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISConsiderPipeFittingsByType):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISConsiderDuctFittings):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISConsiderPipeFittings):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISDuctInsulationReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISPipeInsulationReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISPipeDuctReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISParamReplacementUnit):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISParamReplacementManufacturer):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISParamReplacementItemCode):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISParamReplacementMarkNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISParamReplacementName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Name):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1MarkNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Manufacturer):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Unit):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1ConsumptionPerSqM):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1ConsumptionPerMetr):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Name):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2MarkNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Manufacturer):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Unit):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2ConsumptionPerSqM):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2ConsumptionPerMetr):
                    return SpecTypeId.Number;                
                case nameof(SharedParamsConfig.VISInsulationConsumable3Name):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3MarkNumber):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3Manufacturer):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3Unit):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3ConsumptionPerSqM):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3ConsumptionPerMetr):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.EconomicFunction):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ElementMirroring):
                    return SpecTypeId.Currency;
                default:
                    throw new ArgumentException($"Не найден общий параметр с идентификатором \"{paramId}\".",
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
                case nameof(SharedParamsConfig.AlbumBlueprints):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.MechanicalSystemName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaWithRatio):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaRatio):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ApartmentAreaRatio):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaNoBalcony):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentLivingArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentFullArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.ApartmentNumberExtra):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.ApartmentNameExtra):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.Level):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomsCount):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.ApartmentGroupName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomGroupShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FireCompartmentShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomSectionShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomBuildingShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomTypeGroupShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomMultilevelGroup):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.ApartmentAreaSpec):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.ApartmentAreaMaxSpec):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaMinSpec):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.VISGrouping):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISUnit):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISMass):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISMinDuctThickness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISCombinedName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISSpecNumbers):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISSpecNumbersCurrency):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.ApartmentAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaNoBalconyFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentFullAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentAreaRatioFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.ApartmentLivingAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.RoomAreaWithRatioFix):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.BuildingWorksBlock):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.BuildingWorksSection):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.BuildingWorksTyping):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.BuildingWorksLevel):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FixBuildingWorks):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.FixComment):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISOutSystemName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISSystemShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FloorFinishingType1):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FloorFinishingType2):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.CeilingFinishingType1):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.CeilingFinishingType2):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType1):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType2):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType3):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType4):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType5):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType6):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType7):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType8):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType9):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.WallFinishingType10):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.BaseboardFinishingType1):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.BaseboardFinishingType2):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FinishingRoomName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FinishingRoomNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FinishingRoomNames):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FinishingRoomNumbers):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FinishingType):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FloorFinishingOrder):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.CeilingFinishingOrder):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.WallFinishingOrder):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.BaseboardFinishingOrder):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.SizeLengthAdditional):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.SizeArea):
                    return SpecTypeId.Area;
                case nameof(SharedParamsConfig.SizeVolume):
                    return SpecTypeId.Volume;
                case nameof(SharedParamsConfig.SizeLength):
                    return SpecTypeId.Length;
                case nameof(SharedParamsConfig.SizeWidth):
                    return SpecTypeId.Length;
                case nameof(SharedParamsConfig.SizeHeight):
                    return SpecTypeId.Length;
                case nameof(SharedParamsConfig.VISCrossSection):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISLocalResistanceCoef):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISEconomicFunction):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISHvacSystemFunction):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISHvacSystemForcedFunction):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISSystemName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISSystemNameForced):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISItemCode):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISManufacturer):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISGroupingForced):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISNameForced):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISNameAddition):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISMarkAxisToZero):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMarkBottomToZero):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISPosition):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISMarkNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISNote):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISIndividualStock):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMaxDuctThickness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISJunction):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISExcludeFromJunction):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISDiameterNominal):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISDiameterNominalXThikness):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISDiameterExternalXThikness):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISIsPipeNameFromSegment):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISIsPaintCalculation):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISIsClampsCalculation):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISIsFasteningMetalCalculation):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISConsiderPipeFittingsByType):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISConsiderDuctFittings):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISConsiderPipeFittings):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISInsulationReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISDuctInsulationReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISPipeInsulationReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISPipeDuctReserve):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISParamReplacementUnit):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISParamReplacementManufacturer):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISParamReplacementItemCode):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISParamReplacementMarkNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISParamReplacementName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Name):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable1MarkNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Manufacturer):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable1Unit):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable1ConsumptionPerSqM):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable1ConsumptionPerMetr):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Name):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable2MarkNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Manufacturer):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable2Unit):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable2ConsumptionPerSqM):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable2ConsumptionPerMetr):
                    return SpecTypeId.Boolean.YesNo;                
                case nameof(SharedParamsConfig.VISInsulationConsumable3Name):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable3MarkNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable3Manufacturer):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable3Unit):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISInsulationConsumable3ConsumptionPerSqM):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISInsulationConsumable3ConsumptionPerMetr):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.EconomicFunction):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.BuildingNumber):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.ConstructionWorksNumber):
                    return SpecTypeId.String.Text;                
                case nameof(SharedParamsConfig.ParkingSpaceClass):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.ElementMirroring):
                    return SpecTypeId.Currency;
                case nameof(SharedParamsConfig.VISTaskSSDate):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISTaskSSMark):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISTaskSSAdd):
                    return SpecTypeId.Boolean.YesNo;
                case nameof(SharedParamsConfig.StampSheetRevision1):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision2):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision3):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision4):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision5):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision6):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision7):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevision8):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue1):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue2):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue3):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue4):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue5):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue6):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue7):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.StampSheetRevisionValue8):
                    return SpecTypeId.String.Text;
                default:
                    throw new ArgumentException($"Не найден общий параметр с идентификатором \"{paramId}\".",
                        nameof(paramId));
            }
        }

#endif
    }
}