using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

using Autodesk.Revit.UI;

using dosymep.Bim4Everyone.SimpleServices.Serialization;
using dosymep.Bim4Everyone.SimpleServices.ServicesModules;
using dosymep.SimpleServices;

using Ninject;
using Ninject.Extensions.ChildKernel;

using Application = Autodesk.Revit.ApplicationServices.Application;

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
            Instance.Load(
                new RevitServicesModule(uiApplication),
                new SettingsServicesModule(),
                new XtraServicesModule(),
                new SerilogServicesModule());

            Instance.UseJsonSerialization();
            Instance.UseConfigSerialization();

            GetPlatformService<ILocalizationService>()
                .SetLocalization(GetPlatformService<ILanguageService>().HostLanguage);
        }

        /// <summary>
        /// Возвращает сервис из контейнера.
        /// </summary>
        /// <typeparam name="T">Запрашиваемый сервис.</typeparam>
        /// <returns>Возвращает сервис из контейнера.</returns>
        public static T GetPlatformService<T>() {
            return Instance.Get<T>();
        }
        
        /// <summary>
        /// Добавляет сервисы платформы в контейнер.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает новый контейнер с сервисами платформы.</returns>
        public static IKernel CreatePlatformServices(this UIApplication application) {
            return new ChildKernel(Instance);
        }
        
        /// <summary>
        /// Добавляет сервисы платформы в контейнер.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает новый контейнер с сервисами платформы.</returns>
        public static IKernel CreatePlatformServices(this Application application) {
            return new ChildKernel(Instance);
        }
    }
}