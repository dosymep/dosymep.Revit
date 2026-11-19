using Build.Options;

using Microsoft.Extensions.Options;

using ModularPipelines;
using ModularPipelines.Context;
using ModularPipelines.Options;

namespace Build.Modules;

[DependsOn<BuildModule>]
public sealed class BuildDocsModule : Module<CommandResult> {
    private readonly BuildOptions _options;

    public BuildDocsModule(IOptions<BuildOptions> options) {
        _options = options.Value;
    }

    protected override void Configure(ModuleConfigurationBuilder module) {
        if(!IsCi()) {
            // docfx --serve держит процесс, пока его не остановят
            module.WithTimeout(Timeout.InfiniteTimeSpan);
        }
    }

    protected override async Task<CommandResult> ExecuteAsync(
        IModuleContext context,
        CancellationToken cancellationToken) {
        bool serve = !context.Environment.BuildSystem.IsCI;

        return await context.Shell.RunAsync(
            new DocFxOptions {
                Config = "docfx.json",
                Serve = serve,
                OpenBrowser = serve
            },
            new CommandExecutionOptions {
                WorkingDirectory = _options.DocsDirectory,
                ExecutionTimeout = serve ? Timeout.InfiniteTimeSpan : null,
            },
            cancellationToken);
    }

    private static bool IsCi() {
        string? ci = Environment.GetEnvironmentVariable("CI");
        return !string.IsNullOrEmpty(ci)
               && !string.Equals(ci, "false", StringComparison.OrdinalIgnoreCase);
    }
}
