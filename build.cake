#tool nuget:?package=Fixie
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////
var buildDir = Directory("./src/Cake.ActiveDirectory/bin") + Directory(configuration);
var solution = "./src/Cake.ActiveDirectory.sln";
var artifactsDir = Directory("./artifacts");
var assemblyInfo = ParseAssemblyInfo("./src/Cake.ActiveDirectory/Properties/AssemblyInfo.cs");
var version = assemblyInfo.AssemblyVersion; 
var isMasterBranch = StringComparer.OrdinalIgnoreCase.Equals("master", AppVeyor.Environment.Repository.Branch);

EnsureDirectoryExists(artifactsDir);
//////////////////////////////////////////////////////////////////////
// Environment Variables
//////////////////////////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() => {
        CleanDirectories("./src/**/bin/" + configuration);
        CleanDirectory(artifactsDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() => {
        NuGetRestore(solution);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() => {
      // Use MSBuild
      MSBuild(solution, settings => settings.SetConfiguration(configuration));
});

Task("Unit-Tests")
    .IsDependentOn("Build")
    .Does(() => {
        Fixie("./src/**/bin/" + configuration + "/*.Tests.dll", new FixieSettings {
            NUnitXml = "TestResult.xml"
        });
});

Task("Package")
    .IsDependentOn("Unit-Tests")
    .Does(() => {
        var nugetPackSettings = new NuGetPackSettings {
            Id = assemblyInfo.Product,
            Version = version,
            Title = assemblyInfo.Title,
            Authors = new []{assemblyInfo.Company},
            Owners = new []{assemblyInfo.Company},
            Description = assemblyInfo.Description,
            ProjectUrl = new Uri("https://github.com/RadioSystems/Cake.ActiveDirectory"),
            LicenseUrl = new Uri("https://github.com/RadioSystems/Cake.ActiveDirectory/blob/master/LICENSE"),
            Copyright = assemblyInfo.Copyright,
            Tags = new []{"Cake", "Active Directory", "AD"},
            RequireLicenseAcceptance = false,
            Symbols =  false,
            NoPackageAnalysis = true,
            Files = new [] {
                new NuSpecContent {Source = "Cake.ActiveDirectory.dll", Target="lib/net45/Cake.ActiveDirectory.dll"},
                new NuSpecContent {Source = "Cake.ActiveDirectory.xml", Target="lib/net45/Cake.ActiveDirectory.xml"},
                new NuSpecContent {Source = "Landpy.ActiveDirectory.dll", Target="lib/net45/Landpy.ActiveDirectory.dll"}
            },
            BasePath = "./src/Cake.ActiveDirectory/bin/" + configuration,
            OutputDirectory = artifactsDir
        };      
      
        NuGetPack(nugetPackSettings);
});

Task("Deploy")
    .IsDependentOn("Package")
    .WithCriteria(()=> AppVeyor.IsRunningOnAppVeyor)
    .WithCriteria(()=> isMasterBranch)
    .Does(() => {
        var apiKey = EnvironmentVariable("NUGET_API_KEY");
        if(string.IsNullOrEmpty(apiKey)) {
            throw new InvalidOperationException("Could not resolve Nuget API key.");
        }

        // Push the package.
        var package = "./artifacts/Cake.ActiveDirectory." + version + ".nupkg";

        NuGetPush(package, new NuGetPushSettings { 
            Source = "https://api.nuget.org/v3/index.json",
            ApiKey = apiKey
        });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Deploy");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);