using System;
using System.IO;

namespace dosymep.Bim4Everyone.ProjectConfigs {
    /// <summary>
    /// Билдер конфигурации проекта.
    /// </summary>
    public class ProjectConfigBuilder {
        /// <summary>
        /// Наименование плагина.
        /// </summary>
        private string _pluginName;

        /// <summary>
        /// Наименование файла конфигурации проекта.
        /// </summary>
        private string _projectConfigName;

        /// <summary>
        /// Интерфейс сериализатора.
        /// </summary>
        private IConfigSerializer _serializer;

        /// <summary>
        /// Версия Revit.
        /// </summary>
        private string _revitVersion;

        /// <summary>
        /// Путь к файлу конфигурации проекта.
        /// </summary>
        private string _projectConfigPath;

        /// <summary>
        /// Устанавливает наименование плагина.
        /// </summary>
        /// <param name="pluginName">Наименование плагина.</param>
        /// <returns>Возвращает текущий билдер.</returns>
        public ProjectConfigBuilder SetPluginName(string pluginName) {
            _pluginName = pluginName;
            return this;
        }

        /// <summary>
        /// Устанавливает наименование файла конфигурации проекта.
        /// </summary>
        /// <param name="projectConfigName">Наименование файла конфигурации проекта.</param>
        /// <returns>Возвращает текущий билдер.</returns>
        public ProjectConfigBuilder SetProjectConfigName(string projectConfigName) {
            _projectConfigName = projectConfigName;
            return this;
        }

        /// <summary>
        /// Устанавливает сериализатор.
        /// </summary>
        /// <param name="serializer">Сериализатор.</param>
        /// <returns>Возвращает текущий билдер.</returns>
        public ProjectConfigBuilder SetSerializer(IConfigSerializer serializer) {
            _serializer = serializer;
            return this;
        }

        /// <summary>
        /// Устанавливает версию Revit.
        /// </summary>
        /// <param name="revitVersion">Версия Revit.</param>
        /// <returns>Возвращает текущий билдер.</returns>
        public ProjectConfigBuilder SetRevitVersion(string revitVersion) {
            _revitVersion = revitVersion;
            return this;
        }

        /// <summary>
        /// Устанавливает путь к файлу конфигурации проекта для его десериализации.
        /// </summary>
        /// <param name="projectConfigPath">Путь к файлу конфигурации проекта.</param>
        /// <returns>Возвращает текущий билдер.</returns>
        public ProjectConfigBuilder SetProjectConfigPath(string projectConfigPath) {
            _projectConfigPath = projectConfigPath;
            return this;
        }

        /// <summary>
        /// Конструирует конфигурацию проекта.
        /// </summary>
        /// <typeparam name="T">Тип конфигурации проекта.</typeparam>
        /// <returns>Возвращает десериализованную конфигурацию проекта, либо если не был найден файл конфигурацию по умолчанию.</returns>
        public T Build<T>()
            where T : ProjectConfig, new() {

            if(_serializer == null) {
                throw new InvalidOperationException("Перед конструированием объекта, требуется установить сериализатор.");
            }

            if(string.IsNullOrEmpty(_pluginName)) {
                throw new InvalidOperationException("Перед конструированием объекта, требуется установить наименование плагина.");
            }

            if(string.IsNullOrEmpty(_projectConfigName)) {
                throw new InvalidOperationException("Перед конструированием объекта, требуется установить наименование файла конфигурации проекта.");
            }

            string projectConfigPath = string.IsNullOrWhiteSpace(_projectConfigPath)
                ? GetConfigPath(_pluginName, _projectConfigName, _revitVersion)
                : _projectConfigPath;
            if(File.Exists(projectConfigPath)) {
                string fileContent = File.ReadAllText(projectConfigPath);

                T projectConfig = _serializer.Deserialize<T>(fileContent);
                projectConfig.Serializer = _serializer;
                projectConfig.ProjectConfigPath = projectConfigPath;

                return projectConfig;
            }

            return new T() { Serializer = _serializer, ProjectConfigPath = projectConfigPath };
        }

        /// <summary>
        /// Возвращает путь до конфигурации проекта.
        /// </summary>
        /// <param name="pluginName">Наименование плагина.</param>
        /// <param name="projectConfigName">Наименование файла конфигурации проекта.</param>
        /// <param name="revitVersion">Версия Revit.</param>
        /// <returns>Возвращает путь до конфигурации проекта.</returns>
        private static string GetConfigPath(string pluginName, string projectConfigName, string revitVersion) {
            return string.IsNullOrEmpty(revitVersion)
                ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "dosymep", pluginName, projectConfigName)
                : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "dosymep", revitVersion, pluginName, projectConfigName);
        }
    }
}
