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

        /// <summary>
        /// Создает экземпляр класса системного параметра.
        /// </summary>
        /// <param name="languageType">Язык системы.</param>
        /// <param name="builtInParameter">Системный параметр.</param>
        internal SystemParam(LanguageType? languageType, BuiltInParameter builtInParameter) {
            _languageType = languageType;
            BuiltInParameter = builtInParameter;
        }

        /// <inheritdoc/>
        public override string Name {
            get {
                if(_languageType.HasValue) {
                    return LabelUtils.GetLabelFor(BuiltInParameter, _languageType.Value);
                }
                
                return LabelUtils.GetLabelFor(BuiltInParameter);
            }
            
            set => throw new NotSupportedException($"Для установки имени параметра нужно использовать свойство \"{nameof(BuiltInParameter)}\".");
        }

        /// <summary>
        /// Системное наименование параметра.
        /// </summary>
        public BuiltInParameter BuiltInParameter { get; }

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            return true;
        }

        /// <inheritdoc/>
        public override Parameter GetParam(Element element) {
            return element.GetParam(BuiltInParameter);
        }
    }
}
