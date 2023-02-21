using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

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

#if REVIT_2020
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
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.ApartmentGroupName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomGroupShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.FireCompartmentShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomSectionShortName):
                    return UnitType.UT_Number;
                case nameof(SharedParamsConfig.RoomTypeGroupShortName):
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
                default:
                    throw new ArgumentException($"Не найден общий параметр с идентификатором \"{paramId}\".",
                        nameof(paramId));
            }
        }

#elif REVIT_2021
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
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.ApartmentGroupName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomGroupShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.FireCompartmentShortName):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.RoomSectionShortName):
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
                case nameof(SharedParamsConfig.Level):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomsCount):
                    return SpecTypeId.Int.Integer;
                case nameof(SharedParamsConfig.ApartmentGroupName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomGroupShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.FireCompartmentShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomSectionShortName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.RoomTypeGroupShortName):
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
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISMinDuctThickness):
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.VISCombinedName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISSpecNumbers):
                    return SpecTypeId.Number;
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
                    return SpecTypeId.Number;
                case nameof(SharedParamsConfig.FixComment):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISOutSystemName):
                    return SpecTypeId.String.Text;
                case nameof(SharedParamsConfig.VISSystemShortName):
                    return SpecTypeId.String.Text;
                default:
                    throw new ArgumentException($"Не найден общий параметр с идентификатором \"{paramId}\".",
                        nameof(paramId));
            }
        }

#endif
    }
}