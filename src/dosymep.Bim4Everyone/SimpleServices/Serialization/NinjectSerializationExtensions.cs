using System;
using System.Collections.Generic;

using dosymep.Bim4Everyone.ProjectConfigs;
using dosymep.SimpleServices;

using Ninject;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization {
    /// <summary>
    /// Расширения для сериализаторов <see cref="IKernel"/>.
    /// </summary>
    public static class NinjectSerializationExtensions {
        /// <summary>
        /// Добавляет в контейнер сервис сериализации <see cref="ISerializationService" />
        /// </summary>
        /// <param name="kernel">Ninject контейнер.</param>
        /// <param name="setting">Настройки сериализатора.</param>
        /// <returns>Возвращает настроенный контейнер Ninject.</returns>
        /// <exception cref="System.ArgumentNullException">kernel is null.</exception>
        public static IKernel UseJsonSerialization(this IKernel kernel,
            Func<JsonSerializerSettings> setting = default) {
            if(kernel == null) {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.Bind<ISerializationService>()
                .To<JsonSerializationService>()
                .WithConstructorArgument("settings", setting?.Invoke() ?? GetDefaultSettings());

            return kernel;
        }

        /// <summary>
        /// Добавляет в контейнер сервис сериализации <see cref="IConfigSerializer" />
        /// </summary>
        /// <param name="kernel">Ninject контейнер.</param>
        /// <param name="setting">Настройки сериализатора.</param>
        /// <returns>Возвращает настроенный контейнер Ninject.</returns>
        /// <exception cref="System.ArgumentNullException">kernel is null.</exception>
        public static IKernel UseConfigSerialization(this IKernel kernel,
            Func<JsonSerializerSettings> setting = default) {
            if(kernel == null) {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.Bind<IConfigSerializer>()
                .To<JsonSerializationService>()
                .WithConstructorArgument("settings", setting?.Invoke() ?? GetDefaultSettings());

            return kernel;
        }

        private static JsonSerializerSettings GetDefaultSettings() {
            var converters = new List<JsonConverter>() {new ElementIdConverter(), new RevitParamConverter()};

#if REVIT2021_OR_GREATER
            converters.Add(new ForgeTypeIdConverter());
#endif
            return new JsonSerializerSettings() {
                Converters = converters, Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.None
            };
        }
    }
}