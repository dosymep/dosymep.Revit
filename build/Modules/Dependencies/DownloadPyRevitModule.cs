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
        module.WithSkipWhen(_ => !File.Exists(_options.PyRevitPath), "pyRevit is installed.");
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