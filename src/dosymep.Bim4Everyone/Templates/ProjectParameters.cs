using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Bim4Everyone;
using dosymep.Bim4Everyone.KeySchedules;
using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SimpleServices;
using dosymep.Revit;
using dosymep.SimpleServices;

using Application = Autodesk.Revit.ApplicationServices.Application;

namespace dosymep.Bim4Everyone.Templates {
    /// <summary>
    /// Класс по копирование параметров проекта.
    /// </summary>
    public class ProjectParameters {
        private const string ParamTransferScheduleNamePrefix = "BIM4E_PARAM_TRANSFER_";

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
                using(var transaction = target.StartTransaction("Настройка параметров")) {
                    RevitParamsSync(source, target, revitParams);
                    RevitParamsCopy(source, target, revitParams);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }
        

        private void RevitParamsCopy(
            Document source,
            Document target,
            IEnumerable<RevitParam> revitParams)
        {
            (ICollection<RevitParam> regularCopyParams, ICollection<RevitParam> paramsWithoutBinding)
                = SplitRevitParamsByBinding(target, revitParams);
            
            ParameterElement[] regularCopyParamsElements = GetRevitParamElements(source, regularCopyParams);
            ParameterElement[] paramsWithoutBindingElements = GetRevitParamElements(source, paramsWithoutBinding);
            
            if(regularCopyParamsElements.Length > 0) {
                ElementTransformUtils.CopyElements(
                    source,
                    regularCopyParamsElements.Select(item => item.Id).ToArray(),
                    target,
                    Transform.Identity,
                    new CopyPasteOptions());
            }
            
            if(paramsWithoutBindingElements.Length > 0) {
                CopyParamsByMultiCategorySchedule(
                    source,
                    target,
                    paramsWithoutBindingElements);
            }
        }

        /// <summary>
        /// Возвращает элементы параметров из документа.
        /// </summary>
        /// <param name="source">Документ с параметрами.</param>
        /// <param name="revitParams">Параметры.</param>
        /// <returns>Возвращает элементы параметров.</returns>
        private ParameterElement[] GetRevitParamElements(Document source, IEnumerable<RevitParam> revitParams) {
            return revitParams
                .Select(item => item.GetRevitParamElement(source))
                .Where(item => item != null)
                .ToArray();
        }

        /// <summary>
        /// Разделяет параметры на параметры для обычного копирования и общие параметры без привязки к категориям.
        /// </summary>
        /// <param name="target">Целевой документ.</param>
        /// <param name="revitParams">Параметры, которые нужно разделить.</param>
        /// <returns>Возвращает параметры для обычного копирования и параметры без привязки.</returns>
        private (
            ICollection<RevitParam> RegularCopyParams,
            ICollection<RevitParam> ParamsWithoutBinding) SplitRevitParamsByBinding(
                Document target,
                IEnumerable<RevitParam> revitParams) {
            var regularCopyParams = new List<RevitParam>();
            var paramsWithoutBinding = new List<RevitParam>();

            foreach(RevitParam revitParam in revitParams) {
                if(!(revitParam is SharedParam)) {
                    regularCopyParams.Add(revitParam);
                    continue;
                }

                if(!HasRevitElementParam(target, revitParam)) {
                    regularCopyParams.Add(revitParam);
                    continue;
                }

                (Definition Definition, Binding Binding) paramBinding = revitParam.GetParamBinding(target);
                if(paramBinding.Definition == null || paramBinding.Binding == null) {
                    paramsWithoutBinding.Add(revitParam);
                }
            }

            return (regularCopyParams, paramsWithoutBinding);
        }

        /// <summary>
        /// Проверяет, существует ли элемент параметра в документе.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="revitParam">Параметр Revit.</param>
        /// <returns>Возвращает true, если элемент параметра существует, иначе false.</returns>
        private bool HasRevitElementParam(Document document, RevitParam revitParam) {
            if(!(revitParam is SharedParam sharedParam)) {
                return false;
            }

            return new FilteredElementCollector(document)
                .OfClass(typeof(SharedParameterElement))
                .OfType<SharedParameterElement>()
                .Any(item => item.GuidValue.Equals(sharedParam.Guid));
        }

        /// <summary>
        /// Копирует параметры через временную мультикатегорийную спецификацию.
        /// </summary>
        /// <param name="source">Файл шаблона.</param>
        /// <param name="target">Целевой документ.</param>
        /// <param name="paramsElements">Параметры из шаблона.</param>
        private void CopyParamsByMultiCategorySchedule(
            Document source,
            Document target,
            IEnumerable<ParameterElement> paramsElements) {
            ViewSchedule viewSchedule = null;

            using(var transaction = source.StartTransaction("Создание временной спецификации параметров")) {
                viewSchedule = ViewSchedule.CreateSchedule(source, ElementId.InvalidElementId);
                viewSchedule.Name = $"{ParamTransferScheduleNamePrefix}{Guid.NewGuid():N}";

                foreach(ParameterElement param in paramsElements) {
                    SchedulableField schedulableField = viewSchedule.Definition
                        .GetSchedulableFields()
                        .FirstOrDefault(item => item.ParameterId == param.Id);
                    if(schedulableField == null) {
                        throw new InvalidOperationException(
                            $"Не удалось добавить параметр '{param.Name}' во временную спецификацию.");
                    }

                    viewSchedule.Definition.AddField(schedulableField);
                }

                transaction.Commit();
            }

            CopyViewSchedule(source, target, true, viewSchedule);
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
    }
}
