using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Класс окружения модуля Bim4Everyone
    /// </summary>
    public class ModuleEnvironment {
        /// <summary>
        /// Статический конструктор
        /// </summary>
        static ModuleEnvironment() {
            CurrentLibraryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            TemplatesPath = Path.Combine(CurrentLibraryPath, "templates");
            EmptyTemplatePath = Path.Combine(TemplatesPath, "empty_project.rte");
            ParametersTemplatePath = Path.Combine(TemplatesPath, "project_parameters.rvt");
        }

#if D2020 || R2020
        /// <summary>
        /// Текущая версия Revit.
        /// </summary>
        public static string RevitVersion { get; set; } = "2020";
#elif D2021 || R2021
        /// <summary>
        /// Текущая версия Revit.
        /// </summary>
        public static string RevitVersion { get; set; } = "2021";
#elif D2022 || R2022
        /// <summary>
        /// Текущая версия Revit.
        /// </summary>
        public static string RevitVersion { get; set; } = "2022";
#endif

        /// <summary>
        /// Путь до текущей библиотеки
        /// </summary>
        public static string CurrentLibraryPath { get; }

        #region Templates

        /// <summary>
        /// Путь до папки с шаблонами
        /// </summary>
        public static string TemplatesPath { get; }

        /// <summary>
        /// Путь до пустого шаблона документа
        /// </summary>
        public static string EmptyTemplatePath { get; }

        /// <summary>
        /// Путь до шаблона параметров
        /// </summary>
        public static string ParametersTemplatePath { get; }

        #endregion
    }
}
