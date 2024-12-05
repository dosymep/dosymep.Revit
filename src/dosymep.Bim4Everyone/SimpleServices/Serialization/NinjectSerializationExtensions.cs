using System;
using System.Collections.Generic;

using dosymep.Bim4Everyone.ProjectConfigs;
using dosymep.Bim4Everyone.SimpleServices.Serialization.JsonConverters;
using dosymep.SimpleServices;

using Ninject;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Converters;
using pyRevitLabs.Json.Serialization;

namespace dosymep.Bim4Everyone.SimpleServices.Serialization {
    /// <summary>
    /// Расширения для сериализаторов <see cref="IKernel"/>.
    /// </summary>
    public static class NinjectSerializationExtensions {
        /// <summary>
        /// Добавляет в контейнер сервис сериализации <see cref="ISerializationService" />
        /// </summary>
        /// <param name="kernel">Ninject контейнер.</param>
        /// <param name="setupAction">Настройки сериализатора.</param>
        /// <returns>Возвращает настроенный контейнер Ninject.</returns>
        /// <exception cref="System.ArgumentNullException">kernel is null.</exception>
        public static IKernel UseJsonSerialization(this IKernel kernel,
            Action<JsonSerializerSettings> setupAction = default) {
            if(kernel == null) {
                throw new ArgumentNullException(nameof(kernel));
            }

            JsonSerializerSettings options = GetDefaultSettings();
            setupAction?.Invoke(options);
            
            kernel.Bind<ISerializationService>()
                .To<JsonSerializationService>()
                .WithConstructorArgument("settings", options);

            return kernel;
        }

        /// <summary>
        /// Добавляет в контейнер сервис сериализации <see cref="IConfigSerializer" />
        /// </summary>
        /// <param name="kernel">Ninject контейнер.</param>
        /// <param name="setupAction">Настройки сериализатора.</param>
        /// <returns>Возвращает настроенный контейнер Ninject.</returns>
        /// <exception cref="System.ArgumentNullException">kernel is null.</exception>
        public static IKernel UseConfigSerialization(this IKernel kernel,
            Action<JsonSerializerSettings> setupAction = default) {
            if(kernel == null) {
                throw new ArgumentNullException(nameof(kernel));
            }
            
            JsonSerializerSettings options = GetDefaultSettings();
            setupAction?.Invoke(options);

            kernel.Bind<IConfigSerializer>()
                .To<JsonSerializationService>()
                .WithConstructorArgument("settings", options);

            return kernel;
        }

        private static JsonSerializerSettings GetDefaultSettings() {
            List<JsonConverter> converters = new List<JsonConverter>() {
                new ElementIdConverter(),
                new RevitParamConverter(),
                new StringEnumConverter(new DefaultNamingStrategy())
            };

#if REVIT2021_OR_GREATER
            converters.Add(new ForgeTypeIdConverter());
#endif
            return new JsonSerializerSettings() {
                Converters = converters, Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.None
            };
        }
    }
}