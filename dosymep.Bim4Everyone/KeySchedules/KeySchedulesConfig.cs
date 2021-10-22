using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Класс конфигурации ключевых спецификаций.
    /// </summary>
    public class KeySchedulesConfig {
        /// <summary>
        /// Текущее состояние конфигурации.
        /// </summary>
        /// <remarks>Перед использованием нужно вызвать <see cref="Load(string)"/></remarks>
        public static KeySchedulesConfig Instance { get; internal set; }

        #region Квартирография

        /// <summary>
        /// КВГ_(Ключ.) - Группа помещений
        /// </summary>
        public KeyScheduleRule RoomsGroups { get; internal set; } 
            = new KeyScheduleRule() {
                ScheduleName = "КВГ_(Ключ.) - Группа помещений",
                KeyRevitParamName = nameof(ProjectParamsConfig.RoomGroupName),

                RequiredSharedParams = new List<string>(),
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.RoomGroupName),
                    nameof(ProjectParamsConfig.ApartmentGroupName),
                    nameof(ProjectParamsConfig.RoomGroupShortName),
                    nameof(ProjectParamsConfig.RoomTypeCountGroup)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomGroupName),
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

                RequiredSystemParams = new List<BuiltInParameter>() { 
                    BuiltInParameter.ROOM_NAME, 
                    BuiltInParameter.ROOM_DEPARTMENT
                },

                RequiredSharedParams = new List<string>() { },
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.RoomName),
                    nameof(ProjectParamsConfig.RoomAreaRatio), 
                    nameof(ProjectParamsConfig.IsRoomBalcony), 
                    nameof(ProjectParamsConfig.IsRoomLiving)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomName)
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
                RequiredProjectParams = new List<string>() {
                    nameof(ProjectParamsConfig.FireCompartmentName),
                    nameof(ProjectParamsConfig.FireCompartmentShortName) 
                },

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
                    nameof(ProjectParamsConfig.RoomSectionName),
                    nameof(ProjectParamsConfig.RoomSectionShortName),
                    nameof(ProjectParamsConfig.ApartmentTypeNumsInSection)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomSectionName),
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
                    nameof(ProjectParamsConfig.RoomTypeGroupName),
                    nameof(ProjectParamsConfig.RoomTypeGroupShortName),
                    nameof(ProjectParamsConfig.ApartmentAreaSpec),
                    nameof(ProjectParamsConfig.ApartmentAreaMinSpec),
                    nameof(ProjectParamsConfig.ApartmentAreaMaxSpec)
                },

                FilledSharedParamNames = new List<string>() { },
                FilledProjectParamNames = new List<string>() {
                    nameof(ProjectParamsConfig.RoomTypeGroupName),
                    nameof(ProjectParamsConfig.RoomTypeGroupShortName),
                }
            };

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
