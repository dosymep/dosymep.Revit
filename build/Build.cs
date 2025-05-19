using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using dosymep.Nuke.RevitVersions;

using Nuke.Common;
using Nuke.Common.CI.GitLab;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DocFX;
using Nuke.Common.Tools.DotNet;
using Nuke.Components;

using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;

class Build : NukeBuild, IHazSolution {
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter] readonly AbsolutePath Output = RootDirectory / "bin";
    [Parameter] readonly string DocsOutput = Path.Combine("docs", "_site");
    [Parameter] readonly string DocsConfig = Path.Combine("docs", "docfx.json");
    [Parameter] readonly AbsolutePath DocsCaches = RootDirectory / Path.Combine("docs", "api");
    
    // ReSharper disable once InconsistentNaming
    [Parameter] readonly AbsolutePath pyRevitOutput;
    [Parameter] readonly AbsolutePath Bim4EveryoneOutput;
    [Parameter] readonly AbsolutePath PublishOutput;

    public Build() {
        AbsolutePath appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        
        pyRevitOutput = appdataFolder / "pyRevit-Master";
        Bim4EveryoneOutput = appdataFolder / "pyRevit" / "Extensions" / "BIM4Everyone.lib";
        PublishOutput = Bim4EveryoneOutput / "dosymep_libs" / "libs";
    }

    /// <summary>
    /// Min Revit version.
    /// </summary>
    [Parameter("Min Revit version.")]
    readonly RevitVersion MinVersion = RevitVersion.Rv2020;

    /// <summary>
    /// Max Revit version.
    /// </summary>
    [Parameter("Max Revit version.")]
    readonly RevitVersion MaxVersion = RevitVersion.Rv2024;

    [Parameter("Build Revit versions.")] readonly RevitVersion[] RevitVersions = new RevitVersion[0];

    IEnumerable<RevitVersion> BuildRevitVersions;

    protected override void OnBuildInitialized() {
        base.OnBuildInitialized();
        BuildRevitVersions = RevitVersions.Length > 0
            ? RevitVersions
            : RevitVersion.GetRevitVersions(MinVersion, MaxVersion);
    }

    Target Clean => _ => _
        .Executes(() => {
            Output.CreateOrCleanDirectory();
            (RootDirectory / DocsOutput).CreateOrCleanDirectory();
            DocsCaches.GlobFiles("**/*.yml").DeleteFiles();
            RootDirectory.GlobDirectories("**/bin", "**/obj")
                .Where(item => item != (RootDirectory / "build" / "bin"))
                .Where(item => item != (RootDirectory / "build" / "obj"))
                .DeleteDirectories();
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() => {
            DotNetRestore(s => s
                .SetProjectFile(((IHazSolution) this).Solution));
        });

    Target DownloadBim4Everyone => _ => _
        .OnlyWhenStatic(() => IsServerBuild)
        .Executes(() => {
            // потому что основные пакеты лежат в библиотеке pyRevit
            Git($"clone https://github.com/pyrevitlabs/pyRevit.git --depth 1 --branch v4.8.16.24121+2117 {pyRevitOutput}");
            Git($"clone https://github.com/dosymep/BIM4Everyone.git --depth 1 --branch master {Bim4EveryoneOutput}");
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .DependsOn(DownloadBim4Everyone)
        .Executes(() => {
            DotNetBuild(s => s
                .EnableForce()
                .DisableNoRestore()
                .SetConfiguration(Configuration)
                .SetProjectFile(((IHazSolution) this).Solution)
                .When(settings => IsServerBuild,
                    _ => _
                        .EnableContinuousIntegrationBuild())
                .CombineWith(BuildRevitVersions,
                    (settings, version) => settings
                        .SetProperty("OutputPath", Output / version)
                        .SetProperty("RevitVersion", (int) version)));
        });

    Target Publish => _ => _
        .DependsOn(Restore)
        .OnlyWhenStatic(() => IsLocalBuild)
        .Executes(() => {
            DotNetPublish(s => s
                .EnableForce()
                .DisableNoRestore()
                .SetConfiguration(Configuration)
                .CombineWith(BuildRevitVersions,
                    (settings, version) => settings
                        .SetProperty("RevitVersion", (int) version)
                        .SetProperty("PublishDir", PublishOutput / version)));
        });

    Target DocsCompile => _ => _
        .DependsOn(Compile)
        .Executes(() => {
            ProcessTasks.StartProcess(
                "docfx",
                DocsConfig
                + (IsLocalBuild
                    ? " --serve"
                    : string.Empty),
                RootDirectory).WaitForExit();

            // DocFXBuild(s => s
            //     .EnableForceRebuild()
            //     .SetServe(IsLocalBuild)
            //     .SetOutputFolder(DocsOutput)
            //     .SetProcessWorkingDirectory(RootDirectory)
            // );
        });
}