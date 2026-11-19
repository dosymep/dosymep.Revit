namespace Build.Options;

public sealed class BuildOptions {
    public string Configuration { get; set; } = "Debug";
    
    public string[] RevitVersions { get; set; } = ["2020", "2021", "2022", "2023", "2024"];

    public string SolutionFileName { get; set; } = "dosymep.Revit.slnx";

    public string SolutionRoot { get; set; } = Directory.GetCurrentDirectory();
    public string SolutionPath => Path.Combine(SolutionRoot, SolutionFileName);

    public string SrcDirectory => Path.Combine(SolutionRoot, "src");
    public string DocsDirectory => Path.Combine(SolutionRoot, "docs");
    public string TestsDirectory => Path.Combine(SolutionRoot, "tests");
    public string TestsFilesDirectory => Path.Combine(SolutionRoot, "build", "tests_files");

    public string BinDirectory => Path.Combine(SolutionRoot, "bin");
    public string ArtifactsDirectory => Path.Combine(SolutionRoot, "artifacts");
    public string TestResultsDirectory => Path.Combine(SolutionRoot, "TestResults");

    public string DocsOutput => Path.Combine(DocsDirectory, "_site");
    
    public string PyRevitBranch => "v4.8.16.24121+2117";
    public string Bim4EveryoneBranch => "master";
   
    public string PyRevitGit => "https://github.com/pyrevitlabs/pyRevit.git";
    public string Bim4EveryoneGit => "https://github.com/dosymep/BIM4Everyone.git";
    
    public string PyRevitPath => Path.Combine(AppData, "pyRevit-Master");
    public string Bim4EveryonePath => Path.Combine(AppData, @"pyRevit\Extensions\BIM4Everyone.lib");
    public string Bim4EveryoneLibsPath => Path.Combine(AppData, Bim4EveryonePath, @"dosymep_libs\libs");

    public string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    
    public string GetOutputDirectory(string revitVersion) {
        return Path.Combine(BinDirectory, revitVersion);
    }

    public string GetDeployDirectory(string revitVersion) {
        return Path.Combine(AppData, Bim4EveryoneLibsPath, revitVersion);
    }

    public string GetArchivePath(string revitVersion) {
        return Path.Combine(ArtifactsDirectory, $"dosymep.Revit.{revitVersion}.zip");
    }

    public IEnumerable<string> GetProjects() {
        return Directory.GetFiles(SrcDirectory, "*.csproj", SearchOption.AllDirectories);
    }

    public IEnumerable<string> GetTestsProjects() {
        return Directory.GetFiles(TestsDirectory, "*.csproj", SearchOption.AllDirectories);
    }
}