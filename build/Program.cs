using Build.Modules;
using Build.Modules.Dependencies;
using Build.Options;
using Build.Versioning;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using ModularPipelines;

PipelineBuilder builder = Pipeline.CreateBuilder(args);

builder.Services.AddOptions<BuildOptions>()
    .Configure(options => {
        string? configuration = Environment.GetEnvironmentVariable("CONFIGURATION");
        if(!string.IsNullOrWhiteSpace(configuration)) {
            options.Configuration = configuration.Trim();
        }

        string? revitVersions = Environment.GetEnvironmentVariable("REVIT_VERSIONS");
        if(!string.IsNullOrWhiteSpace(revitVersions)) {
            options.RevitVersions = revitVersions
                .Split([',', ';', ' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }
    });

builder.Services.AddSingleton(static services => {
    BuildOptions options = services.GetRequiredService<IOptions<BuildOptions>>().Value;
    return new BuildVersionFactory(options.SolutionRoot);
});

builder
    .AddModule<DownloadB4EModule>()
    .AddModule<DownloadPyRevitModule>()
    .AddModule<CleanModule>()
    .AddModule<RestoreModule>()
    .AddModule<BuildModule>()
    .AddModule<PackageModule>()
    .AddModule<DeployModule>()
    .AddModule<BuildDocsModule>();

await builder.RunAsync();