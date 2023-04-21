using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using dosymep.Bim4Everyone.SimpleServices.InvokeButtons;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class PlatformCommandsService : IPlatformCommandsService {
        private readonly IInvokeButtonFactory _invokeButtonFactory;

        public PlatformCommandsService(IInvokeButtonFactory invokeButtonFactory) {
            _invokeButtonFactory = invokeButtonFactory;
        }

        public Result InvokeCommand(Guid commandId, ref string message, ElementSet elements) {
            return InvokeCommand(commandId, ref message, elements, new Dictionary<string, string>());
        }

        public Result InvokeCommand(Guid commandId, ref string message, ElementSet elements, Dictionary<string, string> journalData) {
            if(commandId == Guid.Empty) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(commandId));
            }

            var invokableCommand = InvokeButtonCommand.GetInvokeButtonCommands()
                .FirstOrDefault(item => item.CommandId == commandId);
            
            if(invokableCommand == null) {
                throw new ArgumentException($"Команда с переданным идентификатором не найдена \"{commandId}\".", nameof(commandId));
            }

            return _invokeButtonFactory.Create(invokableCommand).InvokeCommand(ref message, elements, journalData);
        }
    }
}