using System;

using Autodesk.Revit.DB;

using dosymep.Revit;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Фабрика для создания экземпляров RevitParam.
    /// </summary>
    internal class RevitParamFactory : IRevitParamFactory {
        private readonly IParamElementService _projectParamsService;
        private readonly IParamElementService _sharedParamsService;
        private readonly ISystemParamsService _systemParamsService;

        public RevitParamFactory(
            IProjectParamsService projectParamsService,
            ISharedParamsService sharedParamsService,
            ISystemParamsService systemParamsService) {
            _projectParamsService = projectParamsService;
            _sharedParamsService = sharedParamsService;
            _systemParamsService = systemParamsService;
        }

        /// <inheritdoc />
        public RevitParam Create(Document document, ElementId paramId) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(paramId.IsNull()) {
                throw new ArgumentNullException(nameof(paramId));
            }

            return paramId.IsNotSystemId()
                ? Create(document, document.GetElement(paramId) as ParameterElement)
                : _systemParamsService.CreateRevitParam(document, paramId.AsBuiltInParameter());
        }

        /// <inheritdoc />
        public bool CanCreate(Document document, ElementId paramId) {
            if(document == null) {
                return false;
            }

            if(paramId.IsNull()) {
                return false;
            }

            if(paramId.IsSystemId()) {
                return true;
            }

            return document.GetElement(paramId) is ParameterElement;
        }

        private RevitParam Create(Document document, ParameterElement paramElement) {
            if(document == null) {
                throw new ArgumentNullException(nameof(document));
            }

            if(paramElement == null) {
                throw new ArgumentNullException(nameof(paramElement));
            }

            return paramElement.IsSharedParam()
                ? _sharedParamsService.CreateRevitParam(document, paramElement)
                : _projectParamsService.CreateRevitParam(document, paramElement);
        }
    }
}