using System.Reflection;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Интерфейс по предоставлению выполняемого плагина.
    /// </summary>
    public interface IPluginInfoService {
        /// <summary>
        /// Сборка выполняемого плагина.
        /// </summary>
        Assembly PluginAssembly { get; set; }
    }
}