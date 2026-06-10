namespace dosymep.Bim4Everyone;

/// <summary>
///     Настройки спецификаций.
/// </summary>
public abstract class RevitScheduleRule {
    /// <summary>
    ///     Наименование спецификации.
    /// </summary>
    public virtual string ScheduleName { get; set; }
}