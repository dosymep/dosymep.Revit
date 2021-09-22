using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Bim4Everyone;
using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Revit;

namespace dosymep.Bim4Everyone.Templates {
    /// <summary>
    /// Класс по копирование параметров проекта.
    /// </summary>
    public class ProjectParameters {
        /// <summary>
        /// Создает экземпляр класса параметров проекта.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает экземпляр класса параметров проекта.</returns>
        public static ProjectParameters Create(Application application) {
            if(application is null) {
                throw new ArgumentNullException(nameof(application));
            }

            return new ProjectParameters() { Application = application };
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        internal ProjectParameters() { }

        /// <summary>
        /// Приложение Revit.
        /// </summary>
        public Application Application { get; private set; }

        #region RevitParam
        
        /// <summary>
        /// Настройка параметра.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить параметр.</param>
        /// <param name="revitParam">Параметр, который требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке параметра.</remarks>
        private void SetupRevitParam(Document target, RevitParam revitParam) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start("Настройка параметра");

                    ViewSchedule viewSchedule = GetViewSchedule(source, revitParam);
                    CopyViewSchedule(source, target, viewSchedule);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        /// <summary>
        /// Настройка параметров.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить параметры.</param>
        /// <param name="revitParams">Параметры, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке параметров.</remarks>
        private void SetupRevitParams(Document target, IEnumerable<RevitParam> revitParams) {
            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start("Настройка параметров");

                    IEnumerable<ViewSchedule> viewSchedules = GetViewSchedules(source, revitParams);
                    CopyViewSchedules(source, target, viewSchedules);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        #endregion

        #region ProjectParam

        /// <summary>
        /// Настройка параметра проекта.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить параметр проекта.</param>
        /// <param name="revitParam">Параметр проекта, который требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке параметра проекта.</remarks>
        public void SetupRevitParam(Document target, ProjectParam revitParam) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            if(target.IsExistsParam(revitParam)) {
                return;
            }

            SetupRevitParam(target, (RevitParam) revitParam);
        }

        /// <summary>
        /// Настройка параметров проекта.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить параметры проекта.</param>
        /// <param name="revitParams">Параметры проекта, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке параметров проекта.</remarks>
        public void SetupRevitParams(Document target, params ProjectParam[] revitParams) {
            SetupRevitParams(target, revitParams.AsEnumerable());
        }

        /// <summary>
        /// Настройка параметров проекта.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить параметры проекта.</param>
        /// <param name="revitParams">Параметры проекта, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке параметров проекта.</remarks>
        public void SetupRevitParams(Document target, IEnumerable<ProjectParam> revitParams) {
            if(revitParams.All(item => target.IsExistsParam(item))) {
                return;
            }

            SetupRevitParams(target, revitParams.Cast<RevitParam>());
        }

        #endregion

        #region SharedParam

        /// <summary>
        /// Настройка общий параметр.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить общий параметр.</param>
        /// <param name="revitParam">Общий параметр, который требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке общего параметра.</remarks>
        public void SetupRevitParam(Document target, SharedParam revitParam) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            if(target.IsExistsParam(revitParam)) {
                return;
            }

            SetupRevitParam(target, (RevitParam) revitParam);
        }

        /// <summary>
        /// Настройка общих параметров.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить общие параметры.</param>
        /// <param name="revitParams">Общие параметры, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке общих параметров.</remarks>
        public void SetupRevitParams(Document target, params SharedParam[] revitParams) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParams is null) {
                throw new ArgumentNullException(nameof(revitParams));
            }

