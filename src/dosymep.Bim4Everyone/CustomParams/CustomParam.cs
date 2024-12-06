using System;
using System.Linq;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.CustomParams {
    /// <summary>
    /// Пользовательский параметр Revit.
    /// </summary>
    public class CustomParam : RevitParam {
        /// <summary>
        /// Создает экземпляр пользовательского параметра Revit.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        public CustomParam(string id)
            : base(id) {
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
        
        #region Serialization

        /// <summary>
        /// Метод чтения параметра из json
        /// </summary>
        /// <param name="token">Токен</param>
        /// <param name="serializer">Сериализатор</param>
        internal static RevitParam ReadFromJson(JObject token, JsonSerializer serializer) {
            return RevitParam.ReadFromJson(token, serializer, new CustomParam(token.Value<string>(nameof(Id))));
        }

        /// <inheritdoc />
        protected override void SaveToJsonImpl(JsonWriter writer, JsonSerializer serializer) { }
        
        #endregion
    }
}