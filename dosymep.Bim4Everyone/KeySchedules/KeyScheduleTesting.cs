using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

using dosymep.Revit;

namespace dosymep.Bim4Everyone.KeySchedules {
    /// <summary>
    /// Класс для проверок ключевой спецификации.
    /// </summary>
    public class KeyScheduleTesting {
        /// <summary>
        /// Проверяемая спецификация.
        /// </summary>
        private readonly ViewSchedule _testingSchedule;

        /// <summary>
        /// Правила проверок ключевой спецификации. 
        /// </summary>
        private readonly KeyScheduleRuleInternal _keyScheduleRule;

        /// <summary>
        /// Создает экземпляр класс проверок ключевой спецификации.
        /// </summary>
        /// <param name="testingSchedule">Проверяемая спецификация.</param>
        /// <param name="keyScheduleRule">Правила проверок ключевой спецификации.</param>
        internal KeyScheduleTesting(ViewSchedule testingSchedule, KeyScheduleRuleInternal keyScheduleRule) {
            _testingSchedule = testingSchedule ?? throw new ArgumentNullException(nameof(testingSchedule));
            _keyScheduleRule = keyScheduleRule ?? throw new ArgumentNullException(nameof(keyScheduleRule));
        }

        /// <summary>
        /// Проверяемая спецификация.
        /// </summary>
        public ViewSchedule TestingSchedule {
            get { return _testingSchedule; }
        }

        /// <summary>
        /// Проверяет, является ли спецификация ключевой.
        /// </summary>
        /// <returns>Возвращает true - если спецификация является ключевой, иначе false.</returns>
        public bool IsKeySchedule() {
            try {
                return !string.IsNullOrEmpty(_testingSchedule.KeyScheduleParameterName);
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на заполненность элементами передаваемую спецификацию.
        /// </summary>
        /// <returns>Возвращает true - если в спецификации есть элементы, иначе false</returns>
        public bool IsEmptySchedule() {
            return !GetScheduleElements().Any();
        }

        /// <summary>
        /// Проверяет совпадает ли наименование ключевого параметра спецификации.
        /// </summary>
        /// <returns>Возвращает true - если наименования ключевого параметра совпадают с конфигурацией, иначе false.</returns>
        public bool IsCorrectKeyRevitParam() {
            if(IsKeySchedule()) {
                return _testingSchedule.KeyScheduleParameterName.Equals(_keyScheduleRule.KeyRevitParam.Name);
            }

            return false;
        }

        /// <summary>
        /// Возвращает перечисление параметров, которые не были созданы в проекте.
        /// </summary>
        /// <returns>Возвращает перечисление параметров, которые не были созданы в проекте.</returns>
        public IEnumerable<RevitParam> GetNotExistsRequiredParamsInProject() {
            CheckKeySchedule();

            foreach(RevitParam requiredParam in _keyScheduleRule.RequiredParams) {
                if(!_testingSchedule.Document.IsExistsParam(requiredParam)) {
                    yield return requiredParam;
                }
            }
        }

        /// <summary>
        /// Возвращает перечисление обязательных параметров, которые не были созданы в ключевой спецификации.
        /// </summary>
        /// <returns>Возвращает перечисление обязательных параметров, которые не были созданы в ключевой спецификации.</returns>
        public IEnumerable<RevitParam> GetNotExistsRequiredParamsInSchedule() {
            CheckKeySchedule();

            var definition = _testingSchedule.Definition;
            string[] paramNames = Enumerable.Range(0, definition.GetFieldCount())
                .Select(item => definition.GetField(item))
                .Select(item => item.GetName())
                .ToArray();

            return _keyScheduleRule.RequiredParams.Where(item => !paramNames.Contains(item.Name));
        }

        /// <summary>
        /// Возвращает перечисление не заполнены параметров, которые не были заполнены в ключевой спецификации.
        /// </summary>
        /// <returns>Возвращает перечисление не заполнены параметров, которые не были заполнены в ключевой спецификации.</returns>
        public IEnumerable<RevitParam> GetNotFilledParamsInSchedule() {
            CheckKeySchedule();

            Element[] scheduleElements = GetScheduleElements().ToArray();
            foreach(Element element in scheduleElements) {
#if D2020 || R2020 || D2021 || R2021
                if(!element.IsExistsParam(BuiltInParameter.REF_TABLE_ELEM_NAME)) {
#else
                if(!element.IsExistsParam(ParameterTypeId.RefTableElemName)) {
#endif
                    yield return _keyScheduleRule.KeyRevitParam;
                    break;
                }
            }

            foreach(RevitParam filledParam in _keyScheduleRule.FilledParams) {
                foreach(Element element in scheduleElements) {
                    if(!element.IsExistsParam(filledParam)) {
                        yield return filledParam;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Проверяет спецификацию на корректность.
        /// </summary>
        private void CheckKeySchedule() {
            if(!IsKeySchedule()) {
                throw new InvalidOperationException($"Спецификация \"{_testingSchedule.Name}\" не является ключевой.");
            }

            if(IsEmptySchedule()) {
                throw new InvalidOperationException($"Спецификация \"{_testingSchedule.Name}\" не содержит элементов.");
            }
        }

        /// <summary>
        /// Возвращает список элементов спецификации.
        /// </summary>
        /// <returns>Возвращает список элементов спецификации.</returns>
        private IEnumerable<Element> GetScheduleElements() {
            return new FilteredElementCollector(_testingSchedule.Document, _testingSchedule.Id)
                .WhereElementIsNotElementType();
        }
    }
}
