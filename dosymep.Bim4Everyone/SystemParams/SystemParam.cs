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
    public partial class SystemParam : RevitParam {
        private readonly LanguageType? _languageType;
        
#if D2020 || R2020 || D2021 || R2021
        /// <summary>
        /// Создает экземпляр класса системного параметра.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        /// <param name="systemParamId">Системный параметр.</param>
        internal SystemParam(LanguageType? languageType, BuiltInParameter systemParamId) {
            _languageType = languageType;
            SystemParamId = systemParamId;
        }

        /// <summary>
        /// Системное наименование параметра.
        /// </summary>
        public BuiltInParameter SystemParamId { get; }

        /// <inheritdoc/>
        public override string Name {
            get {
                if(_languageType.HasValue) {
                    return LabelUtils.GetLabelFor(SystemParamId, _languageType.Value);
                }

                return LabelUtils.GetLabelFor(SystemParamId);
            }
            set => throw new NotSupportedException(
                $"Для установки имени параметра нужно использовать свойство \"{nameof(SystemParamId)}\".");
        }

        /// <inheritdoc/>
        public override string Id {
            get => Enum.GetName(typeof(BuiltInParameter), SystemParamId);
            set =>
                throw new NotSupportedException("Установка имени свойства для системного параметра запрещено.");
        }
#else
        /// <summary>
        /// Создает экземпляр класса системного параметра.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        /// <param name="forgeTypeId">Системный параметр.</param>
        internal SystemParam(LanguageType? languageType, ForgeTypeId forgeTypeId) {
            _languageType = languageType;
            SystemParamId = forgeTypeId;
        }
        
        /// <summary>
        /// Системное наименование параметра.
        /// </summary>
        public ForgeTypeId SystemParamId { get; }

        /// <inheritdoc/>
        public override string Name {
            get {
                if(_languageType.HasValue) {
                    return LabelUtils.GetLabelForBuiltInParameter(SystemParamId, _languageType.Value);
                }

                return LabelUtils.GetLabelForBuiltInParameter(SystemParamId);
            }

            set => throw new NotSupportedException(
                $"Для установки имени параметра нужно использовать свойство \"{nameof(SystemParamId)}\".");
        }

        /// <inheritdoc/>
        [JsonIgnore]
        public override string Id {
            get => typeof(ParameterTypeId)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(item => (ForgeTypeId) item.GetValue(this) == SystemParamId)?.Name;
            set =>
                throw new NotSupportedException("Установка имени свойства для системного параметра запрещено.");
        }
#endif

        /// <inheritdoc/>
        [JsonIgnore]
        public override StorageType StorageType => SystemParamId.GetStorageType();

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