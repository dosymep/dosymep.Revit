using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

using dosymep.Bim4Everyone.SimpleServices.ServicesModules;

using Ninject;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Класс предоставляющий доступ к внутренним сервисам платформы
    /// </summary>
    public static class ServicesProvider {
        /// <summary>
        /// Наименование биндингов плагина
        /// </summary>
        public static string PluginBindingName => "PluginBinding";

        /// <summary>
        /// Контейнер сервисов платформы.
        /// </summary>
        public static IKernel Instance { get; private set; }

        /// <summary>
        /// Загружает сервисы платформы.
        /// </summary>
        public static void LoadInstance(UIApplication uiApplication) {
            Instance?.Dispose();
            Instance = new StandardKernel();
            Instance.Load(new XtraServicesModule(),
                new SerilogServicesModule(),
                new ConfigurationServicesModule(),
                new JsonSerializationServicesModule(),
                new RevitServicesModule(uiApplication));
        }

        /// <summary>
        /// Возвращает сервис из контейнера.
        /// </summary>
        /// <typeparam name="T">Запрашиваемый сервис.</typeparam>
        /// <returns>Возвращает сервис из контейнера.</returns>
        public static T GetPlatformService<T>() {
            return Instance.Get<T>();
        }
    }
}