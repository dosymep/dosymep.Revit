using Serilog;
using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    /// <summary>
    /// Настройки журналирования в ревит.
    /// </summary>
    public class LogTraceJournal {
        private readonly IniConfigurationService _configurationService;

        internal LogTraceJournal(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }

        /// <summary>
        /// Признак активности журналирования.
        /// </summary>
        public bool? IsActive => _configurationService.ReadBool("log_trace.journal", "active", true);

        /// <summary>
        /// Уровень логгирования.
        /// </summary>
        public LogEventLevel? LogLevel => _configurationService.ReadEnum<LogEventLevel>(
            "log_trace.journal", 
            "level",
            LogEventLevel.Information);

        /// <summary>
        /// Использовать время UTC.
        /// </summary>
        public bool? UseUtc => _configurationService.ReadBool("log_trace.journal", "utc", true);

        /// <summary>
        /// Формат вывода событий.
        /// </summary>
        public string OutputTemplate => _configurationService.Read(
            "log_trace.journal", 
            "output_template",
            AutodeskRevitSinkLoggerConfigurationExtensions.DefaultOutputTemplate);
    }
}