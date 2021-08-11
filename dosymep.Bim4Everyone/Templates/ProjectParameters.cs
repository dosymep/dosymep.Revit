using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

using dosymep.Revit;

namespace dosymep.Bim4Everyone.Templates {
    /// <summary>
    /// Класс по копирование параметров проекта.
    /// </summary>
    public class ProjectParameters {
        /// <summary>
        /// Создает экземпляр класса параметров проекта.
        /// </summary>
        /// <param name="application">Приложение Revit.</param>
        /// <returns>Возвращает экземпляр класса параметров проекта.</returns>
        public static ProjectParameters Create(Application application) {
            if(application is null) {
                throw new ArgumentNullException(nameof(application));
            }

            return new ProjectParameters() { Application = application };
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        internal ProjectParameters() { }

        /// <summary>
        /// Приложение Revit.
        /// </summary>
        public Application Application { get; private set; }


        /// <summary>
        /// Настраивает атрибуты нумерации листов.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить атрибуты нумерации листов.</param>
        /// <remarks>Метод открывает транзакцию при настройке атрибутов нумерации листов.</remarks>
        public void SetupNumerateSheets(Document target) {
            if(Application == null) {
                throw new InvalidOperationException($"Перед настройкой атрибутов нумерации листов нужно инициализировать свойство \"{nameof(Application)}\".");
            }

            if(target.IsExistsParam("Ш.НомерЛиста")
                && target.IsExistsParam("ADSK_Комплект чертежей")) {

                return;
            }

            int viewId = 305989;

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start($"Настройка атрибутов нумерации листов");

                    CopyView(target, source, viewId);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }


        /// <summary>
        /// Настраивает атрибуты нумерации видов на листе.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить атрибуты нумерации видов на листах.</param>
        /// <remarks>Метод открывает транзакцию при настройки нумерации видов на листе.</remarks>
        public void SetupNumerateViewsOnSheet(Document target) {
            if(Application == null) {
                throw new InvalidOperationException($"Перед настройкой атрибутов нумерации видов на листе нужно инициализировать свойство \"{nameof(Application)}\".");
            }

            if(target.IsExistsParam("_Номер Вида на Листе")
                && target.IsExistsParam("_Полный Номер Листа")
                && target.IsExistsParam("_Без Номера Листа")) {

                return;
            }

            int viewId = 305687;

            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start($"Настройка нумерации видов на листе");

                    CopyView(target, source, viewId);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        /// <summary>
        /// Настраивает диспетчер видов.
        /// </summary>
        /// <param name="target">Документ, в котором требуется настроить диспетчер видов.</param>
        /// <remarks>Метод открывает транзакцию при настройке диспетчера видов.</remarks>
        public void SetupBrowserOrganization(Document target) {
            if(Application == null) {
                throw new InvalidOperationException($"Перед настройкой диспетчера видов нужно инициализировать свойство \"{nameof(Application)}\".");
            }

            if(target.IsExistsParam("_Группа Видов")
                && target.IsExistsParam("_Стадия Проекта")
                && target.IsExistsParam("_Номер Вида на Листе")) {

                return;
            }

            int viewId = 304320;
            
            Document source = Application.OpenDocumentFile(ModuleEnvironment.ParametersTemplatePath);
            try {
                using(var transaction = new Transaction(target)) {
                    transaction.Start($"Настройка диспетчера видов");

                    CopyView(target, source, viewId);
                    CopyBrowserOrganization(target, source);

                    transaction.Commit();
                }
            } finally {
                source.Close(false);
            }
        }

        private static void CopyView(Document target, Document document, int viewId) {
            ICollection<ElementId> copiedElements = ElementTransformUtils.CopyElements(document, new[] { new ElementId(viewId) }, target, Transform.Identity, new CopyPasteOptions());

            // Удаляем скопированный вид,
            // так как он нужен был для переноса параметра
            target.Delete(copiedElements);
        }

        private static void CopyBrowserOrganization(Document target, Document document) {
            var elements = new FilteredElementCollector(document).OfClass(typeof(BrowserOrganization)).ToElements();

            // Получаем только те элементы,
            // у которых совпадает имя с копируемыми настройками диспетчера видов
            var removingElements = new FilteredElementCollector(target)
                .OfClass(typeof(BrowserOrganization))
                .Where(targetItem => elements.Any(item => item.Name.Equals(targetItem.Name)))
                .Select(item => item.Id)
                .ToArray();

            // Сначала копируем, после удаляем,
            // потому что невозможно удалить все настройки диспетчера видов
            ElementTransformUtils.CopyElements(document, elements.Select(item => item.Id).ToArray(), target, Transform.Identity, new CopyPasteOptions());

            // Удаляем все найденные настройки организации браузера
            // чтобы произвести замену этих элементов
            target.Delete(removingElements);
        }
    }
}
