using DevExpress.Mvvm.UI;

namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    /// <summary>
    /// Настройка уведомлений.
    /// </summary>
    public sealed class NotificationSettings {
        private readonly IniConfigurationService _configurationService;

        internal NotificationSettings(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }

        /// <summary>
        /// Признак активности уведомлений.
        /// </summary>
        public bool? IsActive {
            get => _configurationService.ReadBool("notification", "active", true);
            set => _configurationService.Write("notification", "active", value.ToString());
        }

        /// <summary>
        /// Экран уведомлений.
        /// </summary>
        public NotificationScreen? NotificationScreen {
            get => _configurationService.ReadEnum<NotificationScreen>("notification", "screen", DevExpress.Mvvm.UI.NotificationScreen.Primary);
            set => _configurationService.Write("notification", "screen", value.ToString());
        }

        /// <summary>
        /// Позиция уведомлений.
        /// </summary>
        public NotificationPosition? NotificationPosition {
            get => _configurationService.ReadEnum<NotificationPosition>("notification", "position", DevExpress.Mvvm.UI.NotificationPosition.BottomRight);
            set => _configurationService.Write("notification", "position", value.ToString());
        }

        /// <summary>
        /// Максимальное количество уведомлений на экране.
        /// </summary>
        public int? NotificationVisibleMaxCount {
            get => _configurationService.ReadInt("notification", "max_visible", 5);
            set => _configurationService.Write("notification", "max_visible", value.ToString());
        }
    }
}