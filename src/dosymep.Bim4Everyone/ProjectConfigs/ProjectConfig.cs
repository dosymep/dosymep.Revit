using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.ProjectConfigs {
    /// <summary>
    /// Абстрактный класс конфигурации проектов.
    /// </summary>
    public abstract class ProjectConfig {
        /// <summary>
        /// Путь до конфигурации проекта
        /// </summary>
        public abstract string ProjectConfigPath { get; set; }

        /// <summary>
        /// Сериализатор.
        /// </summary>
        public abstract IConfigSerializer Serializer { get; set; }

        /// <summary>
        /// Сохраняет текущую конфигурацию проекта.
        /// </summary>
        public virtual void SaveProjectConfig() {
            Directory.CreateDirectory(Path.GetDirectoryName(ProjectConfigPath));
            File.WriteAllText(ProjectConfigPath, Serializer.Serialize(this));
        }
    }

    /// <summary>
    /// Абстрактный класс конфигурации проектов.
    /// </summary>
    public abstract class ProjectConfig<TProjectSettings> : ProjectConfig
        where TProjectSettings : ProjectSettings, new() {

        /// <summary>
        /// Максимальное количество настроек проекта.
        /// </summary>
        public int MaxSettingsCount { get; set; } = 100;

        /// <summary>
        /// Список настроек проекта
        /// </summary>
        public List<TProjectSettings> Settings { get; set; } = new List<TProjectSettings>();

        /// <summary>
        /// Добавить настройки проекта.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает настройки проекта.</returns>
        public TProjectSettings AddSettings(Document document) {            
            return AddSettings(document.Title);
        }

        /// <summary>
        /// Добавить настройки проекта по наименованию документа.
        /// </summary>
        /// <param name="documentName">Наименование документа.</param>
        /// <returns>Возвращает настройки проекта.</returns>
        public TProjectSettings AddSettings(string documentName) {
            if(Settings.Count > MaxSettingsCount) {
                foreach(int index in Enumerable.Range(0, Settings.Count - MaxSettingsCount)) {
                    Settings.RemoveAt(index);
                }
            }

            var projectSettings =
                new TProjectSettings() { ProjectName = GetProjectName(documentName) };
            Settings.Add(projectSettings);

            return projectSettings;
        }

        /// <summary>
        /// Возвращает настройки проекта по документу.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает настройки проекта по документу. Если настройки проекта не были найдены, возвращает null.</returns>
        public TProjectSettings GetSettings(Document document) {
            return GetSettings(document.Title);
        }

        /// <summary>
        /// Возвращает настройки проекта по наименованию документа.
        /// </summary>
        /// <param name="documentName">Наименование документа.</param>
        /// <returns>Возвращает настройки проекта по наименованию документа. Если настройки проекта не были найдены, возвращает null.</returns>
        public TProjectSettings GetSettings(string documentName) {
            documentName = GetProjectName(documentName);
            return Settings.FirstOrDefault(item => documentName.Equals(item.ProjectName));
        }

        /// <summary>
        /// Возвращает наименование проекта по наименованию документа.
        /// </summary>
        /// <param name="documentName">Наименование документа.</param>
        /// <returns>Возвращает наименование проекта по наименованию документа.</returns>
        private static string GetProjectName(string documentName) {
            documentName = string.IsNullOrEmpty(documentName)
                ? "Без имени"
                : documentName.Split('_').FirstOrDefault();

            return documentName;
        }
    }
}
