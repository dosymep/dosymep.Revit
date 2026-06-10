using System.IO;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.KeySchedules;

/// <summary>
///     Класс конфигурации ключевых спецификаций.
/// </summary>
public class KeySchedulesConfig : RevitSchedulesConfig {
    /// <summary>
    ///     Текущее состояние конфигурации.
    /// </summary>
    /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)" /></remarks>
    public static KeySchedulesConfig Instance { get; internal set; }

    #region Квартирография

#if REVIT2020 || REVIT2021
        /// <summary>
        /// КВГ_(Ключ.) - Группа помещений
        /// </summary>
        public KeyScheduleRule RoomsGroups { get; internal set; } 
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Группа помещений",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomGroupName),

                RequiredSharedParams = new List<string>(),
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.ApartmentGroupName),
                    nameof(ProjectParamsConfig.RoomGroupShortName)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomGroupShortName)
                }
            };

        /// <summary>
        /// КВГ_(Ключ.) - Наименование пом.
        /// </summary>
        public KeyScheduleRule RoomsNames { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Наименование пом.",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomName),

                RequiredSharedParams = new List<string>() { },
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.RoomAreaRatio), 
                    nameof(ProjectParamsConfig.IsRoomBalcony), 
                    nameof(ProjectParamsConfig.IsRoomLiving),
                    nameof(ProjectParamsConfig.NumberingOrder),
                },
                RequiredSystemParams = new List<BuiltInParameter>() {
                    BuiltInParameter.ROOM_NAME,
                    BuiltInParameter.ROOM_DEPARTMENT
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomAreaRatio), 
                },
                FilledSystemParams = new List<BuiltInParameter>() {
                    BuiltInParameter.ROOM_NAME
                },


            };

        /// <summary>
        /// КВГ_(Ключ.) - Пожарный отсек
        /// </summary>
        public KeyScheduleRule FireCompartment { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Пожарный отсек",
                KeyRevitParamName = nameof(ProjectParamsConfig.FireCompartmentName),

                RequiredSharedParams = new List<string>(),
                RequiredProjectParams = new List<string>() { },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() { }
            };

        /// <summary>
        /// КВГ_(Ключ.) - Секция
        /// </summary>
        public KeyScheduleRule RoomsSections { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Секция",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomSectionName),

                RequiredSharedParams = new List<string>(),
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.RoomSectionShortName)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomSectionShortName),
                }
            };

        /// <summary>
        /// КВГ_(Ключ.) - Тип группы
        /// </summary>
        public KeyScheduleRule RoomsTypeGroup { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Тип группы",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomTypeGroupName),

                RequiredSharedParams = new List<string>(),
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.RoomTypeGroupShortName),
                    nameof(ProjectParamsConfig.ApartmentAreaSpec),
                    nameof(ProjectParamsConfig.ApartmentAreaMinSpec),
                    nameof(ProjectParamsConfig.ApartmentAreaMaxSpec)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomTypeGroupShortName),
                }
            };
#else
    /// <summary>
    ///     КВГ_(Ключ.) - Группа помещений
    /// </summary>
    public KeyScheduleRule RoomsGroups { get; internal set; }
        = new() {
            ScheduleName = "КВГ_(Ключ.) - Группа помещений",
            KeyRevitParamName = nameof(ProjectParamsConfig.RoomGroupName),
            RequiredSharedParams =
                [nameof(SharedParamsConfig.ApartmentGroupName), nameof(SharedParamsConfig.RoomGroupShortName)],
            RequiredProjectParams = [],
            FilledSharedParamNames = [],
            FilledProjectParamNames = []
        };

    /// <summary>
    ///     КВГ_(Ключ.) - Наименование пом.
    /// </summary>
    public KeyScheduleRule RoomsNames { get; internal set; }
        = new() {
            ScheduleName = "КВГ_(Ключ.) - Наименование пом.",
            KeyRevitParamName = nameof(ProjectParamsConfig.RoomName),
            RequiredSharedParams = [nameof(SharedParamsConfig.RoomAreaRatio)],
            RequiredProjectParams =
                [nameof(ProjectParamsConfig.IsRoomBalcony), nameof(ProjectParamsConfig.IsRoomLiving)],
            RequiredSystemParams = [ParameterTypeId.RoomName, ParameterTypeId.RoomDepartment],
            FilledSharedParamNames = [nameof(SharedParamsConfig.RoomAreaRatio)],
            FilledProjectParamNames = [],
            FilledSystemParams = [ParameterTypeId.RoomName]
        };

    /// <summary>
    ///     КВГ_(Ключ.) - Пожарный отсек
    /// </summary>
    public KeyScheduleRule FireCompartment { get; internal set; }
        = new() {
            ScheduleName = "КВГ_(Ключ.) - Пожарный отсек",
            KeyRevitParamName = nameof(ProjectParamsConfig.FireCompartmentName),
            RequiredSharedParams = [nameof(SharedParamsConfig.FireCompartmentShortName)],
            RequiredProjectParams = [],
            FilledSharedParamNames = [],
            FilledProjectParamNames = []
        };

    /// <summary>
    ///     КВГ_(Ключ.) - Секция
    /// </summary>
    public KeyScheduleRule RoomsSections { get; internal set; }
        = new() {
            ScheduleName = "КВГ_(Ключ.) - Секция",
            KeyRevitParamName = nameof(ProjectParamsConfig.RoomSectionName),
            RequiredSharedParams =
                [nameof(SharedParamsConfig.RoomSectionShortName), nameof(SharedParamsConfig.RoomBuildingShortName)],
            RequiredProjectParams = [],
            FilledSharedParamNames = [],
            FilledProjectParamNames = []
        };

    /// <summary>
    ///     КВГ_(Ключ.) - Тип группы
    /// </summary>
    public KeyScheduleRule RoomsTypeGroup { get; internal set; }
        = new() {
            ScheduleName = "КВГ_(Ключ.) - Тип группы",
            KeyRevitParamName = nameof(ProjectParamsConfig.RoomTypeGroupName),
            RequiredSharedParams = [
                nameof(SharedParamsConfig.RoomTypeGroupShortName),
                nameof(SharedParamsConfig.ApartmentAreaSpec),
                nameof(SharedParamsConfig.ApartmentAreaMinSpec),
                nameof(SharedParamsConfig.ApartmentAreaMaxSpec)
            ],
            RequiredProjectParams = [],
            FilledSharedParamNames = [nameof(SharedParamsConfig.RoomTypeGroupShortName)],
            FilledProjectParamNames = []
        };
