using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines;
using ModularPipelines.Context;
using ModularPipelines.DotNet.Options;

namespace Build.Modules;

[DependsOn<CleanModule>]
public sealed class RestoreModule : Module {
    private readonly BuildOptions _options;

    public RestoreModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(IModuleContext context, CancellationToken cancellationToken) {
        await context.Tools.DotNet.RestoreAsync(
            new DotNetRestoreOptions {ProjectSolution = _options.SolutionPath}, cancellationToken: cancellationToken);
    }
}