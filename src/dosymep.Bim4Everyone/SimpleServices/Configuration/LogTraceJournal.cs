using Serilog;
using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    internal class LogTraceJournal {
        private readonly IniConfigurationService _configurationService;

        public LogTraceJournal(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }

        public bool IsActive => _configurationService.ReadBool("log_trace.journal", "active");
        public LogEventLevel LogLevel => _configurationService.ReadEnum<LogEventLevel>("log_trace", "level");

        public bool UseUtc => _configurationService.ReadBool("log_trace.journal", "utc");

        public string OutputTemplate => _configurationService.Read("log_trace.journal", "output_template")
                                ?? AutodeskRevitSinkLoggerConfigurationExtensions.DefaultOutputTemplate;
    }
}