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
#if D2020 || R2020
            _revitParams = new Dictionary<string, RevitParam>() {
                {
                    nameof(ViewNumberOnSheet),
                    new ProjectParam(nameof(ViewNumberOnSheet)) {
                        Name = "_Номер Вида на Листе", UnitType = UnitType.UT_Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(RoomGroupName),
                    new ProjectParam(nameof(RoomGroupName)) {
                        Name = "КВГ_Группа", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
                    }
                }, {
                    nameof(FireCompartmentName),
                    new ProjectParam(nameof(FireCompartmentName)) {
                        Name = "КВГ_Пожарный отсек", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
                    }
                }, {
                    nameof(RoomSectionName),
                    new ProjectParam(nameof(RoomSectionName)) {
                        Name = "КВГ_Секция", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
                    }
                }, {
                    nameof(RoomTypeGroupName),
                    new ProjectParam(nameof(RoomTypeGroupName)) {
                        Name = "КВГ_Тип группы помещений",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.ElementId
                    }
                }, {
                    nameof(RoomName),
                    new ProjectParam(nameof(RoomName)) {
                        Name = "КВГ_Наименование", UnitType = UnitType.UT_Number, StorageType = StorageType.ElementId
                    }
                }, {
                    nameof(CheckCorrectDistanceGrid),
                    new ProjectParam(nameof(CheckCorrectDistanceGrid)) {
                        Name = "Пров_Ровно от Оси", UnitType = UnitType.UT_Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(CheckIsNormalGrid),
                    new ProjectParam(nameof(CheckIsNormalGrid)) {
                        Name = "Пров_Ортогональность Осям",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.String
                    }
                }, {
                    nameof(IsRoomBalcony),
                    new ProjectParam(nameof(IsRoomBalcony)) {
                        Name = "КВГ_Летнее", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(IsRoomLiving),
                    new ProjectParam(nameof(IsRoomLiving)) {
                        Name = "КВГ_Жилое", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(IsRoomNumberFix),
                    new ProjectParam(nameof(IsRoomNumberFix)) {
                        Name = "КВГ_ПМЩ_Фиксация номера",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.Integer
                    }
                }, {
                    nameof(NumberingOrder),
                    new ProjectParam(nameof(NumberingOrder)) {
                        Name = "КВГ_Приоритет нумерации",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.Integer
                    }
                }, {
                    nameof(ProjectStage),
                    new ProjectParam(nameof(ProjectStage)) {
                        Name = "_Стадия Проекта", UnitType = UnitType.UT_Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(ViewGroup),
                    new ProjectParam(nameof(ViewGroup)) {
                        Name = "_Группа Видов", UnitType = UnitType.UT_Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(WithFullSheetNumber),
                    new ProjectParam(nameof(WithFullSheetNumber)) {
                        Name = "_Полный Номер Листа", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(WithSheetNumber),
                    new ProjectParam(nameof(WithSheetNumber)) {
                        Name = "_Номера Листа Наличие", UnitType = UnitType.UT_Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(RoomAreaRatio),
                    new ProjectParam(nameof(RoomAreaRatio)) {
                        Name = "КВГ_Коэффициент площади",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.Double
                    }
                }, {
                    nameof(ApartmentGroupName),
                    new ProjectParam(nameof(ApartmentGroupName)) {
                        Name = "КВГ_Доп. сортировка групп",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.String
                    }
                }, {
                    nameof(RoomGroupShortName),
                    new ProjectParam(nameof(RoomGroupShortName)) {
                        Name = "КВГ_ПМЩ_Группа короткое",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.String
                    }
                }, {
                    nameof(FireCompartmentShortName),
                    new ProjectParam(nameof(FireCompartmentShortName)) {
                        Name = "КВГ_Пожарный отсек короткое",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.String
                    }
                }, {
                    nameof(RoomSectionShortName),
                    new ProjectParam(nameof(RoomSectionShortName)) {
                        Name = "КВГ_Секция короткое", UnitType = UnitType.UT_Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(RoomTypeGroupShortName),
                    new ProjectParam(nameof(RoomTypeGroupShortName)) {
                        Name = "КВГ_Тип группы помещений короткий",
                        UnitType = UnitType.UT_Number,
                        StorageType = StorageType.String
                    }
                }, {
                    nameof(ApartmentAreaMinSpec),
                    new ProjectParam(nameof(ApartmentAreaMinSpec)) {
                        Name = "КВГ_КВР_Площадь по ТЗ мин",
                        UnitType = UnitType.UT_Area,
                        StorageType = StorageType.Double
                    }
                }, {
                    nameof(ApartmentAreaMaxSpec),
                    new ProjectParam(nameof(ApartmentAreaMaxSpec)) {
                        Name = "КВГ_КВР_Площадь по ТЗ макс",
                        UnitType = UnitType.UT_Area,
                        StorageType = StorageType.Double
                    }
                }, {
                    nameof(ApartmentAreaSpec),
                    new ProjectParam(nameof(ApartmentAreaSpec)) {
                        Name = "КВГ_КВР_Площадь по ТЗ", UnitType = UnitType.UT_Number, StorageType = StorageType.String
                    }
                },
            };
#else

            _revitParams = new Dictionary<string, RevitParam>() {
                {
                    nameof(CheckCorrectDistanceGrid),
                    new ProjectParam(nameof(CheckCorrectDistanceGrid)) {
                        Name = "Пров_Ровно от Оси", UnitType = SpecTypeId.Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(CheckIsNormalGrid),
                    new ProjectParam(nameof(CheckIsNormalGrid)) {
                        Name = "Пров_Ортогональность Осям",
                        UnitType = SpecTypeId.Number,
                        StorageType = StorageType.String
                    }
                }, {
                    nameof(IsRoomBalcony),
                    new ProjectParam(nameof(IsRoomBalcony)) {
                        Name = "КВГ_Летнее", UnitType = SpecTypeId.Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(IsRoomLiving),
                    new ProjectParam(nameof(IsRoomLiving)) {
                        Name = "КВГ_Жилое", UnitType = SpecTypeId.Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(IsRoomNumberFix),
                    new ProjectParam(nameof(IsRoomNumberFix)) {
                        Name = "КВГ_ПМЩ_Фиксация номера",
                        UnitType = SpecTypeId.Number,
                        StorageType = StorageType.Integer
                    }
                }, {
                    nameof(NumberingOrder),
                    new ProjectParam(nameof(NumberingOrder)) {
                        Name = "КВГ_Приоритет нумерации",
                        UnitType = SpecTypeId.Number,
                        StorageType = StorageType.Integer
                    }
                }, {
                    nameof(ProjectStage),
                    new ProjectParam(nameof(ProjectStage)) {
                        Name = "_Стадия Проекта", UnitType = SpecTypeId.Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(ViewGroup),
                    new ProjectParam(nameof(ViewGroup)) {
                        Name = "_Группа Видов", UnitType = SpecTypeId.Number, StorageType = StorageType.String
                    }
                }, {
                    nameof(WithFullSheetNumber),
                    new ProjectParam(nameof(WithFullSheetNumber)) {
                        Name = "_Полный Номер Листа", UnitType = SpecTypeId.Number, StorageType = StorageType.Integer
                    }
                }, {
                    nameof(WithSheetNumber),
                    new ProjectParam(nameof(WithSheetNumber)) {
                        Name = "_Номера Листа Наличие", UnitType = SpecTypeId.Number, StorageType = StorageType.Integer
                    }
                },
            };

#endif
        }

        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static ProjectParamsConfig Instance { get; internal set; }

        /// <summary>
        /// Пров_Ровно от Оси
        /// </summary>
        public ProjectParam CheckCorrectDistanceGrid => (ProjectParam) this[nameof(CheckCorrectDistanceGrid)];

        /// <summary>
        /// Пров_Ортогональность Осям
        /// </summary>
        public ProjectParam CheckIsNormalGrid => (ProjectParam) this[nameof(CheckIsNormalGrid)];

        /// <summary>
        /// КВГ_Летнее
        /// </summary>
        public ProjectParam IsRoomBalcony => (ProjectParam) this[nameof(IsRoomBalcony)];

        /// <summary>
        /// КВГ_Жилое
        /// </summary>
        public ProjectParam IsRoomLiving => (ProjectParam) this[nameof(IsRoomLiving)];

        /// <summary>
        /// КВГ_ПМЩ_Фиксация номера
        /// </summary>
        public ProjectParam IsRoomNumberFix => (ProjectParam) this[nameof(IsRoomNumberFix)];

        /// <summary>
        /// КВГ_Приоритет нумерации
        /// </summary>
        public ProjectParam NumberingOrder => (ProjectParam) this[nameof(NumberingOrder)];

        /// <summary>
        /// _Стадия Проекта
        /// </summary>
        public ProjectParam ProjectStage => (ProjectParam) this[nameof(ProjectStage)];

        /// <summary>
        /// _Группа Видов
        /// </summary>
        public ProjectParam ViewGroup => (ProjectParam) this[nameof(ViewGroup)];

        /// <summary>
        /// _Полный Номер Листа
        /// </summary>
        public ProjectParam WithFullSheetNumber => (ProjectParam) this[nameof(WithFullSheetNumber)];

        /// <summary>
        /// _Номера Листа Наличие
        /// </summary>
        public ProjectParam WithSheetNumber => (ProjectParam) this[nameof(WithSheetNumber)];

        /// <summary>
        /// _Номер Вида на Листе
        /// </summary>
        public ProjectParam ViewNumberOnSheet => (ProjectParam) this[nameof(ViewNumberOnSheet)];

        /// <summary>
        /// КВГ_Группа
        /// </summary>
        public ProjectParam RoomGroupName => (ProjectParam) this[nameof(RoomGroupName)];

        /// <summary>
        /// КВГ_Пожарный отсек
        /// </summary>
        public ProjectParam FireCompartmentName => (ProjectParam) this[nameof(FireCompartmentName)];

        /// <summary>
        /// КВГ_Секция
        /// </summary>
        public ProjectParam RoomSectionName => (ProjectParam) this[nameof(RoomSectionName)];

        /// <summary>
        /// КВГ_Тип группы помещений
        /// </summary>
        public ProjectParam RoomTypeGroupName => (ProjectParam) this[nameof(RoomTypeGroupName)];

        /// <summary>
        /// КВГ_Наименование
        /// </summary>
        public ProjectParam RoomName => (ProjectParam) this[nameof(RoomName)];


#if D2020 || R2020 || D2021 || R2021
        /// <summary>
        /// КВГ_Коэффициент площади
        /// </summary>
        public ProjectParam RoomAreaRatio => (ProjectParam) this[nameof(RoomAreaRatio)];
        
        /// <summary>
        /// КВГ_Доп. сортировка групп
        /// </summary>
        public ProjectParam ApartmentGroupName => (ProjectParam) this[nameof(ApartmentGroupName)];
        
        /// <summary>
        /// КВГ_ПМЩ_Группа короткое
        /// </summary>
        public ProjectParam RoomGroupShortName => (ProjectParam) this[nameof(RoomGroupShortName)];
        
        /// <summary>
        /// КВГ_Пожарный отсек короткое
        /// </summary>
        public ProjectParam FireCompartmentShortName => (ProjectParam) this[nameof(FireCompartmentShortName)];
        
        /// <summary>
        /// КВГ_Секция короткое
        /// </summary>
        public ProjectParam RoomSectionShortName => (ProjectParam) this[nameof(RoomSectionShortName)];
        
        /// <summary>
        /// КВГ_Тип группы помещений короткий
        /// </summary>
        public ProjectParam RoomTypeGroupShortName => (ProjectParam) this[nameof(RoomTypeGroupShortName)];
        
        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ мин
        /// </summary>
        public ProjectParam ApartmentAreaMinSpec => (ProjectParam) this[nameof(ApartmentAreaMinSpec)];
        
        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ макс
        /// </summary>
        public ProjectParam ApartmentAreaMaxSpec => (ProjectParam) this[nameof(ApartmentAreaMaxSpec)];
        
        /// <summary>
        /// КВГ_КВР_Площадь по ТЗ
        /// </summary>
        public ProjectParam ApartmentAreaSpec => (ProjectParam) this[nameof(ApartmentAreaSpec)];

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