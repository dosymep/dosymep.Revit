using System;
using System.Linq;

using Autodesk.Revit.DB;

using DevExpress.XtraSpreadsheet.Model;

using dosymep.Revit;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.CustomParams {
    /// <summary>
    /// Пользовательский параметр Revit.
    /// </summary>
    public class CustomParam : RevitParam {
        /// <summary>
        /// Идентификатор типа сериализатора.
        /// </summary>
        private static readonly Guid _typeId = new Guid("A7947671-74FF-4681-BDDD-705F0B74D4D9");
        
        /// <summary>
        /// Создает экземпляр пользовательского параметра Revit.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        public CustomParam(string id)
            : base(id) {
        }
        
        /// <summary>
        /// Проверяет тип объекта.
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Возвращает true - если токен является нужным типом.</returns>
        internal static bool CheckType(JToken token) {
            return token.Value<Guid>("type_id") == _typeId;
        }

        /// <summary>
        /// Метод сохранения параметра в json
        /// </summary>
        /// <param name="token">Токен</param>
        internal static RevitParam ReadFromJson(JToken token) {
            return RevitParam.ReadFromJson(token, new CustomParam(token.Value<string>("id")));
        }

        /// <inheritdoc />
        protected override void SaveToJsonImpl(JsonWriter writer, JsonSerializer serializer) {
            writer.WritePropertyName("type_id");
            writer.WriteValue(_typeId);
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