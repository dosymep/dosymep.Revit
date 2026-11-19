using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines.Context;
using ModularPipelines.FileSystem;
using ModularPipelines.Git.Options;

namespace Build.Modules.Dependencies;

public sealed class DownloadB4EModule : Module {
    private readonly BuildOptions _options;

    public DownloadB4EModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override void Configure(ModuleConfigurationBuilder module) {
        string bim4EveryonePath = _options.Bim4EveryonePath;
        module.WithSkipWhen(_ => Directory.Exists(bim4EveryonePath), "b4e is installed.");
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        await context.Tools.Git.Commands.Repository.CloneAsync(
            new GitCloneOptions {
                Depth = "1",
                Branch = _options.Bim4EveryoneBranch,
                Arguments = [_options.Bim4EveryoneGit, _options.Bim4EveryonePath]
            },
            cancellationToken: cancellationToken);
    }
}