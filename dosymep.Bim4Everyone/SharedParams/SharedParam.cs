using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SharedParams {
    /// <summary>
    /// Класс общего параметра
    /// </summary>
    public class SharedParam : RevitParam {
        /// <summary>
        /// Конструктор класса общего параметра.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        /// <param name="guid">Guid общего параметра.</param>
        [JsonConstructor]
        internal SharedParam(string paramId, Guid guid)
            : base(paramId) {
            Guid = guid;
        }


        /// <summary>
        /// Guid общего параметра.
        /// </summary>
        public Guid Guid { get; }

        /// <inheritdoc/>
        public override bool IsExistsParam(Document document) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return document.IsExistsSharedParam(Guid) || document.IsExistsSharedParam(Name);
        }

        /// <inheritdoc/>
        public override (Definition Definition, Binding Binding) GetParamBinding(Document document) {
            return document.GetSharedParamBinding(Name);
        }

        /// <inheritdoc/>
        public override ParameterElement GetRevitParamElement(Document document) {
            return document.GetSharedParam(Guid) ?? document.GetSharedParam(Name);
        }

        /// <summary>
        /// Проверяет является ли определение параметра общим параметром.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает true - если определение параметра является общим параметром, иначе false.</returns>
        public override bool IsRevitParam(Document document, Definition definition) {
            if(document is null) {
                throw new ArgumentNullException(nameof(document));
            }

            return base.IsRevitParam(document, definition) && document.IsSharedParamDefinition(definition);
        }

        /// <inheritdoc/>
        public override Parameter GetParam(Element element) {
            if(element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            Parameter param = null;
            try {
                param = element.GetSharedParam(Guid);
            } catch(System.ArgumentException) {
                try {
                    param = element.GetSharedParam(Name);
                } catch(System.ArgumentException) {
                }
            }

            if(param is null) {
                throw new ArgumentException($"Общий параметр с заданным именем \"{Name}\" или Guid \"{Guid}\" не был найден.");
            }

            if(param.StorageType != StorageType) {
                throw new ArgumentException(
                    $"Переданный общий параметр \"{Name}\" или Guid \"{Guid}\" не соответствует типу параметра у элемента.");
            }

            return param;
        }

        /// <summary>
        /// Возвращает описание общего параметра из ФОП.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает описание общего параметра из ФОП.</returns>
        public ExternalDefinition GetExternalDefinition(Application application) {
            DefinitionFile definitionFile = application.OpenSharedParameterFile();

            ExternalDefinition[] definitions = definitionFile.Groups
                .SelectMany(item => item.Definitions)
                .OfType<ExternalDefinition>()
                .ToArray();

            return definitions.FirstOrDefault(item => item.GUID.Equals(Guid))
                   ?? definitions.FirstOrDefault(item => item.Name.Equals(Name));
        }

        /// <summary>
        /// Возвращает описание общего параметра из ФОП.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <param name="groupName">Наименование группы параметров.</param>
        /// <returns>Возвращает описание общего параметра из ФОП.</returns>
        public ExternalDefinition GetExternalDefinition(Application application, string groupName) {
            DefinitionFile definitionFile = application.OpenSharedParameterFile();
         
            return definitionFile.Groups.get_Item(groupName).Definitions
                       .OfType<ExternalDefinition>()
                       .FirstOrDefault(item => item.GUID == Guid)
                   ?? (ExternalDefinition) definitionFile.Groups.get_Item(groupName)?.Definitions.get_Item(Name);
        }
    }
}