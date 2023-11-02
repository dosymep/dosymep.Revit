using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons {
    internal class InvokeButtonCommand : ButtonCommand {
        public static readonly InvokeButtonCommand CheckLevelsCommand = new InvokeButtonCommand(
            PlatformCommandIds.CheckLevelsCommandId,
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\pyRevit\Extensions\01.BIM.extension\BIM.tab\СМР.panel\СМР.stack\Проверить уровни.invokebutton",
            "RevitCheckingLevels.RevitCheckingLevelsCommand",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\pyRevit\Extensions\01.BIM.extension\BIM.tab\bin\RevitCheckingLevels.dll");

        public static readonly InvokeButtonCommand PlatformSettingsCommand = new InvokeButtonCommand(
            PlatformCommandIds.PlatformSettingsCommandId,
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\pyRevit\Extensions\01.BIM.extension\BIM.tab\Установки.panel\настройки.stack\Настройки.smartbutton",
            "RevitPlatformSettings.PlatformSettingsCommand",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\pyRevit\Extensions\01.BIM.extension\BIM.tab\bin\RevitPlatformSettings.dll");

        public InvokeButtonCommand(Guid commandId,
            string commandPath, string commandTypeName, string assemblyPath)
            : base(commandId, commandPath) {
            CommandTypeName = commandTypeName;
            AssemblyPath = assemblyPath;
        }

        /// <summary>
        /// Имя типа команды.
        /// </summary>
        public string CommandTypeName { get; }

        /// <summary>
        /// Путь до сборки с командой.
        /// </summary>
        public string AssemblyPath { get; }

        /// <summary>
        /// Путь до папки сборки с командой.
        /// </summary>
        public string AssemblyDirectory => Path.GetDirectoryName(AssemblyPath);

        /// <summary>
        /// Имя сборки.
        /// </summary>
        public string AssemblyName => Path.GetFileName(AssemblyPath);

        public static IEnumerable<InvokeButtonCommand> GetInvokeButtonCommands() {
            return typeof(InvokeButtonCommand).GetFields()
                .Select(item => item.GetValue(null))
                .OfType<InvokeButtonCommand>();
        }
    }
}