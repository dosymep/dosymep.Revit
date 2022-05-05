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
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="LoadInstance(string)"/></remarks>
        public static SharedParamsConfig Instance { get; internal set; }

        #region

        /// <summary>
        /// ADSK_Комплект чертежей
        /// </summary>
        public SharedParam AlbumBlueprints { get; internal set; } = new SharedParam() { Id = nameof(AlbumBlueprints), Name = "ADSK_Комплект чертежей" };

        /// <summary>
        /// ADSK_Имя системы
        /// </summary>
        public SharedParam MechanicalSystemName { get; internal set; } = new SharedParam() { Id = nameof(MechanicalSystemName), Name = "ADSK_Имя системы" };


        #endregion

        #region Штамп

        /// <summary>
        /// Ш.НомерЛиста
        /// </summary>
        public SharedParam StampSheetNumber { get; internal set; } = new SharedParam() { Id = nameof(StampSheetNumber), Name = "Ш.НомерЛиста" };

        #endregion

        #region Квартирография

        /// <summary>
        /// ФОП_ПМЩ_Площадь
        /// </summary>
        public SharedParam RoomArea { get; internal set; } = new SharedParam() { Id = nameof(RoomArea), Name = "ФОП_ПМЩ_Площадь" };

        /// <summary>
        /// ФОП_ПМЩ_Площадь с коэф.
        /// </summary>
        public SharedParam RoomAreaWithRatio { get; internal set; } = new SharedParam() { Id = nameof(RoomAreaWithRatio), Name = "ФОП_ПМЩ_Площадь с коэф." };

        /// <summary>
        /// ФОП_КВР_Площадь с коэф.
        /// </summary>
        public SharedParam ApartmentAreaRatio { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaRatio), Name = "ФОП_КВР_Площадь с коэф." };

        /// <summary>
        /// ФОП_КВР_Площадь без ЛП
        /// </summary>
        public SharedParam ApartmentAreaNoBalcony { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaNoBalcony), Name = "ФОП_КВР_Площадь без ЛП" };

        /// <summary>
        /// ФОП_КВР_Площадь жилая
        /// </summary>
        public SharedParam ApartmentLivingArea { get; internal set; } = new SharedParam() { Id = nameof(ApartmentLivingArea), Name = "ФОП_КВР_Площадь жилая" };

        /// <summary>
        /// ФОП_КВР_Площадь без коэф.
        /// </summary>
        public SharedParam ApartmentArea { get; internal set; } = new SharedParam() { Id = nameof(ApartmentArea), Name = "ФОП_КВР_Площадь без коэф." };

        /// <summary>
        /// ФОП_КВР_Площадь по пятну
        /// </summary>
        public SharedParam ApartmentFullArea { get; internal set; } = new SharedParam() { Id = nameof(ApartmentFullArea), Name = "ФОП_КВР_Площадь по пятну" };

        /// <summary>
        /// ФОП_Номер квартиры
        /// </summary>
        public SharedParam ApartmentNumber { get; internal set; } = new SharedParam() { Id = nameof(ApartmentNumber), Name = "ФОП_Номер квартиры" };

        /// <summary>
        /// ФОП_Доп. номер помещения
        /// </summary>
        public SharedParam ApartmentNumberExtra { get; internal set; } = new SharedParam() { Id = nameof(ApartmentNumberExtra), Name = "ФОП_Доп. номер помещения" };

        /// <summary>
        /// ФОП_Количество комнат
        /// </summary>
        public SharedParam RoomsCount { get; internal set; } = new SharedParam() { Id = nameof(RoomsCount), Name = "ФОП_Количество комнат" };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь с коэф.
        /// </summary>
        public SharedParam ApartmentAreaRatioFix { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaRatioFix), Name = "ФОП_ФИКС_КВР_Площадь с коэф." };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь без ЛП
        /// </summary>
        public SharedParam ApartmentAreaNoBalconyFix { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaNoBalconyFix), Name = "ФОП_ФИКС_КВР_Площадь без ЛП" };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь жилая
        /// </summary>
        public SharedParam ApartmentLivingAreaFix { get; internal set; } = new SharedParam() { Id = nameof(ApartmentLivingAreaFix), Name = "ФОП_ФИКС_КВР_Площадь жилая" };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь без коэф.
        /// </summary>
        public SharedParam ApartmentAreaFix { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaFix), Name = "ФОП_ФИКС_КВР_Площадь без коэф." };

        /// <summary>
        /// ФОП_ФИКС_ПМЩ_Площадь
        /// </summary>
        public SharedParam RoomAreaFix { get; internal set; } = new SharedParam() { Id = nameof(RoomAreaFix), Name = "ФОП_ФИКС_ПМЩ_Площадь" };

        /// <summary>
        /// ФОП_ФИКС_ПМЩ_Площадь с коэф.
        /// </summary>
        public SharedParam RoomAreaWithRatioFix { get; internal set; } = new SharedParam() { Id = nameof(RoomAreaWithRatioFix), Name = "ФОП_ФИКС_ПМЩ_Площадь с коэф." };

        /// <summary>
        /// ФОП_ФИКС_КВР_Площадь по пятну
        /// </summary>
        public SharedParam ApartmentFullAreaFix { get; internal set; } = new SharedParam() { Id = nameof(ApartmentFullAreaFix), Name = "ФОП_ФИКС_КВР_Площадь по пятну" };

        /// <summary>
        /// ФОП_Коэффициент площади
        /// </summary>
        public SharedParam RoomAreaRatio { get; internal set; } = new SharedParam() { Id = nameof(RoomAreaRatio), Name = "ФОП_Коэффициент площади" };

        /// <summary>
        /// ФОП_Доп. сортировка групп
        /// </summary>
        public SharedParam ApartmentGroupName { get; internal set; } = new SharedParam() { Id = nameof(ApartmentGroupName), Name = "ФОП_Доп. сортировка групп" };

        /// <summary>
        /// ФОП_ПМЩ_Группа
        /// </summary>
        public SharedParam RoomGroupShortName { get; internal set; } = new SharedParam() { Id = nameof(RoomGroupShortName), Name = "ФОП_ПМЩ_Группа" };

        /// <summary>
        /// ФОП_Пожарный отсек
        /// </summary>
        public SharedParam FireCompartmentShortName { get; internal set; } = new SharedParam() { Id = nameof(FireCompartmentShortName), Name = "ФОП_Пожарный отсек" };

        /// <summary>
        /// ФОП_ПМЩ_Секция
        /// </summary>
        public SharedParam RoomSectionShortName { get; internal set; } = new SharedParam() { Id = nameof(RoomSectionShortName), Name = "ФОП_ПМЩ_Секция" };

        /// <summary>
        /// ФОП_Тип группы помещений
        /// </summary>
        public SharedParam RoomTypeGroupShortName { get; internal set; } = new SharedParam() { Id = nameof(RoomTypeGroupShortName), Name = "ФОП_Тип группы помещений" };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ
        /// </summary>
        public SharedParam ApartmentAreaSpec { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaSpec), Name = "ФОП_КВР_Площадь по ТЗ" };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ мин
        /// </summary>
        public SharedParam ApartmentAreaMinSpec { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaMinSpec), Name = "ФОП_КВР_Площадь по ТЗ мин" };

        /// <summary>
        /// ФОП_КВР_Площадь по ТЗ макс
        /// </summary>
        public SharedParam ApartmentAreaMaxSpec { get; internal set; } = new SharedParam() { Id = nameof(ApartmentAreaMaxSpec), Name = "ФОП_КВР_Площадь по ТЗ макс" };

        #endregion

        #region Секции

        /// <summary>
        /// ФОП_Этаж
        /// </summary>
        public SharedParam Level { get; internal set; } = new SharedParam() { Id = nameof(Level), Name = "ФОП_Этаж" };

        /// <summary>
        /// ФОП_Номер секции
        /// </summary>
        public SharedParam BuildingWorksSection { get; internal set; } = new SharedParam() { Id = nameof(BuildingWorksSection), Name = "ФОП_Секция СМР" };

        /// <summary>
        /// ФОП_Блок СМР
        /// </summary>
        public SharedParam BuildingWorksBlock { get; internal set; } = new SharedParam() { Id = nameof(BuildingWorksBlock), Name = "ФОП_Блок СМР" };

        /// <summary>
        /// ФОП_Экономическая функция
        /// </summary>
        public SharedParam EconomicFunction { get; internal set; } = new SharedParam() { Id = nameof(EconomicFunction), Name = "ФОП_Экономическая функция" };

        #endregion

        #region ВИС
        
        /// <summary>
        /// ФОП_ВИС_Группирование
        /// </summary>
        public SharedParam VISGrouping { get; internal set; } = new SharedParam() { Id = nameof(VISGrouping), Name = "ФОП_ВИС_Группирование" };
        
        /// <summary>
        /// ФОП_ВИС_Масса
        /// </summary>
        public SharedParam VISMass { get; internal set; } = new SharedParam() { Id = nameof(VISMass), Name = "ФОП_ВИС_Масса" };
        
        /// <summary>
        /// ФОП_ВИС_Единица измерения
        /// </summary>
        public SharedParam VISUnit { get; internal set; } = new SharedParam() { Id = nameof(VISUnit), Name = "ФОП_ВИС_Единица измерения" };
        
        /// <summary>
        /// ФОП_ВИС_Минимальная толщина воздуховода
        /// </summary>
        public SharedParam VISMinDuctThickness { get; internal set; } = new SharedParam() { Id = nameof(VISMinDuctThickness), Name = "ФОП_ВИС_Минимальная толщина воздуховода" };
        
        /// <summary>
        /// ФОП_ВИС_Наименование комбинированное
        /// </summary>
        public SharedParam VISCombinedName { get; internal set; } = new SharedParam() { Id = nameof(VISCombinedName), Name = "ФОП_ВИС_Наименование комбинированное" };
        
        /// <summary>
        /// ФОП_ВИС_Число
        /// </summary>
        public SharedParam VISSpecNumbers { get; internal set; } = new SharedParam() { Id = nameof(VISSpecNumbers), Name = "ФОП_ВИС_Число" };
        
        /// <summary>
        /// ФОП_ВИС_Экономическая функция
        /// </summary>
        public SharedParam VISEconomicFunction { get; internal set; } = new SharedParam() { Id = nameof(VISEconomicFunction), Name = "ФОП_ВИС_Экономическая функция" };

        #endregion

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, string revitParamName) {
            return CreateRevitParam(document, revitParamName);
        }

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, ParameterElement revitParamElement) {
            return CreateRevitParam(document, revitParamElement);
        }

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, string propertyName, string revitParamName) {
            return CreateRevitParam(document, propertyName, revitParamName);
        }

        /// <inheritdoc />
        RevitParam IParamElementService.CreateRevitParam(Document document, string propertyName,
            ParameterElement revitParamElement) {
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

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, propertyName, document.GetSharedParam(revitParamName));
        }

        /// <inheritdoc />
        public SharedParam CreateRevitParam(Document document, string propertyName, ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            return new SharedParam(((SharedParameterElement) revitParamElement).GuidValue,
                revitParamElement.GetStorageType()) {Id = propertyName, Name = revitParamElement.Name};
        }
        
        /// <inheritdoc/>
        SharedParam ISharedParamsService.this[string paramId] 
            => (SharedParam) this[paramId];

        /// <inheritdoc />
        IEnumerable<SharedParam> ISharedParamsService.GetRevitParams() {
            return base.GetRevitParams().OfType<SharedParam>();
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
            return File.Exists(configPath) ? JsonConvert.DeserializeObject<SharedParamsConfig>(File.ReadAllText(configPath)) : GetDefaultConfig();
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
