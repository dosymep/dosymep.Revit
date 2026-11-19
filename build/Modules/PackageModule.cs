using System.IO.Compression;

using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines;
using ModularPipelines.Context;
using ModularPipelines.FileSystem;

namespace Build.Modules;

[DependsOn<BuildModule>]
public sealed class PackageModule : Module {
    private readonly BuildOptions _options;

    public PackageModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        Directory.CreateDirectory(_options.ArtifactsDirectory);

        foreach(string revitVersion in _options.RevitVersions) {
            await PackageAsync(context, revitVersion, cancellationToken);
        }
    }

    private async Task PackageAsync(IModuleContext context, string revitVersion, CancellationToken cancellationToken) {
        FolderPath archivePath = context.Files.GetFolder(_options.GetArchivePath(revitVersion));

        FolderPath source = context.Files.GetFolder(_options.GetOutputDirectory(revitVersion));
        if(!source.Exists) {
            throw new DirectoryNotFoundException($"Build output was not found: {source.Path}");
        }

        await context.Files.Zip.CreateFromDirectoryAsync(
            source, archivePath, CompressionLevel.Optimal, cancellationToken);
    }
}