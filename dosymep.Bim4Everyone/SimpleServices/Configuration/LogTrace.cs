using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    internal class LogTrace {
        private readonly IniConfigurationService _configurationService;

        public LogTrace(IniConfigurationService configurationService) {
            _configurationService = configurationService;
        }

        public bool IsActive => _configurationService.ReadBool("log_trace", "active");
        public LogEventLevel LogLevel => _configurationService.ReadEnum<LogEventLevel>("log_trace", "level");
        public string ServerName => _configurationService.Read("log_trace", "server_name");
    }
}