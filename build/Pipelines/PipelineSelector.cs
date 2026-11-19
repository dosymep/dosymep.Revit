using Build.Modules;
using Build.Modules.Dependencies;

namespace Build.Pipelines;

internal static class PipelineSelector {
    public static string[] Extract(string[] args, out string targetModule) {
        if(args.Length == 0 || args[0].StartsWith('-')) {
            targetModule = nameof(PackageModule);
            return args;
        }

        targetModule = Resolve(args[0]);
        return args[1..];
    }

    private static string Resolve(string pipeline) {
        return pipeline.Trim().ToLowerInvariant() switch {
            "deps" or "dependencies" => nameof(DownloadPyRevitModule),
            "compile" or "build" or "package" => nameof(PackageModule),
            "deploy" or "publish" => nameof(DeployModule),
            "docs" or "documentation" => nameof(BuildDocsModule),
            _ => throw new ArgumentException(
                $"Unknown pipeline '{pipeline}'. Use: deps, compile, deploy, docs.")
        };
    }
}