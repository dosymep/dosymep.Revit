using dosymep.Bim4Everyone.SimpleServices.Sinks;

using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace dosymep.Bim4Everyone.SimpleServices;

internal static class Bim4EveryoneSinkExtensions {
    public static LoggerConfiguration Bim4Everyone(this LoggerSinkConfiguration loggerSinkConfiguration,
        string logUrl, LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
        IFormatProvider formatProvider = null) {
        return loggerSinkConfiguration.Sink(new Bim4EveryoneSink(logUrl, formatProvider), restrictedToMinimumLevel);
    }

    public static object ToObject(this Exception exception) {
        if(exception is null) {
            return null;
        }

        return new Dictionary<string, object> {
            {"type", exception.GetType().ToString()},
            {"source", exception.Source},
            {"message", exception.Message},
            {"stack_trace", exception.StackTrace},
            {"inner_exception", exception.InnerException.ToObject()}
        };
    }

    public static object ToObject(this LogEventPropertyValue propertyValue) {
        switch(propertyValue) {
            case ScalarValue scalarValue:
                return scalarValue.Value;
            case SequenceValue sequenceValue:
                return sequenceValue.Elements
                    .Select(item => item.ToObject())
                    .ToArray();
            case DictionaryValue dictionaryValue:
                return dictionaryValue.Elements
                    .ToDictionary(
                        item => item.Key.ToObject(),
                        item => item.Value.ToObject());
            case StructureValue structureValue:
                return structureValue.Properties.ToDictionary(
                    item => item.Name,
                    item => item.Value.ToObject());
            default:
                return null;
        }
    }
}