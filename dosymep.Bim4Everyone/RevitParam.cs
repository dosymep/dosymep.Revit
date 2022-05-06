using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone {
    /// <summary>
    /// Абстрактный класс параметра Revit.
    /// </summary>
    public abstract class RevitParam {
        /// <summary>
        /// Идентификатор параметра.
        /// </summary>
        public virtual string Id { get; set; }
        
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
    }
}
