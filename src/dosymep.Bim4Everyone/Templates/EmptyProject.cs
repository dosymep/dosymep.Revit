using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.Templates {
    /// <summary>
    /// Класс шаблона пустого проекта.
    /// </summary>
    public class EmptyProject {
        /// <summary>
        /// Создает экземпляр класса пустого проекта.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает экземпляр класса пустого проекта.</returns>
        public static EmptyProject Create(Application application) {
            if(application is null) {
                throw new ArgumentNullException(nameof(application));
            }

            return new EmptyProject() { Application = application };
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        internal EmptyProject() { }

        /// <summary>
        /// Приложение Revit.
        /// </summary>
        public Application Application { get; private set; }

        /// <summary>
        /// Создает пустой проект.
        /// </summary>
        /// <param name="documentPath">Место сохранения пустого проекта.</param>
        /// <returns>Возвращает сохраненный документ.</returns>
        public Document CreateEmptyProject(string documentPath) {
            if(string.IsNullOrEmpty(documentPath)) {
                throw new ArgumentException($"'{nameof(documentPath)}' cannot be null or empty.", nameof(documentPath));
            }

            if(Application == null) {
                throw new InvalidOperationException($"Перед созданием проекта нужно инициализировать свойство \"{nameof(Application)}\".");
            }

            return CreateEmptyProject(documentPath, new SaveAsOptions() { OverwriteExistingFile = true });
        }

        /// <summary>
        /// Создает пустой проект.
        /// </summary>
        /// <param name="documentPath">Место сохранения пустого проекта.</param>
        /// <param name="saveAsOptions">Настройки сохранения пустого проекта.</param>
        /// <returns>Возвращает сохраненный документ.</returns>
        public Document CreateEmptyProject(string documentPath, SaveAsOptions saveAsOptions) {
            if(string.IsNullOrEmpty(documentPath)) {
                throw new ArgumentException($"'{nameof(documentPath)}' cannot be null or empty.", nameof(documentPath));
            }

            if(saveAsOptions is null) {
                throw new ArgumentNullException(nameof(saveAsOptions));
            }

            if(Application == null) {
                throw new InvalidOperationException($"Перед созданием проекта нужно инициализировать свойство \"{nameof(Application)}\".");
            }

            var document = Application.NewProjectDocument(ModuleEnvironment.EmptyTemplatePath);
            try {
                document.SaveAs(documentPath, saveAsOptions);
                return Application.OpenDocumentFile(documentPath);
            } finally {
                document.Close(false);
            }
        }
    }
}
