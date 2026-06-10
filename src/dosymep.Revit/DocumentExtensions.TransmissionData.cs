using Autodesk.Revit.DB;

using dosymep.Revit.Transmissions;

using ExternalFileReference = dosymep.Revit.Transmissions.ExternalFileReference;
using ExternalFileReferenceType = dosymep.Revit.Transmissions.ExternalFileReferenceType;
using PathType = dosymep.Revit.Transmissions.PathType;
using TransmissionData = dosymep.Revit.Transmissions.TransmissionData;

namespace dosymep.Revit;

public static partial class DocumentExtensions {
    #region UnloadLinks

    /// <summary>
    ///     Выгружает все связанные файлы для переданных документов Revit.
    /// </summary>
    /// <param name="rvtFileNames">Документы Revit.</param>
    /// <remarks>Работает без использования API <see cref="Autodesk.Revit.DB.TransmissionData" /></remarks>
    public static void UnloadAllLinks(params string[] rvtFileNames) {
        UnloadAllLinks((IEnumerable<string>) rvtFileNames);
    }

    /// <summary>
    ///     Выгружает все связанные файлы для переданных документов Revit.
    /// </summary>
    /// <param name="rvtFileNames">Документы Revit.</param>
    /// <remarks>Работает без использования API <see cref="Autodesk.Revit.DB.TransmissionData" /></remarks>
    public static void UnloadAllLinks(IEnumerable<string> rvtFileNames) {
        foreach(string rvtFileName in rvtFileNames) {
            UnloadAllLinks(rvtFileName);
        }
    }

    /// <summary>
    ///     Выгружает все связанные файлы для переданного документа Revit.
    /// </summary>
    /// <param name="rvtFileName">Документ Revit.</param>
    /// <remarks>Работает без использования API <see cref="Autodesk.Revit.DB.TransmissionData" /></remarks>
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
                    .Where(item =>
                        item.ExternalFileReferenceType is ExternalFileReferenceType.CADLink or ExternalFileReferenceType.RevitLink)) {
            externalReference.DesiredLoadState = LoadState.Unloaded;
            externalReference.LastSavedLoadState = LoadState.Unloaded;

            externalReference.DesiredPathType = PathType.Relative;
            externalReference.LastSavedPathType = PathType.Relative;

            externalReference.DesiredPath = Path.GetFileName(externalReference.DesiredPath);
            externalReference.LastSavedPath = Path.GetFileName(externalReference.LastSavedPath);
            externalReference.LastSavedCentralServerLocation = null;

            externalReference.LastSavedAbsolutePath = Path.Combine(Path.GetDirectoryName(rvtFileName),
                Path.GetFileName(externalReference.LastSavedAbsolutePath));
        }

        // Удаляем атрибуты, которые мешают выгрузке (Только чтение)
        File.SetAttributes(rvtFileName, FileAttributes.Normal);
        TransmissionData.WriteTransmissionData(rvtFileName, transData);
    }

    #endregion

    #region UnloadLinksApi

    /// <summary>
    ///     Выгружает все связанные файлы для переданных документов Revit.
    /// </summary>
    /// <param name="rvtFileNames">Документы Revit.</param>
    /// <remarks>Работает c использованием API <see cref="Autodesk.Revit.DB.TransmissionData" /></remarks>
    public static void UnloadAllLinksApi(params string[] rvtFileNames) {
        UnloadAllLinksApi((IEnumerable<string>) rvtFileNames);
    }

    /// <summary>
    ///     Выгружает все связанные файлы для переданных документов Revit.
    /// </summary>
    /// <param name="rvtFileNames">Документы Revit.</param>
    /// <remarks>Работает c использованием API <see cref="Autodesk.Revit.DB.TransmissionData" /></remarks>
    public static void UnloadAllLinksApi(IEnumerable<string> rvtFileNames) {
        foreach(string rvtFileName in rvtFileNames) {
            UnloadAllLinksApi(rvtFileName);
        }
    }

    /// <summary>
    ///     Выгружает все связанные файлы для переданного документа Revit.
    /// </summary>
    /// <param name="rvtFileName">Документ Revit.</param>
    /// <remarks>Работает c использованием API <see cref="Autodesk.Revit.DB.TransmissionData" /></remarks>
    public static void UnloadAllLinksApi(string rvtFileName) {
        if(string.IsNullOrEmpty(rvtFileName)) {
            throw new ArgumentException($"'{nameof(rvtFileName)}' cannot be null or empty.", nameof(rvtFileName));
        }

        if(!File.Exists(rvtFileName)) {
            throw new FileNotFoundException("Не был найден файл.", rvtFileName);
        }

        ModelPath rvtModelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(rvtFileName);

        Autodesk.Revit.DB.TransmissionData transData =
            Autodesk.Revit.DB.TransmissionData.ReadTransmissionData(rvtModelPath);
        transData.IsTransmitted = true;

        IEnumerable<Autodesk.Revit.DB.ExternalFileReference> externalReferences = transData
            .GetAllExternalFileReferenceIds()
            .Select(item => transData.GetLastSavedReferenceData(item))
            .Where(item => item.ExternalFileReferenceType 
                is Autodesk.Revit.DB.ExternalFileReferenceType.CADLink or Autodesk.Revit.DB.ExternalFileReferenceType.RevitLink);

        foreach(Autodesk.Revit.DB.ExternalFileReference externalReference in externalReferences) {
            transData.SetDesiredReferenceData(externalReference.GetReferencingId(), externalReference.GetPath(),
                externalReference.PathType, false);
        }

        Autodesk.Revit.DB.TransmissionData.WriteTransmissionData(rvtModelPath, transData);
    }

    #endregion
}