using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines.Context;
using ModularPipelines.FileSystem;
using ModularPipelines.Git.Options;

namespace Build.Modules.Dependencies;

public sealed class DownloadPyRevitModule : Module {
    private readonly BuildOptions _options;

    public DownloadPyRevitModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override void Configure(ModuleConfigurationBuilder module) {
        string pyRevitPath = _options.PyRevitPath;
        module.WithSkipWhen(_ => Directory.Exists(pyRevitPath), "pyRevit is installed.");
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        await context.Tools.Git.Commands.Repository.CloneAsync(
            new GitCloneOptions {
                Depth = "1",
                Branch = _options.PyRevitBranch,
                Arguments = [_options.PyRevitGit, _options.PyRevitPath]
            },
            cancellationToken: cancellationToken);
    }
}