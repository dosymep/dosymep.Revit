using Autodesk.Revit.DB;

using dosymep.Bim4Everyone.ProjectParams;
using dosymep.Bim4Everyone.SharedParams;
using dosymep.Bim4Everyone.SystemParams;

namespace dosymep.Bim4Everyone.KeySchedules;

/// <summary>
///     Настройки проверки ключевых спецификаций.
/// </summary>
public class KeyScheduleRule : RevitScheduleRule {
    /// <summary>
    ///     Создает экземпляр настроек проверки ключевых спецификаций.
    /// </summary>
    internal KeyScheduleRule() { }

    /// <summary>
    ///     Ключевой параметр спецификации.
    /// </summary>
    public string KeyRevitParamName { get; set; }

    /// <summary>
    ///     Общие параметры, которые должны быть обязательно заполнены в спецификации.
    /// </summary>
    public List<string> FilledSharedParamNames { get; set; } = [];

    /// <summary>
    ///     Параметры проекта, которые должны быть обязательно заполнены в спецификации.
    /// </summary>
    public List<string> FilledProjectParamNames { get; set; } = [];

    /// <summary>
    ///     Обязательные общие параметры в спецификации.
    /// </summary>
    public List<string> RequiredSharedParams { get; set; } = [];

    /// <summary>
    ///     Обязательные параметры проекта в спецификации.
    /// </summary>
    public List<string> RequiredProjectParams { get; set; } = [];

#if REVIT2020 || REVIT2021
        /// <summary>
        /// Обязательные системные параметры проекта в спецификации.
        /// </summary>
        public List<BuiltInParameter> RequiredSystemParams { get; set; } = new List<BuiltInParameter>();

        /// <summary>
        /// Системные параметры проекта, которые должны быть обязательно заполнены в спецификации.
        /// </summary>
        public List<BuiltInParameter> FilledSystemParams { get; set; } = new List<BuiltInParameter>();

#else

    /// <summary>
    ///     Обязательные системные параметры проекта в спецификации.
    /// </summary>
    public List<ForgeTypeId> RequiredSystemParams { get; set; } = [];

    /// <summary>
    ///     Системные параметры проекта, которые должны быть обязательно заполнены в спецификации.
    /// </summary>
    public List<ForgeTypeId> FilledSystemParams { get; set; } = [];

#endif

    /// <summary>
    ///     Создает объект класса проверок для спецификации.
    /// </summary>
    /// <param name="viewSchedule">Проверяемая спецификация.</param>
    /// <returns>Возвращает объект проверок спецификации</returns>
    public KeyScheduleTesting CreateKeyScheduleTesting(ViewSchedule viewSchedule) {
        if(viewSchedule is null) {
            throw new ArgumentNullException(nameof(viewSchedule));
        }

        if(!ScheduleName.Equals(viewSchedule.Name)) {
            throw new ArgumentException($"Переданная спецификация имеет другое наименование \"{viewSchedule.Name}\".",
                nameof(viewSchedule));
        }

        return new KeyScheduleTesting(viewSchedule, GetKeyScheduleRuleInternal(viewSchedule));
    }

    /// <summary>
    ///     Возвращает внутренние настройки проверки ключевых спецификаций.
    /// </summary>
    /// <returns>Возвращает внутренние настройки проверки ключевых спецификаций.</returns>
    private KeyScheduleRuleInternal GetKeyScheduleRuleInternal(ViewSchedule viewSchedule) {
        Dictionary<string, RevitParam> propertySharedParams = SharedParamsConfig.Instance
            .GetRevitParams()
            .Select(item => item.AsRevitParam())
            .ToDictionary(item => item.Id);

        Dictionary<string, RevitParam> propertyProjectParams = ProjectParamsConfig.Instance
            .GetRevitParams()
            .Select(item => item.AsRevitParam())
            .ToDictionary(item => item.Id);

        RevitParam keyRevitParam = propertyProjectParams[KeyRevitParamName];

        IEnumerable<RevitParam> filledSharedParams = FilledSharedParamNames.Select(item => propertySharedParams[item]);
        IEnumerable<RevitParam> filledProjectParams =
            FilledProjectParamNames.Select(item => propertyProjectParams[item]);
        IEnumerable<SystemParam> filledSystemParams = FilledSystemParams.Select(item =>
            SystemParamsConfig.Instance.CreateRevitParam(viewSchedule.Document, item));

        IEnumerable<RevitParam> requiredSharedParams = RequiredSharedParams.Select(item => propertySharedParams[item]);
        IEnumerable<RevitParam> requiredProjectParams =
            RequiredProjectParams.Select(item => propertyProjectParams[item]);
        IEnumerable<SystemParam> requiredSystemParams = RequiredSystemParams.Select(item =>
            SystemParamsConfig.Instance.CreateRevitParam(viewSchedule.Document, item));

        return new KeyScheduleRuleInternal {
            KeyScheduleRule = this,
            KeyRevitParam = keyRevitParam,
            FilledParams =
                [..filledSharedParams.Union(filledProjectParams).Union(filledSystemParams)],
            RequiredParams =
                [..requiredSharedParams.Union(requiredProjectParams).Union(requiredSystemParams)]
        };
    }
}