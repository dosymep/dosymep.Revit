﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;
using pyRevitLabs.Json.Linq;

namespace dosymep.Bim4Everyone.SystemParams {
    /// <summary>
    /// Класс системного параметра.
    /// </summary>
    public class SystemParam : RevitParam {
        /// <summary>
        /// Идентификатор типа сериализатора.
        /// </summary>
        private static readonly Guid _typeId = new Guid("222CC682-ED41-4C85-80D8-544EC73A1884");
        
        /// <summary>
        /// Конструктор класса системного параметра.
        /// </summary>
        /// <param name="id">Идентификатор параметра.</param>
        [JsonConstructor]
        internal SystemParam(string id)
            : base(id) {
            SystemParamId = GetSystemParamId(id);
        }

        internal static BuiltInParameter GetSystemParamId(string paramId) {
            return (BuiltInParameter) Enum.Parse(typeof(BuiltInParameter), paramId);
        }
        
        /// <summary>
        /// Системное наименование параметра.
        /// </summary>
        [JsonIgnore]
        public BuiltInParameter SystemParamId { get; private set; }


        /// <summary>
        /// Язык системного параметра.
        /// </summary>
        [JsonIgnore]
        public LanguageType? LanguageType { get; set; }

        /// <summary>
        /// Наименование параметра.
        /// </summary>
        [JsonIgnore]
        public override string Name {
            get {
                try {
                    return LanguageType == null
                        ? LabelUtils.GetLabelFor(SystemParamId)
                        : LabelUtils.GetLabelFor(SystemParamId, LanguageType.Value);
                } catch(Autodesk.Revit.Exceptions.InvalidOperationException) {
                    return $"Без имени ({SystemParamId})";
                }
            }
        }

        /// <summary>
        /// Тип параметра.
        /// </summary>
        public override StorageType StorageType { get; set; }

#if REVIT2020

        /// <inheritdoc/>
        [JsonIgnore]
        public override UnitType UnitType => SystemParamId.GetUnitType();
        
#else
        
        /// <inheritdoc/>
        [JsonIgnore]        
        public override ForgeTypeId UnitType => SystemParamId.GetUnitType();

        /// <inheritdoc/>
        [JsonIgnore]
        public override string UnitTypeName => UnitType.GetSpecTypeIdName();

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
        
        #region Serialization

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
            return RevitParam.ReadFromJson(token, new SystemParam(token.Value<string>("id")));
        }


        /// <inheritdoc />
        protected override void SaveToJsonImpl(JsonWriter writer, JsonSerializer serializer) {
            writer.WritePropertyName("type_id");
            writer.WriteValue(_typeId);
        }

        #endregion
    }
}