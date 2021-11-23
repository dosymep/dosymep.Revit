using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Класс конфигурации ключевых спецификаций.
    /// </summary>
    public class KeySchedulesConfig : RevitSchedulesConfig {
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static KeySchedulesConfig Instance { get; internal set; }

        #region Квартирография

#if D2020 || R2020 || D2021 || R2021

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
                    nameof(ProjectParamsConfig.IsRoomLiving)
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
        /// КВГ_(Ключ.) - Группа помещений
        /// </summary>
        public KeyScheduleRule RoomsGroups { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Группа помещений",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomGroupName),

                RequiredSharedParams = new List<string>() {
                    nameof(SharedParamsConfig.ApartmentGroupName),
                    nameof(SharedParamsConfig.RoomGroupShortName)
                },
                RequiredProjectParams = new List<string>(),
                FilledSharedParamNames = new List<string>() {
                    nameof(SharedParamsConfig.RoomGroupShortName)
                },
                FilledProjectParamNames = new List<string>() { }
            };

        /// <summary>
        /// КВГ_(Ключ.) - Наименование пом.
        /// </summary>
        public KeyScheduleRule RoomsNames { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Наименование пом.",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomName),

                RequiredSharedParams = new List<string>() {
                    nameof(SharedParamsConfig.RoomAreaRatio),
                },
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.IsRoomBalcony),
                    nameof(ProjectParamsConfig.IsRoomLiving)
                },
                RequiredSystemParams = new List<ForgeTypeId>() {
                    ParameterTypeId.RoomName,
                    ParameterTypeId.RoomDepartment
                },

                FilledSharedParamNames = new List<string>() {
                 nameof(SharedParamsConfig.RoomAreaRatio),
                },
                FilledProjectParamNames = new List<string>() { },
                FilledSystemParams = new List<ForgeTypeId>() {
                    ParameterTypeId.RoomName
                },
            };

        /// <summary>
        /// КВГ_(Ключ.) - Пожарный отсек
        /// </summary>
        public KeyScheduleRule FireCompartment { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Пожарный отсек",
                KeyRevitParamName = nameof(ProjectParamsConfig.FireCompartmentName),

                RequiredSharedParams = new List<string>() {
                    nameof(SharedParamsConfig.FireCompartmentShortName)
                },
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

                RequiredSharedParams = new List<string>() {
                    nameof(SharedParamsConfig.RoomSectionShortName)
                },

                RequiredProjectParams = new List<string>(),
                FilledSharedParamNames = new List<string>() {
                    nameof(SharedParamsConfig.RoomSectionShortName),
                },
                FilledProjectParamNames = new List<string>() { }
            };

        /// <summary>
        /// КВГ_(Ключ.) - Тип группы
        /// </summary>
        public KeyScheduleRule RoomsTypeGroup { get; internal set; }
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Тип группы",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomTypeGroupName),

                RequiredSharedParams = new List<string>() {
                    nameof(SharedParamsConfig.RoomTypeGroupShortName),
                    nameof(SharedParamsConfig.ApartmentAreaSpec),
                    nameof(SharedParamsConfig.ApartmentAreaMinSpec),
                    nameof(SharedParamsConfig.ApartmentAreaMaxSpec)
                },
                RequiredProjectParams = new List<string>() { },

                FilledSharedParamNames = new List<string>() {
                    nameof(SharedParamsConfig.RoomTypeGroupShortName)
                },
                FilledProjectParamNames = new List<string>() { }
            };
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
        public static KeySchedulesConfig Load(string configPath) {
            return File.Exists(configPath) ? JsonConvert.DeserializeObject<KeySchedulesConfig>(File.ReadAllText(configPath)) : GetDefaultConfg();
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static KeySchedulesConfig GetDefaultConfg() {
            return new KeySchedulesConfig();
        }
    }
}
