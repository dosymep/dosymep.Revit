﻿using System;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    public partial class ParamExtensions {
        /// <summary>
        /// Возвращает тип параметра.
        /// </summary>
        /// <param name="builtInParameter">Системный тип параметра.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Выбрасывает исключение если не был сопоставлен тип данных к параметру.</exception>
        public static StorageType GetStorageType(this BuiltInParameter builtInParameter) {
            switch(builtInParameter) {
                case BuiltInParameter.PATH_OF_TRAVEL_FROM_ROOM: return StorageType.String;
                case BuiltInParameter.PATH_OF_TRAVEL_TO_ROOM: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_PROFILE_VOLUME: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PROFILE_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PROFILE_TYPE: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_PLATE_JUSTIFICATION: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_PAINT_AREA: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_EXACT_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_VOLUME: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_AREA: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_WIDTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_TYPE: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_BOLT_TOTAL_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_SHEARSTUD_TOTAL_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_TOTAL_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_CUT_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_EXACT_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PAINT_AREA: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WEIGHT: return StorageType.Double;
                case BuiltInParameter.PATH_OF_TRAVEL_SPEED: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_BOLT_LOCATION: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_BOLT_FINISH_CALCULATION_AT_GAP: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_BOLT_INVERTED: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_BOLT_GRIP_LENGTH_INCREASE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_BOLT_GRIP_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_BOLT_LENGTH: return StorageType.Double;
                case BuiltInParameter.GENERIC_ZONE_NAME: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_TOP_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEC: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEB: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_CURRENT_PHASEA: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEC: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEB: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_APPARENT_LOAD_PHASEA: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEC: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEB: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_CURRENT_PHASEA: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEC: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEB: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_BRANCH_CIRCUIT_APPARENT_LOAD_PHASEA: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_DEFINITION: return StorageType.None;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_THRU_LUGS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBERING_TYPE: return StorageType.Integer;
                case BuiltInParameter.TAG_ON_PLACEMENT_UI: return StorageType.Integer;
                case BuiltInParameter.ROUTE_ANALYSIS_SETTINGS_PARAM: return StorageType.None;
                case BuiltInParameter.PATH_OF_TRAVEL_VIEW_NAME: return StorageType.String;
                case BuiltInParameter.PATH_OF_TRAVEL_LEVEL_NAME: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_CONNECTION_OVERRIDE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_CONNECTION_EDIT_TYPE: return StorageType.None;
                case BuiltInParameter.PATH_OF_TRAVEL_TIME: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_ZCLIP_TYPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_COPE_AROUND_AXIS: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_COPE_AXIS_ANGLE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_COPE_Z_ANGLE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_COPE_X_ANGLE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_COPE_DISTANCE_AXIS: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_COPE_WIDTHX: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_Y_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_X_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_CUT_TYPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_PLATE_SHORTEN_CUTSTRAIGHT: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_PLATE_SHORTEN_SUCTION: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PLATE_SHORTEN_ANGLE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_PREFIX: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_WELD_TEXT_MODULE: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_HOLE_DEPTH_OF_BOLT_HEAD: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_TAPPING: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_HOLE_BACK_TAPER_THREAD: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_TAPPING_HOLE: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_HEAD_DIAMETER: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_ANGLE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_HOLE_ALPHA: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_DEPTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_SLOT_DIRECTION: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_HOLE_SLOT_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_HOLE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_HOLE_DIAMETER: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_PATTERN_RADIUS: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_EDGE_DISTANCE_Y: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_EDGE_DISTANCE_X: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_INTERMEDIATE_DISTANCE_Y: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_INTERMEDIATE_DISTANCE_X: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_TOTAL_WIDTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_TOTAL_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER_Y: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_PATTERN_NUMBER_X: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_PREPDEPTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_EFFECTIVETHROAT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_ROOTOPENING: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_WELDPREP: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_SURFACESHAPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_TEXT: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_DOUBLE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_PREPDEPTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_EFFECTIVETHROAT: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_ROOTOPENING: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_WELDPREP: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_SURFACESHAPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_TEXT: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_WELD_PITCH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_CONTINUOUS: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_LOCATION: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_WELD_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_WELD_MAIN_TYPE: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_PARAM_BORINGOUT: return StorageType.Integer;
                case BuiltInParameter.STEEL_ELEM_PARAM_RADIUS: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_CONTOUR_SIDE2DIST: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_CONTOUR_SIDE1DIST: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_CONTOUR_GAP_WIDTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_SHORTEN_ANGLEZ: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_SHORTEN_ANGLEY: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_SHORTEN_REFLENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_SHEARSTUD_LENGTH: return StorageType.Double;
                case BuiltInParameter.STEEL_ELEM_BOLT_COATING: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_LENGTH: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_SHEARSTUD_DIAMETER: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_SHEARSTUD_GRADE: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_SHEARSTUD_STANDARD: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_DIAMETER: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_ASSEMBLY: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_GRADE: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_ANCHOR_STANDARD: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_COATING: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_BOLT_DIAMETER: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_BOLT_ASSEMBLY: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_BOLT_GRADE: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_BOLT_STANDARD: return StorageType.String;
                case BuiltInParameter.STEEL_ELEM_PLATE_THICKNESS: return StorageType.Double;
                case BuiltInParameter.REBAR_WORKSHOP_INSTRUCTIONS: return StorageType.Integer;
                case BuiltInParameter.REBAR_GEOMETRY_TYPE: return StorageType.Integer;
                case BuiltInParameter.BASEPOINT_LATITUDE_PARAM: return StorageType.Double;
                case BuiltInParameter.BASEPOINT_LONGITUDE_PARAM: return StorageType.Double;
                case BuiltInParameter.REBAR_FREE_FORM_HOOK_END_PLANE_ANGLE: return StorageType.Double;
                case BuiltInParameter.REBAR_FREE_FORM_HOOK_START_PLANE_ANGLE: return StorageType.Double;
                case BuiltInParameter.ROOM_OUTDOOR_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_OUTDOOR_AIRFLOW_STANDARD_PARAM: return StorageType.Integer;
                case BuiltInParameter.DIRECTCONTEXT3D_SOURCE_ID: return StorageType.String;
                case BuiltInParameter.DIRECTCONTEXT3D_APPLICATION_ID: return StorageType.String;
                case BuiltInParameter.DIRECTCONTEXT3D_SERVER_ID: return StorageType.String;
                case BuiltInParameter.DIRECTCONTEXT3D_NAME: return StorageType.String;
                case BuiltInParameter.ROOM_AIR_CHANGES_PER_HOUR_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_OUTDOOR_AIR_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_OUTDOOR_AIR_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_OUTDOOR_AIR_INFO_PARAM: return StorageType.String;
                case BuiltInParameter.REBAR_SHAPE_ENDTREATMENT_END_TYPE: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SHAPE_ENDTREATMENT_START_TYPE: return StorageType.ElementId;
                case BuiltInParameter.REBAR_ELEM_ENDTREATMENT_END: return StorageType.ElementId;
                case BuiltInParameter.REBAR_ELEM_ENDTREATMENT_START: return StorageType.ElementId;
                case BuiltInParameter.END_TREATMENT: return StorageType.String;
                case BuiltInParameter.COUPLER_COUPLED_ENDTREATMENT: return StorageType.ElementId;
                case BuiltInParameter.COUPLER_MAIN_ENDTREATMENT: return StorageType.ElementId;
                case BuiltInParameter.COUPLER_WIDTH: return StorageType.Double;
                case BuiltInParameter.COUPLER_MARK: return StorageType.String;
                case BuiltInParameter.FAMILY_FREEINST_DEFAULT_ELEVATION: return StorageType.Double;
                case BuiltInParameter.COUPLER_COUPLED_ENGAGEMENT: return StorageType.Double;
                case BuiltInParameter.COUPLER_MAIN_ENGAGEMENT: return StorageType.Double;
                case BuiltInParameter.COUPLER_LENGTH: return StorageType.Double;
                case BuiltInParameter.COUPLER_WEIGHT: return StorageType.Double;
                case BuiltInParameter.COUPLER_NUMBER: return StorageType.String;
                case BuiltInParameter.COUPLER_QUANTITY: return StorageType.Integer;
                case BuiltInParameter.COUPLER_COUPLED_BAR_SIZE: return StorageType.ElementId;
                case BuiltInParameter.COUPLER_MAIN_BAR_SIZE: return StorageType.ElementId;
                case BuiltInParameter.COUPLER_CODE: return StorageType.String;
                case BuiltInParameter.MULTISTORY_STAIRS_ACTUAL_TREAD_DEPTH: return StorageType.Double;
                case BuiltInParameter.MULTISTORY_STAIRS_REF_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.REBAR_ELEM_HOST_MARK: return StorageType.String;
                case BuiltInParameter.REBAR_SHAPE_IMAGE: return StorageType.ElementId;
                case BuiltInParameter.FABRIC_NUMBER: return StorageType.String;
                case BuiltInParameter.REBAR_NUMBER: return StorageType.String;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_SKETCHY_LINES: return StorageType.None;
                case BuiltInParameter.NUMBER_PARTITION_PARAM: return StorageType.String;
                case BuiltInParameter.VIEW_SHOW_HIDDEN_LINES: return StorageType.Integer;
                case BuiltInParameter.MEP_ZONE_EQUIPMENT_DRAW_VENTILATION: return StorageType.Integer;
                case BuiltInParameter.MEP_VRF_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_REHEAT_HOTWATER_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_ZONE_EQUIPMENT: return StorageType.ElementId;
                case BuiltInParameter.MEP_ANALYTICAL_EQUIPMENT_NAME: return StorageType.String;
                case BuiltInParameter.MEP_ZONE_HOTWATER_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_ZONE_AIR_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_REHEAT_COIL_TYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_ZONE_EQUIPMENT_BEHAVIOR: return StorageType.Integer;
                case BuiltInParameter.MEP_ZONE_EQUIPMENT_TYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_AIRLOOP_FANTYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_CHILLED_WATER_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_COOLING_COIL_TYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_HEATING_HOTWATER_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_HEATING_COIL_TYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_PREHEAT_HOTWATER_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_AIRLOOP_PREHEAT_COILTYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_AIRLOOP_HEATEXCHANGER_TYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_CONDENSER_WATER_LOOP: return StorageType.ElementId;
                case BuiltInParameter.MEP_WATERLOOP_CHILLERTYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_WATERLOOP_TYPE: return StorageType.Integer;
                case BuiltInParameter.MEP_ANALYTICAL_LOOP_NAME: return StorageType.String;
                case BuiltInParameter.SYSTEM_EQUIPMENT_SETS: return StorageType.ElementId;
                case BuiltInParameter.MEP_IGNORE_FLOW_ANALYSIS: return StorageType.Integer;
                case BuiltInParameter.MEP_ANALYTICAL_LOOP_BOUNDARY_PARAM: return StorageType.Integer;
                case BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.MECHANICAL_EQUIPMENT_SET_NAME: return StorageType.String;
                case BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ON_STANDBY: return StorageType.Integer;
                case BuiltInParameter.MECHANICAL_EQUIPMENT_SET_ON_DUTY: return StorageType.Integer;
                case BuiltInParameter.MEP_ANALYTICAL_CRITICALPATH_PARAM: return StorageType.Integer;
                case BuiltInParameter.MEP_ANALYTICAL_PIPE_DESIGNFLOW: return StorageType.Double;
                case BuiltInParameter.MEP_EQUIPMENT_CALC_PIPINGPRESSUREDROP_PARAM: return StorageType.Double;
                case BuiltInParameter.MEP_EQUIPMENT_CALC_PIPINGFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.MEP_EQUIPMENT_CLASSIFICATION: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_CONNECTION_INPUT_ELEMENTS: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_CONNECTION_NOBLE_STATUS: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_CONNECTION_CODE_CHECKING_STATUS: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_CONNECTION_APPROVAL_STATUS: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_CONNECTION_MODIFY_CONNECTION_PARAMETERS: return StorageType.None;
                case BuiltInParameter.STRUCTURAL_CONNECTION_SYMBOL: return StorageType.None;
                case BuiltInParameter.ALL_MODEL_IMAGE: return StorageType.ElementId;
                case BuiltInParameter.ALL_MODEL_TYPE_IMAGE: return StorageType.ElementId;
                case BuiltInParameter.STRUCT_FRAM_JOIN_STATUS: return StorageType.Integer;
                case BuiltInParameter.REFERENCED_VIEW: return StorageType.ElementId;
                case BuiltInParameter.ENERGY_ANALYSIS_ADVANCED_OPTIONS: return StorageType.None;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_MODE: return StorageType.Integer;
#if D2020 || R2020 || D2021 || R2021
                        case BuiltInParameter
                            .RBS_ENERGY_ANALYSIS_BUILDING_ENVELOPE_ANALYTICAL_SURFACE_INDENTIFICATION_RESOLUTION:
                            return StorageType.Double;
                        case BuiltInParameter.RBS_ENERGY_ANALYSIS_BUILDING_ENVELOPE_ANALYTICAL_SPACE_INDENTIFICATION_RESOLUTION:
                            return StorageType.Double;
#endif
                case BuiltInParameter.FAMILY_ROUNDCONNECTOR_DIMENSIONTYPE: return StorageType.Integer;
                case BuiltInParameter.FAM_PROFILE_DEFINITION: return StorageType.Integer;
                case BuiltInParameter.END_Z_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.END_Z_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.END_Y_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.END_Y_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.START_Z_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.START_Z_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.START_Y_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.START_Y_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.Z_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.Z_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.Y_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.Y_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.YZ_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.END_JOIN_CUTBACK: return StorageType.Double;
                case BuiltInParameter.START_JOIN_CUTBACK: return StorageType.Double;
                case BuiltInParameter.END_EXTENSION: return StorageType.Double;
                case BuiltInParameter.START_EXTENSION: return StorageType.Double;
                case BuiltInParameter.DIVISION_SKETCH_CURVE_DIVISION_PARAMS_OVERRIDE_PARAM: return StorageType.Integer;
                case BuiltInParameter.DIVISION_SKETCH_CURVE_EXTENTD_TO_SILH_PARAM: return StorageType.Integer;
                case BuiltInParameter.DIVISION_RULE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.PATTERN_MIRROR_FOR_DIVISION_RULE: return StorageType.Integer;
                case BuiltInParameter.ALL_GRID_ROTATION_FOR_DIVISION_RULE: return StorageType.Double;
                case BuiltInParameter.PATTERN_INDENT_2_FOR_DIVISION_RULE: return StorageType.Integer;
                case BuiltInParameter.PATTERN_INDENT_1_FOR_DIVISION_RULE: return StorageType.Integer;
                case BuiltInParameter.DIVISION_PATTERN: return StorageType.ElementId;
                case BuiltInParameter.DPART_SHAPE_MODIFIED: return StorageType.Integer;
                case BuiltInParameter.DPART_EXCLUDED: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_MANUALLY_ADJUSTED: return StorageType.Integer;
                case BuiltInParameter.PROPERTY_SET_KEYWORDS: return StorageType.String;
                case BuiltInParameter.MATERIAL_ASSET_PARAM_SOURCE_URL: return StorageType.String;
                case BuiltInParameter.MATERIAL_ASSET_PARAM_SOURCE: return StorageType.String;
                case BuiltInParameter.MATERIAL_ASSET_PARAM_EXTERNAL_MATERIAL_ID: return StorageType.String;
                case BuiltInParameter.MATERIAL_ASSET_PARAM_COMMON_SHARED_ASSET: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_ASSET_PARAM_ASSET_LIB_ID: return StorageType.String;
                case BuiltInParameter.DPART_BASE_LEVEL_BY_ORIGINAL: return StorageType.Integer;
                case BuiltInParameter.DPART_BASE_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.POINT_ADAPTIVE_NUM_PARAM: return StorageType.Integer;
                case BuiltInParameter.POINT_ADAPTIVE_SHOW_NUMBER: return StorageType.Integer;
                case BuiltInParameter.POINT_ADAPTIVE_CONSTRAINED: return StorageType.Integer;
                case BuiltInParameter.POINT_ADAPTIVE_ORIENTATION_TYPE: return StorageType.Integer;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_ELECTRICAL_RESISTIVITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_REFLECTIVITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_POROSITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_PERMEABILITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_TRANSMITS_LIGHT: return StorageType.Integer;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_VAPOR_PRESSURE: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_SPECIFIC_HEAT_OF_VAPORIZATION: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_LIQUID_VISCOSITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_COMPRESSIBILITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_GAS_VISCOSITY: return StorageType.Double;
                case BuiltInParameter.THERMAL_MATERIAL_PARAM_EMISSIVITY: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_WOOD_CONSTRUCTION: return StorageType.Integer;
                case BuiltInParameter.PHY_MATERIAL_PARAM_FIVEPERCENT_MODULUS_OF_ELACTICITY: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_AVERAGE_MODULUS: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_TENSION_PERPENDICULAR: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_TENSION_PARALLEL: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_STRUCTURAL_THERMAL_TREATED: return StorageType.Integer;
                case BuiltInParameter.PHY_MATERIAL_PARAM_STRUCTURAL_DENSITY: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_STRUCTURAL_SPECIFIC_HEAT: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_THERMAL_CONDUCTIVITY_Z: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_THERMAL_CONDUCTIVITY_Y: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_THERMAL_CONDUCTIVITY_X: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_THERMAL_CONDUCTIVITY: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF_2: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF_1: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD_12: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD_23: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD_12: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD_2: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD_1: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_PLACEMENT_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER_IS_SLANTED: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_NOSING_PLACEMENT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.TERMINATION_EXTENSION_LENGTH: return StorageType.Double;
                case BuiltInParameter.SUPPORT_HEIGHT: return StorageType.Double;
                case BuiltInParameter.SUPPORT_HAND_CLEARANCE: return StorageType.Double;
                case BuiltInParameter.STAIRS_TRISERTYPE_TREAD_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_TRISERTYPE_TREAD_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER_TREAD_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_TRISERTYPE_RISER_STYLE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_BACK_NOSING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_LEFT_NOSING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_RIGHT_NOSING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_FRONT_NOSING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISERTYPE_NOSING_LENGTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_TRISERTYPE_NOSING_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_TRISERTYPE_TREAD_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_TRISERTYPE_TREAD: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISER_RISER_MARK: return StorageType.String;
                case BuiltInParameter.STAIRS_TRISER_TREAD_MARK: return StorageType.String;
                case BuiltInParameter.STAIRS_TRISER_RISER_NUMBER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISER_TREAD_NUMBER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TRISER_IS_TYPE_OVERRIDDEN: return StorageType.Integer;
                case BuiltInParameter.STAIRS_WINDERPATTERN_NUMBER_OF_STRAIGHT_STEPS_AT_END: return StorageType.Integer;
                case BuiltInParameter.STAIRS_WINDERPATTERN_NUMBER_OF_STRAIGHT_STEPS_AT_BEGIN:
                    return StorageType.Integer;
                case BuiltInParameter.STAIRS_WINDERPATTERN_RADIUS_INTERIOR: return StorageType.Double;
                case BuiltInParameter.STAIRS_WINDERPATTERN_FILLET_INSIDE_CORNER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_WINDERPATTERN_STAIR_PATH_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_WINDERPATTERN_MINIMUM_WIDTH_INSIDE_WALKLINE: return StorageType.Double;
                case BuiltInParameter.STAIRS_WINDERPATTERN_MINIMUM_WIDTH_CORNER: return StorageType.Double;
                case BuiltInParameter.STAIRS_WINDERPATTERN_WINDER_STYLE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_FLIP_SECTION_PROFILE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH_ON_LANDING: return StorageType.Double;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH_ON_RUN: return StorageType.Double;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_TOTAL_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_STRUCTURAL_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_UNDERSIDE_SURFACE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_TOPSIDE_SURFACE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORTTYPE_SECTION_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_SUPPORT_LANDINGSUPPORT_TYPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORT_OVERRIDDEN: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORT_TRIM_SUPPORT_UPPER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORT_UPPER_END_CUT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORT_LOWER_END_CUT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_SUPPORT_VERTICAL_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_SUPPORT_HORIZONTAL_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_LANDINGTYPE_LANDING_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_LANDINGTYPE_TREADRISER_TYPE: return StorageType.None;
                case BuiltInParameter.STAIRS_LANDINGTYPE_USE_SAME_TRISER_AS_RUN: return StorageType.Integer;
                case BuiltInParameter.STAIRS_LANDINGTYPE_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_LANDINGTYPE_STRUCTURE: return StorageType.None;
                case BuiltInParameter.STAIRS_LANDINGTYPE_HAS_MONOLITHIC_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_LANDING_OVERRIDDEN: return StorageType.Integer;
                case BuiltInParameter.STAIRS_LANDING_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_LANDING_STRUCTURAL: return StorageType.Integer;
                case BuiltInParameter.STAIRS_LANDING_BASE_ELEVATION: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUNTYPE_RUN_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_RUNTYPE_TOTAL_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUNTYPE_STRUCTURAL_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUNTYPE_STRUCTURE: return StorageType.None;
                case BuiltInParameter.STAIRS_RUNTYPE_UNDERSIDE_SURFACE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUNTYPE_HAS_MONOLITHIC_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_EXTEND_BELOW_TREAD_BASE: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_CCW: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_CREATE_AUTO_LANDING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_WINDER_END_WITH_STRAIGHT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_WINDER_BEGIN_WITH_STRAIGHT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_LOCATIONPATH_JUSTFICATION: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_END_WITH_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_BEGIN_WITH_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_OVERRIDDEN: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_STRUCTURAL: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_CENTER_MARK_VISIBLE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_ACTUAL_RUN_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_ACTUAL_TREAD_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_ACTUAL_RISER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_ACTUAL_NUMBER_OF_TREADS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_ACTUAL_NUMBER_OF_RISERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RUN_EXTEND_BELOW_RISER_BASE: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_TOP_ELEVATION: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_BOTTOM_ELEVATION: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_HAS_INTERMEDIATE_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_LEFT_SUPPORT_LATERAL_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_RIGHT_SUPPORT_LATERAL_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_CUTMARK_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRSTYPE_CONSTRUCTION_METHOD: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_HAS_RIGHT_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_HAS_LEFT_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_NOTCH_WIDTH: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_NOTCH_VERTICAL_GAP: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_NOTCH_HORIZONTAL_GAP: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_NOTCH_CUSTOM_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_NOTCH_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_NOTCH_EXTENSION: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_GEOMUNJOINED_END_CUT_STYLE: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_CALC_RULE_TARGET_RESULT: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_CALC_RULE_MIN_RESULT: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_CALC_RULE_MAX_RESULT: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_CALC_RULE_TREAD_MULTIPLIER: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_CALC_RULE_RISER_MULTIPLIER: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_IS_ASSEMBLED_STAIRS: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_NUMBER_OF_INTERMEDIATE_SUPPORTS: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_MINIMUM_RUN_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_WINDER_STEP_FRONT_MEASUREMENT: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_SHOW_UPDOWN: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_SHOW_STAIR_PATH: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_SHOW_CUTLINE: return StorageType.Integer;
                case BuiltInParameter.STAIRSTYPE_INTERMEDIATE_SUPPORT_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRSTYPE_LEFT_SIDE_SUPPORT_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRSTYPE_RIGHT_SIDE_SUPPORT_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRSTYPE_LANDING_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRSTYPE_RUN_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRSTYPE_CALCULATION_RULES: return StorageType.None;
                case BuiltInParameter.STAIRSTYPE_MINIMUM_TREAD_WIDTH_INSIDE_BOUNDARY: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_MINIMUM_TREAD_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRSTYPE_MAXIMUM_RISER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_TRISER_NUMBER_BASE_INDEX: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_ANNOTATION_CUT_MARK: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_MONOLITHIC_SUPPORT_CORSE_GEOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_TRISER_CORSE_GEOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_CORSE_GEOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_MONOLITHIC_SUPPORT_GEOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_TRISER_GEOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_GEOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_SUPPORT_PATH: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_BOUNDARY_3D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_BOUNDARY_2D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_LANDING_PATH: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_LANDING_BOUNDARY: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_OUTLINE_FOR_PLAN: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_NOSING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_PATH_3D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RUN_PATH_2D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RIGHT_RUN_BOUNDARY_3D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_LEFT_RUN_BOUNDARY_3D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_RIGHT_RUN_BOUNDARY_2D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_LEFT_RUN_BOUNDARY_2D: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_LANDING_FACES: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DBG_SHOW_TREAD_FACES: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ENABLE_CALCULATION_RULE_CHECKING: return StorageType.Integer;
                case BuiltInParameter.STAIRS_MIN_AUTOMATIC_LANDING_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RUN_WIDTH_MEASUREMENT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TOTAL_NUMBER_OF_TREADS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TOTAL_NUMBER_OF_RISERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ACTUAL_NUMBER_OF_RISERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_DESIRED_NUMBER_OF_RISERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_MULTISTORY_UP_TO_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_STAIRS_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_TOP_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_BASE_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.PART_MAKER_DIVISION_PROFILE_OFFSET: return StorageType.Double;
                case BuiltInParameter.DIVISION_PROFILE_WIDTH: return StorageType.Double;
                case BuiltInParameter.PART_MAKER_SPLITTER_PROFILE_EDGE_MATCH: return StorageType.Integer;
                case BuiltInParameter.PART_MAKER_SPLITTER_PROFILE_FLIP_ALONG: return StorageType.Integer;
                case BuiltInParameter.PART_MAKER_SPLITTER_PROFILE_FLIP_ACROSS: return StorageType.Integer;
                case BuiltInParameter.PART_MAKER_SPLITTER_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_KEYWORD_PROTECTED: return StorageType.Integer;
                case BuiltInParameter.PARTMAKER_PARAM_DIVISION_GAP: return StorageType.Double;
                case BuiltInParameter.POINTCLOUDINSTANCE_NAME: return StorageType.String;
                case BuiltInParameter.ANALYTICAL_MODEL_ROTATION: return StorageType.Double;
                case BuiltInParameter.POINTCLOUDTYPE_SCALE: return StorageType.Double;
                case BuiltInParameter.PROPERTY_SET_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.PROPERTY_SET_MATERIAL_ASPECT: return StorageType.Integer;
                case BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PROPERTIES: return StorageType.Integer;
                case BuiltInParameter.PROPERTY_SET_NAME: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SUBCLASS: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PARAM_CLASS: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_PERIMETER: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MODEL_AREA: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MODEL_LENGTH: return StorageType.Double;
                case BuiltInParameter.SHEET_ASSEMBLY_KEYNOTE: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_ASSEMBLY_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_COST: return StorageType.Double;
                case BuiltInParameter.SHEET_ASSEMBLY_TYPE_MARK: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_ASSEMBLY_CODE: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_URL: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_TYPE_COMMENTS: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_MANUFACTURER: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_MODEL: return StorageType.String;
                case BuiltInParameter.SHEET_ASSEMBLY_NAME: return StorageType.String;
                case BuiltInParameter.RBS_REFERENCE_FREESIZE: return StorageType.String;
                case BuiltInParameter.RBS_REFERENCE_OVERALLSIZE: return StorageType.String;
                case BuiltInParameter.RBS_REFERENCE_LINING_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RBS_REFERENCE_LINING_TYPE: return StorageType.String;
                case BuiltInParameter.RBS_REFERENCE_INSULATION_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RBS_REFERENCE_INSULATION_TYPE: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_CALCULATED_SIZE: return StorageType.String;
                case BuiltInParameter.RBS_DUCT_CALCULATED_SIZE: return StorageType.String;
                case BuiltInParameter.RBS_INSULATION_LINING_VOLUME: return StorageType.Double;
                case BuiltInParameter.ASSEMBLY_NAME: return StorageType.String;
                case BuiltInParameter.RBS_COMPONENT_CLASSIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_2LINEDROPSYMBOL_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_2LINERISESYMBOL_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_1LINEDROPSYMBOL_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_1LINERISESYMBOL_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_1LINETEEUPSYMBOL_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_RISEDROP_1LINETEEDOWNSYMBOL_PARAM: return StorageType.Integer;
                case BuiltInParameter.ASSEMBLY_NAMING_CATEGORY: return StorageType.ElementId;
                case BuiltInParameter.RAILING_SYSTEM_HAS_TOP_RAIL: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUSRAIL_JOIN_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUSRAIL_PLUS_TREAD_DEPTH_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUSRAIL_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.HANDRAIL_SUPPORTS_JUSTIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.HANDRAIL_SUPPORTS_NUMBER_PARAM: return StorageType.Integer;
                case BuiltInParameter.HANDRAIL_SUPPORTS_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.HANDRAIL_SUPPORTS_LAYOUT_PARAM: return StorageType.Integer;
                case BuiltInParameter.HANDRAIL_SUPPORTS_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.CONTINUOUSRAIL_END_EXTENSION_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.CONTINUOUSRAIL_END_TERMINATION_ATTACHMENT_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUSRAIL_EXTENSION_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.CONTINUOUSRAIL_BEGINNING_TERMINATION_ATTACHMENT_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUSRAIL_END_TERMINATION_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.CONTINUOUSRAIL_BEGINNING_TERMINATION_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.CONTINUOUSRAIL_MATERIALS_PARAM: return StorageType.ElementId;
                case BuiltInParameter.CONTINUOUSRAIL_TRANSITION_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.HANDRAIL_HAND_CLEARANCE_PARAM: return StorageType.Double;
                case BuiltInParameter.HANDRAIL_PROJECTION_PARAM: return StorageType.Double;
                case BuiltInParameter.HANDRAIL_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.CONTINUOUSRAIL_PROFILE_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.CONTINUOUSRAIL_FILLET_RADIUS_PARAM: return StorageType.Double;
                case BuiltInParameter.CONTINUOUSRAIL_DEFAULT_JOIN_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RAILING_SYSTEM_SECONDARY_HANDRAILS_LATTERAL_OFFSET: return StorageType.Double;
                case BuiltInParameter.RAILING_SYSTEM_SECONDARY_HANDRAILS_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RAILING_SYSTEM_SECONDARY_HANDRAILS_POSITION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RAILING_SYSTEM_SECONDARY_HANDRAILS_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RAILING_SYSTEM_HANDRAILS_LATTERAL_OFFSET: return StorageType.Double;
                case BuiltInParameter.RAILING_SYSTEM_HANDRAILS_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RAILING_SYSTEM_HANDRAILS_POSITION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RAILING_SYSTEM_HANDRAILS_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RAILING_SYSTEM_TOP_RAIL_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RAILING_SYSTEM_TOP_RAIL_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.POINT_ELEMENT_ROTATION_ANGLE: return StorageType.Double;
                case BuiltInParameter.FLEXIBLE_INSTANCE_FLIP: return StorageType.Integer;
                case BuiltInParameter.POINT_FLEXIBLE_ORIENTATION_TYPE: return StorageType.Integer;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_FLOOR: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_OPENING: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_SKYLIGHT: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_GLAZING: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_EXT_WALL_UNDERGROUND: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_SLAB: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_SHADE: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_ROOF: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_INTERIOR_WALL: return StorageType.ElementId;
                case BuiltInParameter.DEFAULT_CONSTRUCTION_MASS_EXTERIOR_WALL: return StorageType.ElementId;
                case BuiltInParameter.ENERGY_ANALYSIS_SPACE_BOUNDING_PARAM: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_HORIZONTAL_VOID_THRESHOLD: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_VERTICAL_VOID_THRESHOLD: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_BUILDING_ENVELOPE_ANALYTICAL_GRID_CELL_SIZE:
                    return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_BUILDING_ENVELOPE_DETERMINATION_PARAM:
                    return StorageType.Integer;
                case BuiltInParameter.LEADER_RIGHT_ATTACHMENT: return StorageType.Integer;
                case BuiltInParameter.LEADER_LEFT_ATTACHMENT: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_MEASURE_FROM: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_ANGLE: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_CHORD_LENGTH: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_NORMALIZED_SEGMENT_LENGTH: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_SEGMENT_LENGTH: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_NORMALIZED_CURVE_PARAMATER: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_NON_NORMALIZED_CURVE_PARAMATER: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_MEASUREMENT_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_END_ATTACHMENT_REFCOLUMN_END: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_START_ATTACHMENT_REFCOLUMN_END: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_END_ATTACHMENT_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_BEAM_START_ATTACHMENT_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_BEAM_END_ATTACHMENT_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_START_ATTACHMENT_TYPE: return StorageType.Integer;
                case BuiltInParameter.TEXT_BOX_VISIBILITY: return StorageType.Integer;
                case BuiltInParameter.CURVE_BY_POINTS_PROJECTION_TYPE: return StorageType.Integer;
                case BuiltInParameter.FOLLOW_SURFACE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_INCLUDE_THERMAL_PROPERTIES: return StorageType.Integer;
                case BuiltInParameter.POINT_FLEXIBLE_NUM_PARAM: return StorageType.Integer;
                case BuiltInParameter.FRAMING_LENGTH_ROUNDOFF: return StorageType.Double;
                case BuiltInParameter.SLANTED_COLUMN_BASE_EXTENSION: return StorageType.Double;
                case BuiltInParameter.SLANTED_COLUMN_TOP_EXTENSION: return StorageType.Double;
                case BuiltInParameter.SLANTED_COLUMN_BASE_CUT_STYLE: return StorageType.Integer;
                case BuiltInParameter.SLANTED_COLUMN_TOP_CUT_STYLE: return StorageType.Integer;
                case BuiltInParameter.RBS_BUILDING_USELOADCREDITS: return StorageType.Integer;
                case BuiltInParameter.TILE_PATTERN_FAMREF_COMPONENT_EXTENTS: return StorageType.Integer;
                case BuiltInParameter.TILE_PATTERN_GRID_CELLS_Y: return StorageType.Integer;
                case BuiltInParameter.TILE_PATTERN_GRID_CELLS_X: return StorageType.Integer;
                case BuiltInParameter.TILE_PATTERN_GRID_UNIT_Y: return StorageType.Double;
                case BuiltInParameter.TILE_PATTERN_GRID_UNIT_X: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_SHOW_NORMAL_PLANE_ONLY: return StorageType.Integer;
                case BuiltInParameter.LEVEL_IS_GROUND_PLANE: return StorageType.Integer;
                case BuiltInParameter.BASEPOINT_ANGLETON_PARAM: return StorageType.Double;
                case BuiltInParameter.BASEPOINT_ELEVATION_PARAM: return StorageType.Double;
                case BuiltInParameter.BASEPOINT_EASTWEST_PARAM: return StorageType.Double;
                case BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM: return StorageType.Double;
                case BuiltInParameter.SLANTED_COLUMN_GEOMETRY_TREATMENT_BASE: return StorageType.Integer;
                case BuiltInParameter.SLANTED_COLUMN_GEOMETRY_TREATMENT_TOP: return StorageType.Integer;
                case BuiltInParameter.ROOM_PLENUM_LIGHTING_PARAM: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_TOP_REFERENCEDEND: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_TOP_RATIO: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_TOP_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_TOP_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_BASE_REFERENCEDEND: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_BASE_RATIO: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_BASE_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_BASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.INSTANCE_MOVE_BASE_WITH_GRIDS: return StorageType.Integer;
                case BuiltInParameter.INSTANCE_MOVE_TOP_WITH_GRIDS: return StorageType.Integer;
                case BuiltInParameter.SLANTED_COLUMN_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.VIEW_SLANTED_COLUMN_SYMBOL_OFFSET: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_MIRRORED: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_ZFLIPPED: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_HOSTED_ON_FACE_V_PARAM: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_HOSTED_ON_FACE_U_PARAM: return StorageType.Double;
                case BuiltInParameter.LOCKED_END_OFFSET: return StorageType.Double;
                case BuiltInParameter.LOCKED_START_OFFSET: return StorageType.Double;
                case BuiltInParameter.LOCKED_BASE_OFFSET: return StorageType.Double;
                case BuiltInParameter.LOCKED_TOP_OFFSET: return StorageType.Double;
                case BuiltInParameter.RBS_PROJECT_REPORTTYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_BUILDING_CONSTRUCTIONCLASS: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_UTILITY_PARAM: return StorageType.Integer;
                case BuiltInParameter.POINT_FLEXIBLE_SHOW_NUMBER: return StorageType.Integer;
                case BuiltInParameter.POINT_FLEXIBLE_CONSTRAINED: return StorageType.Integer;
                case BuiltInParameter.POINT_NAME_PARAM: return StorageType.String;
                case BuiltInParameter.POINT_ADAPTIVE_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.SPOT_DIM_STYLE_SLOPE_UNITS: return StorageType.None;
                case BuiltInParameter.POINT_ELEMENT_DRIVING: return StorageType.Integer;
                case BuiltInParameter.SPOT_SLOPE_LEADER_LENGTH: return StorageType.Double;
                case BuiltInParameter.SPOT_SLOPE_SUFFIX: return StorageType.String;
                case BuiltInParameter.SPOT_SLOPE_PREFIX: return StorageType.String;
                case BuiltInParameter.POINT_VISIBILITY_PARAM: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_SHOW_PLANES: return StorageType.Integer;
                case BuiltInParameter.CURVE_IS_REFERENCE_LINE: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_HOSTED_PARAM: return StorageType.Double;
                case BuiltInParameter.POINT_ELEMENT_DRIVEN: return StorageType.Integer;
                case BuiltInParameter.POINT_ELEMENT_OFFSET: return StorageType.Double;
                case BuiltInParameter.SPOT_DIM_STYLE_SLOPE_UNITS_ALT: return StorageType.None;
                case BuiltInParameter.FBX_LIGHT_PHOTOMETRIC_FILE_CACHE: return StorageType.String;
                case BuiltInParameter.FBX_LIGHT_PHOTOMETRICS_FAM: return StorageType.String;
                case BuiltInParameter.FAMILY_CURVE_ATTACHMENT_PROPORTION: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_LOSS_FACTOR_CTRL: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_INITIAL_COLOR_CTRL: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_LOSS_FACTOR_METHOD: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_INITIAL_COLOR_NAME: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_AT_A_DISTANCE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_INITIAL_INTENSITY_INPUT_METHOD: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_SOURCE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_SOURCE_DIAMETER: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_EMIT_CIRCLE_DIAMETER: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_EMIT_RECTANGLE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_EMIT_RECTANGLE_WIDTH: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_EMIT_LINE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_EMIT_SHAPE_VISIBLE: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_DIMMING_LIGHT_COLOR: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_LUMENAIRE_DIRT: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_LAMP_LUMEN_DEPR: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_SURFACE_LOSS: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_LAMP_TILT_LOSS: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_VOLTAGE_LOSS: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_TEMPERATURE_LOSS: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_COLOR_FILTER: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_INITIAL_COLOR_TEMPERATURE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_ILLUMINANCE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_LIMUNOUS_INTENSITY: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_EFFICACY: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_WATTAGE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_INITIAL_INTENSITY: return StorageType.Integer;
                case BuiltInParameter.FBX_LIGHT_PHOTOMETRICS: return StorageType.None;
                case BuiltInParameter.FBX_ASSET_TYPE: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_GRID_OPTION_PARAM_2: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_GRID_OPTION_PARAM_1: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_DISCARDEDDIVISIONLINES: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_COMPONENT_TRIM_TYPE: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_MIRROR: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_RULE_2_SUSPENSION: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_RULE_1_SUSPENSION: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_COMPONENTS: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_FILL_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_PATTERN_FILL: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_LINES_STYLE: return StorageType.ElementId;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_PATTERN_LINES: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_GRIDLINES_STYLE: return StorageType.ElementId;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_GRIDLINES: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_NODES: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_ORIGINAL_SURFACE_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_ORIGINAL_SURFACE: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_DISPLAY_SURFACE_OPTION: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_ALL_GRID_ROTATION: return StorageType.Double;
                case BuiltInParameter.DIVIDED_SURFACE_TILE_BORDER: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_ALL_POINTS: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN: return StorageType.ElementId;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_FLIP: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_ROTATION_ANGLE: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_INDENT_2: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_PATTERN_INDENT_1: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_COVER_FACE_COMPLETELY: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_OFFSET_FROM_SURFACE: return StorageType.Double;
                case BuiltInParameter.DIVIDED_SURFACE_TOTAL_EDGE_LENGTH: return StorageType.Double;
                case BuiltInParameter.DIVIDED_SURFACE_EDGE_NUMBER: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_POINT_NUMBER: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_FACET_NUMBER: return StorageType.Integer;
                case BuiltInParameter.DIVIDED_SURFACE_SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_ROOM_LIGHTING_CALC_LUMINAIREPLANE: return StorageType.Double;
                case BuiltInParameter.LAYOUTNODE_CURVETYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FABRICATION_PART_PAT_NO: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_END_SIZE: return StorageType.String;
                case BuiltInParameter.FABRICATION_BRA_SIZE: return StorageType.String;
                case BuiltInParameter.FABRICATION_SEC_SIZE: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRI_SIZE: return StorageType.String;
                case BuiltInParameter.FABRICATION_CHANGE_SERVICE_PARAM: return StorageType.None;
                case BuiltInParameter.FABRICATION_SET_UP_DOWN_TAG_FROM_BOTTOM: return StorageType.String;
                case BuiltInParameter.FABRICATION_INSULATION_MATERIAL_FINISH: return StorageType.ElementId;
                case BuiltInParameter.DISPLACED_ELEMENT_DISPLACEMENT_Z: return StorageType.Double;
                case BuiltInParameter.DISPLACED_ELEMENT_DISPLACEMENT_Y: return StorageType.Double;
                case BuiltInParameter.DISPLACED_ELEMENT_DISPLACEMENT_X: return StorageType.Double;
                case BuiltInParameter.DISPLACEMENT_PATH_STYLE: return StorageType.Integer;
                case BuiltInParameter.DISPLACEMENT_PATH_DEPTH: return StorageType.Integer;
                case BuiltInParameter.REFERENCE_VIEWER_UI_TARGET_VIEW: return StorageType.ElementId;
                case BuiltInParameter.REFERENCE_VIEWER_UI_TARGET_FILTER: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_FITTING_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_DOUBLEWALL_MATERIAL_ABBREVIATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_MATERIAL_ABBREVIATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_INSULATION_SPECIFICATION_ABBREVIATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_INSULATION_ABBREVIATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_SPECIFICATION_ABBREVIATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PIPE_INVERT_ELEVATION: return StorageType.Double;
                case BuiltInParameter.FABRICATION_BOTTOM_ELEVATION_INCLUDE_INSULATION_OF_PART:
                    return StorageType.Double;
                case BuiltInParameter.FABRICATION_BOTTOM_ELEVATION_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_TOP_ELEVATION_INCLUDE_INSULATION_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_TOP_ELEVATION_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_CENTERLINE_ELEVATION_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_SPOT_BOTTOM_ELEVATION_INCLUDE_INSULATION_OF_PART:
                    return StorageType.Double;
                case BuiltInParameter.FABRICATION_SPOT_BOTTOM_ELEVATION_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_SPOT_TOP_ELEVATION_INCLUDE_INSULATION_OF_PART:
                    return StorageType.Double;
                case BuiltInParameter.FABRICATION_SPOT_TOP_ELEVATION_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL_AREA: return StorageType.Double;
                case BuiltInParameter.FABRICATION_SET_UP_DOWN_TAG: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_SHEETMETAL_AREA: return StorageType.Double;
                case BuiltInParameter.FABRICATION_SERVICE_ABBREVIATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_MATERIAL_THICKNESS: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_NOTES: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_LINING_AREA: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_ITEM_NUMBER: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_INSULATION_AREA: return StorageType.Double;
                case BuiltInParameter.FABRICATION_SERVICE_NAME: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL_THICKNESS: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_DOUBLEWALL_MATERIAL: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_PART_CUT_TYPE: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_PART_BOUGHT_OUT: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_ALIAS: return StorageType.String;
                case BuiltInParameter.FABRICATION_ROUTING_SOLUTIONS_UI_PARAM: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_CODE: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_TAKEOFF_DIALOG_PARAM: return StorageType.None;
                case BuiltInParameter.FABRICATION_PART_DEPTH_OUT_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_WIDTH_OUT_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_DIAMETER_OUT_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_DIAMETER_IN_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_DEPTH_IN_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_WIDTH_IN_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_ANGLE_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_LENGTH_OPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_INSULATION_SPEC: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_PART_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PRODUCT_ENTRY: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_DEPTH_OUT: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_WIDTH_OUT: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_DIAMETER_OUT: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_DEPTH_IN: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_WIDTH_IN: return StorageType.Double;
                case BuiltInParameter.FABRICATION_END_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.FABRICATION_START_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.FABRICATION_SLOPE_PARAM: return StorageType.Double;
                case BuiltInParameter.FABRICATION_RELATIVE_FILENAME: return StorageType.String;
                case BuiltInParameter.FABRICATION_VENDOR: return StorageType.String;
                case BuiltInParameter.FABRICATION_BOTTOM_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_TOP_OF_PART: return StorageType.Double;
                case BuiltInParameter.FABRICATION_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.FABRICATION_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FABRICATION_SPECIFICATION: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_VENDOR_CODE: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_WEIGHT: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_DIAMETER_IN: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PART_ANGLE: return StorageType.Double;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_INSTALL_TYPE: return StorageType.String;
                case BuiltInParameter.FABRICATION_PART_MATERIAL: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_OEM: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_PRODUCT: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_ITEM_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_SIZE_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_MATERIAL_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_SPECIFICATION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_LONG_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_RANGE: return StorageType.String;
                case BuiltInParameter.FABRICATION_PRODUCT_DATA_FINISH_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.TRUSS_FAMILY_BOTTOM_CHORD_STRUCTURAL_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_FAMILY_BOTTOM_CHORD_ANGLE_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_FAMILY_BOTTOM_CHORD_VERTICAL_PROJECTION_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_FAMILY_BOTTOM_CHORD_START_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_BOTTOM_CHORD_END_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.REFERENCE_OTHER_VIEW_UI_REF_VIEW: return StorageType.ElementId;
                case BuiltInParameter.REFERENCE_OTHER_VIEW_UI_TOGGLE: return StorageType.Integer;
                case BuiltInParameter.JOIST_SYSTEM_ELEM_TAG_NEW_MEMBERS_VIEW: return StorageType.ElementId;
                case BuiltInParameter.REFERENCE_VIEWER_ATTR_TAG: return StorageType.ElementId;
                case BuiltInParameter.REFERENCE_VIEWER_TARGET_VIEW: return StorageType.ElementId;
                case BuiltInParameter.MATCHLINE_BOTTOM_PLANE: return StorageType.ElementId;
                case BuiltInParameter.MATCHLINE_TOP_PLANE: return StorageType.ElementId;
                case BuiltInParameter.MATCHLINE_BOTTOM_OFFSET: return StorageType.Double;
                case BuiltInParameter.MATCHLINE_TOP_OFFSET: return StorageType.Double;
                case BuiltInParameter.TRUSS_FAMILY_TOP_CHORD_STRUCTURAL_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_FAMILY_TOP_CHORD_ANGLE_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_FAMILY_TOP_CHORD_VERTICAL_PROJECTION_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_FAMILY_TOP_CHORD_START_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_TOP_CHORD_END_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_DIAG_WEB_STRUCTURAL_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_FAMILY_DIAG_WEB_ANGLE_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_FAMILY_DIAG_WEB_START_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_DIAG_WEB_END_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_VERT_WEB_STRUCTURAL_TYPES_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_FAMILY_VERT_WEB_ANGLE_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_FAMILY_VERT_WEB_START_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_VERT_WEB_END_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_TAG_NEW_MEMBERS_VIEW: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_NON_BEARING_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_BEARING_CHORD_TOP_BOTTOM_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_SPAN_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_ELEMENT_STICK_JUST_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_FAMILY_WEBS_HAVE_SYMBOLIC_CUTBACK_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_HEIGHT: return StorageType.Double;
                case BuiltInParameter.TRUSS_FAMILY_TRANSFORMATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_ROTATE_CHORDS_WITH_TRUSS: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_REFERENCE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.TRUSS_ELEMENT_END1_ELEVATION: return StorageType.Double;
                case BuiltInParameter.TRUSS_ELEMENT_END0_ELEVATION: return StorageType.Double;
                case BuiltInParameter.TRUSS_ELEMENT_BEARING_JUST_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_CREATE_BOTTOM_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_CREATE_TOP_PARAM: return StorageType.Integer;
                case BuiltInParameter.TRUSS_ELEMENT_ANGLE_PARAM: return StorageType.Double;
                case BuiltInParameter.TRUSS_ELEMENT_CLASS_PARAM: return StorageType.String;
                case BuiltInParameter.TRUSS_LENGTH: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_PARAM_PRESET_AREA: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_PARAM_PRESET_LINEAR: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_PARAM_PRESET: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Z_TRANSLATION_SPRING: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Z_TRANSLATION_FIXED: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Z_ROTATION_SPRING: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Z_ROTATION_FIXED: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Y_TRANSLATION_SPRING: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Y_TRANSLATION_FIXED: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Y_ROTATION_SPRING: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_Y_ROTATION_FIXED: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_X_TRANSLATION_SPRING: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_X_TRANSLATION_FIXED: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_X_ROTATION_SPRING: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_X_ROTATION_FIXED: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_AREA_RESTRAINT_Z: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_AREA_RESTRAINT_Y: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_AREA_RESTRAINT_X: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_LINEAR_RESTRAINT_ROT_X: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_LINEAR_RESTRAINT_Z: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_LINEAR_RESTRAINT_Y: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_LINEAR_RESTRAINT_X: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_RESTRAINT_ROT_Z: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_RESTRAINT_ROT_Y: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_RESTRAINT_ROT_X: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_RESTRAINT_Z: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_RESTRAINT_Y: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_RESTRAINT_X: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_DIRECTION_ROT_Z: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_DIRECTION_ROT_Y: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_DIRECTION_ROT_X: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_DIRECTION_Z: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_DIRECTION_Y: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_DIRECTION_X: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_CONDITIONS_IS_EXT: return StorageType.Integer;
                case BuiltInParameter.BOUNDARY_CONDITIONS_TYPE: return StorageType.Integer;
                case BuiltInParameter.KEY_SOURCE_PARAM: return StorageType.String;
                case BuiltInParameter.KEYNOTE_PARAM: return StorageType.String;
                case BuiltInParameter.KEYNOTE_NUMBER: return StorageType.String;
                case BuiltInParameter.SHEET_KEY_NUMBER: return StorageType.Integer;
                case BuiltInParameter.KEYNOTE_TEXT: return StorageType.String;
                case BuiltInParameter.KEY_VALUE: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PARAM_GRADE: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SPECIES: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_BENDING: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_PERPENDICULAR: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_PARALLEL: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_COMPRESSION_PERPENDICULAR: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_COMPRESSION_PARALLEL: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_TYPE: return StorageType.Integer;
                case BuiltInParameter.ELEM_CATEGORY_PARAM_MT: return StorageType.ElementId;
                case BuiltInParameter.ELEM_CATEGORY_PARAM: return StorageType.ElementId;
                case BuiltInParameter.MATERIAL_VOLUME: return StorageType.Double;
                case BuiltInParameter.MATERIAL_AREA: return StorageType.Double;
                case BuiltInParameter.MATERIAL_ASPAINT: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_NAME: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_SLOPE_OPTIONS_DEF_PARAM: return StorageType.Integer;
                case BuiltInParameter.FABRICATION_SERVICE_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_ANGLE_OF_DEFLECTION: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_LENGTH: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_SYSTEM_CALCULATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_SYSTEM_CALCULATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_SYSTEM_ABBREVIATION_PARAM: return StorageType.String;
                case BuiltInParameter.MEP_SYSTEM_LINE_GRAPHICS_OVERRIDES_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_PIPE_SLOPE_DEF_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_ENGAGEMENT_LENGTH: return StorageType.Double;
                case BuiltInParameter.RBS_SYSTEM_FLOW_CONVERSION_METHOD_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_NUM_ELEMENTS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SYSTEM_BASE_ELEMENT_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_SYSTEM_CLASSIFICATION_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_SYSTEM_NAME_PARAM: return StorageType.String;
                case BuiltInParameter.PHY_MATERIAL_PARAM_LIGHT_WEIGHT: return StorageType.Integer;
                case BuiltInParameter.PHY_MATERIAL_PARAM_BEHAVIOR: return StorageType.Integer;
                case BuiltInParameter.PHY_MATERIAL_PARAM_RESISTANCE_CALC_STRENGTH: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_REDUCTION_FACTOR: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_MINIMUM_TENSILE_STRENGTH: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_MINIMUM_YIELD_STRESS: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_STRENGTH_REDUCTION: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_REINFORCEMENT: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_BENDING_REINFORCEMENT: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_CONCRETE_COMPRESSION: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF3: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF2: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_EXP_COEFF1: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_UNIT_WEIGHT: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD3: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD2: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_SHEAR_MOD1: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD3: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD2: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_POISSON_MOD1: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD3: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD2: return StorageType.Double;
                case BuiltInParameter.PHY_MATERIAL_PARAM_YOUNG_MOD1: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_SIZE_MAXIMUM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_SIZE_MINIMUM: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_PRESSURE_DROP: return StorageType.Double;
                case BuiltInParameter.ROUTING_PREFERENCE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DUCT_ROUTING_PREFERENCE_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_SEGMENT_DESCRIPTION_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_JOINTTYPE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_SEGMENT_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_ROUTING_PREFERENCE_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_PARALLELPIPES_VERTICAL_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.RBS_PARALLELPIPES_HORIZONTAL_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.RBS_PARALLELPIPES_VERTICAL_NUMBER: return StorageType.Integer;
                case BuiltInParameter.RBS_PARALLELPIPES_HORIZONTAL_NUMBER: return StorageType.Integer;
                case BuiltInParameter.RBS_PARALLELCONDUITS_VERTICAL_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.RBS_PARALLELCONDUITS_HORIZONTAL_OFFSET_VALUE: return StorageType.Double;
                case BuiltInParameter.RBS_PARALLELCONDUITS_VERTICAL_NUMBER: return StorageType.Integer;
                case BuiltInParameter.RBS_PARALLELCONDUITS_HORIZONTAL_NUMBER: return StorageType.Integer;
                case BuiltInParameter.RBS_FP_SPRINKLER_ORIFICE_SIZE_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_FP_SPRINKLER_TEMPERATURE_RATING_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_FP_SPRINKLER_K_FACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_FP_SPRINKLER_PRESSURE_CLASS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_FP_SPRINKLER_ORIFICE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_FP_SPRINKLER_COVERAGE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_FP_SPRINKLER_RESPONSE_PARAM: return StorageType.Integer;
                case BuiltInParameter.MEP_PROFILE_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_SHOW_PROFILE_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_SYSTEM_FIXTURE_UNIT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_SLOPE: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_SLOPE: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_UTSLOPE: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_VOLUME_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_WFU_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_HWFU_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_CWFU_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FLOW_CONFIGURATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_FLOW_DIRECTION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_FIXTURE_UNITS_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_STATIC_PRESSURE: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_INSULATION_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_BOTTOM_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_TOP_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_OUTER_DIAMETER: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_INVERT_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_TYPE_FITTING_LOSS_METHOD_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_TYPE_FITTING_LOSS_TABLE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_TYPE_FITTING_LOSS_KFACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_TYPE_VALVE_LOSS_CVFACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FITTING_LOSS_METHOD_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_FITTING_LOSS_TABLE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_PIPE_FITTING_LOSS_KFACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_VALVE_LOSS_CVFACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_ADDITIONAL_FLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_DIAMETER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_SLOPE: return StorageType.Double;
                case BuiltInParameter.RBS_ADJUSTABLE_CONNECTOR: return StorageType.Integer;
                case BuiltInParameter.RBS_FLOW_FACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_FLOW_CONFIGURATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_DUCT_FLOW_DIRECTION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_FLUID_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PIPE_FLUID_TEMPERATURE_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FLUID_VISCOSITY_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FLUID_DENSITY_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_INNER_DIAM_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_REYNOLDS_NUMBER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_RELATIVE_ROUGHNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FLOW_STATE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_FRICTION_FACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_VELOCITY_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FRICTION_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_PRESSUREDROP_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_ROUGHNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_MATERIAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PIPE_CONNECTIONTYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PIPE_CLASS_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_CONNECTION_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_PATH_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_PATH_MODE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_START_SLOT: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_GENDER_TYPE: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_JOINT_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_CONFIGURATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_LOCATION_PARAM: return StorageType.String;
                case BuiltInParameter.PANEL_SCHEDULE_NAME: return StorageType.String;
                case BuiltInParameter.TEMPLATE_NAME: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEC_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEB_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_CURRENT_PHASEA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_DEMAND_FACTOR_RULE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_DEMAND_CURRENT_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_CONNECTED_CURRENT_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_DEMAND_LOAD_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_DEMAND_FACTOR_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_CONNECTED_LOAD_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_LOADSUMMARY_LOADCLASSIFICATION_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_NOTES_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER_OF_ELEMENTS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_FRAME_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTAL_DEMAND_CURRENT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTAL_CONNECTED_CURRENT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTAL_DEMAND_FACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_SCHEDULE_FOOTER_NOTES_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_SCHEDULE_HEADER_NOTES_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_NUMWIRES_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_NUMPHASES_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_NEUTRAL_RATING_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_NEUTRAL_BUS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_GROUND_BUS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_BUSSING_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_SUBFEED_LUGS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_SUPPLY_FROM_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_MCB_RATING_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_MAINSTYPE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_FEED_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_CONDUITRUN_OUTER_DIAM_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CONDUITRUN_INNER_DIAM_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CONDUITRUN_DIAMETER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAYRUN_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAYRUN_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAYCONDUITRUN_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_LOAD_SUB_CLASSIFICATION_MOTOR: return StorageType.Integer;
                case BuiltInParameter.RBS_CABLETRAY_SHAPETYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_CABLETRAYCONDUIT_BENDORFITTING: return StorageType.Integer;
                case BuiltInParameter.RBS_CTC_SERVICE_TYPE: return StorageType.String;
                case BuiltInParameter.RBS_CONDUIT_OUTER_DIAM_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CONDUIT_INNER_DIAM_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_CTC_TOP_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.CIRCUIT_LOAD_CLASSIFICATION_PARAM: return StorageType.String;
                case BuiltInParameter.CABLETRAY_MINBENDMULTIPLIER_PARAM: return StorageType.Double;
                case BuiltInParameter.CONDUIT_STANDARD_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CONDUIT_TRADESIZE: return StorageType.String;
                case BuiltInParameter.RBS_CONDUIT_BENDRADIUS: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_BENDRADIUS: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_RUNGHEIGHT: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_RUNGWIDTH: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_RUNGSPACE: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAY_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_SWITCH_ID_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_WIRE_CIRCUIT_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.RBS_WIRE_CIRCUIT_LOAD_NAME: return StorageType.String;
                case BuiltInParameter.RBS_WIRE_NUM_CONDUCTORS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_TICKMARK_STATE: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_PANEL_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_NUMBER: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_WIRE_CIRCUITS: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_RUNS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_HOTS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_NEUTRALS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_NUM_GROUNDS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_ELEVATION: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_WIRE_HOT_ADJUSTMENT: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_NEUTRAL_ADJUSTMENT: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_GROUND_ADJUSTMENT: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_SHARE_NEUTRAL: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_WIRE_SHARE_GROUND: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_NAME: return StorageType.String;
                case BuiltInParameter.RBS_FAMILY_CONTENT_SECONDARY_DISTRIBSYS: return StorageType.ElementId;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_NAMING: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_PREFIX_SEPARATOR: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_PREFIX: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_MODIFICATIONS: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_ENCLOSURE: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_MAINS: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_MOUNTING: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_SHORT_CIRCUIT_RATING: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_MAX_POLE_BREAKERS: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_PANEL_NAME: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_HVAC_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_HVAC_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_LIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_LIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_POWER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_POWER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_OTHER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_OTHER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALESTLOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_PANEL_TOTALLOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_DEMANDFACTOR_LOADCLASSIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_DEMANDFACTOR_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_DEMANDFACTOR_DEMANDLOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_FAMILY_CONTENT_DISTRIBUTION_SYSTEM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DISTRIBUTIONSYS_VLL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DISTRIBUTIONSYS_VLG_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DISTRIBUTIONSYS_PHASE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_DISTRIBUTIONSYS_CONFIG_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_DISTRIBUTIONSYS_NUMWIRES_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_VOLTAGETYPE_VOLTAGE_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_VOLTAGETYPE_MINVOLTAGE_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_VOLTAGETYPE_MAXVOLTAGE_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEC: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEB: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASEA: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEC: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEB: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASEA: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEB_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_CURRENT_PHASEC_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEB_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_CURRENT_PHASEC_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_VOLTAGE_DROP_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_CALC_COEFFICIENT_UTILIZATION: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_RATING_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_SIZE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_WIRE_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_ELEC_ROOM_CAVITY_RATIO: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_PHOTOMETRIC_FILE: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_ROOM_AVERAGE_ILLUMINATION: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_FLOOR: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_WALLS: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_ROOM_REFLECTIVITY_CEILING: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_ROOM_LIGHTING_CALC_WORKPLANE: return StorageType.Double;
                case BuiltInParameter.RBS_WIRE_MATERIAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_WIRE_TEMPERATURE_RATING_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_WIRE_INSULATION_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_WIRE_MAX_CONDUCTOR_SIZE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_WIRE_NEUTRAL_MULTIPLIER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_WIRE_NEUTRAL_INCLUDED_IN_BALANCED_LOAD_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_WIRE_NEUTRAL_MODE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_WIRE_CONDUIT_TYPE_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_ELEC_AMBIENT_TEMPERATURE: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_CIRCUIT_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_LOAD_CLASSIFICATION: return StorageType.ElementId;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASE3: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASE2: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD_PHASE1: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_TRUE_LOAD: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_POWER_FACTOR_STATE: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_POWER_FACTOR: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASE3: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASE2: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD_PHASE1: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_APPARENT_LOAD: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_BALANCED_LOAD: return StorageType.Integer;
                case BuiltInParameter.RBS_ELEC_VOLTAGE: return StorageType.Double;
                case BuiltInParameter.RBS_ELEC_NUMBER_OF_POLES: return StorageType.Integer;
                case BuiltInParameter.RBS_CONNECTOR_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.VIEW_FAMILY_SCHEDULES: return StorageType.String;
                case BuiltInParameter.VIEW_FAMILY_AND_TYPE_SCHEDULES: return StorageType.String;
                case BuiltInParameter.VIEW_TYPE_SCHEDULES: return StorageType.String;
                case BuiltInParameter.MARKUPS_PRIVATE: return StorageType.String;
                case BuiltInParameter.MARKUPS_NOTES: return StorageType.String;
                case BuiltInParameter.MARKUPS_HISTORY: return StorageType.String;
                case BuiltInParameter.MARKUPS_STATUS: return StorageType.Integer;
                case BuiltInParameter.MARKUPS_LABEL: return StorageType.String;
                case BuiltInParameter.MARKUPS_CREATOR: return StorageType.String;
                case BuiltInParameter.MARKUPS_CREATED: return StorageType.String;
                case BuiltInParameter.MARKUPS_MODIFIED: return StorageType.String;
                case BuiltInParameter.VIEW_SCHEMA_SETTING_FOR_SYSTEM_TEMPLATE: return StorageType.None;
                case BuiltInParameter.LEGEND_COMPONENT_DETAIL_LEVEL: return StorageType.Integer;
                case BuiltInParameter.LEGEND_COMPONENT_LENGTH: return StorageType.Double;
                case BuiltInParameter.LEGEND_COMPONENT_VIEW: return StorageType.Integer;
                case BuiltInParameter.LEGEND_COMPONENT: return StorageType.ElementId;
                case BuiltInParameter.OPTION_SET_ID: return StorageType.ElementId;
                case BuiltInParameter.OPTION_NAME: return StorageType.String;
                case BuiltInParameter.PRIMARY_OPTION_ID: return StorageType.ElementId;
                case BuiltInParameter.OPTION_SET_NAME: return StorageType.String;
                case BuiltInParameter.GROUP_ATTACHED_PARENT_NAME: return StorageType.String;
                case BuiltInParameter.GROUP_ALLOWED_VIEW_TYPES: return StorageType.String;
                case BuiltInParameter.GROUP_OFFSET_FROM_LEVEL: return StorageType.Double;
                case BuiltInParameter.GROUP_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.MEP_SYSTEM_FILL_GRAPHICS_OVERRIDES_PARAM: return StorageType.None;
                case BuiltInParameter.DUCT_TERMINAL_ENGAGEMENT_LENGTH: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_INSIDE_DIAMETER: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_DIAMETER: return StorageType.Double;
                case BuiltInParameter.RBS_CABLETRAYCONDUIT_CONNECTORELEM_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_CABLETRAYCONDUIT_SYSTEM_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_CONNECTOR_ISPRIMARY: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_REFERENCE_INDEX: return StorageType.Integer;
                case BuiltInParameter.RBS_PIPE_CONNECTOR_SYSTEM_CLASSIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_ANGLE: return StorageType.Double;
                case BuiltInParameter.RBS_DUCT_CONNECTOR_SYSTEM_CLASSIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_INDEX: return StorageType.Integer;
                case BuiltInParameter.CONNECTOR_VISIBLE_SIZE: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_HEIGHT: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_WIDTH: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_RADIUS: return StorageType.Double;
                case BuiltInParameter.CONNECTOR_PROFILE_TYPE: return StorageType.Integer;
                case BuiltInParameter.PIPING_GENDER_TYPE: return StorageType.String;
                case BuiltInParameter.PIPING_CONNECTION_TYPE: return StorageType.String;
                case BuiltInParameter.RBS_PART_TYPE: return StorageType.Integer;
                case BuiltInParameter.PEAK_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_REFERENCE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SPACE_INFILTRATION_AIRFLOW: return StorageType.Double;
                case BuiltInParameter.SPACE_INFILTRATION_AIRFLOW_PER_AREA: return StorageType.Double;
                case BuiltInParameter.SPACE_OUTDOOR_AIRFLOW: return StorageType.Double;
                case BuiltInParameter.SPACE_OUTDOOR_AIRFLOW_PER_PERSON: return StorageType.Double;
                case BuiltInParameter.SPACE_OUTDOOR_AIRFLOW_PER_AREA: return StorageType.Double;
                case BuiltInParameter.SPACE_AIR_CHANGES_PER_HOUR: return StorageType.Double;
                case BuiltInParameter.SPACE_POWER_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_LIGHTING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_PEOPLE_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_POWER_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_LIGHTING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_PEOPLE_LATENT_HEAT_GAIN_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_PEOPLE_SENSIBLE_HEAT_GAIN_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_AREA_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_AIRFLOW_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.PEAK_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.PEAK_HEATING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_LEVEL_OFFSET_TOP: return StorageType.Double;
                case BuiltInParameter.ZONE_LEVEL_OFFSET: return StorageType.Double;
                case BuiltInParameter.SYSTEM_ZONE_LEVEL_ID: return StorageType.ElementId;
                case BuiltInParameter.ZONE_CALCULATED_HYDRONIC_COOLINGFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_HYDRONIC_HEATINGFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_SPACE_OUTDOOR_AIR_OPTION_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_GBXML_OPENING_TYPE: return StorageType.Integer;
                case BuiltInParameter.ROOM_CALCULATION_POINT: return StorageType.Integer;
                case BuiltInParameter.GRID_BANK_COL_WIDTH: return StorageType.Double;
                case BuiltInParameter.GRID_BANK_ROW_HEIGHT: return StorageType.Double;
                case BuiltInParameter.GRID_BANK_COL_NUM: return StorageType.Integer;
                case BuiltInParameter.GRID_BANK_ROW_NUM: return StorageType.Integer;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_BEND_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_HORIZONTAL_BEND_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_MULTISHAPE_TRANSITION_OVALROUND_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_MULTISHAPE_TRANSITION_RECTOVAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_TEEDOWN_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_TEEUP_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_EXPORT_CATEGORY_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_EXPORT_COMPLEXITY_PARAM: return StorageType.Integer;
                case BuiltInParameter.SPACE_ZONE_NAME: return StorageType.String;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_EXPORT_GBXML_DEFAULTS_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_HVACLOAD_PLENUM_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_SKYLIGHT_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_PARTITION_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_DOOR_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_WINDOW_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_WALL_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_ROOF_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_SKYLIGHT_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_PARTITION_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_FLOOR_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_DOOR_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_WINDOW_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_WALL_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_HVACLOAD_ROOF_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_COORD_AXIS_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_RBE_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_SHADING_SURFACES_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_TRANSPARENT_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_SURFACES_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_INNER_SHELL_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_OUTER_SHELL_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_BUILDING_SHELL_MODE: return StorageType.Integer;
                case BuiltInParameter.RBS_LINING_THICKNESS_FOR_DUCT: return StorageType.Double;
                case BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_PIPE: return StorageType.Double;
                case BuiltInParameter.RBS_INSULATION_THICKNESS_FOR_DUCT: return StorageType.Double;
                case BuiltInParameter.BUILDING_UNOCCUPIED_COOLING_SET_POINT_PARAM: return StorageType.Double;
                case BuiltInParameter.BUILDING_CLOSING_TIME_PARAM: return StorageType.String;
                case BuiltInParameter.BUILDING_OPENING_TIME_PARAM: return StorageType.String;
                case BuiltInParameter.SPACE_PEOPLE_ACTIVITY_LEVEL_PARAM: return StorageType.None;
                case BuiltInParameter.SPACE_ELEC_EQUIPMENT_RADIANT_PERCENTAGE_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_POWER_SCHEDULE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SPACE_LIGHTING_SCHEDULE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SPACE_OCCUPANCY_SCHEDULE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SPACE_INFILTRATION_PARAM: return StorageType.Double;
                case BuiltInParameter.SPACE_CARPETING_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_AIR_VOLUME_CALCULATION_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_COIL_BYPASS_PERCENTAGE_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_AREA_PER_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_AREA_PER_HEATING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_USE_AIR_CHANGES_PER_HOUR_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_USE_OUTSIDE_AIR_PER_AREA_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_USE_OUTSIDE_AIR_PER_PERSON_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_USE_DEHUMIDIFICATION_SETPOINT_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_USE_HUMIDIFICATION_SETPOINT_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_OUTDOOR_AIR_INFORMATION_PARAM: return StorageType.None;
                case BuiltInParameter.ZONE_COOLING_INFORMATION_PARAM: return StorageType.None;
                case BuiltInParameter.ZONE_HEATING_INFORMATION_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SLIVER_SPACE_TOLERANCE: return StorageType.Double;
                case BuiltInParameter.ZONE_AREA_GROSS: return StorageType.Double;
                case BuiltInParameter.ZONE_VOLUME_GROSS: return StorageType.Double;
                case BuiltInParameter.SPACE_IS_PLENUM: return StorageType.Integer;
                case BuiltInParameter.SPACE_IS_OCCUPIABLE: return StorageType.Integer;
                case BuiltInParameter.SPACE_ASSOC_ROOM_NUMBER: return StorageType.String;
                case BuiltInParameter.SPACE_ASSOC_ROOM_NAME: return StorageType.String;
                case BuiltInParameter.ZONE_PHASE: return StorageType.ElementId;
                case BuiltInParameter.ZONE_PHASE_ID: return StorageType.ElementId;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_PROJECT_PHASE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ROOM_CALCULATED_SUPPLY_AIRFLOW_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_CALCULATED_COOLING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_CALCULATED_HEATING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_SUPPLY_AIRFLOW_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_COOLING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_HEATING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_LEVEL_ID: return StorageType.ElementId;
                case BuiltInParameter.ZONE_OA_RATE_PER_ACH_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_OUTSIDE_AIR_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_OUTSIDE_AIR_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_DEHUMIDIFICATION_SET_POINT_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_HUMIDIFICATION_SET_POINT_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_COOLING_AIR_TEMPERATURE_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_HEATING_AIR_TEMPERATURE_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_COOLING_SET_POINT_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_HEATING_SET_POINT_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_SUPPLY_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_CALCULATED_HEATING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ZONE_SERVICE_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.ZONE_VOLUME: return StorageType.Double;
                case BuiltInParameter.ZONE_PERIMETER: return StorageType.Double;
                case BuiltInParameter.ZONE_AREA: return StorageType.Double;
                case BuiltInParameter.ZONE_NAME: return StorageType.String;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_VIEW_UPDATE_SURFACES: return StorageType.None;
                case BuiltInParameter.RBS_PROJECT_CONSTRUCTION_TYPE_SHADINGFACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CONSTRUCTION_TYPE_SHADINGFACTOR_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_GROUND_PLANE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_ORIGIN_Z: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_ORIGIN_Y: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_ORIGIN_X: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_AZIMUTH: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_TILT: return StorageType.Double;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_CADOBJECTID: return StorageType.String;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_ADJACENT_SPACE_ID2: return StorageType.String;
                case BuiltInParameter.RBS_ENERGY_ANALYSIS_SURFACE_ADJACENT_SPACE_ID1: return StorageType.String;
                case BuiltInParameter.ROOM_EDIT_ELECTRICAL_LOADS_PARAM: return StorageType.None;
                case BuiltInParameter.ROOM_EDIT_PEOPLE_LOADS_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_PROJECT_LOCATION_PARAM: return StorageType.String;
                case BuiltInParameter.ROOM_ACTUAL_LIGHTING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_ACTUAL_POWER_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_BASE_HEAT_LOAD_ON_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_LIGHTING_LOAD_UNITS_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_POWER_LOAD_UNITS_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_DESIGN_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_CALCULATED_COOLING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_HEATING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_CALCULATED_HEATING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_BASE_RETURN_AIRFLOW_ON_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_CONSTRUCTION_SET_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CONSTRUCTION_SET_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_SERVICE_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_GBXML_SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.RBS_GBXML_SURFACE_TYPE: return StorageType.Integer;
                case BuiltInParameter.RBS_GBXML_SURFACE_NAME: return StorageType.String;
                case BuiltInParameter.FAMILY_ELECTRICAL_MAINTAIN_ANNOTATION_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.RBS_FAMILY_CONTENT_ANNOTATION_DISPLAY: return StorageType.Integer;
                case BuiltInParameter.RBS_ELECTRICAL_DATA: return StorageType.String;
                case BuiltInParameter.RBS_CALCULATED_SIZE: return StorageType.String;
                case BuiltInParameter.ROOM_PEOPLE_SENSIBLE_HEAT_GAIN_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_IS_CUSTOM_FITTING: return StorageType.Integer;
                case BuiltInParameter.RBS_CONNECTOR_OFFSET_OBSOLETE: return StorageType.Double;
                case BuiltInParameter.RBS_LOOKUP_TABLE_NAME: return StorageType.String;
                case BuiltInParameter.ROOM_DESIGN_LIGHTING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_POWER_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_ACTUAL_LIGHTING_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_ACTUAL_POWER_LOAD_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_BASE_LIGHTING_LOAD_ON_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_BASE_POWER_LOAD_ON_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_DESIGN_OTHER_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_MECHANICAL_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_LIGHTING_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_POWER_LOAD_PER_AREA_PARAM: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_BALLAST_LOSS: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_TOTAL_LIGHT_LOSS: return StorageType.Double;
                case BuiltInParameter.RBS_ROOM_COEFFICIENT_UTILIZATION: return StorageType.Double;
                case BuiltInParameter.RBS_FAMILY_CONTENT_TAKEOFF_FIXED_LENGTH: return StorageType.Double;
                case BuiltInParameter.RBS_FAMILY_CONTENT_TAKEOFF_PROJLENGTH: return StorageType.Double;
                case BuiltInParameter.RBS_FAMILY_CONTENT_TAKEOFF_LENGTH: return StorageType.Double;
                case BuiltInParameter.RBS_FAMILY_CONTENT_OFFSET_HEIGHT: return StorageType.Double;
                case BuiltInParameter.RBS_FAMILY_CONTENT_OFFSET_WIDTH: return StorageType.Double;
                case BuiltInParameter.FAMILY_CONTENT_PART_TYPE: return StorageType.Integer;
                case BuiltInParameter.GBXML_EDIT_DATA_PARAM: return StorageType.None;
                case BuiltInParameter.ROOM_ACTUAL_EXHAUST_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_ACTUAL_RETURN_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_ACTUAL_SUPPLY_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_PEOPLE_LATENT_HEAT_GAIN_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_PEOPLE_TOTAL_HEAT_GAIN_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_CALCULATED_SUPPLY_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_EXHAUST_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_RETURN_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_DESIGN_SUPPLY_AIRFLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_AREA_PER_PERSON_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_NUMBER_OF_PEOPLE_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOM_OCCUPANCY_UNIT_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOM_SPACE_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ROOM_CONDITION_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.PROJECT_POSTAL_CODE: return StorageType.String;
                case BuiltInParameter.PROJECT_BUILDING_TYPE: return StorageType.ElementId;
                case BuiltInParameter.RBS_SIZE_LOCK: return StorageType.Integer;
                case BuiltInParameter.RBS_ADDITIONAL_FLOW: return StorageType.Double;
                case BuiltInParameter.RBS_CURVETYPE_MAX_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_PIPE_FITTING_LOSS_METHOD_SETTINGS: return StorageType.None;
                case BuiltInParameter.RBS_DUCT_FITTING_LOSS_METHOD_SETTINGS: return StorageType.None;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_CAP_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PIPE_FITTING_LOSS_METHOD_SERVER_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_DUCT_FITTING_LOSS_METHOD_SERVER_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_MECHJOINT_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PIPE_SIZE_FORMATTED_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_DUCT_SIZE_FORMATTED_PARAM: return StorageType.String;
                case BuiltInParameter.RBS_DUCT_STATIC_PRESSURE: return StorageType.Double;
                case BuiltInParameter.RBS_FLEX_PIPE_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PIPE_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_FLEX_DUCT_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DUCT_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_DUCT_FITTING_LOSS_TABLE_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_DUCT_FITTING_LOSS_METHOD_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_FLEXDUCT_ROUNDTYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_PREFERRED_BRANCH_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_TAKEOFF_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_UNION_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_HYDRAULIC_DIAMETER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_REYNOLDSNUMBER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_EQ_DIAMETER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CURVETYPE_MULTISHAPE_TRANSITION_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_SECTION: return StorageType.Integer;
                case BuiltInParameter.RBS_LOSS_COEFFICIENT: return StorageType.Double;
                case BuiltInParameter.RBS_MAX_FLOW: return StorageType.Double;
                case BuiltInParameter.RBS_MIN_FLOW: return StorageType.Double;
                case BuiltInParameter.RBS_VELOCITY_PRESSURE: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.RBS_CURVETYPE_MAX_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_LINING_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RBS_INSULATION_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RBS_FRICTION: return StorageType.Double;
                case BuiltInParameter.RBS_CURVETYPE_ROUGHNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_TRANSITION_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_CROSS_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_TEE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOW_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_PRESSURE_DROP: return StorageType.Double;
                case BuiltInParameter.RBS_VELOCITY: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_VERT_OFFSET_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_CURVE_HOR_OFFSET_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_FLOW_OBSOLETE: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_DIAMETER_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_CURVE_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_FLEX_PATTERN_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_END_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_START_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.RBS_END_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.RBS_START_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_ALL_NON_ZERO: return StorageType.String;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_ALL_NON_ZERO: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_MEMBER_FORCES: return StorageType.None;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MZ: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MY: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_MX: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FZ: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FY: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_END_FX: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MZ: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MY: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_MX: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FZ: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FY: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_MEMBER_FORCE_START_FX: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_TOTAL_PATH_LENGTH: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_DISPLAY_NODE_NUMBERS: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_MERGED_POINT_NUM: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_DISPLAY_NODES: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_DISPLAY_REFERENCE_CURVES: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_LAYOUT_FIXED_NUM_POINT: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_FLIP_DIRECTION: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_MEASUREMENT_TYPE: return StorageType.Integer;
                case BuiltInParameter.DIVIDEDPATH_MAX_DISTANCE: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_MIN_DISTANCE: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_END_INDENT: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_BEGINNING_INDENT: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_DISTANCE: return StorageType.Double;
                case BuiltInParameter.DIVIDEDPATH_LAYOUT: return StorageType.Integer;
                case BuiltInParameter.IFC_ORGANIZATION: return StorageType.String;
                case BuiltInParameter.IFC_APPLICATION_VERSION: return StorageType.String;
                case BuiltInParameter.IFC_APPLICATION_NAME: return StorageType.String;
                case BuiltInParameter.PROJECT_ORGANIZATION_NAME: return StorageType.String;
                case BuiltInParameter.PROJECT_ORGANIZATION_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.PROJECT_BUILDING_NAME: return StorageType.String;
                case BuiltInParameter.PROJECT_AUTHOR: return StorageType.String;
                case BuiltInParameter.IFC_SITE_GUID: return StorageType.String;
                case BuiltInParameter.IFC_BUILDING_GUID: return StorageType.String;
                case BuiltInParameter.IFC_PROJECT_GUID: return StorageType.String;
                case BuiltInParameter.IFC_TYPE_GUID: return StorageType.String;
                case BuiltInParameter.IFC_GUID: return StorageType.String;
                case BuiltInParameter.STRUCT_CONNECTION_TYPE_NAME: return StorageType.String;
                case BuiltInParameter.STRUCT_CONNECTION_CUTBACK: return StorageType.Integer;
                case BuiltInParameter.STRUCT_CONNECTION_COLUMN_BASE: return StorageType.ElementId;
                case BuiltInParameter.STRUCT_CONNECTION_COLUMN_TOP: return StorageType.ElementId;
                case BuiltInParameter.STRUCT_CONNECTION_BEAM_END: return StorageType.ElementId;
                case BuiltInParameter.STRUCT_CONNECTION_BEAM_START: return StorageType.ElementId;
                case BuiltInParameter.STRUCT_CONNECTION_APPLY_TO: return StorageType.Integer;
                case BuiltInParameter.REBAR_CONTAINER_BAR_TYPE: return StorageType.ElementId;
                case BuiltInParameter.REINFORCEMENT_VOLUME: return StorageType.Double;
                case BuiltInParameter.REIN_EST_BAR_VOLUME: return StorageType.Double;
                case BuiltInParameter.REIN_EST_BAR_LENGTH: return StorageType.Double;
                case BuiltInParameter.REIN_EST_NUMBER_OF_BARS: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_SHAPE_2: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_SHAPE_1: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_SPANLENGTH_ALT_OFFSET: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_SPANLENGTH_BARLENGTH_ALT: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_SPANLENGTH_BARLENGTH_PRIM: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_SPANLENGTH_TOP_ALT: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_END_SPANHOOK_ALT: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_END_SPANHOOK_PRIM: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_SUMMARY: return StorageType.String;
                case BuiltInParameter.PATH_REIN_SPANLENGTH_BOTTOM_ALT: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_SPANLENGTH_BOTTOM_PRIM: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_SPANHOOK_ALT: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_SPANHOOK_PRIM: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_ADDL_OFFSET: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_ALT_OFFSET: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_END_HOOK_ORIENT_2_WALL: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_END_HOOK_ORIENT_1_WALL: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_END_HOOK_ORIENT_2_SLAB: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_END_HOOK_ORIENT_1_SLAB: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_END_HOOK_TYPE_2: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_END_HOOK_TYPE_1: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_HOOK_ORIENT_2_WALL: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_HOOK_ORIENT_1_WALL: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_HOOK_ORIENT_2_SLAB: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_HOOK_ORIENT_1_SLAB: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_HOOK_TYPE_2: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_HOOK_TYPE_1: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_LENGTH_2: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_LENGTH_1: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_TYPE_2: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_TYPE_1: return StorageType.ElementId;
                case BuiltInParameter.PATH_REIN_ALTERNATING: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_NUMBER_OF_BARS: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_SPACING: return StorageType.Double;
                case BuiltInParameter.PATH_REIN_FACE_WALL: return StorageType.Integer;
                case BuiltInParameter.PATH_REIN_FACE_SLAB: return StorageType.Integer;
                case BuiltInParameter.REBAR_BAR_DEFORMATION_TYPE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_2_GENERIC: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_1_GENERIC: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_2_GENERIC: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_1_GENERIC: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_2_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_1_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_2_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_1_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_2_GENERIC: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_1_GENERIC: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_2_GENERIC: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_1_GENERIC: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_2_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_1_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_2_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_1_GENERIC: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_BACK_DIR_2: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_BACK_DIR_1: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_FRONT_DIR_2: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_FRONT_DIR_1: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BACK_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BACK_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_FRONT_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_FRONT_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_BACK_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_BACK_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_FRONT_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_FRONT_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_BACK_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_BACK_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_FRONT_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_FRONT_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BACK_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BACK_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_FRONT_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_FRONT_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_BACK_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_BACK_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_FRONT_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_FRONT_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_2: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_1: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_2: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_1: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_BOTTOM_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_NUMBER_OF_LINES_TOP_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_BOTTOM_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_BOTTOM_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_TOP_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_TYPE_TOP_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_BOTTOM_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_BOTTOM_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_TOP_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_HOOK_ORIENT_TOP_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_BOTTOM_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_2: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_BAR_TYPE_TOP_DIR_1: return StorageType.ElementId;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPANHOOK_TOP_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPANHOOK_BOTTOM_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPANHOOK_RIGHT_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPANHOOK_LEFT_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPANACTIVE_DIR_2: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_SPANACTIVE_DIR_1: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_ADDL_INTERIOR_OFFSET: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_ADDL_EXTERIOR_OFFSET: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_ADDL_BOTTOM_OFFSET: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_ADDL_TOP_OFFSET: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_TOP_MINOR_MATCHES_BOTTOM_MINOR: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_TOP_MAJOR_MATCHES_BOTTOM_MAJOR: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_BOTTOM_MAJOR_MATCHES_BOTTOM_MINOR: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_TOP_MAJOR_MATCHES_TOP_MINOR: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_2_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_2_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_1_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_DIR_1_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_2_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_2_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_1_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_BOTTOM_DIR_1_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_2_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_2_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_1_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_TOP_DIR_1_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_COVER_BOTTOM: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_COVER_TOP: return StorageType.Double;
                case BuiltInParameter.REBAR_SYSTEM_OVERRIDE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_NO_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYER_SUMMARY_WITH_SPACING: return StorageType.String;
                case BuiltInParameter.REBAR_SYSTEM_LAYOUT_RULE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SYSTEM_COVER_SIDE: return StorageType.Double;
                case BuiltInParameter.FABRIC_WIRE_OFFSET: return StorageType.Double;
                case BuiltInParameter.FABRIC_WIRE_DISTANCE: return StorageType.Double;
                case BuiltInParameter.FABRIC_WIRE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_WIRE_TYPE: return StorageType.ElementId;
                case BuiltInParameter.BENT_FABRIC_PARAM_LONGITUDINAL_CUT_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SHARED_FAMILY_KEY: return StorageType.String;
                case BuiltInParameter.FABRIC_PARAM_CUT_BY_HOST: return StorageType.Integer;
                case BuiltInParameter.BENT_FABRIC_PARAM_STRAIGHT_WIRES_LOCATION: return StorageType.Integer;
                case BuiltInParameter.CONSTRAINT_FIXED_OFFSET: return StorageType.Double;
                case BuiltInParameter.BENT_FABRIC_PARAM_BEND_DIRECTION: return StorageType.Integer;
                case BuiltInParameter.FABRIC_PARAM_SPAN_TAG_COMPONENT_REFERENCE: return StorageType.Integer;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_D_RIGHT: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_D_LEFT: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_D_BOTTOM: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_D_TOP: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_RIGHT: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_LEFT: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_BOTTOM: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_SPAN_SYM_TOP: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_TAG_VIEW: return StorageType.ElementId;
                case BuiltInParameter.FABRIC_PARAM_CUT_SHEET_MASS: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_TOTAL_SHEET_MASS: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_CUT_OVERALL_WIDTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_CUT_OVERALL_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_COVER_OFFSET: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_MINOR_LAPSPLICE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_MAJOR_LAPSPLICE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_PARAM_LOCATION_GENERIC: return StorageType.Integer;
                case BuiltInParameter.FABRIC_PARAM_LAPSPLICE_POSITION: return StorageType.Integer;
                case BuiltInParameter.FABRIC_PARAM_LOCATION_WALL: return StorageType.Integer;
                case BuiltInParameter.FABRIC_PARAM_LOCATION_SLAB: return StorageType.Integer;
                case BuiltInParameter.FABRIC_PARAM_SHEET_TYPE: return StorageType.ElementId;
                case BuiltInParameter.FABRIC_BEND_DIAMETER: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MASSUNIT: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MINOR_REINFORCEMENT_AREA: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_REINFORCEMENT_AREA: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MASS: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MINOR_SPACING: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MINOR_NUMBER_OF_WIRES: return StorageType.Integer;
                case BuiltInParameter.FABRIC_SHEET_MINOR_LAYOUT_PATTERN: return StorageType.Integer;
                case BuiltInParameter.FABRIC_SHEET_MINOR_END_OVERHANG: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MINOR_START_OVERHANG: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_WIDTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_OVERALL_WIDTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_SPACING: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_NUMBER_OF_WIRES: return StorageType.Integer;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_LAYOUT_PATTERN: return StorageType.Integer;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_END_OVERHANG: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_START_OVERHANG: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_OVERALL_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_DEFAULT_MINOR_LAPSPLICE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_DEFAULT_MAJOR_LAPSPLICE_LENGTH: return StorageType.Double;
                case BuiltInParameter.FABRIC_SHEET_MINOR_DIRECTION_WIRE_TYPE: return StorageType.ElementId;
                case BuiltInParameter.FABRIC_SHEET_MAJOR_DIRECTION_WIRE_TYPE: return StorageType.ElementId;
                case BuiltInParameter.FABRIC_SHEET_PHYSICAL_MATERIAL_ASSET: return StorageType.String;
                case BuiltInParameter.FABRIC_WIRE_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_QUANITY_BY_DISTRIB: return StorageType.Integer;
                case BuiltInParameter.REBAR_MIN_LENGTH: return StorageType.Double;
                case BuiltInParameter.REBAR_MAX_LENGTH: return StorageType.Double;
                case BuiltInParameter.REBAR_MAXIM_SUFFIX: return StorageType.String;
                case BuiltInParameter.REBAR_MINIM_SUFFIX: return StorageType.String;
                case BuiltInParameter.REBAR_NUMBER_SUFFIX: return StorageType.String;
                case BuiltInParameter.REBAR_DISTRIBUTION_TYPE: return StorageType.Integer;
                case BuiltInParameter.DPART_CAN_HOST_REBAR: return StorageType.Integer;
                case BuiltInParameter.REBAR_HOST_CATEGORY: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_PARAM_END_HOOK_TAN_LEN: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE_PARAM_START_HOOK_TAN_LEN: return StorageType.Double;
                case BuiltInParameter.REBAR_INTERNAL_MULTIPLANAR_END_CONNECTOR: return StorageType.Integer;
                case BuiltInParameter.REBAR_INTERNAL_MULTIPLANAR_START_CONNECTOR: return StorageType.Integer;
                case BuiltInParameter.REBAR_INTERNAL_MULTIPLANAR_DUPLICATE: return StorageType.Integer;
                case BuiltInParameter.REBAR_INTERNAL_MULTIPLANAR: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_OUT_OF_PLANE_BEND_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_INSTANCE_STIRRUP_TIE_ATTACHMENT: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_STIRRUP_TIE_ATTACHMENT: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_SPIRAL_BASE_FINISHING_TURNS: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_SPIRAL_TOP_FINISHING_TURNS: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_SPIRAL_HEIGHT: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE_SPIRAL_PITCH: return StorageType.Double;
                case BuiltInParameter.REBAR_STANDARD_HOOK_BEND_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_INCLUDE_LAST_BAR: return StorageType.Integer;
                case BuiltInParameter.REBAR_INCLUDE_FIRST_BAR: return StorageType.Integer;
                case BuiltInParameter.REBAR_INSTANCE_BEND_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_INSTANCE_BAR_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE_END_HOOK_OFFSET: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE_END_HOOK_LENGTH: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE_START_HOOK_OFFSET: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE_START_HOOK_LENGTH: return StorageType.Double;
                case BuiltInParameter.REBAR_ELEM_SCHEDULE_MARK: return StorageType.String;
                case BuiltInParameter.FABRIC_PARAM_ROUNDING: return StorageType.None;
                case BuiltInParameter.REBAR_ELEMENT_ROUNDING: return StorageType.None;
                case BuiltInParameter.REBAR_ELEM_HOOK_STYLE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_HOOK_END_TYPE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_HOOK_START_TYPE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_HOOK_STYLE: return StorageType.Integer;
                case BuiltInParameter.REBAR_SHAPE_ALLOWED_BAR_TYPES: return StorageType.None;
                case BuiltInParameter.REBAR_BAR_MAXIMUM_BEND_RADIUS: return StorageType.Double;
                case BuiltInParameter.REBAR_BAR_STIRRUP_BEND_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_BAR_HOOK_LENGTHS: return StorageType.None;
                case BuiltInParameter.REBAR_HOOK_STYLE: return StorageType.Integer;
                case BuiltInParameter.REBAR_ELEM_LENGTH: return StorageType.Double;
                case BuiltInParameter.REBAR_SHAPE: return StorageType.ElementId;
                case BuiltInParameter.REBAR_ELEMENT_VISIBILITY: return StorageType.None;
                case BuiltInParameter.REBAR_ELEM_BAR_SPACING: return StorageType.Double;
                case BuiltInParameter.REBAR_ELEM_QUANTITY_OF_BARS: return StorageType.Integer;
                case BuiltInParameter.REBAR_ELEM_LAYOUT_RULE: return StorageType.Integer;
                case BuiltInParameter.REBAR_STANDARD_BEND_DIAMETER: return StorageType.Double;
                case BuiltInParameter.REBAR_ELEM_HOOK_END_ORIENT: return StorageType.Integer;
                case BuiltInParameter.REBAR_ELEM_HOOK_END_TYPE: return StorageType.ElementId;
                case BuiltInParameter.REBAR_ELEM_HOOK_START_ORIENT: return StorageType.Integer;
                case BuiltInParameter.REBAR_ELEM_HOOK_START_TYPE: return StorageType.ElementId;
                case BuiltInParameter.REBAR_ELEM_TOTAL_LENGTH: return StorageType.Double;
                case BuiltInParameter.REBAR_HOOK_LINE_LEN_FACTOR: return StorageType.Double;
                case BuiltInParameter.REBAR_HOOK_ANGLE: return StorageType.Double;
                case BuiltInParameter.REBAR_BAR_STYLE: return StorageType.ElementId;
                case BuiltInParameter.REBAR_BAR_DIAMETER: return StorageType.Double;
                case BuiltInParameter.WALL_ALIGN_KEY_REF_PARAM: return StorageType.Integer;
                case BuiltInParameter.CWP_COPY_ROOF_INSERTS: return StorageType.Integer;
                case BuiltInParameter.CWP_COPY_FLOOR_INSERTS: return StorageType.Integer;
                case BuiltInParameter.CWP_COPY_WALL_INSERTS: return StorageType.Integer;
                case BuiltInParameter.CWP_LINKED_ROOM_PARAMS: return StorageType.None;
                case BuiltInParameter.CWP_LINKED_ROOM_PHASES: return StorageType.None;
                case BuiltInParameter.CWP_REUSE_GRIDS_SAME_NAME: return StorageType.Integer;
                case BuiltInParameter.CWP_REUSE_LEVELS_SAME_NAME: return StorageType.Integer;
                case BuiltInParameter.CWP_SPLIT_COLUMNS_AT_LEVELS: return StorageType.Integer;
                case BuiltInParameter.CWP_REUSE_EXISTING_GRIDS: return StorageType.Integer;
                case BuiltInParameter.CWP_REUSE_EXISTING_LEVELS: return StorageType.Integer;
                case BuiltInParameter.CWP_LEVEL_OFFSET: return StorageType.Double;
                case BuiltInParameter.CWP_ADD_LEVEL_SUFFIX: return StorageType.String;
                case BuiltInParameter.CWP_ADD_LEVEL_PREFIX: return StorageType.String;
                case BuiltInParameter.CWP_ADD_GRID_SUFFIX: return StorageType.String;
                case BuiltInParameter.CWP_ADD_GRID_PREFIX: return StorageType.String;
                case BuiltInParameter.LOAD_USAGE_NAME: return StorageType.String;
                case BuiltInParameter.LOAD_COMBINATION_FACTOR: return StorageType.Double;
                case BuiltInParameter.LOAD_COMBINATION_NAME: return StorageType.String;
                case BuiltInParameter.LOAD_NATURE_NAME: return StorageType.String;
                case BuiltInParameter.LOAD_CASE_SUBCATEGORY: return StorageType.ElementId;
                case BuiltInParameter.LOAD_CASE_NATURE: return StorageType.ElementId;
                case BuiltInParameter.LOAD_CASE_NUMBER: return StorageType.Integer;
                case BuiltInParameter.LOAD_CASE_NAME: return StorageType.String;
                case BuiltInParameter.LOAD_ATTR_AREA_FORCE_SCALE_FACTOR: return StorageType.Double;
                case BuiltInParameter.LOAD_ATTR_LINEAR_FORCE_SCALE_FACTOR: return StorageType.Double;
                case BuiltInParameter.LOAD_ARROW_SEPARATION: return StorageType.Double;
                case BuiltInParameter.LOAD_ATTR_MOMENT_SCALE_FACTOR: return StorageType.Double;
                case BuiltInParameter.LOAD_ATTR_MOMENT_ARROW_LINE: return StorageType.ElementId;
                case BuiltInParameter.LOAD_ATTR_MOMENT_ARROW_ARC: return StorageType.ElementId;
                case BuiltInParameter.LOAD_ATTR_FORCE_SCALE_FACTOR: return StorageType.Double;
                case BuiltInParameter.LOAD_ATTR_FORCE_ARROW_TYPE: return StorageType.ElementId;
                case BuiltInParameter.LOAD_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.LOAD_COMMENTS: return StorageType.String;
                case BuiltInParameter.LOAD_CASE_NATURE_TEXT: return StorageType.ElementId;
                case BuiltInParameter.LOAD_ALL_NON_0_LOADS: return StorageType.String;
                case BuiltInParameter.LOAD_AREA_IS_PROJECTED: return StorageType.Integer;
                case BuiltInParameter.LOAD_AREA_AREA: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FZ3: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FY3: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FX3: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FZ2: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FY2: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FX2: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FZ1: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FY1: return StorageType.Double;
                case BuiltInParameter.LOAD_AREA_FORCE_FX1: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_LENGTH: return StorageType.Double;
                case BuiltInParameter.LOAD_IS_PROJECTED: return StorageType.Integer;
                case BuiltInParameter.LOAD_MOMENT_MZ2: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MY2: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MX2: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MZ1: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MY1: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MX1: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_FORCE_FZ2: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_FORCE_FY2: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_FORCE_FX2: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_FORCE_FZ1: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_FORCE_FY1: return StorageType.Double;
                case BuiltInParameter.LOAD_LINEAR_FORCE_FX1: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MZ: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MY: return StorageType.Double;
                case BuiltInParameter.LOAD_MOMENT_MX: return StorageType.Double;
                case BuiltInParameter.LOAD_FORCE_FZ: return StorageType.Double;
                case BuiltInParameter.LOAD_FORCE_FY: return StorageType.Double;
                case BuiltInParameter.LOAD_FORCE_FX: return StorageType.Double;
                case BuiltInParameter.LOAD_IS_HOSTED: return StorageType.Integer;
                case BuiltInParameter.LOAD_IS_REACTION: return StorageType.Integer;
                case BuiltInParameter.LOAD_IS_CREATED_BY_API: return StorageType.Integer;
                case BuiltInParameter.LOAD_IS_UNIFORM: return StorageType.Integer;
                case BuiltInParameter.LOAD_USE_LOCAL_COORDINATE_SYSTEM: return StorageType.Integer;
                case BuiltInParameter.LOAD_CASE_ID: return StorageType.ElementId;
                case BuiltInParameter.SPAN_DIR_SYM_PARAM_RIGHT: return StorageType.Double;
                case BuiltInParameter.SPAN_DIR_SYM_PARAM_LEFT: return StorageType.Double;
                case BuiltInParameter.SPAN_DIR_SYM_PARAM_BOTTOM: return StorageType.Double;
                case BuiltInParameter.SPAN_DIR_SYM_PARAM_TOP: return StorageType.Double;
                case BuiltInParameter.SPAN_DIR_INST_PARAM_ANGLE: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_GEOMETRY_IS_VALID: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ASSET_PARAM: return StorageType.String;
                case BuiltInParameter.ANALYTICAL_MODEL_CODE_CHECKING: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_NODES_MARK: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_FOUNDATIONS_MARK: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_SURFACE_ELEMENTS_MARK: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_STICK_ELEMENTS_MARK: return StorageType.Integer;
                case BuiltInParameter.FAMILY_ENABLE_CUTTING_IN_VIEWS: return StorageType.Integer;
                case BuiltInParameter.FAMILY_CAN_HOST_REBAR: return StorageType.Integer;
                case BuiltInParameter.CLEAR_COVER: return StorageType.ElementId;
                case BuiltInParameter.CLEAR_COVER_BOTTOM: return StorageType.ElementId;
                case BuiltInParameter.CLEAR_COVER_TOP: return StorageType.ElementId;
                case BuiltInParameter.CLEAR_COVER_OTHER: return StorageType.ElementId;
                case BuiltInParameter.CLEAR_COVER_INTERIOR: return StorageType.ElementId;
                case BuiltInParameter.CLEAR_COVER_EXTERIOR: return StorageType.ElementId;
                case BuiltInParameter.COVER_TYPE_LENGTH: return StorageType.Double;
                case BuiltInParameter.COVER_TYPE_NAME: return StorageType.String;
                case BuiltInParameter.JOIST_SYSTEM_CLEAR_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.JOIST_SYSTEM_FIXED_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.JOIST_SYSTEM_MAXIMUM_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.CURVE_EDGE_OFFSET: return StorageType.Double;
                case BuiltInParameter.BEAM_SYSTEM_3D_PARAM: return StorageType.Integer;
                case BuiltInParameter.JOIST_SYSTEM_NEW_BEAM_TYPE_NO_FAM_NAME_PARAM: return StorageType.ElementId;
                case BuiltInParameter.BEAM_SYSTEM_TAG_INST_PARAM_ANGLE: return StorageType.Double;
                case BuiltInParameter.BEAM_SYSTEM_TAG_PARAM_RIGHT: return StorageType.Double;
                case BuiltInParameter.BEAM_SYSTEM_TAG_PARAM_LEFT: return StorageType.Double;
                case BuiltInParameter.JOIST_SYSTEM_NUM_BEAMS_SAME_TYPE: return StorageType.Integer;
                case BuiltInParameter.BEAM_H_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.BEAM_V_JUSTIFICATION: return StorageType.Integer;
                case BuiltInParameter.CURVE_SUPPORT_OFFSET: return StorageType.Double;
                case BuiltInParameter.JOIST_SYSTEM_NEW_BEAM_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.JOIST_SYSTEM_LAYOUT_RULE_PARAM: return StorageType.Integer;
                case BuiltInParameter.JOIST_SYSTEM_JUSTIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.JOIST_SYSTEM_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.JOIST_SYSTEM_NUMBER_OF_LINES_PARAM: return StorageType.Integer;
                case BuiltInParameter.RBS_DUCT_FLOW_PARAM: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_BELT_RATIO_V: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_BELT_RATIO_U: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST_V: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST_U: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_ADJUST_BORDER_V: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_ADJUST_BORDER_U: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_BELT_V: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_BELT_U: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ORIGIN_V: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ORIGIN_U: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ANGLE_V: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ANGLE_U: return StorageType.Double;
                case BuiltInParameter.SPACING_NUM_DIVISIONS_V: return StorageType.Integer;
                case BuiltInParameter.SPACING_NUM_DIVISIONS_U: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION_V: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION_U: return StorageType.Integer;
                case BuiltInParameter.SPACING_LENGTH_V: return StorageType.Double;
                case BuiltInParameter.SPACING_LENGTH_U: return StorageType.Double;
                case BuiltInParameter.SPACING_LAYOUT_V: return StorageType.Integer;
                case BuiltInParameter.SPACING_LAYOUT_U: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_BELT_RATIO_2: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_BELT_RATIO_1: return StorageType.Double;
                case BuiltInParameter.CURTAIN_VERSION_PARAM: return StorageType.String;
                case BuiltInParameter.PADDING_LENGTH: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION: return StorageType.None;
                case BuiltInParameter.SPACING_NUM_DIVISIONS: return StorageType.Integer;
                case BuiltInParameter.SPACING_LENGTH: return StorageType.Double;
                case BuiltInParameter.SPACING_LAYOUT: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST_2: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST_1: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_ADJUST_BORDER_2: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_ADJUST_BORDER_1: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_BELT_2: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_BELT_1: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ORIGIN_2: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ORIGIN_1: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ANGLE_2: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ANGLE_1: return StorageType.Double;
                case BuiltInParameter.SPACING_NUM_DIVISIONS_2: return StorageType.Integer;
                case BuiltInParameter.SPACING_NUM_DIVISIONS_1: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION_2: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION_1: return StorageType.Integer;
                case BuiltInParameter.SPACING_LENGTH_2: return StorageType.Double;
                case BuiltInParameter.SPACING_LENGTH_1: return StorageType.Double;
                case BuiltInParameter.SPACING_LAYOUT_2: return StorageType.Integer;
                case BuiltInParameter.SPACING_LAYOUT_1: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST_HORIZ: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_USE_CURVE_DIST_VERT: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_ADJUST_BORDER_HORIZ: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_ADJUST_BORDER_VERT: return StorageType.Integer;
                case BuiltInParameter.CURTAINGRID_BELT_HORIZ: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_BELT_VERT: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ORIGIN_HORIZ: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ORIGIN_VERT: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ANGLE_HORIZ: return StorageType.Double;
                case BuiltInParameter.CURTAINGRID_ANGLE_VERT: return StorageType.Double;
                case BuiltInParameter.GRIDLINE_SPEC_STATUS: return StorageType.Integer;
                case BuiltInParameter.SPACING_NUM_DIVISIONS_HORIZ: return StorageType.Integer;
                case BuiltInParameter.SPACING_NUM_DIVISIONS_VERT: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION_HORIZ: return StorageType.Integer;
                case BuiltInParameter.SPACING_JUSTIFICATION_VERT: return StorageType.Integer;
                case BuiltInParameter.SPACING_LENGTH_HORIZ: return StorageType.Double;
                case BuiltInParameter.SPACING_LENGTH_VERT: return StorageType.Double;
                case BuiltInParameter.SPACING_LAYOUT_HORIZ: return StorageType.Integer;
                case BuiltInParameter.SPACING_LAYOUT_VERT: return StorageType.Integer;
                case BuiltInParameter.DESIGN_OPTION_ID: return StorageType.ElementId;
                case BuiltInParameter.DESIGN_OPTION_PARAM: return StorageType.String;
                case BuiltInParameter.PLAN_REGION_VIEW_RANGE: return StorageType.None;
                case BuiltInParameter.GUIDE_GRID_NAME_PARAM: return StorageType.String;
                case BuiltInParameter.GUIDE_GRID_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.SKETCH_GRID_SPACING_PARAM: return StorageType.Double;
                case BuiltInParameter.JOIN_STRENGTH_ORDER: return StorageType.Double;
                case BuiltInParameter.FAMILY_HOSTING_BEHAVIOR: return StorageType.Integer;
                case BuiltInParameter.FAMILY_IS_ELEVATION_MARK_BODY: return StorageType.Integer;
                case BuiltInParameter.FAMILY_USE_PRECUT_SHAPE: return StorageType.Integer;
                case BuiltInParameter.WALL_SWEEP_DEFAULT_SETBACK_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_SWEEP_CUTS_WALL_PARAM: return StorageType.Integer;
                case BuiltInParameter.WALL_SWEEP_CUT_BY_INSERTS_PARAM: return StorageType.Integer;
                case BuiltInParameter.SLAB_EDGE_PROFILE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.GUTTER_PROFILE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.REVEAL_PROFILE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_SHARED: return StorageType.Integer;
                case BuiltInParameter.FAMILY_WORK_PLANE_BASED: return StorageType.Integer;
                case BuiltInParameter.FAMILY_AUTOJOIN: return StorageType.Integer;
                case BuiltInParameter.FAMILY_IS_PARAMETRIC: return StorageType.Integer;
                case BuiltInParameter.FAMILY_KEEP_TEXT_READABLE: return StorageType.Integer;
                case BuiltInParameter.WALL_BOTTOM_EXTENSION_DIST_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_TOP_EXTENSION_DIST_PARAM: return StorageType.Double;
                case BuiltInParameter.SWEEP_BASE_VERT_OFFSET: return StorageType.Double;
                case BuiltInParameter.SWEEP_BASE_OFFSET: return StorageType.Double;
                case BuiltInParameter.SLAB_EDGE_MATERIAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.GUTTER_MATERIAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FASCIA_MATERIAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SWEEP_BASE_FLOOR_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.SWEEP_BASE_ROOF_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.FASCIA_PROFILE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.DECAL_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.DECAL_HEIGHT: return StorageType.Double;
                case BuiltInParameter.DECAL_WIDTH: return StorageType.Double;
                case BuiltInParameter.DECAL_LOCK_PROPORTIONS: return StorageType.Integer;
                case BuiltInParameter.DECAL_ATTRIBUTES: return StorageType.None;
                case BuiltInParameter.FAMILY_ALLOW_CUT_WITH_VOIDS: return StorageType.Integer;
                case BuiltInParameter.FAMILY_KEY_EXT_PARAM: return StorageType.ElementId;
                case BuiltInParameter.WALL_SWEEP_WALL_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_ALWAYS_VERTICAL: return StorageType.Integer;
                case BuiltInParameter.FAMILY_ROTATE_WITH_COMPONENT: return StorageType.Integer;
                case BuiltInParameter.HOST_VOLUME_COMPUTED: return StorageType.Double;
                case BuiltInParameter.HOST_AREA_COMPUTED: return StorageType.Double;
                case BuiltInParameter.WALL_SWEEP_WALL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_SWEEP_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_SWEEP_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.WALL_SWEEP_PROFILE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.AREA_SCHEME_NAME: return StorageType.String;
                case BuiltInParameter.AREA_SCHEME_ID: return StorageType.ElementId;
                case BuiltInParameter.AREA_TYPE_TEXT: return StorageType.String;
                case BuiltInParameter.AREA_TYPE: return StorageType.ElementId;
                case BuiltInParameter.CONTOUR_LABELS_RELATIVE_BASE: return StorageType.ElementId;
                case BuiltInParameter.CONTOUR_LABELS_ELEV_BASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.PROPERTY_SEGMENT_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.PROPERTY_SEGMENT_L_R: return StorageType.String;
                case BuiltInParameter.PROPERTY_SEGMENT_RADIUS: return StorageType.Double;
                case BuiltInParameter.PROPERTY_SEGMENT_E_W: return StorageType.String;
                case BuiltInParameter.PROPERTY_SEGMENT_BEARING: return StorageType.Double;
                case BuiltInParameter.PROPERTY_SEGMENT_N_S: return StorageType.String;
                case BuiltInParameter.PROPERTY_SEGMENT_DISTANCE: return StorageType.Double;
                case BuiltInParameter.PROPERTY_LENGTH_UNITS: return StorageType.None;
                case BuiltInParameter.PROPERTY_AREA_UNITS: return StorageType.None;
                case BuiltInParameter.VOLUME_NET: return StorageType.Double;
                case BuiltInParameter.PROJECTED_SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.CONTOUR_LABELS_LINEAR_UNITS: return StorageType.None;
                case BuiltInParameter.CONTOUR_LABELS_PRIMARY_ONLY: return StorageType.Integer;
                case BuiltInParameter.PROPERTY_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.PROPERTY_AREA_OPEN: return StorageType.String;
                case BuiltInParameter.VOLUME_FILL: return StorageType.Double;
                case BuiltInParameter.VOLUME_CUT: return StorageType.Double;
                case BuiltInParameter.SURFACE_PERIMETER: return StorageType.Double;
                case BuiltInParameter.SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.PROPERTY_AREA: return StorageType.Double;
                case BuiltInParameter.BUILDINGPAD_HEIGHTABOVELEVEL_PARAM: return StorageType.Double;
                case BuiltInParameter.BUILDINGPAD_THICKNESS: return StorageType.Double;
                case BuiltInParameter.TOPOGRAPHY_LINK_PATH: return StorageType.String;
                case BuiltInParameter.TOPOGRAPHY_LINK_NAME: return StorageType.String;
                case BuiltInParameter.BOUNDARY_RADIUS: return StorageType.Double;
                case BuiltInParameter.CONTOUR_SUBCATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.BOUNDARY_BEARING: return StorageType.Double;
                case BuiltInParameter.BOUNDARY_DISTANCE: return StorageType.Double;
                case BuiltInParameter.CONTOUR_ELEVATION_STEP: return StorageType.Double;
                case BuiltInParameter.CONTOUR_ELEVATION: return StorageType.Double;
                case BuiltInParameter.POINT_ELEVATION: return StorageType.Double;
                case BuiltInParameter.VOLUME_OF_INTEREST_NAME: return StorageType.String;
                case BuiltInParameter.VOLUME_OF_INTEREST_VIEWS_VISIBLE: return StorageType.None;
                case BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP: return StorageType.ElementId;
                case BuiltInParameter.DATUM_VOLUME_OF_INTEREST: return StorageType.ElementId;
                case BuiltInParameter.ORIENT_BY_VIEW: return StorageType.Integer;
                case BuiltInParameter.ROOM_PHASE: return StorageType.ElementId;
                case BuiltInParameter.ROOM_PHASE_ID: return StorageType.ElementId;
                case BuiltInParameter.PHASE_SEQUENCE_NUMBER: return StorageType.Integer;
                case BuiltInParameter.PHASE_NAME: return StorageType.String;
                case BuiltInParameter.VIEW_FAMILY: return StorageType.String;
                case BuiltInParameter.VIEW_TYPE: return StorageType.String;
                case BuiltInParameter.VIEW_PHASE_FILTER: return StorageType.ElementId;
                case BuiltInParameter.VIEW_PHASE: return StorageType.ElementId;
                case BuiltInParameter.PHASE_DEMOLISHED: return StorageType.ElementId;
                case BuiltInParameter.PHASE_CREATED: return StorageType.ElementId;
                case BuiltInParameter.MASS_DATA_SLAB: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_HVAC_SYSTEM: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_OUTDOOR_AIR_INFORMATION_PARAM: return StorageType.None;
                case BuiltInParameter.ENERGY_ANALYSIS_MASSZONE_USEENERGYDATASETTINGS: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_MASSZONE_DIVIDEPERIMETER: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_MASSZONE_COREOFFSET: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_SHADE_DEPTH: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_CONCEPTUAL_CONSTRUCTION: return StorageType.None;
                case BuiltInParameter.ENERGY_ANALYSIS_SKYLIGHT_WIDTH: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_PERCENTAGE_SKYLIGHTS: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_GLAZING_IS_SHADED: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_SILL_HEIGHT: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_PERCENTAGE_GLAZING: return StorageType.Double;
                case BuiltInParameter.ENERGY_ANALYSIS_MASS_ZONING: return StorageType.None;
                case BuiltInParameter.ENERGY_ANALYSIS_BUILDING_OPERATING_SCHEDULE: return StorageType.Integer;
                case BuiltInParameter.ENERGY_ANALYSIS_CREATE_ANALYTICAL_MODEL: return StorageType.Integer;
                case BuiltInParameter.MASS_DATA_SURFACE_DATA_SOURCE: return StorageType.Integer;
                case BuiltInParameter.MASS_DATA_SKYLIGHT_WIDTH: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_PERCENTAGE_SKYLIGHTS: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_SILL_HEIGHT: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_SHADE_DEPTH: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_GLAZING_IS_SHADED: return StorageType.Integer;
                case BuiltInParameter.MASS_DATA_PERCENTAGE_GLAZING: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_UNDERGROUND: return StorageType.Integer;
                case BuiltInParameter.MASS_DATA_MASS_OPENING_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_MASS_SKYLIGHT_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_MASS_WINDOW_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_MASS_ROOF_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_MASS_INTERIOR_WALL_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_MASS_EXTERIOR_WALL_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_DATA_SUBCATEGORY: return StorageType.ElementId;
                case BuiltInParameter.MASS_DATA_CONCEPTUAL_CONSTRUCTION: return StorageType.ElementId;
                case BuiltInParameter.MASS_ZONE_CONDITION_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.MASS_ZONE_SPACE_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.MASS_ZONE_FLOOR_AREA: return StorageType.Double;
                case BuiltInParameter.CONCEPTUAL_CONSTRUCTION_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.MASS_SURFACEDATA_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.MASS_ZONE_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.MASS_ZONE_VOLUME: return StorageType.Double;
                case BuiltInParameter.LEVEL_DATA_MASS_TYPE_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_MASS_INSTANCE_COMMENTS: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_MASS_TYPE_COMMENTS: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_MASS_FAMILY_AND_TYPE_PARAM: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_MASS_FAMILY_PARAM: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_SPACE_USAGE: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_OWNING_LEVEL: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_MASS_TYPE_PARAM: return StorageType.String;
                case BuiltInParameter.LEVEL_DATA_VOLUME: return StorageType.Double;
                case BuiltInParameter.LEVEL_DATA_SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.LEVEL_DATA_FLOOR_AREA: return StorageType.Double;
                case BuiltInParameter.LEVEL_DATA_FLOOR_PERIMETER: return StorageType.Double;
                case BuiltInParameter.MASS_GROSS_VOLUME: return StorageType.Double;
                case BuiltInParameter.MASS_GROSS_SURFACE_AREA: return StorageType.Double;
                case BuiltInParameter.MASS_FLOOR_AREA_LEVELS: return StorageType.None;
                case BuiltInParameter.MASS_GROSS_AREA: return StorageType.Double;
                case BuiltInParameter.MASSING_INTEGRATION_LEVEL: return StorageType.Integer;
                case BuiltInParameter.PROJECT_REVISION_REVISION_ISSUED: return StorageType.Integer;
                case BuiltInParameter.PROJECT_REVISION_ENUMERATION: return StorageType.Integer;
                case BuiltInParameter.PROJECT_REVISION_REVISION_ISSUED_BY: return StorageType.String;
                case BuiltInParameter.PROJECT_REVISION_REVISION_ISSUED_TO: return StorageType.String;
                case BuiltInParameter.PROJECT_REVISION_REVISION_DATE: return StorageType.String;
                case BuiltInParameter.PROJECT_REVISION_REVISION_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.PROJECT_REVISION_REVISION_NUM: return StorageType.String;
                case BuiltInParameter.PROJECT_REVISION_SEQUENCE_NUM: return StorageType.Integer;
                case BuiltInParameter.REVISION_CLOUD_REVISION_ISSUED_BY: return StorageType.String;
                case BuiltInParameter.REVISION_CLOUD_REVISION_ISSUED_TO: return StorageType.String;
                case BuiltInParameter.REVISION_CLOUD_REVISION_DATE: return StorageType.String;
                case BuiltInParameter.REVISION_CLOUD_REVISION_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.REVISION_CLOUD_REVISION_NUM: return StorageType.String;
                case BuiltInParameter.REVISION_CLOUD_REVISION: return StorageType.ElementId;
                case BuiltInParameter.REPEATING_DETAIL_ROTATION: return StorageType.Integer;
                case BuiltInParameter.REPEATING_DETAIL_INSIDE: return StorageType.Integer;
                case BuiltInParameter.REPEATING_DETAIL_ELEMENT: return StorageType.ElementId;
                case BuiltInParameter.REPEATING_DETAIL_LAYOUT: return StorageType.Integer;
                case BuiltInParameter.REPEATING_DETAIL_SPACING: return StorageType.Double;
                case BuiltInParameter.REPEATING_DETAIL_NUMBER: return StorageType.Integer;
                case BuiltInParameter.INSULATION_SCALE: return StorageType.Double;
                case BuiltInParameter.INSULATION_WIDTH: return StorageType.Double;
                case BuiltInParameter.VIEW_PARTS_VISIBILITY: return StorageType.Integer;
                case BuiltInParameter.VIEW_DETAIL_LEVEL: return StorageType.Integer;
                case BuiltInParameter.PLUMBING_FIXTURES_VENT_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.PLUMBING_FIXTURES_WASTE_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.PLUMBING_FIXTURES_CW_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.PLUMBING_FIXTURES_HW_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.PLUMBING_FIXTURES_TRAP: return StorageType.String;
                case BuiltInParameter.PLUMBING_FIXTURES_DRAIN: return StorageType.String;
                case BuiltInParameter.PLUMBING_FIXTURES_SUPPLY_PIPE: return StorageType.String;
                case BuiltInParameter.PLUMBING_FIXTURES_SUPPLY_FITTING: return StorageType.String;
                case BuiltInParameter.LIGHTING_FIXTURE_LIGHT_EMITTER: return StorageType.String;
                case BuiltInParameter.FBX_LIGHT_SPOT_FIELD_ANGLE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_SPOT_BEAM_ANGLE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_SPOT_TILT_ANGLE: return StorageType.Double;
                case BuiltInParameter.FBX_LIGHT_LIMUNOUS_FLUX: return StorageType.Double;
                case BuiltInParameter.LIGHTING_FIXTURE_LAMP: return StorageType.String;
                case BuiltInParameter.LIGHTING_FIXTURE_WATTAGE: return StorageType.String;
                case BuiltInParameter.ELECTICAL_EQUIP_VOLTAGE: return StorageType.String;
                case BuiltInParameter.ELECTICAL_EQUIP_WATTAGE: return StorageType.String;
                case BuiltInParameter.CURTAIN_WALL_SYSPANEL_THICKNESS: return StorageType.Double;
                case BuiltInParameter.CURTAIN_WALL_PANEL_HOST_ID: return StorageType.ElementId;
                case BuiltInParameter.CURTAIN_WALL_SYSPANEL_OFFSET: return StorageType.Double;
                case BuiltInParameter.CURTAIN_WALL_PANELS_WIDTH: return StorageType.Double;
                case BuiltInParameter.CURTAIN_WALL_PANELS_HEIGHT: return StorageType.Double;
                case BuiltInParameter.ALL_MODEL_MODEL: return StorageType.String;
                case BuiltInParameter.ALL_MODEL_MANUFACTURER: return StorageType.String;
                case BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS: return StorageType.String;
                case BuiltInParameter.ALL_MODEL_TYPE_COMMENTS: return StorageType.String;
                case BuiltInParameter.ALL_MODEL_URL: return StorageType.String;
                case BuiltInParameter.ALL_MODEL_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.RGB_B_PARAM: return StorageType.Integer;
                case BuiltInParameter.RGB_G_PARAM: return StorageType.Integer;
                case BuiltInParameter.RGB_R_PARAM: return StorageType.Integer;
                case BuiltInParameter.ELLIPSE_Y_PARAM: return StorageType.String;
                case BuiltInParameter.ELLIPSE_X_PARAM: return StorageType.String;
                case BuiltInParameter.GROUPNAME_PARAM: return StorageType.String;
                case BuiltInParameter.ICON_INDEX_PARAM: return StorageType.Integer;
                case BuiltInParameter.SHOW_ICON_PARAM: return StorageType.Integer;
                case BuiltInParameter.DEBUGTAB_DATABOUNDCONTROLSDEMO_DOUBLE: return StorageType.Double;
                case BuiltInParameter.DEBUGTAB_DATABOUNDCONTROLSDEMO_INTEGER: return StorageType.Integer;
                case BuiltInParameter.DEBUGTAB_DATABOUNDCONTROLSDEMO_BOOLEAN: return StorageType.Integer;
                case BuiltInParameter.DEBUGTAB_DATABOUNDCONTROLSDEMO_ENUM: return StorageType.Integer;
                case BuiltInParameter.CASEWORK_DEPTH: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_Z: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_Y: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_LINK_RELEASE_ROTATION_X: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_Z: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_Y: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_LINK_RELEASE_TRANSLATION_X: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_PHYSICAL_TYPE: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_SKETCH_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_SKETCH_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_WALL_BASE_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_WALL_TOP_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_WALL_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_WALL_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_FLOOR_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_FLOOR_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_COLUMN_BASE_EXTENSION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_BASE_EXTENSION_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_COLUMN_TOP_EXTENSION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_TOP_EXTENSION_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_TOP_Y_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_TOP_Z_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_TOP_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_BASE_Y_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_BASE_Z_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_BASE_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_END_Z_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_END_Y_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_END_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_MODEL_START_Z_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_START_Y_PROJECTION: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_MODEL_START_ALIGNMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.ELEMENT_LOCKED_PARAM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_IS_POST: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_ANGLED_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_TANGENT_CONNECTION: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_HEIGHT_SHIFT_VAL: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_HEIGHT_SHIFT_TYPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_RAIL_NAME: return StorageType.String;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_PLACEMENT: return StorageType.None;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_SLOPE_ANGLE: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_BOTTOM_ANGLE: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_TOP_ANGLE: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_HEIGHT_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BASE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_FAMILY: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_RAILING_RAIL_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_RAIL_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_RAIL_STRUCTURE: return StorageType.None;
                case BuiltInParameter.STAIRS_RAILING_SHAPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_LENGTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTERS_PER_TREAD: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_SPACING: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_SPACING_TYPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_BALUSTER_SHAPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_RAILING_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_RAILING_HEIGHT: return StorageType.Double;
                case BuiltInParameter.RAMP_ATTR_TEXT_SIZE: return StorageType.Double;
                case BuiltInParameter.RAMP_ATTR_TEXT_FONT: return StorageType.String;
                case BuiltInParameter.RAMP_ATTR_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.RAMP_ATTR_RIGHT_BALUSTER_ATTACH_PT: return StorageType.Integer;
                case BuiltInParameter.RAMP_ATTR_LEFT_BALUSTER_ATTACH_PT: return StorageType.Integer;
                case BuiltInParameter.RAMP_ATTR_SHAPE: return StorageType.Integer;
                case BuiltInParameter.RAMP_ATTR_THICKNESS: return StorageType.Double;
                case BuiltInParameter.RAMP_MAX_RUN_LENGTH: return StorageType.Double;
                case BuiltInParameter.RAMP_ATTR_MIN_INV_SLOPE: return StorageType.Double;
                case BuiltInParameter.ASSIGN_TEMPLATE_ON_VIEW_CREATION: return StorageType.Integer;
                case BuiltInParameter.DEFAULT_VIEW_TEMPLATE: return StorageType.ElementId;
                case BuiltInParameter.PLAN_VIEW_VIEW_DIR: return StorageType.Integer;
                case BuiltInParameter.POCHE_MAT_ID: return StorageType.ElementId;
                case BuiltInParameter.ELEVATN_TAG: return StorageType.ElementId;
                case BuiltInParameter.CALLOUT_TAG: return StorageType.ElementId;
                case BuiltInParameter.SECTION_TAG: return StorageType.ElementId;
                case BuiltInParameter.CALLOUT_SYNCRONIZE_BOUND_OFFSET_FAR: return StorageType.Integer;
                case BuiltInParameter.CALLOUT_CORNER_SHEET_RADIUS: return StorageType.Double;
                case BuiltInParameter.CALLOUT_ATTR_HEAD_TAG: return StorageType.ElementId;
                case BuiltInParameter.GRID_BUBBLE_END_2: return StorageType.Integer;
                case BuiltInParameter.GRID_BUBBLE_END_1: return StorageType.Integer;
                case BuiltInParameter.DATUM_BUBBLE_LOCATION_IN_ELEV: return StorageType.Integer;
                case BuiltInParameter.DATUM_BUBBLE_END_1: return StorageType.Integer;
                case BuiltInParameter.DATUM_BUBBLE_END_2: return StorageType.Integer;
                case BuiltInParameter.DATUM_TEXT: return StorageType.String;
                case BuiltInParameter.ELLIPSE_FOCUS_MRK_VISIBLE: return StorageType.Integer;
                case BuiltInParameter.ARC_CURVE_CNTR_MRK_VISIBLE: return StorageType.Integer;
                case BuiltInParameter.REF_TABLE_PARAM_NAME: return StorageType.String;
                case BuiltInParameter.REF_TABLE_ELEM_NAME: return StorageType.String;
                case BuiltInParameter.RBS_PANEL_SCHEDULE_SHEET_APPEARANCE_INST_PARAM: return StorageType.None;
                case BuiltInParameter.RBS_PANEL_SCHEDULE_SHEET_APPEARANCE_PARAM: return StorageType.None;
                case BuiltInParameter.SCHEDULE_EMBEDDED_PARAM: return StorageType.None;
                case BuiltInParameter.SCHEDULE_SHEET_APPEARANCE_PARAM: return StorageType.None;
                case BuiltInParameter.SCHEDULE_FORMAT_PARAM: return StorageType.None;
                case BuiltInParameter.SCHEDULE_GROUP_PARAM: return StorageType.None;
                case BuiltInParameter.SCHEDULE_FILTER_PARAM: return StorageType.None;
                case BuiltInParameter.SCHEDULE_FIELDS_PARAM: return StorageType.None;
                case BuiltInParameter.RASTER_SYMBOL_LINKLOAD_STATUS: return StorageType.String;
                case BuiltInParameter.RASTER_ENABLE_SNAPS: return StorageType.Integer;
                case BuiltInParameter.RASTER_SYMBOL_PAGENUMBER: return StorageType.Integer;
                case BuiltInParameter.RASTER_HORIZONTAL_SCALE: return StorageType.Double;
                case BuiltInParameter.RASTER_VERTICAL_SCALE: return StorageType.Double;
                case BuiltInParameter.RASTER_SYMBOL_HEIGHT: return StorageType.Double;
                case BuiltInParameter.RASTER_SYMBOL_WIDTH: return StorageType.Double;
                case BuiltInParameter.RASTER_SYMBOL_RESOLUTION: return StorageType.Double;
                case BuiltInParameter.RASTER_SYMBOL_FILENAME: return StorageType.String;
                case BuiltInParameter.RASTER_SYMBOL_VIEWNAME: return StorageType.String;
                case BuiltInParameter.RASTER_SYMBOL_PIXELHEIGHT: return StorageType.Integer;
                case BuiltInParameter.RASTER_SYMBOL_PIXELWIDTH: return StorageType.Integer;
                case BuiltInParameter.RASTER_LOCK_PROPORTIONS: return StorageType.Integer;
                case BuiltInParameter.RASTER_SHEETHEIGHT: return StorageType.Double;
                case BuiltInParameter.RASTER_SHEETWIDTH: return StorageType.Double;
                case BuiltInParameter.IMPORT_ADT_ENTITY_ROLL: return StorageType.Double;
                case BuiltInParameter.IMPORT_ADT_ENTITY_THICKNESS: return StorageType.Double;
                case BuiltInParameter.IMPORT_ADT_ENTITY_LENGTH: return StorageType.Double;
                case BuiltInParameter.IMPORT_ADT_ENTITY_WIDTH: return StorageType.Double;
                case BuiltInParameter.IMPORT_ADT_ENTITY_HEIGHT: return StorageType.Double;
                case BuiltInParameter.IMPORT_ADT_COMPONENTS_DESC: return StorageType.String;
                case BuiltInParameter.IMPORT_ADT_ENTITY_STYLE: return StorageType.String;
                case BuiltInParameter.IMPORT_ADT_ENTITY_STRUCT_TYPE: return StorageType.String;
                case BuiltInParameter.IMPORT_ADT_ENTITY_TYPE: return StorageType.String;
                case BuiltInParameter.RVT_LINK_PHASE_MAP: return StorageType.None;
                case BuiltInParameter.RVT_LINK_REFERENCE_TYPE: return StorageType.Integer;
                case BuiltInParameter.RVT_LINK_FILE_NAME_WITHOUT_EXT: return StorageType.String;
                case BuiltInParameter.RVT_LEVEL_OFFSET: return StorageType.Double;
                case BuiltInParameter.RVT_HOST_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.RVT_SOURCE_LEVEL: return StorageType.String;
                case BuiltInParameter.RVT_LINK_INSTANCE_NAME: return StorageType.String;
                case BuiltInParameter.GEO_LOCATION: return StorageType.None;
                case BuiltInParameter.IMPORT_INSTANCE_SCALE: return StorageType.Double;
                case BuiltInParameter.IMPORT_BACKGROUND: return StorageType.Integer;
                case BuiltInParameter.IMPORT_DISPLAY_UNITS: return StorageType.Integer;
                case BuiltInParameter.IMPORT_BASE_LEVEL_OFFSET: return StorageType.Double;
                case BuiltInParameter.IMPORT_BASE_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.IMPORT_SCALE: return StorageType.Double;
                case BuiltInParameter.IMPORT_SYMBOL_NAME: return StorageType.String;
                case BuiltInParameter.ELEV_SYMBOL_ID: return StorageType.ElementId;
                case BuiltInParameter.ELEV_REFERENCE_LABEL_POS: return StorageType.Integer;
                case BuiltInParameter.ELEV_ASSOC_DATUM: return StorageType.ElementId;
                case BuiltInParameter.ELEV_VIEW_NAME_POS: return StorageType.Integer;
                case BuiltInParameter.ELEV_SHOW_VIEW_NAME: return StorageType.Integer;
                case BuiltInParameter.ELEV_TEXT_POS: return StorageType.Integer;
                case BuiltInParameter.ELEV_ARROW_FILLED: return StorageType.Integer;
                case BuiltInParameter.ELEV_ARROW_ANGLE: return StorageType.Double;
                case BuiltInParameter.ELEV_SHAPE: return StorageType.Integer;
                case BuiltInParameter.ELEV_WIDTH: return StorageType.Double;
                case BuiltInParameter.COLOR_FILL_SWATCH_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.COLOR_FILL_SWATCH_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.COLOR_FILL_FILTERED_PARAM: return StorageType.Integer;
                case BuiltInParameter.SHEET_GUIDE_GRID: return StorageType.ElementId;
                case BuiltInParameter.SHEET_CURRENT_REVISION_ISSUED: return StorageType.Integer;
                case BuiltInParameter.SHEET_CURRENT_REVISION_ISSUED_BY: return StorageType.String;
                case BuiltInParameter.SHEET_CURRENT_REVISION_ISSUED_TO: return StorageType.String;
                case BuiltInParameter.SHEET_CURRENT_REVISION_DATE: return StorageType.String;
                case BuiltInParameter.SHEET_CURRENT_REVISION_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.SHEET_REVISIONS_ON_SHEET: return StorageType.None;
                case BuiltInParameter.SHEET_CURRENT_REVISION: return StorageType.String;
                case BuiltInParameter.SHEET_HEIGHT: return StorageType.Double;
                case BuiltInParameter.SHEET_WIDTH: return StorageType.Double;
                case BuiltInParameter.SHEET_FILE_PATH: return StorageType.String;
                case BuiltInParameter.SHEET_APPROVED_BY: return StorageType.String;
                case BuiltInParameter.SHEET_DESIGNED_BY: return StorageType.String;
                case BuiltInParameter.SHEET_SCHEDULED: return StorageType.Integer;
                case BuiltInParameter.SHEET_CHECKED_BY: return StorageType.String;
                case BuiltInParameter.SHEET_DRAWN_BY: return StorageType.String;
                case BuiltInParameter.SHEET_DATE: return StorageType.String;
                case BuiltInParameter.SHEET_SCALE: return StorageType.String;
                case BuiltInParameter.SHEET_NUMBER: return StorageType.String;
                case BuiltInParameter.SHEET_NAME: return StorageType.String;
                case BuiltInParameter.SPACING_APPEND: return StorageType.None;
                case BuiltInParameter.AUTO_JOIN_CONDITION_WALL: return StorageType.Integer;
                case BuiltInParameter.AUTO_MULLION_BORDER2_HORIZ: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER1_HORIZ: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER2_VERT: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER1_VERT: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_INTERIOR_HORIZ: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_INTERIOR_VERT: return StorageType.ElementId;
                case BuiltInParameter.AUTO_PANEL_WALL: return StorageType.ElementId;
                case BuiltInParameter.AUTO_JOIN_CONDITION: return StorageType.Integer;
                case BuiltInParameter.AUTO_PANEL: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER2_GRID2: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER1_GRID2: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER2_GRID1: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_BORDER1_GRID1: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_INTERIOR_GRID2: return StorageType.ElementId;
                case BuiltInParameter.AUTO_MULLION_INTERIOR_GRID1: return StorageType.ElementId;
                case BuiltInParameter.CURTAIN_GRID_BASE_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.MULLION_ANGLE: return StorageType.Double;
                case BuiltInParameter.MULLION_POSITION: return StorageType.ElementId;
                case BuiltInParameter.MULLION_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.TRAP_MULL_WIDTH: return StorageType.Double;
                case BuiltInParameter.MULLION_DEPTH2: return StorageType.Double;
                case BuiltInParameter.MULLION_DEPTH1: return StorageType.Double;
                case BuiltInParameter.MULLION_DEPTH: return StorageType.Double;
                case BuiltInParameter.LV_MULLION_LEG2: return StorageType.Double;
                case BuiltInParameter.LV_MULLION_LEG1: return StorageType.Double;
                case BuiltInParameter.MULLION_CORNER_TYPE: return StorageType.Integer;
                case BuiltInParameter.MULLION_FAM_TYPE: return StorageType.Integer;
                case BuiltInParameter.MULLION_OFFSET: return StorageType.Double;
                case BuiltInParameter.CIRC_MULLION_RADIUS: return StorageType.Double;
                case BuiltInParameter.CUST_MULLION_THICK: return StorageType.Double;
                case BuiltInParameter.CUST_MULLION_WIDTH2: return StorageType.Double;
                case BuiltInParameter.CUST_MULLION_WIDTH1: return StorageType.Double;
                case BuiltInParameter.RECT_MULLION_THICK: return StorageType.Double;
                case BuiltInParameter.RECT_MULLION_WIDTH2: return StorageType.Double;
                case BuiltInParameter.RECT_MULLION_WIDTH1: return StorageType.Double;
                case BuiltInParameter.STAIRS_INST_ALWAYS_UP: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_TRIM_TOP: return StorageType.Integer;
                case BuiltInParameter.STAIRS_INST_DOWN_ARROW_ON: return StorageType.Integer;
                case BuiltInParameter.STAIRS_INST_DOWN_LABEL_TEXT: return StorageType.String;
                case BuiltInParameter.STAIRS_INST_DOWN_LABEL_ON: return StorageType.Integer;
                case BuiltInParameter.STAIRS_INST_UP_ARROW_ON: return StorageType.Integer;
                case BuiltInParameter.STAIRS_INST_UP_LABEL_TEXT: return StorageType.String;
                case BuiltInParameter.STAIRS_INST_UP_LABEL_ON: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_TEXT_SIZE: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_TEXT_FONT: return StorageType.String;
                case BuiltInParameter.STAIRS_ATTR_BODY_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_ATTR_LANDING_CARRIAGE: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_LANDINGS_OVERLAPPING: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_RIGHT_SIDE_STRINGER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_LEFT_SIDE_STRINGER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_NOSING_PLACEMENT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_RISER_TREAD_CONNECT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_RISER_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_NUM_MID_STRINGERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_STAIRS_CUT_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_LAST_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_FIRST_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_STAIRS_BOTTOM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_MONOLITHIC_STAIRS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_CALC_ENABLED: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_CALC_MAX: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_CALC_MIN: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_EQ_RESULT: return StorageType.Double;
                case BuiltInParameter.STAIRS_ACTUAL_TREAD_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_TREAD_MULT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_RISER_MULT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_STAIR_CALCULATOR: return StorageType.None;
                case BuiltInParameter.STAIRS_ACTUAL_NUM_RISERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_BREAK_SYM_IN_CUTLINE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_RISER_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_ATTR_RISER_TYPE: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_TREAD_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_ATTR_NOSING_LENGTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_TREAD_FRONT_PROFILE: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_ATTR_STRINGER_MATERIAL: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_ATTR_STRINGER_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_STRINGER_CARRIAGE: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_SIDE_STRINGER_TYPE_PARAM: return StorageType.Integer;
                case BuiltInParameter.STAIRS_MULTISTORY_TOP_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_STRINGERS_PRESENT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TOP_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_BASE_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_RISER_ANGLE: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_TREAD_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_STRINGER_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_STRINGER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_RISERS_PRESENT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ACTUAL_RISER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_DESIRED_NUM_RISERS: return StorageType.Integer;
                case BuiltInParameter.STAIRS_ATTR_TREAD_WIDTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_MINIMUM_TREAD_DEPTH: return StorageType.Double;
                case BuiltInParameter.STAIRS_ATTR_MAX_RISER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STAIRS_TOP_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_BASE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.LEVEL_IS_STRUCTURAL: return StorageType.Integer;
                case BuiltInParameter.LEVEL_IS_BUILDING_STORY: return StorageType.Integer;
                case BuiltInParameter.LEVEL_UP_TO_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.LEVEL_RELATIVE_BASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.LEVEL_ELEV: return StorageType.Double;
                case BuiltInParameter.LEVEL_NAME: return StorageType.String;
                case BuiltInParameter.LEVEL_HEAD_TAG: return StorageType.ElementId;
                case BuiltInParameter.MULTI_REFERENCE_ANNOTATION_SHOW_DIMENSION_TEXT: return StorageType.Integer;
                case BuiltInParameter.MULTI_REFERENCE_ANNOTATION_DIMENSION_STYLE: return StorageType.ElementId;
                case BuiltInParameter.MULTI_REFERENCE_ANNOTATION_GROUP_TAG_HEADS: return StorageType.Integer;
                case BuiltInParameter.MULTI_REFERENCE_ANNOTATION_TAG_TYPE: return StorageType.ElementId;
                case BuiltInParameter.MULTI_REFERENCE_ANNOTATION_REFERENCE_CATEGORY: return StorageType.ElementId;
                case BuiltInParameter.TAG_LEADER_TYPE: return StorageType.Integer;
                case BuiltInParameter.TAG_NO_BREAK_PARAM_STRINGS: return StorageType.Integer;
                case BuiltInParameter.ROOM_TAG_ORIENTATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.TAG_ORIENTATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.TAG_SAMPLE_TEXT: return StorageType.String;
                case BuiltInParameter.TAG_TAG: return StorageType.None;
                case BuiltInParameter.DIAMETER_SYMBOL_TEXT: return StorageType.String;
                case BuiltInParameter.DIAMETER_SYMBOL_LOCATION: return StorageType.Integer;
                case BuiltInParameter.RADIUS_SYMBOL_TEXT: return StorageType.String;
                case BuiltInParameter.VIS_GRAPHICS_COORDINATION_MODEL: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_POINT_CLOUDS: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_WORKSETS: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_ANALYTICAL_MODEL: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_DESIGNOPTIONS: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_RVT_LINKS: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_FILTERS: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_IMPORT: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_ANNOTATION: return StorageType.None;
                case BuiltInParameter.VIS_GRAPHICS_MODEL: return StorageType.None;
                case BuiltInParameter.LEVEL_ATTR_ROOM_COMPUTATION_AUTOMATIC: return StorageType.Integer;
                case BuiltInParameter.LEVEL_ATTR_ROOM_COMPUTATION_HEIGHT: return StorageType.Double;
                case BuiltInParameter.LEVEL_ROOM_COMPUTATION_HEIGHT: return StorageType.Double;
                case BuiltInParameter.ROOM_COMPUTATION_HEIGHT: return StorageType.Double;
                case BuiltInParameter.ALWAYS_ZERO_LENGTH: return StorageType.Double;
                case BuiltInParameter.ROOM_COMPUTATION_METHOD: return StorageType.Integer;
                case BuiltInParameter.ROOM_LOWER_OFFSET: return StorageType.Double;
                case BuiltInParameter.ROOM_UPPER_OFFSET: return StorageType.Double;
                case BuiltInParameter.ROOM_UPPER_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.ROOM_VOLUME: return StorageType.Double;
                case BuiltInParameter.ROOM_HEIGHT: return StorageType.Double;
                case BuiltInParameter.ROOM_PERIMETER: return StorageType.Double;
                case BuiltInParameter.ROOM_LEVEL_ID: return StorageType.ElementId;
                case BuiltInParameter.ROOM_OCCUPANCY: return StorageType.String;
                case BuiltInParameter.ROOM_DEPARTMENT: return StorageType.String;
                case BuiltInParameter.ROOM_FINISH_BASE: return StorageType.String;
                case BuiltInParameter.ROOM_FINISH_CEILING: return StorageType.String;
                case BuiltInParameter.ROOM_FINISH_WALL: return StorageType.String;
                case BuiltInParameter.ROOM_FINISH_FLOOR: return StorageType.String;
                case BuiltInParameter.ROOM_AREA: return StorageType.Double;
                case BuiltInParameter.ROOM_NUMBER: return StorageType.String;
                case BuiltInParameter.ROOM_NAME: return StorageType.String;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_HOR_ORIGIN_GAP: return StorageType.Double;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_VERT_ORIGIN_GAP: return StorageType.Double;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_WIDTH: return StorageType.Double;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_HEIGHT: return StorageType.Double;
                case BuiltInParameter.VIEW_ANALYSIS_RESULTS_VISIBILITY: return StorageType.None;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_TEXT_TYPE: return StorageType.ElementId;
                case BuiltInParameter.SPATIAL_FIELD_MGR_RESULTS_VISIBILITY: return StorageType.None;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_SHOW_DESCRIPTION: return StorageType.Integer;
                case BuiltInParameter.SPATIAL_FIELD_MGR_LEGEND_SHOW_CONFIG_NAME: return StorageType.Integer;
                case BuiltInParameter.SPATIAL_FIELD_MGR_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.SPATIAL_FIELD_MGR_CURRENT_NAME: return StorageType.Integer;
                case BuiltInParameter.SPATIAL_FIELD_MGR_RANGE: return StorageType.Integer;
                case BuiltInParameter.GRID_END_SEGMENTS_LENGTH: return StorageType.Double;
                case BuiltInParameter.GRID_END_SEGMENT_PATTERN: return StorageType.ElementId;
                case BuiltInParameter.GRID_END_SEGMENT_COLOR: return StorageType.Integer;
                case BuiltInParameter.GRID_END_SEGMENT_WEIGHT: return StorageType.Integer;
                case BuiltInParameter.GRID_CENTER_SEGMENT_PATTERN: return StorageType.ElementId;
                case BuiltInParameter.GRID_CENTER_SEGMENT_COLOR: return StorageType.Integer;
                case BuiltInParameter.GRID_CENTER_SEGMENT_WEIGHT: return StorageType.Integer;
                case BuiltInParameter.GRID_CENTER_SEGMENT_STYLE: return StorageType.Integer;
                case BuiltInParameter.GRID_BUBBLE_LINE_PEN: return StorageType.Integer;
                case BuiltInParameter.GRID_HEAD_TAG: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_PATH_FULL_STEP_ARROW: return StorageType.Integer;
                case BuiltInParameter.STAIRS_PATH_START_EXTENSION: return StorageType.Double;
                case BuiltInParameter.NUMBER_SYSTEM_TEXT_SIZE: return StorageType.Double;
                case BuiltInParameter.NUMBER_SYSTEM_TAG_TYPE: return StorageType.Integer;
                case BuiltInParameter.NUMBER_SYSTEM_DISPLAY_RULE: return StorageType.Integer;
                case BuiltInParameter.NUMBER_SYSTEM_REFERENCE: return StorageType.Integer;
                case BuiltInParameter.NUMBER_SYSTEM_JUSTIFY: return StorageType.Integer;
                case BuiltInParameter.NUMBER_SYSTEM_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.NUMBER_SYSTEM_REFERENCE_OFFSET: return StorageType.Double;
                case BuiltInParameter.NUMBER_SYSTEM_JUSTIFY_OFFSET: return StorageType.Double;
                case BuiltInParameter.STAIRS_TEXT_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.STAIRS_TEXT_TYPE: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_DOWN_TEXT: return StorageType.String;
                case BuiltInParameter.STAIRS_SHOW_DOWN_TEXT: return StorageType.Integer;
                case BuiltInParameter.STAIRS_UP_TEXT: return StorageType.String;
                case BuiltInParameter.STAIRS_SHOW_UP_TEXT: return StorageType.Integer;
                case BuiltInParameter.SHOW_ARROWHEAD_TO_CUT_MARK: return StorageType.Integer;
                case BuiltInParameter.DRAW_FOR_EACH_RUN: return StorageType.Integer;
                case BuiltInParameter.ARROWHEAD_END_AT_RISER: return StorageType.Integer;
                case BuiltInParameter.STAIRS_PATH_START_FROM_RISER: return StorageType.Integer;
                case BuiltInParameter.DISTANCE_TO_CUT_MARK: return StorageType.Double;
                case BuiltInParameter.LINE_SHAPE_AT_CORNER: return StorageType.Integer;
                case BuiltInParameter.ARROWHEAD_TYPE: return StorageType.ElementId;
                case BuiltInParameter.START_SYMBOL_TYPE: return StorageType.ElementId;
                case BuiltInParameter.CUT_MARK_SYMBOL_SIZE: return StorageType.Double;
                case BuiltInParameter.CUT_LINE_TYPE: return StorageType.Integer;
                case BuiltInParameter.CUT_LINE_ANGLE: return StorageType.Double;
                case BuiltInParameter.CUT_LINE_EXTENSION: return StorageType.Double;
                case BuiltInParameter.CUT_LINE_DISTANCE: return StorageType.Double;
                case BuiltInParameter.CUT_MARK_SYMBOL: return StorageType.Integer;
                case BuiltInParameter.SECTION_BROKEN_DISPLAY_STYLE: return StorageType.Integer;
                case BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_IMPERIAL: return StorageType.Integer;
                case BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_METRIC: return StorageType.Integer;
                case BuiltInParameter.SECTION_PARENT_VIEW_NAME: return StorageType.ElementId;
                case BuiltInParameter.SECTION_SHOW_IN_ONE_VIEW_ONLY: return StorageType.Integer;
                case BuiltInParameter.SECTION_ATTR_TAIL_TAG: return StorageType.ElementId;
                case BuiltInParameter.SECTION_ATTR_TAIL_WIDTH: return StorageType.Double;
                case BuiltInParameter.SECTION_ATTR_TAIL_LENGTH: return StorageType.Double;
                case BuiltInParameter.VIEWER_DETAIL_NUMBER: return StorageType.String;
                case BuiltInParameter.VIEWER_SHEET_NUMBER: return StorageType.String;
                case BuiltInParameter.SECTION_ATTR_HEAD_TAG: return StorageType.ElementId;
                case BuiltInParameter.INTERIOR_TICK_DISPLAY: return StorageType.Integer;
                case BuiltInParameter.WITNS_LINE_TICK_MARK: return StorageType.ElementId;
                case BuiltInParameter.DIM_TOTAL_LENGTH: return StorageType.Double;
                case BuiltInParameter.DIM_REFERENCE_COUNT: return StorageType.Integer;
                case BuiltInParameter.ALTERNATE_UNITS_SUFFIX: return StorageType.String;
                case BuiltInParameter.ALTERNATE_UNITS_PREFIX: return StorageType.String;
                case BuiltInParameter.EQUALITY_WITNESS_DISPLAY: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_SUPPRESS_SPACES: return StorageType.Integer;
                case BuiltInParameter.EQUALITY_FORMULA: return StorageType.None;
                case BuiltInParameter.DIM_STYLE_LEADER_TICK_MARK: return StorageType.ElementId;
                case BuiltInParameter.EQUALITY_TEXT_FOR_ANGULAR_DIM: return StorageType.String;
                case BuiltInParameter.EQUALITY_TEXT_FOR_CONTINUOUS_LINEAR_DIM: return StorageType.String;
                case BuiltInParameter.DIM_TEXT_LOCATION_FOR_LEADER: return StorageType.Integer;
                case BuiltInParameter.DIM_LEADER_DISPLAY_CONDITION: return StorageType.Integer;
                case BuiltInParameter.DIM_LEADER_SHOULDER_LENGTH: return StorageType.Double;
                case BuiltInParameter.DIM_LEADER_TYPE: return StorageType.Integer;
                case BuiltInParameter.DIM_TO_INTERSECTING_GRIDS: return StorageType.Integer;
                case BuiltInParameter.DIM_TO_INTERSECTING_WALLS: return StorageType.Integer;
                case BuiltInParameter.DIM_TO_INSERT_TYPE: return StorageType.Integer;
                case BuiltInParameter.FIXED_ROTATION: return StorageType.Integer;
                case BuiltInParameter.KEEP_READABLE: return StorageType.Integer;
                case BuiltInParameter.LEADER_LINE: return StorageType.Integer;
                case BuiltInParameter.LEADER_OFFSET_SHEET: return StorageType.Double;
                case BuiltInParameter.DIM_TO_INSERTS: return StorageType.Integer;
                case BuiltInParameter.SPOT_SLOPE_OFFSET_FROM_REFERENCE: return StorageType.Double;
                case BuiltInParameter.SPOT_SLOPE_SLOPE_REPRESENTATION: return StorageType.Integer;
                case BuiltInParameter.SPOT_SLOPE_SLOPE_DIRECTION: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_LOWER_VALUE: return StorageType.Double;
                case BuiltInParameter.SPOT_ELEV_SINGLE_OR_UPPER_VALUE: return StorageType.Double;
                case BuiltInParameter.SPOT_ELEV_IND_TYPE_ELEVATION: return StorageType.Integer;
                case BuiltInParameter.SPOT_COORDINATE_INCLUDE_ELEVATION: return StorageType.Integer;
                case BuiltInParameter.SPOT_COORDINATE_ELEVATION_SUFFIX: return StorageType.String;
                case BuiltInParameter.SPOT_COORDINATE_ELEVATION_PREFIX: return StorageType.String;
                case BuiltInParameter.SPOT_COORDINATE_BOTTOM_SUFFIX: return StorageType.String;
                case BuiltInParameter.SPOT_COORDINATE_BOTTOM_PREFIX: return StorageType.String;
                case BuiltInParameter.SPOT_COORDINATE_TOP_SUFFIX: return StorageType.String;
                case BuiltInParameter.SPOT_COORDINATE_TOP_PREFIX: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_LOWER_SUFFIX: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_LOWER_PREFIX: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_SINGLE_OR_UPPER_SUFFIX: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_SINGLE_OR_UPPER_PREFIX: return StorageType.String;
                case BuiltInParameter.BASELINE_DIM_OFFSET: return StorageType.Double;
                case BuiltInParameter.SPOT_ELEV_BEND_LEADER: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_IND_TYPE_BOTTOM: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_IND_TYPE_TOP: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_IND_BOTTOM: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_IND_TOP: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_TEXT_LOCATION: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_ROTATE_WITH_COMPONENT: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_DISPLAY_ELEVATIONS: return StorageType.Integer;
                case BuiltInParameter.ORDINATE_DIM_SETTING: return StorageType.None;
                case BuiltInParameter.LINEAR_DIM_TYPE: return StorageType.Integer;
                case BuiltInParameter.SPOT_DIM_LEADER: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_FLIPPED_DIM_LINE_EXTENSION: return StorageType.Double;
                case BuiltInParameter.DIM_STYLE_INTERIOR_TICK_MARK: return StorageType.ElementId;
                case BuiltInParameter.SPOT_TEXT_FROM_LEADER: return StorageType.Double;
                case BuiltInParameter.SPOT_COORDINATE_BASE: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_ANGULAR_UNITS_ALT: return StorageType.None;
                case BuiltInParameter.SPOT_ELEV_IND_TYPE: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_BOT_VALUE: return StorageType.Integer;
                case BuiltInParameter.ALTERNATE_UNITS: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_TOP_VALUE: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_LINEAR_UNITS_ALT: return StorageType.None;
                case BuiltInParameter.SPOT_ELEV_TEXT_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_IND_ELEVATION: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_IND_EW: return StorageType.String;
                case BuiltInParameter.SPOT_ELEV_IND_NS: return StorageType.String;
                case BuiltInParameter.ARROW_CLOSED: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_READ_CONVENTION: return StorageType.Integer;
                case BuiltInParameter.HEAVY_END_PEN: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_DIM_LINE_SNAP_DIST: return StorageType.Double;
                case BuiltInParameter.DIM_STYLE_CENTERLINE_TICK_MARK: return StorageType.ElementId;
                case BuiltInParameter.SPOT_ELEV_LINE_PEN: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_TICK_MARK_PEN: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_LEADER_ARROWHEAD: return StorageType.ElementId;
                case BuiltInParameter.SPOT_ELEV_RELATIVE_BASE: return StorageType.ElementId;
                case BuiltInParameter.SPOT_ELEV_FLIP_TEXT_VERT: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_TEXT_HORIZ_OFFSET: return StorageType.Double;
                case BuiltInParameter.SPOT_ELEV_BASE: return StorageType.Integer;
                case BuiltInParameter.SPOT_ELEV_SYMBOL: return StorageType.ElementId;
                case BuiltInParameter.DIM_STYLE_SHOW_OPENING_HT: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_CENTERLINE_PATTERN: return StorageType.ElementId;
                case BuiltInParameter.DIM_WITNS_LINE_EXTENSION_BELOW: return StorageType.Double;
                case BuiltInParameter.DIM_WITNS_LINE_CNTRL: return StorageType.Integer;
                case BuiltInParameter.DIM_LINE_EXTENSION: return StorageType.Double;
                case BuiltInParameter.DIM_STYLE_CENTERLINE_SYMBOL: return StorageType.ElementId;
                case BuiltInParameter.DIM_TEXT_BACKGROUND: return StorageType.Integer;
                case BuiltInParameter.DIM_STYLE_ANGULAR_UNITS: return StorageType.None;
                case BuiltInParameter.DIM_STYLE_LINEAR_UNITS: return StorageType.None;
                case BuiltInParameter.LEADER_ARROW_WIDTH: return StorageType.Double;
                case BuiltInParameter.ARROW_FILLED: return StorageType.Integer;
                case BuiltInParameter.HEAVY_TICK_MARK_PEN: return StorageType.Integer;
                case BuiltInParameter.ARROW_SIZE: return StorageType.Double;
                case BuiltInParameter.ARROW_TYPE: return StorageType.Integer;
                case BuiltInParameter.TICK_MARK_PEN: return StorageType.Integer;
                case BuiltInParameter.TEXT_POSITION: return StorageType.Integer;
                case BuiltInParameter.RADIUS_SYMBOL_LOCATION: return StorageType.Integer;
                case BuiltInParameter.CENTER_MARK_SIZE: return StorageType.Double;
                case BuiltInParameter.ARC_CENTER_MARK: return StorageType.Integer;
                case BuiltInParameter.WITNS_LINE_GAP_TO_ELT: return StorageType.Double;
                case BuiltInParameter.WITNS_LINE_EXTENSION: return StorageType.Double;
                case BuiltInParameter.TEXT_DIST_TO_LINE: return StorageType.Double;
                case BuiltInParameter.TEXT_ALIGNMENT: return StorageType.Integer;
                case BuiltInParameter.MODEL_TEXT_SIZE: return StorageType.Double;
                case BuiltInParameter.TEXT_STYLE_SIZE: return StorageType.Double;
                case BuiltInParameter.TEXT_STYLE_FONT: return StorageType.String;
                case BuiltInParameter.SHOW_TITLE: return StorageType.Integer;
                case BuiltInParameter.TITLE_STYLE_UNDERLINE: return StorageType.Integer;
                case BuiltInParameter.TITLE_STYLE_ITALIC: return StorageType.Integer;
                case BuiltInParameter.TITLE_STYLE_BOLD: return StorageType.Integer;
                case BuiltInParameter.TITLE_SIZE: return StorageType.Double;
                case BuiltInParameter.TITLE_FONT: return StorageType.String;
                case BuiltInParameter.TEXT_WIDTH_SCALE: return StorageType.Double;
                case BuiltInParameter.TEXT_TAB_SIZE: return StorageType.Double;
                case BuiltInParameter.ARC_LEADER_PARAM: return StorageType.Integer;
                case BuiltInParameter.DIM_LEADER_ARROWHEAD: return StorageType.ElementId;
                case BuiltInParameter.SHEET_ISSUE_DATE: return StorageType.String;
                case BuiltInParameter.PROJECT_ISSUE_DATE: return StorageType.String;
                case BuiltInParameter.PROJECT_STATUS: return StorageType.String;
                case BuiltInParameter.CLIENT_NAME: return StorageType.String;
                case BuiltInParameter.PROJECT_ADDRESS: return StorageType.String;
                case BuiltInParameter.PROJECT_NAME: return StorageType.String;
                case BuiltInParameter.PROJECT_NUMBER: return StorageType.String;
                case BuiltInParameter.LEADER_ARROWHEAD: return StorageType.ElementId;
                case BuiltInParameter.TEXT_BACKGROUND: return StorageType.Integer;
                case BuiltInParameter.TEXT_STYLE_UNDERLINE: return StorageType.Integer;
                case BuiltInParameter.TEXT_STYLE_ITALIC: return StorageType.Integer;
                case BuiltInParameter.TEXT_STYLE_BOLD: return StorageType.Integer;
                case BuiltInParameter.CURVE_IS_FILLED: return StorageType.Integer;
                case BuiltInParameter.TEXT_ALIGN_VERT: return StorageType.Integer;
                case BuiltInParameter.TEXT_ALIGN_HORZ: return StorageType.Integer;
                case BuiltInParameter.TEXT_TEXT: return StorageType.String;
                case BuiltInParameter.LINE_PATTERN: return StorageType.ElementId;
                case BuiltInParameter.LINE_COLOR: return StorageType.Integer;
                case BuiltInParameter.LINE_PEN: return StorageType.Integer;
                case BuiltInParameter.TEXT_COLOR: return StorageType.Integer;
                case BuiltInParameter.TEXT_SIZE: return StorageType.Double;
                case BuiltInParameter.TEXT_FONT: return StorageType.String;
                case BuiltInParameter.REFERENCE_LINE_SUBCATEGORY: return StorageType.ElementId;
                case BuiltInParameter.CLINE_SUBCATEGORY: return StorageType.ElementId;
                case BuiltInParameter.EDGE_LINEWORK: return StorageType.ElementId;
                case BuiltInParameter.BUILDING_CURVE_GSTYLE_PLUS_INVISIBLE: return StorageType.ElementId;
                case BuiltInParameter.BUILDING_CURVE_GSTYLE: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_CURVE_GSTYLE_FOR_2010_MASS: return StorageType.ElementId;
                case BuiltInParameter.HEAD_ON_PLACEMENT_METHOD: return StorageType.Integer;
                case BuiltInParameter.IS_VISIBLE_PARAM: return StorageType.Integer;
                case BuiltInParameter.FAMILY_CURVE_GSTYLE_PLUS_INVISIBLE_PLUS_STICK_SYM_MINUS_ANALYTICAL:
                    return StorageType.ElementId;
                case BuiltInParameter.FAMILY_CURVE_GSTYLE_PLUS_INVISIBLE_MINUS_ANALYTICAL: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_CURVE_GSTYLE_PLUS_INVISIBLE_PLUS_STICK_SYM: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_CURVE_GSTYLE_PLUS_INVISIBLE: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_ELEM_SUBCATEGORY: return StorageType.ElementId;
                case BuiltInParameter.STAIRS_CURVE_TYPE: return StorageType.Integer;
                case BuiltInParameter.ROOF_SLOPE: return StorageType.Double;
                case BuiltInParameter.CURVE_PARAM_STEEL_CANTILEVER: return StorageType.Double;
                case BuiltInParameter.CURVE_PARAM_CONCRETE_CANTILEVER: return StorageType.Double;
                case BuiltInParameter.CURVE_NUMBER_OF_SEGMENTS: return StorageType.Integer;
                case BuiltInParameter.SPECIFY_SLOPE_OR_OFFSET: return StorageType.Integer;
                case BuiltInParameter.SLOPE_ARROW_LEVEL_END: return StorageType.ElementId;
                case BuiltInParameter.SLOPE_ARROW_LEVEL_START: return StorageType.ElementId;
                case BuiltInParameter.CURVE_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.CURVE_HEIGHT_OFFSET: return StorageType.Double;
                case BuiltInParameter.CURVE_IS_SLOPE_DEFINING: return StorageType.Integer;
                case BuiltInParameter.DEFINES_CONSTANT_HEIGHT: return StorageType.Integer;
                case BuiltInParameter.ROOF_CURVE_HEIGHT_AT_WALL: return StorageType.Double;
                case BuiltInParameter.ROOF_CURVE_HEIGHT_OFFSET: return StorageType.Double;
                case BuiltInParameter.ROOF_CURVE_IS_SLOPE_DEFINING: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBTHICKNESS_LOCATION: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGETHICKNESS_LOCATION: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_TOP_WEB_FILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_SLOPED_WEB_ANGLE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_SLOPED_FLANGE_ANGLE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_CANTILEVER_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_CANTILEVER_LENGTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_BOTTOM_CUT_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_BOTTOM_CUT_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_TOP_CUT_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_TOP_CUT_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_FAMILY_CODE_NAME: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_FAMILY_NAME_KEY: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_SECTION_NAME_KEY: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_TOP_BEND_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_MIDDLE_BEND_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_SIGMA_PROFILE_BEND_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ZPROFILE_BOTTOM_FLANGE_LENGTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_CPROFILE_FOLD_LENGTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_LPROFILE_LIP_LENGTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_DIAMETER_SHORTER_FLANGE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_DIAMETER_LONGER_FLANGE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_SHORTER_FLANGE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_2_LONGER_FLANGE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_LANGLE_BOLT_SPACING_1_LONGER_FLANGE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_WEB: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_BETWEEN_ROWS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING_TWO_ROWS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_DIAMETER: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_BOLT_SPACING: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEB_TOE_OF_FILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGE_TOE_OF_FILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_CLEAR_WEB_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_IWELDED_BOTTOMFLANGEWIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_IWELDED_BOTTOMFLANGETHICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_IWELDED_TOPFLANGEWIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_IWELDED_TOPFLANGETHICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_HSS_OUTERFILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_HSS_INNERFILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBFILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGEFILLET: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBHEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_WEBTHICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_ISHAPE_FLANGETHICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_SHEAR_AREA_WEAK_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_SHEAR_AREA_STRONG_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_WARPING_CONSTANT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_TORSIONAL_MODULUS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_TORSIONAL_MOMENT_OF_INERTIA: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_PLASTIC_MODULUS_WEAK_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_PLASTIC_MODULUS_STRONG_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_ELASTIC_MODULUS_WEAK_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_ELASTIC_MODULUS_STRONG_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_MOMENT_OF_INERTIA_WEAK_AXIS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_MOMENT_OF_INERTIA_STRONG_AXIS:
                    return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_NOMINAL_WEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_PERIMETER: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_ALPHA: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_CENTROID_VERTICAL: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_CENTROID_HORIZ: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_AREA: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_PIPESTANDARD_WALLDESIGNTHICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_PIPESTANDARD_WALLNOMINALTHICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_DIAMETER: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_HEIGHT: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_COMMON_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_SECTION_SHAPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_MATERIAL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ANALYTICAL_DEFINE_THERMAL_PROPERTIES_BY: return StorageType.Integer;
                case BuiltInParameter.ANALYTIC_CONSTRUCTION_GBXML_TYPEID: return StorageType.String;
                case BuiltInParameter.ANALYTIC_CONSTRUCTION_LOOKUP_TABLE: return StorageType.String;
                case BuiltInParameter.ANALYTICAL_ROUGHNESS: return StorageType.Integer;
                case BuiltInParameter.ANALYTICAL_ABSORPTANCE: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_THERMAL_MASS: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_VISUAL_LIGHT_TRANSMITTANCE: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_SOLAR_HEAT_GAIN_COEFFICIENT: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_THERMAL_RESISTANCE: return StorageType.Double;
                case BuiltInParameter.ANALYTICAL_HEAT_TRANSFER_COEFFICIENT: return StorageType.Double;
                case BuiltInParameter.VIEW_DESIGN_OPTIONS_CONFIG: return StorageType.ElementId;
                case BuiltInParameter.VIEW_UNDERLAY_TOP_ID: return StorageType.ElementId;
                case BuiltInParameter.VIEW_GRAPH_SUN_PATH_SIZE: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SUN_PATH: return StorageType.Integer;
                case BuiltInParameter.VIEW_ANALYSIS_DISPLAY_STYLE: return StorageType.ElementId;
                case BuiltInParameter.VIEW_GRAPH_SCHED_LEVEL_RELATIVE_BASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SCHED_HIDDEN_LEVELS: return StorageType.None;
                case BuiltInParameter.VIEW_GRAPH_SCHED_TOTAL_ROWS: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SCHED_ROWS_COUNT: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SCHED_GRID_APPEARANCE: return StorageType.None;
                case BuiltInParameter.VIEW_GRAPH_SCHED_TEXT_APPEARANCE: return StorageType.None;
                case BuiltInParameter.VIEW_GRAPH_SCHED_TITLE: return StorageType.String;
                case BuiltInParameter.VIEW_GRAPH_SCHED_ROWS_FROM: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SCHED_GROUP_SIMILAR: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SCHED_MATERIAL_TYPES: return StorageType.None;
                case BuiltInParameter.VIEW_GRAPH_SCHED_LOCATIONS_HIGH: return StorageType.String;
                case BuiltInParameter.VIEW_GRAPH_SCHED_LOCATIONS_LOW: return StorageType.String;
                case BuiltInParameter.VIEW_GRAPH_SCHED_BOTTOM_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.VIEW_GRAPH_SCHED_TOP_LEVEL: return StorageType.ElementId;
                case BuiltInParameter.VIEWPORT_ATTR_ORIENTATION_ON_SHEET: return StorageType.Integer;
                case BuiltInParameter.VIEWPORT_ATTR_SHOW_BOX: return StorageType.Integer;
                case BuiltInParameter.VIEWPORT_ATTR_SHOW_EXTENSION_LINE: return StorageType.Integer;
                case BuiltInParameter.VIEWPORT_ATTR_SHOW_LABEL: return StorageType.Integer;
                case BuiltInParameter.VIEWPORT_ATTR_LABEL_TAG: return StorageType.ElementId;
                case BuiltInParameter.VIEW_SCALE_HAVENAME: return StorageType.Integer;
                case BuiltInParameter.VIEW_SCALE_CUSTOMNAME: return StorageType.String;
                case BuiltInParameter.VIEW_GRAPH_SCHED_OFF_GRID: return StorageType.Integer;
                case BuiltInParameter.VIEW_GRAPH_SCHED_UNITS_FORMAT: return StorageType.None;
                case BuiltInParameter.VIEWPORT_SHEET_NAME: return StorageType.String;
                case BuiltInParameter.VIEWPORT_SHEET_NUMBER: return StorageType.String;
                case BuiltInParameter.VIEWPORT_SCALE: return StorageType.String;
                case BuiltInParameter.VIEWPORT_VIEW_NAME: return StorageType.String;
                case BuiltInParameter.VIEWPORT_DETAIL_NUMBER: return StorageType.String;
                case BuiltInParameter.VIEW_TEMPLATE_FOR_SCHEDULE: return StorageType.ElementId;
                case BuiltInParameter.RENDER_RPC_PROPERTIES: return StorageType.String;
                case BuiltInParameter.FAMILY_SYMBOLIC_REP: return StorageType.Integer;
                case BuiltInParameter.FAMILY_RENDERING_TYPE: return StorageType.Integer;
                case BuiltInParameter.RENDER_RPC_FILENAME: return StorageType.String;
                case BuiltInParameter.RENDER_PLANT_TRIM_HEIGHT: return StorageType.Double;
                case BuiltInParameter.RENDER_PLANT_HEIGHT: return StorageType.Double;
                case BuiltInParameter.RENDER_PLANT_NAME: return StorageType.String;
                case BuiltInParameter.VIEW_CAMERA_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.COLOR_SCHEME_LOCATION: return StorageType.Integer;
                case BuiltInParameter.VIEW_DEPENDENCY: return StorageType.String;
                case BuiltInParameter.VIEW_BACK_CLIPPING: return StorageType.Integer;
                case BuiltInParameter.VIEW_ASSOCIATED_ASSEMBLY_INSTANCE_ID: return StorageType.ElementId;
                case BuiltInParameter.VIEW_GRAPH_SCHED_TOTAL_COLUMNS: return StorageType.Integer;
                case BuiltInParameter.VIEW_UNDERLAY_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.VIEW_TEMPLATE: return StorageType.ElementId;
                case BuiltInParameter.VIEW_GRAPH_SCHED_NUMBER_COLUMNS: return StorageType.Integer;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS: return StorageType.None;
                case BuiltInParameter.MODEL_GRAPHICS_STYLE_ANON_DRAFT: return StorageType.Integer;
                case BuiltInParameter.VIEW_REFERENCING_DETAIL: return StorageType.String;
                case BuiltInParameter.VIEW_REFERENCING_SHEET: return StorageType.String;
                case BuiltInParameter.VIEW_CAMERA_POSITION: return StorageType.Integer;
                case BuiltInParameter.PLAN_VIEW_NORTH: return StorageType.Integer;
                case BuiltInParameter.WALKTHROUGH_FRAMES_COUNT: return StorageType.None;
                case BuiltInParameter.PLAN_VIEW_LEVEL: return StorageType.String;
                case BuiltInParameter.MODEL_GRAPHICS_STYLE: return StorageType.Integer;
                case BuiltInParameter.VIEW_VISIBLE_CATEGORIES: return StorageType.None;
                case BuiltInParameter.VIEW_DISCIPLINE: return StorageType.Integer;
                case BuiltInParameter.PLAN_VIEW_RANGE: return StorageType.None;
                case BuiltInParameter.VIEW_MODEL_DISPLAY_MODE: return StorageType.Integer;
                case BuiltInParameter.VIEW_SHOW_MASSING: return StorageType.Integer;
                case BuiltInParameter.PLAN_VIEW_TOP_CLIP_HEIGHT: return StorageType.Double;
                case BuiltInParameter.VIEW_CLEAN_JOINS: return StorageType.Integer;
                case BuiltInParameter.VIEW_SHEET_VIEWPORT_INFO: return StorageType.String;
                case BuiltInParameter.PLAN_VIEW_CUT_PLANE_HEIGHT: return StorageType.Double;
                case BuiltInParameter.VIEW_DEPTH: return StorageType.ElementId;
                case BuiltInParameter.VIEW_UNDERLAY_BOTTOM_ID: return StorageType.ElementId;
                case BuiltInParameter.VIEW_SCALE_PULLDOWN_IMPERIAL: return StorageType.Integer;
                case BuiltInParameter.VIEW_SCALE_PULLDOWN_METRIC: return StorageType.Integer;
                case BuiltInParameter.VIEW_SCALE: return StorageType.Integer;
                case BuiltInParameter.VIEW_SCHEMA_SETTING_FOR_SYSTEM: return StorageType.None;
                case BuiltInParameter.VIEW_SCHEMA_SETTING_FOR_BUILDING: return StorageType.None;
                case BuiltInParameter.VIEW_FIXED_SKETCH_PLANE: return StorageType.ElementId;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_PHOTO_EXPOSURE: return StorageType.None;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_FOG: return StorageType.None;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_BACKGROUND: return StorageType.None;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_SS_INTENSITY: return StorageType.None;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_LIGHTING: return StorageType.None;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_SHADOWS: return StorageType.None;
                case BuiltInParameter.GRAPHIC_DISPLAY_OPTIONS_MODEL: return StorageType.None;
                case BuiltInParameter.VIEWER3D_RENDER_SETTINGS: return StorageType.None;
                case BuiltInParameter.VIEWER_BOUND_FAR_CLIPPING: return StorageType.Integer;
                case BuiltInParameter.VIEWER_REFERENCE_LABEL_TEXT: return StorageType.String;
                case BuiltInParameter.VIEWER_IS_REFERENCE: return StorageType.Integer;
                case BuiltInParameter.VIEWER_REFERENCE_LABEL: return StorageType.String;
                case BuiltInParameter.VIEW_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.VIEWER_MODEL_CLIP_BOX_ACTIVE: return StorageType.Integer;
                case BuiltInParameter.VIEW_NAME: return StorageType.String;
                case BuiltInParameter.VIEWER_BOUND_ACTIVE_NEAR: return StorageType.Integer;
                case BuiltInParameter.VIEWER_BOUND_ACTIVE_FAR: return StorageType.Integer;
                case BuiltInParameter.VIEWER_BOUND_ACTIVE_BOTTOM: return StorageType.Integer;
                case BuiltInParameter.VIEWER_BOUND_ACTIVE_TOP: return StorageType.Integer;
                case BuiltInParameter.VIEWER_BOUND_ACTIVE_LEFT: return StorageType.Integer;
                case BuiltInParameter.VIEWER_BOUND_ACTIVE_RIGHT: return StorageType.Integer;
                case BuiltInParameter.VIEWER_BOUND_OFFSET_NEAR: return StorageType.Double;
                case BuiltInParameter.VIEWER_BOUND_OFFSET_FAR: return StorageType.Double;
                case BuiltInParameter.VIEWER_BOUND_OFFSET_BOTTOM: return StorageType.Double;
                case BuiltInParameter.VIEWER_BOUND_OFFSET_TOP: return StorageType.Double;
                case BuiltInParameter.VIEWER_BOUND_OFFSET_LEFT: return StorageType.Double;
                case BuiltInParameter.VIEWER_BOUND_OFFSET_RIGHT: return StorageType.Double;
                case BuiltInParameter.VIEWER_ANNOTATION_CROP_ACTIVE: return StorageType.Integer;
                case BuiltInParameter.VIEWER_SHOW_UNCROPPED: return StorageType.Integer;
                case BuiltInParameter.VIEWER_CROP_REGION_DISABLED: return StorageType.Integer;
                case BuiltInParameter.VIEWER_CROP_REGION_VISIBLE: return StorageType.Integer;
                case BuiltInParameter.VIEWER_CROP_REGION: return StorageType.Integer;
                case BuiltInParameter.VIEWER_PERSPECTIVE: return StorageType.Integer;
                case BuiltInParameter.VIEWER_TARGET_ELEVATION: return StorageType.Double;
                case BuiltInParameter.VIEWER_OPTION_VISIBILITY: return StorageType.ElementId;
                case BuiltInParameter.VIEWER_EYE_ELEVATION: return StorageType.Double;
                case BuiltInParameter.DIM_LABEL_IS_INSTANCE: return StorageType.Integer;
                case BuiltInParameter.DIM_ISREPORTING: return StorageType.Integer;
                case BuiltInParameter.DIM_LEADER: return StorageType.Integer;
                case BuiltInParameter.DIM_DISPLAY_EQ: return StorageType.Integer;
                case BuiltInParameter.DIM_NOT_MODIFIABLE: return StorageType.Integer;
                case BuiltInParameter.DIM_LABEL: return StorageType.ElementId;
                case BuiltInParameter.DIM_LABEL_GP_SHOW: return StorageType.Integer;
                case BuiltInParameter.DIM_VALUE_ANGLE: return StorageType.Double;
                case BuiltInParameter.DIM_VALUE_LENGTH: return StorageType.Double;
                case BuiltInParameter.ELEM_REFERENCE_NAME_2D_XZ: return StorageType.Integer;
                case BuiltInParameter.CURVE_ELEM_DEFINES_SLOPE: return StorageType.Integer;
                case BuiltInParameter.RADIAL_ARRAY_ARC_RADIUS: return StorageType.Double;
                case BuiltInParameter.CURVE_DETERMINES_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.DATUM_PLANE_DEFINES_WALL_CLOSURE: return StorageType.Integer;
                case BuiltInParameter.CURVE_IS_DETAIL: return StorageType.Integer;
                case BuiltInParameter.CURVE_ELEM_ARC_RADIUS: return StorageType.Double;
                case BuiltInParameter.CURVE_ELEM_ARC_RANGE: return StorageType.Double;
                case BuiltInParameter.CURVE_ELEM_ARC_END_ANGLE: return StorageType.Double;
                case BuiltInParameter.CURVE_ELEM_ARC_START_ANGLE: return StorageType.Double;
                case BuiltInParameter.CURVE_ELEM_LINE_ANGLE: return StorageType.Double;
                case BuiltInParameter.CURVE_ELEM_LENGTH: return StorageType.Double;
                case BuiltInParameter.ELEM_DELETABLE_IN_FAMILY: return StorageType.Integer;
                case BuiltInParameter.ELEM_REFERENCE_NAME: return StorageType.Integer;
                case BuiltInParameter.DATUM_PLANE_DEFINES_ORIGIN: return StorageType.Integer;
                case BuiltInParameter.ELEM_IS_REFERENCE: return StorageType.Integer;
                case BuiltInParameter.COLUMN_LOCATION_MARK: return StorageType.String;
                case BuiltInParameter.COLUMN_TOP_ATTACH_CUT_PARAM: return StorageType.Integer;
                case BuiltInParameter.COLUMN_BASE_ATTACH_CUT_PARAM: return StorageType.Integer;
                case BuiltInParameter.COLUMN_BASE_ATTACHED_PARAM: return StorageType.Integer;
                case BuiltInParameter.COLUMN_TOP_ATTACHED_PARAM: return StorageType.Integer;
                case BuiltInParameter.COLUMN_BASE_ATTACHMENT_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.COLUMN_TOP_ATTACHMENT_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.COLUMN_BASE_ATTACH_JUSTIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.COLUMN_TOP_ATTACH_JUSTIFICATION_PARAM: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_PARAM_SHININESS: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_PARAM_SMOOTHNESS: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_PARAM_GLOW: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_PARAM_TRANSPARENCY: return StorageType.Integer;
                case BuiltInParameter.MATERIAL_PARAM_COLOR: return StorageType.Integer;
                case BuiltInParameter.SEEK_ITEM_ID: return StorageType.String;
                case BuiltInParameter.OMNICLASS_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.OMNICLASS_CODE: return StorageType.String;
                case BuiltInParameter.UNIFORMAT_DESCRIPTION: return StorageType.String;
                case BuiltInParameter.UNIFORMAT_CODE: return StorageType.String;
                case BuiltInParameter.SLOPE_END_HEIGHT: return StorageType.Double;
                case BuiltInParameter.SLOPE_START_HEIGHT: return StorageType.Double;
                case BuiltInParameter.CEILING_HAS_THICKNESS_PARAM: return StorageType.Integer;
                case BuiltInParameter.CEILING_THICKNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM: return StorageType.Double;
                case BuiltInParameter.CEILING_THICKNESS: return StorageType.Double;
                case BuiltInParameter.CEILING_ATTR_SYSTEMNAME_PARAM: return StorageType.String;
                case BuiltInParameter.CEILING_ATTR_SPACING2_PARAM: return StorageType.Double;
                case BuiltInParameter.CEILING_ATTR_SPACING1_PARAM: return StorageType.Double;
                case BuiltInParameter.CEILING_ATTR_PATTERN_PARAM: return StorageType.Integer;
                case BuiltInParameter.CEILING_ATTR_DEFAULT_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.FILLED_REGION_MASKING: return StorageType.Integer;
                case BuiltInParameter.BACKGROUND_PATTERN_COLOR_PARAM: return StorageType.Integer;
                case BuiltInParameter.FOREGROUND_PATTERN_COLOR_PARAM: return StorageType.Integer;
                case BuiltInParameter.BACKGROUND_DRAFT_PATTERN_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FOREGROUND_ANY_PATTERN_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FOREGROUND_DRAFT_PATTERN_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.BUILIDING_PAD_STRUCTURE_ID_PARAM: return StorageType.None;
                case BuiltInParameter.CEILING_STRUCTURE_ID_PARAM: return StorageType.None;
                case BuiltInParameter.ROOF_STRUCTURE_ID_PARAM: return StorageType.None;
                case BuiltInParameter.FLOOR_STRUCTURE_ID_PARAM: return StorageType.None;
                case BuiltInParameter.ANY_PATTERN_ID_PARAM_NO_NO: return StorageType.ElementId;
                case BuiltInParameter.FILL_PATTERN_ID_PARAM_NO_NO: return StorageType.ElementId;
                case BuiltInParameter.OBJECT_STYLE_MATERIAL_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.WRAPPING_AT_INSERTS_PARAM: return StorageType.Integer;
                case BuiltInParameter.WRAPPING_AT_ENDS_PARAM: return StorageType.Integer;
                case BuiltInParameter.COARSE_SCALE_FILL_PATTERN_COLOR: return StorageType.Integer;
                case BuiltInParameter.MODEL_CATEGORY_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.HOST_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.MATERIAL_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.COARSE_SCALE_FILL_PATTERN_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ANY_PATTERN_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.WALL_STRUCTURE_ID_PARAM: return StorageType.None;
                case BuiltInParameter.SURFACE_PATTERN_ID_PARAM: return StorageType.None;
                case BuiltInParameter.FILL_PATTERN_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.EDITED_BY: return StorageType.String;
                case BuiltInParameter.SCHEDULE_TOP_LEVEL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.SCHEDULE_BASE_LEVEL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.SCHEDULE_TOP_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SCHEDULE_BASE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.SCHEDULE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ELEM_ROOM_ID: return StorageType.ElementId;
                case BuiltInParameter.ELEM_ROOM_NAME: return StorageType.String;
                case BuiltInParameter.ELEM_ROOM_NUMBER: return StorageType.String;
                case BuiltInParameter.ELEM_PARTITION_PARAM: return StorageType.Integer;
                case BuiltInParameter.ELEM_FAMILY_AND_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ELEM_FAMILY_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ELEM_TYPE_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ELEM_TYPE_LABEL: return StorageType.ElementId;
                case BuiltInParameter.BR_ORG_FILTER: return StorageType.None;
                case BuiltInParameter.BR_ORG_FOLDERS: return StorageType.None;
                case BuiltInParameter.SYMBOL_FAMILY_AND_TYPE_NAMES_PARAM: return StorageType.String;
                case BuiltInParameter.SYMBOL_FAMILY_NAME_PARAM: return StorageType.String;
                case BuiltInParameter.SYMBOL_NAME_PARAM: return StorageType.String;
                case BuiltInParameter.SYMBOL_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_DISPLAY_IN_HIDDEN_VIEWS: return StorageType.Integer;
                case BuiltInParameter.FLOOR_PARAM_SPAN_DIRECTION: return StorageType.Double;
                case BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL: return StorageType.Integer;
                case BuiltInParameter.HOST_PERIMETER_COMPUTED: return StorageType.Double;
                case BuiltInParameter.LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM: return StorageType.Double;
                case BuiltInParameter.FLOOR_ATTR_DEFAULT_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.FLOOR_ATTR_DEFAULT_THICKNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.PROFILE_PARAM_ALONG_PATH: return StorageType.Double;
                case BuiltInParameter.PROFILE_FAM_TYPE_PLUS_NONE: return StorageType.ElementId;
                case BuiltInParameter.PROFILE2_ANGLE: return StorageType.Double;
                case BuiltInParameter.PROFILE2_FAM_TYPE: return StorageType.ElementId;
                case BuiltInParameter.PROFILE2_FLIPPED_HOR: return StorageType.Integer;
                case BuiltInParameter.PROFILE2_OFFSET_Y: return StorageType.Double;
                case BuiltInParameter.PROFILE2_OFFSET_X: return StorageType.Double;
                case BuiltInParameter.PROFILE1_ANGLE: return StorageType.Double;
                case BuiltInParameter.PROFILE1_FAM_TYPE: return StorageType.ElementId;
                case BuiltInParameter.PROFILE1_FLIPPED_HOR: return StorageType.Integer;
                case BuiltInParameter.PROFILE1_OFFSET_Y: return StorageType.Double;
                case BuiltInParameter.PROFILE1_OFFSET_X: return StorageType.Double;
                case BuiltInParameter.FAM_PROFILE_USAGE: return StorageType.Integer;
                case BuiltInParameter.SWEEP_TRAJ_SEGMENTED: return StorageType.Integer;
                case BuiltInParameter.SWEEP_MAX_SEG_ANGLE: return StorageType.Double;
                case BuiltInParameter.MODEL_OR_SYMBOLIC: return StorageType.Integer;
                case BuiltInParameter.PROFILE_ANGLE: return StorageType.Double;
                case BuiltInParameter.PROFILE_FAM_TYPE: return StorageType.ElementId;
                case BuiltInParameter.PROFILE_FLIPPED_HOR: return StorageType.Integer;
                case BuiltInParameter.PROFILE_OFFSET_Y: return StorageType.Double;
                case BuiltInParameter.PROFILE_OFFSET_X: return StorageType.Double;
                case BuiltInParameter.EXTRUSION_LENGTH: return StorageType.Double;
                case BuiltInParameter.CURVE_VISIBILITY_PARAM: return StorageType.Integer;
                case BuiltInParameter.GEOM_VISIBILITY_PARAM: return StorageType.Integer;
                case BuiltInParameter.ELEMENT_IS_CUTTING: return StorageType.Integer;
                case BuiltInParameter.EXTRUSION_AUTO_PARAMS: return StorageType.Integer;
                case BuiltInParameter.BLEND_END_PARAM: return StorageType.Double;
                case BuiltInParameter.BLEND_START_PARAM: return StorageType.Double;
                case BuiltInParameter.REVOLUTION_END_ANGLE: return StorageType.Double;
                case BuiltInParameter.REVOLUTION_START_ANGLE: return StorageType.Double;
                case BuiltInParameter.EXTRUSION_END_PARAM: return StorageType.Double;
                case BuiltInParameter.EXTRUSION_START_PARAM: return StorageType.Double;
                case BuiltInParameter.SCHEDULE_TYPE_FOR_BROWSER: return StorageType.Integer;
                case BuiltInParameter.SCHEDULE_CATEGORY: return StorageType.ElementId;
                case BuiltInParameter.FACEROOF_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.FACEROOF_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ROOF_FACES_LOCATION: return StorageType.Integer;
                case BuiltInParameter.RELATED_TO_MASS: return StorageType.Integer;
                case BuiltInParameter.FASCIA_DEPTH_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOF_EAVE_CUT_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOF_RAFTER_OR_TRUSS_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOF_BASE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.CURVE_WALL_OFFSET_ROOFS: return StorageType.Double;
                case BuiltInParameter.CURVE_WALL_OFFSET: return StorageType.Double;
                case BuiltInParameter.ACTUAL_MAX_RIDGE_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOF_UPTO_LEVEL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOF_UPTO_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.ROOF_LEVEL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM_SURVEY: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP_SURVEY: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_FLOOR_CORE_THICKNESS: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM_CORE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP_CORE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_REFERENCE_LEVEL_ELEVATION: return StorageType.Double;
                case BuiltInParameter.ROOF_CONSTRAINT_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOF_CONSTRAINT_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.HOST_SSE_CURVED_EDGE_CONDITION_PARAM: return StorageType.Integer;
                case BuiltInParameter.ROOF_ATTR_THICKNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.ROOF_ATTR_DEFAULT_THICKNESS_PARAM: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP: return StorageType.Double;
                case BuiltInParameter.NODE_CONNECTION_STATUS: return StorageType.Integer;
                case BuiltInParameter.WALL_STRUCTURAL_SIGNIFICANT: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_BEAM_RIGID_LINK: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_COLUMN_HORIZONTAL_PROJECTION_PLANE:
                    return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_BEAM_HORIZONTAL_PROJECTION_PLANE:
                    return StorageType.ElementId;
                case BuiltInParameter.CONTINUOUS_FOOTING_BREAK_AT_INSERTS_DISABLE: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUS_FOOTING_DEFAULT_END_EXTENSION_LENGTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_TESSELLATE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_TESS_DEVIATION: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_HARD_POINTS: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEND_DIR_ANGLE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_DISPLAY_IN_HIDDEN_VIEWS_COLUMN: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_DISPLAY_IN_HIDDEN_VIEWS_FRAMING: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_FLOOR_ANALYZES_AS: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ANALYZES_AS: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_CUTBACK_FOR_COLUMN: return StorageType.Integer;
                case BuiltInParameter.BEAM_V_JUSTIFICATION_OTHER_VALUE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_BEAM_ORIENTATION: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION: return StorageType.Double;
                case BuiltInParameter.FAMILY_EXPORT_AS_GEOMETRY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_FOUNDATION_LENGTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_FOUNDATION_WIDTH: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_LENGTH: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_ECCENTRICITY: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_STRUCTURAL_USAGE: return StorageType.Integer;
                case BuiltInParameter.CONTINUOUS_FOOTING_BEARING_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ELEVATION_AT_BOTTOM: return StorageType.Double;
                case BuiltInParameter.FAMILY_STRUCT_FOOTING_USE_CAP_TOP: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_COPING_DISTANCE: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_WIDTH: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_FOUNDATION_THICKNESS: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_BOTTOM_HEEL: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_TOP_HEEL: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_BOTTOM_TOE: return StorageType.Double;
                case BuiltInParameter.CONTINUOUS_FOOTING_TOP_TOE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_MODEL: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_COLUMN_RIGID_LINK: return StorageType.Integer;
                case BuiltInParameter.FAMILY_STRUCT_MATERIAL_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_MX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_FX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_MZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_MY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_MX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_FZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_FY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_FX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BOTTOM_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_TOP_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_PROJECT_MEMBER_PLANE_COLUMN_BOTTOM:
                    return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_PROJECT_MEMBER_PLANE_COLUMN_TOP:
                    return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_MATERIAL_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_CAMBER: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_NUMBER_OF_STUDS: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_MZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_MY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_MX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_FZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_FY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_FX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_MZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_MY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_MX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_FZ: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_FY: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_FX: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_END_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_START_RELEASE_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_WALL_BOTTOM_PROJECTION_PLANE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_WALL_TOP_PROJECTION_PLANE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_WALL_PROJECTION_SURFACE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_PROJECT_FLOOR_PLANE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_ANALYTICAL_PROJECT_MEMBER_PLANE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_BRACE_REPRESENTATION: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_STICK_SYMBOL_LOCATION: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_END_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_BEAM_START_SUPPORT: return StorageType.Integer;
                case BuiltInParameter.WINDOW_TYPE_ID: return StorageType.String;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_END_VALUE_ELEVATION: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_START_VALUE_ELEVATION: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_END_LEVEL_REFERENCE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_START_LEVEL_REFERENCE: return StorageType.ElementId;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_END_VALUE_RATIO: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_START_VALUE_RATIO: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_END_REFELEMENT_END: return StorageType.Integer;
                case BuiltInParameter.TYPE_WALL_CLOSURE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_START_REFELEMENT_END: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_END_VALUE_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_START_VALUE_DISTANCE: return StorageType.Double;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_END_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_ATTACHMENT_START_TYPE: return StorageType.Integer;
                case BuiltInParameter.STRUCTURAL_FRAME_CUT_LENGTH: return StorageType.Double;
                case BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.INSTANCE_STRUCT_USAGE_PARAM: return StorageType.Integer;
                case BuiltInParameter.SKETCH_PLANE_PARAM: return StorageType.String;
                case BuiltInParameter.INSTANCE_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.INSTANCE_MOVES_WITH_GRID_PARAM: return StorageType.Integer;
                case BuiltInParameter.INSTANCE_OFFSET_POS_PARAM: return StorageType.Integer;
                case BuiltInParameter.INSTANCE_SCHEDULE_ONLY_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.INSTANCE_FREE_HOST_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.INSTANCE_FREE_HOST_PARAM: return StorageType.String;
                case BuiltInParameter.INSTANCE_HEAD_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.INSTANCE_SILL_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.INSTANCE_ELEVATION_PARAM: return StorageType.Double;
                case BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.FAMILY_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_TOP_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_BASE_LEVEL_PARAM: return StorageType.ElementId;
                case BuiltInParameter.FAMILY_RFA_PATH_PSEUDO_PARAM: return StorageType.String;
                case BuiltInParameter.FAMILY_CATEGORY_PSEUDO_PARAM: return StorageType.String;
                case BuiltInParameter.FAMILY_NAME_PSEUDO_PARAM: return StorageType.String;
                case BuiltInParameter.FAMILY_USAGE_PSEUDO_PARAM: return StorageType.String;
                case BuiltInParameter.FAMILY_WPB_DEFAULT_ELEVATION: return StorageType.Double;
                case BuiltInParameter.FAMILY_LINE_LENGTH_PARAM: return StorageType.Double;
                case BuiltInParameter.FAMILY_ROUGH_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.FAMILY_ROUGH_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.FAMILY_WINDOW_INSET_PARAM: return StorageType.Double;
                case BuiltInParameter.WINDOW_THICKNESS: return StorageType.Double;
                case BuiltInParameter.FURNITURE_WIDTH: return StorageType.Double;
                case BuiltInParameter.FAMILY_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.DOOR_EVACUATION_EXIT_TYPE: return StorageType.Integer;
                case BuiltInParameter.WINDOW_OPERATION_TYPE: return StorageType.String;
                case BuiltInParameter.DOOR_FRAME_MATERIAL: return StorageType.String;
                case BuiltInParameter.DOOR_FRAME_TYPE: return StorageType.String;
                case BuiltInParameter.GENERIC_FINISH: return StorageType.String;
                case BuiltInParameter.WINDOW_CONSTRUCTION_TYPE: return StorageType.String;
                case BuiltInParameter.FIRE_RATING: return StorageType.String;
                case BuiltInParameter.DOOR_COST: return StorageType.Double;
                case BuiltInParameter.DOOR_NUMBER: return StorageType.String;
                case BuiltInParameter.DPART_ORIGINAL_CATEGORY_ID: return StorageType.ElementId;
                case BuiltInParameter.DPART_LAYER_CONSTRUCTION: return StorageType.String;
                case BuiltInParameter.DPART_PHASE_DEMOLISHED_BY_ORIGINAL: return StorageType.Integer;
                case BuiltInParameter.DPART_PHASE_CREATED_BY_ORIGINAL: return StorageType.Integer;
                case BuiltInParameter.DPART_LENGTH_COMPUTED: return StorageType.Double;
                case BuiltInParameter.DPART_HEIGHT_COMPUTED: return StorageType.Double;
                case BuiltInParameter.DPART_LAYER_WIDTH: return StorageType.Double;
                case BuiltInParameter.DPART_AREA_COMPUTED: return StorageType.Double;
                case BuiltInParameter.DPART_ORIGINAL_TYPE: return StorageType.String;
                case BuiltInParameter.OFFSETFACES_SHOW_SHAPE_HANDLES: return StorageType.Integer;
                case BuiltInParameter.DPART_LAYER_FUNCTION: return StorageType.String;
                case BuiltInParameter.DPART_VOLUME_COMPUTED: return StorageType.Double;
                case BuiltInParameter.DPART_MATERIAL_BY_ORIGINAL: return StorageType.Integer;
                case BuiltInParameter.DPART_MATERIAL_ID_PARAM: return StorageType.ElementId;
                case BuiltInParameter.DPART_ORIGINAL_FAMILY: return StorageType.String;
                case BuiltInParameter.DPART_ORIGINAL_CATEGORY: return StorageType.String;
                case BuiltInParameter.HOST_PANEL_SCHEDULE_AS_PANEL_PARAM: return StorageType.Integer;
                case BuiltInParameter.WALL_LOCATION_LINE_OFFSET_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_KEY_REF_PARAM: return StorageType.Integer;
                case BuiltInParameter.MEASURE_FROM_STRUCTURE: return StorageType.Integer;
                case BuiltInParameter.WALL_STRUCTURAL_USAGE_PARAM: return StorageType.Integer;
                case BuiltInParameter.WALL_BOTTOM_IS_ATTACHED: return StorageType.Integer;
                case BuiltInParameter.WALL_TOP_IS_ATTACHED: return StorageType.Integer;
                case BuiltInParameter.WALL_TOP_OFFSET: return StorageType.Double;
                case BuiltInParameter.WALL_BASE_OFFSET: return StorageType.Double;
                case BuiltInParameter.WALL_BASE_CONSTRAINT: return StorageType.ElementId;
                case BuiltInParameter.WALL_USER_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_HEIGHT_TYPE: return StorageType.ElementId;
                case BuiltInParameter.WALL_BASE_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.ALLOW_AUTO_EMBED: return StorageType.Integer;
                case BuiltInParameter.WALL_ATTR_ROOM_BOUNDING: return StorageType.Integer;
                case BuiltInParameter.FUNCTION_PARAM: return StorageType.Integer;
                case BuiltInParameter.WALL_ATTR_DEFHEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_ATTR_HEIGHT_PARAM: return StorageType.Double;
                case BuiltInParameter.WALL_ATTR_WIDTH_PARAM: return StorageType.Double;
                case BuiltInParameter.INVALID: return StorageType.None;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

#if D2020 || R2020 || D2021 || R2021
        /// <summary>
        /// Возвращает тип параметра.
        /// </summary>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает тип параметра.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Выбрасывает исключение если не был сопоставлен тип данных к параметру.</exception>
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
                    throw new System.ArgumentOutOfRangeException();
            }
        }

#else
        /// <summary>
        /// Возвращает тип параметра.
        /// </summary>
        /// <param name="forgeTypeId">Системный тип параметра.</param>
        /// <returns>Возвращает тип параметра.</returns>
        public static StorageType GetStorageType(this ForgeTypeId forgeTypeId) {
            if(forgeTypeId == null) {
                throw new ArgumentNullException(nameof(forgeTypeId));
            }

            return forgeTypeId.GetStorageType();
        }

        /// <summary>
        /// Возвращает тип параметра.
        /// </summary>
        /// <param name="definition">Определение параметра.</param>
        /// <returns>Возвращает тип параметра.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Выбрасывает исключение если не был сопоставлен тип данных к параметру.</exception>
        public static StorageType GetStorageType(this Definition definition) {
            if(definition == null) {
                throw new ArgumentNullException(nameof(definition));
            }


            ForgeTypeId dataType = definition.GetDataType();
            if(dataType == SpecTypeId.Acceleration) { return StorageType.Double; }

            if(dataType == SpecTypeId.AirFlow) { return StorageType.Double; }

            if(dataType == SpecTypeId.AirFlowDensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.AirFlowDividedByCoolingLoad) { return StorageType.Double; }

            if(dataType == SpecTypeId.AirFlowDividedByVolume) { return StorageType.Double; }

            if(dataType == SpecTypeId.Angle) { return StorageType.Double; }

            if(dataType == SpecTypeId.AngularSpeed) { return StorageType.Double; }

            if(dataType == SpecTypeId.ApparentPower) { return StorageType.Double; }

            if(dataType == SpecTypeId.Area) { return StorageType.Double; }

            if(dataType == SpecTypeId.AreaDividedByCoolingLoad) { return StorageType.Double; }

            if(dataType == SpecTypeId.AreaDividedByHeatingLoad) { return StorageType.Double; }

            if(dataType == SpecTypeId.AreaForce) { return StorageType.Double; }

            if(dataType == SpecTypeId.AreaForceScale) { return StorageType.Double; }

            if(dataType == SpecTypeId.AreaSpringCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.BarDiameter) { return StorageType.Double; }

            if(dataType == SpecTypeId.CableTraySize) { return StorageType.Double; }

            if(dataType == SpecTypeId.ColorTemperature) { return StorageType.Double; }

            if(dataType == SpecTypeId.ConduitSize) { return StorageType.Double; }

            if(dataType == SpecTypeId.CoolingLoad) { return StorageType.Double; }

            if(dataType == SpecTypeId.CoolingLoadDividedByArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.CoolingLoadDividedByVolume) { return StorageType.Double; }

            if(dataType == SpecTypeId.CostPerArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.CostRateEnergy) { return StorageType.Double; }

            if(dataType == SpecTypeId.CostRatePower) { return StorageType.Double; }

            if(dataType == SpecTypeId.CrackWidth) { return StorageType.Double; }

            if(dataType == SpecTypeId.CrossSection) { return StorageType.Double; }

            if(dataType == SpecTypeId.Currency) { return StorageType.Double; }

            if(dataType == SpecTypeId.Current) { return StorageType.Double; }

            if(dataType == SpecTypeId.DecimalSheetLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.DemandFactor) { return StorageType.Double; }

            if(dataType == SpecTypeId.Diffusivity) { return StorageType.Double; }

            if(dataType == SpecTypeId.Displacement) { return StorageType.Double; }

            if(dataType == SpecTypeId.Distance) { return StorageType.Double; }

            if(dataType == SpecTypeId.DuctInsulationThickness) { return StorageType.Double; }

            if(dataType == SpecTypeId.DuctLiningThickness) { return StorageType.Double; }

            if(dataType == SpecTypeId.DuctSize) { return StorageType.Double; }

            if(dataType == SpecTypeId.Efficacy) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalFrequency) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalPotential) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalPower) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalPowerDensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalResistivity) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalTemperature) { return StorageType.Double; }

            if(dataType == SpecTypeId.ElectricalTemperatureDifference) { return StorageType.Double; }

            if(dataType == SpecTypeId.Energy) { return StorageType.Double; }

            if(dataType == SpecTypeId.Factor) { return StorageType.Double; }

            if(dataType == SpecTypeId.Flow) { return StorageType.Double; }

            if(dataType == SpecTypeId.FlowPerPower) { return StorageType.Double; }

            if(dataType == SpecTypeId.Force) { return StorageType.Double; }

            if(dataType == SpecTypeId.ForceScale) { return StorageType.Double; }

            if(dataType == SpecTypeId.HeatCapacityPerArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.HeatGain) { return StorageType.Double; }

            if(dataType == SpecTypeId.HeatTransferCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.HeatingLoad) { return StorageType.Double; }

            if(dataType == SpecTypeId.HeatingLoadDividedByArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.HeatingLoadDividedByVolume) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacDensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacEnergy) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacFriction) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacMassPerTime) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacPower) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacPowerDensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacPressure) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacRoughness) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacSlope) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacTemperature) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacTemperatureDifference) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacVelocity) { return StorageType.Double; }

            if(dataType == SpecTypeId.HvacViscosity) { return StorageType.Double; }

            if(dataType == SpecTypeId.Illuminance) { return StorageType.Double; }

            if(dataType == SpecTypeId.Reference.Image) { return StorageType.ElementId; }

            if(dataType == SpecTypeId.Int.Integer) { return StorageType.Integer; }

            if(dataType == SpecTypeId.IsothermalMoistureCapacity) { return StorageType.Double; }

            if(dataType == SpecTypeId.Length) { return StorageType.Double; }

            if(dataType == SpecTypeId.LineSpringCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.LinearForce) { return StorageType.Double; }

            if(dataType == SpecTypeId.LinearForceScale) { return StorageType.Double; }

            if(dataType == SpecTypeId.LinearMoment) { return StorageType.Double; }

            if(dataType == SpecTypeId.LinearMomentScale) { return StorageType.Double; }

            if(dataType == SpecTypeId.Reference.LoadClassification) { return StorageType.ElementId; }

            if(dataType == SpecTypeId.Luminance) { return StorageType.Double; }

            if(dataType == SpecTypeId.LuminousFlux) { return StorageType.Double; }

            if(dataType == SpecTypeId.LuminousIntensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.Mass) { return StorageType.Double; }

            if(dataType == SpecTypeId.MassDensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.MassPerUnitArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.MassPerUnitLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.Reference.Material) { return StorageType.ElementId; }

            if(dataType == SpecTypeId.Moment) { return StorageType.Double; }

            if(dataType == SpecTypeId.MomentOfInertia) { return StorageType.Double; }

            if(dataType == SpecTypeId.MomentScale) { return StorageType.Double; }

            if(dataType == SpecTypeId.String.MultilineText) { return StorageType.String; }

            if(dataType == SpecTypeId.Number) { return StorageType.Double; }

            if(dataType == SpecTypeId.Int.NumberOfPoles) { return StorageType.Integer; }

            if(dataType == SpecTypeId.Period) { return StorageType.Double; }

            if(dataType == SpecTypeId.Permeability) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipeDimension) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipeInsulationThickness) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipeMassPerUnitLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipeSize) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingDensity) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingFriction) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingMass) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingMassPerTime) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingPressure) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingRoughness) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingSlope) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingTemperature) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingTemperatureDifference) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingVelocity) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingViscosity) { return StorageType.Double; }

            if(dataType == SpecTypeId.PipingVolume) { return StorageType.Double; }

            if(dataType == SpecTypeId.PointSpringCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.PowerPerFlow) { return StorageType.Double; }

            if(dataType == SpecTypeId.PowerPerLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.Pulsation) { return StorageType.Double; }

            if(dataType == SpecTypeId.ReinforcementArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.ReinforcementAreaPerUnitLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.ReinforcementCover) { return StorageType.Double; }

            if(dataType == SpecTypeId.ReinforcementLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.ReinforcementSpacing) { return StorageType.Double; }

            if(dataType == SpecTypeId.ReinforcementVolume) { return StorageType.Double; }

            if(dataType == SpecTypeId.Rotation) { return StorageType.Double; }

            if(dataType == SpecTypeId.RotationAngle) { return StorageType.Double; }

            if(dataType == SpecTypeId.RotationalLineSpringCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.RotationalPointSpringCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.SectionArea) { return StorageType.Double; }

            if(dataType == SpecTypeId.SectionDimension) { return StorageType.Double; }

            if(dataType == SpecTypeId.SectionModulus) { return StorageType.Double; }

            if(dataType == SpecTypeId.SectionProperty) { return StorageType.Double; }

            if(dataType == SpecTypeId.SheetLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.SiteAngle) { return StorageType.Double; }

            if(dataType == SpecTypeId.Slope) { return StorageType.Double; }

            if(dataType == SpecTypeId.SpecificHeat) { return StorageType.Double; }

            if(dataType == SpecTypeId.SpecificHeatOfVaporization) { return StorageType.Double; }

            if(dataType == SpecTypeId.Speed) { return StorageType.Double; }

            if(dataType == SpecTypeId.Stationing) { return StorageType.Double; }

            if(dataType == SpecTypeId.StationingInterval) { return StorageType.Double; }

            if(dataType == SpecTypeId.Stress) { return StorageType.Double; }

            if(dataType == SpecTypeId.StructuralFrequency) { return StorageType.Double; }

            if(dataType == SpecTypeId.StructuralVelocity) { return StorageType.Double; }

            if(dataType == SpecTypeId.SurfaceAreaPerUnitLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.String.Text) { return StorageType.String; }

            if(dataType == SpecTypeId.ThermalConductivity) { return StorageType.Double; }

            if(dataType == SpecTypeId.ThermalExpansionCoefficient) { return StorageType.Double; }

            if(dataType == SpecTypeId.ThermalGradientCoefficientForMoistureCapacity) { return StorageType.Double; }

            if(dataType == SpecTypeId.ThermalMass) { return StorageType.Double; }

            if(dataType == SpecTypeId.ThermalResistance) { return StorageType.Double; }

            if(dataType == SpecTypeId.Time) { return StorageType.Double; }

            if(dataType == SpecTypeId.UnitWeight) { return StorageType.Double; }

            if(dataType == SpecTypeId.String.Url) { return StorageType.String; }

            if(dataType == SpecTypeId.Volume) { return StorageType.Double; }

            if(dataType == SpecTypeId.WarpingConstant) { return StorageType.Double; }

            if(dataType == SpecTypeId.Wattage) { return StorageType.Double; }

            if(dataType == SpecTypeId.Weight) { return StorageType.Double; }

            if(dataType == SpecTypeId.WeightPerUnitLength) { return StorageType.Double; }

            if(dataType == SpecTypeId.WireDiameter) { return StorageType.Double; }

            if(dataType == SpecTypeId.Boolean.YesNo) { return StorageType.Integer; }

            throw new System.ArgumentOutOfRangeException();
        }

#endif
    }
}