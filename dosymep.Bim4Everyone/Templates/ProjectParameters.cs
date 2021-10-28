using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Bim4Everyone;
using dosymep.Bim4Everyone.KeySchedules;
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
        public void SetupRevitParam(Document target, RevitParam revitParam) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParam is null) {
                throw new ArgumentNullException(nameof(revitParam));
            }

            if(revitParam.IsExistsParam(target)) {
                return;
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start("Настройка параметра");

                    ViewSchedule viewSchedule = GetViewSchedule(source, revitParam);
                    CopyViewSchedule(source, target, true, viewSchedule);

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
        public void SetupRevitParams(Document target, params RevitParam[] revitParams) {
            if(revitParams is null) {
                throw new ArgumentNullException(nameof(revitParams));
            }

            SetupRevitParams(target, revitParams.AsEnumerable());
        }

        /// <summary>
        /// Настройка параметров.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить параметры.</param>
        /// <param name="revitParams">Параметры, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке параметров.</remarks>
        public void SetupRevitParams(Document target, IEnumerable<RevitParam> revitParams) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitParams is null) {
                throw new ArgumentNullException(nameof(revitParams));
            }

            // Получаем параметры, которых нет в проекте
            revitParams = revitParams.Where(item => !target.IsExistsParam(item));

            // Если не были найдены параметры, которых нет проекте
            // то выходим
            if(!revitParams.Any()) {
                return;
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start("Настройка параметров");

                    IEnumerable<ViewSchedule> viewSchedules = GetViewSchedules(source, revitParams);
                    CopyViewSchedules(source, target, true, viewSchedules);

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
            SetupRevitParam(target, (RevitParam) revitParam);
        }

        /// <summary>
        /// Настройка общих параметров.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить общие параметры.</param>
        /// <param name="revitParams">Общие параметры, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке общих параметров.</remarks>
        public void SetupRevitParams(Document target, params SharedParam[] revitParams) {
            SetupRevitParams(target, revitParams.AsEnumerable());
        }

        /// <summary>
        /// Настройка общих параметров.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить общие параметры.</param>
        /// <param name="revitParams">Общие параметры, которые требуется настроить.</param>
        /// <remarks>Метод открывает транзакцию при настройке общих параметров.</remarks>
        public void SetupRevitParams(Document target, IEnumerable<SharedParam> revitParams) {
            SetupRevitParams(target, revitParams.Cast<RevitParam>());
        }

        #endregion

        #region KeySchedules

        /// <summary>
        /// Настройка ключевой спецификации.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить ключевую спецификацию.</param>
        /// <param name="replaceSchedule">true - если требуется заменить спецификацию, иначе false.</param>
        /// <param name="keyScheduleRule">Правила ключевой спецификации.</param>
        public void SetupKeySchedule(Document target, bool replaceSchedule, KeyScheduleRule keyScheduleRule) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(keyScheduleRule is null) {
                throw new ArgumentNullException(nameof(keyScheduleRule));
            }

            ViewSchedule removedViewSchedule = GetViewSchedule(target, keyScheduleRule);
            if(!replaceSchedule && removedViewSchedule != null) {
                return;
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start("Настройка ключевой спецификации");

                    if(replaceSchedule) {                        
                        RemoveViewSchedule(target, removedViewSchedule);
                    }
                    
                    ViewSchedule viewSchedule = GetViewSchedule(source, keyScheduleRule);
                    CopyViewSchedule(source, target, false, viewSchedule);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        /// <summary>
        /// Настройка ключевой спецификации.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить ключевую спецификацию.</param>
        /// <param name="replaceSchedule">true - если требуется заменить спецификацию, иначе false.</param>
        /// <param name="keyScheduleRules">Правила ключевой спецификации.</param>
        public void SetupKeySchedules(Document target, bool replaceSchedule, params KeyScheduleRule[] keyScheduleRules) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(keyScheduleRules is null) {
                throw new ArgumentNullException(nameof(keyScheduleRules));
            }

            SetupKeySchedules(target, replaceSchedule, keyScheduleRules.AsEnumerable());
        }

        /// <summary>
        /// Настройка ключевых спецификаций.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить ключевую спецификацию.</param>
        /// <param name="replaceSchedule">true - если требуется заменить спецификацию, иначе false.</param>
        /// <param name="keyScheduleRules">Правила ключевой спецификации.</param>
        public void SetupKeySchedules(Document target, bool replaceSchedule, IEnumerable<KeyScheduleRule> keyScheduleRules) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(keyScheduleRules is null) {
                throw new ArgumentNullException(nameof(keyScheduleRules));
            }

            IEnumerable<ViewSchedule> removedViewSchedules = GetViewSchedules(target, keyScheduleRules);
            if(!replaceSchedule && removedViewSchedules.Any()) {
                return;
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start("Настройка ключевых спецификаций");
                    
                    if(replaceSchedule) {
                        RemoveViewSchedules(target, removedViewSchedules);
                    }
                    
                    IEnumerable<ViewSchedule> viewSchedules = GetViewSchedules(source, keyScheduleRules);
                    CopyViewSchedules(source, target, false, viewSchedules);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
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
            return GetViewSchedule(document, revitParam.Name);
        }

        private static ViewSchedule GetViewSchedule(Document document, KeyScheduleRule keyScheduleRule) {
            return GetViewSchedule(document, keyScheduleRule.ScheduleName);
        }

        private static ViewSchedule GetViewSchedule(Document document, string viewScheduleName) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(ViewSchedule))
                .OfType<ViewSchedule>()
                .FirstOrDefault(item => IsFindViewSchedule(item, viewScheduleName));
        }

        private static IEnumerable<ViewSchedule> GetViewSchedules(Document document, IEnumerable<RevitParam> revitParams) {
            return GetViewSchedules(document, revitParams.Select(item => item.Name));
        }

        private static IEnumerable<ViewSchedule> GetViewSchedules(Document document, IEnumerable<KeyScheduleRule> keyScheduleRules) {
            return GetViewSchedules(document, keyScheduleRules.Select(item => item.ScheduleName));
        }

        private static IEnumerable<ViewSchedule> GetViewSchedules(Document document, IEnumerable<string> scheduleNames) {
            return new FilteredElementCollector(document)
                .OfClass(typeof(ViewSchedule))
                .OfType<ViewSchedule>()
                .Where(item => scheduleNames.Any(param => IsFindViewSchedule(item, param)));
        }

        private static bool IsFindViewSchedule(ViewSchedule viewSchedule, string viewScheduleName) {
            return viewSchedule.Name.Equals(viewScheduleName);
        }

        private static void CopyViewSchedule(Document source, Document target, bool removeSchedule, ViewSchedule viewSchedule) {
            if(viewSchedule == null) {
                return;
            }

            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(source, new[] { viewSchedule.Id }, target, Transform.Identity, new CopyPasteOptions());
            if(removeSchedule) {
                // Удаляем скопированный вид,
                // так как он нужен был для переноса параметра
                target.Delete(copiedElements);
            }
        }

        private static void CopyViewSchedules(Document source, Document target, bool removeSchedule, IEnumerable<ViewSchedule> viewSchedules) {
            if(!viewSchedules.Any()) {
                return;
            }

            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(source, viewSchedules.Select(item => item.Id).ToArray(), target, Transform.Identity, new CopyPasteOptions());
            if(removeSchedule) {
                // Удаляем скопированные виды,
                // так как они нужны были для переноса параметра
                target.Delete(copiedElements);
            }
        }

        private static void RemoveViewSchedule(Document target, ViewSchedule viewSchedule) {
            if(viewSchedule != null) {
                target.Delete(viewSchedule.Id);
            }
        }

        private static void RemoveViewSchedules(Document target, IEnumerable<ViewSchedule> viewSchedules) {
            target.Delete(viewSchedules.Select(item => item.Id).ToArray());
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
