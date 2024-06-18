using System;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    public partial class ParamExtensions {
#if REVIT2020

        /// <summary>
        /// Возвращает <see cref="Autodesk.Revit.DB.UnitType"/> для системного параметра.
        /// </summary>
        /// <param name="builtInParameter">Системный параметр.</param>
        /// <returns>Возвращает <see cref="Autodesk.Revit.DB.UnitType"/> для системного параметра.</returns>
        public static UnitType GetUnitType(this BuiltInParameter builtInParameter) {
            switch((int) builtInParameter) {
                case -1155202: // BuiltInParameter.PATH_OF_TRAVEL_FROM_ROOM
                    return UnitType.UT_Undefined;
                case -1155201: // BuiltInParameter.PATH_OF_TRAVEL_TO_ROOM
                    return UnitType.UT_Undefined;
                case -1155146: // BuiltInParameter.STEEL_ELEM_PROFILE_TYPE
                    return UnitType.UT_Undefined;
                case -1155136: // BuiltInParameter.STEEL_ELEM_PLATE_TYPE
                    return UnitType.UT_Undefined;
                case -1155130: // BuiltInParameter.STEEL_ELEM_ANCHOR_ORIENTATION
                    return UnitType.UT_Undefined;
                case -1155122: // BuiltInParameter.STEEL_ELEM_BOLT_LOCATION
                    return UnitType.UT_Undefined;
                case -1155116: // BuiltInParameter.GENERIC_ZONE_NAME
                    return UnitType.UT_Undefined;
                case -1155100: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_PARAM
                    return UnitType.UT_Undefined;
                case -1155094: // BuiltInParameter.PATH_OF_TRAVEL_VIEW_NAME
                    return UnitType.UT_Undefined;
                case -1155093: // BuiltInParameter.PATH_OF_TRAVEL_LEVEL_NAME
                    return UnitType.UT_Undefined;
                case -1155092: // BuiltInParameter.STRUCTURAL_CONNECTION_OVERRIDE_TYPE
                    return UnitType.UT_Undefined;
                case -1155074: // BuiltInParameter.STEEL_ELEM_WELD_PREFIX
                    return UnitType.UT_Undefined;
                case -1155073: // BuiltInParameter.STEEL_ELEM_WELD_TEXT_MODULE
                    return UnitType.UT_Undefined;
                case -1155060: // BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER
                    return UnitType.UT_Undefined;
                case -1155052: // BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER_Y
                    return UnitType.UT_Undefined;
                case -1155051: // BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER_X
                    return UnitType.UT_Undefined;
                case -1155047: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_WELDPREP
                    return UnitType.UT_Undefined;
                case -1155046: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_SURFACESHAPE
                    return UnitType.UT_Undefined;
                case -1155045: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_TEXT
                    return UnitType.UT_Undefined;
                case -1155043: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_TYPE
                    return UnitType.UT_Undefined;
                case -1155039: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_WELDPREP
                    return UnitType.UT_Undefined;
                case -1155038: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_SURFACESHAPE
                    return UnitType.UT_Undefined;
                case -1155037: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_TEXT
                    return UnitType.UT_Undefined;
                case -1155035: // BuiltInParameter.STEEL_ELEM_WELD_CONTINUOUS
                    return UnitType.UT_Undefined;
                case -1155034: // BuiltInParameter.STEEL_ELEM_WELD_LOCATION
                    return UnitType.UT_Undefined;
                case -1155031: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_TYPE
                    return UnitType.UT_Undefined;
                case -1155018: // BuiltInParameter.STEEL_ELEM_BOLT_COATING
                    return UnitType.UT_Undefined;
                case -1155017: // BuiltInParameter.STEEL_ELEM_ANCHOR_LENGTH
                    return UnitType.UT_Undefined;
                case -1155016: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_DIAMETER
                    return UnitType.UT_Undefined;
                case -1155015: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_GRADE
                    return UnitType.UT_Undefined;
                case -1155014: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_STANDARD
                    return UnitType.UT_Undefined;
                case -1155013: // BuiltInParameter.STEEL_ELEM_ANCHOR_DIAMETER
                    return UnitType.UT_Undefined;
                case -1155012: // BuiltInParameter.STEEL_ELEM_ANCHOR_ASSEMBLY
                    return UnitType.UT_Undefined;
                case -1155011: // BuiltInParameter.STEEL_ELEM_ANCHOR_GRADE
                    return UnitType.UT_Undefined;
                case -1155010: // BuiltInParameter.STEEL_ELEM_ANCHOR_STANDARD
                    return UnitType.UT_Undefined;
                case -1155009: // BuiltInParameter.STEEL_ELEM_COATING
                    return UnitType.UT_Undefined;
                case -1155008: // BuiltInParameter.STEEL_ELEM_BOLT_DIAMETER
                    return UnitType.UT_Undefined;
                case -1155007: // BuiltInParameter.STEEL_ELEM_BOLT_ASSEMBLY
                    return UnitType.UT_Undefined;
                case -1155006: // BuiltInParameter.STEEL_ELEM_BOLT_GRADE
                    return UnitType.UT_Undefined;
                case -1155005: // BuiltInParameter.STEEL_ELEM_BOLT_STANDARD
                    return UnitType.UT_Undefined;
                case -1154695: // BuiltInParameter.REBAR_WORKSHOP_INSTRUCTIONS
                    return UnitType.UT_Undefined;
                case -1154694: // BuiltInParameter.REBAR_GEOMETRY_TYPE
                    return UnitType.UT_Undefined;
                case -1154687: // BuiltInParameter.ROOM_OUTDOOR_AIRFLOW_STANDARD_PARAM
                    return UnitType.UT_Undefined;
                case -1154662: // BuiltInParameter.ROOM_OUTDOOR_AIR_INFO_PARAM
                    return UnitType.UT_Undefined;
                case -1154656: // BuiltInParameter.REBAR_ELEM_ENDTREATMENT_END
                    return UnitType.UT_Undefined;
                case -1154655: // BuiltInParameter.REBAR_ELEM_ENDTREATMENT_START
                    return UnitType.UT_Undefined;
                case -1154653: // BuiltInParameter.COUPLER_COUPLED_ENDTREATMENT
                    return UnitType.UT_Undefined;
                case -1154652: // BuiltInParameter.COUPLER_MAIN_ENDTREATMENT
                    return UnitType.UT_Undefined;
                case -1154649: // BuiltInParameter.COUPLER_MARK
                    return UnitType.UT_Undefined;
                case -1154642: // BuiltInParameter.COUPLER_NUMBER
                    return UnitType.UT_Undefined;
                case -1154641: // BuiltInParameter.COUPLER_QUANTITY
                    return UnitType.UT_Undefined;
                case -1154640: // BuiltInParameter.COUPLER_COUPLED_BAR_SIZE
                    return UnitType.UT_Undefined;
                case -1154639: // BuiltInParameter.COUPLER_MAIN_BAR_SIZE
                    return UnitType.UT_Undefined;
                case -1154638: // BuiltInParameter.COUPLER_CODE
                    return UnitType.UT_Undefined;
                case -1154620: //
                    return UnitType.UT_Undefined;
                case -1154619: // BuiltInParameter.REBAR_ELEM_HOST_MARK
                    return UnitType.UT_Undefined;
                case -1154618: // BuiltInParameter.REBAR_SHAPE_IMAGE
                    return UnitType.UT_Undefined;
                case -1154617: // BuiltInParameter.FABRIC_NUMBER
                    return UnitType.UT_Undefined;
                case -1154616: // BuiltInParameter.REBAR_NUMBER
                    return UnitType.UT_Undefined;
                case -1154614: // BuiltInParameter.NUMBER_PARTITION_PARAM
                    return UnitType.UT_Undefined;
                case -1153528: // BuiltInParameter.MEP_ZONE_EQUIPMENT_DRAW_VENTILATION
                    return UnitType.UT_Undefined;
                case -1153527: // BuiltInParameter.MEP_VRF_LOOP
                    return UnitType.UT_Undefined;
                case -1153526: // BuiltInParameter.MEP_REHEAT_HOTWATER_LOOP
                    return UnitType.UT_Undefined;
                case -1153519: // BuiltInParameter.MEP_ZONE_EQUIPMENT
                    return UnitType.UT_Undefined;
                case -1153518: // BuiltInParameter.MEP_ANALYTICAL_EQUIPMENT_NAME
                    return UnitType.UT_Undefined;
                case -1153517: // BuiltInParameter.MEP_ZONE_HOTWATER_LOOP
                    return UnitType.UT_Undefined;
                case -1153516: // BuiltInParameter.MEP_ZONE_AIR_LOOP
                    return UnitType.UT_Undefined;
                case -1153514: // BuiltInParameter.MEP_REHEAT_COIL_TYPE
                    return UnitType.UT_Undefined;
                case -1153513: // BuiltInParameter.MEP_ZONE_EQUIPMENT_BEHAVIOR
                    return UnitType.UT_Undefined;
                case -1153512: // BuiltInParameter.MEP_ZONE_EQUIPMENT_TYPE
                    return UnitType.UT_Undefined;
                case -1153511: // BuiltInParameter.MEP_AIRLOOP_FANTYPE
                    return UnitType.UT_Undefined;
                case -1153510: // BuiltInParameter.MEP_CHILLED_WATER_LOOP
                    return UnitType.UT_Undefined;
                case -1153509: // BuiltInParameter.MEP_COOLING_COIL_TYPE
                    return UnitType.UT_Undefined;
                case -1153508: // BuiltInParameter.MEP_HEATING_HOTWATER_LOOP
                    return UnitType.UT_Undefined;
                case -1153507: // BuiltInParameter.MEP_HEATING_COIL_TYPE
                    return UnitType.UT_Undefined;
                case -1153506: // BuiltInParameter.MEP_PREHEAT_HOTWATER_LOOP
                    return UnitType.UT_Undefined;
                case -1153505: // BuiltInParameter.MEP_AIRLOOP_PREHEAT_COILTYPE
                    return UnitType.UT_Undefined;
                case -1153504: // BuiltInParameter.MEP_AIRLOOP_HEATEXCHANGER_TYPE
                    return UnitType.UT_Undefined;
                case -1153503: // BuiltInParameter.MEP_CONDENSER_WATER_LOOP
                    return UnitType.UT_Undefined;
                case -1153502: // BuiltInParameter.MEP_WATERLOOP_CHILLERTYPE
                    return UnitType.UT_Undefined;
                case -1153501: // BuiltInParameter.MEP_WATERLOOP_TYPE
                    return UnitType.UT_Undefined;
                case -1153500: // BuiltInParameter.MEP_ANALYTICAL_LOOP_NAME
                    return UnitType.UT_Undefined;
                case -1153114: // BuiltInParameter.MEP_IGNORE_FLOW_ANALYSIS
                    return UnitType.UT_Undefined;
                case -1153113: // BuiltInParameter.MEP_ANALYTICAL_LOOP_BOUNDARY_PARAM
                    return UnitType.UT_Undefined;
                case -1153112: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ID_PARAM
                    return UnitType.UT_Undefined;
                case -1153111: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_NAME
                    return UnitType.UT_Undefined;
                case -1153110: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ON_STANDBY
                    return UnitType.UT_Undefined;
                case -1153109: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ON_DUTY
                    return UnitType.UT_Undefined;
                case -1153106: // BuiltInParameter.MEP_ANALYTICAL_CRITICALPATH_PARAM
                    return UnitType.UT_Undefined;
                case -1153100: // BuiltInParameter.MEP_EQUIPMENT_CLASSIFICATION
                    return UnitType.UT_Undefined;
                case -1153004: // BuiltInParameter.STRUCTURAL_CONNECTION_INPUT_ELEMENTS
                    return UnitType.UT_Undefined;
                case -1153002: // BuiltInParameter.STRUCTURAL_CONNECTION_CODE_CHECKING_STATUS
                    return UnitType.UT_Undefined;
                case -1153001: // BuiltInParameter.STRUCTURAL_CONNECTION_APPROVAL_STATUS
                    return UnitType.UT_Undefined;
                case -1152385: // BuiltInParameter.ALL_MODEL_IMAGE
                    return UnitType.UT_Undefined;
                case -1152384: // BuiltInParameter.ALL_MODEL_TYPE_IMAGE
                    return UnitType.UT_Undefined;
                case -1152383: // BuiltInParameter.STRUCT_FRAM_JOIN_STATUS
                    return UnitType.UT_Undefined;
                case -1152372: // BuiltInParameter.END_Z_JUSTIFICATION
                    return UnitType.UT_Undefined;
                case -1152370: // BuiltInParameter.END_Y_JUSTIFICATION
                    return UnitType.UT_Undefined;
                case -1152368: // BuiltInParameter.START_Z_JUSTIFICATION
                    return UnitType.UT_Undefined;
                case -1152366: // BuiltInParameter.START_Y_JUSTIFICATION
                    return UnitType.UT_Undefined;
                case -1152364: // BuiltInParameter.Z_JUSTIFICATION
                    return UnitType.UT_Undefined;
                case -1152362: // BuiltInParameter.Y_JUSTIFICATION
                    return UnitType.UT_Undefined;
                case -1152353: //
                    return UnitType.UT_Undefined;
                case -1152345: // BuiltInParameter.DPART_SHAPE_MODIFIED
                    return UnitType.UT_Undefined;
                case -1152344: // BuiltInParameter.DPART_EXCLUDED
                    return UnitType.UT_Undefined;
                case -1152335: // BuiltInParameter.DPART_BASE_LEVEL
                    return UnitType.UT_Undefined;
                case -1151306: // BuiltInParameter.STAIRS_RUN_ACTUAL_NUMBER_OF_TREADS
                    return UnitType.UT_Undefined;
                case -1151305: // BuiltInParameter.STAIRS_RUN_ACTUAL_NUMBER_OF_RISERS
                    return UnitType.UT_Undefined;
                case -1151211: // BuiltInParameter.STAIRSTYPE_INTERMEDIATE_SUPPORT_TYPE
                    return UnitType.UT_Undefined;
                case -1151210: // BuiltInParameter.STAIRSTYPE_LEFT_SIDE_SUPPORT_TYPE
                    return UnitType.UT_Undefined;
                case -1151209: // BuiltInParameter.STAIRSTYPE_RIGHT_SIDE_SUPPORT_TYPE
                    return UnitType.UT_Undefined;
                case -1151208: // BuiltInParameter.STAIRSTYPE_LANDING_TYPE
                    return UnitType.UT_Undefined;
                case -1151207: // BuiltInParameter.STAIRSTYPE_RUN_TYPE
                    return UnitType.UT_Undefined;
                case -1150481: // BuiltInParameter.PROPERTY_SET_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1150468: // BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM
                    return UnitType.UT_Undefined;
                case -1150466: // BuiltInParameter.PROPERTY_SET_NAME
                    return UnitType.UT_Undefined;
                case -1150465: // BuiltInParameter.PHY_MATERIAL_PARAM_SUBCLASS
                    return UnitType.UT_Undefined;
                case -1150464: // BuiltInParameter.PHY_MATERIAL_PARAM_CLASS
                    return UnitType.UT_Undefined;
                case -1150435: // BuiltInParameter.RBS_REFERENCE_FREESIZE
                    return UnitType.UT_Undefined;
                case -1150434: // BuiltInParameter.RBS_REFERENCE_OVERALLSIZE
                    return UnitType.UT_Undefined;
                case -1150432: // BuiltInParameter.RBS_REFERENCE_LINING_TYPE
                    return UnitType.UT_Undefined;
                case -1150430: // BuiltInParameter.RBS_REFERENCE_INSULATION_TYPE
                    return UnitType.UT_Undefined;
                case -1150427: // BuiltInParameter.RBS_PIPE_CALCULATED_SIZE
                    return UnitType.UT_Undefined;
                case -1150426: // BuiltInParameter.RBS_DUCT_CALCULATED_SIZE
                    return UnitType.UT_Undefined;
                case -1150420: // BuiltInParameter.ASSEMBLY_NAME
                    return UnitType.UT_Undefined;
                case -1150403: // BuiltInParameter.ASSEMBLY_NAMING_CATEGORY
                    return UnitType.UT_Undefined;
                case -1141012: // BuiltInParameter.FABRICATION_BRA_SIZE
                    return UnitType.UT_Undefined;
                case -1141011: // BuiltInParameter.FABRICATION_SEC_SIZE
                    return UnitType.UT_Undefined;
                case -1141010: // BuiltInParameter.FABRICATION_PRI_SIZE
                    return UnitType.UT_Undefined;
                case -1140999: // BuiltInParameter.FABRICATION_FITTING_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1140977: // BuiltInParameter.FABRICATION_PART_NOTES
                    return UnitType.UT_Undefined;
                case -1140975: // BuiltInParameter.FABRICATION_PART_ITEM_NUMBER
                    return UnitType.UT_Undefined;
                case -1140973: // BuiltInParameter.FABRICATION_SERVICE_NAME
                    return UnitType.UT_Undefined;
                case -1140971: // BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL
                    return UnitType.UT_Undefined;
                case -1140970: // BuiltInParameter.FABRICATION_PART_CUT_TYPE
                    return UnitType.UT_Undefined;
                case -1140969: // BuiltInParameter.FABRICATION_PART_BOUGHT_OUT
                    return UnitType.UT_Undefined;
                case -1140968: // BuiltInParameter.FABRICATION_PART_ALIAS
                    return UnitType.UT_Undefined;
                case -1140966: // BuiltInParameter.FABRICATION_PRODUCT_CODE
                    return UnitType.UT_Undefined;
                case -1140920: // BuiltInParameter.FABRICATION_VENDOR
                    return UnitType.UT_Undefined;
                case -1140916: // BuiltInParameter.FABRICATION_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1140915: // BuiltInParameter.FABRICATION_SPECIFICATION
                    return UnitType.UT_Undefined;
                case -1140914: // BuiltInParameter.FABRICATION_VENDOR_CODE
                    return UnitType.UT_Undefined;
                case -1140910: // BuiltInParameter.FABRICATION_PRODUCT_DATA_INSTALL_TYPE
                    return UnitType.UT_Undefined;
                case -1140909: // BuiltInParameter.FABRICATION_PART_MATERIAL
                    return UnitType.UT_Undefined;
                case -1140908: // BuiltInParameter.FABRICATION_PRODUCT_DATA_OEM
                    return UnitType.UT_Undefined;
                case -1140907: // BuiltInParameter.FABRICATION_PRODUCT_DATA_PRODUCT
                    return UnitType.UT_Undefined;
                case -1140906: // BuiltInParameter.FABRICATION_PRODUCT_DATA_ITEM_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1140905: // BuiltInParameter.FABRICATION_PRODUCT_DATA_SIZE_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1140904: // BuiltInParameter.FABRICATION_PRODUCT_DATA_MATERIAL_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1140903: // BuiltInParameter.FABRICATION_PRODUCT_DATA_SPECIFICATION
                    return UnitType.UT_Undefined;
                case -1140902: // BuiltInParameter.FABRICATION_PRODUCT_DATA_LONG_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1140901: // BuiltInParameter.FABRICATION_PRODUCT_DATA_RANGE
                    return UnitType.UT_Undefined;
                case -1140900: // BuiltInParameter.FABRICATION_PRODUCT_DATA_FINISH_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1140702: // BuiltInParameter.TRUSS_ELEMENT_CLASS_PARAM
                    return UnitType.UT_Undefined;
                case -1140422: // BuiltInParameter.KEYNOTE_PARAM
                    return UnitType.UT_Undefined;
                case -1140417: // BuiltInParameter.PHY_MATERIAL_PARAM_GRADE
                    return UnitType.UT_Undefined;
                case -1140416: // BuiltInParameter.PHY_MATERIAL_PARAM_SPECIES
                    return UnitType.UT_Undefined;
                case -1140400: // BuiltInParameter.PHY_MATERIAL_PARAM_TYPE
                    return UnitType.UT_Undefined;
                case -1140362: // BuiltInParameter.ELEM_CATEGORY_PARAM
                    return UnitType.UT_Undefined;
                case -1140339: // BuiltInParameter.FABRICATION_SERVICE_PARAM
                    return UnitType.UT_Undefined;
                case -1140336: // BuiltInParameter.RBS_DUCT_SYSTEM_CALCULATION_PARAM
                    return UnitType.UT_Undefined;
                case -1140335: // BuiltInParameter.RBS_PIPE_SYSTEM_CALCULATION_PARAM
                    return UnitType.UT_Undefined;
                case -1140334: // BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140333: // BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140332: // BuiltInParameter.RBS_SYSTEM_ABBREVIATION_PARAM
                    return UnitType.UT_Undefined;
                case -1140327: // BuiltInParameter.RBS_SYSTEM_NUM_ELEMENTS_PARAM
                    return UnitType.UT_Undefined;
                case -1140326: // BuiltInParameter.RBS_SYSTEM_BASE_ELEMENT_PARAM
                    return UnitType.UT_Undefined;
                case -1140325: // BuiltInParameter.RBS_SYSTEM_CLASSIFICATION_PARAM
                    return UnitType.UT_Undefined;
                case -1140324: // BuiltInParameter.RBS_SYSTEM_NAME_PARAM
                    return UnitType.UT_Undefined;
                case -1140323: // BuiltInParameter.PHY_MATERIAL_PARAM_LIGHT_WEIGHT
                    return UnitType.UT_Undefined;
                case -1140322: // BuiltInParameter.PHY_MATERIAL_PARAM_BEHAVIOR
                    return UnitType.UT_Undefined;
                case -1140279: // BuiltInParameter.RBS_SEGMENT_DESCRIPTION_PARAM
                    return UnitType.UT_Undefined;
                case -1140278: // BuiltInParameter.RBS_PIPE_JOINTTYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140263: // BuiltInParameter.RBS_FP_SPRINKLER_PRESSURE_CLASS_PARAM
                    return UnitType.UT_Undefined;
                case -1140262: // BuiltInParameter.RBS_FP_SPRINKLER_ORIFICE_PARAM
                    return UnitType.UT_Undefined;
                case -1140261: // BuiltInParameter.RBS_FP_SPRINKLER_COVERAGE_PARAM
                    return UnitType.UT_Undefined;
                case -1140260: // BuiltInParameter.RBS_FP_SPRINKLER_RESPONSE_PARAM
                    return UnitType.UT_Undefined;
                case -1140218: // BuiltInParameter.RBS_PIPE_FLUID_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140209: // BuiltInParameter.RBS_PIPE_FLOW_STATE_PARAM
                    return UnitType.UT_Undefined;
                case -1140202: // BuiltInParameter.RBS_PIPE_MATERIAL_PARAM
                    return UnitType.UT_Undefined;
                case -1140200: // BuiltInParameter.RBS_PIPE_CLASS_PARAM
                    return UnitType.UT_Undefined;
                case -1140176: // BuiltInParameter.RBS_ELEC_CIRCUIT_CONNECTION_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140169: // BuiltInParameter.RBS_ELEC_PANEL_LOCATION_PARAM
                    return UnitType.UT_Undefined;
                case -1140156: // BuiltInParameter.RBS_ELEC_CIRCUIT_NOTES_PARAM
                    return UnitType.UT_Undefined;
                case -1140155: // BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER_OF_ELEMENTS_PARAM
                    return UnitType.UT_Undefined;
                case -1140150: // BuiltInParameter.RBS_ELEC_PANEL_SCHEDULE_FOOTER_NOTES_PARAM
                    return UnitType.UT_Undefined;
                case -1140149: // BuiltInParameter.RBS_ELEC_PANEL_SCHEDULE_HEADER_NOTES_PARAM
                    return UnitType.UT_Undefined;
                case -1140148: // BuiltInParameter.RBS_ELEC_PANEL_NUMWIRES_PARAM
                    return UnitType.UT_Undefined;
                case -1140147: // BuiltInParameter.RBS_ELEC_PANEL_NUMPHASES_PARAM
                    return UnitType.UT_Undefined;
                case -1140145: // BuiltInParameter.RBS_ELEC_PANEL_NEUTRAL_BUS_PARAM
                    return UnitType.UT_Undefined;
                case -1140144: // BuiltInParameter.RBS_ELEC_PANEL_GROUND_BUS_PARAM
                    return UnitType.UT_Undefined;
                case -1140143: // BuiltInParameter.RBS_ELEC_PANEL_BUSSING_PARAM
                    return UnitType.UT_Undefined;
                case -1140142: // BuiltInParameter.RBS_ELEC_PANEL_SUBFEED_LUGS_PARAM
                    return UnitType.UT_Undefined;
                case -1140141: // BuiltInParameter.RBS_ELEC_PANEL_SUPPLY_FROM_PARAM
                    return UnitType.UT_Undefined;
                case -1140139: // BuiltInParameter.RBS_ELEC_PANEL_MAINSTYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140138: // BuiltInParameter.RBS_ELEC_PANEL_FEED_PARAM
                    return UnitType.UT_Undefined;
                case -1140129: // BuiltInParameter.RBS_CABLETRAYCONDUIT_BENDORFITTING
                    return UnitType.UT_Undefined;
                case -1140128: // BuiltInParameter.RBS_CTC_SERVICE_TYPE
                    return UnitType.UT_Undefined;
                case -1140120: // BuiltInParameter.CIRCUIT_LOAD_CLASSIFICATION_PARAM
                    return UnitType.UT_Undefined;
                case -1140118: // BuiltInParameter.CONDUIT_STANDARD_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140110: // BuiltInParameter.RBS_ELEC_SWITCH_ID_PARAM
                    return UnitType.UT_Undefined;
                case -1140104: // BuiltInParameter.RBS_ELEC_CIRCUIT_PANEL_PARAM
                    return UnitType.UT_Undefined;
                case -1140103: // BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER
                    return UnitType.UT_Undefined;
                case -1140101: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_RUNS_PARAM
                    return UnitType.UT_Undefined;
                case -1140100: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_HOTS_PARAM
                    return UnitType.UT_Undefined;
                case -1140099: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_NEUTRALS_PARAM
                    return UnitType.UT_Undefined;
                case -1140098: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_GROUNDS_PARAM
                    return UnitType.UT_Undefined;
                case -1140089: // BuiltInParameter.RBS_ELEC_CIRCUIT_NAME
                    return UnitType.UT_Undefined;
                case -1140084: // BuiltInParameter.RBS_ELEC_MODIFICATIONS
                    return UnitType.UT_Undefined;
                case -1140083: // BuiltInParameter.RBS_ELEC_ENCLOSURE
                    return UnitType.UT_Undefined;
                case -1140081: // BuiltInParameter.RBS_ELEC_MOUNTING
                    return UnitType.UT_Undefined;
                case -1140080: // BuiltInParameter.RBS_ELEC_SHORT_CIRCUIT_RATING
                    return UnitType.UT_Undefined;
                case -1140079: // BuiltInParameter.RBS_ELEC_MAX_POLE_BREAKERS
                    return UnitType.UT_Undefined;
                case -1140078: // BuiltInParameter.RBS_ELEC_PANEL_NAME
                    return UnitType.UT_Undefined;
                case -1140037: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_SIZE_PARAM
                    return UnitType.UT_Undefined;
                case -1140036: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1140018: // BuiltInParameter.RBS_ELEC_CIRCUIT_TYPE
                    return UnitType.UT_Undefined;
                case -1140009: // BuiltInParameter.RBS_ELEC_POWER_FACTOR_STATE
                    return UnitType.UT_Undefined;
                case -1140003: // BuiltInParameter.RBS_ELEC_BALANCED_LOAD
                    return UnitType.UT_Undefined;
                case -1140001: // BuiltInParameter.RBS_ELEC_NUMBER_OF_POLES
                    return UnitType.UT_Undefined;
                case -1133500: // BuiltInParameter.GROUP_LEVEL
                    return UnitType.UT_Undefined;
                case -1114817: // BuiltInParameter.SPACE_REFERENCE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1114705: // BuiltInParameter.SYSTEM_ZONE_LEVEL_ID
                    return UnitType.UT_Undefined;
                case -1114700: // BuiltInParameter.ZONE_SPACE_OUTDOOR_AIR_OPTION_PARAM
                    return UnitType.UT_Undefined;
                case -1114400: // BuiltInParameter.RBS_GBXML_OPENING_TYPE
                    return UnitType.UT_Undefined;
                case -1114384: // BuiltInParameter.SPACE_ZONE_NAME
                    return UnitType.UT_Undefined;
                case -1114341: // BuiltInParameter.ZONE_USE_AIR_CHANGES_PER_HOUR_PARAM
                    return UnitType.UT_Undefined;
                case -1114340: // BuiltInParameter.ZONE_USE_OUTSIDE_AIR_PER_AREA_PARAM
                    return UnitType.UT_Undefined;
                case -1114339: // BuiltInParameter.ZONE_USE_OUTSIDE_AIR_PER_PERSON_PARAM
                    return UnitType.UT_Undefined;
                case -1114338: // BuiltInParameter.ZONE_USE_DEHUMIDIFICATION_SETPOINT_PARAM
                    return UnitType.UT_Undefined;
                case -1114337: // BuiltInParameter.ZONE_USE_HUMIDIFICATION_SETPOINT_PARAM
                    return UnitType.UT_Undefined;
                case -1114330: // BuiltInParameter.SPACE_IS_PLENUM
                    return UnitType.UT_Undefined;
                case -1114329: // BuiltInParameter.SPACE_IS_OCCUPIABLE
                    return UnitType.UT_Undefined;
                case -1114327: // BuiltInParameter.SPACE_ASSOC_ROOM_NAME
                    return UnitType.UT_Undefined;
                case -1114317: // BuiltInParameter.ZONE_LEVEL_ID
                    return UnitType.UT_Undefined;
                case -1114304: // BuiltInParameter.ZONE_SERVICE_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1114300: // BuiltInParameter.ZONE_NAME
                    return UnitType.UT_Undefined;
                case -1114259: // BuiltInParameter.ROOM_BASE_HEAT_LOAD_ON_PARAM
                    return UnitType.UT_Undefined;
                case -1114258: // BuiltInParameter.ROOM_LIGHTING_LOAD_UNITS_PARAM
                    return UnitType.UT_Undefined;
                case -1114257: // BuiltInParameter.ROOM_POWER_LOAD_UNITS_PARAM
                    return UnitType.UT_Undefined;
                case -1114252: // BuiltInParameter.ROOM_BASE_RETURN_AIRFLOW_ON_PARAM
                    return UnitType.UT_Undefined;
                case -1114251: // BuiltInParameter.ROOM_CONSTRUCTION_SET_PARAM
                    return UnitType.UT_Undefined;
                case -1114246: // BuiltInParameter.RBS_GBXML_SURFACE_TYPE
                    return UnitType.UT_Undefined;
                case -1114241: // BuiltInParameter.RBS_ELECTRICAL_DATA
                    return UnitType.UT_Undefined;
                case -1114240: // BuiltInParameter.RBS_CALCULATED_SIZE
                    return UnitType.UT_Undefined;
                case -1114224: // BuiltInParameter.ROOM_BASE_LIGHTING_LOAD_ON_PARAM
                    return UnitType.UT_Undefined;
                case -1114223: // BuiltInParameter.ROOM_BASE_POWER_LOAD_ON_PARAM
                    return UnitType.UT_Undefined;
                case -1114173: // BuiltInParameter.ROOM_OCCUPANCY_UNIT_PARAM
                    return UnitType.UT_Undefined;
                case -1114172: // BuiltInParameter.ROOM_SPACE_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1114171: // BuiltInParameter.ROOM_CONDITION_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1114167: // BuiltInParameter.RBS_SIZE_LOCK
                    return UnitType.UT_Undefined;
                case -1114125: // BuiltInParameter.RBS_SECTION
                    return UnitType.UT_Undefined;
                case -1019011: // BuiltInParameter.IFC_ORGANIZATION
                    return UnitType.UT_Undefined;
                case -1019010: // BuiltInParameter.IFC_APPLICATION_VERSION
                    return UnitType.UT_Undefined;
                case -1019009: // BuiltInParameter.IFC_APPLICATION_NAME
                    return UnitType.UT_Undefined;
                case -1019008: // BuiltInParameter.PROJECT_ORGANIZATION_NAME
                    return UnitType.UT_Undefined;
                case -1019007: // BuiltInParameter.PROJECT_ORGANIZATION_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1019006: // BuiltInParameter.PROJECT_BUILDING_NAME
                    return UnitType.UT_Undefined;
                case -1019005: // BuiltInParameter.PROJECT_AUTHOR
                    return UnitType.UT_Undefined;
                case -1019004: // BuiltInParameter.IFC_SITE_GUID
                    return UnitType.UT_Undefined;
                case -1019003: // BuiltInParameter.IFC_BUILDING_GUID
                    return UnitType.UT_Undefined;
                case -1019002: // BuiltInParameter.IFC_PROJECT_GUID
                    return UnitType.UT_Undefined;
                case -1019001: // BuiltInParameter.IFC_TYPE_GUID
                    return UnitType.UT_Undefined;
                case -1019000: // BuiltInParameter.IFC_GUID
                    return UnitType.UT_Undefined;
                case -1018362: // BuiltInParameter.PATH_REIN_SHAPE_2
                    return UnitType.UT_Undefined;
                case -1018361: // BuiltInParameter.PATH_REIN_SHAPE_1
                    return UnitType.UT_Undefined;
                case -1018354: // BuiltInParameter.PATH_REIN_SUMMARY
                    return UnitType.UT_Undefined;
                case -1018306: // BuiltInParameter.PATH_REIN_TYPE_2
                    return UnitType.UT_Undefined;
                case -1018305: // BuiltInParameter.PATH_REIN_TYPE_1
                    return UnitType.UT_Undefined;
                case -1018304: // BuiltInParameter.PATH_REIN_ALTERNATING
                    return UnitType.UT_Undefined;
                case -1018303: // BuiltInParameter.PATH_REIN_NUMBER_OF_BARS
                    return UnitType.UT_Undefined;
                case -1018300: // BuiltInParameter.PATH_REIN_FACE_SLAB
                    return UnitType.UT_Undefined;
                case -1018274: // BuiltInParameter.REBAR_BAR_DEFORMATION_TYPE
                    return UnitType.UT_Undefined;
                case -1018269: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_2_GENERIC
                    return UnitType.UT_Undefined;
                case -1018268: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_1_GENERIC
                    return UnitType.UT_Undefined;
                case -1018267: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_2_GENERIC
                    return UnitType.UT_Undefined;
                case -1018266: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_1_GENERIC
                    return UnitType.UT_Undefined;
                case -1018257: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_2_GENERIC
                    return UnitType.UT_Undefined;
                case -1018256: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_1_GENERIC
                    return UnitType.UT_Undefined;
                case -1018255: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_2_GENERIC
                    return UnitType.UT_Undefined;
                case -1018254: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_1_GENERIC
                    return UnitType.UT_Undefined;
                case -1018253: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_2_GENERIC
                    return UnitType.UT_Undefined;
                case -1018252: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_1_GENERIC
                    return UnitType.UT_Undefined;
                case -1018251: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_2_GENERIC
                    return UnitType.UT_Undefined;
                case -1018250: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_1_GENERIC
                    return UnitType.UT_Undefined;
                case -1018023: // BuiltInParameter.REBAR_SYSTEM_TOP_MINOR_MATCHES_BOTTOM_MINOR
                    return UnitType.UT_Undefined;
                case -1018022: // BuiltInParameter.REBAR_SYSTEM_TOP_MAJOR_MATCHES_BOTTOM_MAJOR
                    return UnitType.UT_Undefined;
                case -1018021: // BuiltInParameter.REBAR_SYSTEM_BOTTOM_MAJOR_MATCHES_BOTTOM_MINOR
                    return UnitType.UT_Undefined;
                case -1018020: // BuiltInParameter.REBAR_SYSTEM_TOP_MAJOR_MATCHES_TOP_MINOR
                    return UnitType.UT_Undefined;
                case -1018019: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_2_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018018: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_2_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018017: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_1_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018016: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_1_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018015: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_2_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018014: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_2_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018013: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_1_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018012: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_1_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018011: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_2_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018010: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_2_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018009: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_1_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018008: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_1_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018003: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_NO_SPACING
                    return UnitType.UT_Undefined;
                case -1018002: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_WITH_SPACING
                    return UnitType.UT_Undefined;
                case -1018001: // BuiltInParameter.REBAR_SYSTEM_LAYOUT_RULE
                    return UnitType.UT_Undefined;
                case -1017736: // BuiltInParameter.FABRIC_WIRE_TYPE
                    return UnitType.UT_Undefined;
                case -1017733: // BuiltInParameter.FABRIC_PARAM_SHARED_FAMILY_KEY
                    return UnitType.UT_Undefined;
                case -1017705: // BuiltInParameter.FABRIC_PARAM_LOCATION_GENERIC
                    return UnitType.UT_Undefined;
                case -1017701: // BuiltInParameter.FABRIC_PARAM_SHEET_TYPE
                    return UnitType.UT_Undefined;
                case -1017619: // BuiltInParameter.FABRIC_SHEET_MINOR_NUMBER_OF_WIRES
                    return UnitType.UT_Undefined;
                case -1017612: // BuiltInParameter.FABRIC_SHEET_MAJOR_NUMBER_OF_WIRES
                    return UnitType.UT_Undefined;
                case -1017604: // BuiltInParameter.FABRIC_SHEET_MINOR_DIRECTION_WIRE_TYPE
                    return UnitType.UT_Undefined;
                case -1017603: // BuiltInParameter.FABRIC_SHEET_MAJOR_DIRECTION_WIRE_TYPE
                    return UnitType.UT_Undefined;
                case -1017602: // BuiltInParameter.FABRIC_SHEET_PHYSICAL_MATERIAL_ASSET
                    return UnitType.UT_Undefined;
                case -1017065: // BuiltInParameter.REBAR_QUANITY_BY_DISTRIB
                    return UnitType.UT_Undefined;
                case -1017062: // BuiltInParameter.REBAR_MAXIM_SUFFIX
                    return UnitType.UT_Undefined;
                case -1017061: // BuiltInParameter.REBAR_MINIM_SUFFIX
                    return UnitType.UT_Undefined;
                case -1017060: // BuiltInParameter.REBAR_NUMBER_SUFFIX
                    return UnitType.UT_Undefined;
                case -1017055: // BuiltInParameter.REBAR_HOST_CATEGORY
                    return UnitType.UT_Undefined;
                case -1017047: // BuiltInParameter.REBAR_INSTANCE_STIRRUP_TIE_ATTACHMENT
                    return UnitType.UT_Undefined;
                case -1017032: // BuiltInParameter.REBAR_ELEM_SCHEDULE_MARK
                    return UnitType.UT_Undefined;
                case -1017026: // BuiltInParameter.REBAR_ELEM_HOOK_STYLE
                    return UnitType.UT_Undefined;
                case -1017015: // BuiltInParameter.REBAR_SHAPE
                    return UnitType.UT_Undefined;
                case -1017012: // BuiltInParameter.REBAR_ELEM_QUANTITY_OF_BARS
                    return UnitType.UT_Undefined;
                case -1017008: // BuiltInParameter.REBAR_ELEM_HOOK_END_TYPE
                    return UnitType.UT_Undefined;
                case -1017006: // BuiltInParameter.REBAR_ELEM_HOOK_START_TYPE
                    return UnitType.UT_Undefined;
                case -1015084: // BuiltInParameter.LOAD_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1015083: // BuiltInParameter.LOAD_COMMENTS
                    return UnitType.UT_Undefined;
                case -1015082: // BuiltInParameter.LOAD_CASE_NATURE_TEXT
                    return UnitType.UT_Undefined;
                case -1015005: // BuiltInParameter.LOAD_IS_REACTION
                    return UnitType.UT_Undefined;
                case -1015003: // BuiltInParameter.LOAD_IS_UNIFORM
                    return UnitType.UT_Undefined;
                case -1015001: // BuiltInParameter.LOAD_USE_LOCAL_COORDINATE_SYSTEM
                    return UnitType.UT_Undefined;
                case -1015000: // BuiltInParameter.LOAD_CASE_ID
                    return UnitType.UT_Undefined;
                case -1013451: // BuiltInParameter.ANALYTICAL_GEOMETRY_IS_VALID
                    return UnitType.UT_Undefined;
                case -1013450: // BuiltInParameter.STRUCTURAL_ASSET_PARAM
                    return UnitType.UT_Undefined;
                case -1013446: // BuiltInParameter.ANALYTICAL_MODEL_NODES_MARK
                    return UnitType.UT_Undefined;
                case -1013445: // BuiltInParameter.ANALYTICAL_MODEL_FOUNDATIONS_MARK
                    return UnitType.UT_Undefined;
                case -1013444: // BuiltInParameter.ANALYTICAL_MODEL_SURFACE_ELEMENTS_MARK
                    return UnitType.UT_Undefined;
                case -1013443: // BuiltInParameter.ANALYTICAL_MODEL_STICK_ELEMENTS_MARK
                    return UnitType.UT_Undefined;
                case -1013419: // BuiltInParameter.JOIST_SYSTEM_NEW_BEAM_TYPE_NO_FAM_NAME_PARAM
                    return UnitType.UT_Undefined;
                case -1013411: // BuiltInParameter.JOIST_SYSTEM_NEW_BEAM_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1013410: // BuiltInParameter.JOIST_SYSTEM_LAYOUT_RULE_PARAM
                    return UnitType.UT_Undefined;
                case -1012837: // BuiltInParameter.SLAB_EDGE_PROFILE_PARAM
                    return UnitType.UT_Undefined;
                case -1012836: // BuiltInParameter.GUTTER_PROFILE_PARAM
                    return UnitType.UT_Undefined;
                case -1012819: // BuiltInParameter.FASCIA_PROFILE_PARAM
                    return UnitType.UT_Undefined;
                case -1012809: // BuiltInParameter.WALL_SWEEP_WALL_SUBCATEGORY_ID
                    return UnitType.UT_Undefined;
                case -1012800: // BuiltInParameter.WALL_SWEEP_PROFILE_PARAM
                    return UnitType.UT_Undefined;
                case -1012619: // BuiltInParameter.PROPERTY_SEGMENT_L_R
                    return UnitType.UT_Undefined;
                case -1012617: // BuiltInParameter.PROPERTY_SEGMENT_E_W
                    return UnitType.UT_Undefined;
                case -1012615: // BuiltInParameter.PROPERTY_SEGMENT_N_S
                    return UnitType.UT_Undefined;
                case -1012201: // BuiltInParameter.DATUM_VOLUME_OF_INTEREST
                    return UnitType.UT_Undefined;
                case -1012101: // BuiltInParameter.PHASE_DEMOLISHED
                    return UnitType.UT_Undefined;
                case -1012100: // BuiltInParameter.PHASE_CREATED
                    return UnitType.UT_Undefined;
                case -1012098: // BuiltInParameter.MASS_DATA_SLAB
                    return UnitType.UT_Undefined;
                case -1012045: // BuiltInParameter.MASS_DATA_SURFACE_DATA_SOURCE
                    return UnitType.UT_Undefined;
                case -1012040: // BuiltInParameter.MASS_DATA_GLAZING_IS_SHADED
                    return UnitType.UT_Undefined;
                case -1012038: // BuiltInParameter.MASS_DATA_UNDERGROUND
                    return UnitType.UT_Undefined;
                case -1012031: // BuiltInParameter.MASS_DATA_SUBCATEGORY
                    return UnitType.UT_Undefined;
                case -1012030: // BuiltInParameter.MASS_DATA_CONCEPTUAL_CONSTRUCTION
                    return UnitType.UT_Undefined;
                case -1012027: // BuiltInParameter.MASS_ZONE_CONDITION_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1012026: // BuiltInParameter.MASS_ZONE_SPACE_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1012023: // BuiltInParameter.MASS_SURFACEDATA_MATERIAL
                    return UnitType.UT_Undefined;
                case -1012022: // BuiltInParameter.MASS_ZONE_MATERIAL
                    return UnitType.UT_Undefined;
                case -1012020: // BuiltInParameter.LEVEL_DATA_MASS_TYPE_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1012019: // BuiltInParameter.LEVEL_DATA_MASS_INSTANCE_COMMENTS
                    return UnitType.UT_Undefined;
                case -1012018: // BuiltInParameter.LEVEL_DATA_MASS_TYPE_COMMENTS
                    return UnitType.UT_Undefined;
                case -1012017: // BuiltInParameter.LEVEL_DATA_MASS_FAMILY_AND_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1012016: // BuiltInParameter.LEVEL_DATA_MASS_FAMILY_PARAM
                    return UnitType.UT_Undefined;
                case -1012015: // BuiltInParameter.LEVEL_DATA_SPACE_USAGE
                    return UnitType.UT_Undefined;
                case -1012014: // BuiltInParameter.LEVEL_DATA_OWNING_LEVEL
                    return UnitType.UT_Undefined;
                case -1012013: // BuiltInParameter.LEVEL_DATA_MASS_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1010707: // BuiltInParameter.PLUMBING_FIXTURES_VENT_CONNECTION
                    return UnitType.UT_Undefined;
                case -1010706: // BuiltInParameter.PLUMBING_FIXTURES_WASTE_CONNECTION
                    return UnitType.UT_Undefined;
                case -1010705: // BuiltInParameter.PLUMBING_FIXTURES_CW_CONNECTION
                    return UnitType.UT_Undefined;
                case -1010704: // BuiltInParameter.PLUMBING_FIXTURES_HW_CONNECTION
                    return UnitType.UT_Undefined;
                case -1010703: // BuiltInParameter.PLUMBING_FIXTURES_TRAP
                    return UnitType.UT_Undefined;
                case -1010702: // BuiltInParameter.PLUMBING_FIXTURES_DRAIN
                    return UnitType.UT_Undefined;
                case -1010701: // BuiltInParameter.PLUMBING_FIXTURES_SUPPLY_PIPE
                    return UnitType.UT_Undefined;
                case -1010700: // BuiltInParameter.PLUMBING_FIXTURES_SUPPLY_FITTING
                    return UnitType.UT_Undefined;
                case -1010501: // BuiltInParameter.LIGHTING_FIXTURE_LAMP
                    return UnitType.UT_Undefined;
                case -1010500: // BuiltInParameter.LIGHTING_FIXTURE_WATTAGE
                    return UnitType.UT_Undefined;
                case -1010401: // BuiltInParameter.ELECTICAL_EQUIP_VOLTAGE
                    return UnitType.UT_Undefined;
                case -1010400: // BuiltInParameter.ELECTICAL_EQUIP_WATTAGE
                    return UnitType.UT_Undefined;
                case -1010109: // BuiltInParameter.ALL_MODEL_MODEL
                    return UnitType.UT_Undefined;
                case -1010108: // BuiltInParameter.ALL_MODEL_MANUFACTURER
                    return UnitType.UT_Undefined;
                case -1010106: // BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS
                    return UnitType.UT_Undefined;
                case -1010105: // BuiltInParameter.ALL_MODEL_TYPE_COMMENTS
                    return UnitType.UT_Undefined;
                case -1010104: // BuiltInParameter.ALL_MODEL_URL
                    return UnitType.UT_Undefined;
                case -1010103: // BuiltInParameter.ALL_MODEL_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1009530: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_Z
                    return UnitType.UT_Undefined;
                case -1009529: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_Y
                    return UnitType.UT_Undefined;
                case -1009528: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_X
                    return UnitType.UT_Undefined;
                case -1009527: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_Z
                    return UnitType.UT_Undefined;
                case -1009526: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_Y
                    return UnitType.UT_Undefined;
                case -1009525: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_X
                    return UnitType.UT_Undefined;
                case -1009524: // BuiltInParameter.ANALYTICAL_MODEL_PHYSICAL_TYPE
                    return UnitType.UT_Undefined;
                case -1008620: // BuiltInParameter.STAIRS_RAILING_BASE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1008000: // BuiltInParameter.DATUM_TEXT
                    return UnitType.UT_Undefined;
                case -1007721: // BuiltInParameter.RVT_LINK_INSTANCE_NAME
                    return UnitType.UT_Undefined;
                case -1007246: // BuiltInParameter.STAIRS_ACTUAL_NUM_RISERS
                    return UnitType.UT_Undefined;
                case -1007235: // BuiltInParameter.STAIRS_MULTISTORY_TOP_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1007201: // BuiltInParameter.STAIRS_TOP_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1007200: // BuiltInParameter.STAIRS_BASE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1007112: // BuiltInParameter.LEVEL_IS_STRUCTURAL
                    return UnitType.UT_Undefined;
                case -1007111: // BuiltInParameter.LEVEL_IS_BUILDING_STORY
                    return UnitType.UT_Undefined;
                case -1007110: // BuiltInParameter.LEVEL_UP_TO_LEVEL
                    return UnitType.UT_Undefined;
                case -1007109: // BuiltInParameter.LEVEL_RELATIVE_BASE_TYPE
                    return UnitType.UT_Undefined;
                case -1006922: // BuiltInParameter.ROOM_UPPER_LEVEL
                    return UnitType.UT_Undefined;
                case -1006916: // BuiltInParameter.ROOM_LEVEL_ID
                    return UnitType.UT_Undefined;
                case -1006909: // BuiltInParameter.ROOM_OCCUPANCY
                    return UnitType.UT_Undefined;
                case -1006907: // BuiltInParameter.ROOM_DEPARTMENT
                    return UnitType.UT_Undefined;
                case -1006906: // BuiltInParameter.ROOM_FINISH_BASE
                    return UnitType.UT_Undefined;
                case -1006905: // BuiltInParameter.ROOM_FINISH_CEILING
                    return UnitType.UT_Undefined;
                case -1006904: // BuiltInParameter.ROOM_FINISH_WALL
                    return UnitType.UT_Undefined;
                case -1006903: // BuiltInParameter.ROOM_FINISH_FLOOR
                    return UnitType.UT_Undefined;
                case -1006901: // BuiltInParameter.ROOM_NUMBER
                    return UnitType.UT_Undefined;
                case -1006900: // BuiltInParameter.ROOM_NAME
                    return UnitType.UT_Undefined;
                case -1006321: // BuiltInParameter.PROJECT_ISSUE_DATE
                    return UnitType.UT_Undefined;
                case -1006320: // BuiltInParameter.PROJECT_STATUS
                    return UnitType.UT_Undefined;
                case -1006319: // BuiltInParameter.CLIENT_NAME
                    return UnitType.UT_Undefined;
                case -1006317: // BuiltInParameter.PROJECT_NAME
                    return UnitType.UT_Undefined;
                case -1006316: // BuiltInParameter.PROJECT_NUMBER
                    return UnitType.UT_Undefined;
                case -1006210: // BuiltInParameter.BUILDING_CURVE_GSTYLE
                    return UnitType.UT_Undefined;
                case -1005554: // BuiltInParameter.STRUCTURAL_SECTION_NAME_KEY
                    return UnitType.UT_Undefined;
                case -1005501: // BuiltInParameter.STRUCTURAL_SECTION_SHAPE
                    return UnitType.UT_Undefined;
                case -1005500: // BuiltInParameter.STRUCTURAL_MATERIAL_PARAM
                    return UnitType.UT_Undefined;
                case -1005436: // BuiltInParameter.ANALYTICAL_ROUGHNESS
                    return UnitType.UT_Undefined;
                case -1004011: // BuiltInParameter.CURVE_IS_DETAIL
                    return UnitType.UT_Undefined;
                case -1002563: // BuiltInParameter.COLUMN_LOCATION_MARK
                    return UnitType.UT_Undefined;
                case -1002503: // BuiltInParameter.OMNICLASS_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1002502: // BuiltInParameter.OMNICLASS_CODE
                    return UnitType.UT_Undefined;
                case -1002501: // BuiltInParameter.UNIFORMAT_DESCRIPTION
                    return UnitType.UT_Undefined;
                case -1002500: // BuiltInParameter.UNIFORMAT_CODE
                    return UnitType.UT_Undefined;
                case -1002107: // BuiltInParameter.MATERIAL_ID_PARAM
                    return UnitType.UT_Undefined;
                case -1002064: // BuiltInParameter.SCHEDULE_TOP_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1002063: // BuiltInParameter.SCHEDULE_BASE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1002062: // BuiltInParameter.SCHEDULE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1002052: // BuiltInParameter.ELEM_FAMILY_AND_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1002051: // BuiltInParameter.ELEM_FAMILY_PARAM
                    return UnitType.UT_Undefined;
                case -1002050: // BuiltInParameter.ELEM_TYPE_PARAM
                    return UnitType.UT_Undefined;
                case -1001954: // BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL
                    return UnitType.UT_Undefined;
                case -1001708: // BuiltInParameter.ROOF_BASE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1001597: // BuiltInParameter.NODE_CONNECTION_STATUS
                    return UnitType.UT_Undefined;
                case -1001577: // BuiltInParameter.STRUCTURAL_FLOOR_ANALYZES_AS
                    return UnitType.UT_Undefined;
                case -1001576: // BuiltInParameter.STRUCTURAL_ANALYZES_AS
                    return UnitType.UT_Undefined;
                case -1001563: // BuiltInParameter.CONTINUOUS_FOOTING_STRUCTURAL_USAGE
                    return UnitType.UT_Undefined;
                case -1001549: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MZ
                    return UnitType.UT_Undefined;
                case -1001548: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MY
                    return UnitType.UT_Undefined;
                case -1001547: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MX
                    return UnitType.UT_Undefined;
                case -1001546: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FZ
                    return UnitType.UT_Undefined;
                case -1001545: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FY
                    return UnitType.UT_Undefined;
                case -1001544: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FX
                    return UnitType.UT_Undefined;
                case -1001543: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_MZ
                    return UnitType.UT_Undefined;
                case -1001542: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_MY
                    return UnitType.UT_Undefined;
                case -1001541: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_MX
                    return UnitType.UT_Undefined;
                case -1001540: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_FZ
                    return UnitType.UT_Undefined;
                case -1001539: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_FY
                    return UnitType.UT_Undefined;
                case -1001538: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_FX
                    return UnitType.UT_Undefined;
                case -1001537: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_TYPE
                    return UnitType.UT_Undefined;
                case -1001536: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_TYPE
                    return UnitType.UT_Undefined;
                case -1001530: // BuiltInParameter.STRUCTURAL_CAMBER
                    return UnitType.UT_Undefined;
                case -1001529: // BuiltInParameter.STRUCTURAL_NUMBER_OF_STUDS
                    return UnitType.UT_Undefined;
                case -1001528: // BuiltInParameter.STRUCTURAL_END_RELEASE_MZ
                    return UnitType.UT_Undefined;
                case -1001527: // BuiltInParameter.STRUCTURAL_END_RELEASE_MY
                    return UnitType.UT_Undefined;
                case -1001526: // BuiltInParameter.STRUCTURAL_END_RELEASE_MX
                    return UnitType.UT_Undefined;
                case -1001525: // BuiltInParameter.STRUCTURAL_END_RELEASE_FZ
                    return UnitType.UT_Undefined;
                case -1001524: // BuiltInParameter.STRUCTURAL_END_RELEASE_FY
                    return UnitType.UT_Undefined;
                case -1001523: // BuiltInParameter.STRUCTURAL_END_RELEASE_FX
                    return UnitType.UT_Undefined;
                case -1001522: // BuiltInParameter.STRUCTURAL_START_RELEASE_MZ
                    return UnitType.UT_Undefined;
                case -1001521: // BuiltInParameter.STRUCTURAL_START_RELEASE_MY
                    return UnitType.UT_Undefined;
                case -1001520: // BuiltInParameter.STRUCTURAL_START_RELEASE_MX
                    return UnitType.UT_Undefined;
                case -1001519: // BuiltInParameter.STRUCTURAL_START_RELEASE_FZ
                    return UnitType.UT_Undefined;
                case -1001518: // BuiltInParameter.STRUCTURAL_START_RELEASE_FY
                    return UnitType.UT_Undefined;
                case -1001517: // BuiltInParameter.STRUCTURAL_START_RELEASE_FX
                    return UnitType.UT_Undefined;
                case -1001516: // BuiltInParameter.STRUCTURAL_END_RELEASE_TYPE
                    return UnitType.UT_Undefined;
                case -1001515: // BuiltInParameter.STRUCTURAL_START_RELEASE_TYPE
                    return UnitType.UT_Undefined;
                case -1001405: // BuiltInParameter.WINDOW_TYPE_ID, BuiltInParameter.WINDOW_TYPE_ID
                    return UnitType.UT_Undefined;
                case -1001383: // BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM
                    return UnitType.UT_Undefined;
                case -1001381: // BuiltInParameter.INSTANCE_STRUCT_USAGE_PARAM
                    return UnitType.UT_Undefined;
                case -1001211: // BuiltInParameter.WINDOW_OPERATION_TYPE, BuiltInParameter.WINDOW_OPERATION_TYPE
                    return UnitType.UT_Undefined;
                case -1001210: // BuiltInParameter.DOOR_FRAME_MATERIAL
                    return UnitType.UT_Undefined;
                case -1001209: // BuiltInParameter.DOOR_FRAME_TYPE
                    return UnitType.UT_Undefined;
                case -1001208: // BuiltInParameter.GENERIC_FINISH, BuiltInParameter.GENERIC_FINISH, BuiltInParameter.GENERIC_FINISH, BuiltInParameter.GENERIC_FINISH
                    return UnitType.UT_Undefined;
                case -1001207: // BuiltInParameter.WINDOW_CONSTRUCTION_TYPE, BuiltInParameter.WINDOW_CONSTRUCTION_TYPE, BuiltInParameter.WINDOW_CONSTRUCTION_TYPE, BuiltInParameter.WINDOW_CONSTRUCTION_TYPE, BuiltInParameter.WINDOW_CONSTRUCTION_TYPE
                    return UnitType.UT_Undefined;
                case -1001206: // BuiltInParameter.FIRE_RATING, BuiltInParameter.FIRE_RATING
                    return UnitType.UT_Undefined;
                case -1001203: // BuiltInParameter.DOOR_NUMBER, BuiltInParameter.DOOR_NUMBER
                    return UnitType.UT_Undefined;
                case -1001139: // BuiltInParameter.DPART_LAYER_CONSTRUCTION
                    return UnitType.UT_Undefined;
                case -1001132: // BuiltInParameter.DPART_ORIGINAL_TYPE
                    return UnitType.UT_Undefined;
                case -1001127: // BuiltInParameter.DPART_MATERIAL_ID_PARAM
                    return UnitType.UT_Undefined;
                case -1001126: // BuiltInParameter.DPART_ORIGINAL_FAMILY
                    return UnitType.UT_Undefined;
                case -1001125: // BuiltInParameter.DPART_ORIGINAL_CATEGORY
                    return UnitType.UT_Undefined;
                case -1001119: // BuiltInParameter.WALL_STRUCTURAL_USAGE_PARAM
                    return UnitType.UT_Undefined;
                case -1001107: // BuiltInParameter.WALL_BASE_CONSTRAINT
                    return UnitType.UT_Undefined;
                case -1001103: // BuiltInParameter.WALL_HEIGHT_TYPE
                    return UnitType.UT_Undefined;
                case -1001007: // BuiltInParameter.WALL_ATTR_ROOM_BOUNDING
                    return UnitType.UT_Undefined;
                case -1001006: // BuiltInParameter.FUNCTION_PARAM
                    return UnitType.UT_Undefined;
                case -1155148: // BuiltInParameter.STEEL_ELEM_PROFILE_VOLUME
                    return UnitType.UT_Volume;
                case -1155147: // BuiltInParameter.STEEL_ELEM_PROFILE_LENGTH
                    return UnitType.UT_Length;
                case -1155144: // BuiltInParameter.STEEL_ELEM_PLATE_JUSTIFICATION
                    return UnitType.UT_Number;
                case -1155143: // BuiltInParameter.STEEL_ELEM_PLATE_PAINT_AREA
                    return UnitType.UT_Area;
                case -1155142: // BuiltInParameter.STEEL_ELEM_PLATE_EXACT_WEIGHT
                    return UnitType.UT_Mass;
                case -1155141: // BuiltInParameter.STEEL_ELEM_PLATE_WEIGHT
                    return UnitType.UT_Mass;
                case -1155140: // BuiltInParameter.STEEL_ELEM_PLATE_VOLUME
                    return UnitType.UT_Volume;
                case -1155139: // BuiltInParameter.STEEL_ELEM_PLATE_AREA
                    return UnitType.UT_Area;
                case -1155138: // BuiltInParameter.STEEL_ELEM_PLATE_WIDTH
                    return UnitType.UT_Length;
                case -1155137: // BuiltInParameter.STEEL_ELEM_PLATE_LENGTH
                    return UnitType.UT_Length;
                case -1155135: // BuiltInParameter.STEEL_ELEM_BOLT_TOTAL_WEIGHT
                    return UnitType.UT_Mass;
                case -1155134: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_TOTAL_WEIGHT
                    return UnitType.UT_Mass;
                case -1155132: // BuiltInParameter.STEEL_ELEM_ANCHOR_TOTAL_WEIGHT
                    return UnitType.UT_Mass;
                case -1155128: // BuiltInParameter.STEEL_ELEM_CUT_LENGTH
                    return UnitType.UT_Length;
                case -1155127: // BuiltInParameter.STEEL_ELEM_EXACT_WEIGHT
                    return UnitType.UT_Mass;
                case -1155125: // BuiltInParameter.STEEL_ELEM_PAINT_AREA
                    return UnitType.UT_Area;
                case -1155124: // BuiltInParameter.STEEL_ELEM_WEIGHT
                    return UnitType.UT_Mass;
                case -1155123: // BuiltInParameter.PATH_OF_TRAVEL_SPEED
                    return UnitType.UT_Speed;
                case -1155119: // BuiltInParameter.STEEL_ELEM_BOLT_GRIP_LENGTH_INCREASE
                    return UnitType.UT_Length;
                case -1155118: // BuiltInParameter.STEEL_ELEM_BOLT_GRIP_LENGTH
                    return UnitType.UT_Length;
                case -1155117: // BuiltInParameter.STEEL_ELEM_BOLT_LENGTH
                    return UnitType.UT_Length;
                case -1155115: // BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION
                    return UnitType.UT_Length;
                case -1155114: // BuiltInParameter.RBS_PIPE_TOP_ELEVATION
                    return UnitType.UT_Length;
                case -1155113: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEC
                    return UnitType.UT_Electrical_Current;
                case -1155112: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEB
                    return UnitType.UT_Electrical_Current;
                case -1155111: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEA
                    return UnitType.UT_Electrical_Current;
                case -1155110: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEC
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1155109: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEB
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1155108: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEA
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1155107: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEC
                    return UnitType.UT_Electrical_Current;
                case -1155106: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEB
                    return UnitType.UT_Electrical_Current;
                case -1155105: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEA
                    return UnitType.UT_Electrical_Current;
                case -1155104: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEC
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1155103: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEB
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1155102: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEA
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1155090: // BuiltInParameter.PATH_OF_TRAVEL_TIME
                    return UnitType.UT_TimeInterval;
                case -1155059: // BuiltInParameter.STEEL_ELEM_PATTERN_RADIUS
                    return UnitType.UT_Length;
                case -1155058: // BuiltInParameter.STEEL_ELEM_PATTERN_EDGE_DISTANCE_Y
                    return UnitType.UT_Length;
                case -1155057: // BuiltInParameter.STEEL_ELEM_PATTERN_EDGE_DISTANCE_X
                    return UnitType.UT_Length;
                case -1155056: // BuiltInParameter.STEEL_ELEM_PATTERN_INTERMEDIATE_DISTANCE_Y
                    return UnitType.UT_Length;
                case -1155055: // BuiltInParameter.STEEL_ELEM_PATTERN_INTERMEDIATE_DISTANCE_X
                    return UnitType.UT_Length;
                case -1155054: // BuiltInParameter.STEEL_ELEM_PATTERN_TOTAL_WIDTH
                    return UnitType.UT_Length;
                case -1155053: // BuiltInParameter.STEEL_ELEM_PATTERN_TOTAL_LENGTH
                    return UnitType.UT_Length;
                case -1155050: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_PREPDEPTH
                    return UnitType.UT_Length;
                case -1155049: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_EFFECTIVETHROAT
                    return UnitType.UT_Length;
                case -1155048: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_ROOTOPENING
                    return UnitType.UT_Length;
                case -1155044: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_THICKNESS
                    return UnitType.UT_Length;
                case -1155042: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_PREPDEPTH
                    return UnitType.UT_Length;
                case -1155041: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_EFFECTIVETHROAT
                    return UnitType.UT_Length;
                case -1155040: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_ROOTOPENING
                    return UnitType.UT_Length;
                case -1155036: // BuiltInParameter.STEEL_ELEM_WELD_PITCH
                    return UnitType.UT_Length;
                case -1155033: // BuiltInParameter.STEEL_ELEM_WELD_LENGTH
                    return UnitType.UT_Length;
                case -1155032: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_THICKNESS
                    return UnitType.UT_Length;
                case -1155019: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_LENGTH
                    return UnitType.UT_Length;
                case -1155003: // BuiltInParameter.STEEL_ELEM_PLATE_THICKNESS
                    return UnitType.UT_Length;
                case -1154689: // BuiltInParameter.ROOM_OUTDOOR_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1154671: // BuiltInParameter.ROOM_AIR_CHANGES_PER_HOUR_PARAM
                    return UnitType.UT_Number;
                case -1154668: // BuiltInParameter.ROOM_OUTDOOR_AIR_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1154665: // BuiltInParameter.ROOM_OUTDOOR_AIR_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1154651: // BuiltInParameter.COUPLER_WIDTH
                    return UnitType.UT_Length;
                case -1154646: // BuiltInParameter.COUPLER_COUPLED_ENGAGEMENT
                    return UnitType.UT_Length;
                case -1154645: // BuiltInParameter.COUPLER_MAIN_ENGAGEMENT
                    return UnitType.UT_Length;
                case -1154644: // BuiltInParameter.COUPLER_LENGTH
                    return UnitType.UT_Length;
                case -1154643: // BuiltInParameter.COUPLER_WEIGHT
                    return UnitType.UT_Mass;
                case -1153104: // BuiltInParameter.MEP_EQUIPMENT_CALC_PIPINGPRESSUREDROP_PARAM
                    return UnitType.UT_Piping_Pressure;
                case -1153103: // BuiltInParameter.MEP_EQUIPMENT_CALC_PIPINGFLOW_PARAM
                    return UnitType.UT_Piping_Flow;
                case -1152373: // BuiltInParameter.END_Z_OFFSET_VALUE
                    return UnitType.UT_Length;
                case -1152371: // BuiltInParameter.END_Y_OFFSET_VALUE
                    return UnitType.UT_Length;
                case -1152369: // BuiltInParameter.START_Z_OFFSET_VALUE
                    return UnitType.UT_Length;
                case -1152367: // BuiltInParameter.START_Y_OFFSET_VALUE
                    return UnitType.UT_Length;
                case -1152365: // BuiltInParameter.Z_OFFSET_VALUE
                    return UnitType.UT_Length;
                case -1152363: // BuiltInParameter.Y_OFFSET_VALUE
                    return UnitType.UT_Length;
                case -1152360: // BuiltInParameter.END_JOIN_CUTBACK
                    return UnitType.UT_Length;
                case -1152359: // BuiltInParameter.START_JOIN_CUTBACK
                    return UnitType.UT_Length;
                case -1152358: // BuiltInParameter.END_EXTENSION
                    return UnitType.UT_Length;
                case -1152357: // BuiltInParameter.START_EXTENSION
                    return UnitType.UT_Length;
                case -1152313: // BuiltInParameter.PHY_MATERIAL_PARAM_STRUCTURAL_DENSITY
                    return UnitType.UT_MassDensity;
                case -1152300: // BuiltInParameter.STAIRS_RAILING_PLACEMENT_OFFSET
                    return UnitType.UT_Length;
                case -1152166: // BuiltInParameter.SUPPORT_HEIGHT
                    return UnitType.UT_Length;
                case -1152165: // BuiltInParameter.SUPPORT_HAND_CLEARANCE
                    return UnitType.UT_Length;
                case -1151810: // BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH_ON_LANDING
                    return UnitType.UT_Length;
                case -1151809: // BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH_ON_RUN
                    return UnitType.UT_Length;
                case -1151807: // BuiltInParameter.STAIRS_SUPPORTTYPE_WIDTH
                    return UnitType.UT_Length;
                case -1151806: // BuiltInParameter.STAIRS_SUPPORTTYPE_TOTAL_DEPTH
                    return UnitType.UT_Length;
                case -1151603: // BuiltInParameter.STAIRS_LANDINGTYPE_THICKNESS
                    return UnitType.UT_Length;
                case -1151404: // BuiltInParameter.STAIRS_RUNTYPE_STRUCTURAL_DEPTH
                    return UnitType.UT_Length;
                case -1151309: // BuiltInParameter.STAIRS_RUN_ACTUAL_RUN_WIDTH
                    return UnitType.UT_Length;
                case -1151308: // BuiltInParameter.STAIRS_RUN_ACTUAL_TREAD_DEPTH
                    return UnitType.UT_Length;
                case -1151307: // BuiltInParameter.STAIRS_RUN_ACTUAL_RISER_HEIGHT
                    return UnitType.UT_Length;
                case -1151303: // BuiltInParameter.STAIRS_RUN_HEIGHT
                    return UnitType.UT_Length;
                case -1150501: // BuiltInParameter.ANALYTICAL_MODEL_ROTATION
                    return UnitType.UT_Angle;
                case -1150463: // BuiltInParameter.ANALYTICAL_MODEL_PERIMETER
                    return UnitType.UT_Length;
                case -1150462: // BuiltInParameter.ANALYTICAL_MODEL_AREA
                    return UnitType.UT_Area;
                case -1150461: // BuiltInParameter.ANALYTICAL_MODEL_LENGTH
                    return UnitType.UT_Length;
                case -1150433: // BuiltInParameter.RBS_REFERENCE_LINING_THICKNESS
                    return UnitType.UT_HVAC_DuctLiningThickness;
                case -1150431: // BuiltInParameter.RBS_REFERENCE_INSULATION_THICKNESS
                    return UnitType.UT_HVAC_DuctInsulationThickness;
                case -1150425: // BuiltInParameter.RBS_INSULATION_LINING_VOLUME
                    return UnitType.UT_Volume;
                case -1150188: // BuiltInParameter.ROOM_PLENUM_LIGHTING_PARAM
                    return UnitType.UT_HVAC_Factor;
                case -1150115: // BuiltInParameter.FBX_LIGHT_LUMENAIRE_DIRT
                    return UnitType.UT_Number;
                case -1150114: // BuiltInParameter.FBX_LIGHT_LAMP_LUMEN_DEPR
                    return UnitType.UT_Number;
                case -1150113: // BuiltInParameter.FBX_LIGHT_SURFACE_LOSS
                    return UnitType.UT_Number;
                case -1150112: // BuiltInParameter.FBX_LIGHT_LAMP_TILT_LOSS
                    return UnitType.UT_Number;
                case -1150110: // BuiltInParameter.FBX_LIGHT_VOLTAGE_LOSS
                    return UnitType.UT_Number;
                case -1150109: // BuiltInParameter.FBX_LIGHT_TEMPERATURE_LOSS
                    return UnitType.UT_Number;
                case -1150107: // BuiltInParameter.FBX_LIGHT_INITIAL_COLOR_TEMPERATURE
                    return UnitType.UT_Color_Temperature;
                case -1150106: // BuiltInParameter.FBX_LIGHT_ILLUMINANCE
                    return UnitType.UT_Electrical_Illuminance;
                case -1150105: // BuiltInParameter.FBX_LIGHT_LIMUNOUS_INTENSITY
                    return UnitType.UT_Electrical_Luminous_Intensity;
                case -1150104: // BuiltInParameter.FBX_LIGHT_EFFICACY
                    return UnitType.UT_Electrical_Efficacy;
                case -1150103: // BuiltInParameter.FBX_LIGHT_WATTAGE
                    return UnitType.UT_Electrical_Wattage;
                case -1144331: // BuiltInParameter.RBS_ELEC_ROOM_LIGHTING_CALC_LUMINAIREPLANE
                    return UnitType.UT_Length;
                case -1140983: // BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL_AREA
                    return UnitType.UT_Area;
                case -1140981: // BuiltInParameter.FABRICATION_PART_SHEETMETAL_AREA
                    return UnitType.UT_Area;
                case -1140978: // BuiltInParameter.FABRICATION_PART_MATERIAL_THICKNESS
                    return UnitType.UT_Pipe_Dimension;
                case -1140976: // BuiltInParameter.FABRICATION_PART_LINING_AREA
                    return UnitType.UT_Area;
                case -1140974: // BuiltInParameter.FABRICATION_PART_INSULATION_AREA
                    return UnitType.UT_Area;
                case -1140972: // BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL_THICKNESS
                    return UnitType.UT_Pipe_Dimension;
                case -1140944: // BuiltInParameter.FABRICATION_PART_LENGTH
                    return UnitType.UT_Length;
                case -1140935: // BuiltInParameter.FABRICATION_PART_DEPTH_OUT
                    return UnitType.UT_Pipe_Dimension;
                case -1140934: // BuiltInParameter.FABRICATION_PART_WIDTH_OUT
                    return UnitType.UT_Pipe_Dimension;
                case -1140933: // BuiltInParameter.FABRICATION_PART_DIAMETER_OUT
                    return UnitType.UT_Pipe_Dimension;
                case -1140930: // BuiltInParameter.FABRICATION_PART_DEPTH_IN
                    return UnitType.UT_Pipe_Dimension;
                case -1140929: // BuiltInParameter.FABRICATION_PART_WIDTH_IN
                    return UnitType.UT_Pipe_Dimension;
                case -1140919: // BuiltInParameter.FABRICATION_BOTTOM_OF_PART
                    return UnitType.UT_Length;
                case -1140918: // BuiltInParameter.FABRICATION_TOP_OF_PART
                    return UnitType.UT_Length;
                case -1140913: // BuiltInParameter.FABRICATION_PART_WEIGHT
                    return UnitType.UT_PipeMass;
                case -1140912: // BuiltInParameter.FABRICATION_PART_DIAMETER_IN
                    return UnitType.UT_Pipe_Dimension;
                case -1140911: // BuiltInParameter.FABRICATION_PART_ANGLE
                    return UnitType.UT_Angle;
                case -1140415: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF
                    return UnitType.UT_ThermalExpansion;
                case -1140414: // BuiltInParameter.PHY_MATERIAL_PARAM_BENDING
                    return UnitType.UT_Stress;
                case -1140413: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD
                    return UnitType.UT_Stress;
                case -1140412: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD
                    return UnitType.UT_Number;
                case -1140410: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_PERPENDICULAR
                    return UnitType.UT_Stress;
                case -1140409: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_PARALLEL
                    return UnitType.UT_Stress;
                case -1140408: // BuiltInParameter.PHY_MATERIAL_PARAM_COMPRESSION_PERPENDICULAR
                    return UnitType.UT_Stress;
                case -1140407: // BuiltInParameter.PHY_MATERIAL_PARAM_COMPRESSION_PARALLEL
                    return UnitType.UT_Stress;
                case -1140401: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD
                    return UnitType.UT_Stress;
                case -1140321: // BuiltInParameter.PHY_MATERIAL_PARAM_RESISTANCE_CALC_STRENGTH
                    return UnitType.UT_Stress;
                case -1140320: // BuiltInParameter.PHY_MATERIAL_PARAM_REDUCTION_FACTOR
                    return UnitType.UT_Number;
                case -1140319: // BuiltInParameter.PHY_MATERIAL_PARAM_MINIMUM_TENSILE_STRENGTH
                    return UnitType.UT_Stress;
                case -1140318: // BuiltInParameter.PHY_MATERIAL_PARAM_MINIMUM_YIELD_STRESS
                    return UnitType.UT_Stress;
                case -1140317: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_STRENGTH_REDUCTION
                    return UnitType.UT_Number;
                case -1140316: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_REINFORCEMENT
                    return UnitType.UT_Stress;
                case -1140315: // BuiltInParameter.PHY_MATERIAL_PARAM_BENDING_REINFORCEMENT
                    return UnitType.UT_Stress;
                case -1140314: // BuiltInParameter.PHY_MATERIAL_PARAM_CONCRETE_COMPRESSION
                    return UnitType.UT_Stress;
                case -1140312: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF3
                    return UnitType.UT_ThermalExpansion;
                case -1140311: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF2
                    return UnitType.UT_ThermalExpansion;
                case -1140310: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF1
                    return UnitType.UT_ThermalExpansion;
                case -1140309: // BuiltInParameter.PHY_MATERIAL_PARAM_UNIT_WEIGHT
                    return UnitType.UT_UnitWeight;
                case -1140308: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD3
                    return UnitType.UT_Stress;
                case -1140307: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD2
                    return UnitType.UT_Stress;
                case -1140306: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD1
                    return UnitType.UT_Stress;
                case -1140305: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD3
                    return UnitType.UT_Number;
                case -1140304: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD2
                    return UnitType.UT_Number;
                case -1140303: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD1
                    return UnitType.UT_Number;
                case -1140302: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD3
                    return UnitType.UT_Stress;
                case -1140301: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD2
                    return UnitType.UT_Stress;
                case -1140300: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD1
                    return UnitType.UT_Stress;
                case -1140266: // BuiltInParameter.RBS_FP_SPRINKLER_ORIFICE_SIZE_PARAM
                    return UnitType.UT_PipeSize;
                case -1140265: // BuiltInParameter.RBS_FP_SPRINKLER_TEMPERATURE_RATING_PARAM
                    return UnitType.UT_Piping_Temperature;
                case -1140264: // BuiltInParameter.RBS_FP_SPRINKLER_K_FACTOR_PARAM
                    return UnitType.UT_Number;
                case -1140257: // BuiltInParameter.RBS_PIPE_SYSTEM_FIXTURE_UNIT_PARAM
                    return UnitType.UT_Number;
                case -1140253: // BuiltInParameter.RBS_PIPE_VOLUME_PARAM
                    return UnitType.UT_Piping_Volume;
                case -1140252: // BuiltInParameter.RBS_PIPE_WFU_PARAM
                    return UnitType.UT_Number;
                case -1140251: // BuiltInParameter.RBS_PIPE_HWFU_PARAM
                    return UnitType.UT_Number;
                case -1140250: // BuiltInParameter.RBS_PIPE_CWFU_PARAM
                    return UnitType.UT_Number;
                case -1140246: // BuiltInParameter.RBS_PIPE_FIXTURE_UNITS_PARAM
                    return UnitType.UT_Number;
                case -1140242: // BuiltInParameter.RBS_PIPE_STATIC_PRESSURE
                    return UnitType.UT_Piping_Pressure;
                case -1140240: // BuiltInParameter.RBS_DUCT_BOTTOM_ELEVATION
                    return UnitType.UT_Length;
                case -1140239: // BuiltInParameter.RBS_DUCT_TOP_ELEVATION
                    return UnitType.UT_Length;
                case -1140238: // BuiltInParameter.RBS_PIPE_OUTER_DIAMETER
                    return UnitType.UT_PipeSize;
                case -1140237: // BuiltInParameter.RBS_PIPE_INVERT_ELEVATION
                    return UnitType.UT_Length;
                case -1140226: // BuiltInParameter.RBS_PIPE_ADDITIONAL_FLOW_PARAM
                    return UnitType.UT_Piping_Flow;
                case -1140225: // BuiltInParameter.RBS_PIPE_DIAMETER_PARAM
                    return UnitType.UT_PipeSize;
                case -1140217: // BuiltInParameter.RBS_PIPE_FLUID_TEMPERATURE_PARAM
                    return UnitType.UT_Piping_Temperature;
                case -1140215: // BuiltInParameter.RBS_PIPE_FLUID_VISCOSITY_PARAM
                    return UnitType.UT_Piping_Viscosity;
                case -1140214: // BuiltInParameter.RBS_PIPE_FLUID_DENSITY_PARAM
                    return UnitType.UT_Piping_Density;
                case -1140213: // BuiltInParameter.RBS_PIPE_FLOW_PARAM
                    return UnitType.UT_Piping_Flow;
                case -1140212: // BuiltInParameter.RBS_PIPE_INNER_DIAM_PARAM
                    return UnitType.UT_PipeSize;
                case -1140211: // BuiltInParameter.RBS_PIPE_REYNOLDS_NUMBER_PARAM
                    return UnitType.UT_Number;
                case -1140210: // BuiltInParameter.RBS_PIPE_RELATIVE_ROUGHNESS_PARAM
                    return UnitType.UT_Number;
                case -1140208: // BuiltInParameter.RBS_PIPE_FRICTION_FACTOR_PARAM
                    return UnitType.UT_Number;
                case -1140207: // BuiltInParameter.RBS_PIPE_VELOCITY_PARAM
                    return UnitType.UT_Piping_Velocity;
                case -1140206: // BuiltInParameter.RBS_PIPE_FRICTION_PARAM
                    return UnitType.UT_Piping_Friction;
                case -1140205: // BuiltInParameter.RBS_PIPE_PRESSUREDROP_PARAM
                    return UnitType.UT_Piping_Pressure;
                case -1140204: // BuiltInParameter.RBS_PIPE_ROUGHNESS_PARAM
                    return UnitType.UT_Piping_Roughness;
                case -1140166: // BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEC_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140165: // BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEB_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140164: // BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEA_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140154: // BuiltInParameter.RBS_ELEC_CIRCUIT_FRAME_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140153: // BuiltInParameter.RBS_ELEC_PANEL_TOTAL_DEMAND_CURRENT_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140152: // BuiltInParameter.RBS_ELEC_PANEL_TOTAL_CONNECTED_CURRENT_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140151: // BuiltInParameter.RBS_ELEC_PANEL_TOTAL_DEMAND_FACTOR_PARAM
                    return UnitType.UT_Electrical_Demand_Factor;
                case -1140146: // BuiltInParameter.RBS_ELEC_PANEL_NEUTRAL_RATING_PARAM
                    return UnitType.UT_Electrical_Demand_Factor;
                case -1140140: // BuiltInParameter.RBS_ELEC_PANEL_MCB_RATING_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140137: // BuiltInParameter.RBS_CONDUITRUN_OUTER_DIAM_PARAM
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140136: // BuiltInParameter.RBS_CONDUITRUN_INNER_DIAM_PARAM
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140135: // BuiltInParameter.RBS_CONDUITRUN_DIAMETER_PARAM
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140134: // BuiltInParameter.RBS_CABLETRAYRUN_WIDTH_PARAM
                    return UnitType.UT_Electrical_CableTraySize;
                case -1140133: // BuiltInParameter.RBS_CABLETRAYRUN_HEIGHT_PARAM
                    return UnitType.UT_Electrical_CableTraySize;
                case -1140132: // BuiltInParameter.RBS_CABLETRAYCONDUITRUN_LENGTH_PARAM
                    return UnitType.UT_Length;
                case -1140127: // BuiltInParameter.RBS_CONDUIT_OUTER_DIAM_PARAM
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140126: // BuiltInParameter.RBS_CONDUIT_INNER_DIAM_PARAM
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140125: // BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION
                    return UnitType.UT_Length;
                case -1140124: // BuiltInParameter.RBS_CTC_TOP_ELEVATION
                    return UnitType.UT_Length;
                case -1140123: // BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140122: // BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM
                    return UnitType.UT_Electrical_CableTraySize;
                case -1140121: // BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM
                    return UnitType.UT_Electrical_CableTraySize;
                case -1140119: // BuiltInParameter.CABLETRAY_MINBENDMULTIPLIER_PARAM
                    return UnitType.UT_Number;
                case -1140116: // BuiltInParameter.RBS_CONDUIT_BENDRADIUS
                    return UnitType.UT_Electrical_ConduitSize;
                case -1140115: // BuiltInParameter.RBS_CABLETRAY_BENDRADIUS
                    return UnitType.UT_Electrical_CableTraySize;
                case -1140082: // BuiltInParameter.RBS_ELEC_MAINS
                    return UnitType.UT_Electrical_Current;
                case -1140069: // BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_PARAM
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1140068: // BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_PARAM
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1140055: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEC
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1140054: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEB
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1140053: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEA
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1140052: // BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEC
                    return UnitType.UT_Electrical_Power;
                case -1140051: // BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEB
                    return UnitType.UT_Electrical_Power;
                case -1140050: // BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEA
                    return UnitType.UT_Electrical_Power;
                case -1140049: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140048: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEA_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140047: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEB_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140046: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEC_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140045: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140044: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEA_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140043: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEB_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140042: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEC_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140041: // BuiltInParameter.RBS_ELEC_VOLTAGE_DROP_PARAM
                    return UnitType.UT_Electrical_Potential;
                case -1140039: // BuiltInParameter.RBS_ELEC_CIRCUIT_LENGTH_PARAM
                    return UnitType.UT_Length;
                case -1140038: // BuiltInParameter.RBS_ELEC_CIRCUIT_RATING_PARAM
                    return UnitType.UT_Electrical_Current;
                case -1140035: // BuiltInParameter.RBS_ELEC_ROOM_CAVITY_RATIO
                    return UnitType.UT_Number;
                case -1140033: // BuiltInParameter.RBS_ELEC_ROOM_AVERAGE_ILLUMINATION
                    return UnitType.UT_Electrical_Illuminance;
                case -1140032: // BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_FLOOR
                    return UnitType.UT_HVAC_Factor;
                case -1140031: // BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_WALLS
                    return UnitType.UT_HVAC_Factor;
                case -1140030: // BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_CEILING
                    return UnitType.UT_HVAC_Factor;
                case -1140029: // BuiltInParameter.RBS_ELEC_ROOM_LIGHTING_CALC_WORKPLANE
                    return UnitType.UT_Length;
                case -1140010: // BuiltInParameter.RBS_ELEC_TRUE_LOAD
                    return UnitType.UT_Electrical_Power;
                case -1140008: // BuiltInParameter.RBS_ELEC_POWER_FACTOR
                    return UnitType.UT_Number;
                case -1140004: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD
                    return UnitType.UT_Electrical_Apparent_Power;
                case -1140002: // BuiltInParameter.RBS_ELEC_VOLTAGE
                    return UnitType.UT_Electrical_Potential;
                case -1133501: // BuiltInParameter.GROUP_OFFSET_FROM_LEVEL
                    return UnitType.UT_Length;
                case -1114818: // BuiltInParameter.PEAK_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114815: // BuiltInParameter.SPACE_INFILTRATION_AIRFLOW_PER_AREA
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1114814: // BuiltInParameter.SPACE_OUTDOOR_AIRFLOW
                    return UnitType.UT_HVAC_Airflow;
                case -1114813: // BuiltInParameter.SPACE_OUTDOOR_AIRFLOW_PER_PERSON
                    return UnitType.UT_HVAC_Airflow;
                case -1114812: // BuiltInParameter.SPACE_OUTDOOR_AIRFLOW_PER_AREA
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1114811: // BuiltInParameter.SPACE_AIR_CHANGES_PER_HOUR
                    return UnitType.UT_Number;
                case -1114810: // BuiltInParameter.SPACE_POWER_LOAD_PARAM
                    return UnitType.UT_HVAC_Power;
                case -1114809: // BuiltInParameter.SPACE_LIGHTING_LOAD_PARAM
                    return UnitType.UT_HVAC_Power;
                case -1114808: // BuiltInParameter.SPACE_PEOPLE_LOAD_PARAM
                    return UnitType.UT_HVAC_Power;
                case -1114807: // BuiltInParameter.SPACE_POWER_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114806: // BuiltInParameter.SPACE_LIGHTING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114805: // BuiltInParameter.SPACE_PEOPLE_LATENT_HEAT_GAIN_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_HeatGain;
                case -1114804: // BuiltInParameter.SPACE_PEOPLE_SENSIBLE_HEAT_GAIN_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_HeatGain;
                case -1114803: // BuiltInParameter.SPACE_AREA_PER_PERSON_PARAM
                    return UnitType.UT_Area;
                case -1114802: // BuiltInParameter.SPACE_AIRFLOW_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1114801: // BuiltInParameter.PEAK_COOLING_LOAD_PARAM
                    return UnitType.UT_HVAC_Cooling_Load;
                case -1114800: // BuiltInParameter.PEAK_HEATING_LOAD_PARAM
                    return UnitType.UT_HVAC_Heating_Load;
                case -1114706: // BuiltInParameter.ZONE_LEVEL_OFFSET
                    return UnitType.UT_Length;
                case -1114360: // BuiltInParameter.RBS_LINING_THICKNESS_FOR_DUCT
                    return UnitType.UT_HVAC_DuctLiningThickness;
                case -1114359: // BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_PIPE
                    return UnitType.UT_PipeInsulationThickness;
                case -1114358: // BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_DUCT
                    return UnitType.UT_HVAC_DuctInsulationThickness;
                case -1114344: // BuiltInParameter.ZONE_COIL_BYPASS_PERCENTAGE_PARAM
                    return UnitType.UT_HVAC_Factor;
                case -1114343: // BuiltInParameter.ZONE_CALCULATED_AREA_PER_COOLING_LOAD_PARAM
                    return UnitType.UT_HVAC_Area_Divided_By_Cooling_Load;
                case -1114342: // BuiltInParameter.ZONE_CALCULATED_AREA_PER_HEATING_LOAD_PARAM
                    return UnitType.UT_HVAC_Area_Divided_By_Heating_Load;
                case -1114332: // BuiltInParameter.ZONE_AREA_GROSS
                    return UnitType.UT_Area;
                case -1114331: // BuiltInParameter.ZONE_VOLUME_GROSS
                    return UnitType.UT_Volume;
                case -1114323: // BuiltInParameter.ROOM_CALCULATED_SUPPLY_AIRFLOW_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1114322: // BuiltInParameter.ROOM_CALCULATED_COOLING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Cooling_Load_Divided_By_Area;
                case -1114321: // BuiltInParameter.ROOM_CALCULATED_HEATING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Heating_Load_Divided_By_Area;
                case -1114320: // BuiltInParameter.ZONE_CALCULATED_SUPPLY_AIRFLOW_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1114319: // BuiltInParameter.ZONE_CALCULATED_COOLING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Cooling_Load_Divided_By_Area;
                case -1114318: // BuiltInParameter.ZONE_CALCULATED_HEATING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Heating_Load_Divided_By_Area;
                case -1114316: // BuiltInParameter.ZONE_OA_RATE_PER_ACH_PARAM
                    return UnitType.UT_Number;
                case -1114315: // BuiltInParameter.ZONE_OUTSIDE_AIR_PER_AREA_PARAM
                    return UnitType.UT_HVAC_Airflow_Density;
                case -1114314: // BuiltInParameter.ZONE_OUTSIDE_AIR_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114313: // BuiltInParameter.ZONE_DEHUMIDIFICATION_SET_POINT_PARAM
                    return UnitType.UT_Number;
                case -1114312: // BuiltInParameter.ZONE_HUMIDIFICATION_SET_POINT_PARAM
                    return UnitType.UT_Number;
                case -1114311: // BuiltInParameter.ZONE_COOLING_AIR_TEMPERATURE_PARAM
                    return UnitType.UT_HVAC_Temperature;
                case -1114310: // BuiltInParameter.ZONE_HEATING_AIR_TEMPERATURE_PARAM
                    return UnitType.UT_HVAC_Temperature;
                case -1114309: // BuiltInParameter.ZONE_COOLING_SET_POINT_PARAM
                    return UnitType.UT_HVAC_Temperature;
                case -1114308: // BuiltInParameter.ZONE_HEATING_SET_POINT_PARAM
                    return UnitType.UT_HVAC_Temperature;
                case -1114307: // BuiltInParameter.ZONE_CALCULATED_SUPPLY_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114306: // BuiltInParameter.ZONE_CALCULATED_COOLING_LOAD_PARAM
                    return UnitType.UT_HVAC_Cooling_Load;
                case -1114305: // BuiltInParameter.ZONE_CALCULATED_HEATING_LOAD_PARAM
                    return UnitType.UT_HVAC_Heating_Load;
                case -1114303: // BuiltInParameter.ZONE_VOLUME
                    return UnitType.UT_Volume;
                case -1114302: // BuiltInParameter.ZONE_PERIMETER
                    return UnitType.UT_Length;
                case -1114301: // BuiltInParameter.ZONE_AREA
                    return UnitType.UT_Area;
                case -1114261: // BuiltInParameter.ROOM_ACTUAL_LIGHTING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114260: // BuiltInParameter.ROOM_ACTUAL_POWER_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114256: // BuiltInParameter.ROOM_DESIGN_COOLING_LOAD_PARAM
                    return UnitType.UT_HVAC_Cooling_Load;
                case -1114255: // BuiltInParameter.ROOM_CALCULATED_COOLING_LOAD_PARAM
                    return UnitType.UT_HVAC_Cooling_Load;
                case -1114254: // BuiltInParameter.ROOM_DESIGN_HEATING_LOAD_PARAM
                    return UnitType.UT_HVAC_Heating_Load;
                case -1114253: // BuiltInParameter.ROOM_CALCULATED_HEATING_LOAD_PARAM
                    return UnitType.UT_HVAC_Heating_Load;
                case -1114247: // BuiltInParameter.RBS_GBXML_SURFACE_AREA
                    return UnitType.UT_Area;
                case -1114239: // BuiltInParameter.ROOM_PEOPLE_SENSIBLE_HEAT_GAIN_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_HeatGain;
                case -1114230: // BuiltInParameter.ROOM_DESIGN_LIGHTING_LOAD_PARAM
                    return UnitType.UT_Electrical_Power;
                case -1114229: // BuiltInParameter.ROOM_DESIGN_POWER_LOAD_PARAM
                    return UnitType.UT_Electrical_Power;
                case -1114226: // BuiltInParameter.ROOM_ACTUAL_LIGHTING_LOAD_PARAM
                    return UnitType.UT_Electrical_Power;
                case -1114225: // BuiltInParameter.ROOM_ACTUAL_POWER_LOAD_PARAM
                    return UnitType.UT_Electrical_Power;
                case -1114222: // BuiltInParameter.ROOM_DESIGN_OTHER_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114221: // BuiltInParameter.ROOM_DESIGN_MECHANICAL_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114220: // BuiltInParameter.ROOM_DESIGN_LIGHTING_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114219: // BuiltInParameter.ROOM_DESIGN_POWER_LOAD_PER_AREA_PARAM
                    return UnitType.UT_Electrical_Power_Density;
                case -1114218: // BuiltInParameter.FBX_LIGHT_BALLAST_LOSS
                    return UnitType.UT_Number;
                case -1114217: // BuiltInParameter.FBX_LIGHT_TOTAL_LIGHT_LOSS
                    return UnitType.UT_Number;
                case -1114216: // BuiltInParameter.RBS_ROOM_COEFFICIENT_UTILIZATION
                    return UnitType.UT_Number;
                case -1114196: // BuiltInParameter.ROOM_ACTUAL_EXHAUST_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114195: // BuiltInParameter.ROOM_ACTUAL_RETURN_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114194: // BuiltInParameter.ROOM_ACTUAL_SUPPLY_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114189: // BuiltInParameter.ROOM_PEOPLE_LATENT_HEAT_GAIN_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_HeatGain;
                case -1114188: // BuiltInParameter.ROOM_PEOPLE_TOTAL_HEAT_GAIN_PER_PERSON_PARAM
                    return UnitType.UT_HVAC_HeatGain;
                case -1114180: // BuiltInParameter.ROOM_CALCULATED_SUPPLY_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114178: // BuiltInParameter.ROOM_DESIGN_EXHAUST_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114177: // BuiltInParameter.ROOM_DESIGN_RETURN_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114176: // BuiltInParameter.ROOM_DESIGN_SUPPLY_AIRFLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1114175: // BuiltInParameter.ROOM_AREA_PER_PERSON_PARAM
                    return UnitType.UT_Area;
                case -1114174: // BuiltInParameter.ROOM_NUMBER_OF_PEOPLE_PARAM
                    return UnitType.UT_Number;
                case -1114166: // BuiltInParameter.RBS_ADDITIONAL_FLOW
                    return UnitType.UT_HVAC_Airflow;
                case -1114142: // BuiltInParameter.RBS_DUCT_STATIC_PRESSURE
                    return UnitType.UT_HVAC_Pressure;
                case -1114129: // BuiltInParameter.RBS_HYDRAULIC_DIAMETER_PARAM
                    return UnitType.UT_HVAC_DuctSize;
                case -1114128: // BuiltInParameter.RBS_REYNOLDSNUMBER_PARAM
                    return UnitType.UT_Number;
                case -1114127: // BuiltInParameter.RBS_EQ_DIAMETER_PARAM
                    return UnitType.UT_HVAC_DuctSize;
                case -1114124: // BuiltInParameter.RBS_LOSS_COEFFICIENT
                    return UnitType.UT_Number;
                case -1114123: // BuiltInParameter.RBS_MAX_FLOW
                    return UnitType.UT_HVAC_Airflow;
                case -1114122: // BuiltInParameter.RBS_MIN_FLOW
                    return UnitType.UT_HVAC_Airflow;
                case -1114121: // BuiltInParameter.RBS_VELOCITY_PRESSURE
                    return UnitType.UT_HVAC_Pressure;
                case -1114120: // BuiltInParameter.RBS_CURVE_SURFACE_AREA
                    return UnitType.UT_Area;
                case -1114116: // BuiltInParameter.RBS_FRICTION
                    return UnitType.UT_HVAC_Friction;
                case -1114108: // BuiltInParameter.RBS_PRESSURE_DROP
                    return UnitType.UT_HVAC_Pressure;
                case -1114107: // BuiltInParameter.RBS_VELOCITY
                    return UnitType.UT_HVAC_Velocity;
                case -1114103: // BuiltInParameter.RBS_CURVE_DIAMETER_PARAM
                    return UnitType.UT_HVAC_DuctSize;
                case -1114102: // BuiltInParameter.RBS_CURVE_HEIGHT_PARAM
                    return UnitType.UT_HVAC_DuctSize;
                case -1114101: // BuiltInParameter.RBS_CURVE_WIDTH_PARAM
                    return UnitType.UT_HVAC_DuctSize;
                case -1060011: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MZ
                    return UnitType.UT_Moment;
                case -1060010: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MY
                    return UnitType.UT_Moment;
                case -1060009: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MX
                    return UnitType.UT_Moment;
                case -1060008: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FZ
                    return UnitType.UT_Force;
                case -1060007: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FY
                    return UnitType.UT_Force;
                case -1060006: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FX
                    return UnitType.UT_Force;
                case -1060005: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MZ
                    return UnitType.UT_Moment;
                case -1060004: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MY
                    return UnitType.UT_Moment;
                case -1060003: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MX
                    return UnitType.UT_Moment;
                case -1060002: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FZ
                    return UnitType.UT_Force;
                case -1060001: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FY
                    return UnitType.UT_Force;
                case -1060000: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FX
                    return UnitType.UT_Force;
                case -1018503: // BuiltInParameter.REINFORCEMENT_VOLUME
                    return UnitType.UT_Reinforcement_Volume;
                case -1018502: // BuiltInParameter.REIN_EST_BAR_VOLUME
                    return UnitType.UT_Reinforcement_Volume;
                case -1018308: // BuiltInParameter.PATH_REIN_LENGTH_2
                    return UnitType.UT_Reinforcement_Length;
                case -1018307: // BuiltInParameter.PATH_REIN_LENGTH_1
                    return UnitType.UT_Reinforcement_Length;
                case -1018302: // BuiltInParameter.PATH_REIN_SPACING
                    return UnitType.UT_Reinforcement_Spacing;
                case -1018273: // BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_2_GENERIC
                    return UnitType.UT_Reinforcement_Spacing;
                case -1018272: // BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_1_GENERIC
                    return UnitType.UT_Reinforcement_Spacing;
                case -1018271: // BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_2_GENERIC
                    return UnitType.UT_Reinforcement_Spacing;
                case -1018270: // BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_1_GENERIC
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017739: // BuiltInParameter.FABRIC_WIRE_OFFSET
                    return UnitType.UT_Reinforcement_Length;
                case -1017738: // BuiltInParameter.FABRIC_WIRE_DISTANCE
                    return UnitType.UT_Reinforcement_Length;
                case -1017737: // BuiltInParameter.FABRIC_WIRE_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017712: // BuiltInParameter.FABRIC_PARAM_CUT_SHEET_MASS
                    return UnitType.UT_Mass;
                case -1017711: // BuiltInParameter.FABRIC_PARAM_TOTAL_SHEET_MASS
                    return UnitType.UT_Mass;
                case -1017710: // BuiltInParameter.FABRIC_PARAM_CUT_OVERALL_WIDTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017709: // BuiltInParameter.FABRIC_PARAM_CUT_OVERALL_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017707: // BuiltInParameter.FABRIC_PARAM_MINOR_LAPSPLICE_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017706: // BuiltInParameter.FABRIC_PARAM_MAJOR_LAPSPLICE_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017624: // BuiltInParameter.FABRIC_SHEET_MASSUNIT
                    return UnitType.UT_MassPerUnitArea;
                case -1017623: // BuiltInParameter.FABRIC_SHEET_MINOR_REINFORCEMENT_AREA
                    return UnitType.UT_Reinforcement_Area_per_Unit_Length;
                case -1017622: // BuiltInParameter.FABRIC_SHEET_MAJOR_REINFORCEMENT_AREA
                    return UnitType.UT_Reinforcement_Area_per_Unit_Length;
                case -1017621: // BuiltInParameter.FABRIC_SHEET_MASS
                    return UnitType.UT_Mass;
                case -1017620: // BuiltInParameter.FABRIC_SHEET_MINOR_SPACING
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017617: // BuiltInParameter.FABRIC_SHEET_MINOR_END_OVERHANG
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017616: // BuiltInParameter.FABRIC_SHEET_MINOR_START_OVERHANG
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017615: // BuiltInParameter.FABRIC_SHEET_WIDTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017614: // BuiltInParameter.FABRIC_SHEET_OVERALL_WIDTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017613: // BuiltInParameter.FABRIC_SHEET_MAJOR_SPACING
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017610: // BuiltInParameter.FABRIC_SHEET_MAJOR_END_OVERHANG
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017609: // BuiltInParameter.FABRIC_SHEET_MAJOR_START_OVERHANG
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017608: // BuiltInParameter.FABRIC_SHEET_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017607: // BuiltInParameter.FABRIC_SHEET_OVERALL_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017601: // BuiltInParameter.FABRIC_WIRE_DIAMETER
                    return UnitType.UT_Bar_Diameter;
                case -1017064: // BuiltInParameter.REBAR_MIN_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017063: // BuiltInParameter.REBAR_MAX_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017038: // BuiltInParameter.REBAR_INSTANCE_BEND_DIAMETER
                    return UnitType.UT_Bar_Diameter;
                case -1017016: // BuiltInParameter.REBAR_ELEM_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017013: // BuiltInParameter.REBAR_ELEM_BAR_SPACING
                    return UnitType.UT_Reinforcement_Spacing;
                case -1017005: // BuiltInParameter.REBAR_ELEM_TOTAL_LENGTH
                    return UnitType.UT_Reinforcement_Length;
                case -1017000: // BuiltInParameter.REBAR_BAR_DIAMETER
                    return UnitType.UT_Bar_Diameter;
                case -1015069: // BuiltInParameter.LOAD_AREA_AREA
                    return UnitType.UT_Area;
                case -1015068: // BuiltInParameter.LOAD_AREA_FORCE_FZ3
                    return UnitType.UT_AreaForce;
                case -1015067: // BuiltInParameter.LOAD_AREA_FORCE_FY3
                    return UnitType.UT_AreaForce;
                case -1015066: // BuiltInParameter.LOAD_AREA_FORCE_FX3
                    return UnitType.UT_AreaForce;
                case -1015065: // BuiltInParameter.LOAD_AREA_FORCE_FZ2
                    return UnitType.UT_AreaForce;
                case -1015064: // BuiltInParameter.LOAD_AREA_FORCE_FY2
                    return UnitType.UT_AreaForce;
                case -1015063: // BuiltInParameter.LOAD_AREA_FORCE_FX2
                    return UnitType.UT_AreaForce;
                case -1015062: // BuiltInParameter.LOAD_AREA_FORCE_FZ1
                    return UnitType.UT_AreaForce;
                case -1015061: // BuiltInParameter.LOAD_AREA_FORCE_FY1
                    return UnitType.UT_AreaForce;
                case -1015060: // BuiltInParameter.LOAD_AREA_FORCE_FX1
                    return UnitType.UT_AreaForce;
                case -1015043: // BuiltInParameter.LOAD_LINEAR_LENGTH
                    return UnitType.UT_Length;
                case -1015041: // BuiltInParameter.LOAD_MOMENT_MZ2
                    return UnitType.UT_LinearMoment;
                case -1015040: // BuiltInParameter.LOAD_MOMENT_MY2
                    return UnitType.UT_LinearMoment;
                case -1015039: // BuiltInParameter.LOAD_MOMENT_MX2
                    return UnitType.UT_LinearMoment;
                case -1015038: // BuiltInParameter.LOAD_MOMENT_MZ1
                    return UnitType.UT_LinearMoment;
                case -1015037: // BuiltInParameter.LOAD_MOMENT_MY1
                    return UnitType.UT_LinearMoment;
                case -1015036: // BuiltInParameter.LOAD_MOMENT_MX1
                    return UnitType.UT_LinearMoment;
                case -1015035: // BuiltInParameter.LOAD_LINEAR_FORCE_FZ2
                    return UnitType.UT_LinearForce;
                case -1015034: // BuiltInParameter.LOAD_LINEAR_FORCE_FY2
                    return UnitType.UT_LinearForce;
                case -1015033: // BuiltInParameter.LOAD_LINEAR_FORCE_FX2
                    return UnitType.UT_LinearForce;
                case -1015032: // BuiltInParameter.LOAD_LINEAR_FORCE_FZ1
                    return UnitType.UT_LinearForce;
                case -1015031: // BuiltInParameter.LOAD_LINEAR_FORCE_FY1
                    return UnitType.UT_LinearForce;
                case -1015030: // BuiltInParameter.LOAD_LINEAR_FORCE_FX1
                    return UnitType.UT_LinearForce;
                case -1015015: // BuiltInParameter.LOAD_MOMENT_MZ
                    return UnitType.UT_Moment;
                case -1015014: // BuiltInParameter.LOAD_MOMENT_MY
                    return UnitType.UT_Moment;
                case -1015013: // BuiltInParameter.LOAD_MOMENT_MX
                    return UnitType.UT_Moment;
                case -1015012: // BuiltInParameter.LOAD_FORCE_FZ
                    return UnitType.UT_Force;
                case -1015011: // BuiltInParameter.LOAD_FORCE_FY
                    return UnitType.UT_Force;
                case -1015010: // BuiltInParameter.LOAD_FORCE_FX
                    return UnitType.UT_Force;
                case -1013408: // BuiltInParameter.JOIST_SYSTEM_SPACING_PARAM
                    return UnitType.UT_Length;
                case -1013405: // BuiltInParameter.RBS_DUCT_FLOW_PARAM
                    return UnitType.UT_HVAC_Airflow;
                case -1012806: // BuiltInParameter.HOST_VOLUME_COMPUTED
                    return UnitType.UT_Volume;
                case -1012805: // BuiltInParameter.HOST_AREA_COMPUTED
                    return UnitType.UT_Area;
                case -1012618: // BuiltInParameter.PROPERTY_SEGMENT_RADIUS
                    return UnitType.UT_Length;
                case -1012616: // BuiltInParameter.PROPERTY_SEGMENT_BEARING
                    return UnitType.UT_SiteAngle;
                case -1012614: // BuiltInParameter.PROPERTY_SEGMENT_DISTANCE
                    return UnitType.UT_Length;
                case -1012611: // BuiltInParameter.VOLUME_NET
                    return UnitType.UT_Volume;
                case -1012610: // BuiltInParameter.PROJECTED_SURFACE_AREA
                    return UnitType.UT_Area;
                case -1012604: // BuiltInParameter.VOLUME_FILL
                    return UnitType.UT_Volume;
                case -1012603: // BuiltInParameter.VOLUME_CUT
                    return UnitType.UT_Volume;
                case -1012601: // BuiltInParameter.SURFACE_AREA
                    return UnitType.UT_Area;
                case -1012600: // BuiltInParameter.PROPERTY_AREA
                    return UnitType.UT_Area;
                case -1012501: // BuiltInParameter.BUILDINGPAD_THICKNESS
                    return UnitType.UT_Length;
                case -1012044: // BuiltInParameter.MASS_DATA_SKYLIGHT_WIDTH
                    return UnitType.UT_Length;
                case -1012043: // BuiltInParameter.MASS_DATA_PERCENTAGE_SKYLIGHTS
                    return UnitType.UT_Number;
                case -1012042: // BuiltInParameter.MASS_DATA_SILL_HEIGHT
                    return UnitType.UT_Length;
                case -1012041: // BuiltInParameter.MASS_DATA_SHADE_DEPTH
                    return UnitType.UT_Length;
                case -1012039: // BuiltInParameter.MASS_DATA_PERCENTAGE_GLAZING
                    return UnitType.UT_Number;
                case -1012037: // BuiltInParameter.MASS_DATA_MASS_OPENING_AREA
                    return UnitType.UT_Area;
                case -1012036: // BuiltInParameter.MASS_DATA_MASS_SKYLIGHT_AREA
                    return UnitType.UT_Area;
                case -1012035: // BuiltInParameter.MASS_DATA_MASS_WINDOW_AREA
                    return UnitType.UT_Area;
                case -1012034: // BuiltInParameter.MASS_DATA_MASS_ROOF_AREA
                    return UnitType.UT_Area;
                case -1012033: // BuiltInParameter.MASS_DATA_MASS_INTERIOR_WALL_AREA
                    return UnitType.UT_Area;
                case -1012032: // BuiltInParameter.MASS_DATA_MASS_EXTERIOR_WALL_AREA
                    return UnitType.UT_Area;
                case -1012025: // BuiltInParameter.MASS_ZONE_FLOOR_AREA
                    return UnitType.UT_Area;
                case -1012021: // BuiltInParameter.MASS_ZONE_VOLUME
                    return UnitType.UT_Volume;
                case -1012012: // BuiltInParameter.LEVEL_DATA_VOLUME
                    return UnitType.UT_Volume;
                case -1012011: // BuiltInParameter.LEVEL_DATA_SURFACE_AREA
                    return UnitType.UT_Area;
                case -1012010: // BuiltInParameter.LEVEL_DATA_FLOOR_AREA
                    return UnitType.UT_Area;
                case -1012009: // BuiltInParameter.LEVEL_DATA_FLOOR_PERIMETER
                    return UnitType.UT_Length;
                case -1012007: // BuiltInParameter.MASS_GROSS_VOLUME
                    return UnitType.UT_Volume;
                case -1012006: // BuiltInParameter.MASS_GROSS_SURFACE_AREA
                    return UnitType.UT_Area;
                case -1012004: // BuiltInParameter.MASS_GROSS_AREA
                    return UnitType.UT_Area;
                case -1010503: // BuiltInParameter.FBX_LIGHT_LIMUNOUS_FLUX
                    return UnitType.UT_Electrical_Luminous_Flux;
                case -1010301: // BuiltInParameter.CURTAIN_WALL_PANELS_WIDTH
                    return UnitType.UT_Length;
                case -1010300: // BuiltInParameter.CURTAIN_WALL_PANELS_HEIGHT
                    return UnitType.UT_Length;
                case -1010003: // BuiltInParameter.CASEWORK_DEPTH, BuiltInParameter.CASEWORK_DEPTH
                    return UnitType.UT_Length;
                case -1008621: // BuiltInParameter.STAIRS_RAILING_HEIGHT_OFFSET
                    return UnitType.UT_Length;
                case -1008602: // BuiltInParameter.STAIRS_RAILING_HEIGHT
                    return UnitType.UT_Length;
                case -1007250: // BuiltInParameter.STAIRS_ACTUAL_TREAD_DEPTH
                    return UnitType.UT_Length;
                case -1007211: // BuiltInParameter.STAIRS_ATTR_TREAD_THICKNESS
                    return UnitType.UT_Length;
                case -1007206: // BuiltInParameter.STAIRS_ACTUAL_RISER_HEIGHT
                    return UnitType.UT_Length;
                case -1007204: // BuiltInParameter.STAIRS_ATTR_TREAD_WIDTH
                    return UnitType.UT_Length;
                case -1007203: // BuiltInParameter.STAIRS_ATTR_MINIMUM_TREAD_DEPTH
                    return UnitType.UT_Length;
                case -1007202: // BuiltInParameter.STAIRS_ATTR_MAX_RISER_HEIGHT
                    return UnitType.UT_Length;
                case -1007102: // BuiltInParameter.LEVEL_ELEV
                    return UnitType.UT_Length;
                case -1006925: // BuiltInParameter.ROOM_LOWER_OFFSET
                    return UnitType.UT_Length;
                case -1006924: // BuiltInParameter.ROOM_UPPER_OFFSET
                    return UnitType.UT_Length;
                case -1006921: // BuiltInParameter.ROOM_VOLUME
                    return UnitType.UT_Volume;
                case -1006920: // BuiltInParameter.ROOM_HEIGHT
                    return UnitType.UT_Length;
                case -1006917: // BuiltInParameter.ROOM_PERIMETER
                    return UnitType.UT_Length;
                case -1006902: // BuiltInParameter.ROOM_AREA
                    return UnitType.UT_Area;
                case -1006016: // BuiltInParameter.ROOF_SLOPE
                    return UnitType.UT_Slope;
                case -1005567: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBTHICKNESS_LOCATION
                    return UnitType.UT_Section_Property;
                case -1005566: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGETHICKNESS_LOCATION
                    return UnitType.UT_Section_Property;
                case -1005565: // BuiltInParameter.STRUCTURAL_SECTION_TOP_WEB_FILLET
                    return UnitType.UT_Section_Property;
                case -1005564: // BuiltInParameter.STRUCTURAL_SECTION_SLOPED_WEB_ANGLE
                    return UnitType.UT_Angle;
                case -1005563: // BuiltInParameter.STRUCTURAL_SECTION_SLOPED_FLANGE_ANGLE
                    return UnitType.UT_Angle;
                case -1005562: // BuiltInParameter.STRUCTURAL_SECTION_CANTILEVER_HEIGHT
                    return UnitType.UT_Section_Dimension;
                case -1005561: // BuiltInParameter.STRUCTURAL_SECTION_CANTILEVER_LENGTH
                    return UnitType.UT_Section_Dimension;
                case -1005560: // BuiltInParameter.STRUCTURAL_SECTION_BOTTOM_CUT_HEIGHT
                    return UnitType.UT_Section_Dimension;
                case -1005559: // BuiltInParameter.STRUCTURAL_SECTION_BOTTOM_CUT_WIDTH
                    return UnitType.UT_Section_Dimension;
                case -1005558: // BuiltInParameter.STRUCTURAL_SECTION_TOP_CUT_HEIGHT
                    return UnitType.UT_Section_Dimension;
                case -1005557: // BuiltInParameter.STRUCTURAL_SECTION_TOP_CUT_WIDTH
                    return UnitType.UT_Section_Dimension;
                case -1005553: // BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_TOP_BEND_WIDTH
                    return UnitType.UT_Section_Dimension;
                case -1005552: // BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_MIDDLE_BEND_WIDTH
                    return UnitType.UT_Section_Dimension;
                case -1005551: // BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_BEND_WIDTH
                    return UnitType.UT_Section_Dimension;
                case -1005550: // BuiltInParameter.STRUCTURAL_SECTION_ZPROFILE_BOTTOM_FLANGE_LENGTH
                    return UnitType.UT_Section_Dimension;
                case -1005549: // BuiltInParameter.STRUCTURAL_SECTION_CPROFILE_FOLD_LENGTH
                    return UnitType.UT_Section_Dimension;
                case -1005548: // BuiltInParameter.STRUCTURAL_SECTION_LPROFILE_LIP_LENGTH
                    return UnitType.UT_Section_Dimension;
                case -1005547: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_DIAMETER_SHORTER_FLANGE
                    return UnitType.UT_Section_Dimension;
                case -1005546: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_DIAMETER_LONGER_FLANGE
                    return UnitType.UT_Section_Dimension;
                case -1005545: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_SHORTER_FLANGE
                    return UnitType.UT_Section_Dimension;
                case -1005544: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_2_LONGER_FLANGE
                    return UnitType.UT_Section_Dimension;
                case -1005543: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_1_LONGER_FLANGE
                    return UnitType.UT_Section_Dimension;
                case -1005542: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_WEB
                    return UnitType.UT_Section_Dimension;
                case -1005541: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_BETWEEN_ROWS
                    return UnitType.UT_Section_Dimension;
                case -1005540: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_TWO_ROWS
                    return UnitType.UT_Section_Dimension;
                case -1005539: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_DIAMETER
                    return UnitType.UT_Section_Dimension;
                case -1005538: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING
                    return UnitType.UT_Section_Dimension;
                case -1005537: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEB_TOE_OF_FILLET
                    return UnitType.UT_Section_Dimension;
                case -1005536: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGE_TOE_OF_FILLET
                    return UnitType.UT_Section_Dimension;
                case -1005535: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_CLEAR_WEB_HEIGHT
                    return UnitType.UT_Section_Dimension;
                case -1005534: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_BOTTOMFLANGEWIDTH
                    return UnitType.UT_Section_Property;
                case -1005533: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_BOTTOMFLANGETHICKNESS
                    return UnitType.UT_Section_Property;
                case -1005532: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_TOPFLANGEWIDTH
                    return UnitType.UT_Section_Property;
                case -1005531: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_TOPFLANGETHICKNESS
                    return UnitType.UT_Section_Property;
                case -1005530: // BuiltInParameter.STRUCTURAL_SECTION_HSS_OUTERFILLET
                    return UnitType.UT_Section_Property;
                case -1005529: // BuiltInParameter.STRUCTURAL_SECTION_HSS_INNERFILLET
                    return UnitType.UT_Section_Property;
                case -1005528: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBFILLET
                    return UnitType.UT_Section_Property;
                case -1005527: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGEFILLET
                    return UnitType.UT_Section_Property;
                case -1005526: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBHEIGHT
                    return UnitType.UT_Section_Property;
                case -1005525: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBTHICKNESS
                    return UnitType.UT_Section_Property;
                case -1005524: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGETHICKNESS
                    return UnitType.UT_Section_Property;
                case -1005523: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_SHEAR_AREA_WEAK_AXIS
                    return UnitType.UT_Section_Area;
                case -1005522: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_SHEAR_AREA_STRONG_AXIS
                    return UnitType.UT_Section_Area;
                case -1005521: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_WARPING_CONSTANT
                    return UnitType.UT_Warping_Constant;
                case -1005520: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_TORSIONAL_MODULUS
                    return UnitType.UT_Section_Modulus;
                case -1005519: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_TORSIONAL_MOMENT_OF_INERTIA
                    return UnitType.UT_Moment_of_Inertia;
                case -1005518: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_PLASTIC_MODULUS_WEAK_AXIS
                    return UnitType.UT_Section_Modulus;
                case -1005517: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_PLASTIC_MODULUS_STRONG_AXIS
                    return UnitType.UT_Section_Modulus;
                case -1005516: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_ELASTIC_MODULUS_WEAK_AXIS
                    return UnitType.UT_Section_Modulus;
                case -1005515: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_ELASTIC_MODULUS_STRONG_AXIS
                    return UnitType.UT_Section_Modulus;
                case -1005514: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_MOMENT_OF_INERTIA_WEAK_AXIS
                    return UnitType.UT_Moment_of_Inertia;
                case -1005513: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_MOMENT_OF_INERTIA_STRONG_AXIS
                    return UnitType.UT_Moment_of_Inertia;
                case -1005512: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_NOMINAL_WEIGHT
                    return UnitType.UT_Weight_per_Unit_Length;
                case -1005511: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_PERIMETER
                    return UnitType.UT_Surface_Area;
                case -1005510: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_ALPHA
                    return UnitType.UT_Angle;
                case -1005509: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_CENTROID_VERTICAL
                    return UnitType.UT_Section_Property;
                case -1005508: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_CENTROID_HORIZ
                    return UnitType.UT_Section_Property;
                case -1005507: // BuiltInParameter.STRUCTURAL_SECTION_AREA
                    return UnitType.UT_Section_Area;
                case -1005506: // BuiltInParameter.STRUCTURAL_SECTION_PIPESTANDARD_WALLDESIGNTHICKNESS
                    return UnitType.UT_Section_Property;
                case -1005505: // BuiltInParameter.STRUCTURAL_SECTION_PIPESTANDARD_WALLNOMINALTHICKNESS
                    return UnitType.UT_Section_Property;
                case -1005504: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_DIAMETER
                    return UnitType.UT_Section_Property;
                case -1005503: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_HEIGHT
                    return UnitType.UT_Section_Property;
                case -1005502: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_WIDTH
                    return UnitType.UT_Section_Property;
                case -1005435: // BuiltInParameter.ANALYTICAL_ABSORPTANCE
                    return UnitType.UT_Number;
                case -1005434: // BuiltInParameter.ANALYTICAL_THERMAL_MASS
                    return UnitType.UT_HVAC_ThermalMass;
                case -1005433: // BuiltInParameter.ANALYTICAL_VISUAL_LIGHT_TRANSMITTANCE
                    return UnitType.UT_Number;
                case -1005432: // BuiltInParameter.ANALYTICAL_SOLAR_HEAT_GAIN_COEFFICIENT
                    return UnitType.UT_Number;
                case -1005431: // BuiltInParameter.ANALYTICAL_THERMAL_RESISTANCE
                    return UnitType.UT_HVAC_ThermalResistance;
                case -1005430: // BuiltInParameter.ANALYTICAL_HEAT_TRANSFER_COEFFICIENT
                    return UnitType.UT_HVAC_CoefficientOfHeatTransfer;
                case -1004005: // BuiltInParameter.CURVE_ELEM_LENGTH
                    return UnitType.UT_Length;
                case -1002300: // BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM
                    return UnitType.UT_Length;
                case -1002066: // BuiltInParameter.SCHEDULE_TOP_LEVEL_OFFSET_PARAM
                    return UnitType.UT_Length;
                case -1002065: // BuiltInParameter.SCHEDULE_BASE_LEVEL_OFFSET_PARAM
                    return UnitType.UT_Length;
                case -1001953: // BuiltInParameter.HOST_PERIMETER_COMPUTED
                    return UnitType.UT_Length;
                case -1001951: // BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM
                    return UnitType.UT_Length;
                case -1001902: // BuiltInParameter.FLOOR_ATTR_DEFAULT_THICKNESS_PARAM
                    return UnitType.UT_Length;
                case -1001701: // BuiltInParameter.ROOF_LEVEL_OFFSET_PARAM
                    return UnitType.UT_Length;
                case -1001658: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM_SURVEY
                    return UnitType.UT_Length;
                case -1001657: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP_SURVEY
                    return UnitType.UT_Length;
                case -1001656: // BuiltInParameter.STRUCTURAL_FLOOR_CORE_THICKNESS
                    return UnitType.UT_Length;
                case -1001655: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM_CORE
                    return UnitType.UT_Length;
                case -1001654: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP_CORE
                    return UnitType.UT_Length;
                case -1001653: // BuiltInParameter.STRUCTURAL_REFERENCE_LEVEL_ELEVATION
                    return UnitType.UT_Length;
                case -1001601: // BuiltInParameter.ROOF_ATTR_THICKNESS_PARAM
                    return UnitType.UT_Length;
                case -1001598: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP
                    return UnitType.UT_Length;
                case -1001586: // BuiltInParameter.STRUCTURAL_BEND_DIR_ANGLE
                    return UnitType.UT_Angle;
                case -1001572: // BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION
                    return UnitType.UT_Length;
                case -1001571: // BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION
                    return UnitType.UT_Length;
                case -1001567: // BuiltInParameter.CONTINUOUS_FOOTING_LENGTH
                    return UnitType.UT_Length;
                case -1001561: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM
                    return UnitType.UT_Length;
                case -1001558: // BuiltInParameter.CONTINUOUS_FOOTING_WIDTH
                    return UnitType.UT_Length;
                case -1001557: // BuiltInParameter.STRUCTURAL_FOUNDATION_THICKNESS
                    return UnitType.UT_Length;
                case -1001555: // BuiltInParameter.CONTINUOUS_FOOTING_TOP_HEEL
                    return UnitType.UT_Length;
                case -1001553: // BuiltInParameter.CONTINUOUS_FOOTING_TOP_TOE
                    return UnitType.UT_Length;
                case -1001384: // BuiltInParameter.STRUCTURAL_FRAME_CUT_LENGTH
                    return UnitType.UT_Length;
                case -1001375: // BuiltInParameter.INSTANCE_LENGTH_PARAM
                    return UnitType.UT_Length;
                case -1001362: // BuiltInParameter.INSTANCE_HEAD_HEIGHT_PARAM
                    return UnitType.UT_Length;
                case -1001361: // BuiltInParameter.INSTANCE_SILL_HEIGHT_PARAM
                    return UnitType.UT_Length;
                case -1001360: // BuiltInParameter.INSTANCE_ELEVATION_PARAM
                    return UnitType.UT_Length;
                case -1001305: // BuiltInParameter.FAMILY_ROUGH_WIDTH_PARAM
                    return UnitType.UT_Length;
                case -1001304: // BuiltInParameter.FAMILY_ROUGH_HEIGHT_PARAM
                    return UnitType.UT_Length;
                case -1001302: // BuiltInParameter.WINDOW_THICKNESS, BuiltInParameter.WINDOW_THICKNESS, BuiltInParameter.WINDOW_THICKNESS, BuiltInParameter.WINDOW_THICKNESS, BuiltInParameter.WINDOW_THICKNESS
                    return UnitType.UT_Length;
                case -1001301: // BuiltInParameter.FURNITURE_WIDTH, BuiltInParameter.FURNITURE_WIDTH, BuiltInParameter.FURNITURE_WIDTH, BuiltInParameter.FURNITURE_WIDTH, BuiltInParameter.FURNITURE_WIDTH, BuiltInParameter.FURNITURE_WIDTH
                    return UnitType.UT_Length;
                case -1001300: // BuiltInParameter.FAMILY_HEIGHT_PARAM, BuiltInParameter.FAMILY_HEIGHT_PARAM, BuiltInParameter.FAMILY_HEIGHT_PARAM, BuiltInParameter.FAMILY_HEIGHT_PARAM, BuiltInParameter.FAMILY_HEIGHT_PARAM, BuiltInParameter.FAMILY_HEIGHT_PARAM
                    return UnitType.UT_Length;
                case -1001205: // BuiltInParameter.DOOR_COST, BuiltInParameter.DOOR_COST
                    return UnitType.UT_Currency;
                case -1001136: // BuiltInParameter.DPART_LENGTH_COMPUTED
                    return UnitType.UT_Length;
                case -1001135: // BuiltInParameter.DPART_HEIGHT_COMPUTED
                    return UnitType.UT_Length;
                case -1001134: // BuiltInParameter.DPART_LAYER_WIDTH
                    return UnitType.UT_Length;
                case -1001133: // BuiltInParameter.DPART_AREA_COMPUTED
                    return UnitType.UT_Area;
                case -1001129: // BuiltInParameter.DPART_VOLUME_COMPUTED
                    return UnitType.UT_Volume;
                case -1001109: // BuiltInParameter.WALL_TOP_OFFSET
                    return UnitType.UT_Length;
                case -1001108: // BuiltInParameter.WALL_BASE_OFFSET
                    return UnitType.UT_Length;
                case -1001105: // BuiltInParameter.WALL_USER_HEIGHT_PARAM
                    return UnitType.UT_Length;
                case -1001000: // BuiltInParameter.WALL_ATTR_WIDTH_PARAM
                    return UnitType.UT_Length;
                default:
                    throw new ArgumentOutOfRangeException(nameof(builtInParameter),
                        $"Не удалось определить \"UnitType\" параметра для \"{builtInParameter}\".");
            }

        }

#endif

#if REVIT2021_OR_GREATER

        /// <summary>
        /// Возвращает <see cref="Autodesk.Revit.DB.ForgeTypeId"/> для системного параметра.
        /// </summary>
        /// <param name="builtInParameter">Системный параметр.</param>
        /// <returns>Возвращает <see cref="Autodesk.Revit.DB.ForgeTypeId"/> для системного параметра.</returns>
        public static ForgeTypeId GetUnitType(this BuiltInParameter builtInParameter) {
            switch((int) builtInParameter) {
                case -1155215: // BuiltInParameter.REBAR_HOOK_LENGTH_OVERRIDE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155214: // BuiltInParameter.INFRASTRUCTURE_ALIGNMENT_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155213: // BuiltInParameter.INFRASTRUCTURE_ALIGNMENT_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155210: // BuiltInParameter.ASSEMBLY_PRECAST_FREEZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155202: // BuiltInParameter.PATH_OF_TRAVEL_FROM_ROOM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155201: // BuiltInParameter.PATH_OF_TRAVEL_TO_ROOM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155150: // BuiltInParameter.RBS_ELEC_NUMBER_OF_CIRCUITS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155146: // BuiltInParameter.STEEL_ELEM_PROFILE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155136: // BuiltInParameter.STEEL_ELEM_PLATE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155130: // BuiltInParameter.STEEL_ELEM_ANCHOR_ORIENTATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155122: // BuiltInParameter.STEEL_ELEM_BOLT_LOCATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155116: // BuiltInParameter.GENERIC_ZONE_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155100: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155094: // BuiltInParameter.PATH_OF_TRAVEL_VIEW_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155093: // BuiltInParameter.PATH_OF_TRAVEL_LEVEL_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155092: // BuiltInParameter.STRUCTURAL_CONNECTION_OVERRIDE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155074: // BuiltInParameter.STEEL_ELEM_WELD_PREFIX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155073: // BuiltInParameter.STEEL_ELEM_WELD_TEXT_MODULE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155060: // BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155052: // BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER_Y
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155051: // BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER_X
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155047: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_WELDPREP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155046: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_SURFACESHAPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155045: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_TEXT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155043: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155039: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_WELDPREP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155038: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_SURFACESHAPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155037: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_TEXT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155035: // BuiltInParameter.STEEL_ELEM_WELD_CONTINUOUS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155034: // BuiltInParameter.STEEL_ELEM_WELD_LOCATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155031: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155018: // BuiltInParameter.STEEL_ELEM_BOLT_COATING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155017: // BuiltInParameter.STEEL_ELEM_ANCHOR_LENGTH
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155016: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_DIAMETER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155015: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_GRADE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155014: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_STANDARD
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155013: // BuiltInParameter.STEEL_ELEM_ANCHOR_DIAMETER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155012: // BuiltInParameter.STEEL_ELEM_ANCHOR_ASSEMBLY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155011: // BuiltInParameter.STEEL_ELEM_ANCHOR_GRADE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155010: // BuiltInParameter.STEEL_ELEM_ANCHOR_STANDARD
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155009: // BuiltInParameter.STEEL_ELEM_COATING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155008: // BuiltInParameter.STEEL_ELEM_BOLT_DIAMETER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155007: // BuiltInParameter.STEEL_ELEM_BOLT_ASSEMBLY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155006: // BuiltInParameter.STEEL_ELEM_BOLT_GRADE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155005: // BuiltInParameter.STEEL_ELEM_BOLT_STANDARD
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154695: // BuiltInParameter.REBAR_WORKSHOP_INSTRUCTIONS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154694: // BuiltInParameter.REBAR_GEOMETRY_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154687: // BuiltInParameter.ROOM_OUTDOOR_AIRFLOW_STANDARD_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154662: // BuiltInParameter.ROOM_OUTDOOR_AIR_INFO_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154656: // BuiltInParameter.REBAR_ELEM_ENDTREATMENT_END
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154655: // BuiltInParameter.REBAR_ELEM_ENDTREATMENT_START
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154653: // BuiltInParameter.COUPLER_COUPLED_ENDTREATMENT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154652: // BuiltInParameter.COUPLER_MAIN_ENDTREATMENT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154649: // BuiltInParameter.COUPLER_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154642: // BuiltInParameter.COUPLER_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154641: // BuiltInParameter.COUPLER_QUANTITY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154640: // BuiltInParameter.COUPLER_COUPLED_BAR_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154639: // BuiltInParameter.COUPLER_MAIN_BAR_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154638: // BuiltInParameter.COUPLER_CODE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154620: //
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154619: // BuiltInParameter.REBAR_ELEM_HOST_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154618: // BuiltInParameter.REBAR_SHAPE_IMAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154617: // BuiltInParameter.FABRIC_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154616: // BuiltInParameter.REBAR_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1154614: // BuiltInParameter.NUMBER_PARTITION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153528: // BuiltInParameter.MEP_ZONE_EQUIPMENT_DRAW_VENTILATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153527: // BuiltInParameter.MEP_VRF_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153526: // BuiltInParameter.MEP_REHEAT_HOTWATER_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153519: // BuiltInParameter.MEP_ZONE_EQUIPMENT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153518: // BuiltInParameter.MEP_ANALYTICAL_EQUIPMENT_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153517: // BuiltInParameter.MEP_ZONE_HOTWATER_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153516: // BuiltInParameter.MEP_ZONE_AIR_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153514: // BuiltInParameter.MEP_REHEAT_COIL_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153513: // BuiltInParameter.MEP_ZONE_EQUIPMENT_BEHAVIOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153512: // BuiltInParameter.MEP_ZONE_EQUIPMENT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153511: // BuiltInParameter.MEP_AIRLOOP_FANTYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153510: // BuiltInParameter.MEP_CHILLED_WATER_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153509: // BuiltInParameter.MEP_COOLING_COIL_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153508: // BuiltInParameter.MEP_HEATING_HOTWATER_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153507: // BuiltInParameter.MEP_HEATING_COIL_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153506: // BuiltInParameter.MEP_PREHEAT_HOTWATER_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153505: // BuiltInParameter.MEP_AIRLOOP_PREHEAT_COILTYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153504: // BuiltInParameter.MEP_AIRLOOP_HEATEXCHANGER_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153503: // BuiltInParameter.MEP_CONDENSER_WATER_LOOP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153502: // BuiltInParameter.MEP_WATERLOOP_CHILLERTYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153501: // BuiltInParameter.MEP_WATERLOOP_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153500: // BuiltInParameter.MEP_ANALYTICAL_LOOP_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153114: // BuiltInParameter.MEP_IGNORE_FLOW_ANALYSIS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153113: // BuiltInParameter.MEP_ANALYTICAL_LOOP_BOUNDARY_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153112: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ID_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153111: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153110: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ON_STANDBY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153109: // BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ON_DUTY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153106: // BuiltInParameter.MEP_ANALYTICAL_CRITICALPATH_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153100: // BuiltInParameter.MEP_EQUIPMENT_CLASSIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153004: // BuiltInParameter.STRUCTURAL_CONNECTION_INPUT_ELEMENTS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153002: // BuiltInParameter.STRUCTURAL_CONNECTION_CODE_CHECKING_STATUS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1153001: // BuiltInParameter.STRUCTURAL_CONNECTION_APPROVAL_STATUS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152385: // BuiltInParameter.ALL_MODEL_IMAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152384: // BuiltInParameter.ALL_MODEL_TYPE_IMAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152383: // BuiltInParameter.STRUCT_FRAM_JOIN_STATUS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152372: // BuiltInParameter.END_Z_JUSTIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152370: // BuiltInParameter.END_Y_JUSTIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152368: // BuiltInParameter.START_Z_JUSTIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152366: // BuiltInParameter.START_Y_JUSTIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152364: // BuiltInParameter.Z_JUSTIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152362: // BuiltInParameter.Y_JUSTIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152353: //
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152345: // BuiltInParameter.DPART_SHAPE_MODIFIED
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152344: // BuiltInParameter.DPART_EXCLUDED
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152335: // BuiltInParameter.DPART_BASE_LEVEL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1152314: // BuiltInParameter.PHY_MATERIAL_PARAM_STRUCTURAL_THERMAL_TREATED
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151306: // BuiltInParameter.STAIRS_RUN_ACTUAL_NUMBER_OF_TREADS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151305: // BuiltInParameter.STAIRS_RUN_ACTUAL_NUMBER_OF_RISERS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151211: // BuiltInParameter.STAIRSTYPE_INTERMEDIATE_SUPPORT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151210: // BuiltInParameter.STAIRSTYPE_LEFT_SIDE_SUPPORT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151209: // BuiltInParameter.STAIRSTYPE_RIGHT_SIDE_SUPPORT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151208: // BuiltInParameter.STAIRSTYPE_LANDING_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1151207: // BuiltInParameter.STAIRSTYPE_RUN_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150481: // BuiltInParameter.PROPERTY_SET_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150468: // BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150466: // BuiltInParameter.PROPERTY_SET_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150465: // BuiltInParameter.PHY_MATERIAL_PARAM_SUBCLASS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150464: // BuiltInParameter.PHY_MATERIAL_PARAM_CLASS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150435: // BuiltInParameter.RBS_REFERENCE_FREESIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150434: // BuiltInParameter.RBS_REFERENCE_OVERALLSIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150432: // BuiltInParameter.RBS_REFERENCE_LINING_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150430: // BuiltInParameter.RBS_REFERENCE_INSULATION_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150427: // BuiltInParameter.RBS_PIPE_CALCULATED_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150426: // BuiltInParameter.RBS_DUCT_CALCULATED_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150420: // BuiltInParameter.ASSEMBLY_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1150403: // BuiltInParameter.ASSEMBLY_NAMING_CATEGORY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1141012: // BuiltInParameter.FABRICATION_BRA_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1141011: // BuiltInParameter.FABRICATION_SEC_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1141010: // BuiltInParameter.FABRICATION_PRI_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140999: // BuiltInParameter.FABRICATION_FITTING_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140977: // BuiltInParameter.FABRICATION_PART_NOTES
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140975: // BuiltInParameter.FABRICATION_PART_ITEM_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140973: // BuiltInParameter.FABRICATION_SERVICE_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140971: // BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140970: // BuiltInParameter.FABRICATION_PART_CUT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140969: // BuiltInParameter.FABRICATION_PART_BOUGHT_OUT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140968: // BuiltInParameter.FABRICATION_PART_ALIAS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140966: // BuiltInParameter.FABRICATION_PRODUCT_CODE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140920: // BuiltInParameter.FABRICATION_VENDOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140916: // BuiltInParameter.FABRICATION_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140915: // BuiltInParameter.FABRICATION_SPECIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140914: // BuiltInParameter.FABRICATION_VENDOR_CODE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140910: // BuiltInParameter.FABRICATION_PRODUCT_DATA_INSTALL_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140909: // BuiltInParameter.FABRICATION_PART_MATERIAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140908: // BuiltInParameter.FABRICATION_PRODUCT_DATA_OEM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140907: // BuiltInParameter.FABRICATION_PRODUCT_DATA_PRODUCT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140906: // BuiltInParameter.FABRICATION_PRODUCT_DATA_ITEM_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140905: // BuiltInParameter.FABRICATION_PRODUCT_DATA_SIZE_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140904: // BuiltInParameter.FABRICATION_PRODUCT_DATA_MATERIAL_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140903: // BuiltInParameter.FABRICATION_PRODUCT_DATA_SPECIFICATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140902: // BuiltInParameter.FABRICATION_PRODUCT_DATA_LONG_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140901: // BuiltInParameter.FABRICATION_PRODUCT_DATA_RANGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140900: // BuiltInParameter.FABRICATION_PRODUCT_DATA_FINISH_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140702: // BuiltInParameter.TRUSS_ELEMENT_CLASS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140422: // BuiltInParameter.KEYNOTE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140417: // BuiltInParameter.PHY_MATERIAL_PARAM_GRADE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140416: // BuiltInParameter.PHY_MATERIAL_PARAM_SPECIES
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140400: // BuiltInParameter.PHY_MATERIAL_PARAM_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140362: // BuiltInParameter.ELEM_CATEGORY_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140339: // BuiltInParameter.FABRICATION_SERVICE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140336: // BuiltInParameter.RBS_DUCT_SYSTEM_CALCULATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140335: // BuiltInParameter.RBS_PIPE_SYSTEM_CALCULATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140334: // BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140333: // BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140332: // BuiltInParameter.RBS_SYSTEM_ABBREVIATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140327: // BuiltInParameter.RBS_SYSTEM_NUM_ELEMENTS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140326: // BuiltInParameter.RBS_SYSTEM_BASE_ELEMENT_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140325: // BuiltInParameter.RBS_SYSTEM_CLASSIFICATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140324: // BuiltInParameter.RBS_SYSTEM_NAME_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140323: // BuiltInParameter.PHY_MATERIAL_PARAM_LIGHT_WEIGHT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140322: // BuiltInParameter.PHY_MATERIAL_PARAM_BEHAVIOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140279: // BuiltInParameter.RBS_SEGMENT_DESCRIPTION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140278: // BuiltInParameter.RBS_PIPE_JOINTTYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140263: // BuiltInParameter.RBS_FP_SPRINKLER_PRESSURE_CLASS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140262: // BuiltInParameter.RBS_FP_SPRINKLER_ORIFICE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140261: // BuiltInParameter.RBS_FP_SPRINKLER_COVERAGE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140260: // BuiltInParameter.RBS_FP_SPRINKLER_RESPONSE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140218: // BuiltInParameter.RBS_PIPE_FLUID_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140209: // BuiltInParameter.RBS_PIPE_FLOW_STATE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140202: // BuiltInParameter.RBS_PIPE_MATERIAL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140200: // BuiltInParameter.RBS_PIPE_CLASS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140181: // BuiltInParameter.RBS_ELEC_CIRCUIT_SLOT_INDEX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140180: // BuiltInParameter.CIRCUIT_WAYS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140179: // BuiltInParameter.CIRCUIT_LOAD_CLASSIFICATION_ABBREVIATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140178: // BuiltInParameter.CIRCUIT_PHASE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140176: // BuiltInParameter.RBS_ELEC_CIRCUIT_CONNECTION_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140169: // BuiltInParameter.RBS_ELEC_PANEL_LOCATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140156: // BuiltInParameter.RBS_ELEC_CIRCUIT_NOTES_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140155: // BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER_OF_ELEMENTS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140150: // BuiltInParameter.RBS_ELEC_PANEL_SCHEDULE_FOOTER_NOTES_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140149: // BuiltInParameter.RBS_ELEC_PANEL_SCHEDULE_HEADER_NOTES_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140148: // BuiltInParameter.RBS_ELEC_PANEL_NUMWIRES_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140147: // BuiltInParameter.RBS_ELEC_PANEL_NUMPHASES_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140145: // BuiltInParameter.RBS_ELEC_PANEL_NEUTRAL_BUS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140144: // BuiltInParameter.RBS_ELEC_PANEL_GROUND_BUS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140143: // BuiltInParameter.RBS_ELEC_PANEL_BUSSING_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140142: // BuiltInParameter.RBS_ELEC_PANEL_SUBFEED_LUGS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140141: // BuiltInParameter.RBS_ELEC_PANEL_SUPPLY_FROM_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140139: // BuiltInParameter.RBS_ELEC_PANEL_MAINSTYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140138: // BuiltInParameter.RBS_ELEC_PANEL_FEED_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140129: // BuiltInParameter.RBS_CABLETRAYCONDUIT_BENDORFITTING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140128: // BuiltInParameter.RBS_CTC_SERVICE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140120: // BuiltInParameter.CIRCUIT_LOAD_CLASSIFICATION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140118: // BuiltInParameter.CONDUIT_STANDARD_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140110: // BuiltInParameter.RBS_ELEC_SWITCH_ID_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140104: // BuiltInParameter.RBS_ELEC_CIRCUIT_PANEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140103: // BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140101: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_RUNS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140100: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_HOTS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140099: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_NEUTRALS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140098: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_GROUNDS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140089: // BuiltInParameter.RBS_ELEC_CIRCUIT_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140084: // BuiltInParameter.RBS_ELEC_MODIFICATIONS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140083: // BuiltInParameter.RBS_ELEC_ENCLOSURE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140081: // BuiltInParameter.RBS_ELEC_MOUNTING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140080: // BuiltInParameter.RBS_ELEC_SHORT_CIRCUIT_RATING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140079: // BuiltInParameter.RBS_ELEC_MAX_POLE_BREAKERS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140078: // BuiltInParameter.RBS_ELEC_PANEL_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140037: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_SIZE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140036: // BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140018: // BuiltInParameter.RBS_ELEC_CIRCUIT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140009: // BuiltInParameter.RBS_ELEC_POWER_FACTOR_STATE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140003: // BuiltInParameter.RBS_ELEC_BALANCED_LOAD
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1140001: // BuiltInParameter.RBS_ELEC_NUMBER_OF_POLES
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1133500: // BuiltInParameter.GROUP_LEVEL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114817: // BuiltInParameter.SPACE_REFERENCE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114705: // BuiltInParameter.SYSTEM_ZONE_LEVEL_ID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114700: // BuiltInParameter.ZONE_SPACE_OUTDOOR_AIR_OPTION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114400: // BuiltInParameter.RBS_GBXML_OPENING_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114384: // BuiltInParameter.SPACE_ZONE_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114341: // BuiltInParameter.ZONE_USE_AIR_CHANGES_PER_HOUR_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114340: // BuiltInParameter.ZONE_USE_OUTSIDE_AIR_PER_AREA_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114339: // BuiltInParameter.ZONE_USE_OUTSIDE_AIR_PER_PERSON_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114338: // BuiltInParameter.ZONE_USE_DEHUMIDIFICATION_SETPOINT_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114337: // BuiltInParameter.ZONE_USE_HUMIDIFICATION_SETPOINT_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114330: // BuiltInParameter.SPACE_IS_PLENUM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114329: // BuiltInParameter.SPACE_IS_OCCUPIABLE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114327: // BuiltInParameter.SPACE_ASSOC_ROOM_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114317: // BuiltInParameter.ZONE_LEVEL_ID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114304: // BuiltInParameter.ZONE_SERVICE_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114300: // BuiltInParameter.ZONE_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114259: // BuiltInParameter.ROOM_BASE_HEAT_LOAD_ON_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114258: // BuiltInParameter.ROOM_LIGHTING_LOAD_UNITS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114257: // BuiltInParameter.ROOM_POWER_LOAD_UNITS_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114252: // BuiltInParameter.ROOM_BASE_RETURN_AIRFLOW_ON_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114251: // BuiltInParameter.ROOM_CONSTRUCTION_SET_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114246: // BuiltInParameter.RBS_GBXML_SURFACE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114241: // BuiltInParameter.RBS_ELECTRICAL_DATA
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114240: // BuiltInParameter.RBS_CALCULATED_SIZE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114224: // BuiltInParameter.ROOM_BASE_LIGHTING_LOAD_ON_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114223: // BuiltInParameter.ROOM_BASE_POWER_LOAD_ON_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114173: // BuiltInParameter.ROOM_OCCUPANCY_UNIT_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114172: // BuiltInParameter.ROOM_SPACE_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114171: // BuiltInParameter.ROOM_CONDITION_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114167: // BuiltInParameter.RBS_SIZE_LOCK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1114125: // BuiltInParameter.RBS_SECTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019100: // BuiltInParameter.WALL_CROSS_SECTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019011: // BuiltInParameter.IFC_ORGANIZATION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019010: // BuiltInParameter.IFC_APPLICATION_VERSION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019009: // BuiltInParameter.IFC_APPLICATION_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019008: // BuiltInParameter.PROJECT_ORGANIZATION_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019007: // BuiltInParameter.PROJECT_ORGANIZATION_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019006: // BuiltInParameter.PROJECT_BUILDING_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019005: // BuiltInParameter.PROJECT_AUTHOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019004: // BuiltInParameter.IFC_SITE_GUID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019003: // BuiltInParameter.IFC_BUILDING_GUID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019002: // BuiltInParameter.IFC_PROJECT_GUID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019001: // BuiltInParameter.IFC_TYPE_GUID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019000: // BuiltInParameter.IFC_GUID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018362: // BuiltInParameter.PATH_REIN_SHAPE_2
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018361: // BuiltInParameter.PATH_REIN_SHAPE_1
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018354: // BuiltInParameter.PATH_REIN_SUMMARY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018306: // BuiltInParameter.PATH_REIN_TYPE_2
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018305: // BuiltInParameter.PATH_REIN_TYPE_1
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018304: // BuiltInParameter.PATH_REIN_ALTERNATING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018303: // BuiltInParameter.PATH_REIN_NUMBER_OF_BARS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018300: // BuiltInParameter.PATH_REIN_FACE_SLAB
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018274: // BuiltInParameter.REBAR_BAR_DEFORMATION_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018269: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_2_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018268: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_1_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018267: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_2_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018266: // BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_1_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018257: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_2_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018256: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_1_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018255: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_2_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018254: // BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_1_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018253: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_2_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018252: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_1_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018251: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_2_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018250: // BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_1_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018023: // BuiltInParameter.REBAR_SYSTEM_TOP_MINOR_MATCHES_BOTTOM_MINOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018022: // BuiltInParameter.REBAR_SYSTEM_TOP_MAJOR_MATCHES_BOTTOM_MAJOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018021: // BuiltInParameter.REBAR_SYSTEM_BOTTOM_MAJOR_MATCHES_BOTTOM_MINOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018020: // BuiltInParameter.REBAR_SYSTEM_TOP_MAJOR_MATCHES_TOP_MINOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018019: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_2_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018018: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_2_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018017: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_1_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018016: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_1_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018015: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_2_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018014: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_2_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018013: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_1_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018012: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_1_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018011: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_2_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018010: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_2_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018009: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_1_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018008: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_1_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018003: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_NO_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018002: // BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_WITH_SPACING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1018001: // BuiltInParameter.REBAR_SYSTEM_LAYOUT_RULE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017736: // BuiltInParameter.FABRIC_WIRE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017733: // BuiltInParameter.FABRIC_PARAM_SHARED_FAMILY_KEY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017705: // BuiltInParameter.FABRIC_PARAM_LOCATION_GENERIC
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017701: // BuiltInParameter.FABRIC_PARAM_SHEET_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017619: // BuiltInParameter.FABRIC_SHEET_MINOR_NUMBER_OF_WIRES
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017612: // BuiltInParameter.FABRIC_SHEET_MAJOR_NUMBER_OF_WIRES
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017604: // BuiltInParameter.FABRIC_SHEET_MINOR_DIRECTION_WIRE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017603: // BuiltInParameter.FABRIC_SHEET_MAJOR_DIRECTION_WIRE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017602: // BuiltInParameter.FABRIC_SHEET_PHYSICAL_MATERIAL_ASSET
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017065: // BuiltInParameter.REBAR_QUANITY_BY_DISTRIB
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017062: // BuiltInParameter.REBAR_MAXIM_SUFFIX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017061: // BuiltInParameter.REBAR_MINIM_SUFFIX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017060: // BuiltInParameter.REBAR_NUMBER_SUFFIX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017055: // BuiltInParameter.REBAR_HOST_CATEGORY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017047: // BuiltInParameter.REBAR_INSTANCE_STIRRUP_TIE_ATTACHMENT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017032: // BuiltInParameter.REBAR_ELEM_SCHEDULE_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017026: // BuiltInParameter.REBAR_ELEM_HOOK_STYLE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017015: // BuiltInParameter.REBAR_SHAPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017012: // BuiltInParameter.REBAR_ELEM_QUANTITY_OF_BARS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017008: // BuiltInParameter.REBAR_ELEM_HOOK_END_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1017006: // BuiltInParameter.REBAR_ELEM_HOOK_START_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015084: // BuiltInParameter.LOAD_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015083: // BuiltInParameter.LOAD_COMMENTS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015082: // BuiltInParameter.LOAD_CASE_NATURE_TEXT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015005: // BuiltInParameter.LOAD_IS_REACTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015003: // BuiltInParameter.LOAD_IS_UNIFORM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015001: // BuiltInParameter.LOAD_USE_LOCAL_COORDINATE_SYSTEM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1015000: // BuiltInParameter.LOAD_CASE_ID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013451: // BuiltInParameter.ANALYTICAL_GEOMETRY_IS_VALID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013450: // BuiltInParameter.STRUCTURAL_ASSET_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013446: // BuiltInParameter.ANALYTICAL_MODEL_NODES_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013445: // BuiltInParameter.ANALYTICAL_MODEL_FOUNDATIONS_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013444: // BuiltInParameter.ANALYTICAL_MODEL_SURFACE_ELEMENTS_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013443: // BuiltInParameter.ANALYTICAL_MODEL_STICK_ELEMENTS_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013419: // BuiltInParameter.JOIST_SYSTEM_NEW_BEAM_TYPE_NO_FAM_NAME_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013411: // BuiltInParameter.JOIST_SYSTEM_NEW_BEAM_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1013410: // BuiltInParameter.JOIST_SYSTEM_LAYOUT_RULE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012837: // BuiltInParameter.SLAB_EDGE_PROFILE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012836: // BuiltInParameter.GUTTER_PROFILE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012819: // BuiltInParameter.FASCIA_PROFILE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012809: // BuiltInParameter.WALL_SWEEP_WALL_SUBCATEGORY_ID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012800: // BuiltInParameter.WALL_SWEEP_PROFILE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012619: // BuiltInParameter.PROPERTY_SEGMENT_L_R
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012617: // BuiltInParameter.PROPERTY_SEGMENT_E_W
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012615: // BuiltInParameter.PROPERTY_SEGMENT_N_S
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012201: // BuiltInParameter.DATUM_VOLUME_OF_INTEREST
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012101: // BuiltInParameter.PHASE_DEMOLISHED
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012100: // BuiltInParameter.PHASE_CREATED
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012098: // BuiltInParameter.MASS_DATA_SLAB
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012045: // BuiltInParameter.MASS_DATA_SURFACE_DATA_SOURCE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012040: // BuiltInParameter.MASS_DATA_GLAZING_IS_SHADED
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012038: // BuiltInParameter.MASS_DATA_UNDERGROUND
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012031: // BuiltInParameter.MASS_DATA_SUBCATEGORY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012030: // BuiltInParameter.MASS_DATA_CONCEPTUAL_CONSTRUCTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012027: // BuiltInParameter.MASS_ZONE_CONDITION_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012026: // BuiltInParameter.MASS_ZONE_SPACE_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012023: // BuiltInParameter.MASS_SURFACEDATA_MATERIAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012022: // BuiltInParameter.MASS_ZONE_MATERIAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012020: // BuiltInParameter.LEVEL_DATA_MASS_TYPE_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012019: // BuiltInParameter.LEVEL_DATA_MASS_INSTANCE_COMMENTS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012018: // BuiltInParameter.LEVEL_DATA_MASS_TYPE_COMMENTS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012017: // BuiltInParameter.LEVEL_DATA_MASS_FAMILY_AND_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012016: // BuiltInParameter.LEVEL_DATA_MASS_FAMILY_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012015: // BuiltInParameter.LEVEL_DATA_SPACE_USAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012014: // BuiltInParameter.LEVEL_DATA_OWNING_LEVEL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1012013: // BuiltInParameter.LEVEL_DATA_MASS_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1011955: // BuiltInParameter.PROJECT_REVISION_REVISION_ISSUED_BY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1011954: // BuiltInParameter.PROJECT_REVISION_REVISION_ISSUED_TO
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010707: // BuiltInParameter.PLUMBING_FIXTURES_VENT_CONNECTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010706: // BuiltInParameter.PLUMBING_FIXTURES_WASTE_CONNECTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010705: // BuiltInParameter.PLUMBING_FIXTURES_CW_CONNECTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010704: // BuiltInParameter.PLUMBING_FIXTURES_HW_CONNECTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010703: // BuiltInParameter.PLUMBING_FIXTURES_TRAP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010702: // BuiltInParameter.PLUMBING_FIXTURES_DRAIN
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010701: // BuiltInParameter.PLUMBING_FIXTURES_SUPPLY_PIPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010700: // BuiltInParameter.PLUMBING_FIXTURES_SUPPLY_FITTING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010501: // BuiltInParameter.LIGHTING_FIXTURE_LAMP
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010500: // BuiltInParameter.LIGHTING_FIXTURE_WATTAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010401: // BuiltInParameter.ELECTICAL_EQUIP_VOLTAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010400: // BuiltInParameter.ELECTICAL_EQUIP_WATTAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010109: // BuiltInParameter.ALL_MODEL_MODEL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010108: // BuiltInParameter.ALL_MODEL_MANUFACTURER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010106: // BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010105: // BuiltInParameter.ALL_MODEL_TYPE_COMMENTS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010104: // BuiltInParameter.ALL_MODEL_URL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1010103: // BuiltInParameter.ALL_MODEL_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009530: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_Z
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009529: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_Y
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009528: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_X
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009527: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_Z
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009526: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_Y
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009525: // BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_X
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1009524: // BuiltInParameter.ANALYTICAL_MODEL_PHYSICAL_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1008620: // BuiltInParameter.STAIRS_RAILING_BASE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1008000: // BuiltInParameter.DATUM_TEXT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007721: // BuiltInParameter.RVT_LINK_INSTANCE_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007246: // BuiltInParameter.STAIRS_ACTUAL_NUM_RISERS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007235: // BuiltInParameter.STAIRS_MULTISTORY_TOP_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007201: // BuiltInParameter.STAIRS_TOP_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007200: // BuiltInParameter.STAIRS_BASE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007112: // BuiltInParameter.LEVEL_IS_STRUCTURAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007111: // BuiltInParameter.LEVEL_IS_BUILDING_STORY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007110: // BuiltInParameter.LEVEL_UP_TO_LEVEL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1007109: // BuiltInParameter.LEVEL_RELATIVE_BASE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006922: // BuiltInParameter.ROOM_UPPER_LEVEL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006916: // BuiltInParameter.ROOM_LEVEL_ID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006909: // BuiltInParameter.ROOM_OCCUPANCY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006907: // BuiltInParameter.ROOM_DEPARTMENT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006906: // BuiltInParameter.ROOM_FINISH_BASE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006905: // BuiltInParameter.ROOM_FINISH_CEILING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006904: // BuiltInParameter.ROOM_FINISH_WALL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006903: // BuiltInParameter.ROOM_FINISH_FLOOR
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006901: // BuiltInParameter.ROOM_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006900: // BuiltInParameter.ROOM_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006321: // BuiltInParameter.PROJECT_ISSUE_DATE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006320: // BuiltInParameter.PROJECT_STATUS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006319: // BuiltInParameter.CLIENT_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006317: // BuiltInParameter.PROJECT_NAME
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006316: // BuiltInParameter.PROJECT_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1006210: // BuiltInParameter.BUILDING_CURVE_GSTYLE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1005554: // BuiltInParameter.STRUCTURAL_SECTION_NAME_KEY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1005501: // BuiltInParameter.STRUCTURAL_SECTION_SHAPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1005500: // BuiltInParameter.STRUCTURAL_MATERIAL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1005436: // BuiltInParameter.ANALYTICAL_ROUGHNESS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1004011: // BuiltInParameter.CURVE_IS_DETAIL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002563: // BuiltInParameter.COLUMN_LOCATION_MARK
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002503: // BuiltInParameter.OMNICLASS_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002502: // BuiltInParameter.OMNICLASS_CODE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002501: // BuiltInParameter.UNIFORMAT_DESCRIPTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002500: // BuiltInParameter.UNIFORMAT_CODE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002107: // BuiltInParameter.MATERIAL_ID_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002064: // BuiltInParameter.SCHEDULE_TOP_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002063: // BuiltInParameter.SCHEDULE_BASE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002062: // BuiltInParameter.SCHEDULE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002052: // BuiltInParameter.ELEM_FAMILY_AND_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002051: // BuiltInParameter.ELEM_FAMILY_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002050: // BuiltInParameter.ELEM_TYPE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001954: // BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001708: // BuiltInParameter.ROOF_BASE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001597: // BuiltInParameter.NODE_CONNECTION_STATUS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001577: // BuiltInParameter.STRUCTURAL_FLOOR_ANALYZES_AS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001576: // BuiltInParameter.STRUCTURAL_ANALYZES_AS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001563: // BuiltInParameter.CONTINUOUS_FOOTING_STRUCTURAL_USAGE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001549: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001548: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001547: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001546: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001545: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001544: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001543: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_MZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001542: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_MY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001541: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_MX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001540: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_FZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001539: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_FY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001538: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_FX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001537: // BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001536: // BuiltInParameter.STRUCTURAL_TOP_RELEASE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001530: // BuiltInParameter.STRUCTURAL_CAMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001529: // BuiltInParameter.STRUCTURAL_NUMBER_OF_STUDS
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001528: // BuiltInParameter.STRUCTURAL_END_RELEASE_MZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001527: // BuiltInParameter.STRUCTURAL_END_RELEASE_MY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001526: // BuiltInParameter.STRUCTURAL_END_RELEASE_MX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001525: // BuiltInParameter.STRUCTURAL_END_RELEASE_FZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001524: // BuiltInParameter.STRUCTURAL_END_RELEASE_FY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001523: // BuiltInParameter.STRUCTURAL_END_RELEASE_FX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001522: // BuiltInParameter.STRUCTURAL_START_RELEASE_MZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001521: // BuiltInParameter.STRUCTURAL_START_RELEASE_MY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001520: // BuiltInParameter.STRUCTURAL_START_RELEASE_MX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001519: // BuiltInParameter.STRUCTURAL_START_RELEASE_FZ
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001518: // BuiltInParameter.STRUCTURAL_START_RELEASE_FY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001517: // BuiltInParameter.STRUCTURAL_START_RELEASE_FX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001516: // BuiltInParameter.STRUCTURAL_END_RELEASE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001515: // BuiltInParameter.STRUCTURAL_START_RELEASE_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001405: // BuiltInParameter.ALL_MODEL_TYPE_MARK, BuiltInParameter.WINDOW_TYPE_ID
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001383: // BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001381: // BuiltInParameter.INSTANCE_STRUCT_USAGE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001211: // BuiltInParameter.DOOR_OPERATION_TYPE, BuiltInParameter.WINDOW_OPERATION_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001210: // BuiltInParameter.DOOR_FRAME_MATERIAL
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001209: // BuiltInParameter.DOOR_FRAME_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001208
                    : // BuiltInParameter.CASEWORK_FINISH, BuiltInParameter.CURTAIN_WALL_PANELS_FINISH, BuiltInParameter.DOOR_FINISH, BuiltInParameter.GENERIC_FINISH
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001207
                    : // BuiltInParameter.CASEWORK_CONSTRUCTION_TYPE, BuiltInParameter.CURTAIN_WALL_PANELS_CONSTRUCTION_TYPE, BuiltInParameter.DOOR_CONSTRUCTION_TYPE, BuiltInParameter.GENERIC_CONSTRUCTION_TYPE, BuiltInParameter.WINDOW_CONSTRUCTION_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001206: // BuiltInParameter.DOOR_FIRE_RATING, BuiltInParameter.FIRE_RATING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001203: // BuiltInParameter.ALL_MODEL_MARK, BuiltInParameter.DOOR_NUMBER
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001139: // BuiltInParameter.DPART_LAYER_CONSTRUCTION
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001132: // BuiltInParameter.DPART_ORIGINAL_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001127: // BuiltInParameter.DPART_MATERIAL_ID_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001126: // BuiltInParameter.DPART_ORIGINAL_FAMILY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001125: // BuiltInParameter.DPART_ORIGINAL_CATEGORY
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001119: // BuiltInParameter.WALL_STRUCTURAL_USAGE_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001107: // BuiltInParameter.WALL_BASE_CONSTRAINT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001103: // BuiltInParameter.WALL_HEIGHT_TYPE
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001007: // BuiltInParameter.WALL_ATTR_ROOM_BOUNDING
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1001006: // BuiltInParameter.FUNCTION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;

                case -1155217: // BuiltInParameter.REBAR_HOOK_ROTATION_AT_END_SCHEDULES_TAGS_FILTERS
                    return SpecTypeId.Angle;
                case -1155216: // BuiltInParameter.REBAR_HOOK_ROTATION_AT_START_SCHEDULES_TAGS_FILTERS
                    return SpecTypeId.Angle;
                case -1155212: // BuiltInParameter.INFRASTRUCTURE_ALIGNMENT_DISPLAYED_START_STATION
                    return SpecTypeId.Stationing;
                case -1155211: // BuiltInParameter.INFRASTRUCTURE_ALIGNMENT_DISPLAYED_END_STATION
                    return SpecTypeId.Stationing;
                case -1155148: // BuiltInParameter.STEEL_ELEM_PROFILE_VOLUME
                    return SpecTypeId.Volume;
                case -1155147: // BuiltInParameter.STEEL_ELEM_PROFILE_LENGTH
                    return SpecTypeId.Length;
                case -1155144: // BuiltInParameter.STEEL_ELEM_PLATE_JUSTIFICATION
                    return SpecTypeId.Number;
                case -1155143: // BuiltInParameter.STEEL_ELEM_PLATE_PAINT_AREA
                    return SpecTypeId.Area;
                case -1155142: // BuiltInParameter.STEEL_ELEM_PLATE_EXACT_WEIGHT
                    return SpecTypeId.Mass;
                case -1155141: // BuiltInParameter.STEEL_ELEM_PLATE_WEIGHT
                    return SpecTypeId.Mass;
                case -1155140: // BuiltInParameter.STEEL_ELEM_PLATE_VOLUME
                    return SpecTypeId.Volume;
                case -1155139: // BuiltInParameter.STEEL_ELEM_PLATE_AREA
                    return SpecTypeId.Area;
                case -1155138: // BuiltInParameter.STEEL_ELEM_PLATE_WIDTH
                    return SpecTypeId.Length;
                case -1155137: // BuiltInParameter.STEEL_ELEM_PLATE_LENGTH
                    return SpecTypeId.Length;
                case -1155135: // BuiltInParameter.STEEL_ELEM_BOLT_TOTAL_WEIGHT
                    return SpecTypeId.Mass;
                case -1155134: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_TOTAL_WEIGHT
                    return SpecTypeId.Mass;
                case -1155132: // BuiltInParameter.STEEL_ELEM_ANCHOR_TOTAL_WEIGHT
                    return SpecTypeId.Mass;
                case -1155128: // BuiltInParameter.STEEL_ELEM_CUT_LENGTH
                    return SpecTypeId.Length;
                case -1155127: // BuiltInParameter.STEEL_ELEM_EXACT_WEIGHT
                    return SpecTypeId.Mass;
                case -1155125: // BuiltInParameter.STEEL_ELEM_PAINT_AREA
                    return SpecTypeId.Area;
                case -1155124: // BuiltInParameter.STEEL_ELEM_WEIGHT
                    return SpecTypeId.Mass;
                case -1155123: // BuiltInParameter.PATH_OF_TRAVEL_SPEED
                    return SpecTypeId.Speed;
                case -1155119: // BuiltInParameter.STEEL_ELEM_BOLT_GRIP_LENGTH_INCREASE
                    return SpecTypeId.Length;
                case -1155118: // BuiltInParameter.STEEL_ELEM_BOLT_GRIP_LENGTH
                    return SpecTypeId.Length;
                case -1155117: // BuiltInParameter.STEEL_ELEM_BOLT_LENGTH
                    return SpecTypeId.Length;
                case -1155115: // BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION
                    return SpecTypeId.Length;
                case -1155114: // BuiltInParameter.RBS_PIPE_TOP_ELEVATION
                    return SpecTypeId.Length;
                case -1155113: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEC
                    return SpecTypeId.Current;
                case -1155112: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEB
                    return SpecTypeId.Current;
                case -1155111: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEA
                    return SpecTypeId.Current;
                case -1155110: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEC
                    return SpecTypeId.ApparentPower;
                case -1155109: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEB
                    return SpecTypeId.ApparentPower;
                case -1155108: // BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEA
                    return SpecTypeId.ApparentPower;
                case -1155107: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEC
                    return SpecTypeId.Current;
                case -1155106: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEB
                    return SpecTypeId.Current;
                case -1155105: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEA
                    return SpecTypeId.Current;
                case -1155104: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEC
                    return SpecTypeId.ApparentPower;
                case -1155103: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEB
                    return SpecTypeId.ApparentPower;
                case -1155102: // BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEA
                    return SpecTypeId.ApparentPower;
                case -1155090: // BuiltInParameter.PATH_OF_TRAVEL_TIME
                    return SpecTypeId.Time;
                case -1155059: // BuiltInParameter.STEEL_ELEM_PATTERN_RADIUS
                    return SpecTypeId.Length;
                case -1155058: // BuiltInParameter.STEEL_ELEM_PATTERN_EDGE_DISTANCE_Y
                    return SpecTypeId.Length;
                case -1155057: // BuiltInParameter.STEEL_ELEM_PATTERN_EDGE_DISTANCE_X
                    return SpecTypeId.Length;
                case -1155056: // BuiltInParameter.STEEL_ELEM_PATTERN_INTERMEDIATE_DISTANCE_Y
                    return SpecTypeId.Length;
                case -1155055: // BuiltInParameter.STEEL_ELEM_PATTERN_INTERMEDIATE_DISTANCE_X
                    return SpecTypeId.Length;
                case -1155054: // BuiltInParameter.STEEL_ELEM_PATTERN_TOTAL_WIDTH
                    return SpecTypeId.Length;
                case -1155053: // BuiltInParameter.STEEL_ELEM_PATTERN_TOTAL_LENGTH
                    return SpecTypeId.Length;
                case -1155050: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_PREPDEPTH
                    return SpecTypeId.Length;
                case -1155049: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_EFFECTIVETHROAT
                    return SpecTypeId.Length;
                case -1155048: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_ROOTOPENING
                    return SpecTypeId.Length;
                case -1155044: // BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_THICKNESS
                    return SpecTypeId.Length;
                case -1155042: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_PREPDEPTH
                    return SpecTypeId.Length;
                case -1155041: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_EFFECTIVETHROAT
                    return SpecTypeId.Length;
                case -1155040: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_ROOTOPENING
                    return SpecTypeId.Length;
                case -1155036: // BuiltInParameter.STEEL_ELEM_WELD_PITCH
                    return SpecTypeId.Length;
                case -1155033: // BuiltInParameter.STEEL_ELEM_WELD_LENGTH
                    return SpecTypeId.Length;
                case -1155032: // BuiltInParameter.STEEL_ELEM_WELD_MAIN_THICKNESS
                    return SpecTypeId.Length;
                case -1155019: // BuiltInParameter.STEEL_ELEM_SHEARSTUD_LENGTH
                    return SpecTypeId.Length;
                case -1155003: // BuiltInParameter.STEEL_ELEM_PLATE_THICKNESS
                    return SpecTypeId.Length;
                case -1154689: // BuiltInParameter.ROOM_OUTDOOR_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1154671: // BuiltInParameter.ROOM_AIR_CHANGES_PER_HOUR_PARAM
                    return SpecTypeId.Number;
                case -1154668: // BuiltInParameter.ROOM_OUTDOOR_AIR_PER_AREA_PARAM
                    return SpecTypeId.AirFlowDensity;
                case -1154665: // BuiltInParameter.ROOM_OUTDOOR_AIR_PER_PERSON_PARAM
                    return SpecTypeId.AirFlow;
                case -1154651: // BuiltInParameter.COUPLER_WIDTH
                    return SpecTypeId.Length;
                case -1154646: // BuiltInParameter.COUPLER_COUPLED_ENGAGEMENT
                    return SpecTypeId.Length;
                case -1154645: // BuiltInParameter.COUPLER_MAIN_ENGAGEMENT
                    return SpecTypeId.Length;
                case -1154644: // BuiltInParameter.COUPLER_LENGTH
                    return SpecTypeId.Length;
                case -1154643: // BuiltInParameter.COUPLER_WEIGHT
                    return SpecTypeId.Mass;
                case -1153104: // BuiltInParameter.MEP_EQUIPMENT_CALC_PIPINGPRESSUREDROP_PARAM
                    return SpecTypeId.PipingPressure;
                case -1153103: // BuiltInParameter.MEP_EQUIPMENT_CALC_PIPINGFLOW_PARAM
                    return SpecTypeId.Flow;
                case -1152373: // BuiltInParameter.END_Z_OFFSET_VALUE
                    return SpecTypeId.Length;
                case -1152371: // BuiltInParameter.END_Y_OFFSET_VALUE
                    return SpecTypeId.Length;
                case -1152369: // BuiltInParameter.START_Z_OFFSET_VALUE
                    return SpecTypeId.Length;
                case -1152367: // BuiltInParameter.START_Y_OFFSET_VALUE
                    return SpecTypeId.Length;
                case -1152365: // BuiltInParameter.Z_OFFSET_VALUE
                    return SpecTypeId.Length;
                case -1152363: // BuiltInParameter.Y_OFFSET_VALUE
                    return SpecTypeId.Length;
                case -1152360: // BuiltInParameter.END_JOIN_CUTBACK
                    return SpecTypeId.Length;
                case -1152359: // BuiltInParameter.START_JOIN_CUTBACK
                    return SpecTypeId.Length;
                case -1152358: // BuiltInParameter.END_EXTENSION
                    return SpecTypeId.Length;
                case -1152357: // BuiltInParameter.START_EXTENSION
                    return SpecTypeId.Length;
                case -1152313: // BuiltInParameter.PHY_MATERIAL_PARAM_STRUCTURAL_DENSITY
                    return SpecTypeId.MassDensity;
                case -1152300: // BuiltInParameter.STAIRS_RAILING_PLACEMENT_OFFSET
                    return SpecTypeId.Length;
                case -1152166: // BuiltInParameter.SUPPORT_HEIGHT
                    return SpecTypeId.Length;
                case -1152165: // BuiltInParameter.SUPPORT_HAND_CLEARANCE
                    return SpecTypeId.Length;
                case -1151810: // BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH_ON_LANDING
                    return SpecTypeId.Length;
                case -1151809: // BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH_ON_RUN
                    return SpecTypeId.Length;
                case -1151807: // BuiltInParameter.STAIRS_SUPPORTTYPE_WIDTH
                    return SpecTypeId.Length;
                case -1151806: // BuiltInParameter.STAIRS_SUPPORTTYPE_TOTAL_DEPTH
                    return SpecTypeId.Length;
                case -1151603: // BuiltInParameter.STAIRS_LANDINGTYPE_THICKNESS
                    return SpecTypeId.Length;
                case -1151404: // BuiltInParameter.STAIRS_RUNTYPE_STRUCTURAL_DEPTH
                    return SpecTypeId.Length;
                case -1151309: // BuiltInParameter.STAIRS_RUN_ACTUAL_RUN_WIDTH
                    return SpecTypeId.Length;
                case -1151308: // BuiltInParameter.STAIRS_RUN_ACTUAL_TREAD_DEPTH
                    return SpecTypeId.Length;
                case -1151307: // BuiltInParameter.STAIRS_RUN_ACTUAL_RISER_HEIGHT
                    return SpecTypeId.Length;
                case -1151303: // BuiltInParameter.STAIRS_RUN_HEIGHT
                    return SpecTypeId.Length;
                case -1150501: // BuiltInParameter.ANALYTICAL_MODEL_ROTATION
                    return SpecTypeId.Angle;
                case -1150463: // BuiltInParameter.ANALYTICAL_MODEL_PERIMETER
                    return SpecTypeId.Length;
                case -1150462: // BuiltInParameter.ANALYTICAL_MODEL_AREA
                    return SpecTypeId.Area;
                case -1150461: // BuiltInParameter.ANALYTICAL_MODEL_LENGTH
                    return SpecTypeId.Length;
                case -1150433: // BuiltInParameter.RBS_REFERENCE_LINING_THICKNESS
                    return SpecTypeId.DuctLiningThickness;
                case -1150431: // BuiltInParameter.RBS_REFERENCE_INSULATION_THICKNESS
                    return SpecTypeId.DuctInsulationThickness;
                case -1150425: // BuiltInParameter.RBS_INSULATION_LINING_VOLUME
                    return SpecTypeId.Volume;
                case -1150188: // BuiltInParameter.ROOM_PLENUM_LIGHTING_PARAM
                    return SpecTypeId.Factor;
                case -1150115: // BuiltInParameter.FBX_LIGHT_LUMENAIRE_DIRT
                    return SpecTypeId.Number;
                case -1150114: // BuiltInParameter.FBX_LIGHT_LAMP_LUMEN_DEPR
                    return SpecTypeId.Number;
                case -1150113: // BuiltInParameter.FBX_LIGHT_SURFACE_LOSS
                    return SpecTypeId.Number;
                case -1150112: // BuiltInParameter.FBX_LIGHT_LAMP_TILT_LOSS
                    return SpecTypeId.Number;
                case -1150110: // BuiltInParameter.FBX_LIGHT_VOLTAGE_LOSS
                    return SpecTypeId.Number;
                case -1150109: // BuiltInParameter.FBX_LIGHT_TEMPERATURE_LOSS
                    return SpecTypeId.Number;
                case -1150107: // BuiltInParameter.FBX_LIGHT_INITIAL_COLOR_TEMPERATURE
                    return SpecTypeId.ColorTemperature;
                case -1150106: // BuiltInParameter.FBX_LIGHT_ILLUMINANCE
                    return SpecTypeId.Illuminance;
                case -1150105: // BuiltInParameter.FBX_LIGHT_LIMUNOUS_INTENSITY
                    return SpecTypeId.LuminousIntensity;
                case -1150104: // BuiltInParameter.FBX_LIGHT_EFFICACY
                    return SpecTypeId.Efficacy;
                case -1150103: // BuiltInParameter.FBX_LIGHT_WATTAGE
                    return SpecTypeId.Wattage;
                case -1144331: // BuiltInParameter.RBS_ELEC_ROOM_LIGHTING_CALC_LUMINAIREPLANE
                    return SpecTypeId.Length;
                case -1140983: // BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL_AREA
                    return SpecTypeId.Area;
                case -1140981: // BuiltInParameter.FABRICATION_PART_SHEETMETAL_AREA
                    return SpecTypeId.Area;
                case -1140978: // BuiltInParameter.FABRICATION_PART_MATERIAL_THICKNESS
                    return SpecTypeId.PipeDimension;
                case -1140976: // BuiltInParameter.FABRICATION_PART_LINING_AREA
                    return SpecTypeId.Area;
                case -1140974: // BuiltInParameter.FABRICATION_PART_INSULATION_AREA
                    return SpecTypeId.Area;
                case -1140972: // BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL_THICKNESS
                    return SpecTypeId.PipeDimension;
                case -1140944: // BuiltInParameter.FABRICATION_PART_LENGTH
                    return SpecTypeId.Length;
                case -1140935: // BuiltInParameter.FABRICATION_PART_DEPTH_OUT
                    return SpecTypeId.PipeDimension;
                case -1140934: // BuiltInParameter.FABRICATION_PART_WIDTH_OUT
                    return SpecTypeId.PipeDimension;
                case -1140933: // BuiltInParameter.FABRICATION_PART_DIAMETER_OUT
                    return SpecTypeId.PipeDimension;
                case -1140930: // BuiltInParameter.FABRICATION_PART_DEPTH_IN
                    return SpecTypeId.PipeDimension;
                case -1140929: // BuiltInParameter.FABRICATION_PART_WIDTH_IN
                    return SpecTypeId.PipeDimension;
                case -1140919: // BuiltInParameter.FABRICATION_BOTTOM_OF_PART
                    return SpecTypeId.Length;
                case -1140918: // BuiltInParameter.FABRICATION_TOP_OF_PART
                    return SpecTypeId.Length;
                case -1140913: // BuiltInParameter.FABRICATION_PART_WEIGHT
                    return SpecTypeId.PipingMass;
                case -1140912: // BuiltInParameter.FABRICATION_PART_DIAMETER_IN
                    return SpecTypeId.PipeDimension;
                case -1140911: // BuiltInParameter.FABRICATION_PART_ANGLE
                    return SpecTypeId.Angle;
                case -1140415: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF
                    return SpecTypeId.ThermalExpansionCoefficient;
                case -1140414: // BuiltInParameter.PHY_MATERIAL_PARAM_BENDING
                    return SpecTypeId.Stress;
                case -1140413: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD
                    return SpecTypeId.Stress;
                case -1140412: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD
                    return SpecTypeId.Number;
                case -1140410: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_PERPENDICULAR
                    return SpecTypeId.Stress;
                case -1140409: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_PARALLEL
                    return SpecTypeId.Stress;
                case -1140408: // BuiltInParameter.PHY_MATERIAL_PARAM_COMPRESSION_PERPENDICULAR
                    return SpecTypeId.Stress;
                case -1140407: // BuiltInParameter.PHY_MATERIAL_PARAM_COMPRESSION_PARALLEL
                    return SpecTypeId.Stress;
                case -1140401: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD
                    return SpecTypeId.Stress;
                case -1140321: // BuiltInParameter.PHY_MATERIAL_PARAM_RESISTANCE_CALC_STRENGTH
                    return SpecTypeId.Stress;
                case -1140320: // BuiltInParameter.PHY_MATERIAL_PARAM_REDUCTION_FACTOR
                    return SpecTypeId.Number;
                case -1140319: // BuiltInParameter.PHY_MATERIAL_PARAM_MINIMUM_TENSILE_STRENGTH
                    return SpecTypeId.Stress;
                case -1140318: // BuiltInParameter.PHY_MATERIAL_PARAM_MINIMUM_YIELD_STRESS
                    return SpecTypeId.Stress;
                case -1140317: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_STRENGTH_REDUCTION
                    return SpecTypeId.Number;
                case -1140316: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_REINFORCEMENT
                    return SpecTypeId.Stress;
                case -1140315: // BuiltInParameter.PHY_MATERIAL_PARAM_BENDING_REINFORCEMENT
                    return SpecTypeId.Stress;
                case -1140314: // BuiltInParameter.PHY_MATERIAL_PARAM_CONCRETE_COMPRESSION
                    return SpecTypeId.Stress;
                case -1140312: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF3
                    return SpecTypeId.ThermalExpansionCoefficient;
                case -1140311: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF2
                    return SpecTypeId.ThermalExpansionCoefficient;
                case -1140310: // BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF1
                    return SpecTypeId.ThermalExpansionCoefficient;
                case -1140309: // BuiltInParameter.PHY_MATERIAL_PARAM_UNIT_WEIGHT
                    return SpecTypeId.UnitWeight;
                case -1140308: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD3
                    return SpecTypeId.Stress;
                case -1140307: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD2
                    return SpecTypeId.Stress;
                case -1140306: // BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD1
                    return SpecTypeId.Stress;
                case -1140305: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD3
                    return SpecTypeId.Number;
                case -1140304: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD2
                    return SpecTypeId.Number;
                case -1140303: // BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD1
                    return SpecTypeId.Number;
                case -1140302: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD3
                    return SpecTypeId.Stress;
                case -1140301: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD2
                    return SpecTypeId.Stress;
                case -1140300: // BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD1
                    return SpecTypeId.Stress;
                case -1140266: // BuiltInParameter.RBS_FP_SPRINKLER_ORIFICE_SIZE_PARAM
                    return SpecTypeId.PipeSize;
                case -1140265: // BuiltInParameter.RBS_FP_SPRINKLER_TEMPERATURE_RATING_PARAM
                    return SpecTypeId.PipingTemperature;
                case -1140264: // BuiltInParameter.RBS_FP_SPRINKLER_K_FACTOR_PARAM
                    return SpecTypeId.Number;
                case -1140257: // BuiltInParameter.RBS_PIPE_SYSTEM_FIXTURE_UNIT_PARAM
                    return SpecTypeId.Number;
                case -1140253: // BuiltInParameter.RBS_PIPE_VOLUME_PARAM
                    return SpecTypeId.PipingVolume;
                case -1140252: // BuiltInParameter.RBS_PIPE_WFU_PARAM
                    return SpecTypeId.Number;
                case -1140251: // BuiltInParameter.RBS_PIPE_HWFU_PARAM
                    return SpecTypeId.Number;
                case -1140250: // BuiltInParameter.RBS_PIPE_CWFU_PARAM
                    return SpecTypeId.Number;
                case -1140246: // BuiltInParameter.RBS_PIPE_FIXTURE_UNITS_PARAM
                    return SpecTypeId.Number;
                case -1140242: // BuiltInParameter.RBS_PIPE_STATIC_PRESSURE
                    return SpecTypeId.PipingPressure;
                case -1140240: // BuiltInParameter.RBS_DUCT_BOTTOM_ELEVATION
                    return SpecTypeId.Length;
                case -1140239: // BuiltInParameter.RBS_DUCT_TOP_ELEVATION
                    return SpecTypeId.Length;
                case -1140238: // BuiltInParameter.RBS_PIPE_OUTER_DIAMETER
                    return SpecTypeId.PipeSize;
                case -1140237: // BuiltInParameter.RBS_PIPE_INVERT_ELEVATION
                    return SpecTypeId.Length;
                case -1140226: // BuiltInParameter.RBS_PIPE_ADDITIONAL_FLOW_PARAM
                    return SpecTypeId.Flow;
                case -1140225: // BuiltInParameter.RBS_PIPE_DIAMETER_PARAM
                    return SpecTypeId.PipeSize;
                case -1140217: // BuiltInParameter.RBS_PIPE_FLUID_TEMPERATURE_PARAM
                    return SpecTypeId.PipingTemperature;
                case -1140215: // BuiltInParameter.RBS_PIPE_FLUID_VISCOSITY_PARAM
                    return SpecTypeId.PipingViscosity;
                case -1140214: // BuiltInParameter.RBS_PIPE_FLUID_DENSITY_PARAM
                    return SpecTypeId.PipingDensity;
                case -1140213: // BuiltInParameter.RBS_PIPE_FLOW_PARAM
                    return SpecTypeId.Flow;
                case -1140212: // BuiltInParameter.RBS_PIPE_INNER_DIAM_PARAM
                    return SpecTypeId.PipeSize;
                case -1140211: // BuiltInParameter.RBS_PIPE_REYNOLDS_NUMBER_PARAM
                    return SpecTypeId.Number;
                case -1140210: // BuiltInParameter.RBS_PIPE_RELATIVE_ROUGHNESS_PARAM
                    return SpecTypeId.Number;
                case -1140208: // BuiltInParameter.RBS_PIPE_FRICTION_FACTOR_PARAM
                    return SpecTypeId.Number;
                case -1140207: // BuiltInParameter.RBS_PIPE_VELOCITY_PARAM
                    return SpecTypeId.PipingVelocity;
                case -1140206: // BuiltInParameter.RBS_PIPE_FRICTION_PARAM
                    return SpecTypeId.PipingFriction;
                case -1140205: // BuiltInParameter.RBS_PIPE_PRESSUREDROP_PARAM
                    return SpecTypeId.PipingPressure;
                case -1140204: // BuiltInParameter.RBS_PIPE_ROUGHNESS_PARAM
                    return SpecTypeId.PipingRoughness;
                case -1140166: // BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEC_PARAM
                    return SpecTypeId.Current;
                case -1140165: // BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEB_PARAM
                    return SpecTypeId.Current;
                case -1140164: // BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEA_PARAM
                    return SpecTypeId.Current;
                case -1140154: // BuiltInParameter.RBS_ELEC_CIRCUIT_FRAME_PARAM
                    return SpecTypeId.Current;
                case -1140153: // BuiltInParameter.RBS_ELEC_PANEL_TOTAL_DEMAND_CURRENT_PARAM
                    return SpecTypeId.Current;
                case -1140152: // BuiltInParameter.RBS_ELEC_PANEL_TOTAL_CONNECTED_CURRENT_PARAM
                    return SpecTypeId.Current;
                case -1140151: // BuiltInParameter.RBS_ELEC_PANEL_TOTAL_DEMAND_FACTOR_PARAM
                    return SpecTypeId.DemandFactor;
                case -1140146: // BuiltInParameter.RBS_ELEC_PANEL_NEUTRAL_RATING_PARAM
                    return SpecTypeId.DemandFactor;
                case -1140140: // BuiltInParameter.RBS_ELEC_PANEL_MCB_RATING_PARAM
                    return SpecTypeId.Current;
                case -1140137: // BuiltInParameter.RBS_CONDUITRUN_OUTER_DIAM_PARAM
                    return SpecTypeId.ConduitSize;
                case -1140136: // BuiltInParameter.RBS_CONDUITRUN_INNER_DIAM_PARAM
                    return SpecTypeId.ConduitSize;
                case -1140135: // BuiltInParameter.RBS_CONDUITRUN_DIAMETER_PARAM
                    return SpecTypeId.ConduitSize;
                case -1140134: // BuiltInParameter.RBS_CABLETRAYRUN_WIDTH_PARAM
                    return SpecTypeId.CableTraySize;
                case -1140133: // BuiltInParameter.RBS_CABLETRAYRUN_HEIGHT_PARAM
                    return SpecTypeId.CableTraySize;
                case -1140132: // BuiltInParameter.RBS_CABLETRAYCONDUITRUN_LENGTH_PARAM
                    return SpecTypeId.Length;
                case -1140127: // BuiltInParameter.RBS_CONDUIT_OUTER_DIAM_PARAM
                    return SpecTypeId.ConduitSize;
                case -1140126: // BuiltInParameter.RBS_CONDUIT_INNER_DIAM_PARAM
                    return SpecTypeId.ConduitSize;
                case -1140125: // BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION
                    return SpecTypeId.Length;
                case -1140124: // BuiltInParameter.RBS_CTC_TOP_ELEVATION
                    return SpecTypeId.Length;
                case -1140123: // BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM
                    return SpecTypeId.ConduitSize;
                case -1140122: // BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM
                    return SpecTypeId.CableTraySize;
                case -1140121: // BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM
                    return SpecTypeId.CableTraySize;
                case -1140119: // BuiltInParameter.CABLETRAY_MINBENDMULTIPLIER_PARAM
                    return SpecTypeId.Number;
                case -1140116: // BuiltInParameter.RBS_CONDUIT_BENDRADIUS
                    return SpecTypeId.ConduitSize;
                case -1140115: // BuiltInParameter.RBS_CABLETRAY_BENDRADIUS
                    return SpecTypeId.CableTraySize;
                case -1140082: // BuiltInParameter.RBS_ELEC_MAINS
                    return SpecTypeId.Current;
                case -1140069: // BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_PARAM
                    return SpecTypeId.ApparentPower;
                case -1140068: // BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_PARAM
                    return SpecTypeId.ApparentPower;
                case -1140055: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEC
                    return SpecTypeId.ApparentPower;
                case -1140054: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEB
                    return SpecTypeId.ApparentPower;
                case -1140053: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEA
                    return SpecTypeId.ApparentPower;
                case -1140052: // BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEC
                    return SpecTypeId.ElectricalPower;
                case -1140051: // BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEB
                    return SpecTypeId.ElectricalPower;
                case -1140050: // BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEA
                    return SpecTypeId.ElectricalPower;
                case -1140049: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PARAM
                    return SpecTypeId.Current;
                case -1140048: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEA_PARAM
                    return SpecTypeId.Current;
                case -1140047: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEB_PARAM
                    return SpecTypeId.Current;
                case -1140046: // BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEC_PARAM
                    return SpecTypeId.Current;
                case -1140045: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PARAM
                    return SpecTypeId.Current;
                case -1140044: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEA_PARAM
                    return SpecTypeId.Current;
                case -1140043: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEB_PARAM
                    return SpecTypeId.Current;
                case -1140042: // BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEC_PARAM
                    return SpecTypeId.Current;
                case -1140041: // BuiltInParameter.RBS_ELEC_VOLTAGE_DROP_PARAM
                    return SpecTypeId.ElectricalPotential;
                case -1140039: // BuiltInParameter.RBS_ELEC_CIRCUIT_LENGTH_PARAM
                    return SpecTypeId.Length;
                case -1140038: // BuiltInParameter.RBS_ELEC_CIRCUIT_RATING_PARAM
                    return SpecTypeId.Current;
                case -1140035: // BuiltInParameter.RBS_ELEC_ROOM_CAVITY_RATIO
                    return SpecTypeId.Number;
                case -1140033: // BuiltInParameter.RBS_ELEC_ROOM_AVERAGE_ILLUMINATION
                    return SpecTypeId.Illuminance;
                case -1140032: // BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_FLOOR
                    return SpecTypeId.Factor;
                case -1140031: // BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_WALLS
                    return SpecTypeId.Factor;
                case -1140030: // BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_CEILING
                    return SpecTypeId.Factor;
                case -1140029: // BuiltInParameter.RBS_ELEC_ROOM_LIGHTING_CALC_WORKPLANE
                    return SpecTypeId.Length;
                case -1140010: // BuiltInParameter.RBS_ELEC_TRUE_LOAD
                    return SpecTypeId.ElectricalPower;
                case -1140008: // BuiltInParameter.RBS_ELEC_POWER_FACTOR
                    return SpecTypeId.Number;
                case -1140004: // BuiltInParameter.RBS_ELEC_APPARENT_LOAD
                    return SpecTypeId.ApparentPower;
                case -1140002: // BuiltInParameter.RBS_ELEC_VOLTAGE
                    return SpecTypeId.ElectricalPotential;
                case -1133501: // BuiltInParameter.GROUP_OFFSET_FROM_LEVEL
                    return SpecTypeId.Length;
                case -1114819: // BuiltInParameter.PEAK_LATENT_COOLING_LOAD
                    return SpecTypeId.CoolingLoad;
                case -1114818: // BuiltInParameter.PEAK_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114815: // BuiltInParameter.SPACE_INFILTRATION_AIRFLOW_PER_AREA
                    return SpecTypeId.AirFlowDensity;
                case -1114814: // BuiltInParameter.SPACE_OUTDOOR_AIRFLOW
                    return SpecTypeId.AirFlow;
                case -1114813: // BuiltInParameter.SPACE_OUTDOOR_AIRFLOW_PER_PERSON
                    return SpecTypeId.AirFlow;
                case -1114812: // BuiltInParameter.SPACE_OUTDOOR_AIRFLOW_PER_AREA
                    return SpecTypeId.AirFlowDensity;
                case -1114811: // BuiltInParameter.SPACE_AIR_CHANGES_PER_HOUR
                    return SpecTypeId.Number;
                case -1114810: // BuiltInParameter.SPACE_POWER_LOAD_PARAM
                    return SpecTypeId.HvacPower;
                case -1114809: // BuiltInParameter.SPACE_LIGHTING_LOAD_PARAM
                    return SpecTypeId.HvacPower;
                case -1114808: // BuiltInParameter.SPACE_PEOPLE_LOAD_PARAM
                    return SpecTypeId.HvacPower;
                case -1114807: // BuiltInParameter.SPACE_POWER_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114806: // BuiltInParameter.SPACE_LIGHTING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114805: // BuiltInParameter.SPACE_PEOPLE_LATENT_HEAT_GAIN_PER_PERSON_PARAM
                    return SpecTypeId.HeatGain;
                case -1114804: // BuiltInParameter.SPACE_PEOPLE_SENSIBLE_HEAT_GAIN_PER_PERSON_PARAM
                    return SpecTypeId.HeatGain;
                case -1114803: // BuiltInParameter.SPACE_AREA_PER_PERSON_PARAM
                    return SpecTypeId.Area;
                case -1114802: // BuiltInParameter.SPACE_AIRFLOW_PER_AREA_PARAM
                    return SpecTypeId.AirFlowDensity;
                case -1114801: // BuiltInParameter.PEAK_COOLING_LOAD_PARAM
                    return SpecTypeId.CoolingLoad;
                case -1114800: // BuiltInParameter.PEAK_HEATING_LOAD_PARAM
                    return SpecTypeId.HeatingLoad;
                case -1114711: // BuiltInParameter.SPACE_DEHUMIDIFICATION_SET_POINT
                    return SpecTypeId.Factor;
                case -1114710: // BuiltInParameter.SPACE_HUMIDIFICATION_SET_POINT
                    return SpecTypeId.Factor;
                case -1114709: // BuiltInParameter.SPACE_COOLING_SET_POINT
                    return SpecTypeId.HvacTemperature;
                case -1114708: // BuiltInParameter.SPACE_HEATING_SET_POINT
                    return SpecTypeId.HvacTemperature;
                case -1114706: // BuiltInParameter.ZONE_LEVEL_OFFSET
                    return SpecTypeId.Length;
                case -1114360: // BuiltInParameter.RBS_LINING_THICKNESS_FOR_DUCT
                    return SpecTypeId.DuctLiningThickness;
                case -1114359: // BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_PIPE
                    return SpecTypeId.PipeInsulationThickness;
                case -1114358: // BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_DUCT
                    return SpecTypeId.DuctInsulationThickness;
                case -1114344: // BuiltInParameter.ZONE_COIL_BYPASS_PERCENTAGE_PARAM
                    return SpecTypeId.Factor;
                case -1114343: // BuiltInParameter.ZONE_CALCULATED_AREA_PER_COOLING_LOAD_PARAM
                    return SpecTypeId.AreaDividedByCoolingLoad;
                case -1114342: // BuiltInParameter.ZONE_CALCULATED_AREA_PER_HEATING_LOAD_PARAM
                    return SpecTypeId.AreaDividedByHeatingLoad;
                case -1114332: // BuiltInParameter.ZONE_AREA_GROSS
                    return SpecTypeId.Area;
                case -1114331: // BuiltInParameter.ZONE_VOLUME_GROSS
                    return SpecTypeId.Volume;
                case -1114323: // BuiltInParameter.ROOM_CALCULATED_SUPPLY_AIRFLOW_PER_AREA_PARAM
                    return SpecTypeId.AirFlowDensity;
                case -1114322: // BuiltInParameter.ROOM_CALCULATED_COOLING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.CoolingLoadDividedByArea;
                case -1114321: // BuiltInParameter.ROOM_CALCULATED_HEATING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.HeatingLoadDividedByArea;
                case -1114320: // BuiltInParameter.ZONE_CALCULATED_SUPPLY_AIRFLOW_PER_AREA_PARAM
                    return SpecTypeId.AirFlowDensity;
                case -1114319: // BuiltInParameter.ZONE_CALCULATED_COOLING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.CoolingLoadDividedByArea;
                case -1114318: // BuiltInParameter.ZONE_CALCULATED_HEATING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.HeatingLoadDividedByArea;
                case -1114316: // BuiltInParameter.ZONE_OA_RATE_PER_ACH_PARAM
                    return SpecTypeId.Number;
                case -1114315: // BuiltInParameter.ZONE_OUTSIDE_AIR_PER_AREA_PARAM
                    return SpecTypeId.AirFlowDensity;
                case -1114314: // BuiltInParameter.ZONE_OUTSIDE_AIR_PER_PERSON_PARAM
                    return SpecTypeId.AirFlow;
                case -1114313: // BuiltInParameter.ZONE_DEHUMIDIFICATION_SET_POINT_PARAM
                    return SpecTypeId.Number;
                case -1114312: // BuiltInParameter.ZONE_HUMIDIFICATION_SET_POINT_PARAM
                    return SpecTypeId.Number;
                case -1114311: // BuiltInParameter.ZONE_COOLING_AIR_TEMPERATURE_PARAM
                    return SpecTypeId.HvacTemperature;
                case -1114310: // BuiltInParameter.ZONE_HEATING_AIR_TEMPERATURE_PARAM
                    return SpecTypeId.HvacTemperature;
                case -1114309: // BuiltInParameter.ZONE_COOLING_SET_POINT_PARAM
                    return SpecTypeId.HvacTemperature;
                case -1114308: // BuiltInParameter.ZONE_HEATING_SET_POINT_PARAM
                    return SpecTypeId.HvacTemperature;
                case -1114307: // BuiltInParameter.ZONE_CALCULATED_SUPPLY_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114306: // BuiltInParameter.ZONE_CALCULATED_COOLING_LOAD_PARAM
                    return SpecTypeId.CoolingLoad;
                case -1114305: // BuiltInParameter.ZONE_CALCULATED_HEATING_LOAD_PARAM
                    return SpecTypeId.HeatingLoad;
                case -1114303: // BuiltInParameter.ZONE_VOLUME
                    return SpecTypeId.Volume;
                case -1114302: // BuiltInParameter.ZONE_PERIMETER
                    return SpecTypeId.Length;
                case -1114301: // BuiltInParameter.ZONE_AREA
                    return SpecTypeId.Area;
                case -1114261: // BuiltInParameter.ROOM_ACTUAL_LIGHTING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114260: // BuiltInParameter.ROOM_ACTUAL_POWER_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114256: // BuiltInParameter.ROOM_DESIGN_COOLING_LOAD_PARAM
                    return SpecTypeId.CoolingLoad;
                case -1114255: // BuiltInParameter.ROOM_CALCULATED_COOLING_LOAD_PARAM
                    return SpecTypeId.CoolingLoad;
                case -1114254: // BuiltInParameter.ROOM_DESIGN_HEATING_LOAD_PARAM
                    return SpecTypeId.HeatingLoad;
                case -1114253: // BuiltInParameter.ROOM_CALCULATED_HEATING_LOAD_PARAM
                    return SpecTypeId.HeatingLoad;
                case -1114247: // BuiltInParameter.RBS_GBXML_SURFACE_AREA
                    return SpecTypeId.Area;
                case -1114239: // BuiltInParameter.ROOM_PEOPLE_SENSIBLE_HEAT_GAIN_PER_PERSON_PARAM
                    return SpecTypeId.HeatGain;
                case -1114230: // BuiltInParameter.ROOM_DESIGN_LIGHTING_LOAD_PARAM
                    return SpecTypeId.ElectricalPower;
                case -1114229: // BuiltInParameter.ROOM_DESIGN_POWER_LOAD_PARAM
                    return SpecTypeId.ElectricalPower;
                case -1114226: // BuiltInParameter.ROOM_ACTUAL_LIGHTING_LOAD_PARAM
                    return SpecTypeId.ElectricalPower;
                case -1114225: // BuiltInParameter.ROOM_ACTUAL_POWER_LOAD_PARAM
                    return SpecTypeId.ElectricalPower;
                case -1114222: // BuiltInParameter.ROOM_DESIGN_OTHER_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114221: // BuiltInParameter.ROOM_DESIGN_MECHANICAL_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114220: // BuiltInParameter.ROOM_DESIGN_LIGHTING_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114219: // BuiltInParameter.ROOM_DESIGN_POWER_LOAD_PER_AREA_PARAM
                    return SpecTypeId.ElectricalPowerDensity;
                case -1114218: // BuiltInParameter.FBX_LIGHT_BALLAST_LOSS
                    return SpecTypeId.Number;
                case -1114217: // BuiltInParameter.FBX_LIGHT_TOTAL_LIGHT_LOSS
                    return SpecTypeId.Number;
                case -1114216: // BuiltInParameter.RBS_ROOM_COEFFICIENT_UTILIZATION
                    return SpecTypeId.Number;
                case -1114196: // BuiltInParameter.ROOM_ACTUAL_EXHAUST_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114195: // BuiltInParameter.ROOM_ACTUAL_RETURN_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114194: // BuiltInParameter.ROOM_ACTUAL_SUPPLY_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114189: // BuiltInParameter.ROOM_PEOPLE_LATENT_HEAT_GAIN_PER_PERSON_PARAM
                    return SpecTypeId.HeatGain;
                case -1114188: // BuiltInParameter.ROOM_PEOPLE_TOTAL_HEAT_GAIN_PER_PERSON_PARAM
                    return SpecTypeId.HeatGain;
                case -1114180: // BuiltInParameter.ROOM_CALCULATED_SUPPLY_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114178: // BuiltInParameter.ROOM_DESIGN_EXHAUST_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114177: // BuiltInParameter.ROOM_DESIGN_RETURN_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114176: // BuiltInParameter.ROOM_DESIGN_SUPPLY_AIRFLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1114175: // BuiltInParameter.ROOM_AREA_PER_PERSON_PARAM
                    return SpecTypeId.Area;
                case -1114174: // BuiltInParameter.ROOM_NUMBER_OF_PEOPLE_PARAM
                    return SpecTypeId.Number;
                case -1114166: // BuiltInParameter.RBS_ADDITIONAL_FLOW
                    return SpecTypeId.AirFlow;
                case -1114142: // BuiltInParameter.RBS_DUCT_STATIC_PRESSURE
                    return SpecTypeId.HvacPressure;
                case -1114129: // BuiltInParameter.RBS_HYDRAULIC_DIAMETER_PARAM
                    return SpecTypeId.DuctSize;
                case -1114128: // BuiltInParameter.RBS_REYNOLDSNUMBER_PARAM
                    return SpecTypeId.Number;
                case -1114127: // BuiltInParameter.RBS_EQ_DIAMETER_PARAM
                    return SpecTypeId.DuctSize;
                case -1114124: // BuiltInParameter.RBS_LOSS_COEFFICIENT
                    return SpecTypeId.Number;
                case -1114123: // BuiltInParameter.RBS_MAX_FLOW
                    return SpecTypeId.AirFlow;
                case -1114122: // BuiltInParameter.RBS_MIN_FLOW
                    return SpecTypeId.AirFlow;
                case -1114121: // BuiltInParameter.RBS_VELOCITY_PRESSURE
                    return SpecTypeId.HvacPressure;
                case -1114120: // BuiltInParameter.RBS_CURVE_SURFACE_AREA
                    return SpecTypeId.Area;
                case -1114116: // BuiltInParameter.RBS_FRICTION
                    return SpecTypeId.HvacFriction;
                case -1114108: // BuiltInParameter.RBS_PRESSURE_DROP
                    return SpecTypeId.HvacPressure;
                case -1114107: // BuiltInParameter.RBS_VELOCITY
                    return SpecTypeId.HvacVelocity;
                case -1114103: // BuiltInParameter.RBS_CURVE_DIAMETER_PARAM
                    return SpecTypeId.DuctSize;
                case -1114102: // BuiltInParameter.RBS_CURVE_HEIGHT_PARAM
                    return SpecTypeId.DuctSize;
                case -1114101: // BuiltInParameter.RBS_CURVE_WIDTH_PARAM
                    return SpecTypeId.DuctSize;
                case -1060011: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MZ
                    return SpecTypeId.Moment;
                case -1060010: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MY
                    return SpecTypeId.Moment;
                case -1060009: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MX
                    return SpecTypeId.Moment;
                case -1060008: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FZ
                    return SpecTypeId.Force;
                case -1060007: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FY
                    return SpecTypeId.Force;
                case -1060006: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FX
                    return SpecTypeId.Force;
                case -1060005: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MZ
                    return SpecTypeId.Moment;
                case -1060004: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MY
                    return SpecTypeId.Moment;
                case -1060003: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MX
                    return SpecTypeId.Moment;
                case -1060002: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FZ
                    return SpecTypeId.Force;
                case -1060001: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FY
                    return SpecTypeId.Force;
                case -1060000: // BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FX
                    return SpecTypeId.Force;
                case -1019101: // BuiltInParameter.WALL_SINGLE_SLANT_ANGLE_FROM_VERTICAL
                    return SpecTypeId.Angle;
                case -1018503: // BuiltInParameter.REINFORCEMENT_VOLUME
                    return SpecTypeId.ReinforcementVolume;
                case -1018502: // BuiltInParameter.REIN_EST_BAR_VOLUME
                    return SpecTypeId.ReinforcementVolume;
                case -1018308: // BuiltInParameter.PATH_REIN_LENGTH_2
                    return SpecTypeId.ReinforcementLength;
                case -1018307: // BuiltInParameter.PATH_REIN_LENGTH_1
                    return SpecTypeId.ReinforcementLength;
                case -1018302: // BuiltInParameter.PATH_REIN_SPACING
                    return SpecTypeId.ReinforcementSpacing;
                case -1018273: // BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_2_GENERIC
                    return SpecTypeId.ReinforcementSpacing;
                case -1018272: // BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_1_GENERIC
                    return SpecTypeId.ReinforcementSpacing;
                case -1018271: // BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_2_GENERIC
                    return SpecTypeId.ReinforcementSpacing;
                case -1018270: // BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_1_GENERIC
                    return SpecTypeId.ReinforcementSpacing;
                case -1017739: // BuiltInParameter.FABRIC_WIRE_OFFSET
                    return SpecTypeId.ReinforcementLength;
                case -1017738: // BuiltInParameter.FABRIC_WIRE_DISTANCE
                    return SpecTypeId.ReinforcementLength;
                case -1017737: // BuiltInParameter.FABRIC_WIRE_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017712: // BuiltInParameter.FABRIC_PARAM_CUT_SHEET_MASS
                    return SpecTypeId.Mass;
                case -1017711: // BuiltInParameter.FABRIC_PARAM_TOTAL_SHEET_MASS
                    return SpecTypeId.Mass;
                case -1017710: // BuiltInParameter.FABRIC_PARAM_CUT_OVERALL_WIDTH
                    return SpecTypeId.ReinforcementLength;
                case -1017709: // BuiltInParameter.FABRIC_PARAM_CUT_OVERALL_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017707: // BuiltInParameter.FABRIC_PARAM_MINOR_LAPSPLICE_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017706: // BuiltInParameter.FABRIC_PARAM_MAJOR_LAPSPLICE_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017624: // BuiltInParameter.FABRIC_SHEET_MASSUNIT
                    return SpecTypeId.MassPerUnitArea;
                case -1017623: // BuiltInParameter.FABRIC_SHEET_MINOR_REINFORCEMENT_AREA
                    return SpecTypeId.ReinforcementAreaPerUnitLength;
                case -1017622: // BuiltInParameter.FABRIC_SHEET_MAJOR_REINFORCEMENT_AREA
                    return SpecTypeId.ReinforcementAreaPerUnitLength;
                case -1017621: // BuiltInParameter.FABRIC_SHEET_MASS
                    return SpecTypeId.Mass;
                case -1017620: // BuiltInParameter.FABRIC_SHEET_MINOR_SPACING
                    return SpecTypeId.ReinforcementSpacing;
                case -1017617: // BuiltInParameter.FABRIC_SHEET_MINOR_END_OVERHANG
                    return SpecTypeId.ReinforcementSpacing;
                case -1017616: // BuiltInParameter.FABRIC_SHEET_MINOR_START_OVERHANG
                    return SpecTypeId.ReinforcementSpacing;
                case -1017615: // BuiltInParameter.FABRIC_SHEET_WIDTH
                    return SpecTypeId.ReinforcementLength;
                case -1017614: // BuiltInParameter.FABRIC_SHEET_OVERALL_WIDTH
                    return SpecTypeId.ReinforcementLength;
                case -1017613: // BuiltInParameter.FABRIC_SHEET_MAJOR_SPACING
                    return SpecTypeId.ReinforcementSpacing;
                case -1017610: // BuiltInParameter.FABRIC_SHEET_MAJOR_END_OVERHANG
                    return SpecTypeId.ReinforcementSpacing;
                case -1017609: // BuiltInParameter.FABRIC_SHEET_MAJOR_START_OVERHANG
                    return SpecTypeId.ReinforcementSpacing;
                case -1017608: // BuiltInParameter.FABRIC_SHEET_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017607: // BuiltInParameter.FABRIC_SHEET_OVERALL_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017601: // BuiltInParameter.FABRIC_WIRE_DIAMETER
                    return SpecTypeId.BarDiameter;
                case -1017064: // BuiltInParameter.REBAR_MIN_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017063: // BuiltInParameter.REBAR_MAX_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017038: // BuiltInParameter.REBAR_INSTANCE_BEND_DIAMETER
                    return SpecTypeId.BarDiameter;
                case -1017016: // BuiltInParameter.REBAR_ELEM_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017013: // BuiltInParameter.REBAR_ELEM_BAR_SPACING
                    return SpecTypeId.ReinforcementSpacing;
                case -1017005: // BuiltInParameter.REBAR_ELEM_TOTAL_LENGTH
                    return SpecTypeId.ReinforcementLength;
                case -1017000: // BuiltInParameter.REBAR_BAR_DIAMETER
                    return SpecTypeId.BarDiameter;
                case -1015069: // BuiltInParameter.LOAD_AREA_AREA
                    return SpecTypeId.Area;
                case -1015068: // BuiltInParameter.LOAD_AREA_FORCE_FZ3
                    return SpecTypeId.AreaForce;
                case -1015067: // BuiltInParameter.LOAD_AREA_FORCE_FY3
                    return SpecTypeId.AreaForce;
                case -1015066: // BuiltInParameter.LOAD_AREA_FORCE_FX3
                    return SpecTypeId.AreaForce;
                case -1015065: // BuiltInParameter.LOAD_AREA_FORCE_FZ2
                    return SpecTypeId.AreaForce;
                case -1015064: // BuiltInParameter.LOAD_AREA_FORCE_FY2
                    return SpecTypeId.AreaForce;
                case -1015063: // BuiltInParameter.LOAD_AREA_FORCE_FX2
                    return SpecTypeId.AreaForce;
                case -1015062: // BuiltInParameter.LOAD_AREA_FORCE_FZ1
                    return SpecTypeId.AreaForce;
                case -1015061: // BuiltInParameter.LOAD_AREA_FORCE_FY1
                    return SpecTypeId.AreaForce;
                case -1015060: // BuiltInParameter.LOAD_AREA_FORCE_FX1
                    return SpecTypeId.AreaForce;
                case -1015043: // BuiltInParameter.LOAD_LINEAR_LENGTH
                    return SpecTypeId.Length;
                case -1015041: // BuiltInParameter.LOAD_MOMENT_MZ2
                    return SpecTypeId.LinearMoment;
                case -1015040: // BuiltInParameter.LOAD_MOMENT_MY2
                    return SpecTypeId.LinearMoment;
                case -1015039: // BuiltInParameter.LOAD_MOMENT_MX2
                    return SpecTypeId.LinearMoment;
                case -1015038: // BuiltInParameter.LOAD_MOMENT_MZ1
                    return SpecTypeId.LinearMoment;
                case -1015037: // BuiltInParameter.LOAD_MOMENT_MY1
                    return SpecTypeId.LinearMoment;
                case -1015036: // BuiltInParameter.LOAD_MOMENT_MX1
                    return SpecTypeId.LinearMoment;
                case -1015035: // BuiltInParameter.LOAD_LINEAR_FORCE_FZ2
                    return SpecTypeId.LinearForce;
                case -1015034: // BuiltInParameter.LOAD_LINEAR_FORCE_FY2
                    return SpecTypeId.LinearForce;
                case -1015033: // BuiltInParameter.LOAD_LINEAR_FORCE_FX2
                    return SpecTypeId.LinearForce;
                case -1015032: // BuiltInParameter.LOAD_LINEAR_FORCE_FZ1
                    return SpecTypeId.LinearForce;
                case -1015031: // BuiltInParameter.LOAD_LINEAR_FORCE_FY1
                    return SpecTypeId.LinearForce;
                case -1015030: // BuiltInParameter.LOAD_LINEAR_FORCE_FX1
                    return SpecTypeId.LinearForce;
                case -1015015: // BuiltInParameter.LOAD_MOMENT_MZ
                    return SpecTypeId.Moment;
                case -1015014: // BuiltInParameter.LOAD_MOMENT_MY
                    return SpecTypeId.Moment;
                case -1015013: // BuiltInParameter.LOAD_MOMENT_MX
                    return SpecTypeId.Moment;
                case -1015012: // BuiltInParameter.LOAD_FORCE_FZ
                    return SpecTypeId.Force;
                case -1015011: // BuiltInParameter.LOAD_FORCE_FY
                    return SpecTypeId.Force;
                case -1015010: // BuiltInParameter.LOAD_FORCE_FX
                    return SpecTypeId.Force;
                case -1013408: // BuiltInParameter.JOIST_SYSTEM_SPACING_PARAM
                    return SpecTypeId.Length;
                case -1013405: // BuiltInParameter.RBS_DUCT_FLOW_PARAM
                    return SpecTypeId.AirFlow;
                case -1012806: // BuiltInParameter.HOST_VOLUME_COMPUTED
                    return SpecTypeId.Volume;
                case -1012805: // BuiltInParameter.HOST_AREA_COMPUTED
                    return SpecTypeId.Area;
                case -1012618: // BuiltInParameter.PROPERTY_SEGMENT_RADIUS
                    return SpecTypeId.Length;
                case -1012616: // BuiltInParameter.PROPERTY_SEGMENT_BEARING
                    return SpecTypeId.SiteAngle;
                case -1012614: // BuiltInParameter.PROPERTY_SEGMENT_DISTANCE
                    return SpecTypeId.Length;
                case -1012611: // BuiltInParameter.VOLUME_NET
                    return SpecTypeId.Volume;
                case -1012610: // BuiltInParameter.PROJECTED_SURFACE_AREA
                    return SpecTypeId.Area;
                case -1012604: // BuiltInParameter.VOLUME_FILL
                    return SpecTypeId.Volume;
                case -1012603: // BuiltInParameter.VOLUME_CUT
                    return SpecTypeId.Volume;
                case -1012601: // BuiltInParameter.SURFACE_AREA
                    return SpecTypeId.Area;
                case -1012600: // BuiltInParameter.PROPERTY_AREA
                    return SpecTypeId.Area;
                case -1012501: // BuiltInParameter.BUILDINGPAD_THICKNESS
                    return SpecTypeId.Length;
                case -1012044: // BuiltInParameter.MASS_DATA_SKYLIGHT_WIDTH
                    return SpecTypeId.Length;
                case -1012043: // BuiltInParameter.MASS_DATA_PERCENTAGE_SKYLIGHTS
                    return SpecTypeId.Number;
                case -1012042: // BuiltInParameter.MASS_DATA_SILL_HEIGHT
                    return SpecTypeId.Length;
                case -1012041: // BuiltInParameter.MASS_DATA_SHADE_DEPTH
                    return SpecTypeId.Length;
                case -1012039: // BuiltInParameter.MASS_DATA_PERCENTAGE_GLAZING
                    return SpecTypeId.Number;
                case -1012037: // BuiltInParameter.MASS_DATA_MASS_OPENING_AREA
                    return SpecTypeId.Area;
                case -1012036: // BuiltInParameter.MASS_DATA_MASS_SKYLIGHT_AREA
                    return SpecTypeId.Area;
                case -1012035: // BuiltInParameter.MASS_DATA_MASS_WINDOW_AREA
                    return SpecTypeId.Area;
                case -1012034: // BuiltInParameter.MASS_DATA_MASS_ROOF_AREA
                    return SpecTypeId.Area;
                case -1012033: // BuiltInParameter.MASS_DATA_MASS_INTERIOR_WALL_AREA
                    return SpecTypeId.Area;
                case -1012032: // BuiltInParameter.MASS_DATA_MASS_EXTERIOR_WALL_AREA
                    return SpecTypeId.Area;
                case -1012025: // BuiltInParameter.MASS_ZONE_FLOOR_AREA
                    return SpecTypeId.Area;
                case -1012021: // BuiltInParameter.MASS_ZONE_VOLUME
                    return SpecTypeId.Volume;
                case -1012012: // BuiltInParameter.LEVEL_DATA_VOLUME
                    return SpecTypeId.Volume;
                case -1012011: // BuiltInParameter.LEVEL_DATA_SURFACE_AREA
                    return SpecTypeId.Area;
                case -1012010: // BuiltInParameter.LEVEL_DATA_FLOOR_AREA
                    return SpecTypeId.Area;
                case -1012009: // BuiltInParameter.LEVEL_DATA_FLOOR_PERIMETER
                    return SpecTypeId.Length;
                case -1012007: // BuiltInParameter.MASS_GROSS_VOLUME
                    return SpecTypeId.Volume;
                case -1012006: // BuiltInParameter.MASS_GROSS_SURFACE_AREA
                    return SpecTypeId.Area;
                case -1012004: // BuiltInParameter.MASS_GROSS_AREA
                    return SpecTypeId.Area;
                case -1010503: // BuiltInParameter.FBX_LIGHT_LIMUNOUS_FLUX
                    return SpecTypeId.LuminousFlux;
                case -1010301: // BuiltInParameter.CURTAIN_WALL_PANELS_WIDTH
                    return SpecTypeId.Length;
                case -1010300: // BuiltInParameter.CURTAIN_WALL_PANELS_HEIGHT
                    return SpecTypeId.Length;
                case -1010003: // BuiltInParameter.CASEWORK_DEPTH, BuiltInParameter.GENERIC_DEPTH
                    return SpecTypeId.Length;
                case -1008621: // BuiltInParameter.STAIRS_RAILING_HEIGHT_OFFSET
                    return SpecTypeId.Length;
                case -1008602: // BuiltInParameter.STAIRS_RAILING_HEIGHT
                    return SpecTypeId.Length;
                case -1007250: // BuiltInParameter.STAIRS_ACTUAL_TREAD_DEPTH
                    return SpecTypeId.Length;
                case -1007211: // BuiltInParameter.STAIRS_ATTR_TREAD_THICKNESS
                    return SpecTypeId.Length;
                case -1007206: // BuiltInParameter.STAIRS_ACTUAL_RISER_HEIGHT
                    return SpecTypeId.Length;
                case -1007204: // BuiltInParameter.STAIRS_ATTR_TREAD_WIDTH
                    return SpecTypeId.Length;
                case -1007203: // BuiltInParameter.STAIRS_ATTR_MINIMUM_TREAD_DEPTH
                    return SpecTypeId.Length;
                case -1007202: // BuiltInParameter.STAIRS_ATTR_MAX_RISER_HEIGHT
                    return SpecTypeId.Length;
                case -1007102: // BuiltInParameter.LEVEL_ELEV
                    return SpecTypeId.Length;
                case -1006925: // BuiltInParameter.ROOM_LOWER_OFFSET
                    return SpecTypeId.Length;
                case -1006924: // BuiltInParameter.ROOM_UPPER_OFFSET
                    return SpecTypeId.Length;
                case -1006921: // BuiltInParameter.ROOM_VOLUME
                    return SpecTypeId.Volume;
                case -1006920: // BuiltInParameter.ROOM_HEIGHT
                    return SpecTypeId.Length;
                case -1006917: // BuiltInParameter.ROOM_PERIMETER
                    return SpecTypeId.Length;
                case -1006902: // BuiltInParameter.ROOM_AREA
                    return SpecTypeId.Area;
                case -1006016: // BuiltInParameter.ROOF_SLOPE
                    return SpecTypeId.Slope;
                case -1005567: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBTHICKNESS_LOCATION
                    return SpecTypeId.SectionProperty;
                case -1005566: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGETHICKNESS_LOCATION
                    return SpecTypeId.SectionProperty;
                case -1005565: // BuiltInParameter.STRUCTURAL_SECTION_TOP_WEB_FILLET
                    return SpecTypeId.SectionProperty;
                case -1005564: // BuiltInParameter.STRUCTURAL_SECTION_SLOPED_WEB_ANGLE
                    return SpecTypeId.Angle;
                case -1005563: // BuiltInParameter.STRUCTURAL_SECTION_SLOPED_FLANGE_ANGLE
                    return SpecTypeId.Angle;
                case -1005562: // BuiltInParameter.STRUCTURAL_SECTION_CANTILEVER_HEIGHT
                    return SpecTypeId.SectionDimension;
                case -1005561: // BuiltInParameter.STRUCTURAL_SECTION_CANTILEVER_LENGTH
                    return SpecTypeId.SectionDimension;
                case -1005560: // BuiltInParameter.STRUCTURAL_SECTION_BOTTOM_CUT_HEIGHT
                    return SpecTypeId.SectionDimension;
                case -1005559: // BuiltInParameter.STRUCTURAL_SECTION_BOTTOM_CUT_WIDTH
                    return SpecTypeId.SectionDimension;
                case -1005558: // BuiltInParameter.STRUCTURAL_SECTION_TOP_CUT_HEIGHT
                    return SpecTypeId.SectionDimension;
                case -1005557: // BuiltInParameter.STRUCTURAL_SECTION_TOP_CUT_WIDTH
                    return SpecTypeId.SectionDimension;
                case -1005553: // BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_TOP_BEND_WIDTH
                    return SpecTypeId.SectionDimension;
                case -1005552: // BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_MIDDLE_BEND_WIDTH
                    return SpecTypeId.SectionDimension;
                case -1005551: // BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_BEND_WIDTH
                    return SpecTypeId.SectionDimension;
                case -1005550: // BuiltInParameter.STRUCTURAL_SECTION_ZPROFILE_BOTTOM_FLANGE_LENGTH
                    return SpecTypeId.SectionDimension;
                case -1005549: // BuiltInParameter.STRUCTURAL_SECTION_CPROFILE_FOLD_LENGTH
                    return SpecTypeId.SectionDimension;
                case -1005548: // BuiltInParameter.STRUCTURAL_SECTION_LPROFILE_LIP_LENGTH
                    return SpecTypeId.SectionDimension;
                case -1005547: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_DIAMETER_SHORTER_FLANGE
                    return SpecTypeId.SectionDimension;
                case -1005546: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_DIAMETER_LONGER_FLANGE
                    return SpecTypeId.SectionDimension;
                case -1005545: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_SHORTER_FLANGE
                    return SpecTypeId.SectionDimension;
                case -1005544: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_2_LONGER_FLANGE
                    return SpecTypeId.SectionDimension;
                case -1005543: // BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_1_LONGER_FLANGE
                    return SpecTypeId.SectionDimension;
                case -1005542: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_WEB
                    return SpecTypeId.SectionDimension;
                case -1005541: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_BETWEEN_ROWS
                    return SpecTypeId.SectionDimension;
                case -1005540: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_TWO_ROWS
                    return SpecTypeId.SectionDimension;
                case -1005539: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_DIAMETER
                    return SpecTypeId.SectionDimension;
                case -1005538: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING
                    return SpecTypeId.SectionDimension;
                case -1005537: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEB_TOE_OF_FILLET
                    return SpecTypeId.SectionDimension;
                case -1005536: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGE_TOE_OF_FILLET
                    return SpecTypeId.SectionDimension;
                case -1005535: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_CLEAR_WEB_HEIGHT
                    return SpecTypeId.SectionDimension;
                case -1005534: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_BOTTOMFLANGEWIDTH
                    return SpecTypeId.SectionProperty;
                case -1005533: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_BOTTOMFLANGETHICKNESS
                    return SpecTypeId.SectionProperty;
                case -1005532: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_TOPFLANGEWIDTH
                    return SpecTypeId.SectionProperty;
                case -1005531: // BuiltInParameter.STRUCTURAL_SECTION_IWELDED_TOPFLANGETHICKNESS
                    return SpecTypeId.SectionProperty;
                case -1005530: // BuiltInParameter.STRUCTURAL_SECTION_HSS_OUTERFILLET
                    return SpecTypeId.SectionProperty;
                case -1005529: // BuiltInParameter.STRUCTURAL_SECTION_HSS_INNERFILLET
                    return SpecTypeId.SectionProperty;
                case -1005528: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBFILLET
                    return SpecTypeId.SectionProperty;
                case -1005527: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGEFILLET
                    return SpecTypeId.SectionProperty;
                case -1005526: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBHEIGHT
                    return SpecTypeId.SectionProperty;
                case -1005525: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBTHICKNESS
                    return SpecTypeId.SectionProperty;
                case -1005524: // BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGETHICKNESS
                    return SpecTypeId.SectionProperty;
                case -1005523: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_SHEAR_AREA_WEAK_AXIS
                    return SpecTypeId.SectionArea;
                case -1005522: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_SHEAR_AREA_STRONG_AXIS
                    return SpecTypeId.SectionArea;
                case -1005521: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_WARPING_CONSTANT
                    return SpecTypeId.WarpingConstant;
                case -1005520: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_TORSIONAL_MODULUS
                    return SpecTypeId.SectionModulus;
                case -1005519: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_TORSIONAL_MOMENT_OF_INERTIA
                    return SpecTypeId.MomentOfInertia;
                case -1005518: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_PLASTIC_MODULUS_WEAK_AXIS
                    return SpecTypeId.SectionModulus;
                case -1005517: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_PLASTIC_MODULUS_STRONG_AXIS
                    return SpecTypeId.SectionModulus;
                case -1005516: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_ELASTIC_MODULUS_WEAK_AXIS
                    return SpecTypeId.SectionModulus;
                case -1005515: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_ELASTIC_MODULUS_STRONG_AXIS
                    return SpecTypeId.SectionModulus;
                case -1005514: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_MOMENT_OF_INERTIA_WEAK_AXIS
                    return SpecTypeId.MomentOfInertia;
                case -1005513: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_MOMENT_OF_INERTIA_STRONG_AXIS
                    return SpecTypeId.MomentOfInertia;
                case -1005512: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_NOMINAL_WEIGHT
                    return SpecTypeId.WeightPerUnitLength;
                case -1005511: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_PERIMETER
                    return SpecTypeId.SurfaceAreaPerUnitLength;
                case -1005510: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_ALPHA
                    return SpecTypeId.Angle;
                case -1005509: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_CENTROID_VERTICAL
                    return SpecTypeId.SectionProperty;
                case -1005508: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_CENTROID_HORIZ
                    return SpecTypeId.SectionProperty;
                case -1005507: // BuiltInParameter.STRUCTURAL_SECTION_AREA
                    return SpecTypeId.SectionArea;
                case -1005506: // BuiltInParameter.STRUCTURAL_SECTION_PIPESTANDARD_WALLDESIGNTHICKNESS
                    return SpecTypeId.SectionProperty;
                case -1005505: // BuiltInParameter.STRUCTURAL_SECTION_PIPESTANDARD_WALLNOMINALTHICKNESS
                    return SpecTypeId.SectionProperty;
                case -1005504: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_DIAMETER
                    return SpecTypeId.SectionProperty;
                case -1005503: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_HEIGHT
                    return SpecTypeId.SectionProperty;
                case -1005502: // BuiltInParameter.STRUCTURAL_SECTION_COMMON_WIDTH
                    return SpecTypeId.SectionProperty;
                case -1005435: // BuiltInParameter.ANALYTICAL_ABSORPTANCE
                    return SpecTypeId.Number;
                case -1005433: // BuiltInParameter.ANALYTICAL_VISUAL_LIGHT_TRANSMITTANCE
                    return SpecTypeId.Number;
                case -1005432: // BuiltInParameter.ANALYTICAL_SOLAR_HEAT_GAIN_COEFFICIENT
                    return SpecTypeId.Number;
                case -1005431: // BuiltInParameter.ANALYTICAL_THERMAL_RESISTANCE
                    return SpecTypeId.ThermalResistance;
                case -1005430: // BuiltInParameter.ANALYTICAL_HEAT_TRANSFER_COEFFICIENT
                    return SpecTypeId.HeatTransferCoefficient;
                case -1004005: // BuiltInParameter.CURVE_ELEM_LENGTH
                    return SpecTypeId.Length;
                case -1002300: // BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM
                    return SpecTypeId.Length;
                case -1002066: // BuiltInParameter.SCHEDULE_TOP_LEVEL_OFFSET_PARAM
                    return SpecTypeId.Length;
                case -1002065: // BuiltInParameter.SCHEDULE_BASE_LEVEL_OFFSET_PARAM
                    return SpecTypeId.Length;
                case -1001953: // BuiltInParameter.HOST_PERIMETER_COMPUTED
                    return SpecTypeId.Length;
                case -1001951: // BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM
                    return SpecTypeId.Length;
                case -1001902: // BuiltInParameter.FLOOR_ATTR_DEFAULT_THICKNESS_PARAM
                    return SpecTypeId.Length;
                case -1001701: // BuiltInParameter.ROOF_LEVEL_OFFSET_PARAM
                    return SpecTypeId.Length;
                case -1001658: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM_SURVEY
                    return SpecTypeId.Length;
                case -1001657: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP_SURVEY
                    return SpecTypeId.Length;
                case -1001656: // BuiltInParameter.STRUCTURAL_FLOOR_CORE_THICKNESS
                    return SpecTypeId.Length;
                case -1001655: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM_CORE
                    return SpecTypeId.Length;
                case -1001654: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP_CORE
                    return SpecTypeId.Length;
                case -1001653: // BuiltInParameter.STRUCTURAL_REFERENCE_LEVEL_ELEVATION
                    return SpecTypeId.Length;
                case -1001601: // BuiltInParameter.ROOF_ATTR_THICKNESS_PARAM
                    return SpecTypeId.Length;
                case -1001598: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP
                    return SpecTypeId.Length;
                case -1001586: // BuiltInParameter.STRUCTURAL_BEND_DIR_ANGLE
                    return SpecTypeId.Angle;
                case -1001572: // BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION
                    return SpecTypeId.Length;
                case -1001571: // BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION
                    return SpecTypeId.Length;
                case -1001567: // BuiltInParameter.CONTINUOUS_FOOTING_LENGTH
                    return SpecTypeId.Length;
                case -1001561: // BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM
                    return SpecTypeId.Length;
                case -1001558: // BuiltInParameter.CONTINUOUS_FOOTING_WIDTH
                    return SpecTypeId.Length;
                case -1001557: // BuiltInParameter.STRUCTURAL_FOUNDATION_THICKNESS
                    return SpecTypeId.Length;
                case -1001555: // BuiltInParameter.CONTINUOUS_FOOTING_TOP_HEEL
                    return SpecTypeId.Length;
                case -1001553: // BuiltInParameter.CONTINUOUS_FOOTING_TOP_TOE
                    return SpecTypeId.Length;
                case -1001384: // BuiltInParameter.STRUCTURAL_FRAME_CUT_LENGTH
                    return SpecTypeId.Length;
                case -1001375: // BuiltInParameter.INSTANCE_LENGTH_PARAM
                    return SpecTypeId.Length;
                case -1001362: // BuiltInParameter.INSTANCE_HEAD_HEIGHT_PARAM
                    return SpecTypeId.Length;
                case -1001361: // BuiltInParameter.INSTANCE_SILL_HEIGHT_PARAM
                    return SpecTypeId.Length;
                case -1001360: // BuiltInParameter.INSTANCE_ELEVATION_PARAM
                    return SpecTypeId.Length;
                case -1001305: // BuiltInParameter.FAMILY_ROUGH_WIDTH_PARAM
                    return SpecTypeId.Length;
                case -1001304: // BuiltInParameter.FAMILY_ROUGH_HEIGHT_PARAM
                    return SpecTypeId.Length;
                case -1001302: // BuiltInParameter.DOOR_THICKNESS, BuiltInParameter.FAMILY_THICKNESS_PARAM, BuiltInParameter.FURNITURE_THICKNESS, BuiltInParameter.GENERIC_THICKNESS, BuiltInParameter.WINDOW_THICKNESS
                    return SpecTypeId.Length;
                case -1001301: // BuiltInParameter.CASEWORK_WIDTH, BuiltInParameter.DOOR_WIDTH, BuiltInParameter.FAMILY_WIDTH_PARAM, BuiltInParameter.FURNITURE_WIDTH, BuiltInParameter.GENERIC_WIDTH, BuiltInParameter.WINDOW_WIDTH
                    return SpecTypeId.Length;
                case -1001300: // BuiltInParameter.CASEWORK_HEIGHT, BuiltInParameter.DOOR_HEIGHT, BuiltInParameter.FAMILY_HEIGHT_PARAM, BuiltInParameter.FURNITURE_HEIGHT, BuiltInParameter.GENERIC_HEIGHT, BuiltInParameter.WINDOW_HEIGHT
                    return SpecTypeId.Length;
                case -1001205: // BuiltInParameter.ALL_MODEL_COST, BuiltInParameter.DOOR_COST
                    return SpecTypeId.Currency;
                case -1001136: // BuiltInParameter.DPART_LENGTH_COMPUTED
                    return SpecTypeId.Length;
                case -1001135: // BuiltInParameter.DPART_HEIGHT_COMPUTED
                    return SpecTypeId.Length;
                case -1001134: // BuiltInParameter.DPART_LAYER_WIDTH
                    return SpecTypeId.Length;
                case -1001133: // BuiltInParameter.DPART_AREA_COMPUTED
                    return SpecTypeId.Area;
                case -1001129: // BuiltInParameter.DPART_VOLUME_COMPUTED
                    return SpecTypeId.Volume;
                case -1001109: // BuiltInParameter.WALL_TOP_OFFSET
                    return SpecTypeId.Length;
                case -1001108: // BuiltInParameter.WALL_BASE_OFFSET
                    return SpecTypeId.Length;
                case -1001105: // BuiltInParameter.WALL_USER_HEIGHT_PARAM
                    return SpecTypeId.Length;
                case -1001000: // BuiltInParameter.WALL_ATTR_WIDTH_PARAM
                    return SpecTypeId.Length;
#if REVIT2021

                case -1005434: // BuiltInParameter.ANALYTICAL_THERMAL_MASS
                    return SpecTypeId.ThermalMass;

#endif
                
#if REVIT2022_OR_GREATER

                case -1155221: // BuiltInParameter.REBAR_MODIFIED_SET
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1155219: // BuiltInParameter.DPART_LAYER_INDEX
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019110: // BuiltInParameter.WALL_TAPERED_USE_INSTANCE_ANGLES
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1019107: // BuiltInParameter.WALL_TYPE_WIDTH_MEASURED_AT
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                case -1002053: // BuiltInParameter.ELEM_PARTITION_PARAM
                    return ForgeTypeIdExtensions.EmptyForgeTypeId;
                
                case -1005434: // BuiltInParameter.ANALYTICAL_THERMAL_MASS
                    return SpecTypeId.HeatCapacityPerArea;
                case -1155223: // BuiltInParameter.REBAR_MODEL_BAR_DIAMETER
                    return SpecTypeId.BarDiameter;
                case -1114821: // BuiltInParameter.SPACE_VOLUME
                    return SpecTypeId.Volume;
                case -1114820: // BuiltInParameter.SPACE_AREA
                    return SpecTypeId.Area;
                case -1019121: // BuiltInParameter.WALL_TAPERED_WIDTH_AT_BOTTOM
                    return SpecTypeId.Length;
                case -1019120: // BuiltInParameter.WALL_TAPERED_WIDTH_AT_TOP
                    return SpecTypeId.Length;
                case -1019106: // BuiltInParameter.WALL_TYPE_DEFAULT_TAPERED_INTERIOR_INWARD_ANGLE
                    return SpecTypeId.Angle;
                case -1019105: // BuiltInParameter.WALL_TYPE_DEFAULT_TAPERED_EXTERIOR_INWARD_ANGLE
                    return SpecTypeId.Angle;
                case -1019103: // BuiltInParameter.WALL_TAPERED_INTERIOR_INWARD_ANGLE
                    return SpecTypeId.Angle;
                case -1019102: // BuiltInParameter.WALL_TAPERED_EXTERIOR_INWARD_ANGLE
                    return SpecTypeId.Angle;

#endif
                default:
                    throw new ArgumentOutOfRangeException(nameof(builtInParameter),
                        $"Не удалось определить \"SpecTypeId\" параметра для \"{builtInParameter}\".");
            }
        }

#endif
    }
}