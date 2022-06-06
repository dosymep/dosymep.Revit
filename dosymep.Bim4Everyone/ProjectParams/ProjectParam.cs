using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.ProjectParams {
    /// <summary>
    /// Класс параметров проекта Revit.
    /// </summary>
    public class ProjectParam : RevitParam {
        /// <summary>
        /// Конструктор класса параметра проекта.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        [JsonConstructor]
        internal ProjectParam(string paramId)
            : base(paramId) {
        }

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.IsExistsProjectParam(Name);
        }

        /// <inheritdoc/>
        public override (Definition Definition, Binding Binding) GetParamBinding(Document document) {
            return document.GetProjectParamBinding(Name);
        }

        /// <inheritdoc/>
        public override ParameterElement GetRevitParamElement(Document document) {
            return document.GetProjectParam(Name);
        }

        /// <summary>
        /// Проверяет является ли определение параметра параметром проекта.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является параметром проекта, иначе false.</returns>
        public override bool IsRevitParam(Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return base.IsRevitParam(document, definition) && document.IsProjectParamDefinition(definition);
        }

        /// <inheritdoc/>
        public override Parameter GetParam(Element element) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            var param = element.GetParameters(Name).FirstOrDefault(item => !item.IsShared);
            if(param is null) {
                throw new ArgumentException($"Параметр проекта с заданным именем \"{Name}\" не был найден.");
            }

            if(param.StorageType != StorageType) {
                throw new ArgumentException(
                    $"Переданный Параметр проекта \"{Name}\" не соответствует типу параметра у элемента.");
            }

            return param;
        }
    }
}