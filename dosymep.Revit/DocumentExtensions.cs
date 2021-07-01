using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;

namespace dosymep.Revit {
    public static class DocumentExtensions {
        public static void UnloadRevitLinks(string rvtFileName) {
            if(string.IsNullOrEmpty(rvtFileName)) {
                throw new ArgumentException($"'{nameof(rvtFileName)}' cannot be null or empty.", nameof(rvtFileName));
            }

            if(!File.Exists(rvtFileName)) {
                throw new FileNotFoundException("Не был найден файл.", rvtFileName);
            }

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

        public static void UnloadRevitLinks(params string[] rvtFileNames) {
            UnloadRevitLinks((IEnumerable<string>) rvtFileNames);
        }

        public static void UnloadRevitLinks(IEnumerable<string> rvtFileNames) {
            foreach(string rvtFileName in rvtFileNames) {
                UnloadRevitLinks(rvtFileName);
            }
        }
    }
}
