using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Абстрактный класс параметра Revit.
    /// </summary>
    public abstract class RevitParam : IEquatable<RevitParam> {
        /// <summary>
        /// Создает экземпляр класса параметра Revit.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        protected RevitParam(string id) {
            if(string.IsNullOrEmpty(id)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Идентификатор параметра.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Наименование параметра.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Описание параметра.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Тип параметра.
        /// </summary>
        public virtual StorageType StorageType { get; set; }

#if REVIT2020
        /// <summary>
        /// Тип измерения параметра.
        /// </summary>
        public virtual UnitType UnitType { get; set; }

#else

        /// <summary>
        /// Тип измерения параметра.
        /// </summary>
        [JsonIgnore]
        public virtual ForgeTypeId UnitType {
            get => ForgeTypeIdExtensions.GetSpecIdByName(UnitTypeName);
            set => UnitTypeName = value.GetSpecTypeIdName();
        }

        /// <summary>
        /// Наименование свойства типа измерения параметра.
        /// </summary>
        public virtual string UnitTypeName { get; set; }

#endif

        /// <summary>
        /// Проверяет на существование параметра в документе.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public abstract bool IsExistsParam(Document document);

        /// <summary>
        /// Возвращает настройки привязки параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает настройки привязки параметра.</returns>
        public abstract (Definition Definition, Binding Binding) GetParamBinding(Document document);

        /// <summary>
        /// Возвращает элемент параметра.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Возвращает элемент параметра.</returns>
        public abstract ParameterElement GetRevitParamElement(Document document);

        /// <summary>
        /// Возвращает параметр элемента.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает параметр элемента.</returns>
        public abstract Parameter GetParam(Element element);

        /// <summary>
        /// Проверяет на существование параметра в элементе.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает true - если параметр существует, иначе false.</returns>
        public virtual bool IsExistsParam(Element element) {
            return element.IsExistsParam(this);
        }

        /// <summary>
        /// Проверяет является ли определение параметра параметром Revit.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является параметром Revit, иначе false.</returns>
        public virtual bool IsRevitParam(Document document, Definition definition) {
            return Name.Equals(definition?.Name);
        }

        /// <summary>
        /// Возвращает параметр Revit.
        /// </summary>
        /// <returns>Возвращает параметр Revit.</returns>
        public RevitParam AsRevitParam() {
            return this;
        }

        #region Serialization

        internal static T ReadFromJson<T>(JToken token, T revitParam) where T : RevitParam {
            revitParam.Name = token.Value<string>("name");
            revitParam.Description = token.Value<string>("description");
            revitParam.StorageType = token.Value<StorageType>("storage_type");

#if REVIT2020
            revitParam.UnitType = token.Value<UnitType>("unit_type");
#else
            revitParam.UnitType = token.Value<ForgeTypeId>("unit_type");
#endif

            return revitParam;
        }

        /// <summary>
        /// Метод сохранения параметра в json
        /// </summary>
        /// <param name="writer">Writer</param>
        /// <param name="serializer">Serializer</param>
        internal void SaveToJson(JsonWriter writer, JsonSerializer serializer) {
            SaveToJsonImpl(writer, serializer);

            writer.WritePropertyName("id");
            writer.WriteValue(Id);

            writer.WritePropertyName("name");
            writer.WriteValue(Name);

            writer.WritePropertyName("description");
            writer.WriteValue(Description);

            writer.WritePropertyName("storage_type");
            writer.WriteValue(StorageType);

            writer.WritePropertyName("unit_type");
            writer.WriteValue(UnitType);
        }

        /// <summary>
        /// Метод сохранения параметра в json
        /// </summary>
        /// <param name="writer">Writer</param>
        /// <param name="serializer">Serializer</param>
        protected abstract void SaveToJsonImpl(JsonWriter writer, JsonSerializer serializer);

        #endregion

        #region IEquatable

        /// <inheritdoc />
        public bool Equals(RevitParam other) {
            if(ReferenceEquals(null, other)) {
                return false;
            }

            if(ReferenceEquals(this, other)) {
                return true;
            }

            return string.Equals(Id, other.Id, StringComparison.CurrentCulture);
        }

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if(ReferenceEquals(null, obj)) {
                return false;
            }

            if(ReferenceEquals(this, obj)) {
                return true;
            }

            if(obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((RevitParam) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return StringComparer.CurrentCulture.GetHashCode(Id);
        }

        #endregion
    }
}