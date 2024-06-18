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

        /// <summary>
        /// Проверяет <see cref="BuiltInParameter"/> является ли он идентификатором системного параметра.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <param name="builtInParameter">Системный параметр.</param>
        /// <returns>Возвращает true - если <see cref="BuiltInParameter"/> является идентификатором системного параметра, иначе false</returns>
        public static bool IsId(this ParameterElement parameterElement, BuiltInParameter builtInParameter) {
            if(parameterElement == null) {
                throw new ArgumentNullException(nameof(parameterElement));
            }

            return (BuiltInParameter) parameterElement.Id.GetIdValue() == builtInParameter;
        }

        /// <summary>
        /// Возвращает <see cref="BuiltInParameter"/> для определения параметра.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра".</param>
        /// <returns>Возвращает <see cref="BuiltInParameter"/> для определения параметра, для не системных параметров возвращает <see cref="BuiltInParameter.INVALID"/>.</returns>
        public static BuiltInParameter GetBuiltInParameter(this ParameterElement parameterElement) {
            if(parameterElement.Id.IsSystemId()) {
                return (BuiltInParameter) parameterElement.Id.GetIdValue();
            }

            return BuiltInParameter.INVALID;
        }

#if REVIT2020

        /// <summary>
        /// Возвращает единицу измерения параметра.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает единицу измерения параметра.</returns>
        public static UnitType GetUnitType(this ParameterElement parameterElement) {
            if(parameterElement == null) {
                throw new ArgumentNullException(nameof(parameterElement));
            }

            return parameterElement.GetDefinition().UnitType;
        }

#elif REVIT2021

        /// <summary>
        /// Возвращает единицу измерения параметра.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает единицу измерения параметра.</returns>
        public static ForgeTypeId GetUnitType(this ParameterElement parameterElement) {
            if(parameterElement == null) {
                throw new ArgumentNullException(nameof(parameterElement));
            }

            return parameterElement.GetDefinition().GetSpecTypeId();
        }

#else
        
        /// <summary>
        /// Возвращает единицу измерения параметра.
        /// </summary>
        /// <param name="parameterElement">Элемент параметра.</param>
        /// <returns>Возвращает единицу измерения параметра.</returns>
        public static ForgeTypeId GetUnitType(this ParameterElement parameterElement) {
            if(parameterElement == null) {
                throw new ArgumentNullException(nameof(parameterElement));
            }

            return parameterElement.GetDefinition().GetDataType();
        }

#endif

    }
}