namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    /// <summary>
    /// Настройки социальных сетей.
    /// </summary>
    public sealed class SocialsSettings {
        private readonly IniConfigurationService _configurationService;

        internal SocialsSettings(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }
        
        /// <summary>
        /// Канал новостей.
        /// </summary>
        public string NewsChatUrl => _configurationService.Read("socials", "tg_news");
        
        /// <summary>
        /// Основной чат платформы.
        /// </summary>
        public string MainChatUrl => _configurationService.Read("socials", "tg_main");
        
        /// <summary>
        /// Ссылка на описание платформы.
        /// </summary>
        public string PlatformPageUrl => _configurationService.Read("socials", "page_link");
        
        /// <summary>
        /// Ссылка на скачивание платформы.
        /// </summary>
        public string DownloadLinkUrl => _configurationService.Read("socials", "downloads_link");
    }
}