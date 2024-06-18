using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
#if REVIT2021_OR_GREATER

    /// <summary>
    /// Расширения для класса <see cref="Autodesk.Revit.DB.ForgeTypeId"/>.
    /// </summary>
    public static class ForgeTypeIdExtensions {
        /// <summary>
        /// Пустой ForgeTypeId
        /// </summary>
        public static readonly ForgeTypeId EmptyForgeTypeId = new ForgeTypeId();

        /// <summary>
        /// Наименование свойства SpecTypeId Undefined
        /// </summary>
        public static string UnitTypeUndefinedName { get; } = "UT_Undefined";

        /// <summary>
        /// Возвращает наименование свойства единицы измерения <see cref="SpecTypeId"/>.
        /// </summary>
        /// <param name="forgeTypeId">Единица измерения.</param>
        /// <returns>Возвращает наименование свойства единицы измерения <see cref="SpecTypeId"/>.</returns>
        public static string GetSpecTypeIdName(this ForgeTypeId forgeTypeId) {
            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            if(forgeTypeId == EmptyForgeTypeId) {
                return UnitTypeUndefinedName;
            }

#if REVIT2021

            if(!UnitUtils.IsSpec(forgeTypeId)) {
                throw new ArgumentException(
                    $"Переданный ForgeTypeId \"{forgeTypeId.TypeId}\" не является единицей измерения.",
                    nameof(forgeTypeId));
            }

#endif

#if REVIT2022_OR_GREATER

            if(!SpecUtils.IsValidDataType(forgeTypeId)) {
                throw new ArgumentException(
                    $"Переданный ForgeTypeId \"{forgeTypeId.TypeId}\" не является единицей измерения.",
                    nameof(forgeTypeId));
            }

#endif

            PropertyInfo propertyInfo = GetSpecIdTypes()
                .SelectMany(item => item.GetProperties())
                .FirstOrDefault(item => item.GetValue(null)?.Equals(forgeTypeId) == true);

            if(propertyInfo == null) {
                return UnitTypeUndefinedName;
            }

            return $"{propertyInfo.DeclaringType?.FullName}.{propertyInfo.Name}";
        }


        /// <summary>
        /// Возвращает <see cref="Autodesk.Revit.DB.ForgeTypeId"/> единицы измерения по имени свойства <see cref="SpecTypeId"/>.
        /// </summary>
        /// <param name="specTypeIdName">Наименование свойства единицы измерения.</param>
        /// <returns>Возвращает <see cref="Autodesk.Revit.DB.ForgeTypeId"/> единицы измерения по имени свойства <see cref="SpecTypeId"/>.</returns>
        public static ForgeTypeId GetSpecIdByName(string specTypeIdName) {
            if(string.IsNullOrEmpty(specTypeIdName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(specTypeIdName));
            }

            if(specTypeIdName == UnitTypeUndefinedName) {
                return EmptyForgeTypeId;
            }

            int index = specTypeIdName.LastIndexOf('.');
            if(index < 0) {
                return EmptyForgeTypeId;
            }

            string typeName = specTypeIdName.Substring(0, index);
            string propertyName = specTypeIdName.Substring(index + 1, specTypeIdName.Length - index - 1);

            return (ForgeTypeId) typeof(SpecTypeId).Assembly
                .GetType(typeName)
                .GetProperty(propertyName)
                ?.GetValue(null) ?? EmptyForgeTypeId;
        }

        private static IEnumerable<Type> GetSpecIdTypes() {
            yield return typeof(SpecTypeId);
            foreach(Type innerType in typeof(SpecTypeId).GetMembers().OfType<Type>()) {
                yield return innerType;
            }
        }
    }

#endif
    
}