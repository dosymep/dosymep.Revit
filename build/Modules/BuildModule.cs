using Build.Modules.Dependencies;
using Build.Options;
using Build.Versioning;

using Microsoft.Extensions.Options;

using ModularPipelines;
using ModularPipelines.Context;
using ModularPipelines.DotNet.Options;
using ModularPipelines.Git;

namespace Build.Modules;

[DependsOn<RestoreModule>]
[DependsOn<DownloadB4EModule>(Optional = true)]
[DependsOn<DownloadPyRevitModule>(Optional = true)]
public sealed class BuildModule : Module {
    private readonly BuildOptions _options;
    private readonly BuildVersionFactory _versions;

    public BuildModule(IOptions<BuildOptions> options, BuildVersionFactory versions) {
        _options = options.Value;
        _versions = versions;
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        GitRepositoryInfo git = await context.Tools.Git.Information.GetRequiredInfoAsync(cancellationToken);

        foreach(string revitVersion in _options.RevitVersions) {
            await BuildProjectAsync(context, git, revitVersion, cancellationToken);
        }
    }

    private async Task BuildProjectAsync(
        IModuleContext context,
        GitRepositoryInfo git,
        string revitVersion,
        CancellationToken cancellationToken) {
        string outputDirectory = _options.GetOutputDirectory(revitVersion);
        foreach(string projectPath in _options.GetProjects()) {
            await context.Tools.DotNet.BuildAsync(
                new DotNetBuildOptions {
                    ProjectSolution = projectPath,
                    Configuration = _options.Configuration,
                    Output = outputDirectory,
                    NoRestore = false,
                    NoIncremental = true,
                    Arguments = ["--force"],
                    Properties = [
                        ("RevitVersion", revitVersion),
                        .. _versions.PropertiesFor(git, revitVersion)
                    ]
                },
                cancellationToken: cancellationToken);
        }
    }
}