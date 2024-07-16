using dosymep.Bim4Everyone.SimpleServices.Configuration;

namespace dosymep.Bim4Everyone.SimpleServices
{
    /// <summary>
    /// Настройки платформы.
    /// </summary>
    public interface IPlatformSettingsService {
        /// <summary>
        /// Настройки трассировки.
        /// </summary>
        LogTrace LogTrace { get; }
        
        /// <summary>
        /// Настройки журналирования.
        /// </summary>
        LogTraceJournal LogTraceJournal { get; }

        /// <summary>
        /// Корпоративные настройки.
        /// </summary>
        CorpSettings CorpSettings { get; }
        
        /// <summary>
        /// Настройки социальных сетей.
        /// </summary>
        SocialsSettings SocialsSettings { get; }

        /// <summary>
        /// Настройки увеломлений.
        /// </summary>
        NotificationSettings NotificationSettings { get; }
    }
}