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
            => new SharedParam(nameof(AlbumBlueprints), new Guid("e1b06433-f527-403c-8986-af9a01e6be7f")) {
                Name = "ADSK_Комплект чертежей",
                UnitType = SharedParam.GetUnitType(nameof(AlbumBlueprints)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_КВР_Площадь без коэф.
        /// </summary>
        public SharedParam ApartmentArea
            => new SharedParam(nameof(ApartmentArea), new Guid("603c712b-657c-4195-b153-30950ae5f4cb")) {
                Name = "ФОП_КВР_Площадь без коэф.",
                UnitType = SharedParam.GetUnitType(nameof(ApartmentArea)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь без коэф.
        /// </summary>
        public SharedParam ApartmentAreaFix
            => new SharedParam(nameof(ApartmentAreaFix), new Guid("3d6c5084-d6ab-490e-baa6-f8d119a0d628")) {
                Name = "ФОП_ФИКС_КВР_Площадь без коэф.", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ макс
        /// </summary>
        public SharedParam ApartmentAreaMaxSpec
            => new SharedParam(nameof(ApartmentAreaMaxSpec), new Guid("2a6f369d-9065-4b55-a7d3-33db24751a98")) {
                Name = "ФОП_КВР_Площадь по ТЗ макс", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaMaxSpec)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ мин
        /// </summary>
        public SharedParam ApartmentAreaMinSpec
            => new SharedParam(nameof(ApartmentAreaMinSpec), new Guid("24508a72-b07c-460a-a580-d5ae2d54ab94")) {
                Name = "ФОП_КВР_Площадь по ТЗ мин", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaMinSpec)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь без ЛП
        /// </summary>
        public SharedParam ApartmentAreaNoBalcony
            => new SharedParam(nameof(ApartmentAreaNoBalcony), new Guid("374fc833-240a-4d71-95fc-7d349456ca7e")) {
                Name = "ФОП_КВР_Площадь без ЛП", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaNoBalcony)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь без ЛП
        /// </summary>
        public SharedParam ApartmentAreaNoBalconyFix
            => new SharedParam(nameof(ApartmentAreaNoBalconyFix),
                new Guid("8226f116-c19e-4797-a3bb-55ac79acdf44")) {
                Name = "ФОП_ФИКС_КВР_Площадь без ЛП", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaNoBalconyFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь с коэф.
        /// </summary>
        public SharedParam ApartmentAreaRatio
            => new SharedParam(nameof(ApartmentAreaRatio), new Guid("80be4e2b-0656-45d2-90e6-e372685b03aa")) {
                Name = "ФОП_КВР_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaRatio)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь с коэф.
        /// </summary>
        public SharedParam ApartmentAreaRatioFix
            => new SharedParam(nameof(ApartmentAreaRatioFix), new Guid("77713404-35ef-4c8a-a5c4-c6f3d4da16c2")) {
                Name = "ФОП_ФИКС_КВР_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaRatioFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ
        /// </summary>
        public SharedParam ApartmentAreaSpec
            => new SharedParam(nameof(ApartmentAreaSpec), new Guid("f6616ef6-481c-4133-81f9-c258790822e2")) {
                Name = "ФОП_КВР_Площадь по ТЗ", UnitType = SharedParam.GetUnitType(nameof(ApartmentAreaSpec)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_КВР_Площадь по пятну
        /// </summary>
        public SharedParam ApartmentFullArea
            => new SharedParam(nameof(ApartmentFullArea), new Guid("317ce3f3-b540-4a5d-9cba-15cd273d0e4e")) {
                Name = "ФОП_КВР_Площадь по пятну", UnitType = SharedParam.GetUnitType(nameof(ApartmentFullArea)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь по пятну
        /// </summary>
        public SharedParam ApartmentFullAreaFix
            => new SharedParam(nameof(ApartmentFullAreaFix), new Guid("bc1bf705-37a8-404e-af7c-ca072168b994")) {
                Name = "ФОП_ФИКС_КВР_Площадь по пятну", UnitType = SharedParam.GetUnitType(nameof(ApartmentFullAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Доп. сортировка групп
        /// </summary>
        public SharedParam ApartmentGroupName
            => new SharedParam(nameof(ApartmentGroupName), new Guid("a3cb8c52-4c45-42ff-abc0-a569cd122763")) {
                Name = "ФОП_Доп. сортировка групп", UnitType = SharedParam.GetUnitType(nameof(ApartmentGroupName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_КВР_Площадь жилая
        /// </summary>
        public SharedParam ApartmentLivingArea
            => new SharedParam(nameof(ApartmentLivingArea), new Guid("3e43f7d6-6dfe-4b88-a874-7c54272789b7")) {
                Name = "ФОП_КВР_Площадь жилая", UnitType = SharedParam.GetUnitType(nameof(ApartmentLivingArea)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь жилая
        /// </summary>
        public SharedParam ApartmentLivingAreaFix
            => new SharedParam(nameof(ApartmentLivingAreaFix), new Guid("421ec146-2f9b-48ae-9bcc-1f478c115e7e")) {
                Name = "ФОП_ФИКС_КВР_Площадь жилая", UnitType = SharedParam.GetUnitType(nameof(ApartmentLivingAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Номер квартиры
        /// </summary>
        public SharedParam ApartmentNumber
            => new SharedParam(nameof(ApartmentNumber), new Guid("083c183f-d3d3-4710-9efc-f21ade3680f9")) {
                Name = "ФОП_Номер квартиры", UnitType = SharedParam.GetUnitType(nameof(ApartmentNumber)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Доп. номер помещения
        /// </summary>
        public SharedParam ApartmentNumberExtra
            => new SharedParam(nameof(ApartmentNumberExtra), new Guid("735e1a5f-e5f6-44b6-b94f-bb810db5bafc")) {
                Name = "ФОП_Доп. номер помещения", UnitType = SharedParam.GetUnitType(nameof(ApartmentNumberExtra)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Блок СМР
        /// </summary>
        public SharedParam BuildingWorksBlock
            => new SharedParam(nameof(BuildingWorksBlock), new Guid("e8385ba7-d468-4dc9-862d-4d8673db398e")) {
                Name = "ФОП_Блок СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksBlock)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Секция СМР
        /// </summary>
        public SharedParam BuildingWorksSection
            => new SharedParam(nameof(BuildingWorksSection), new Guid("fc159fc9-4163-4886-aad4-081c33716eaf")) {
                Name = "ФОП_Секция СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksSection)), StorageType = StorageType.String
            };
        
        /// <summary>
        /// ФОП_Типизация СМР
        /// </summary>
        public SharedParam BuildingWorksTyping
            => new SharedParam(nameof(BuildingWorksTyping), new Guid("2e5cc8dc-7598-4d94-887b-d239bcf4de76")) {
                Name = "ФОП_Типизация СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksTyping)), StorageType = StorageType.String
            };
        
        /// <summary>
        /// ФОП_Фиксация координаты СМР
        /// </summary>
        public SharedParam FixBuildingWorks
            => new SharedParam(nameof(FixBuildingWorks), new Guid("ff9554f5-b037-40d3-ad9f-c46ebc5d8244")) {
                Name = "ФОП_Фиксация координаты СМР", UnitType = SharedParam.GetUnitType(nameof(FixBuildingWorks)), StorageType = StorageType.Integer
            };
        
        /// <summary>
        /// ФОП_Этаж СМР
        /// </summary>
        public SharedParam BuildingWorksLevel
            => new SharedParam(nameof(BuildingWorksLevel), new Guid("326da28a-41b9-40af-9ac9-2ef7e16d50e8")) {
                Name = "ФОП_Этаж СМР", UnitType = SharedParam.GetUnitType(nameof(BuildingWorksLevel)), StorageType = StorageType.String
            };


        /// <summary>
        /// ФОП_ФИКС_Комментарии
        /// </summary>
        public SharedParam FixComment
            => new SharedParam(nameof(FixComment), new Guid("9aa1f257-c6bd-4ca7-b958-4bcb17cf1c32")) {
                Name = "ФОП_ФИКС_Комментарии", UnitType = SharedParam.GetUnitType(nameof(FixComment)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Пожарный отсек
        /// </summary>
        public SharedParam FireCompartmentShortName
            => new SharedParam(nameof(FireCompartmentShortName),
                new Guid("b750a7c4-e882-4952-a773-07f060946ad7")) {
                Name = "ФОП_Пожарный отсек", UnitType = SharedParam.GetUnitType(nameof(FireCompartmentShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Этаж
        /// </summary>
        public SharedParam Level
            => new SharedParam(nameof(Level), new Guid("248ddd42-5597-4eba-bba2-818056f8586c")) {
                Name = "ФОП_Этаж", UnitType = SharedParam.GetUnitType(nameof(Level)), StorageType = StorageType.String
            };

        /// <summary>
        /// ADSK_Имя системы
        /// </summary>
        public SharedParam MechanicalSystemName
            => new SharedParam(nameof(MechanicalSystemName), new Guid("4be4ed4d-c509-4ef3-a55d-23d3a406b83c")) {
                Name = "ADSK_Имя системы", UnitType = SharedParam.GetUnitType(nameof(MechanicalSystemName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ПМЩ_Площадь
        /// </summary>
        public SharedParam RoomArea
            => new SharedParam(nameof(RoomArea), new Guid("88698162-c32d-45df-9db6-2ddb07b04d17")) {
                Name = "ФОП_ПМЩ_Площадь", UnitType = SharedParam.GetUnitType(nameof(RoomArea)), StorageType = StorageType.Double
            };


        /// <summary>
        /// ФОП_ФИКС_ПМЩ_Площадь
        /// </summary>
        public SharedParam RoomAreaFix
            => new SharedParam(nameof(RoomAreaFix), new Guid("64bf4d4d-6ef3-4cfd-b452-eccdde94a8ad")) {
                Name = "ФОП_ФИКС_ПМЩ_Площадь", UnitType = SharedParam.GetUnitType(nameof(RoomAreaFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_Коэффициент площади
        /// </summary>
        public SharedParam RoomAreaRatio
            => new SharedParam(nameof(RoomAreaRatio), new Guid("3a8a1879-1802-4bc6-9c1a-c375dc1a9292")) {
                Name = "ФОП_Коэффициент площади", UnitType = SharedParam.GetUnitType(nameof(RoomAreaRatio)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ПМЩ_Площадь с коэф.
        /// </summary>
        public SharedParam RoomAreaWithRatio
            => new SharedParam(nameof(RoomAreaWithRatio), new Guid("aa4729e4-4964-43c1-a706-4b45d0567771")) {
                Name = "ФОП_ПМЩ_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(RoomAreaWithRatio)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ФИКС_ПМЩ_Площадь с коэф.
        /// </summary>
        public SharedParam RoomAreaWithRatioFix
            => new SharedParam(nameof(RoomAreaWithRatioFix), new Guid("46bc1213-6d5a-4164-84d0-598a9abcf70d")) {
                Name = "ФОП_ФИКС_ПМЩ_Площадь с коэф.", UnitType = SharedParam.GetUnitType(nameof(RoomAreaWithRatioFix)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ПМЩ_Группа
        /// </summary>
        public SharedParam RoomGroupShortName
            => new SharedParam(nameof(RoomGroupShortName), new Guid("c7955ded-0589-4d86-93a1-7d205d5852e2")) {
                Name = "ФОП_ПМЩ_Группа", UnitType = SharedParam.GetUnitType(nameof(RoomGroupShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ПМЩ_Секция
        /// </summary>
        public SharedParam RoomSectionShortName
            => new SharedParam(nameof(RoomSectionShortName), new Guid("c39f32dd-a2b7-4853-8dc0-13c63c052eb2")) {
                Name = "ФОП_ПМЩ_Секция", UnitType = SharedParam.GetUnitType(nameof(RoomSectionShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Тип группы помещений
        /// </summary>
        public SharedParam RoomTypeGroupShortName
            => new SharedParam(nameof(RoomTypeGroupShortName), new Guid("2e36a08a-94c0-4b35-a082-e5e3d51765cf")) {
                Name = "ФОП_Тип группы помещений", UnitType = SharedParam.GetUnitType(nameof(RoomTypeGroupShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Многоуровневая группа
        /// </summary>
        public SharedParam RoomMultilevelGroup
            => new SharedParam(nameof(RoomMultilevelGroup), new Guid("7d6fdcf2-e138-4a79-b122-04fc8667f4dc")) {
                Name = "ФОП_Многоуровневая группа", UnitType = SharedParam.GetUnitType(nameof(RoomMultilevelGroup)),
        StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_Количество комнат
        /// </summary>
        public SharedParam RoomsCount
            => new SharedParam(nameof(RoomsCount), new Guid("2498f7c7-de06-42c7-93dc-5e269cadc202")) {
                Name = "ФОП_Количество комнат", UnitType = SharedParam.GetUnitType(nameof(RoomsCount)), StorageType = StorageType.Integer
            };

        /// <summary>
        /// Ш.НомерЛиста
        /// </summary>
        public SharedParam StampSheetNumber
            => new SharedParam(nameof(StampSheetNumber), new Guid("b6e73342-b6cd-42c5-86c5-64b04b5b88de")) {
                Name = "Ш.НомерЛиста", UnitType = SharedParam.GetUnitType(nameof(StampSheetNumber)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Наименование комбинированное
        /// </summary>
        public SharedParam VISCombinedName
            => new SharedParam(nameof(VISCombinedName), new Guid("3624223b-d55a-4b60-98e7-af64d6242409")) {
                Name = "ФОП_ВИС_Наименование комбинированное",
                UnitType = SharedParam.GetUnitType(nameof(VISCombinedName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Группирование
        /// </summary>
        public SharedParam VISGrouping
            => new SharedParam(nameof(VISGrouping), new Guid("7bf3d944-9973-484d-9195-66472ddd150f")) {
                Name = "ФОП_ВИС_Группирование", UnitType = SharedParam.GetUnitType(nameof(VISGrouping)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ВИС_Масса
        /// </summary>
        public SharedParam VISMass
            => new SharedParam(nameof(VISMass), new Guid("4a62a841-b2d0-4c94-aca8-c907f1adcc88")) {
                Name = "ФОП_ВИС_Масса", UnitType = SharedParam.GetUnitType(nameof(VISMass)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Минимальная толщина воздуховода
        /// </summary>
        public SharedParam VISMinDuctThickness
            => new SharedParam(nameof(VISMinDuctThickness), new Guid("7af80795-5115-46e4-867f-f276a2510250")) {
                Name = "ФОП_ВИС_Минимальная толщина воздуховода",
                UnitType = SharedParam.GetUnitType(nameof(VISMinDuctThickness)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Число
        /// </summary>
        public SharedParam VISSpecNumbers
            => new SharedParam(nameof(VISSpecNumbers), new Guid("37e09a6d-093b-432b-9647-33b70424642d")) {
                Name = "ФОП_ВИС_Число", UnitType = SharedParam.GetUnitType(nameof(VISSpecNumbers)), StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ВИС_Единица измерения
        /// </summary>
        public SharedParam VISUnit
            => new SharedParam(nameof(VISUnit), new Guid("02d3bf80-f03c-4055-ad5c-3dfb2c6ff26a")) {
                Name = "ФОП_ВИС_Единица измерения", UnitType = SharedParam.GetUnitType(nameof(VISUnit)), StorageType = StorageType.String
            };
        
        /// <summary>
        /// ФОП_ВИС_Имя внесистемных элементов
        /// </summary>
        public SharedParam VISOutSystemName
            => new SharedParam(nameof(VISOutSystemName), new Guid("ccbdb4ac-389e-4e17-890f-bdd1c6368724")) {
                Name = "ФОП_ВИС_Имя внесистемных элементов", UnitType = SharedParam.GetUnitType(nameof(VISOutSystemName)), StorageType = StorageType.String
            };
        
        
        /// <summary>
        /// ФОП_ВИС_Сокращение для системы
        /// </summary>
        public SharedParam VISSystemShortName
            => new SharedParam(nameof(VISSystemShortName), new Guid("da024aab-a886-456c-b7c1-64fcaf40383d")) {
                Name = "ФОП_ВИС_Сокращение для системы", UnitType = SharedParam.GetUnitType(nameof(VISSystemShortName)), StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Полы Тип 1
        /// </summary>
        public SharedParam FloorFinishingType1
            => new SharedParam(nameof(FloorFinishingType1), new Guid("61b51270-72ab-41b2-ab15-8379b35cdab5")) {
                Name = "ФОП_ОТД_Полы Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Полы Тип 2
        /// </summary>
        public SharedParam FloorFinishingType2
            => new SharedParam(nameof(FloorFinishingType2), new Guid("a7ac4b67-98f7-43af-b798-8b0a0143d5db")) {
                Name = "ФОП_ОТД_Полы Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 1
        /// </summary>
        public SharedParam CeilingFinishingType1
            => new SharedParam(nameof(CeilingFinishingType1), new Guid("04785056-2e1f-4d88-b1a4-41f89ab346df")) {
                Name = "ФОП_ОТД_Потолки Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Потолки Тип 2
        /// </summary>
        public SharedParam CeilingFinishingType2
            => new SharedParam(nameof(CeilingFinishingType2), new Guid("cd92e19f-d6fd-4b96-a36c-d72ec437ffaa")) {
                Name = "ФОП_ОТД_Потолки Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 1
        /// </summary>
        public SharedParam WallFinishingType1
            => new SharedParam(nameof(WallFinishingType1), new Guid("63af57e2-6e4d-4cb2-985b-64c375e2cf7d")) {
                Name = "ФОП_ОТД_Стены Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 2
        /// </summary>
        public SharedParam WallFinishingType2
            => new SharedParam(nameof(WallFinishingType2), new Guid("4a8d8421-2e38-4700-bbcd-7c58692a579b")) {
                Name = "ФОП_ОТД_Стены Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 3
        /// </summary>
        public SharedParam WallFinishingType3
            => new SharedParam(nameof(WallFinishingType3), new Guid("7491edc7-372a-4547-bc12-99cc30882f36")) {
                Name = "ФОП_ОТД_Стены Тип 3",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType3)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 4
        /// </summary>
        public SharedParam WallFinishingType4
            => new SharedParam(nameof(WallFinishingType4), new Guid("a031e6fc-2c62-4ade-915c-bdbf28c4696a")) {
                Name = "ФОП_ОТД_Стены Тип 4",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType4)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 5
        /// </summary>
        public SharedParam WallFinishingType5
            => new SharedParam(nameof(WallFinishingType5), new Guid("aad25307-6f2a-4c9b-a9c4-f8df0afe932a")) {
                Name = "ФОП_ОТД_Стены Тип 5",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType5)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 6
        /// </summary>
        public SharedParam WallFinishingType6
            => new SharedParam(nameof(WallFinishingType6), new Guid("7bedd5a6-34bb-4eea-bce6-1c7eff2f4e0f")) {
                Name = "ФОП_ОТД_Стены Тип 6",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType6)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 7
        /// </summary>
        public SharedParam WallFinishingType7
            => new SharedParam(nameof(WallFinishingType7), new Guid("8e836fae-c18e-413a-b23d-c02367033d65")) {
                Name = "ФОП_ОТД_Стены Тип 7",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType7)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 8
        /// </summary>
        public SharedParam WallFinishingType8
            => new SharedParam(nameof(WallFinishingType8), new Guid("448961a2-8b3b-4144-98f1-12f79cafcd61")) {
                Name = "ФОП_ОТД_Стены Тип 8",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType8)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 9
        /// </summary>
        public SharedParam WallFinishingType9
            => new SharedParam(nameof(WallFinishingType9), new Guid("a8cdd7e9-0395-4a3d-90af-00c237c83e4e")) {
                Name = "ФОП_ОТД_Стены Тип 9",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType9)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Стены Тип 10
        /// </summary>
        public SharedParam WallFinishingType10
            => new SharedParam(nameof(WallFinishingType10), new Guid("0adcdd17-3cfd-478f-ada3-33faafc4e317")) {
                Name = "ФОП_ОТД_Стены Тип 10",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingType10)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 1
        /// </summary>
        public SharedParam BaseboardFinishingType1
            => new SharedParam(nameof(BaseboardFinishingType1), new Guid("d286f79a-fa63-4148-b620-241331bb00a6")) {
                Name = "ФОП_ОТД_Плинтусы Тип 1",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType1)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Плинтусы Тип 2
        /// </summary>
        public SharedParam BaseboardFinishingType2
            => new SharedParam(nameof(BaseboardFinishingType2), new Guid("43324f43-4148-4b1f-aa46-d0d247d5cce5")) {
                Name = "ФОП_ОТД_Плинтусы Тип 2",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingType2)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Имя помещения
        /// </summary>
        public SharedParam FinishingRoomName
            => new SharedParam(nameof(FinishingRoomName), new Guid("1b8a1d6f-1ccb-42a5-bfeb-278b025319ee")) {
                Name = "ФОП_ОТД_Имя помещения",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Номер помещения
        /// </summary>
        public SharedParam FinishingRoomNumber
            => new SharedParam(nameof(FinishingRoomNumber), new Guid("5cd5937b-6ac2-40e0-8644-5616519c4518")) {
                Name = "ФОП_ОТД_Номер помещения",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Имена помещений
        /// </summary>
        public SharedParam FinishingRoomNames
            => new SharedParam(nameof(FinishingRoomNames), new Guid("79bbdddd-a22a-489d-a5e7-e7d9378ff2d5")) {
                Name = "ФОП_ОТД_Имена помещений",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomNames)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Номера помещений
        /// </summary>
        public SharedParam FinishingRoomNumbers
            => new SharedParam(nameof(FinishingRoomNumbers), new Guid("1b303522-5133-4253-8282-9ef2e4ef44e5")) {
                Name = "ФОП_ОТД_Номера помещений",
                UnitType = SharedParam.GetUnitType(nameof(FinishingRoomNumbers)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Тип отделки_ТЕ
        /// </summary>
        public SharedParam FinishingType
            => new SharedParam(nameof(FinishingType), new Guid("6ccd5d9c-5319-4d80-a9c3-6a3ca2926bdc")) {
                Name = "ФОП_ОТД_Тип отделки_ТЕ",
                UnitType = SharedParam.GetUnitType(nameof(FinishingType)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ФОП_ОТД_Тип пола_ДЕ
        /// </summary>
        public SharedParam FloorFinishingOrder
            => new SharedParam(nameof(FloorFinishingOrder), new Guid("1a76a12a-a54b-4e0e-a741-5f68f6e8fb59")) {
                Name = "ФОП_ОТД_Тип пола_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(FloorFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ОТД_Тип потолка_ДЕ
        /// </summary>
        public SharedParam CeilingFinishingOrder
            => new SharedParam(nameof(CeilingFinishingOrder), new Guid("1a00bb3d-fcc4-46f2-b146-28ab1d17bab4")) {
                Name = "ФОП_ОТД_Тип потолка_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(CeilingFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ОТД_Тип стены_ДЕ
        /// </summary>
        public SharedParam WallFinishingOrder
            => new SharedParam(nameof(WallFinishingOrder), new Guid("4844df04-a9db-4863-8322-c6bf6835c0f6")) {
                Name = "ФОП_ОТД_Тип стены_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(WallFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_ОТД_Тип плинтуса_ДЕ
        /// </summary>
        public SharedParam BaseboardFinishingOrder
            => new SharedParam(nameof(BaseboardFinishingOrder), new Guid("b997afe6-735b-4bb7-8e52-daee5168920e")) {
                Name = "ФОП_ОТД_Тип плинтуса_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(BaseboardFinishingOrder)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Длина_ДЕ
        /// </summary>
        public SharedParam SizeLengthAdditional
            => new SharedParam(nameof(SizeLengthAdditional), new Guid("bc97c75c-073b-4ddc-96d9-29f965afe96d")) {
                Name = "ФОП_РАЗМ_Длина_ДЕ",
                UnitType = SharedParam.GetUnitType(nameof(SizeLengthAdditional)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Площадь
        /// </summary>
        public SharedParam SizeArea
            => new SharedParam(nameof(SizeArea), new Guid("a27c2dbc-9578-41d0-ba1c-e8c1e1c03daa")) {
                Name = "ФОП_РАЗМ_Площадь",
                UnitType = SharedParam.GetUnitType(nameof(SizeArea)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// ФОП_РАЗМ_Объем
        /// </summary>
        public SharedParam SizeVolume
            => new SharedParam(nameof(SizeVolume), new Guid("f0775dbc-b7c0-4323-ae31-7ef706d1cca0")) {
                Name = "ФОП_РАЗМ_Объем",
                UnitType = SharedParam.GetUnitType(nameof(SizeVolume)),
                StorageType = StorageType.Double
            };

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