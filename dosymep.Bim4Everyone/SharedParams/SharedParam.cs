using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;

using dosymep.Revit;

using pyRevitLabs.Json;

namespace dosymep.Bim4Everyone.SharedParams {
    /// <summary>
    /// Класс общего параметра
    /// </summary>
    public class SharedParam : RevitParam {
        private readonly Guid? _paramGuid;
        private readonly StorageType? _storageType;

        /// <summary>
        /// Содержит все описания общих параметров
        /// </summary>
        private static readonly Dictionary<string, string> _description
            = new Dictionary<string, string>() {
                {nameof(SharedParamsConfig.AlbumBlueprints), "Описание AlbumBlueprints"},
                {nameof(SharedParamsConfig.ApartmentArea), "Описание ApartmentArea"},
                {nameof(SharedParamsConfig.ApartmentAreaMaxSpec), "Описание ApartmentAreaMaxSpec"},
                {nameof(SharedParamsConfig.ApartmentAreaMinSpec), "Описание ApartmentAreaMinSpec"},
                {nameof(SharedParamsConfig.ApartmentAreaNoBalcony), "Описание ApartmentAreaNoBalcony"},
                {nameof(SharedParamsConfig.ApartmentAreaRatio), "Описание ApartmentAreaRatio"},
                {nameof(SharedParamsConfig.ApartmentAreaSpec), "Описание ApartmentAreaSpec"},
                {nameof(SharedParamsConfig.ApartmentFullArea), "Описание ApartmentFullArea"},
                {nameof(SharedParamsConfig.ApartmentGroupName), "Описание ApartmentGroupName"},
                {nameof(SharedParamsConfig.ApartmentLivingArea), "Описание ApartmentLivingArea"},
                {nameof(SharedParamsConfig.ApartmentNumber), "Описание ApartmentNumber"},
                {nameof(SharedParamsConfig.ApartmentNumberExtra), "Описание ApartmentNumberExtra"},
                {nameof(SharedParamsConfig.FireCompartmentShortName), "Описание FireCompartmentShortName"},
                {nameof(SharedParamsConfig.Level), "Описание Level"},
                {nameof(SharedParamsConfig.MechanicalSystemName), "Описание MechanicalSystemName"},
                {nameof(SharedParamsConfig.RoomArea), "Описание RoomArea"},
                {nameof(SharedParamsConfig.RoomAreaRatio), "Описание RoomAreaRatio"},
                {nameof(SharedParamsConfig.RoomAreaWithRatio), "Описание RoomAreaWithRatio"},
                {nameof(SharedParamsConfig.RoomGroupShortName), "Описание RoomGroupShortName"},
                {nameof(SharedParamsConfig.RoomsCount), "Описание RoomsCount"},
                {nameof(SharedParamsConfig.RoomSectionShortName), "Описание RoomSectionShortName"},
                {nameof(SharedParamsConfig.RoomTypeGroupShortName), "Описание RoomTypeGroupShortName"},
                {nameof(SharedParamsConfig.StampSheetNumber), "Описание StampSheetNumber"},
                {nameof(SharedParamsConfig.VISCombinedName), "Описание VISCombinedName"},
                {nameof(SharedParamsConfig.VISGrouping), "Описание VISGrouping"},
                {nameof(SharedParamsConfig.VISMass), "Описание VISMass"},
                {nameof(SharedParamsConfig.VISMinDuctThickness), "Описание VISMinDuctThickness"},
                {nameof(SharedParamsConfig.VISSpecNumbers), "Описание VISSpecNumbers"},
                {nameof(SharedParamsConfig.VISUnit), "Описание VISUnit"},
            };

