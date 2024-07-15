namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    /// <summary>
    /// Корпоративные настройки.
    /// </summary>
    public sealed class CorpSettings {
        private readonly IniConfigurationService _configurationService;

        internal CorpSettings(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }
        
        /// <summary>
        /// Название настроек.
        /// </summary>
        public string Name => _configurationService.Read("corp", "name");
        
        /// <summary>
        /// Путь до изобрежения.
        /// </summary>
        public string ImagePath => _configurationService.Read("corp", "image_path");
        
        /// <summary>
        /// Путь до настроек.
        /// </summary>
        public string SettingsPath => _configurationService.Read("corp", "settings_path");
    }
}