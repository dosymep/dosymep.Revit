using dosymep.Bim4Everyone.SimpleServices.Configuration;

namespace dosymep.Bim4Everyone.SimpleServices;

internal sealed class PlatformSettingsService : IPlatformSettingsService {
    private readonly IniConfigurationService _configurationService;

    public PlatformSettingsService(IniConfigurationService configurationService) {
        _configurationService = configurationService;
    }

    public LogTrace LogTrace => new(_configurationService);
    public LogTraceJournal LogTraceJournal => new(_configurationService);

    public CorpSettings CorpSettings => new(_configurationService);
    public SocialsSettings SocialsSettings => new(_configurationService);

    public NotificationSettings NotificationSettings => new(_configurationService);
}