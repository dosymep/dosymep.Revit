using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Класс расширений категории.
    /// </summary>
    public static class CategoryExtensions {
        /// <summary>
        /// Проверяет <see cref="BuiltInCategory"/> является ли она идентификатором категории.
        /// </summary>
        /// <param name="category">Категория.</param>
        /// <param name="builtInCategory">Встроенная категория.</param>
        /// <returns>Возвращает true - если <see cref="BuiltInCategory"/> является идентификатором категории, иначе false.</returns>
        public static bool IsId(this Category category, BuiltInCategory builtInCategory) {
            return category == null ? false : (BuiltInCategory) category.Id.GetIdValue() == builtInCategory;
        }

        /// <summary>
        /// Возвращает <see cref="BuiltInCategory"/> для категории.
        /// </summary>
        /// <param name="category">Категория.</param>
        /// <returns>Возвращает <see cref="BuiltInCategory"/> для категории, для не системных категорий возвращает <see cref="Autodesk.Revit.DB.BuiltInCategory.INVALID"/>.</returns>
        public static BuiltInCategory GetBuiltInCategory(this Category category) {
            if (category.Id.IsSystemId()) {
                return (BuiltInCategory) category.Id.GetIdValue();
            }

            return BuiltInCategory.INVALID;
        }
    }
}