            SetupRevitParams(target, revitParams.AsEnumerable());
        }

        /// <summary>
        /// Настройка общих параметров.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить общие параметры.</param>
        /// <param name="revitParams">Общие параметры, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке общих параметров.</remarks>
        public void SetupRevitParams(Document target, IEnumerable<SharedParam> revitParams) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParams is null) {
                throw new ArgumentNullException(nameof(revitParams));
            }

            if(revitParams.All(item => target.IsExistsParam(item))) {
                return;
            }

            SetupRevitParams(target, revitParams.Cast<RevitParam>());
        }

        #endregion

        #region Obsolete

        /// <summary>
        /// Настраивает атрибуты нумерации листов.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить атрибуты нумерации листов.</param>
        /// <remarks>Метод открывает транзакцию при настройке атрибутов нумерации листов.</remarks>
        public void SetupNumerateSheets(Document target) {
            
        }


        /// <summary>
        /// Настраивает атрибуты нумерации видов на листе.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить атрибуты нумерации видов на листах.</param>
        /// <remarks>Метод открывает транзакцию при настройки нумерации видов на листе.</remarks>
        public void SetupNumerateViewsOnSheet(Document target) {
            
        }

        /// <summary>
        /// Настраивает диспетчер видов.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить диспетчер видов.</param>
        /// <remarks>Метод открывает транзакцию при настройке диспетчера видов.</remarks>
        public void SetupBrowserOrganization(Document target) {
            if(Application == null) {
                throw new InvalidOperationException($"Перед настройкой диспетчера видов нужно инициализировать свойство \"{nameof(Application)}\".");
            }

            if(target.IsExistsParam(ProjectParamsConfig.Instance.ViewGroup)
                && target.IsExistsParam(ProjectParamsConfig.Instance.ProjectStage)) {
                
                return;
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start($"Настройка диспетчера видов");

                    CopyBrowserOrganization(target, source);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        #endregion

        #region ViewSchedules

        private static ViewSchedule GetViewSchedule(Document document, RevitParam revitParam) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(ViewSchedule))
                .OfType<ViewSchedule>()
                .FirstOrDefault(item => IsViewScheduleParam(item, revitParam));
        }

        private static IEnumerable<ViewSchedule> GetViewSchedules(Document document, IEnumerable<RevitParam> revitParams) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(ViewSchedule))
                .OfType<ViewSchedule>()
                .Where(item => revitParams.Any(param => IsViewScheduleParam(item, param)));
        }

        private static bool IsViewScheduleParam(ViewSchedule viewSchedule, RevitParam revitParam) {
            return viewSchedule.Name.Equals(revitParam.Name);
        }

        private static void CopyViewSchedule(Document source, Document target, ViewSchedule viewSchedule) {
            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(source, new[] { viewSchedule.Id }, target, Transform.Identity, new CopyPasteOptions());

            // Удаляем скопированный вид,
            // так как он нужен был для переноса параметра
            target.Delete(copiedElements);
        }


        private static void CopyViewSchedules(Document source, Document target, IEnumerable<ViewSchedule> viewSchedules) {
            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(source, viewSchedules.Select(item => item.Id).ToArray(), target, Transform.Identity, new CopyPasteOptions());

            // Удаляем скопированные виды,
            // так как они нужны были для переноса параметра
            target.Delete(copiedElements);
        }

        #endregion

        private static void CopyBrowserOrganization(Document target, Document document) {
            var elements = new FilteredElementCollector(document).OfClass(typeof(BrowserOrganization)).ToElements();

            // Получаем только те элементы,
            // у которых совпадает имя с копируемыми настройками диспетчера видов
            var removingElements = new FilteredElementCollector(target)
                .OfClass(typeof(BrowserOrganization))
                .Where(targetItem => elements.Any(item => item.Name.Equals(targetItem.Name)))
                .Select(item => item.Id)
                .ToArray();

            // Сначала копируем, после удаляем,
            // потому что невозможно удалить все настройки диспетчера видов
            ElementTransformUtils.CopyElements(document, elements.Select(item => item.Id).ToArray(), target, Transform.Identity, new CopyPasteOptions());

            // Удаляем все найденные настройки организации браузера
            // чтобы произвести замену этих элементов
            target.Delete(removingElements);
        }
    }
}
