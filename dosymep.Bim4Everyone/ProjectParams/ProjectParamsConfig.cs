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
            return File.Exists(configPath) ? JsonConvert.DeserializeObject<ProjectParamsConfig>(File.ReadAllText(configPath)) : GetDefaultConfg();
        }

        /// <summary>
        /// Возвращает конфигурацию по умолчанию.
        /// </summary>
        /// <returns>Возвращает конфигурацию по умолчанию.</returns>
        public static ProjectParamsConfig GetDefaultConfg() {
            return new ProjectParamsConfig();
        }
    }
}