        /// <summary>
        /// Содержит все типы общих параметров
        /// </summary>
        private static readonly Dictionary<string, StorageType> _paramTypes =
            new Dictionary<string, StorageType>() {
                {nameof(SharedParamsConfig.AlbumBlueprints), StorageType.String},
                {nameof(SharedParamsConfig.ApartmentArea), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentAreaMaxSpec), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentAreaMinSpec), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentAreaNoBalcony), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentAreaRatio), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentAreaSpec), StorageType.String},
                {nameof(SharedParamsConfig.ApartmentFullArea), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentGroupName), StorageType.String},
                {nameof(SharedParamsConfig.ApartmentLivingArea), StorageType.Double},
                {nameof(SharedParamsConfig.ApartmentNumber), StorageType.String},
                {nameof(SharedParamsConfig.ApartmentNumberExtra), StorageType.String},
                {nameof(SharedParamsConfig.FireCompartmentShortName), StorageType.String},
                {nameof(SharedParamsConfig.Level), StorageType.String},
                {nameof(SharedParamsConfig.MechanicalSystemName), StorageType.String},
                {nameof(SharedParamsConfig.RoomArea), StorageType.Double},
                {nameof(SharedParamsConfig.RoomAreaRatio), StorageType.Double},
                {nameof(SharedParamsConfig.RoomAreaWithRatio), StorageType.Double},
                {nameof(SharedParamsConfig.RoomGroupShortName), StorageType.String},
                {nameof(SharedParamsConfig.RoomsCount), StorageType.Integer},
                {nameof(SharedParamsConfig.RoomSectionShortName), StorageType.String},
                {nameof(SharedParamsConfig.RoomTypeGroupShortName), StorageType.String},
                {nameof(SharedParamsConfig.StampSheetNumber), StorageType.String},
                {nameof(SharedParamsConfig.VISCombinedName), StorageType.String},
                {nameof(SharedParamsConfig.VISGrouping), StorageType.String},
                {nameof(SharedParamsConfig.VISMass), StorageType.Double},
                {nameof(SharedParamsConfig.VISMinDuctThickness), StorageType.Double},
                {nameof(SharedParamsConfig.VISSpecNumbers), StorageType.Double},
                {nameof(SharedParamsConfig.VISUnit), StorageType.String},
            };


        private readonly Dictionary<string, Guid> _paramGuids =
            new Dictionary<string, Guid>() {
                {nameof(SharedParamsConfig.AlbumBlueprints), new Guid("e1b06433-f527-403c-8986-af9a01e6be7f")},
                {nameof(SharedParamsConfig.ApartmentArea), new Guid("603c712b-657c-4195-b153-30950ae5f4cb")},
                {nameof(SharedParamsConfig.ApartmentAreaMaxSpec), new Guid("2a6f369d-9065-4b55-a7d3-33db24751a98")},
                {nameof(SharedParamsConfig.ApartmentAreaMinSpec), new Guid("24508a72-b07c-460a-a580-d5ae2d54ab94")},
                {nameof(SharedParamsConfig.ApartmentAreaNoBalcony), new Guid("374fc833-240a-4d71-95fc-7d349456ca7e")},
                {nameof(SharedParamsConfig.ApartmentAreaRatio), new Guid("80be4e2b-0656-45d2-90e6-e372685b03aa")},
                {nameof(SharedParamsConfig.ApartmentAreaSpec), new Guid("f6616ef6-481c-4133-81f9-c258790822e2")},
                {nameof(SharedParamsConfig.ApartmentFullArea), new Guid("317ce3f3-b540-4a5d-9cba-15cd273d0e4e")},
                {nameof(SharedParamsConfig.ApartmentGroupName), new Guid("a3cb8c52-4c45-42ff-abc0-a569cd122763")},
                {nameof(SharedParamsConfig.ApartmentLivingArea), new Guid("3e43f7d6-6dfe-4b88-a874-7c54272789b7")},
                {nameof(SharedParamsConfig.ApartmentNumber), new Guid("083c183f-d3d3-4710-9efc-f21ade3680f9")},
                {nameof(SharedParamsConfig.ApartmentNumberExtra), new Guid("735e1a5f-e5f6-44b6-b94f-bb810db5bafc")},
                {nameof(SharedParamsConfig.FireCompartmentShortName), new Guid("b750a7c4-e882-4952-a773-07f060946ad7")},
                {nameof(SharedParamsConfig.Level), new Guid("248ddd42-5597-4eba-bba2-818056f8586c")},
                {nameof(SharedParamsConfig.MechanicalSystemName), new Guid("4be4ed4d-c509-4ef3-a55d-23d3a406b83c")},
                {nameof(SharedParamsConfig.RoomArea), new Guid("88698162-c32d-45df-9db6-2ddb07b04d17")},
                {nameof(SharedParamsConfig.RoomAreaRatio), new Guid("3a8a1879-1802-4bc6-9c1a-c375dc1a9292")},
                {nameof(SharedParamsConfig.RoomAreaWithRatio), new Guid("aa4729e4-4964-43c1-a706-4b45d0567771")},
                {nameof(SharedParamsConfig.RoomGroupShortName), new Guid("c7955ded-0589-4d86-93a1-7d205d5852e2")},
                {nameof(SharedParamsConfig.RoomsCount), new Guid("2498f7c7-de06-42c7-93dc-5e269cadc202")},
                {nameof(SharedParamsConfig.RoomSectionShortName), new Guid("c39f32dd-a2b7-4853-8dc0-13c63c052eb2")},
                {nameof(SharedParamsConfig.RoomTypeGroupShortName), new Guid("2e36a08a-94c0-4b35-a082-e5e3d51765cf")},
                {nameof(SharedParamsConfig.StampSheetNumber), new Guid("b6e73342-b6cd-42c5-86c5-64b04b5b88de")},
                {nameof(SharedParamsConfig.VISCombinedName), new Guid("3624223b-d55a-4b60-98e7-af64d6242409")},
                {nameof(SharedParamsConfig.VISGrouping), new Guid("7bf3d944-9973-484d-9195-66472ddd150f")},
                {nameof(SharedParamsConfig.VISMass), new Guid("4a62a841-b2d0-4c94-aca8-c907f1adcc88")},
                {nameof(SharedParamsConfig.VISMinDuctThickness), new Guid("7af80795-5115-46e4-867f-f276a2510250")},
                {nameof(SharedParamsConfig.VISSpecNumbers), new Guid("37e09a6d-093b-432b-9647-33b70424642d")},
                {nameof(SharedParamsConfig.VISUnit), new Guid("02d3bf80-f03c-4055-ad5c-3dfb2c6ff26a")},
            };

        /// <summary>
        /// Конструктор класса общего параметра
        /// </summary>
        internal SharedParam() { }

        /// <summary>
        /// Конструктор класса общего параметра проекта.
        /// </summary>
        /// <param name="paramGuid">Guid общего параметра.</param>
        /// <param name="storageType">Тип параметра проекта.</param>
        internal SharedParam(Guid paramGuid, StorageType storageType) {
            _paramGuid = paramGuid;
            _storageType = storageType;
        }
        
        /// <summary>
        /// Guid общего параметра.
        /// </summary>
        [JsonIgnore]
        public Guid Guid => GetGuid();

        /// <inheritdoc/>
        [JsonIgnore]
        public override string Description => GetDescription();

        /// <inheritdoc/>
        [JsonIgnore]
        public override StorageType StorageType => GetStorageType();

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
                param = element.GetSharedParam(Name);
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
        
        private Guid GetGuid() {
            if(_paramGuid == null) {
                return _paramGuids.TryGetValue(PropertyName, out Guid value) ? value : Guid.Empty;
            }

            return _paramGuid.Value;
        }
        
        private string GetDescription() {
            return _description.TryGetValue(PropertyName, out string value) ? value : null;
        }

        private StorageType GetStorageType() {
            if(_storageType == null) {
                return _paramTypes.TryGetValue(PropertyName, out StorageType value) ? value : StorageType.None;
            }

            return _storageType.Value;
        }
    }
}