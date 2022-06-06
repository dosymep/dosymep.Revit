using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SystemParams {
    /// <summary>
    /// Класс системного параметра.
    /// </summary>
    public class SystemParam : RevitParam {
        /// <summary>
        /// Конструктор класса системного параметра.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        [JsonConstructor]
        internal SystemParam(string paramId)
            : base(paramId) {
            SystemParamId = (BuiltInParameter) Enum.Parse(typeof(BuiltInParameter), paramId);
        }

        /// <summary>
        /// Системное наименование параметра.
        /// </summary>
        [JsonIgnore]
        public BuiltInParameter SystemParamId { get; }


        /// <summary>
        /// Язык системного параметра.
        /// </summary>
        [JsonIgnore]
        public LanguageType? LanguageType { get; set; }

        /// <summary>
        /// Наименование параметра.
        /// </summary>
        [JsonIgnore]
        public override string Name
            => LanguageType == null
                ? LabelUtils.GetLabelFor(SystemParamId)
                : LabelUtils.GetLabelFor(SystemParamId, LanguageType.Value);

        /// <summary>
        /// Тип параметра.
        /// </summary>
        [JsonIgnore]
        public override StorageType StorageType => SystemParamId.GetStorageType();

#if D2020 || R2020

        /// <summary>
        /// Тип измерения параметра.
        /// </summary>
        [JsonIgnore]
        public override UnitType UnitType => SystemParamId.GetUnitType();
        
#else
        
        /// <summary>
        /// Тип измерения параметра.
        /// </summary>
        [JsonIgnore]        
        public override ForgeTypeId UnitType => SystemParamId.GetUnitType();
        
#endif

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            return true;
        }

        /// <inheritdoc/>
        public override (Definition Definition, Binding Binding) GetParamBinding(Document document) {
            return document.GetSystemParamBinding(Name);
        }

        /// <inheritdoc/>
        public override ParameterElement GetRevitParamElement(Document document) {
            return null;
        }

        /// <summary>
        /// Проверяет является ли определение параметра внутренним параметром.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является внутренним параметром, иначе false.</returns>
        public override bool IsRevitParam(Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return base.IsRevitParam(document, definition) && document.IsSystemParamDefinition(definition);
        }

        /// <inheritdoc/>
        public override Parameter GetParam(Element element) {
            return element.GetParam(SystemParamId);
        }
    }
}