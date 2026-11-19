using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines;
using ModularPipelines.Context;
using ModularPipelines.FileSystem;

namespace Build.Modules;

public sealed class CleanModule : Module {
    private readonly BuildOptions _options;

    public CleanModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        await DeleteIfExistsAsync(context, _options.DocsOutput, cancellationToken);
        await DeleteIfExistsAsync(context, _options.BinDirectory, cancellationToken);
        await DeleteIfExistsAsync(context, _options.ArtifactsDirectory, cancellationToken);

        await DeleteBinAndObjAsync(context, cancellationToken);
    }

    private async Task DeleteBinAndObjAsync(IModuleContext context, CancellationToken cancellationToken) {
        FolderPath src = context.Files.GetFolder(_options.SrcDirectory);
        if(!src.Exists) {
            return;
        }

        List<FolderPath> directories = src
            .GetFolders(static folder => folder.Name is "bin" or "obj")
            .OrderByDescending(static folder => folder.Path.Length)
            .ToList();

        foreach(FolderPath folder in directories) {
            if(folder.Exists) {
                await folder.DeleteAsync(cancellationToken);
            }
        }
    }

    private static async Task DeleteIfExistsAsync(
        IModuleContext context,
        string directoryPath,
        CancellationToken cancellationToken) {
        FolderPath folder = context.Files.GetFolder(directoryPath);
        if(folder.Exists) {
            await folder.DeleteAsync(cancellationToken);
        }
    }
}