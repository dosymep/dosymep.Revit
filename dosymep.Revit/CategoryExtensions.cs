using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Класс расширений категории.
    /// </summary>
    public static class CategoryExtensions {
        /// <summary>
        /// Проверяет <see cref="BuiltInCategory"/> ли является она идентификатором категории.
        /// </summary>
        /// <param name="self">Категория.</param>
        /// <param name="builtInCategory">Встроенная категория.</param>
        /// <returns>Возвращает true - если <see cref="BuiltInCategory"/> является идентификатором категории, иначе false.</returns>
        public static bool IsId(this Category self, BuiltInCategory builtInCategory) {
            return self == null ? false : self.Id.IntegerValue == (int) builtInCategory;
        }
    }
}