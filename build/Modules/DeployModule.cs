using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines;
using ModularPipelines.Context;
using ModularPipelines.FileSystem;

namespace Build.Modules;

[DependsOn<BuildModule>]
public sealed class DeployModule : Module {
    private readonly BuildOptions _options;

    public DeployModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        foreach(string revitVersion in _options.RevitVersions) {
            await DeployAsync(context, revitVersion, cancellationToken);
        }
    }

    private async Task DeployAsync(IModuleContext context, string revitVersion, CancellationToken cancellationToken) {
        FolderPath source = context.Files.GetFolder(_options.GetOutputDirectory(revitVersion));
        if(!source.Exists) {
            throw new DirectoryNotFoundException($"Build output was not found: {source.Path}");
        }

        FolderPath destination = context.Files.GetFolder(_options.GetDeployDirectory(revitVersion));
        if(destination.Exists) {
            await destination.DeleteAsync(cancellationToken);
        }

        await source.CopyToAsync(destination.Path, cancellationToken);
    }
}