using System.Reflection;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Класс информации о выполняемом плагине.
    /// </summary>
    public class PluginInfoService : IPluginInfoService {
        /// <inheritdoc />
        public Assembly PluginAssembly { get; set; }
    }
}