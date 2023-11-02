using System.Collections.Generic;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace dosymep.Bim4Everyone.SimpleServices.InvokeButtons {
    internal interface IInvokeButton {
        Result InvokeCommand(ref string message, ElementSet elements, Dictionary<string, string> journalData);
    }
}