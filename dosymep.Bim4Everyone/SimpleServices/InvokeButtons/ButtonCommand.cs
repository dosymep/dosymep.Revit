using System;
using System.IO;
using System.Linq;

namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons {
    /// <summary>
    /// Информация о команде платформы.
    /// </summary>
    internal abstract class ButtonCommand {
        public ButtonCommand(Guid commandId, string commandPath) {
            CommandId = commandId;
            CommandPath = commandPath;
        }
        
        /// <summary>
        /// Идентификатор команды.
        /// </summary>
        public Guid CommandId { get; }

        /// <summary>
        /// Путь до папки с командой.
        /// </summary>
        public string CommandPath { get; }

        /// <summary>
        /// Имя команды.
        /// </summary>
        public string CommandName => Path.GetFileName(CommandPath);

        /// <summary>
        /// Иконка команды - светлая.
        /// </summary>
        public string Icon => GetFile("icon.png");
        
        /// <summary>
        /// Иконка команды - темная. 
        /// </summary>
        public string IconDark => GetFile("icon.dark.png");
        
        /// <summary>
        /// Иконка команды - ошибка. 
        /// </summary>
        public string IconFatal => GetFile("icon.fatal.png");
        
        /// <summary>
        /// Иконка команды - предупреждение. 
        /// </summary>
        public string IconWarning => GetFile("icon.warning.png");

        /// <summary>
        /// Возвращает файл из папки с командой.
        /// </summary>
        /// <param name="searchPattern">Шаблон поиска файла.</param>
        /// <returns>Возвращает файл из папки с командой.</returns>
        protected string GetFile(string searchPattern) {
            return Directory.GetFiles(CommandPath, searchPattern).FirstOrDefault();
        }
    }
}