#endif

    #endregion

#if REVIT2022_OR_GREATER
    /// <summary>
    ///     КВГ_(Ключ.) - Тип группы
    /// </summary>
    public KeyScheduleRule RoomsFinishing { get; internal set; }
        = new() {
            ScheduleName = "ОТД_(Ключ.) - Отделка помещений",
            KeyRevitParamName = nameof(ProjectParamsConfig.RoomFinishingType),
            RequiredSharedParams = [
                nameof(SharedParamsConfig.FloorFinishingType1),
                nameof(SharedParamsConfig.FloorFinishingType2),
                nameof(SharedParamsConfig.FloorFinishingType3),
                nameof(SharedParamsConfig.FloorFinishingType4),
                nameof(SharedParamsConfig.FloorFinishingType5),
                nameof(SharedParamsConfig.CeilingFinishingType1),
                nameof(SharedParamsConfig.CeilingFinishingType2),
                nameof(SharedParamsConfig.CeilingFinishingType3),
                nameof(SharedParamsConfig.CeilingFinishingType4),
                nameof(SharedParamsConfig.CeilingFinishingType5),
                nameof(SharedParamsConfig.WallFinishingType1),
                nameof(SharedParamsConfig.WallFinishingType2),
                nameof(SharedParamsConfig.WallFinishingType3),
                nameof(SharedParamsConfig.WallFinishingType4),
                nameof(SharedParamsConfig.WallFinishingType5),
                nameof(SharedParamsConfig.WallFinishingType6),
                nameof(SharedParamsConfig.WallFinishingType7),
                nameof(SharedParamsConfig.WallFinishingType8),
                nameof(SharedParamsConfig.WallFinishingType9),
                nameof(SharedParamsConfig.WallFinishingType10),
                nameof(SharedParamsConfig.BaseboardFinishingType1),
                nameof(SharedParamsConfig.BaseboardFinishingType2),
                nameof(SharedParamsConfig.BaseboardFinishingType3),
                nameof(SharedParamsConfig.BaseboardFinishingType4),
                nameof(SharedParamsConfig.BaseboardFinishingType5)
            ],
            RequiredProjectParams = [],
            FilledSharedParamNames = [],
            FilledProjectParamNames = []
        };
#endif

    /// <summary>
    ///     Загрузка текущей конфигурации.
    /// </summary>
    /// <param name="configPath">Путь до конфигурации.</param>
    /// <remarks>Возвращает конфигурацию по умолчанию если был найден переданный файл.</remarks>
    public static void LoadInstance(string configPath) {
        Instance = Load(configPath);
    }

    /// <summary>
    ///     Загрузка текущей конфигурации.
    /// </summary>
    /// <param name="configPath">Путь до конфигурации.</param>
    /// <remarks>Возвращает конфигурацию по умолчанию если был найден переданный файл.</remarks>
    public static KeySchedulesConfig Load(string configPath) {
        return File.Exists(configPath)
            ? JsonConvert.DeserializeObject<KeySchedulesConfig>(File.ReadAllText(configPath))
            : GetDefaultConfg();
    }

    /// <summary>
    ///     Возвращает конфигурацию по умолчанию.
    /// </summary>
    /// <returns>Возвращает конфигурацию по умолчанию.</returns>
    public static KeySchedulesConfig GetDefaultConfg() {
        return new KeySchedulesConfig();
    }
}