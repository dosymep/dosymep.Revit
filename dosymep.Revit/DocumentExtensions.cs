using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dosymep.Revit.Transmissions;

namespace dosymep.Revit {
    public static class DocumentExtensions {
        public static void UnloadAllLinks(params string[] rvtFileNames) {
            UnloadAllLinks((IEnumerable<string>) rvtFileNames);
        }

        public static void UnloadAllLinks(IEnumerable<string> rvtFileNames) {
            foreach(string rvtFileName in rvtFileNames) {
                UnloadAllLinks(rvtFileName);
            }
        }

        public static void UnloadAllLinks(string rvtFileName) {
            if(string.IsNullOrEmpty(rvtFileName)) {
                throw new ArgumentException($"'{nameof(rvtFileName)}' cannot be null or empty.", nameof(rvtFileName));
            }

            if(!File.Exists(rvtFileName)) {
                throw new FileNotFoundException("Не был найден файл.", rvtFileName);
            }

            TransmissionData transData = TransmissionData.ReadTransmissionData(rvtFileName);
            transData.IsTransmitted = true;

            foreach(ExternalFileReference externalReference in transData.ExternalFileReferences
                .Where(item => item.ExternalFileReferenceType == ExternalFileReferenceType.CADLink || item.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink)) {
                externalReference.DesiredLoadState = LoadState.Unloaded;
                externalReference.LastSavedLoadState = LoadState.Unloaded;

                externalReference.DesiredPathType = PathType.Relative;
                externalReference.LastSavedPathType = PathType.Relative;

                externalReference.DesiredPath = Path.GetFileName(externalReference.DesiredPath);
                externalReference.LastSavedPath = Path.GetFileName(externalReference.LastSavedPath);
                externalReference.LastSavedCentralServerLocation = null;

                externalReference.LastSavedAbsolutePath = Path.Combine(Path.GetDirectoryName(rvtFileName), Path.GetFileName(externalReference.LastSavedAbsolutePath));
            }

            TransmissionData.WriteTransmissionData(rvtFileName, transData);
        }

        public static void UnloadAllLinksApi(params string[] rvtFileNames) {
            UnloadAllLinksApi((IEnumerable<string>) rvtFileNames);
        }

        public static void UnloadAllLinksApi(IEnumerable<string> rvtFileNames) {
            foreach(string rvtFileName in rvtFileNames) {
                UnloadAllLinksApi(rvtFileName);
            }
        }

        public static void UnloadAllLinksApi(string rvtFileName) {
            if(string.IsNullOrEmpty(rvtFileName)) {
                throw new ArgumentException($"'{nameof(rvtFileName)}' cannot be null or empty.", nameof(rvtFileName));
            }

            if(!File.Exists(rvtFileName)) {
                throw new FileNotFoundException("Не был найден файл.", rvtFileName);
            }

            Autodesk.Revit.DB.ModelPath rvtModelPath = Autodesk.Revit.DB.ModelPathUtils.ConvertUserVisiblePathToModelPath(rvtFileName);

            Autodesk.Revit.DB.TransmissionData transData = Autodesk.Revit.DB.TransmissionData.ReadTransmissionData(rvtModelPath);
            transData.IsTransmitted = true;

            IEnumerable<Autodesk.Revit.DB.ExternalFileReference> externalReferences = transData.GetAllExternalFileReferenceIds()
                .Select(item => transData.GetLastSavedReferenceData(item))
                .Where(item => item.ExternalFileReferenceType == Autodesk.Revit.DB.ExternalFileReferenceType.CADLink || item.ExternalFileReferenceType == Autodesk.Revit.DB.ExternalFileReferenceType.RevitLink);

            foreach(Autodesk.Revit.DB.ExternalFileReference externalReference in externalReferences) {
                transData.SetDesiredReferenceData(externalReference.GetReferencingId(), externalReference.GetPath(), externalReference.PathType, false);
            }

            Autodesk.Revit.DB.TransmissionData.WriteTransmissionData(rvtModelPath, transData);
        }

        public static bool IsExistsParam(this Autodesk.Revit.DB.Document document, string paramName) {
            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return document.GetProjectParamElements().Any(item => item.Name.Equals(paramName));
        }

        public static bool IsExistsProjectParam(this Autodesk.Revit.DB.Document document, string paramName) {
            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return document.GetProjectParams().Any(item => item.Name.Equals(paramName));
        }

        public static bool IsExistsSharedParam(this Autodesk.Revit.DB.Document document, string paramName) {
            if(string.IsNullOrEmpty(paramName)) {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            return document.GetSharedParams().Any(item=> item.Name.Equals(paramName));
        }

        public static IEnumerable<Autodesk.Revit.DB.ParameterElement> GetProjectParams(this Autodesk.Revit.DB.Document document) {
            return document.GetProjectParamElements().Where(item => !(item is Autodesk.Revit.DB.SharedParameterElement));
        }

        public static IEnumerable<Autodesk.Revit.DB.SharedParameterElement> GetSharedParams(this Autodesk.Revit.DB.Document document) {
            return document.GetProjectParamElements().OfType<Autodesk.Revit.DB.SharedParameterElement>();
        }

        public static IEnumerable<Autodesk.Revit.DB.ParameterElement> GetProjectParamElements(this Autodesk.Revit.DB.Document document) {
            return document.GetParameterBindings().Select(item => document.GetElement(((dynamic) item.Definition).Id)).OfType<Autodesk.Revit.DB.ParameterElement>();
        }

        public static IEnumerable<(Autodesk.Revit.DB.Definition Definition, Autodesk.Revit.DB.Binding Binding)> GetParameterBindings(this Autodesk.Revit.DB.Document document) {
            var iterator = document.ParameterBindings.ForwardIterator();
            while(iterator.MoveNext()) {
                yield return (iterator.Key, (Autodesk.Revit.DB.Binding) iterator.Current);
            }
        }
    }
}
