using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;

using Autodesk.Revit.UI;

using dosymep.Bim4Everyone.SimpleServices.ServicesModules;

using Ninject;

using dosymep.SimpleServices;
using dosymep.SimpleServices.PlatformProfiles;
using dosymep.SimpleServices.PlatformProfiles.ProfileStorages;
using dosymep.Xpf.Core.SimpleServices;

using Ninject.Activation;
using Ninject.Modules;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Serialization;

using Serilog;
using Serilog.Events;

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
                new ProfileServicesModule(),
                new SerilogServicesModule(),
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