using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.SimpleServices;
using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SharedParams {
    /// <summary>
    /// Конфигурация общих параметров.
    /// </summary>
    public class SharedParamsConfig : RevitParamsConfig, ISharedParamsService {
        internal SharedParamsConfig() {
            _revitParams = new Dictionary<string, RevitParam>();
        }

        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="LoadInstance(string)"/></remarks>
        public static SharedParamsConfig Instance { get; internal set; }

        /// <summary>
        /// ADSK_Комплект чертежей
        /// </summary>
        public SharedParam AlbumBlueprints
            { get; private set; } = new SharedParam(nameof(AlbumBlueprints), new Guid("e1b06433-f527-403c-8986-af9a01e6be7f")) {
                Name = "ADSK_Комплект чертежей",
                UnitType = SharedParam.GetUnitType(nameof(AlbumBlueprints)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_КВР_Площадь без коэф.
        /// </summary>
        public SharedParam ApartmentArea
            { get; private set; } = new SharedParam(nameof(ApartmentArea), new Guid("603c712b-657c-4195-b153-30950ae5f4cb")) {
                Name = "ФОП_КВР_Площадь без коэф.",
                UnitType = SharedParam.GetUnitType(nameof(ApartmentArea)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь без коэф.
        /// </summary>
        public SharedParam ApartmentAreaFix
            { get; private set; } = new SharedParam(nameof(ApartmentAreaFix), new Guid("3d6c5084-d6ab-490e-baa6-f8d119a0d628")) {
                Name = "ФОП_ФИКС_КВР_Площадь без коэф.", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ макс
        /// </summary>
        public SharedParam ApartmentAreaMaxSpec
            { get; private set; } = new SharedParam(nameof(ApartmentAreaMaxSpec), new Guid("2a6f369d-9065-4b55-a7d3-33db24751a98")) {
                Name = "ФОП_КВР_Площадь по ТЗ макс", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaMaxSpec)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ мин
        /// </summary>
        public SharedParam ApartmentAreaMinSpec
            { get; private set; } = new SharedParam(nameof(ApartmentAreaMinSpec), new Guid("24508a72-b07c-460a-a580-d5ae2d54ab94")) {
                Name = "ФОП_КВР_Площадь по ТЗ мин", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaMinSpec)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь без ЛП
        /// </summary>
        public SharedParam ApartmentAreaNoBalcony
            { get; private set; } = new SharedParam(nameof(ApartmentAreaNoBalcony), new Guid("374fc833-240a-4d71-95fc-7d349456ca7e")) {
                Name = "ФОП_КВР_Площадь без ЛП", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaNoBalcony)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь без ЛП
        /// </summary>
        public SharedParam ApartmentAreaNoBalconyFix
            { get; private set; } = new SharedParam(nameof(ApartmentAreaNoBalconyFix),
                new Guid("8226f116-c19e-4797-a3bb-55ac79acdf44")) {
                Name = "ФОП_ФИКС_КВР_Площадь без ЛП", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaNoBalconyFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь с коэф.
        /// </summary>
        public SharedParam ApartmentAreaRatio
            { get; private set; } = new SharedParam(nameof(ApartmentAreaRatio), new Guid("80be4e2b-0656-45d2-90e6-e372685b03aa")) {
                Name = "ФОП_КВР_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaRatio)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь с коэф.
        /// </summary>
        public SharedParam ApartmentAreaRatioFix
            { get; private set; } = new SharedParam(nameof(ApartmentAreaRatioFix), new Guid("77713404-35ef-4c8a-a5c4-c6f3d4da16c2")) {
                Name = "ФОП_ФИКС_КВР_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaRatioFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ
        /// </summary>
        public SharedParam ApartmentAreaSpec
            { get; private set; } = new SharedParam(nameof(ApartmentAreaSpec), new Guid("f6616ef6-481c-4133-81f9-c258790822e2")) {
                Name = "ФОП_КВР_Площадь по ТЗ", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaSpec)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_КВР_Площадь по пятну
        /// </summary>
        public SharedParam ApartmentFullArea
            { get; private set; } = new SharedParam(nameof(ApartmentFullArea), new Guid("317ce3f3-b540-4a5d-9cba-15cd273d0e4e")) {
                Name = "ФОП_КВР_Площадь по пятну", UnitType = SharedParam.GetUnitType(nameof(ApartmentFullArea)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь по пятну
        /// </summary>
        public SharedParam ApartmentFullAreaFix
            { get; private set; } = new SharedParam(nameof(ApartmentFullAreaFix), new Guid("bc1bf705-37a8-404e-af7c-ca072168b994")) {
                Name = "ФОП_ФИКС_КВР_Площадь по пятну", UnitType = SharedParam.GetUnitType(nameof(ApartmentFullAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Доп. сортировка групп
        /// </summary>
        public SharedParam ApartmentGroupName
            { get; private set; } = new SharedParam(nameof(ApartmentGroupName), new Guid("a3cb8c52-4c45-42ff-abc0-a569cd122763")) {
                Name = "ФОП_Доп. сортировка групп", UnitType = SharedParam.GetUnitType(nameof(ApartmentGroupName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_КВР_Площадь жилая
        /// </summary>
        public SharedParam ApartmentLivingArea
            { get; private set; } = new SharedParam(nameof(ApartmentLivingArea), new Guid("3e43f7d6-6dfe-4b88-a874-7c54272789b7")) {
                Name = "ФОП_КВР_Площадь жилая", UnitType = SharedParam.GetUnitType(nameof(ApartmentLivingArea)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь жилая
        /// </summary>
        public SharedParam ApartmentLivingAreaFix
            { get; private set; } = new SharedParam(nameof(ApartmentLivingAreaFix), new Guid("421ec146-2f9b-48ae-9bcc-1f478c115e7e")) {
                Name = "ФОП_ФИКС_КВР_Площадь жилая", UnitType = SharedParam.GetUnitType(nameof(ApartmentLivingAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Номер квартиры
        /// </summary>
        public SharedParam ApartmentNumber
            { get; private set; } = new SharedParam(nameof(ApartmentNumber), new Guid("083c183f-d3d3-4710-9efc-f21ade3680f9")) {
                Name = "ФОП_Номер квартиры", UnitType = SharedParam.GetUnitType(nameof(ApartmentNumber)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Доп. номер помещения
        /// </summary>
        public SharedParam ApartmentNumberExtra
            { get; private set; } = new SharedParam(nameof(ApartmentNumberExtra), new Guid("735e1a5f-e5f6-44b6-b94f-bb810db5bafc")) {
                Name = "ФОП_Доп. номер помещения", UnitType = SharedParam.GetUnitType(nameof(ApartmentNumberExtra)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Блок СМР
        /// </summary>
        public SharedParam BuildingWorksBlock
            { get; private set; } = new SharedParam(nameof(BuildingWorksBlock), new Guid("e8385ba7-d468-4dc9-862d-4d8673db398e")) {
                Name = "ФОП_Блок СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksBlock)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Секция СМР
        /// </summary>
        public SharedParam BuildingWorksSection
            { get; private set; } = new SharedParam(nameof(BuildingWorksSection), new Guid("fc159fc9-4163-4886-aad4-081c33716eaf")) {
                Name = "ФОП_Секция СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksSection)), StorageType = StorageType.String
            };
        
        /// <summary>
        /// ФОП_Типизация СМР
        /// </summary>
        public SharedParam BuildingWorksTyping
            { get; private set; } = new SharedParam(nameof(BuildingWorksTyping), new Guid("2e5cc8dc-7598-4d94-887b-d239bcf4de76")) {
                Name = "ФОП_Типизация СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksTyping)), StorageType = StorageType.String
            };
        
        /// <summary>
        /// ФОП_Фиксация координаты СМР
        /// </summary>
        public SharedParam FixBuildingWorks
            { get; private set; } = new SharedParam(nameof(FixBuildingWorks), new Guid("ff9554f5-b037-40d3-ad9f-c46ebc5d8244")) {
                Name = "ФОП_Фиксация координаты СМР", UnitType = SharedParam.GetUnitType(nameof(FixBuildingWorks)), StorageType = StorageType.Integer
            };
        
        /// <summary>
        /// ФОП_Этаж СМР
        /// </summary>
        public SharedParam BuildingWorksLevel
            { get; private set; } = new SharedParam(nameof(BuildingWorksLevel), new Guid("326da28a-41b9-40af-9ac9-2ef7e16d50e8")) {
                Name = "ФОП_Этаж СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksLevel)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ФИКС_Комментарии
        /// </summary>
        public SharedParam FixComment
            { get; private set; } = new SharedParam(nameof(FixComment), new Guid("9aa1f257-c6bd-4ca7-b958-4bcb17cf1c32")) {
                Name = "ФОП_ФИКС_Комментарии", UnitType = SharedParam.GetUnitType(nameof(FixComment)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Пожарный отсек
        /// </summary>
        public SharedParam FireCompartmentShortName
            { get; private set; } = new SharedParam(nameof(FireCompartmentShortName),
                new Guid("b750a7c4-e882-4952-a773-07f060946ad7")) {
                Name = "ФОП_Пожарный отсек", UnitType = SharedParam.GetUnitType(nameof(FireCompartmentShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Этаж
        /// </summary>
        public SharedParam Level
            { get; private set; } = new SharedParam(nameof(Level), new Guid("248ddd42-5597-4eba-bba2-818056f8586c")) {
                Name = "ФОП_Этаж", UnitType = SharedParam.GetUnitType(nameof(Level)), StorageType = StorageType.String
            };

        /// <summary>
        /// ADSK_Имя системы
        /// </summary>
        public SharedParam MechanicalSystemName
            { get; private set; } = new SharedParam(nameof(MechanicalSystemName), new Guid("4be4ed4d-c509-4ef3-a55d-23d3a406b83c")) {
                Name = "ADSK_Имя системы", UnitType = SharedParam.GetUnitType(nameof(MechanicalSystemName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ПМЩ_Площадь
        /// </summary>
        public SharedParam RoomArea
            { get; private set; } = new SharedParam(nameof(RoomArea), new Guid("88698162-c32d-45df-9db6-2ddb07b04d17")) {
                Name = "ФОП_ПМЩ_Площадь", UnitType = SharedParam.GetUnitType(nameof(RoomArea)), StorageType = StorageType.Double
            };


        /// <summary>
        /// ФОП_ФИКС_ПМЩ_Площадь
        /// </summary>
        public SharedParam RoomAreaFix
            { get; private set; } = new SharedParam(nameof(RoomAreaFix), new Guid("64bf4d4d-6ef3-4cfd-b452-eccdde94a8ad")) {
                Name = "ФОП_ФИКС_ПМЩ_Площадь", UnitType = SharedParam.GetUnitType(nameof(RoomAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Коэффициент площади
        /// </summary>
        public SharedParam RoomAreaRatio
            { get; private set; } = new SharedParam(nameof(RoomAreaRatio), new Guid("3a8a1879-1802-4bc6-9c1a-c375dc1a9292")) {
                Name = "ФОП_Коэффициент площади", UnitType = SharedParam.GetUnitType(nameof(RoomAreaRatio)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ПМЩ_Площадь с коэф.
        /// </summary>
        public SharedParam RoomAreaWithRatio
            { get; private set; } = new SharedParam(nameof(RoomAreaWithRatio), new Guid("aa4729e4-4964-43c1-a706-4b45d0567771")) {
                Name = "ФОП_ПМЩ_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(RoomAreaWithRatio)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_ПМЩ_Площадь с коэф.
        /// </summary>
        public SharedParam RoomAreaWithRatioFix
            { get; private set; } = new SharedParam(nameof(RoomAreaWithRatioFix), new Guid("46bc1213-6d5a-4164-84d0-598a9abcf70d")) {
                Name = "ФОП_ФИКС_ПМЩ_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(RoomAreaWithRatioFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ПМЩ_Группа
        /// </summary>
        public SharedParam RoomGroupShortName
            { get; private set; } = new SharedParam(nameof(RoomGroupShortName), new Guid("c7955ded-0589-4d86-93a1-7d205d5852e2")) {
                Name = "ФОП_ПМЩ_Группа", UnitType = SharedParam.GetUnitType(nameof(RoomGroupShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ПМЩ_Секция
        /// </summary>
        public SharedParam RoomSectionShortName
            { get; private set; } = new SharedParam(nameof(RoomSectionShortName), new Guid("c39f32dd-a2b7-4853-8dc0-13c63c052eb2")) {
                Name = "ФОП_ПМЩ_Секция", UnitType = SharedParam.GetUnitType(nameof(RoomSectionShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ПМЩ_Корпус
        /// </summary>
        public SharedParam RoomBuildingShortName
            { get; private set; } = new SharedParam(nameof(RoomBuildingShortName), new Guid("a3486213-68bc-4ad6-8019-bb5144fb67c0")) {
                Name = "ФОП_ПМЩ_Корпус", UnitType = SharedParam.GetUnitType(nameof(RoomBuildingShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Тип группы помещений
        /// </summary>
        public SharedParam RoomTypeGroupShortName
            { get; private set; } = new SharedParam(nameof(RoomTypeGroupShortName), new Guid("2e36a08a-94c0-4b35-a082-e5e3d51765cf")) {
                Name = "ФОП_Тип группы помещений", UnitType = SharedParam.GetUnitType(nameof(RoomTypeGroupShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Многоуровневая группа
        /// </summary>
        public SharedParam RoomMultilevelGroup
            { get; private set; } = new SharedParam(nameof(RoomMultilevelGroup), new Guid("7d6fdcf2-e138-4a79-b122-04fc8667f4dc")) {
                Name = "ФОП_Многоуровневая группа", UnitType = SharedParam.GetUnitType(nameof(RoomMultilevelGroup)),
        StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Количество комнат
        /// </summary>
        public SharedParam RoomsCount
            { get; private set; } = new SharedParam(nameof(RoomsCount), new Guid("2498f7c7-de06-42c7-93dc-5e269cadc202")) {
                Name = "ФОП_Количество комнат", UnitType = SharedParam.GetUnitType(nameof(RoomsCount)), StorageType = StorageType.Double
            };

        /// <summary>
        /// Ш.НомерЛиста
        /// </summary>
        public SharedParam StampSheetNumber
            { get; private set; } = new SharedParam(nameof(StampSheetNumber), new Guid("b6e73342-b6cd-42c5-86c5-64b04b5b88de")) {
                Name = "Ш.НомерЛиста", UnitType = SharedParam.GetUnitType(nameof(StampSheetNumber)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Наименование комбинированное
        /// </summary>
        public SharedParam VISCombinedName
            { get; private set; } = new SharedParam(nameof(VISCombinedName), new Guid("3624223b-d55a-4b60-98e7-af64d6242409")) {
                Name = "ФОП_ВИС_Наименование комбинированное",
                UnitType = SharedParam.GetUnitType(nameof(VISCombinedName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Группирование
        /// </summary>
        public SharedParam VISGrouping
            { get; private set; } = new SharedParam(nameof(VISGrouping), new Guid("7bf3d944-9973-484d-9195-66472ddd150f")) {
                Name = "ФОП_ВИС_Группирование", UnitType = SharedParam.GetUnitType(nameof(VISGrouping)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Масса
        /// </summary>
        public SharedParam VISMass
            { get; private set; } = new SharedParam(nameof(VISMass), new Guid("8aa9bea3-2478-49d4-a47b-75af34dbdad8")) {
                Name = "ФОП_ВИС_Масса", UnitType = SharedParam.GetUnitType(nameof(VISMass)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Минимальная толщина воздуховода
        /// </summary>
        public SharedParam VISMinDuctThickness
            { get; private set; } = new SharedParam(nameof(VISMinDuctThickness), new Guid("7af80795-5115-46e4-867f-f276a2510250")) {
                Name = "ФОП_ВИС_Минимальная толщина воздуховода",
                UnitType = SharedParam.GetUnitType(nameof(VISMinDuctThickness)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Число
        /// </summary>
        public SharedParam VISSpecNumbers
            { get; private set; } = new SharedParam(nameof(VISSpecNumbers), new Guid("37e09a6d-093b-432b-9647-33b70424642d")) {
                Name = "ФОП_ВИС_Число", UnitType = SharedParam.GetUnitType(nameof(VISSpecNumbers)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Число ДЕ
        /// </summary>
        public SharedParam VISSpecNumbersCurrency
            { get; private set; } = new SharedParam(nameof(VISSpecNumbersCurrency), new Guid("c3c6bfd8-fcc3-449a-9112-e45198fc8037")) {
                Name = "ФОП_ВИС_Число ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(VISSpecNumbersCurrency)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Единица измерения
        /// </summary>
        public SharedParam VISUnit
            { get; private set; } = new SharedParam(nameof(VISUnit), new Guid("02d3bf80-f03c-4055-ad5c-3dfb2c6ff26a")) {
                Name = "ФОП_ВИС_Единица измерения", UnitType = SharedParam.GetUnitType(nameof(VISUnit)), StorageType = StorageType.String
            };
        
        /// <summary>
        /// ФОП_ВИС_Имя внесистемных элементов
        /// </summary>
        public SharedParam VISOutSystemName
            { get; private set; } = new SharedParam(nameof(VISOutSystemName), new Guid("ccbdb4ac-389e-4e17-890f-bdd1c6368724")) {
                Name = "ФОП_ВИС_Имя внесистемных элементов", UnitType = SharedParam.GetUnitType(nameof(VISOutSystemName)), StorageType = StorageType.String
            };
        
        
        /// <summary>
        /// ФОП_ВИС_Сокращение для системы
        /// </summary>
        public SharedParam VISSystemShortName
            { get; private set; } = new SharedParam(nameof(VISSystemShortName), new Guid("da024aab-a886-456c-b7c1-64fcaf40383d")) {
                Name = "ФОП_ВИС_Сокращение для системы", UnitType = SharedParam.GetUnitType(nameof(VISSystemShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Живое сечение, м2
        /// </summary>
        public SharedParam VISCrossSection
            { get; private set; } = new SharedParam(nameof(VISCrossSection), new Guid("c57b0650-d5cc-4d2b-9b62-12ee6734ce93")) {
                Name = "ФОП_ВИС_Живое сечение, м2",
                UnitType = SharedParam.GetUnitType(nameof(VISCrossSection)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_КМС
        /// </summary>
        public SharedParam VISLocalResistanceCoef
            { get; private set; } = new SharedParam(nameof(VISLocalResistanceCoef), new Guid("7439de5b-9486-464e-9a40-851782cc923c")) {
                Name = "ФОП_ВИС_КМС",
                UnitType = SharedParam.GetUnitType(nameof(VISLocalResistanceCoef)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Экономическая функция
        /// </summary>
        public SharedParam VISEconomicFunction
            { get; private set; } = new SharedParam(nameof(VISEconomicFunction), new Guid("23772cae-9eaa-4f96-99ba-b65a7f44f8cf")) {
                Name = "ФОП_ВИС_Экономическая функция",
                UnitType = SharedParam.GetUnitType(nameof(VISEconomicFunction)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_ЭФ для системы
        /// </summary>
        public SharedParam VISHvacSystemFunction
            { get; private set; } = new SharedParam(nameof(VISHvacSystemFunction), new Guid("e83cce16-974a-4356-a6f8-7a1cafa3a232")) {
                Name = "ФОП_ВИС_ЭФ для системы",
                UnitType = SharedParam.GetUnitType(nameof(VISHvacSystemFunction)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_ЭФ принудительная
        /// </summary>
        public SharedParam VISHvacSystemForcedFunction
            { get; private set; } = new SharedParam(nameof(VISHvacSystemForcedFunction), new Guid("96302de2-fb03-48da-bbd0-db6d9fb9a79d")) {
                Name = "ФОП_ВИС_ЭФ принудительная",
                UnitType = SharedParam.GetUnitType(nameof(VISHvacSystemForcedFunction)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Имя системы
        /// </summary>
        public SharedParam VISSystemName
            { get; private set; } = new SharedParam(nameof(VISSystemName), new Guid("56edfca3-7f93-4fee-b82b-363bc2c1b8d9")) {
                Name = "ФОП_ВИС_Имя системы",
                UnitType = SharedParam.GetUnitType(nameof(VISSystemName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Имя системы принудительное
        /// </summary>
        public SharedParam VISSystemNameForced
            { get; private set; } = new SharedParam(nameof(VISSystemNameForced), new Guid("5f90a621-46e0-4964-95e0-a40ac5c066fe")) {
                Name = "ФОП_ВИС_Имя системы принудительное",
                UnitType = SharedParam.GetUnitType(nameof(VISSystemNameForced)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Код изделия
        /// </summary>
        public SharedParam VISItemCode
            { get; private set; } = new SharedParam(nameof(VISItemCode), new Guid("637311d8-d4ec-4996-ad7d-94b64ff8e80f")) {
                Name = "ФОП_ВИС_Код изделия",
                UnitType = SharedParam.GetUnitType(nameof(VISItemCode)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Завод-изготовитель
        /// </summary>
        public SharedParam VISManufacturer
            { get; private set; } = new SharedParam(nameof(VISManufacturer), new Guid("2b4c380c-fb24-4dd4-b238-9a81380ee678")) {
                Name = "ФОП_ВИС_Завод-изготовитель",
                UnitType = SharedParam.GetUnitType(nameof(VISManufacturer)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Группирование принудительное
        /// </summary>
        public SharedParam VISGroupingForced
            { get; private set; } = new SharedParam(nameof(VISGroupingForced), new Guid("d8f8a985-fd21-474c-95b7-fa776a8b3bd6")) {
                Name = "ФОП_ВИС_Группирование принудительное",
                UnitType = SharedParam.GetUnitType(nameof(VISGroupingForced)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Наименование принудительное
        /// </summary>
        public SharedParam VISNameForced
            { get; private set; } = new SharedParam(nameof(VISNameForced), new Guid("c8f6a5b0-718b-4482-8c5d-8359e487cf59")) {
                Name = "ФОП_ВИС_Наименование принудительное",
                UnitType = SharedParam.GetUnitType(nameof(VISNameForced)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Дополнение к имени
        /// </summary>
        public SharedParam VISNameAddition
            { get; private set; } = new SharedParam(nameof(VISNameAddition), new Guid("56f6e7aa-cffc-4595-bb22-7559d7d52284")) {
                Name = "ФОП_ВИС_Дополнение к имени",
                UnitType = SharedParam.GetUnitType(nameof(VISNameAddition)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Отметка оси от нуля
        /// </summary>
        public SharedParam VISMarkAxisToZero
            { get; private set; } = new SharedParam(nameof(VISMarkAxisToZero), new Guid("a1674535-4757-4178-8cd4-eb1aa3ed08d9")) {
                Name = "ФОП_ВИС_Отметка оси от нуля",
                UnitType = SharedParam.GetUnitType(nameof(VISMarkAxisToZero)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Отметка низа от нуля
        /// </summary>
        public SharedParam VISMarkBottomToZero
            { get; private set; } = new SharedParam(nameof(VISMarkBottomToZero), new Guid("0a5a0183-6210-4909-a7d9-75efd616cd39")) {
                Name = "ФОП_ВИС_Отметка низа от нуля",
                UnitType = SharedParam.GetUnitType(nameof(VISMarkBottomToZero)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Позиция
        /// </summary>
        public SharedParam VISPosition
            { get; private set; } = new SharedParam(nameof(VISPosition), new Guid("3f809907-b64c-4a8d-be5e-06709ee28386")) {
                Name = "ФОП_ВИС_Позиция",
                UnitType = SharedParam.GetUnitType(nameof(VISPosition)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Марка
        /// </summary>
        public SharedParam VISMarkNumber
            { get; private set; } = new SharedParam(nameof(VISMarkNumber), new Guid("c4b7716a-64db-4a8f-ae8d-aecaff39e162")) {
                Name = "ФОП_ВИС_Марка",
                UnitType = SharedParam.GetUnitType(nameof(VISMarkNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Примечание
        /// </summary>
        public SharedParam VISNote
            { get; private set; } = new SharedParam(nameof(VISNote), new Guid("9c36f220-4c81-4900-a604-4abc394ca95b")) {
                Name = "ФОП_ВИС_Примечание",
                UnitType = SharedParam.GetUnitType(nameof(VISNote)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Индивидуальный запас
        /// </summary>
        public SharedParam VISIndividualStock
            { get; private set; } = new SharedParam(nameof(VISIndividualStock), new Guid("9ff26b45-f894-4c78-a6e2-5808d77f2222")) {
                Name = "ФОП_ВИС_Индивидуальный запас",
                UnitType = SharedParam.GetUnitType(nameof(VISIndividualStock)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Максимальная толщина воздуховода
        /// </summary>
        public SharedParam VISMaxDuctThickness
            { get; private set; } = new SharedParam(nameof(VISMaxDuctThickness), new Guid("79dc7595-bcde-4bb4-a9b7-95417c7f5a8b")) {
                Name = "ФОП_ВИС_Максимальная толщина воздуховода",
                UnitType = SharedParam.GetUnitType(nameof(VISMaxDuctThickness)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Узел
        /// </summary>
        public SharedParam VISJunction
            { get; private set; } = new SharedParam(nameof(VISJunction), new Guid("c39ded76-eb20-4a21-abf3-6db36aca369b")) {
                Name = "ФОП_ВИС_Узел",
                UnitType = SharedParam.GetUnitType(nameof(VISJunction)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Исключить из узла
        /// </summary>
        public SharedParam VISExcludeFromJunction
            { get; private set; } = new SharedParam(nameof(VISExcludeFromJunction), new Guid("ebecee67-fdfc-4c3f-a102-714d9bdc44ed")) {
                Name = "ФОП_ВИС_Исключить из узла",
                UnitType = SharedParam.GetUnitType(nameof(VISExcludeFromJunction)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Ду
        /// </summary>
        public SharedParam VISDiameterNominal
            { get; private set; } = new SharedParam(nameof(VISDiameterNominal), new Guid("1ac7f9f7-fdd7-40fb-9a9c-1d704bedca90")) {
                Name = "ФОП_ВИС_Ду",
                UnitType = SharedParam.GetUnitType(nameof(VISDiameterNominal)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Ду х Стенка
        /// </summary>
        public SharedParam VISDiameterNominalXThikness
            { get; private set; } = new SharedParam(nameof(VISDiameterNominalXThikness), new Guid("049dde32-c903-4736-b1bc-5d9b4e51ffc5")) {
                Name = "ФОП_ВИС_Ду х Стенка",
                UnitType = SharedParam.GetUnitType(nameof(VISDiameterNominalXThikness)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Днар х Стенка
        /// </summary>
        public SharedParam VISDiameterExternalXThikness
            { get; private set; } = new SharedParam(nameof(VISDiameterExternalXThikness), new Guid("e3939e06-3185-48bc-b920-cb05c6b70d69")) {
                Name = "ФОП_ВИС_Днар х Стенка",
                UnitType = SharedParam.GetUnitType(nameof(VISDiameterExternalXThikness)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Имя трубы из сегмента
        /// </summary>
        public SharedParam VISIsPipeNameFromSegment
            { get; private set; } = new SharedParam(nameof(VISIsPipeNameFromSegment), new Guid("e84ed706-336f-4c35-b9c4-3ed44ff71cbb")) {
                Name = "ФОП_ВИС_Имя трубы из сегмента",
                UnitType = SharedParam.GetUnitType(nameof(VISIsPipeNameFromSegment)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Расчет краски и грунтовки
        /// </summary>
        public SharedParam VISIsPaintCalculation
            { get; private set; } = new SharedParam(nameof(VISIsPaintCalculation), new Guid("afdbc978-78fe-4824-a0f7-ad629dd42d1f")) {
                Name = "ФОП_ВИС_Расчет краски и грунтовки",
                UnitType = SharedParam.GetUnitType(nameof(VISIsPaintCalculation)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Расчет хомутов
        /// </summary>
        public SharedParam VISIsClampsCalculation
            { get; private set; } = new SharedParam(nameof(VISIsClampsCalculation), new Guid("9ee7f02e-1f56-4bf8-ae36-6e5d63aee44c")) {
                Name = "ФОП_ВИС_Расчет хомутов",
                UnitType = SharedParam.GetUnitType(nameof(VISIsClampsCalculation)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Расчет металла для креплений
        /// </summary>
        public SharedParam VISIsFasteningMetalCalculation
            { get; private set; } = new SharedParam(nameof(VISIsFasteningMetalCalculation), new Guid("e4cdcf39-3a2a-41b9-8050-3ceb82cb95e9")) {
                Name = "ФОП_ВИС_Расчет металла для креплений",
                UnitType = SharedParam.GetUnitType(nameof(VISIsFasteningMetalCalculation)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Учитывать фитинги труб по типу трубы
        /// </summary>
        public SharedParam VISConsiderPipeFittingsByType
            { get; private set; } = new SharedParam(nameof(VISConsiderPipeFittingsByType), new Guid("b09cf837-fea0-4cbc-a58c-57fed7e8fcce")) {
                Name = "ФОП_ВИС_Учитывать фитинги труб по типу трубы",
                UnitType = SharedParam.GetUnitType(nameof(VISConsiderPipeFittingsByType)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Учитывать фитинги воздуховодов
        /// </summary>
        public SharedParam VISConsiderDuctFittings
            { get; private set; } = new SharedParam(nameof(VISConsiderDuctFittings), new Guid("eb14322a-187b-4188-8b86-2c3e495d4758")) {
                Name = "ФОП_ВИС_Учитывать фитинги воздуховодов",
                UnitType = SharedParam.GetUnitType(nameof(VISConsiderDuctFittings)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Учитывать фитинги труб
        /// </summary>
        public SharedParam VISConsiderPipeFittings
            { get; private set; } = new SharedParam(nameof(VISConsiderPipeFittings), new Guid("a586535e-0af7-4cd6-b70e-4f04938f9d44")) {
                Name = "ФОП_ВИС_Учитывать фитинги труб",
                UnitType = SharedParam.GetUnitType(nameof(VISConsiderPipeFittings)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Запас изоляции
        /// </summary>
        public SharedParam VISInsulationReserve
            { get; private set; } = new SharedParam(nameof(VISInsulationReserve), new Guid("9c8bbeba-f50b-42b2-9160-9e66b66cf065")) {
                Name = "ФОП_ВИС_Запас изоляции",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationReserve)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Запас изоляции воздуховодов
        /// </summary>
        public SharedParam VISDuctInsulationReserve
            { get; private set; } = new SharedParam(nameof(VISDuctInsulationReserve), new Guid("bb0bf4d1-4874-4102-afb4-e8cda9e06009")) {
                Name = "ФОП_ВИС_Запас изоляции воздуховодов",
                UnitType = SharedParam.GetUnitType(nameof(VISDuctInsulationReserve)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Запас изоляции труб
        /// </summary>
        public SharedParam VISPipeInsulationReserve
            { get; private set; } = new SharedParam(nameof(VISPipeInsulationReserve), new Guid("cacdb0b3-3e22-44ea-a3c3-8e6de06bc10f")) {
                Name = "ФОП_ВИС_Запас изоляции труб",
                UnitType = SharedParam.GetUnitType(nameof(VISPipeInsulationReserve)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Запас воздуховодов/труб
        /// </summary>
        public SharedParam VISPipeDuctReserve
            { get; private set; } = new SharedParam(nameof(VISPipeDuctReserve), new Guid("871f822a-047b-4f76-9cf0-9d9796b4e984")) {
                Name = "ФОП_ВИС_Запас воздуховодов/труб",
                UnitType = SharedParam.GetUnitType(nameof(VISPipeDuctReserve)),
                StorageType = StorageType.Double
            };


        /// <summary>
        /// ФОП_ВИС_Замена параметра_Единица измерения
        /// </summary>
        public SharedParam VISParamReplacementUnit
            { get; private set; } = new SharedParam(nameof(VISParamReplacementUnit), new Guid("c418500a-4f16-493b-b26d-abd2f313eb7b")) {
                Name = "ФОП_ВИС_Замена параметра_Единица измерения",
                UnitType = SharedParam.GetUnitType(nameof(VISParamReplacementUnit)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Замена параметра_Завод-изготовитель
        /// </summary>
        public SharedParam VISParamReplacementManufacturer
            { get; private set; } = new SharedParam(nameof(VISParamReplacementManufacturer), new Guid("e4262902-9261-4bf4-99af-09ab749a9d46")) {
                Name = "ФОП_ВИС_Замена параметра_Завод-изготовитель",
                UnitType = SharedParam.GetUnitType(nameof(VISParamReplacementManufacturer)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Замена параметра_Код изделия
        /// </summary>
        public SharedParam VISParamReplacementItemCode
            { get; private set; } = new SharedParam(nameof(VISParamReplacementItemCode), new Guid("e70a0caa-9a9e-437b-b60f-e15e09f1d99a")) {
                Name = "ФОП_ВИС_Замена параметра_Код изделия",
                UnitType = SharedParam.GetUnitType(nameof(VISParamReplacementItemCode)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Замена параметра_Марка
        /// </summary>
        public SharedParam VISParamReplacementMarkNumber
            { get; private set; } = new SharedParam(nameof(VISParamReplacementMarkNumber), new Guid("a79cc2b7-021e-4102-a71b-1d2c685b7d53")) {
                Name = "ФОП_ВИС_Замена параметра_Марка",
                UnitType = SharedParam.GetUnitType(nameof(VISParamReplacementMarkNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Замена параметра_Наименование
        /// </summary>
        public SharedParam VISParamReplacementName
            { get; private set; } = new SharedParam(nameof(VISParamReplacementName), new Guid("9ff51aa4-40d9-43db-9697-2348cda6bc4d")) {
                Name = "ФОП_ВИС_Замена параметра_Наименование",
                UnitType = SharedParam.GetUnitType(nameof(VISParamReplacementName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 1_Наименование
        /// </summary>
        public SharedParam VISInsulationConsumable1Name
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable1Name), new Guid("2691c56f-e6c0-4a36-817b-8482ec64763c")) {
                Name = "ФОП_ВИС_Изол_Расходник 1_Наименование",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable1Name)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 1_Марка
        /// </summary>
        public SharedParam VISInsulationConsumable1MarkNumber
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable1MarkNumber), new Guid("a6bbaacf-95d0-458a-8df9-b83605588331")) {
                Name = "ФОП_ВИС_Изол_Расходник 1_Марка",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable1MarkNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 1_Изготовитель
        /// </summary>
        public SharedParam VISInsulationConsumable1Manufacturer
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable1Manufacturer), new Guid("91341b01-0c21-4815-8499-492cdd8c94b3")) {
                Name = "ФОП_ВИС_Изол_Расходник 1_Изготовитель",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable1Manufacturer)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 1_Ед. изм.
        /// </summary>
        public SharedParam VISInsulationConsumable1Unit
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable1Unit), new Guid("67b6f08b-a2a1-4513-be40-1cfbdc736130")) {
                Name = "ФОП_ВИС_Изол_Расходник 1_Ед. изм.",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable1Unit)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 1_Расход на м2
        /// </summary>
        public SharedParam VISInsulationConsumable1ConsumptionPerSqM
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable1ConsumptionPerSqM), new Guid("02aecec0-1508-40e4-8aa6-f94b87c1b61e")) {
                Name = "ФОП_ВИС_Изол_Расходник 1_Расход на м2",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable1ConsumptionPerSqM)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 1_Расход по м.п.
        /// </summary>
        public SharedParam VISInsulationConsumable1ConsumptionPerMetr
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable1ConsumptionPerMetr), new Guid("d2e92911-441f-4fea-b96e-783c29e71772")) {
                Name = "ФОП_ВИС_Изол_Расходник 1_Расход по м.п.",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable1ConsumptionPerMetr)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 2_Наименование
        /// </summary>
        public SharedParam VISInsulationConsumable2Name
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable2Name), new Guid("ea6b08ae-f3cf-480b-a6fb-2e534135218f")) {
                Name = "ФОП_ВИС_Изол_Расходник 2_Наименование",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable2Name)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 2_Марка
        /// </summary>
        public SharedParam VISInsulationConsumable2MarkNumber
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable2MarkNumber), new Guid("5e33608b-e63d-4f01-9f7b-9840341240f0")) {
                Name = "ФОП_ВИС_Изол_Расходник 2_Марка",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable2MarkNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 2_Изготовитель
        /// </summary>
        public SharedParam VISInsulationConsumable2Manufacturer
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable2Manufacturer), new Guid("de09a7d6-18ae-4dfc-addc-dcfb7f60e466")) {
                Name = "ФОП_ВИС_Изол_Расходник 2_Изготовитель",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable2Manufacturer)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 2_Ед. изм.
        /// </summary>
        public SharedParam VISInsulationConsumable2Unit
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable2Unit), new Guid("484618a7-433f-463d-be6d-070da59a46f8")) {
                Name = "ФОП_ВИС_Изол_Расходник 2_Ед. изм.",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable2Unit)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 2_Расход на м2
        /// </summary>
        public SharedParam VISInsulationConsumable2ConsumptionPerSqM
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable2ConsumptionPerSqM), new Guid("fcc08f24-fc00-46dd-a5dc-fb770d6d1b81")) {
                Name = "ФОП_ВИС_Изол_Расходник 2_Расход на м2",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable2ConsumptionPerSqM)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 2_Расход по м.п.
        /// </summary>
        public SharedParam VISInsulationConsumable2ConsumptionPerMetr
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable2ConsumptionPerMetr), new Guid("4acb1680-baa5-4668-87a5-1387300416e5")) {
                Name = "ФОП_ВИС_Изол_Расходник 2_Расход по м.п.",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable2ConsumptionPerMetr)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 3_Наименование
        /// </summary>
        public SharedParam VISInsulationConsumable3Name
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable3Name), new Guid("665fb0bb-f896-4fe6-bd94-bf2fd06eaef9")) {
                Name = "ФОП_ВИС_Изол_Расходник 3_Наименование",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable3Name)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 3_Марка
        /// </summary>
        public SharedParam VISInsulationConsumable3MarkNumber
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable3MarkNumber), new Guid("0c50fbd5-4388-43f4-919e-03dc32ac48f0")) {
                Name = "ФОП_ВИС_Изол_Расходник 3_Марка",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable3MarkNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 3_Изготовитель
        /// </summary>
        public SharedParam VISInsulationConsumable3Manufacturer
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable3Manufacturer), new Guid("34443524-f178-497a-8dac-b8b68a762b8e")) {
                Name = "ФОП_ВИС_Изол_Расходник 3_Изготовитель",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable3Manufacturer)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 3_Ед. изм.
        /// </summary>
        public SharedParam VISInsulationConsumable3Unit
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable3Unit), new Guid("86e6da57-fd7b-4ab2-92f2-d8f61061ee3a")) {
                Name = "ФОП_ВИС_Изол_Расходник 3_Ед. изм.",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable3Unit)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 3_Расход на м2
        /// </summary>
        public SharedParam VISInsulationConsumable3ConsumptionPerSqM
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable3ConsumptionPerSqM), new Guid("8f516f37-d5b6-4ca9-8437-9957073a760b")) {
                Name = "ФОП_ВИС_Изол_Расходник 3_Расход на м2",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable3ConsumptionPerSqM)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Изол_Расходник 3_Расход по м.п.
        /// </summary>
        public SharedParam VISInsulationConsumable3ConsumptionPerMetr
            { get; private set; } = new SharedParam(nameof(VISInsulationConsumable3ConsumptionPerMetr), new Guid("488e75dc-91c9-49d8-81cc-81170875c1b5")) {
                Name = "ФОП_ВИС_Изол_Расходник 3_Расход по м.п.",
                UnitType = SharedParam.GetUnitType(nameof(VISInsulationConsumable3ConsumptionPerMetr)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_Экономическая функция
        /// </summary>
        public SharedParam EconomicFunction
            { get; private set; } = new SharedParam(nameof(EconomicFunction), new Guid("75686bc4-a44c-43c1-bf5a-344f044e2a73")) {
                Name = "ФОП_Экономическая функция",
                UnitType = SharedParam.GetUnitType(nameof(EconomicFunction)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Зеркальность
        /// </summary>
        public SharedParam ElementMirroring
            { get; private set; } = new SharedParam(nameof(ElementMirroring), new Guid("ba68fa97-0493-4bb7-80f7-87b377802437")) {
                Name = "ФОП_Зеркальность",
                UnitType = SharedParam.GetUnitType(nameof(ElementMirroring)),
                StorageType = StorageType.Double
            };

#if REVIT2022_OR_GREATER
        /// <summary>
        /// ФОП_ОТД_Полы Тип 1
        /// </summary>
        public SharedParam FloorFinishingType1
            { get; private set; } = new SharedParam(nameof(FloorFinishingType1), new Guid("61b51270-72ab-41b2-ab15-8379b35cdab5")) {
                Name = "ФОП_ОТД_Полы Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Полы Тип 2
        /// </summary>
        public SharedParam FloorFinishingType2
            { get; private set; } = new SharedParam(nameof(FloorFinishingType2), new Guid("a7ac4b67-98f7-43af-b798-8b0a0143d5db")) {
                Name = "ФОП_ОТД_Полы Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Полы Тип 3
        /// </summary>
        public SharedParam FloorFinishingType3
            { get; private set; } = new SharedParam(nameof(FloorFinishingType3), new Guid("faf38afc-0eab-45f4-b24d-f6e1971747ed")) {
                Name = "ФОП_ОТД_Полы Тип 3",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType3)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Полы Тип 4
        /// </summary>
        public SharedParam FloorFinishingType4
            { get; private set; } = new SharedParam(nameof(FloorFinishingType4), new Guid("a0353eb7-e49a-404d-9997-1ba4ccb68eef")) {
                Name = "ФОП_ОТД_Полы Тип 4",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType4)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Полы Тип 5
        /// </summary>
        public SharedParam FloorFinishingType5
            { get; private set; } = new SharedParam(nameof(FloorFinishingType5), new Guid("50a11012-368d-4389-b447-8e13388c8596")) {
                Name = "ФОП_ОТД_Полы Тип 5",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType5)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 1
        /// </summary>
        public SharedParam CeilingFinishingType1
            { get; private set; } = new SharedParam(nameof(CeilingFinishingType1), new Guid("04785056-2e1f-4d88-b1a4-41f89ab346df")) {
                Name = "ФОП_ОТД_Потолки Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 2
        /// </summary>
        public SharedParam CeilingFinishingType2
            { get; private set; } = new SharedParam(nameof(CeilingFinishingType2), new Guid("cd92e19f-d6fd-4b96-a36c-d72ec437ffaa")) {
                Name = "ФОП_ОТД_Потолки Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 3
        /// </summary>
        public SharedParam CeilingFinishingType3
            { get; private set; } = new SharedParam(nameof(CeilingFinishingType3), new Guid("4fa13b7d-97a0-4e39-8e14-885b6435d8dd")) {
                Name = "ФОП_ОТД_Потолки Тип 3",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType3)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 4
        /// </summary>
        public SharedParam CeilingFinishingType4
            { get; private set; } = new SharedParam(nameof(CeilingFinishingType4), new Guid("f985418e-a043-454c-aaa3-8177fec97326")) {
                Name = "ФОП_ОТД_Потолки Тип 4",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType4)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 5
        /// </summary>
        public SharedParam CeilingFinishingType5
            { get; private set; } = new SharedParam(nameof(CeilingFinishingType5), new Guid("bb3768ed-91dc-4945-89e6-9ad2683a0a0c")) {
                Name = "ФОП_ОТД_Потолки Тип 5",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType5)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 1
        /// </summary>
        public SharedParam WallFinishingType1
            { get; private set; } = new SharedParam(nameof(WallFinishingType1), new Guid("63af57e2-6e4d-4cb2-985b-64c375e2cf7d")) {
                Name = "ФОП_ОТД_Стены Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 2
        /// </summary>
        public SharedParam WallFinishingType2
            { get; private set; } = new SharedParam(nameof(WallFinishingType2), new Guid("4a8d8421-2e38-4700-bbcd-7c58692a579b")) {
                Name = "ФОП_ОТД_Стены Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 3
        /// </summary>
        public SharedParam WallFinishingType3
            { get; private set; } = new SharedParam(nameof(WallFinishingType3), new Guid("7491edc7-372a-4547-bc12-99cc30882f36")) {
                Name = "ФОП_ОТД_Стены Тип 3",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType3)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 4
        /// </summary>
        public SharedParam WallFinishingType4
            { get; private set; } = new SharedParam(nameof(WallFinishingType4), new Guid("a031e6fc-2c62-4ade-915c-bdbf28c4696a")) {
                Name = "ФОП_ОТД_Стены Тип 4",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType4)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 5
        /// </summary>
        public SharedParam WallFinishingType5
            { get; private set; } = new SharedParam(nameof(WallFinishingType5), new Guid("aad25307-6f2a-4c9b-a9c4-f8df0afe932a")) {
                Name = "ФОП_ОТД_Стены Тип 5",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType5)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 6
        /// </summary>
        public SharedParam WallFinishingType6
            { get; private set; } = new SharedParam(nameof(WallFinishingType6), new Guid("7bedd5a6-34bb-4eea-bce6-1c7eff2f4e0f")) {
                Name = "ФОП_ОТД_Стены Тип 6",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType6)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 7
        /// </summary>
        public SharedParam WallFinishingType7
            { get; private set; } = new SharedParam(nameof(WallFinishingType7), new Guid("8e836fae-c18e-413a-b23d-c02367033d65")) {
                Name = "ФОП_ОТД_Стены Тип 7",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType7)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 8
        /// </summary>
        public SharedParam WallFinishingType8
            { get; private set; } = new SharedParam(nameof(WallFinishingType8), new Guid("448961a2-8b3b-4144-98f1-12f79cafcd61")) {
                Name = "ФОП_ОТД_Стены Тип 8",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType8)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 9
        /// </summary>
        public SharedParam WallFinishingType9
            { get; private set; } = new SharedParam(nameof(WallFinishingType9), new Guid("a8cdd7e9-0395-4a3d-90af-00c237c83e4e")) {
                Name = "ФОП_ОТД_Стены Тип 9",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType9)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 10
        /// </summary>
        public SharedParam WallFinishingType10
            { get; private set; } = new SharedParam(nameof(WallFinishingType10), new Guid("0adcdd17-3cfd-478f-ada3-33faafc4e317")) {
                Name = "ФОП_ОТД_Стены Тип 10",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType10)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 1
        /// </summary>
        public SharedParam BaseboardFinishingType1
            { get; private set; } = new SharedParam(nameof(BaseboardFinishingType1), new Guid("d286f79a-fa63-4148-b620-241331bb00a6")) {
                Name = "ФОП_ОТД_Плинтусы Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 2
        /// </summary>
        public SharedParam BaseboardFinishingType2
            { get; private set; } = new SharedParam(nameof(BaseboardFinishingType2), new Guid("43324f43-4148-4b1f-aa46-d0d247d5cce5")) {
                Name = "ФОП_ОТД_Плинтусы Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 3
        /// </summary>
        public SharedParam BaseboardFinishingType3
            { get; private set; } = new SharedParam(nameof(BaseboardFinishingType3), new Guid("8a440520-d34b-482d-965e-dce0e3fc3224")) {
                Name = "ФОП_ОТД_Плинтусы Тип 3",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType3)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 4
        /// </summary>
        public SharedParam BaseboardFinishingType4
            { get; private set; } = new SharedParam(nameof(BaseboardFinishingType4), new Guid("b1741f27-e041-48db-bfd5-85a05795cb23")) {
                Name = "ФОП_ОТД_Плинтусы Тип 4",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType4)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 5
        /// </summary>
        public SharedParam BaseboardFinishingType5
            { get; private set; } = new SharedParam(nameof(BaseboardFinishingType5), new Guid("cd4084e0-70c7-4904-b2a4-927550d3a9f2")) {
                Name = "ФОП_ОТД_Плинтусы Тип 5",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType5)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Имя помещения
        /// </summary>
        public SharedParam FinishingRoomName
            { get; private set; } = new SharedParam(nameof(FinishingRoomName), new Guid("1b8a1d6f-1ccb-42a5-bfeb-278b025319ee")) {
                Name = "ФОП_ОТД_Имя помещения",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Номер помещения
        /// </summary>
        public SharedParam FinishingRoomNumber
            { get; private set; } = new SharedParam(nameof(FinishingRoomNumber), new Guid("5cd5937b-6ac2-40e0-8644-5616519c4518")) {
                Name = "ФОП_ОТД_Номер помещения",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Имена помещений
        /// </summary>
        public SharedParam FinishingRoomNames
            { get; private set; } = new SharedParam(nameof(FinishingRoomNames), new Guid("79bbdddd-a22a-489d-a5e7-e7d9378ff2d5")) {
                Name = "ФОП_ОТД_Имена помещений",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomNames)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Номера помещений
        /// </summary>
        public SharedParam FinishingRoomNumbers
            { get; private set; } = new SharedParam(nameof(FinishingRoomNumbers), new Guid("1b303522-5133-4253-8282-9ef2e4ef44e5")) {
                Name = "ФОП_ОТД_Номера помещений",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomNumbers)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Тип отделки_ТЕ
        /// </summary>
        public SharedParam FinishingType
            { get; private set; } = new SharedParam(nameof(FinishingType), new Guid("6ccd5d9c-5319-4d80-a9c3-6a3ca2926bdc")) {
                Name = "ФОП_ОТД_Тип отделки_ТЕ",
                UnitType = SharedParam.GetUnitType(nameof(FinishingType)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Тип пола_ДЕ
        /// </summary>
        public SharedParam FloorFinishingOrder
            { get; private set; } = new SharedParam(nameof(FloorFinishingOrder), new Guid("1a76a12a-a54b-4e0e-a741-5f68f6e8fb59")) {
                Name = "ФОП_ОТД_Тип пола_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ОТД_Тип потолка_ДЕ
        /// </summary>
        public SharedParam CeilingFinishingOrder
            { get; private set; } = new SharedParam(nameof(CeilingFinishingOrder), new Guid("1a00bb3d-fcc4-46f2-b146-28ab1d17bab4")) {
                Name = "ФОП_ОТД_Тип потолка_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ОТД_Тип стены_ДЕ
        /// </summary>
        public SharedParam WallFinishingOrder
            { get; private set; } = new SharedParam(nameof(WallFinishingOrder), new Guid("4844df04-a9db-4863-8322-c6bf6835c0f6")) {
                Name = "ФОП_ОТД_Тип стены_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ОТД_Тип плинтуса_ДЕ
        /// </summary>
        public SharedParam BaseboardFinishingOrder
            { get; private set; } = new SharedParam(nameof(BaseboardFinishingOrder), new Guid("b997afe6-735b-4bb7-8e52-daee5168920e")) {
                Name = "ФОП_ОТД_Тип плинтуса_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Длина_ДЕ
        /// </summary>
        public SharedParam SizeLengthAdditional
            { get; private set; } = new SharedParam(nameof(SizeLengthAdditional), new Guid("bc97c75c-073b-4ddc-96d9-29f965afe96d")) {
                Name = "ФОП_РАЗМ_Длина_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(SizeLengthAdditional)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Площадь
        /// </summary>
        public SharedParam SizeArea
            { get; private set; } = new SharedParam(nameof(SizeArea), new Guid("a27c2dbc-9578-41d0-ba1c-e8c1e1c03daa")) {
                Name = "ФОП_РАЗМ_Площадь",
                UnitType = SharedParam.GetUnitType(nameof(SizeArea)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Объем
        /// </summary>
        public SharedParam SizeVolume
            { get; private set; } = new SharedParam(nameof(SizeVolume), new Guid("f0775dbc-b7c0-4323-ae31-7ef706d1cca0")) {
                Name = "ФОП_РАЗМ_Объем",
                UnitType = SharedParam.GetUnitType(nameof(SizeVolume)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Длина
        /// </summary>
        public SharedParam SizeLength
            { get; private set; } = new SharedParam(nameof(SizeLength), new Guid("6948f304-93e3-4e68-a76b-29e2aacc19ab")) {
                Name = "ФОП_РАЗМ_Длина",
                UnitType = SharedParam.GetUnitType(nameof(SizeLength)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Ширина
        /// </summary>
        public SharedParam SizeWidth
            { get; private set; } = new SharedParam(nameof(SizeWidth), new Guid("5ca11eed-a8b0-490a-8109-af59411e1639")) {
                Name = "ФОП_РАЗМ_Ширина",
                UnitType = SharedParam.GetUnitType(nameof(SizeWidth)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Высота
        /// </summary>
        public SharedParam SizeHeight
            { get; private set; } = new SharedParam(nameof(SizeHeight), new Guid("1aef8494-bbdd-41cd-9f45-40b6bd0e7913")) {
                Name = "ФОП_РАЗМ_Высота",
                UnitType = SharedParam.GetUnitType(nameof(SizeHeight)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ПМЩ_Номер здания
        /// </summary>
        public SharedParam BuildingNumber
            { get; private set; } = new SharedParam(nameof(BuildingNumber), new Guid("22b6b0fc-80fe-4a60-8136-18e619927126")) {
                Name = "ФОП_ПМЩ_Номер здания",
                UnitType = SharedParam.GetUnitType(nameof(BuildingNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ПМЩ_Номер ОКС
        /// </summary>
        public SharedParam ConstructionWorksNumber
            { get; private set; } = new SharedParam(nameof(ConstructionWorksNumber), new Guid("2564126d-dd7e-4c35-8d04-12b40679ab45")) {
                Name = "ФОП_ПМЩ_Номер ОКС",
                UnitType = SharedParam.GetUnitType(nameof(ConstructionWorksNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Класс ММ
        /// </summary>
        public SharedParam ParkingSpaceClass
            { get; private set; } = new SharedParam(nameof(ParkingSpaceClass), new Guid("f84676b0-e969-45af-8f36-d2a961367afe")) {
                Name = "ФОП_Класс ММ",
                UnitType = SharedParam.GetUnitType(nameof(ParkingSpaceClass)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_СС Дата задания
        /// </summary>
        public SharedParam VISTaskSSDate
            { get; private set; } = new SharedParam(nameof(VISTaskSSDate), new Guid("63cbf6de-c1cb-467d-829e-235fa74656bb")) {
                Name = "ФОП_ВИС_СС Дата задания",
                UnitType = SharedParam.GetUnitType(nameof(VISTaskSSDate)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_СС Марка задания
        /// </summary>
        public SharedParam VISTaskSSMark
            { get; private set; } = new SharedParam(nameof(VISTaskSSMark), new Guid("2722332b-529f-4f4e-b729-5420f7e403e0")) {
                Name = "ФОП_ВИС_СС Марка задания",
                UnitType = SharedParam.GetUnitType(nameof(VISTaskSSMark)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_СС Добавить к заданию
        /// </summary>
        public SharedParam VISTaskSSAdd
            { get; private set; } = new SharedParam(nameof(VISTaskSSAdd), new Guid("9384dc86-2e82-4cb1-9d19-3c367e57b6c0")) {
                Name = "ФОП_ВИС_СС Добавить к заданию",
                UnitType = SharedParam.GetUnitType(nameof(VISTaskSSAdd)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// ФОП_ВИС_Потери давления
        /// </summary>
        public SharedParam VISPressureLoss
            { get; private set; } = new SharedParam(nameof(VISPressureLoss), new Guid("d87b6933-00c5-421e-859e-60ff215174c0")) {
                Name = "ФОП_ВИС_Потери давления",
                UnitType = SharedParam.GetUnitType(nameof(VISPressureLoss)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Доп. имя помещения
        /// </summary>
        public SharedParam ApartmentNameExtra
            { get; private set; } = new SharedParam(nameof(ApartmentNameExtra), new Guid("11552a57-bced-445f-a439-8353251d9128")) {
                Name = "ФОП_Доп. имя помещения",
                UnitType = SharedParam.GetUnitType(nameof(ApartmentNameExtra)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// Ш.№Изм1
        /// </summary>
        public SharedParam StampSheetRevision1
            { get; private set; } = new SharedParam(nameof(StampSheetRevision1), new Guid("c7be433c-10d5-40c8-a5c2-1944fecd644e")) {
                Name = "Ш.№Изм1",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision1)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм2
        /// </summary>
        public SharedParam StampSheetRevision2
            { get; private set; } = new SharedParam(nameof(StampSheetRevision2), new Guid("e450f1c1-89d2-4f02-8c57-b1e2b9b3d83d")) {
                Name = "Ш.№Изм2",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision2)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм3
        /// </summary>
        public SharedParam StampSheetRevision3
            { get; private set; } = new SharedParam(nameof(StampSheetRevision3), new Guid("957fcafe-d7bf-4301-898b-6f06c482b3e4")) {
                Name = "Ш.№Изм3",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision3)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм4
        /// </summary>
        public SharedParam StampSheetRevision4
            { get; private set; } = new SharedParam(nameof(StampSheetRevision4), new Guid("be5f1ade-514a-4b32-b250-6a0842292997")) {
                Name = "Ш.№Изм4",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision4)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм5
        /// </summary>
        public SharedParam StampSheetRevision5
            { get; private set; } = new SharedParam(nameof(StampSheetRevision5), new Guid("11fea1fd-5ea4-4d57-90ce-2d72b2f07aba")) {
                Name = "Ш.№Изм5",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision5)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм6
        /// </summary>
        public SharedParam StampSheetRevision6
            { get; private set; } = new SharedParam(nameof(StampSheetRevision6), new Guid("b391d9fa-8fbf-4574-8040-ee567add42ed")) {
                Name = "Ш.№Изм6",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision6)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм7
        /// </summary>
        public SharedParam StampSheetRevision7
            { get; private set; } = new SharedParam(nameof(StampSheetRevision7), new Guid("b1042735-d74e-40a5-8314-23a01447755c")) {
                Name = "Ш.№Изм7",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision7)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.№Изм8
        /// </summary>
        public SharedParam StampSheetRevision8
            { get; private set; } = new SharedParam(nameof(StampSheetRevision8), new Guid("f6aea3f2-aa0e-415c-8fd4-d4db7a9a8be8")) {
                Name = "Ш.№Изм8",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevision8)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№1
        /// </summary>
        public SharedParam StampSheetRevisionValue1
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue1), new Guid("c6902b30-6190-44de-9f94-d5149b787310")) {
                Name = "Ш.Значение.Изм/Зам№1",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue1)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№2
        /// </summary>
        public SharedParam StampSheetRevisionValue2
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue2), new Guid("7f7e628c-2739-4752-a21c-64f59f1b28bc")) {
                Name = "Ш.Значение.Изм/Зам№2",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue2)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№3
        /// </summary>
        public SharedParam StampSheetRevisionValue3
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue3), new Guid("62311fd6-c076-4ed0-843a-3294e9ffa8fe")) {
                Name = "Ш.Значение.Изм/Зам№3",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue3)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№4
        /// </summary>
        public SharedParam StampSheetRevisionValue4
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue4), new Guid("38c8024e-dbf1-4ca3-af63-b3b008269159")) {
                Name = "Ш.Значение.Изм/Зам№4",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue4)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№5
        /// </summary>
        public SharedParam StampSheetRevisionValue5
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue5), new Guid("41aeccc5-6ea5-444e-bc06-2b232188bc00")) {
                Name = "Ш.Значение.Изм/Зам№5",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue5)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№6
        /// </summary>
        public SharedParam StampSheetRevisionValue6
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue6), new Guid("50950e51-078f-4a21-8c45-a847dc3207d8")) {
                Name = "Ш.Значение.Изм/Зам№6",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue6)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№7
        /// </summary>
        public SharedParam StampSheetRevisionValue7
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue7), new Guid("b1353820-2d6e-4811-8b26-152432916a1c")) {
                Name = "Ш.Значение.Изм/Зам№7",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue7)),
                StorageType = StorageType.String
            };
        
        /// <summary>
        /// Ш.Значение.Изм/Зам№8
        /// </summary>
        public SharedParam StampSheetRevisionValue8
            { get; private set; } = new SharedParam(nameof(StampSheetRevisionValue8), new Guid("64645b8a-8451-4812-b895-c83b1101ffe7")) {
                Name = "Ш.Значение.Изм/Зам№8",
                UnitType = SharedParam.GetUnitType(nameof(StampSheetRevisionValue8)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ID	
        /// </summary>
        public SharedParam FopId
            { get; private set; } = new SharedParam(nameof(FopId), new Guid("5a0fc547-0a86-4518-a0e3-718c1b116c45")) {
                Name = "ФОП_ID",
                UnitType = SharedParam.GetUnitType(nameof(FopId)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Категория помещения
        /// </summary>
        public SharedParam RoomFireCategory
            { get; private set; } = new SharedParam(nameof(RoomFireCategory), new Guid("66005df5-7751-4ddb-bf84-b1f551d1d058")) {
                Name = "ФОП_Категория помещения",
                UnitType = SharedParam.GetUnitType(nameof(RoomFireCategory)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_РАЗМ_Ширина проёма
        /// </summary>
        public SharedParam SizeOpeningWidth
            { get; private set; } = new SharedParam(nameof(SizeOpeningWidth), new Guid("b10f1ca0-f1b3-47a8-8f18-fe13196b4d4a")) {
                Name = "ФОП_РАЗМ_Ширина проёма",
                UnitType = SharedParam.GetUnitType(nameof(SizeOpeningWidth)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Высота проёма
        /// </summary>
        public SharedParam SizeOpeningHeight
            { get; private set; } = new SharedParam(nameof(SizeOpeningHeight), new Guid("6c51dbbe-5635-4b2f-aaa3-b3ed0bd4a528")) {
                Name = "ФОП_РАЗМ_Высота проёма",
                UnitType = SharedParam.GetUnitType(nameof(SizeOpeningHeight)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Глубина проёма
        /// </summary>
        public SharedParam SizeOpeningDepth
            { get; private set; } = new SharedParam(nameof(SizeOpeningDepth), new Guid("4c5379ca-b3e3-4a3b-913f-a6596348255a")) {
                Name = "ФОП_РАЗМ_Глубина проёма",
                UnitType = SharedParam.GetUnitType(nameof(SizeOpeningDepth)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Диаметр
        /// </summary>
        public SharedParam SizeDiameter
            { get; private set; } = new SharedParam(nameof(SizeDiameter), new Guid("902bbe92-2ad5-4956-915f-c83a85eb151f")) {
                Name = "ФОП_РАЗМ_Диаметр",
                UnitType = SharedParam.GetUnitType(nameof(SizeDiameter)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Глубина
        /// </summary>
        public SharedParam SizeDepth
            { get; private set; } = new SharedParam(nameof(SizeDepth), new Guid("8132a541-c995-400c-839c-aeaa327e2081")) {
                Name = "ФОП_РАЗМ_Глубина",
                UnitType = SharedParam.GetUnitType(nameof(SizeDepth)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// мод_ФОП_Габарит А
        /// </summary>
        public SharedParam DimensionAModeling
            { get; private set; } = new SharedParam(nameof(DimensionAModeling), new Guid("87e4fe4d-f50c-4f80-9b62-93b0dce6bf5d")) {
                Name = "мод_ФОП_Габарит А",
                UnitType = SharedParam.GetUnitType(nameof(DimensionAModeling)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// мод_ФОП_Габарит Б
        /// </summary>
        public SharedParam DimensionBModeling
            { get; private set; } = new SharedParam(nameof(DimensionBModeling), new Guid("b577c174-8fe9-4e75-94b4-69c59dbcfa7c")) {
                Name = "мод_ФОП_Габарит Б",
                UnitType = SharedParam.GetUnitType(nameof(DimensionBModeling)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ADSK_Размер_УголПоворота
        /// </summary>
        public SharedParam SizeRotationAngle
            { get; private set; } = new SharedParam(nameof(SizeRotationAngle), new Guid("a7397d18-200b-4659-b34c-3d8ae1c54317")) {
                Name = "ADSK_Размер_УголПоворота",
                UnitType = SharedParam.GetUnitType(nameof(SizeRotationAngle)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Толщина стенки
        /// </summary>
        public SharedParam VISSideThickness
            { get; private set; } = new SharedParam(nameof(VISSideThickness), new Guid("7828fd5b-153b-4778-b2f6-4c04e80e6467")) {
                Name = "ФОП_ВИС_Толщина стенки",
                UnitType = SharedParam.GetUnitType(nameof(VISSideThickness)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Описание
        /// </summary>
        public SharedParam Description
            { get; private set; } = new SharedParam(nameof(Description), new Guid("7bc34a91-32d1-4aae-a68b-f000d48e40bd")) {
                Name = "ФОП_Описание",
                UnitType = SharedParam.GetUnitType(nameof(Description)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Этаж СМР_ДЕ
        /// </summary>
        public SharedParam BuildingWorksLevelCurrency
            { get; private set; } = new SharedParam(nameof(BuildingWorksLevelCurrency), new Guid("3b271f59-7ccd-4ca5-ad45-3242d8a4329f")) {
                Name = "ФОП_Этаж СМР_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(BuildingWorksLevelCurrency)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Фиксация решения
        /// </summary>
        public SharedParam FixSolution
            { get; private set; } = new SharedParam(nameof(FixSolution), new Guid("83f536a8-08cc-42e0-a6f5-4db7c1166cfb")) {
                Name = "ФОП_Фиксация решения",
                UnitType = SharedParam.GetUnitType(nameof(FixSolution)),
                StorageType = StorageType.Integer
            };

#endif

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, string revitParamName) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, revitParamName);
        }

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            return CreateRevitParam(document, revitParamElement);
        }

        /// <inheritdoc />
        RevitParam IParamElementService.
            CreateRevitParam(Document document, string propertyName, string revitParamName) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(string.IsNullOrEmpty(propertyName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(propertyName));
            }

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, propertyName, revitParamName);
        }

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, string propertyName,
            ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            if(string.IsNullOrEmpty(propertyName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(propertyName));
            }

            return CreateRevitParam(document, propertyName, revitParamElement);
        }

        /// <inheritdoc />
        public SharedParam CreateRevitParam(Document document, string revitParamName) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, revitParamName, document.GetSharedParam(revitParamName));
        }

        /// <inheritdoc />
        public SharedParam CreateRevitParam(Document document, ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            return CreateRevitParam(document, revitParamElement.Name, revitParamElement);
        }

        /// <inheritdoc />
        public SharedParam CreateRevitParam(Document document, string propertyName, string revitParamName) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(propertyName == null) {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, propertyName, document.GetSharedParam(revitParamName));
        }

        /// <inheritdoc />
        public SharedParam CreateRevitParam(Document document, string propertyName,
            ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            if(string.IsNullOrEmpty(propertyName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(propertyName));
            }

            Guid guid = ((SharedParameterElement) revitParamElement).GuidValue;
            return new SharedParam(propertyName, guid) {
                Name = revitParamElement.Name,
                UnitType = revitParamElement.GetUnitType(),
                StorageType = revitParamElement.GetStorageType()
            };
        }

        /// <inheritdoc/>
        SharedParam ISharedParamsService.this[string paramId]
            => (SharedParam) this[paramId];

        /// <inheritdoc />
        IEnumerable<SharedParam> ISharedParamsService.GetRevitParams() {
            return base.GetRevitParams().OfType<SharedParam>();
        }

        /// <inheritdoc/>
        IEnumerable<RevitParam> IParamElementService.GetRevitParams(Document document) {
            return GetRevitParams(document);
        }

        /// <inheritdoc/>
        public IEnumerable<SharedParam> GetRevitParams(Document document) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(ParameterElement))
                .OfType<ParameterElement>()
                .Where(item => item.IsSharedParam())
                .Select(item => CreateRevitParam(document, item));
        }

        /// <summary>
        /// Загрузка текущей конфигурации.
        /// </summary>
        /// <param name="configPath">Путь до конфигурации.</param>
        /// <remarks>Возвращает конфигурацию по умолчанию если был найден переданный файл.</remarks>
        public static void LoadInstance(string configPath) {
            Instance = Load(configPath);
        }

        /// <summary>
        /// Загрузка текущей конфигурации.
        /// </summary>
        /// <param name="configPath">Путь до конфигурации.</param>
        /// <remarks>Возвращает конфигурацию по умолчанию если был найден переданный файл.</remarks>
        public static SharedParamsConfig Load(string configPath) {
            return File.Exists(configPath)
                ? JsonConvert.DeserializeObject<SharedParamsConfig>(File.ReadAllText(configPath))
                : GetDefaultConfig();
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static SharedParamsConfig GetDefaultConfig() {
            return new SharedParamsConfig();
        }
    }
}