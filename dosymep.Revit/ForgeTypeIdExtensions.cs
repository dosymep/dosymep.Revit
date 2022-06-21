using System;
using System.Linq;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
#if D2021 || R2021 || D2022 || R2022

    /// <summary>
    /// Расширения для класса <see cref="Autodesk.Revit.DB.ForgeTypeId"/>.
    /// </summary>
    public static class ForgeTypeIdExtensions {
        /// <summary>
        /// Пустой ForgeTypeId
        /// </summary>
        public static ForgeTypeId EmptyForgeTypeId { get; } = new ForgeTypeId();

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

#if REVIT_2022_OR_GREATER

            if(!SpecUtils.IsSpec(forgeTypeId)) {
                throw new ArgumentException(
                    $"Переданный ForgeTypeId \"{forgeTypeId.TypeId}\" не является единицей измерения.",
                    nameof(forgeTypeId));
            }

#endif

            return typeof(SpecTypeId).GetProperties()
                .FirstOrDefault(item => item.GetValue(null)?.Equals(forgeTypeId) == true)?.Name;
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

            return (ForgeTypeId) typeof(SpecTypeId).GetProperty(specTypeIdName)?.GetValue(null);
        }
    }

#endif
}