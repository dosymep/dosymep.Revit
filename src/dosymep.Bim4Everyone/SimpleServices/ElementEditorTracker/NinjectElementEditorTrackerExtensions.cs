using dosymep.Bim4Everyone.SimpleServices;

using Ninject;

namespace dosymep.Bim4Everyone.SimpleServices.ElementEditorTracker;

/// <summary>
///     Расширения для регистрации фабрики трекеров доступности элементов.
/// </summary>
public static class NinjectElementEditorTrackerExtensions {
    /// <summary>
    ///     Добавляет фабрику трекеров доступности элементов в контейнер зависимостей.
    /// </summary>
    /// <param name="kernel">Контейнер зависимостей.</param>
    /// <returns>Настроенный контейнер зависимостей.</returns>
    /// <exception cref="System.ArgumentNullException">Контейнер не задан.</exception>
    public static IKernel UseElementEditorTracker(this IKernel kernel) {
        if(kernel == null) {
            throw new ArgumentNullException(nameof(kernel));
        }

        kernel.Bind<IElementEditorTrackerFactory>()
            .To<ElementEditorTrackerFactory>()
            .InSingletonScope();

        return kernel;
    }
}
