#load nuget:?package=Cake.Recipe&version=2.2.0

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.DotNetCoreEf",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.DotNetCoreEf",
                            shouldRunCodecov: false,
                            shouldGenerateDocumentation: false, // until wyam oin recipe is fixed
                            appVeyorAccountName: "cakecontrib",
                            shouldRunDotNetCorePack: true,
                            preferredBuildProviderType: BuildProviderType.GitHubActions);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                            	BuildParameters.RootDirectoryPath + "/src/**/*.AssemblyInfo.cs",
                                BuildParameters.RootDirectoryPath + "/src/Cake.DotNetCoreEf/Migration/DotNetCoreEfMigrationLister.cs",
                                BuildParameters.RootDirectoryPath + "/src/Cake.DotNetCoreEf/DotNetCoreEfTool.cs",
                                BuildParameters.RootDirectoryPath + "/src/Cake.DotNetCoreEf.UnitTests/**/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[FakeItEasy]* -[FluentAssertions]* -[FluentAssertions.Core]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
