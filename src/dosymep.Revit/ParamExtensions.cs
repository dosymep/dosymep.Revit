using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса параметров.
    /// </summary>
    public static partial class ParamExtensions {
        /// <summary>
        /// Возвращает значение параметра.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает значение параметра.</returns>
        public static object AsObject(this Parameter parameter) {
            if(parameter is null) {
                throw new ArgumentNullException(nameof(parameter));
            }

            if(parameter.HasValue) {
                var storageType = parameter.StorageType;
                switch(storageType) {
                    case StorageType.Integer:
                        return parameter.AsInteger();
                    case StorageType.Double:
                        return parameter.AsDouble();
                    case StorageType.String: {
                        var value = parameter.AsString();
                        return string.IsNullOrWhiteSpace(value) ? null : value;
                    }

                    case StorageType.ElementId:
                        return parameter.AsElementId();
                }
            }

            return null;
        }

        /// <summary>
        /// Удаляет значение параметра (устанавливает значение по умолчанию)
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public static void RemoveValue(this Parameter parameter) {
            if(parameter is null) {
                throw new ArgumentNullException(nameof(parameter));
            }

            if(parameter.HasValue) {
                var storageType = parameter.StorageType;
                switch(storageType) {
                    case StorageType.Integer:
                        parameter.Set((int) default);
                        break;
                    case StorageType.Double:
                        parameter.Set((double) default);
                        break;
                    case StorageType.String:
                        parameter.Set((string) default);
                        break;
                    case StorageType.ElementId:
                        parameter.Set((ElementId) default);
                        break;
                }
            }
        }

        /// <summary>
        /// Присваивает значение параметра по значению другого параметра.
        /// </summary>
        /// <param name="leftParameter">Параметр в который присваивается значение.</param>
        /// <param name="rightParameter">Параметр значение которого присваивается.</param>
        public static void Set(this Parameter leftParameter, Parameter rightParameter) {
            if(leftParameter is null) {
                throw new ArgumentNullException(nameof(leftParameter));
            }

            if(rightParameter is null) {
                throw new ArgumentNullException(nameof(rightParameter));
            }

            if(leftParameter.StorageType != StorageType.String &&
               leftParameter.StorageType != rightParameter.StorageType) {
                throw new ArgumentException("У переданного параметра не соответствует тип данных.",
                    nameof(rightParameter));
            }

            var storageType = rightParameter.StorageType;
            switch(storageType) {
                case StorageType.Integer:
                    leftParameter.Set(rightParameter.AsInteger());
                    break;
                case StorageType.Double:
                    leftParameter.Set(rightParameter.AsDouble());
                    break;
                case StorageType.String:
                    leftParameter.Set(rightParameter.AsObject()?.ToString());
                    break;
                case StorageType.ElementId:
                    leftParameter.Set(rightParameter.AsElementId());
                    break;
                default:
                    leftParameter.Set((string) null);
                    break;
            }
        }

        /// <summary>
        /// Проверяет является ли привязка параметра для типа элемента.
        /// </summary>
        /// <param name="binding">Привязка параметра.</param>
        /// <returns>Возвращает true - если привязка параметра является типом элемента.</returns>
        public static bool IsTypeBinding(this Binding binding) {
            return binding is TypeBinding;
        }

        /// <summary>
        /// Проверяет является ли привязка параметра для экземпляром элемента.
        /// </summary>
        /// <param name="binding">Привязка параметра.</param>
        /// <returns>Возвращает true - если привязка параметра является экземпляром элемента.</returns>
        public static bool IsInstanceBinding(this Binding binding) {
            return binding is InstanceBinding;
        }

        /// <summary>
        /// Возвращает нумератор категорий.
        /// </summary>
        /// <param name="binding">Привязка параметра.</param>
        /// <returns>Возвращает нумератор категорий.</returns>
        public static IEnumerable<Category> GetCategories(this Binding binding) {
            return ((ElementBinding) binding).Categories.OfType<Category>();
        }

        /// <summary>
        /// Возвращает идентификатор определения параметра.
        /// </summary>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает идентификатор определения параметра.</returns>
        public static ElementId GetElementId(this Definition definition) {
            if(definition is InternalDefinition internalDefinition) {
                return internalDefinition.Id;
            }

            return ElementId.InvalidElementId;
        }

        /// <summary>
        /// Проверяет <see cref="BuiltInParameter"/> является ли он идентификатором системного параметра.
        /// </summary>
        /// <param name="definition">Определение параметра.</param>
        /// <param name="builtInParameter">Системный параметр.</param>
        /// <returns>Возвращает true - если <see cref="BuiltInParameter"/> является идентификатором системного параметра, иначе false</returns>
        public static bool IsId(this Definition definition, BuiltInParameter builtInParameter) {
            if(definition == null) {
                throw new ArgumentNullException(nameof(definition));
            }

            if(definition is InternalDefinition internalDefinition) {
                return (BuiltInParameter) internalDefinition.Id.GetIdValue() == builtInParameter;
            }

            return false;
        }

        /// <summary>
        /// Возвращает <see cref="BuiltInParameter"/> для определения параметра.
        /// </summary>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает <see cref="BuiltInParameter"/> для определения параметра, для не системных параметров возвращает <see cref="BuiltInParameter.INVALID"/>.</returns>
        public static BuiltInParameter GetBuiltInParameter(this Definition definition) {
            if(definition is InternalDefinition internalDefinition) {
                if(internalDefinition.Id.IsSystemId()) {
                    return (BuiltInParameter) internalDefinition.Id.GetIdValue();
                }
            }

            return BuiltInParameter.INVALID;
        }
    }
}
