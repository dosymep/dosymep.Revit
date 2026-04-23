using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using dosymep.Bim4Everyone;
using dosymep.Bim4Everyone.KeySchedules;
using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SimpleServices;
using dosymep.Revit;
using dosymep.SimpleServices;

namespace dosymep.Bim4Everyone.Templates {
    /// <summary>
    /// Класс по копирование параметров проекта.
    /// </summary>
    public class ProjectParameters {
        private const string ParameterTransferScheduleNamePrefix = "BIM4E_PARAM_TRANSFER_";

        private readonly ILoggerService _loggerService;

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
        internal ProjectParameters() {
            _loggerService = ServicesProvider.GetPlatformService<ILoggerService>();
        }

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
            
            SetupRevitParams(target, new[] {revitParam});
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

            RevitParamsCopy(target, revitParams);
        }

        #endregion

        #region Schedules

        /// <summary>
        /// Настройка спецификации.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить спецификацию.</param>
        /// <param name="replaceSchedule">true - если требуется заменить спецификацию, иначе false.</param>
        /// <param name="revitScheduleRule">Правило спецификации.</param>
        public bool SetupSchedule(Document target, bool replaceSchedule, RevitScheduleRule revitScheduleRule) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitScheduleRule == null) {
                throw new ArgumentNullException(nameof(revitScheduleRule));
            }

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.BIMStart("Настройка спецификации");

                    if(replaceSchedule) {
                        ViewSchedule removedViewSchedule = GetViewSchedule(target, revitScheduleRule.ScheduleName);
                        RemoveViewSchedule(target, removedViewSchedule);
                    }

                    ViewSchedule viewSchedule = GetViewSchedule(source, revitScheduleRule.ScheduleName);
                    bool result = CopyViewSchedule(source, target, false, viewSchedule);

                    transaction.Commit();

                    return result;
                }
            } finally {
                source.Close(false);
            }
        }

        /// <summary>
        /// Настройка спецификации.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить спецификацию.</param>
        /// <param name="replaceSchedule">true - если требуется заменить спецификацию, иначе false.</param>
        /// <param name="revitScheduleRule">Правила спецификации.</param>
        public bool SetupSchedules(Document target, bool replaceSchedule, params RevitScheduleRule[] revitScheduleRule) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitScheduleRule is null) {
                throw new ArgumentNullException(nameof(revitScheduleRule));
            }

            return SetupSchedules(target, replaceSchedule, revitScheduleRule.AsEnumerable());
        }

        /// <summary>
        /// Настройка спецификаций.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить спецификацию.</param>
        /// <param name="replaceSchedule">true - если требуется заменить спецификацию, иначе false.</param>
        /// <param name="revitScheduleRule">Правила спецификации.</param>
        public bool SetupSchedules(Document target, bool replaceSchedule, IEnumerable<RevitScheduleRule> revitScheduleRule) {
            if(target is null) {
                throw new ArgumentNullException(nameof(target));
            }

            if(revitScheduleRule is null) {
                throw new ArgumentNullException(nameof(revitScheduleRule));
            }


            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.BIMStart("Настройка спецификаций");

                    if(replaceSchedule) {
                        IEnumerable<ViewSchedule> removedViewSchedules = GetViewSchedules(target, revitScheduleRule.Select(item => item.ScheduleName));
                        RemoveViewSchedules(target, removedViewSchedules);
                    }

                    IEnumerable<ViewSchedule> viewSchedules = GetViewSchedules(source, revitScheduleRule.Select(item => item.ScheduleName));
                    bool result = CopyViewSchedules(source, target, false, viewSchedules);

                    transaction.Commit();

                    return result;
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
                    transaction.BIMStart($"Настройка диспетчера видов");

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

        private static bool CopyViewSchedule(Document source, Document target, bool removeSchedule, ViewSchedule viewSchedule) {
            if(viewSchedule == null) {
                return false;
            }

            var targetViewSchedules = new FilteredElementCollector(target)
                .WhereElementIsNotElementType()
                .OfClass(typeof(ViewSchedule))
                .Select(item => item.Name)
                .Distinct()
                .ToList();

            // Пропускаем спецификацию, если она есть
            if(targetViewSchedules.Any(item => viewSchedule.Name.Equals(item))) {
                return false;
            }

            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(
                source,
                new[] { viewSchedule.Id },
                target,
                Transform.Identity,
                CreateCopyPasteOptions());
            if(removeSchedule) {
                // Удаляем скопированный вид,
                // так как он нужен был для переноса параметра
                target.Delete(copiedElements);
            }

            return true;
        }

        private static bool CopyViewSchedules(Document source, Document target, bool removeSchedule, IEnumerable<ViewSchedule> viewSchedules) {
            if(!viewSchedules.Any()) {
                return false;
            }

            // Пропускаем спецификации, если они есть
            var targetViewSchedules = new FilteredElementCollector(target)
                .WhereElementIsNotElementType()
                .OfClass(typeof(ViewSchedule))
                .Select(item => item.Name)
                .Distinct()
                .ToList();

            viewSchedules = viewSchedules.Where(item => !targetViewSchedules.Contains(item.Name));
            if(!viewSchedules.Any()) {
                return false;
            }

            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(
                source,
                viewSchedules.Select(item => item.Id).ToArray(),
                target,
                Transform.Identity,
                CreateCopyPasteOptions());
            if(removeSchedule) {
                // Удаляем скопированные виды,
                // так как они нужны были для переноса параметра
                target.Delete(copiedElements);
            }

            return true;
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
        
        private void RevitParamsCopy(Document target, IEnumerable<RevitParam> revitParams) {
            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                ICollection<ViewSchedule> transferSchedules = CreateParameterTransferSchedules(source, target, revitParams);

                using(var transaction = target.StartTransaction("Настройка параметров")) {
                    CopyViewSchedules(source, target, true, transferSchedules);
                    RevitParamsSync(source, target, revitParams);
                    RevitParamsCopy(source, target, revitParams);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        /// <summary>
        /// Создает трансферные таблицы для отсутствующих в целевом документе параметров.
        /// </summary>
        /// <param name="source">Шаблон</param>
        /// <param name="target">Целевой документ</param>
        /// <param name="revitParams">Параметры, которые нужно проверить на наличие в целевом документе</param>
        /// <returns></returns>
        private ICollection<ViewSchedule> CreateParameterTransferSchedules(
            Document source,
            Document target,
            IEnumerable<RevitParam> revitParams) {
            RevitParam[] missingParams = revitParams
                .Where(item => !item.IsExistsParam(target))
                .ToArray();

            if(missingParams.Length == 0) {
                return Array.Empty<ViewSchedule>();
            }

            var transferSchedules = new List<ViewSchedule>();
            var transferSchedulesByCategoryId = new Dictionary<long, ViewSchedule>();

            using(var transaction = source.StartTransaction("Создание временных спецификаций параметров")) {
                foreach(RevitParam revitParam in missingParams) {
                    try {
                        ParameterElement parameterElement = revitParam.GetRevitParamElement(source);
                        if(parameterElement == null) {
                            continue;
                        }

                        ViewSchedule viewSchedule = CreateParameterTransferSchedule(
                            source,
                            transferSchedulesByCategoryId,
                            revitParam,
                            parameterElement);
                        
                        if(viewSchedule != null
                           && !transferSchedules.Any(item => item.Id == viewSchedule.Id)) {
                            transferSchedules.Add(viewSchedule);
                        }

                        if(viewSchedule == null) {
                            _loggerService.Warning(
                                "Не удалось создать временную спецификацию переноса для параметра {@revitParam} в шаблоне.",
                                revitParam);
                        }
                    } catch(Exception ex) {
                        _loggerService.Warning(
                            ex,
                            "Не удалось подготовить временную спецификацию переноса для параметра {@revitParam} в шаблоне.",
                            revitParam);
                    }
                }

                transaction.Commit();
            }

            return transferSchedules;
        }

        /// <summary>
        /// Создает временную спецификацию переноса для параметра в шаблоне или использует одну из ранее созданных.
        /// </summary>
        /// <param name="source">Файл шаблона</param>
        /// <param name="transferSchedulesByCategoryId">Словарь ранее созданных спецификаций</param>
        /// <param name="revitParam">Параметр</param>
        /// <param name="parameterElement">Объект параметра из шаблона</param>
        /// <returns></returns>
        private ViewSchedule CreateParameterTransferSchedule(
            Document source,
            IDictionary<long, ViewSchedule> transferSchedulesByCategoryId,
            RevitParam revitParam,
            ParameterElement parameterElement) {
            foreach(Category category in GetRevitParamCategories(source, revitParam)) {
                ViewSchedule viewSchedule = GetOrCreateParameterTransferSchedule(
                    source,
                    transferSchedulesByCategoryId,
                    category);
                if(viewSchedule == null) {
                    continue;
                }

                if(TryAddParameterTransferField(viewSchedule, parameterElement)) {
                    return viewSchedule;
                }
            }

            return null;
        }

        /// <summary>
        /// Создает новую трансферную спецификацию или возвращает ранее созданную для текущей категории.
        /// </summary>
        /// <param name="source">Файл шаблона</param>
        /// <param name="transferSchedulesByCategoryId">Словарь с трансферными спецификацями</param>
        /// <param name="category">Категория</param>
        /// <returns></returns>
        private ViewSchedule GetOrCreateParameterTransferSchedule(
            Document source,
            IDictionary<long, ViewSchedule> transferSchedulesByCategoryId,
            Category category) {
            long categoryId = category.Id.GetIdValue();
            if(transferSchedulesByCategoryId.TryGetValue(categoryId, out ViewSchedule viewSchedule)) {
                return viewSchedule;
            }

            try {
                viewSchedule = ViewSchedule.CreateSchedule(source, category.Id);
                viewSchedule.Name = $"{ParameterTransferScheduleNamePrefix}{Guid.NewGuid():N}";
                transferSchedulesByCategoryId.Add(categoryId, viewSchedule);

                return viewSchedule;
            } catch(Exception ex) {
                transferSchedulesByCategoryId.Add(categoryId, null);
                _loggerService.Warning(
                    ex,
                    "Не удалось создать временную спецификацию переноса для категории {category} в шаблоне.",
                    category.Name);

                return null;
            }
        }

        /// <summary>
        /// Возвращает категории, к которым привязан параметр в файле шаблона.
        /// </summary>
        /// <param name="source">Файл шаблона</param>
        /// <param name="revitParam">Параметр</param>
        /// <returns></returns>
        private static IEnumerable<Category> GetRevitParamCategories(Document source, RevitParam revitParam) {
            (Definition Definition, Binding Binding) paramBinding = revitParam.GetParamBinding(source);
            if(!(paramBinding.Binding is ElementBinding elementBinding)) {
                yield break;
            }

            foreach(Category category in elementBinding.Categories) {
                if(category != null) {
                    yield return category;
                }
            }
        }

        /// <summary>
        /// Пробует добавить в трансферную спецификацию требуемый параметр. Если в ранее созданной таблице уже есть такой параметр, возвращает True и не добавляет.
        /// </summary>
        /// <param name="viewSchedule">Таблица</param>
        /// <param name="parameterElement">Объект параметра из шаблона</param>
        /// <returns></returns>
        private static bool TryAddParameterTransferField(ViewSchedule viewSchedule, ParameterElement parameterElement) {
            if(IsParameterTransferFieldExists(viewSchedule, parameterElement)) {
                return true;
            }

            SchedulableField schedulableField = viewSchedule.Definition
                .GetSchedulableFields()
                .FirstOrDefault(item => item.ParameterId == parameterElement.Id);
            if(schedulableField == null) {
                return false;
            }

            try {
                viewSchedule.Definition.AddField(schedulableField);
                return true;
            } catch(Exception) {
                return false;
            }
        }

        /// <summary>
        /// Для ранее созданной таблицы проверяет существует ли в ней уже требуемый параметр.
        /// </summary>
        /// <param name="viewSchedule">Таблица</param>
        /// <param name="parameterElement">Объект параметра из шаблона</param>
        /// <returns></returns>
        private static bool IsParameterTransferFieldExists(ViewSchedule viewSchedule, ParameterElement parameterElement) {
            ScheduleDefinition definition = viewSchedule.Definition;
            return definition.GetFieldOrder()
                .Select(item => definition.GetField(item))
                .Any(item => item.ParameterId == parameterElement.Id);
        }

        private void RevitParamsCopy(Document source, Document target, IEnumerable<RevitParam> revitParams) {
            ElementId[] sourceParamElementIds = revitParams
                .Where(item => !item.IsExistsParam(target))
                .Select(item => item.GetRevitParamElement(source))
                .Where(item => item != null)
                .Select(item => item.Id)
                .ToArray();

            if(sourceParamElementIds.Length > 0) {
                ElementTransformUtils.CopyElements(source, sourceParamElementIds, target,
                    Transform.Identity,
                    new CopyPasteOptions());
            }
        }

        private void RevitParamsSync(Document source, Document target, IEnumerable<RevitParam> revitParams) {
            foreach(RevitParam revitParam in revitParams) {
                try {
                    if(revitParam.IsExistsParam(target)) {
                        RevitParamBindingsSync(source, target, revitParam);
                    }
                } catch(Exception ex) {
                    _loggerService.Warning(ex, "Не удалось синхронизировать параметр {@revitParam} в документе {@document}", revitParam, target.Title);
                }
            }
        }

        private static void RevitParamBindingsSync(Document source, Document target, RevitParam revitParam) {
            if(source.IsExistsParam(revitParam)) {
                (Definition Definition, Binding Binding) sourceSettings = revitParam.GetParamBinding(source);
                (Definition Definition, Binding Binding) targetSettings = revitParam.GetParamBinding(target);

                var targetCategories = ((ElementBinding) targetSettings.Binding).Categories;
                var sourceCategories = ((ElementBinding) sourceSettings.Binding).Categories;

                foreach(Category sourceCategory in sourceCategories) {
                    if(!targetCategories.Contains(sourceCategory)) {
                        targetCategories.Insert(sourceCategory);
                        target.ParameterBindings.ReInsert(targetSettings.Definition, targetSettings.Binding);
                    }
                }

                // После вызова ReInsert сбрасывается свойство VariesAcrossGroups
                var sourceDefinition = (InternalDefinition) sourceSettings.Definition;
                var targetDefinition = (InternalDefinition) targetSettings.Definition;
                targetDefinition.SetAllowVaryBetweenGroups(target, sourceDefinition.VariesAcrossGroups);
            }
        }

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

        /// <summary>
        /// Создает настройки копирования элементов.
        /// </summary>
        /// <returns>Возвращает настройки копирования элементов.</returns>
        private static CopyPasteOptions CreateCopyPasteOptions() {
            var copyPasteOptions = new CopyPasteOptions();
            copyPasteOptions.SetDuplicateTypeNamesHandler(new UseDestinationDuplicateTypeNamesHandler());

            return copyPasteOptions;
        }

        /// <summary>
        /// Обработчик совпадений имен типов при копировании элементов.
        /// </summary>
        private class UseDestinationDuplicateTypeNamesHandler : IDuplicateTypeNamesHandler {
            /// <summary>
            /// Обрабатывает совпадения имен типов при копировании элементов.
            /// </summary>
            /// <param name="args">Аргументы обработчика совпадений имен типов.</param>
            /// <returns>Возвращает действие для обработки совпадающих типов.</returns>
            public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args) {
                return DuplicateTypeAction.UseDestinationTypes;
            }
        }
    }
}
