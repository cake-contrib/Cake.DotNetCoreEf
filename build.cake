#addin "Cake.Figlet"
#addin "Cake.Git"
#tool "xunit.runner.console"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var appName = "Cake.DotNetCoreEf";

//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////
var local = BuildSystem.IsLocalBuild;
var isRunningOnAppVeyor = AppVeyor.IsRunningOnAppVeyor;
var isPullRequest = AppVeyor.Environment.PullRequest.IsPullRequest;

var branchName = isRunningOnAppVeyor ? EnvironmentVariable("APPVEYOR_REPO_BRANCH") : GitBranchCurrent(DirectoryPath.FromString(".")).FriendlyName;
var isMasterBranch = System.String.Equals("master", branchName, System.StringComparison.OrdinalIgnoreCase);

var isTagCommit = false;
var tagName = bool.TryParse(EnvironmentVariable("APPVEYOR_REPO_TAG"), out isTagCommit) ? (isTagCommit ? EnvironmentVariable("APPVEYOR_REPO_TAG_NAME") : string.Empty) : string.Empty;

var buildNumber = AppVeyor.Environment.Build.Number;
var version = "0.1.0";
var semVersion = local ? version : (version + string.Concat("-build-", buildNumber));

var buildDir = "./src/Cake.DotNetCoreEf/bin/" + configuration;
var buildTestDir = "./src/Cake.DotNetCoreEf/bin/" + configuration;

var buildResultDir = "./build/v" + semVersion;
var testResultsDir = buildResultDir + "/test-results";
var nugetRoot = buildResultDir + "/nuget";
var binDir = buildResultDir + "/bin";

var solutionPath = File("./src/Cake.DotNetCoreEf.sln");

var zipPackage = buildResultDir + "/Cake-DotNetCoreEf-v" + semVersion + ".zip";

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context =>
{
    Information(Figlet(appName));
});

///////////////////////////////////////////////////////////////////////////////
// PREPARE
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{   
    CleanDirectories(new DirectoryPath[]
    {
        buildDir, 
        buildTestDir, 
        buildResultDir,
        binDir, 
        testResultsDir, 
        nugetRoot
    });
});

Task("Restore-Nuget-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionPath);
});

///////////////////////////////////////////////////////////////////////////////
// BUILD
///////////////////////////////////////////////////////////////////////////////

Task("Patch-Assembly-Info")
    .IsDependentOn("Restore-Nuget-Packages")
    .Does(() =>
{
    CreateAssemblyInfo("./src/SolutionInfo.cs", new AssemblyInfoSettings
    {
        Product = appName,
        Version = version,
        FileVersion = version,
        InformationalVersion = semVersion,
        Copyright = "Copyright (c) Cake Contributions Organization 2017"
    });
});

Task("Build")
    .IsDependentOn("Patch-Assembly-Info")
    .Does(() =>
{
    DotNetBuild (solutionPath, settings =>
        settings.SetConfiguration(configuration)
                .WithTarget("Build")
                .SetVerbosity(Verbosity.Minimal)                    
                .WithProperty("TreatWarningsAsErrors","false")
    );    
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    XUnit2("./src/**/bin/" + configuration + "/*.Tests.dll", new XUnit2Settings
    {
        OutputDirectory = testResultsDir,
        Parallelism = ParallelismOption.All,
        XmlReport = true,        
    });    
});

///////////////////////////////////////////////////////////////////////////////
// PACKAGE
///////////////////////////////////////////////////////////////////////////////

Task("Copy-Files")
    .IsDependentOn("Build")
	.IsDependentOn("Run-Unit-Tests")
    .Does(() =>
{
    CopyFileToDirectory(buildDir + "/Cake.DotNetCoreEf.dll", binDir);
	CopyFileToDirectory(buildDir + "/Cake.DotNetCoreEf.xml", binDir);
    CopyFiles(new FilePath[] { "LICENSE", "README.md" }, binDir);
});

Task("Zip-Files")
    .IsDependentOn("Copy-Files")
    .Does(() =>
{
    Zip(binDir, zipPackage);
});

Task("Create-NuGet-Packages")
    .IsDependentOn("Zip-Files")
    .Does(() =>
{
    NuGetPack("./nuspec/Cake.DotNetCoreEf.nuspec", new NuGetPackSettings
    {
        Version = version,
        BasePath = binDir,
        OutputDirectory = nugetRoot,
        Symbols = false,
        NoPackageAnalysis = true
    });
});

Task("Publish-Nuget")
    .IsDependentOn("Create-NuGet-Packages")
    .WithCriteria(() => isRunningOnAppVeyor)
    .WithCriteria(() => !isPullRequest)
    .WithCriteria(() => isMasterBranch)
    .WithCriteria(() => isTagCommit)
    .Does(() =>
{
    var apiKey = EnvironmentVariable("NUGET_API_KEY");

    if(string.IsNullOrEmpty(apiKey))    
        throw new InvalidOperationException("Could not resolve Nuget API key.");

    NuGetPush(nugetRoot + "/Cake.DotNetCoreEf." + version + ".nupkg", new NuGetPushSettings
    {
        ApiKey = apiKey,
        Source = "https://www.nuget.org/api/v2/package"
    });
});

///////////////////////////////////////////////////////////////////////////////
// APPVEYOR
///////////////////////////////////////////////////////////////////////////////

Task("Update-AppVeyor-Build-Number")
    .WithCriteria(() => isRunningOnAppVeyor)
    .Does(() =>
{
    AppVeyor.UpdateBuildVersion(semVersion);
});

Task("Upload-AppVeyor-Test-Results")
    .IsDependentOn("Run-Unit-Tests")
    .WithCriteria(() => isRunningOnAppVeyor)
    .Does(() =>
{
    AppVeyor.UploadTestResults(testResultsDir + "/" + appName + ".Tests.dll.xml", AppVeyorTestResultsType.XUnit);
});

Task("Upload-AppVeyor-Artifacts")
    .IsDependentOn("Zip-Files")
    .WithCriteria(() => isRunningOnAppVeyor)
    .Does(() =>
{
    AppVeyor.UploadArtifact(zipPackage);
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Package")
    .IsDependentOn("Zip-Files")
    .IsDependentOn("Create-NuGet-Packages");

Task("Publish")
    .IsDependentOn("Publish-Nuget");

Task("AppVeyor")
    .IsDependentOn("Publish")
    .IsDependentOn("Update-AppVeyor-Build-Number")
    .IsDependentOn("Upload-AppVeyor-Test-Results")
    .IsDependentOn("Upload-AppVeyor-Artifacts");

Task("Default")
    .IsDependentOn("Package");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);