using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.DotNetCoreEf.Tests.Fixtures
{
    internal abstract class DotNetCoreEfFixture<TSettings> : ToolFixture<TSettings, ToolFixtureResult>
        where TSettings : DotNetCoreEfSettings, new()
    {
        protected DotNetCoreEfFixture()
            : base("dotnet.exe")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }

        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }
}