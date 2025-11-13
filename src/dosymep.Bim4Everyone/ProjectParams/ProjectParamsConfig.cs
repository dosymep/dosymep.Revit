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

namespace dosymep.Bim4Everyone.ProjectParams {
    /// <summary>
    /// Конфигурация параметров проекта.
    /// </summary>
    public class ProjectParamsConfig : RevitParamsConfig, IProjectParamsService {
        internal ProjectParamsConfig() {
            _revitParams = new Dictionary<string, RevitParam>();
        }

        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static ProjectParamsConfig Instance { get; internal set; }

        /// <summary>
        /// КВГ_Группа
        /// </summary>
        public ProjectParam RoomGroupName
            { get; } = new ProjectParam(nameof(RoomGroupName)) {
                Name = "КВГ_Группа",
                UnitType = ProjectParam.GetUnitType(nameof(RoomGroupName)),
                StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Пожарный отсек
        /// </summary>
        public ProjectParam FireCompartmentName
            { get; } = new ProjectParam(nameof(FireCompartmentName)) {
                Name = "КВГ_Пожарный отсек",
                UnitType = ProjectParam.GetUnitType(nameof(FireCompartmentName)),
                StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Секция
        /// </summary>
        public ProjectParam RoomSectionName
            { get; } = new ProjectParam(nameof(RoomSectionName)) {
                Name = "КВГ_Секция",
                UnitType = ProjectParam.GetUnitType(nameof(RoomSectionName)),
                StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Тип группы помещений
        /// </summary>
        public ProjectParam RoomTypeGroupName
            { get; } = new ProjectParam(nameof(RoomTypeGroupName)) {
                Name = "КВГ_Тип группы помещений",
                UnitType = ProjectParam.GetUnitType(nameof(RoomTypeGroupName)),
                StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Наименование
        /// </summary>
        public ProjectParam RoomName
            { get; } = new ProjectParam(nameof(RoomName)) {
                Name = "КВГ_Наименование",
                UnitType = ProjectParam.GetUnitType(nameof(RoomName)), StorageType = StorageType.ElementId
            };

        /// <summary>
        /// _Группа Видов
        /// </summary>
        public ProjectParam ViewGroup
            { get; } = new ProjectParam(nameof(ViewGroup)) {
                Name = "_Группа Видов",
                UnitType = ProjectParam.GetUnitType(nameof(ViewGroup)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// _Номер Вида на Листе
        /// </summary>
        public ProjectParam ViewNumberOnSheet
            { get; } = new ProjectParam(nameof(ViewNumberOnSheet)) {
                Name = "_Номер Вида на Листе",
                UnitType = ProjectParam.GetUnitType(nameof(ViewNumberOnSheet)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// _Номера Листа Наличие
        /// </summary>
        public ProjectParam WithSheetNumber
            { get; } = new ProjectParam(nameof(WithSheetNumber)) {
                Name = "_Номера Листа Наличие",
                UnitType = ProjectParam.GetUnitType(nameof(WithSheetNumber)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Полный Номер Листа
        /// </summary>
        public ProjectParam WithFullSheetNumber
            { get; } = new ProjectParam(nameof(WithFullSheetNumber)) {
                Name = "_Полный Номер Листа",
                UnitType = ProjectParam.GetUnitType(nameof(WithFullSheetNumber)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Стадия Проекта
        /// </summary>
        public ProjectParam ProjectStage
            { get; } = new ProjectParam(nameof(ProjectStage)) {
                Name = "_Стадия Проекта",
                UnitType = ProjectParam.GetUnitType(nameof(ProjectStage)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Жилое
        /// </summary>
        public ProjectParam IsRoomLiving
            { get; } = new ProjectParam(nameof(IsRoomLiving)) {
                Name = "КВГ_Жилое",
                UnitType = ProjectParam.GetUnitType(nameof(IsRoomLiving)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Летнее
        /// </summary>
        public ProjectParam IsRoomBalcony
            { get; } = new ProjectParam(nameof(IsRoomBalcony)) {
                Name = "КВГ_Летнее",
                UnitType = ProjectParam.GetUnitType(nameof(IsRoomBalcony)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_ПМЩ_Фиксация номера
        /// </summary>
        public ProjectParam IsRoomNumberFix
            { get; } = new ProjectParam(nameof(IsRoomNumberFix)) {
                Name = "КВГ_ПМЩ_Фиксация номера",
                UnitType = ProjectParam.GetUnitType(nameof(IsRoomNumberFix)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_ПМЩ_Фиксация этажа
        /// </summary>
        public ProjectParam IsRoomLevelFix
            { get; } = new ProjectParam(nameof(IsRoomLevelFix)) {
                Name = "КВГ_ПМЩ_Фиксация этажа",
                UnitType = ProjectParam.GetUnitType(nameof(IsRoomLevelFix)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Приоритет нумерации
        /// </summary>
        public ProjectParam NumberingOrder
            { get; } = new ProjectParam(nameof(NumberingOrder)) {
                Name = "КВГ_Приоритет нумерации",
                UnitType = ProjectParam.GetUnitType(nameof(NumberingOrder)),
                StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Основной этаж
        /// </summary>
        public ProjectParam IsRoomMainLevel
            { get; } = new ProjectParam(nameof(IsRoomMainLevel)) {
                Name = "КВГ_Основной этаж",
                UnitType = ProjectParam.GetUnitType(nameof(IsRoomMainLevel)),
                StorageType = StorageType.Integer
    };

        /// <summary>
        /// Пров_Ортогональность Осям
        /// </summary>
        public ProjectParam CheckIsNormalGrid
            { get; } = new ProjectParam(nameof(CheckIsNormalGrid)) {
                Name = "Пров_Ортогональность Осям",
                UnitType = ProjectParam.GetUnitType(nameof(CheckIsNormalGrid)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// Пров_Ровно от Оси
        /// </summary>
        public ProjectParam CheckCorrectDistanceGrid
            { get; } = new ProjectParam(nameof(CheckCorrectDistanceGrid)) {
                Name = "Пров_Ровно от Оси",
                UnitType = ProjectParam.GetUnitType(nameof(CheckCorrectDistanceGrid)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// Имя помещения
        /// </summary>
        public ProjectParam RelatedRoomName
            { get; } = new ProjectParam(nameof(RelatedRoomName)) {
                Name = "Имя помещения",
                UnitType = ProjectParam.GetUnitType(nameof(RelatedRoomName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// Номер помещения
        /// </summary>
        public ProjectParam RelatedRoomNumber
            { get; } = new ProjectParam(nameof(RelatedRoomNumber)) {
                Name = "Номер помещения",
                UnitType = ProjectParam.GetUnitType(nameof(RelatedRoomNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ID помещения
        /// </summary>
        public ProjectParam RelatedRoomID
            { get; } = new ProjectParam(nameof(RelatedRoomID)) {
                Name = "ID помещения",
                UnitType = ProjectParam.GetUnitType(nameof(RelatedRoomID)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// Группа помещения
        /// </summary>
        public ProjectParam RelatedRoomGroup
            { get; } = new ProjectParam(nameof(RelatedRoomGroup)) {
                Name = "Группа помещения",
                UnitType = ProjectParam.GetUnitType(nameof(RelatedRoomGroup)),
                StorageType = StorageType.String
            };

#if REVIT2020 || REVIT2021

        /// <summary>
        /// КВГ_Доп. сортировка групп
        /// </summary>
        public ProjectParam ApartmentGroupName
            { get; } = new ProjectParam(nameof(ApartmentGroupName)) {
                Name = "КВГ_Доп. сортировка групп",
                UnitType = ProjectParam.GetUnitType(nameof(ApartmentGroupName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Коэффициент площади
        /// </summary>
        public ProjectParam RoomAreaRatio
            { get; } = new ProjectParam(nameof(RoomAreaRatio)) {
                Name = "КВГ_Коэффициент площади",
                UnitType = ProjectParam.GetUnitType(nameof(RoomAreaRatio)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_ПМЩ_Группа короткое
        /// </summary>
        public ProjectParam RoomGroupShortName
            { get; } = new ProjectParam(nameof(RoomGroupShortName)) {
                Name = "КВГ_ПМЩ_Группа короткое",
                UnitType = ProjectParam.GetUnitType(nameof(RoomGroupShortName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Пожарный отсек короткое
        /// </summary>
        public ProjectParam FireCompartmentShortName
            { get; } = new ProjectParam(nameof(FireCompartmentShortName)) {
                Name = "КВГ_Пожарный отсек короткое",
                UnitType = ProjectParam.GetUnitType(nameof(FireCompartmentShortName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Секция короткое
        /// </summary>
        public ProjectParam RoomSectionShortName
            { get; } = new ProjectParam(nameof(RoomSectionShortName)) {
                Name = "КВГ_Секция короткое",
                UnitType = ProjectParam.GetUnitType(nameof(RoomSectionShortName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Тип группы помещений короткий
        /// </summary>
        public ProjectParam RoomTypeGroupShortName
            { get; } = new ProjectParam(nameof(RoomTypeGroupShortName)) {
                Name = "КВГ_Тип группы помещений короткий",
                UnitType = ProjectParam.GetUnitType(nameof(RoomTypeGroupShortName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ мин
        /// </summary>
        public ProjectParam ApartmentAreaMinSpec
            { get; } = new ProjectParam(nameof(ApartmentAreaMinSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ мин",
                UnitType = ProjectParam.GetUnitType(nameof(ApartmentAreaMinSpec)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ макс
        /// </summary>
        public ProjectParam ApartmentAreaMaxSpec
            { get; } = new ProjectParam(nameof(ApartmentAreaMaxSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ макс",
                UnitType = ProjectParam.GetUnitType(nameof(ApartmentAreaMaxSpec)),
                StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ
        /// </summary>
        public ProjectParam ApartmentAreaSpec
            { get; } = new ProjectParam(nameof(ApartmentAreaSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ",
                UnitType = ProjectParam.GetUnitType(nameof(ApartmentAreaSpec)),
                StorageType = StorageType.String
            };

#else
        /// <summary>
        /// ОТД_Тип отделки
        /// </summary>
        public ProjectParam RoomFinishingType
            { get; } = new ProjectParam(nameof(RoomGroupName)) {
                Name = "ОТД_Тип отделки",
                UnitType = ProjectParam.GetUnitType(nameof(RoomFinishingType)),
                StorageType = StorageType.ElementId
            };

        /// <summary>
        /// ВС_Наименование спецификации
        /// </summary>
        public ProjectParam ListOfSchedulesListName
            { get; } = new ProjectParam(nameof(ListOfSchedulesListName)) {
                Name = "ВС_Наименование спецификации",
                UnitType = ProjectParam.GetUnitType(nameof(ListOfSchedulesListName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ВС_Номер листа
        /// </summary>
        public ProjectParam ListOfSchedulesSheetName
            { get; } = new ProjectParam(nameof(ListOfSchedulesSheetName)) {
                Name = "ВС_Номер листа",
                UnitType = ProjectParam.GetUnitType(nameof(ListOfSchedulesSheetName)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ВС_Номер изменения
        /// </summary>
        public ProjectParam ListOfSchedulesRevNumber
            { get; } = new ProjectParam(nameof(ListOfSchedulesRevNumber)) {
                Name = "ВС_Номер изменения",
                UnitType = ProjectParam.GetUnitType(nameof(ListOfSchedulesRevNumber)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ВС_Примечания
        /// </summary>
        public ProjectParam ListOfSchedulesNotes
            { get; } = new ProjectParam(nameof(ListOfSchedulesNotes)) {
                Name = "ВС_Примечания",
                UnitType = ProjectParam.GetUnitType(nameof(ListOfSchedulesNotes)),
                StorageType = StorageType.String
            };

        /// <summary>
        /// ВС_Группировка
        /// </summary>
        public ProjectParam ListOfSchedulesGroup
            { get; } = new ProjectParam(nameof(ListOfSchedulesGroup)) {
                Name = "ВС_Группировка",
                UnitType = ProjectParam.GetUnitType(nameof(ListOfSchedulesGroup)),
                StorageType = StorageType.String
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
        public ProjectParam CreateRevitParam(Document document, string revitParamName) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, revitParamName, document.GetProjectParam(revitParamName));
        }

        /// <inheritdoc />
        public ProjectParam CreateRevitParam(Document document, ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            return CreateRevitParam(document, revitParamElement.Name, revitParamElement);
        }

        /// <inheritdoc />
        public ProjectParam CreateRevitParam(Document document, string propertyName, string revitParamName) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(string.IsNullOrEmpty(revitParamName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(revitParamName));
            }

            return CreateRevitParam(document, propertyName, document.GetProjectParam(revitParamName));
        }

        /// <inheritdoc />
        public ProjectParam CreateRevitParam(Document document, string propertyName,
            ParameterElement revitParamElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(revitParamElement == null) {
                throw new ArgumentNullException(nameof(revitParamElement));
            }

            return new ProjectParam(propertyName) {
                Name = revitParamElement.Name,
                UnitType = revitParamElement.GetUnitType(),
                StorageType = revitParamElement.GetStorageType(),
            };
        }

        /// <inheritdoc/>
        ProjectParam IProjectParamsService.this[string paramId]
            => (ProjectParam) this[paramId];

        /// <inheritdoc />
        IEnumerable<ProjectParam> IProjectParamsService.GetRevitParams() {
            return base.GetRevitParams().OfType<ProjectParam>();
        }

        /// <inheritdoc/>
        IEnumerable<RevitParam> IParamElementService.GetRevitParams(Document document) {
            return GetRevitParams(document);
        }

        /// <inheritdoc/>
        public IEnumerable<ProjectParam> GetRevitParams(Document document) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(ParameterElement))
                .OfType<ParameterElement>()
                .Where(item => item.IsProjectParam())
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
        public static ProjectParamsConfig Load(string configPath) {
            return File.Exists(configPath)
                ? JsonConvert.DeserializeObject<ProjectParamsConfig>(File.ReadAllText(configPath))
                : GetDefaultConfig();
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