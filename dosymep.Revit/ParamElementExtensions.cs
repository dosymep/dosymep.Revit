using System;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Класс расширений элементов параметров
    /// </summary>
    public static class ParamElementExtensions {
        /// <summary>
        /// Проверяет, является ли параметр параметром проекта.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает true - если параметр является параметром проекта, иначе false.</returns>
        public static bool IsProjectParam(this ParameterElement parameterElement) {
            return !(parameterElement.IsSharedParam() || parameterElement.IsGlobalParam());
        }
        
        /// <summary>
        /// Проверяет, является ли параметр общим параметром.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает true - если параметр является общим параметром, иначе false.</returns>
        public static bool IsSharedParam(this ParameterElement parameterElement) {
            return parameterElement is SharedParameterElement;
        }
        
        /// <summary>
        /// Проверяет, является ли параметр глобальным параметром.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает true - если параметр является глобальным параметром, иначе false.</returns>
        public static bool IsGlobalParam(this ParameterElement parameterElement) {
            return parameterElement is GlobalParameter;
        }

        /// <summary>
        /// Возвращает тип параметра.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает тип параметра.</returns>
        public static StorageType GetStorageType(this ParameterElement parameterElement) {
            if(parameterElement == null) {
                throw new ArgumentNullException(nameof(parameterElement));
            }

            return parameterElement.GetDefinition().GetStorageType();
        }
    }
}