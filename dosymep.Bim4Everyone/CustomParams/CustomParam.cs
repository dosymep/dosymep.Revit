using System.Linq;

using Autodesk.Revit.DB;

using dosymep.Revit;

namespace dosymep.Bim4Everyone.CustomParams {
    /// <summary>
    /// Пользовательский параметр Revit.
    /// </summary>
    public class CustomParam : RevitParam {
        /// <summary>
        /// Создает экземпляр пользовательского параметра Revit.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        public CustomParam(string paramId)
            : base(paramId) {
        }

        /// <inheritdoc />
        public override bool IsExistsParam(Document document) {
            return document.IsExistsParam(Name);
        }

        /// <inheritdoc />
        public override (Definition Definition, Binding Binding) GetParamBinding(Document document) {
            return document.GetParameterBindings().FirstOrDefault(item => item.Definition.Name.Equals(Name));
        }

        /// <inheritdoc />
        public override ParameterElement GetRevitParamElement(Document document) {
            return document.GetProjectParamElements().FirstOrDefault(item => item.Name.Equals(Name));
        }

        /// <inheritdoc />
        public override Parameter GetParam(Element element) {
            return element.GetParam(Name);
        }
    }
}