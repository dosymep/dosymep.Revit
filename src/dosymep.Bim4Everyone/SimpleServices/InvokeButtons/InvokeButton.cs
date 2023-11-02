using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons {
    internal class InvokeButton : IInvokeButton {
        private readonly UIApplication _uiApplication;
        private readonly InvokeButtonCommand _invokeButtonCommand;

        public InvokeButton(UIApplication uiApplication, InvokeButtonCommand invokeButtonCommand) {
            _uiApplication = uiApplication;
            _invokeButtonCommand = invokeButtonCommand;
        }

        public Result InvokeCommand(ref string message, ElementSet elements, Dictionary<string, string> journalData) {
            string assemblyPath = Path.Combine(_invokeButtonCommand.AssemblyDirectory, 
                $"{Path.GetFileNameWithoutExtension(_invokeButtonCommand.AssemblyName)}_{ModuleEnvironment.RevitVersion}.dll");

            if(!File.Exists(assemblyPath)) {
                assemblyPath = _invokeButtonCommand.AssemblyPath;
                if(!File.Exists(assemblyPath)) {
                    throw new InvalidOperationException("Не была найдена сборка запускаемой команды.");
                }
            }

            Assembly assembly = Assembly.Load(File.ReadAllBytes(assemblyPath));
            var commandType = assembly.GetType(_invokeButtonCommand.CommandTypeName);
            var externalCommand = (IExternalCommand) Activator.CreateInstance(commandType);
            return externalCommand.Execute(CreateExternalCommandData(journalData), ref message, elements);
        }

        private ExternalCommandData CreateExternalCommandData(Dictionary<string, string> journalData) {
            var externalCommandData = (ExternalCommandData) Activator.CreateInstance(typeof(ExternalCommandData), true);
            externalCommandData.Application = _uiApplication;
            externalCommandData.View = _uiApplication.ActiveUIDocument?.ActiveView;

            externalCommandData.JournalData = journalData;
            externalCommandData.JournalData.Add(PlatformCommandIds.ExecutedFromUI, "false");

            return externalCommandData;
        }
    }
}