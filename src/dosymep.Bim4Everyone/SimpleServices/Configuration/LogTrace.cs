﻿using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    /// <summary>
    /// Настройки трассировки.
    /// </summary>
    public class LogTrace {
        private readonly IniConfigurationService _configurationService;

        internal LogTrace(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }

        /// <summary>
        /// Признак активности.
        /// </summary>
        public bool? IsActive => _configurationService.ReadBool("log_trace", "active", true);

        /// <summary>
        /// Уровень логгирования.
        /// </summary>
        public LogEventLevel? LogLevel => _configurationService.ReadEnum<LogEventLevel>(
            "log_trace",
            "level",
            LogEventLevel.Information);

        /// <summary>
        /// Наименование сервера телеметрии.
        /// </summary>
        public string ServerName => _configurationService.Read("log_trace", "server_name");
        
        /// <summary>
        /// Включает логгирование времени открытия файла.
        /// </summary>
        public bool? EnableOpenDocTime => _configurationService.ReadBool("log_trace", "enable_open_doc_time", true);
        
        /// <summary>
        /// Включает логгирование времени синхронизации файла.
        /// </summary>
        public bool? EnableSyncDocTime => _configurationService.ReadBool("log_trace", "enable_sync_doc_time", true);
    }
}