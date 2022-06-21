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

#if REVIT_2020

        /// <summary>
        /// Пров_Ровно от Оси
        /// </summary>
        public ProjectParam CheckCorrectDistanceGrid
            => new ProjectParam(nameof(CheckCorrectDistanceGrid)) {
                Name = "Пров_Ровно от Оси", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// Пров_Ортогональность Осям
        /// </summary>
        public ProjectParam CheckIsNormalGrid
            => new ProjectParam(nameof(CheckIsNormalGrid)) {
                Name = "Пров_Ортогональность Осям", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Летнее
        /// </summary>
        public ProjectParam IsRoomBalcony
            => new ProjectParam(nameof(IsRoomBalcony)) {
                Name = "КВГ_Летнее", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Жилое
        /// </summary>
        public ProjectParam IsRoomLiving
            => new ProjectParam(nameof(IsRoomLiving)) {
                Name = "КВГ_Жилое", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_ПМЩ_Фиксация номера
        /// </summary>
        public ProjectParam IsRoomNumberFix
            => new ProjectParam(nameof(IsRoomNumberFix)) {
                Name = "КВГ_ПМЩ_Фиксация номера", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Приоритет нумерации
        /// </summary>
        public ProjectParam NumberingOrder
            => new ProjectParam(nameof(NumberingOrder)) {
                Name = "КВГ_Приоритет нумерации", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Стадия Проекта
        /// </summary>
        public ProjectParam ProjectStage
            => new ProjectParam(nameof(ProjectStage)) {
                Name = "_Стадия Проекта", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// _Группа Видов
        /// </summary>
        public ProjectParam ViewGroup
            => new ProjectParam(nameof(ViewGroup)) {
                Name = "_Группа Видов", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// _Полный Номер Листа
        /// </summary>
        public ProjectParam WithFullSheetNumber
            => new ProjectParam(nameof(WithFullSheetNumber)) {
                Name = "_Полный Номер Листа", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Номера Листа Наличие
        /// </summary>
        public ProjectParam WithSheetNumber
            => new ProjectParam(nameof(WithSheetNumber)) {
                Name = "_Номера Листа Наличие", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Номер Вида на Листе
        /// </summary>
        public ProjectParam ViewNumberOnSheet
            => new ProjectParam(nameof(ViewNumberOnSheet)) {
                Name = "_Номер Вида на Листе", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Группа
        /// </summary>
        public ProjectParam RoomGroupName
            => new ProjectParam(nameof(RoomGroupName)) {
                Name = "КВГ_Группа", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Пожарный отсек
        /// </summary>
        public ProjectParam FireCompartmentName
            => new ProjectParam(nameof(FireCompartmentName)) {
                Name = "КВГ_Пожарный отсек", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Секция
        /// </summary>
        public ProjectParam RoomSectionName
            => new ProjectParam(nameof(RoomSectionName)) {
                Name = "КВГ_Секция", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Тип группы помещений
        /// </summary>
        public ProjectParam RoomTypeGroupName
            => new ProjectParam(nameof(RoomTypeGroupName)) {
                Name = "КВГ_Тип группы помещений", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Наименование
        /// </summary>
        public ProjectParam RoomName
            => new ProjectParam(nameof(RoomName)) {
                Name = "КВГ_Наименование", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Коэффициент площади
        /// </summary>
        public ProjectParam RoomAreaRatio
            => new ProjectParam(nameof(RoomAreaRatio)) {
                Name = "КВГ_Коэффициент площади", UnitType = UnitType.UT_Number, StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_Доп. сортировка групп
        /// </summary>
        public ProjectParam ApartmentGroupName
            => new ProjectParam(nameof(ApartmentGroupName)) {
                Name = "КВГ_Доп. сортировка групп", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_ПМЩ_Группа короткое
        /// </summary>
        public ProjectParam RoomGroupShortName
            => new ProjectParam(nameof(RoomGroupShortName)) {
                Name = "КВГ_ПМЩ_Группа короткое", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Пожарный отсек короткое
        /// </summary>
        public ProjectParam FireCompartmentShortName
            => new ProjectParam(nameof(FireCompartmentShortName)) {
                Name = "КВГ_Пожарный отсек короткое", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Секция короткое
        /// </summary>
        public ProjectParam RoomSectionShortName
            => new ProjectParam(nameof(RoomSectionShortName)) {
                Name = "КВГ_Секция короткое", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Тип группы помещений короткий
        /// </summary>
        public ProjectParam RoomTypeGroupShortName
            => new ProjectParam(nameof(RoomTypeGroupShortName)) {
                Name = "КВГ_Тип группы помещений короткий",
                UnitType = UnitType.UT_Number,
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ мин
        /// </summary>
        public ProjectParam ApartmentAreaMinSpec
            => new ProjectParam(nameof(ApartmentAreaMinSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ мин", UnitType = UnitType.UT_Area, StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ макс
        /// </summary>
        public ProjectParam ApartmentAreaMaxSpec
            => new ProjectParam(nameof(ApartmentAreaMaxSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ макс", UnitType = UnitType.UT_Area, StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ
        /// </summary>
        public ProjectParam ApartmentAreaSpec
            => new ProjectParam(nameof(ApartmentAreaSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ", UnitType = UnitType.UT_Number, StorageType = StorageType.String
            };

#else
        
        /// <summary>
        /// Пров_Ровно от Оси
        /// </summary>
        public ProjectParam CheckCorrectDistanceGrid
            => new ProjectParam(nameof(CheckCorrectDistanceGrid)) {
                Name = "Пров_Ровно от Оси", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// Пров_Ортогональность Осям
        /// </summary>
        public ProjectParam CheckIsNormalGrid
            => new ProjectParam(nameof(CheckIsNormalGrid)) {
                Name = "Пров_Ортогональность Осям", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Летнее
        /// </summary>
        public ProjectParam IsRoomBalcony
            => new ProjectParam(nameof(IsRoomBalcony)) {
                Name = "КВГ_Летнее", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Жилое
        /// </summary>
        public ProjectParam IsRoomLiving
            => new ProjectParam(nameof(IsRoomLiving)) {
                Name = "КВГ_Жилое", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_ПМЩ_Фиксация номера
        /// </summary>
        public ProjectParam IsRoomNumberFix
            => new ProjectParam(nameof(IsRoomNumberFix)) {
                Name = "КВГ_ПМЩ_Фиксация номера", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Integer
            };

        /// <summary>
        /// КВГ_Приоритет нумерации
        /// </summary>
        public ProjectParam NumberingOrder
            => new ProjectParam(nameof(NumberingOrder)) {
                Name = "КВГ_Приоритет нумерации", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Стадия Проекта
        /// </summary>
        public ProjectParam ProjectStage
            => new ProjectParam(nameof(ProjectStage)) {
                Name = "_Стадия Проекта", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// _Группа Видов
        /// </summary>
        public ProjectParam ViewGroup
            => new ProjectParam(nameof(ViewGroup)) {
                Name = "_Группа Видов", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// _Полный Номер Листа
        /// </summary>
        public ProjectParam WithFullSheetNumber
            => new ProjectParam(nameof(WithFullSheetNumber)) {
                Name = "_Полный Номер Листа", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Номера Листа Наличие
        /// </summary>
        public ProjectParam WithSheetNumber
            => new ProjectParam(nameof(WithSheetNumber)) {
                Name = "_Номера Листа Наличие", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Integer
            };

        /// <summary>
        /// _Номер Вида на Листе
        /// </summary>
        public ProjectParam ViewNumberOnSheet
            => new ProjectParam(nameof(ViewNumberOnSheet)) {
                Name = "_Номер Вида на Листе", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Группа
        /// </summary>
        public ProjectParam RoomGroupName
            => new ProjectParam(nameof(RoomGroupName)) {
                Name = "КВГ_Группа", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Пожарный отсек
        /// </summary>
        public ProjectParam FireCompartmentName
            => new ProjectParam(nameof(RoomGroupName)) {
                Name = "КВГ_Пожарный отсек", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Секция
        /// </summary>
        public ProjectParam RoomSectionName
            => new ProjectParam(nameof(RoomSectionName)) {
                Name = "КВГ_Секция", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Тип группы помещений
        /// </summary>
        public ProjectParam RoomTypeGroupName
            => new ProjectParam(nameof(RoomTypeGroupName)) {
                Name = "КВГ_Тип группы помещений", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.ElementId
            };

        /// <summary>
        /// КВГ_Наименование
        /// </summary>
        public ProjectParam RoomName
            => new ProjectParam(nameof(RoomTypeGroupName)) {
                Name = "КВГ_Наименование", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.ElementId
            };
        
#endif

#if REVIT_2021

        /// <summary>
        /// КВГ_Коэффициент площади
        /// </summary>
        public ProjectParam RoomAreaRatio
            => new ProjectParam(nameof(RoomAreaRatio)) {
                Name = "КВГ_Коэффициент площади", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_Доп. сортировка групп
        /// </summary>
        public ProjectParam ApartmentGroupName
            => new ProjectParam(nameof(ApartmentGroupName)) {
                Name = "КВГ_Доп. сортировка групп", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_ПМЩ_Группа короткое
        /// </summary>
        public ProjectParam RoomGroupShortName
            => new ProjectParam(nameof(RoomGroupShortName)) {
                Name = "КВГ_ПМЩ_Группа короткое", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Пожарный отсек короткое
        /// </summary>
        public ProjectParam FireCompartmentShortName
            => new ProjectParam(nameof(FireCompartmentShortName)) {
                Name = "КВГ_Пожарный отсек короткое", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Секция короткое
        /// </summary>
        public ProjectParam RoomSectionShortName
            => new ProjectParam(nameof(RoomSectionShortName)) {
                Name = "КВГ_Секция короткое", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_Тип группы помещений короткий
        /// </summary>
        public ProjectParam RoomTypeGroupShortName
            => new ProjectParam(nameof(RoomTypeGroupShortName)) {
                Name = "КВГ_Тип группы помещений короткий",
                UnitTypeName = nameof(SpecTypeId.Number),
                StorageType = StorageType.String
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ мин
        /// </summary>
        public ProjectParam ApartmentAreaMinSpec
            => new ProjectParam(nameof(ApartmentAreaMinSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ мин", UnitTypeName = nameof(SpecTypeId.Area), StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ макс
        /// </summary>
        public ProjectParam ApartmentAreaMaxSpec
            => new ProjectParam(nameof(ApartmentAreaMaxSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ макс", UnitTypeName = nameof(SpecTypeId.Area), StorageType = StorageType.Double
            };

        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ
        /// </summary>
        public ProjectParam ApartmentAreaSpec
            => new ProjectParam(nameof(ApartmentAreaSpec)) {
                Name = "КВГ_КВР_Площадь по ТЗ", UnitTypeName = nameof(SpecTypeId.Number), StorageType = StorageType.String
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