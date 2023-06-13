using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using pyRevitLabs.Json;

using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices.Sinks {
    internal class Bim4EveryoneSink : ILogEventSink {
        private readonly string _logUrl;
        private readonly IFormatProvider _formatProvider;

        public Bim4EveryoneSink(string logUrl, IFormatProvider formatProvider) {
            _logUrl = logUrl;
            _formatProvider = formatProvider;
        }

        public async void Emit(LogEvent logEvent) {
            try {
                using(var client = new HttpClient()) {
                    string jsonValue = JsonConvert.SerializeObject(CreateLogEventRecord(logEvent));
                    await client.PostAsync(_logUrl, new StringContent(jsonValue, Encoding.UTF8, "application/json"));
                }
            } catch(Exception ex) {
                SelfLog.WriteLine("Bim4EveryoneSink catch exception{0}{1}", Environment.NewLine, ex);
            }
        }

        private LogEventRecord CreateLogEventRecord(LogEvent logEvent) {
            return new LogEventRecord() {
                Timestamp = logEvent.Timestamp.UtcDateTime,
                Level = logEvent.Level.ToString(),
                MessageTemplate = logEvent.MessageTemplate.Text,
                RenderedMessage = logEvent.RenderMessage(_formatProvider),
                Exception = logEvent.Exception.ToObject(),
                
                SessionId = FormatProperty<Guid>(logEvent, "SessionId"),
                PluginName = FormatProperty<string>(logEvent, "PluginName"),
                PluginSessionId = FormatProperty<Guid>(logEvent, "PluginSessionId"),
                EnvironmentUserName = FormatProperty<string>(logEvent, "EnvironmentUserName"),
                EnvironmentMachineName = FormatProperty<string>(logEvent, "EnvironmentMachineName"),
                
                RevitBuild = FormatProperty<string>(logEvent, "RevitBuild"),
                RevitVersion = FormatProperty<int>(logEvent, "RevitVersion"),
                RevitLanguage = FormatProperty<string>(logEvent, "RevitLanguage"),
                RevitUserName = FormatProperty<string>(logEvent, "RevitUserName"),
                RevitDocumentTitle = FormatProperty<string>(logEvent, "RevitDocumentTitle"),
                RevitDocumentPathName = FormatProperty<string>(logEvent, "RevitDocumentPathName"),
                RevitDocumentModelPath = FormatProperty<string>(logEvent, "RevitDocumentModelPath"),
                
                LogEvent = logEvent.Properties.ToDictionary(
                    item => item.Key,
                    item => item.Value.ToObject()),
            };
        }

        private T FormatProperty<T>(LogEvent logEvent, string propertyName) {
            if(logEvent.Properties.TryGetValue(propertyName, out LogEventPropertyValue value)) {
                logEvent.RemovePropertyIfPresent(propertyName);
                return (T) ((ScalarValue) value).Value;
            }

            return default;
        }
    }
}