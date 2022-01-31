using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

namespace dosymep.Bim4Everyone.SystemParams {
    /// <summary>
    /// Класс системного параметра.
    /// </summary>
    public class SystemParam : RevitParam {        
        private readonly LanguageType? _languageType;

#if D2020 || R2020 || D2021 || R2021
        /// <summary>
        /// Создает экземпляр класса системного параметра.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        /// <param name="builtInParameter">Системный параметр.</param>
        internal SystemParam(LanguageType? languageType, BuiltInParameter builtInParameter) {
            _languageType = languageType;
            SystemParamId = builtInParameter;
        }

        /// <summary>
        /// Системное наименование параметра.
        /// </summary>
        public BuiltInParameter SystemParamId { get; }
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
#endif

        /// <inheritdoc/>
        public override string Name {
            get {
#if D2020 || R2020 || D2021 || R2021
                if(_languageType.HasValue) {
                    return LabelUtils.GetLabelFor(SystemParamId, _languageType.Value);
                }

                return LabelUtils.GetLabelFor(SystemParamId);

#else
                if(_languageType.HasValue) {
                    return LabelUtils.GetLabelForBuiltInParameter(SystemParamId, _languageType.Value);
                }
                
                return LabelUtils.GetLabelForBuiltInParameter(SystemParamId);
#endif
            }
            
            set => throw new NotSupportedException($"Для установки имени параметра нужно использовать свойство \"{nameof(BuiltInParameter)}\".");
        }

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            return true;
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
