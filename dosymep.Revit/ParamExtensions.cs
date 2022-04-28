using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    /// <summary>
    /// Расширения класса параметров.
    /// </summary>
    public static class ParamExtensions {
        /// <summary>
        /// Возвращает значение параметра.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает значение параметра.</returns>
        public static object AsObject(this Parameter parameter) {
            if(parameter is null) {
                throw new ArgumentNullException(nameof(parameter));
            }

            if(parameter.HasValue) {
                var storageType = parameter.StorageType;
                switch(storageType) {
                    case StorageType.Integer:
                        return parameter.AsInteger();
                    case StorageType.Double:
                        return parameter.AsDouble();
                    case StorageType.String: {
                        var value = parameter.AsString();
                        return string.IsNullOrWhiteSpace(value) ? null : value;
                    }

                    case StorageType.ElementId:
                        return parameter.AsElementId();
                }
            }

            return null;
        }

        /// <summary>
        /// Удаляет значение параметра (устанавливает значение по умолчанию)
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public static void RemoveValue(this Parameter parameter) {
            if(parameter is null) {
                throw new ArgumentNullException(nameof(parameter));
            }

            if(parameter.HasValue) {
                var storageType = parameter.StorageType;
                switch(storageType) {
                    case StorageType.Integer:
                        parameter.Set((int) default);
                        break;
                    case StorageType.Double:
                        parameter.Set((double) default);
                        break;
                    case StorageType.String:
                        parameter.Set((string) default);
                        break;
                    case StorageType.ElementId:
                        parameter.Set((ElementId) default);
                        break;
                }
            }
        }

        /// <summary>
        /// Присваивает значение параметра по значению другого параметра.
        /// </summary>
        /// <param name="leftParameter">Параметр в который присваивается значение.</param>
        /// <param name="rightParameter">Параметр значение которого присваивается.</param>
        public static void Set(this Parameter leftParameter, Parameter rightParameter) {
            if(leftParameter is null) {
                throw new ArgumentNullException(nameof(leftParameter));
            }

            if(rightParameter is null) {
                throw new ArgumentNullException(nameof(rightParameter));
            }

            if(leftParameter.StorageType != StorageType.String &&
               leftParameter.StorageType != rightParameter.StorageType) {
                throw new ArgumentException("У переданного параметра не соответствует тип данных.",
                    nameof(rightParameter));
            }

            var storageType = rightParameter.StorageType;
            switch(storageType) {
                case StorageType.Integer:
                    leftParameter.Set(rightParameter.AsInteger());
                    break;
                case StorageType.Double:
                    leftParameter.Set(rightParameter.AsDouble());
                    break;
                case StorageType.String:
                    leftParameter.Set(rightParameter.AsObject()?.ToString());
                    break;
                case StorageType.ElementId:
                    leftParameter.Set(rightParameter.AsElementId());
                    break;
                default:
                    leftParameter.Set((string) null);
                    break;
            }
        }

        /// <summary>
        /// Проверяет является ли привязка параметра для типа элемента.
        /// </summary>
        /// <param name="binding">Привязка параметра.</param>
        /// <returns>Возвращает true - если привязка параметра является типом элемента.</returns>
        public static bool IsTypeBinding(this Binding binding) {
            return binding is TypeBinding;
        }

        /// <summary>
        /// Проверяет является ли привязка параметра для экземпляром элемента.
        /// </summary>
        /// <param name="binding">Привязка параметра.</param>
        /// <returns>Возвращает true - если привязка параметра является экземпляром элемента.</returns>
        public static bool IsInstanceBinding(this Binding binding) {
            return binding is InstanceBinding;
        }

        /// <summary>
        /// Возвращает нумератор категорий.
        /// </summary>
        /// <param name="binding">Привязка параметра.</param>
        /// <returns>Возвращает нумератор категорий.</returns>
        public static IEnumerable<Category> GetCategories(this Binding binding) {
            return ((ElementBinding) binding).Categories.OfType<Category>();
        }

        /// <summary>
        /// Возвращает тип параметра.
        /// </summary>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает тип параметра.</returns>
        public static StorageType GetStorageType(this Definition definition) {
            if(definition == null) {
                throw new ArgumentNullException(nameof(definition));
            }

            switch(definition.ParameterType) {
                case ParameterType.Invalid: return StorageType.String;
                case ParameterType.Text: return StorageType.String;
                case ParameterType.Integer: return StorageType.Integer;
                case ParameterType.Number: return StorageType.Double;
                case ParameterType.Length: return StorageType.Double;
                case ParameterType.Area: return StorageType.Double;
                case ParameterType.Volume: return StorageType.Double;
                case ParameterType.Angle: return StorageType.Double;
                case ParameterType.URL: return StorageType.String;
                case ParameterType.Material: return StorageType.ElementId;
                case ParameterType.YesNo: return StorageType.Integer;
                case ParameterType.Force: return StorageType.Double;
                case ParameterType.LinearForce: return StorageType.Double;
                case ParameterType.AreaForce: return StorageType.Double;
                case ParameterType.Moment: return StorageType.Double;
                case ParameterType.NumberOfPoles: return StorageType.Integer;
                case ParameterType.FixtureUnit: return StorageType.Double;
                case ParameterType.LoadClassification: return StorageType.ElementId;
                case ParameterType.Image: return StorageType.ElementId;
                case ParameterType.MultilineText: return StorageType.String;
                case ParameterType.HVACDensity: return StorageType.Double;
                case ParameterType.HVACEnergy: return StorageType.Double;
                case ParameterType.HVACFriction: return StorageType.Double;
                case ParameterType.HVACPower: return StorageType.Double;
                case ParameterType.HVACPowerDensity: return StorageType.Double;
                case ParameterType.HVACPressure: return StorageType.Double;
                case ParameterType.HVACTemperature: return StorageType.Double;
                case ParameterType.HVACVelocity: return StorageType.Double;
                case ParameterType.HVACAirflow: return StorageType.Double;
                case ParameterType.HVACDuctSize: return StorageType.Double;
                case ParameterType.HVACCrossSection: return StorageType.Double;
                case ParameterType.HVACHeatGain: return StorageType.Double;
                case ParameterType.ElectricalCurrent: return StorageType.Double;
                case ParameterType.ElectricalPotential: return StorageType.Double;
                case ParameterType.ElectricalFrequency: return StorageType.Double;
                case ParameterType.ElectricalIlluminance: return StorageType.Double;
                case ParameterType.ElectricalLuminousFlux: return StorageType.Double;
                case ParameterType.ElectricalPower: return StorageType.Double;
                case ParameterType.HVACRoughness: return StorageType.Double;
                case ParameterType.ElectricalApparentPower: return StorageType.Double;
                case ParameterType.ElectricalPowerDensity: return StorageType.Double;
                case ParameterType.PipingDensity: return StorageType.Double;
                case ParameterType.PipingFlow: return StorageType.Double;
                case ParameterType.PipingFriction: return StorageType.Double;
                case ParameterType.PipingPressure: return StorageType.Double;
                case ParameterType.PipingTemperature: return StorageType.Double;
                case ParameterType.PipingVelocity: return StorageType.Double;
                case ParameterType.PipingViscosity: return StorageType.Double;
                case ParameterType.PipeSize: return StorageType.Double;
                case ParameterType.PipingRoughness: return StorageType.Double;
                case ParameterType.Stress: return StorageType.Double;
                case ParameterType.UnitWeight: return StorageType.Double;
                case ParameterType.ThermalExpansion: return StorageType.Double;
                case ParameterType.LinearMoment: return StorageType.Double;
                case ParameterType.ForcePerLength: return StorageType.Double;
                case ParameterType.ForceLengthPerAngle: return StorageType.Double;
                case ParameterType.LinearForcePerLength: return StorageType.Double;
                case ParameterType.LinearForceLengthPerAngle: return StorageType.Double;
                case ParameterType.AreaForcePerLength: return StorageType.Double;
                case ParameterType.PipingVolume: return StorageType.Double;
                case ParameterType.HVACViscosity: return StorageType.Double;
                case ParameterType.HVACCoefficientOfHeatTransfer: return StorageType.Double;
                case ParameterType.HVACAirflowDensity: return StorageType.Double;
                case ParameterType.Slope: return StorageType.Double;
                case ParameterType.HVACCoolingLoad: return StorageType.Double;
                case ParameterType.HVACCoolingLoadDividedByArea: return StorageType.Double;
                case ParameterType.HVACCoolingLoadDividedByVolume: return StorageType.Double;
                case ParameterType.HVACHeatingLoad: return StorageType.Double;
                case ParameterType.HVACHeatingLoadDividedByArea: return StorageType.Double;
                case ParameterType.HVACHeatingLoadDividedByVolume: return StorageType.Double;
                case ParameterType.HVACAirflowDividedByVolume: return StorageType.Double;
                case ParameterType.HVACAirflowDividedByCoolingLoad: return StorageType.Double;
                case ParameterType.HVACAreaDividedByCoolingLoad: return StorageType.Double;
                case ParameterType.WireSize: return StorageType.Double;
                case ParameterType.HVACSlope: return StorageType.Double;
                case ParameterType.PipingSlope: return StorageType.Double;
                case ParameterType.Currency: return StorageType.Double;
                case ParameterType.ElectricalEfficacy: return StorageType.Double;
                case ParameterType.ElectricalWattage: return StorageType.Double;
                case ParameterType.ColorTemperature: return StorageType.Double;
                case ParameterType.ElectricalLuminousIntensity: return StorageType.Double;
                case ParameterType.ElectricalLuminance: return StorageType.Double;
                case ParameterType.HVACAreaDividedByHeatingLoad: return StorageType.Double;
                case ParameterType.HVACFactor: return StorageType.Double;
                case ParameterType.ElectricalTemperature: return StorageType.Double;
                case ParameterType.ElectricalCableTraySize: return StorageType.Double;
                case ParameterType.ElectricalConduitSize: return StorageType.Double;
                case ParameterType.ReinforcementVolume: return StorageType.Double;
                case ParameterType.ReinforcementLength: return StorageType.Double;
                case ParameterType.ElectricalDemandFactor: return StorageType.Double;
                case ParameterType.HVACDuctInsulationThickness: return StorageType.Double;
                case ParameterType.HVACDuctLiningThickness: return StorageType.Double;
                case ParameterType.PipeInsulationThickness: return StorageType.Double;
                case ParameterType.HVACThermalResistance: return StorageType.Double;
                case ParameterType.HVACThermalMass: return StorageType.Double;
                case ParameterType.Acceleration: return StorageType.Double;
                case ParameterType.BarDiameter: return StorageType.Double;
                case ParameterType.CrackWidth: return StorageType.Double;
                case ParameterType.DisplacementDeflection: return StorageType.Double;
                case ParameterType.Energy: return StorageType.Double;
                case ParameterType.StructuralFrequency: return StorageType.Double;
                case ParameterType.Mass: return StorageType.Double;
                case ParameterType.MassPerUnitLength: return StorageType.Double;
                case ParameterType.MomentOfInertia: return StorageType.Double;
                case ParameterType.SurfaceArea: return StorageType.Double;
                case ParameterType.Period: return StorageType.Double;
                case ParameterType.Pulsation: return StorageType.Double;
                case ParameterType.ReinforcementArea: return StorageType.Double;
                case ParameterType.ReinforcementAreaPerUnitLength: return StorageType.Double;
                case ParameterType.ReinforcementCover: return StorageType.Double;
                case ParameterType.ReinforcementSpacing: return StorageType.Double;
                case ParameterType.Rotation: return StorageType.Double;
                case ParameterType.SectionArea: return StorageType.Double;
                case ParameterType.SectionDimension: return StorageType.Double;
                case ParameterType.SectionModulus: return StorageType.Double;
                case ParameterType.SectionProperty: return StorageType.Double;
                case ParameterType.StructuralVelocity: return StorageType.Double;
                case ParameterType.WarpingConstant: return StorageType.Double;
                case ParameterType.Weight: return StorageType.Double;
                case ParameterType.WeightPerUnitLength: return StorageType.Double;
                case ParameterType.HVACThermalConductivity: return StorageType.Double;
                case ParameterType.HVACSpecificHeat: return StorageType.Double;
                case ParameterType.HVACSpecificHeatOfVaporization: return StorageType.Double;
                case ParameterType.HVACPermeability: return StorageType.Double;
                case ParameterType.ElectricalResistivity: return StorageType.Double;
                case ParameterType.MassDensity: return StorageType.Double;
                case ParameterType.MassPerUnitArea: return StorageType.Double;
                case ParameterType.PipeDimension: return StorageType.Double;
                case ParameterType.PipeMass: return StorageType.Double;
                case ParameterType.PipeMassPerUnitLength: return StorageType.Double;
                case ParameterType.HVACTemperatureDifference: return StorageType.Double;
                case ParameterType.PipingTemperatureDifference: return StorageType.Double;
                case ParameterType.ElectricalTemperatureDifference: return StorageType.Double;
                case ParameterType.TimeInterval: return StorageType.Double;
                case ParameterType.Speed: return StorageType.Double;
                case ParameterType.FamilyType: return StorageType.ElementId;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
