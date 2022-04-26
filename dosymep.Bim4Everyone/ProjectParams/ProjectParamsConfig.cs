using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.ProjectParams {
    /// <summary>
    /// Конфигурация параметров проекта.
    /// </summary>
    public class ProjectParamsConfig : RevitParamsConfig {
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static ProjectParamsConfig Instance { get; internal set; }

        #region Нумерация видов на листе

        /// <summary>
        /// _Номер Вида на Листе
        /// </summary>
        public ProjectParam ViewNumberOnSheet { get; internal set; } = new ProjectParam() { PropertyName = nameof(ViewNumberOnSheet), Name = "_Номер Вида на Листе" };

        /// <summary>
        /// _Полный Номер Листа
        /// </summary>
        public ProjectParam WithFullSheetNumber { get; internal set; } = new ProjectParam() { PropertyName = nameof(WithFullSheetNumber), Name = "_Полный Номер Листа" };

        /// <summary>
        /// _Номера Листа Наличие
        /// </summary>
        public ProjectParam WithSheetNumber { get; internal set; } = new ProjectParam() { PropertyName = nameof(WithSheetNumber), Name = "_Номера Листа Наличие" };

        #endregion

        #region Параметры организации браузера

        /// <summary>
        /// _Группа Видов
        /// </summary>
        public ProjectParam ViewGroup { get; internal set; } = new ProjectParam() { PropertyName = nameof(ViewGroup), Name = "_Группа Видов" };

        /// <summary>
        /// _Стадия Проекта
        /// </summary>
        public ProjectParam ProjectStage { get; internal set; } = new ProjectParam() { PropertyName = nameof(ProjectStage), Name = "_Стадия Проекта" };

        #endregion

        #region Проверки

        /// <summary>
        /// Пров_Ортогональность Осям
        /// </summary>
        public ProjectParam CheckIsNormalGrid { get; internal set; } = new ProjectParam() { PropertyName = nameof(CheckIsNormalGrid), Name = "Пров_Ортогональность Осям" };

        /// <summary>
        /// Пров_Ровно от Оси
        /// </summary>
        public ProjectParam CheckCorrectDistanceGrid { get; internal set; } = new ProjectParam() { PropertyName = nameof(CheckCorrectDistanceGrid), Name = "Пров_Ровно от Оси" };

        #endregion

        #region Квартирография

        /// <summary>
        /// КВГ_Группа
        /// </summary>
        public ProjectParam RoomGroupName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomGroupName), Name = "КВГ_Группа" };

        /// <summary>
        /// КВГ_Пожарный отсек
        /// </summary>
        public ProjectParam FireCompartmentName { get; internal set; } = new ProjectParam() { PropertyName = nameof(FireCompartmentName), Name = "КВГ_Пожарный отсек" };

        /// <summary>
        /// КВГ_Секция
        /// </summary>
        public ProjectParam RoomSectionName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomSectionName), Name = "КВГ_Секция" };

        /// <summary>
        /// КВГ_Тип группы помещений
        /// </summary>
        public ProjectParam RoomTypeGroupName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomTypeGroupName), Name = "КВГ_Тип группы помещений" };

        /// <summary>
        /// КВГ_Наименование
        /// </summary>
        public ProjectParam RoomName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomName), Name = "КВГ_Наименование" };

        /// <summary>
        /// КВГ_Летнее
        /// </summary>
        public ProjectParam IsRoomBalcony { get; internal set; } = new ProjectParam() { PropertyName = nameof(IsRoomBalcony), Name = "КВГ_Летнее" };

        /// <summary>
        /// КВГ_Жилое
        /// </summary>
        public ProjectParam IsRoomLiving { get; internal set; } = new ProjectParam() { PropertyName = nameof(IsRoomLiving), Name = "КВГ_Жилое" };

        /// <summary>
        /// КВГ_ПМЩ_Фиксация номера
        /// </summary>
        public ProjectParam IsRoomNumberFix { get; internal set; } = new ProjectParam() { PropertyName = nameof(IsRoomNumberFix), Name = "КВГ_ПМЩ_Фиксация номера" };

        /// <summary>
        /// КВГ_Приоритет нумерации
        /// </summary>
        public ProjectParam NumberingOrder { get; internal set; } = new ProjectParam() { PropertyName = nameof(NumberingOrder), Name = "КВГ_Приоритет нумерации" };

#if D2020 || R2020 || D2021 || R2021

        /// <summary>
        /// КВГ_Коэффициент площади
        /// </summary>
        public ProjectParam RoomAreaRatio { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomAreaRatio), Name = "КВГ_Коэффициент площади" };

        /// <summary>
        /// КВГ_Доп. сортировка групп
        /// </summary>
        public ProjectParam ApartmentGroupName { get; internal set; } = new ProjectParam() { PropertyName = nameof(ApartmentGroupName), Name = "КВГ_Доп. сортировка групп" };

        /// <summary>
        /// КВГ_ПМЩ_Группа короткое
        /// </summary>
        public ProjectParam RoomGroupShortName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomGroupShortName), Name = "КВГ_ПМЩ_Группа короткое" };

        /// <summary>
        /// КВГ_Пожарный отсек короткое
        /// </summary>
        public ProjectParam FireCompartmentShortName { get; internal set; } = new ProjectParam() { PropertyName = nameof(FireCompartmentShortName), Name = "КВГ_Пожарный отсек короткое" };

        /// <summary>
        /// КВГ_Секция короткое
        /// </summary>
        public ProjectParam RoomSectionShortName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomSectionShortName), Name = "КВГ_Секция короткое" };

        /// <summary>
        /// КВГ_Тип группы помещений короткий
        /// </summary>
        public ProjectParam RoomTypeGroupShortName { get; internal set; } = new ProjectParam() { PropertyName = nameof(RoomTypeGroupShortName), Name = "КВГ_Тип группы помещений короткий" };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ
        /// </summary>
        public ProjectParam ApartmentAreaSpec { get; internal set; } = new ProjectParam() { PropertyName = nameof(ApartmentAreaSpec), Name = "КВГ_КВР_Площадь по ТЗ" };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ мин
        /// </summary>
        public ProjectParam ApartmentAreaMinSpec { get; internal set; } = new ProjectParam() { PropertyName = nameof(ApartmentAreaMinSpec), Name = "КВГ_КВР_Площадь по ТЗ мин" };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ макс
        /// </summary>
        public ProjectParam ApartmentAreaMaxSpec { get; internal set; } = new ProjectParam() { PropertyName = nameof(ApartmentAreaMaxSpec), Name = "КВГ_КВР_Площадь по ТЗ макс" };

#endif

        #endregion

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
        public static ProjectParamsConfig Load(string configPath) {
            return File.Exists(configPath) ? JsonConvert.DeserializeObject<ProjectParamsConfig>(File.ReadAllText(configPath)) : GetDefaultConfig();
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static ProjectParamsConfig GetDefaultConfig() {
            return new ProjectParamsConfig();
        }
    }
}
