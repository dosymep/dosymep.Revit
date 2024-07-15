using dosymep.Bim4Everyone.SimpleServices.Configuration;

namespace dosymep.Bim4Everyone.SimpleServices
{
    /// <summary>
    /// Настройки платформы.
    /// </summary>
    public interface IPlatformConfigurationService {
        LogTrace LogTrace { get; }
        LogTraceJournal LogTraceJournal { get; }

        CorpSettings CorpSettings { get; }
        SocialsSettings SocialsSettings { get; }

        NotificationSettings NotificationSettings { get; }
    }
}