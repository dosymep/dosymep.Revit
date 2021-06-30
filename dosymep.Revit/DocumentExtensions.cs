using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    public static class DocumentExtensions {
        public static void UnloadRevitLinks(string rvtFileName) {
            ModelPath rvtModelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(rvtFileName);

            TransmissionData transData = TransmissionData.ReadTransmissionData(rvtModelPath);
            transData.IsTransmitted = true;

            IEnumerable<ExternalFileReference> externalReferences = transData.GetAllExternalFileReferenceIds()
                .Select(item => transData.GetLastSavedReferenceData(item))
                .Where(item => item.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink);

            foreach(ExternalFileReference externalReference in externalReferences) {
                transData.SetDesiredReferenceData(externalReference.GetReferencingId(), externalReference.GetPath(), externalReference.PathType, false);
            }

            TransmissionData.WriteTransmissionData(rvtModelPath, transData);
        }
    }
}
