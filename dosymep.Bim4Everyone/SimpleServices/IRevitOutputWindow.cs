using System;
using System.Collections.Generic;

using Autodesk.Revit.DB;

namespace dosymep.Bim4Everyone.SimpleServices {
    /// <summary>
    /// Интерфейс неблокирующего окна вывода сообщений.
    /// </summary>
    public interface IRevitOutputWindow {
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        string Title { get; set; }
        
        /// <summary>
        /// Путь до иконки окна.
        /// </summary>
        string IconPath { get; set; }
        

        /// <summary>
        /// Ставит окно по центру монитора.
        /// </summary>
        void Center();

        /// <summary>
        /// Устанавливает размер окна.
        /// </summary>
        /// <param name="width">Ширина окна.</param>
        /// <param name="height">Высота окна.</param>
        void SetSize(double width, double height);
        

        /// <summary>
        /// Показывает окно.
        /// </summary>
        void Show();
        
        /// <summary>
        /// Скрывает окно.
        /// </summary>
        void Hide();

        /// <summary>
        /// Закрывает окно.
        /// </summary>
        void Close();
        

        /// <summary>
        /// Печатает содержимое текста.
        /// </summary>
        /// <param name="text">Текстовое содержимое.</param>
        void PrintText(string text);

        /// <summary>
        /// Печатает HTML содержимое.
        /// </summary>
        /// <param name="html">HTML содержимое.</param>
        void PrintHTML(string html);

        /// <summary>
        /// Печатает содержимое кода.
        /// </summary>
        /// <param name="code">Содержимое кода.</param>
        void PrintCode(string code);

        /// <summary>
        /// Печатает содержимое markdown документа.
        /// </summary>
        /// <param name="markdown">Содержимое markdown.</param>
        void PrintMarkdown(string markdown);

        /// <summary>
        /// Печатает изображение.
        /// </summary>
        /// <param name="imagePath">Путь до печатаемого изображения.</param>
        void PrintImage(string imagePath);

        /// <summary>
        /// Печатает таблицу.
        /// </summary>
        /// <param name="rows">Список строк.</param>
        /// <param name="title">Наименование таблицы.</param>
        /// <param name="columns">Список наименований колонок.</param>
        void PrintTable(List<string[]> rows, string title = null, List<string> columns = null);
        

        /// <summary>
        /// Возвращает ссылку на элемент.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <returns>Возвращает ссылку на элемент.</returns>
        string GetElementLinks(ElementId elementId);
        
        /// <summary>
        /// Возвращает ссылки на элементы.
        /// </summary>
        /// <param name="elementIds">Массив идентификаторов элементов.</param>
        /// <returns>Возвращает ссылки на элементы.</returns>
        string GetElementLinks(params ElementId[] elementIds);
        
        /// <summary>
        /// Возвращает ссылки на элементы.
        /// </summary>
        /// <param name="elementIds">Перечисление идентификаторов элементов.</param>
        /// <returns>Возвращает ссылки на элементы.</returns>
        string GetElementLinks(IEnumerable<ElementId> elementIds);
        
        
        /// <summary>
        /// Возвращает ссылку на элемент.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Возвращает ссылку на элемент.</returns>
        string GetElementLinks(Element element);
        
        /// <summary>
        /// Возвращает ссылки на элементы.
        /// </summary>
        /// <param name="elements">Массив элементов.</param>
        /// <returns>Возвращает ссылки на элементы.</returns>
        string GetElementLinks(params Element[] elements);
        
        /// <summary>
        /// Возвращает ссылки на элементы.
        /// </summary>
        /// <param name="elements">Перечисление элементов.</param>
        /// <returns>Возвращает ссылки на элементы.</returns>
        string GetElementLinks(IEnumerable<Element> elements);
    }
}