using System;
using System.IO;

namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons
{
    internal class InvokeButtonCommand : ButtonCommand {
        public static readonly InvokeButtonCommand CheckLevelsCommand = new InvokeButtonCommand(PlatformCommandIds.CheckLevelsCommandId,
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\pyRevit\Extensions\01.BIM.extension\BIM.tab\СМР.panel\СМР.stack\Проверить уровни.invokebutton",
            "RevitCheckingLevels.RevitCheckingLevelsCommand",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\pyRevit\Extensions\01.BIM.extension\BIM.tab\bin");

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
        /// Имя сборки.
        /// </summary>
        public string AssemblyName => Path.GetFileName(AssemblyPath);
    }
}