using Cake.DotNetCoreEf.Migration;

namespace Cake.DotNetCoreEf.Tests.Fixtures.Migration
{
    internal sealed class DotNetCoreEfMigrationAdderFixture : DotNetCoreEfFixture<DotNetCoreEfMigrationAddSettings>
    {
        public string Project { get; set; }

        public string Arguments { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreEfMigrationAdder(FileSystem, Environment, ProcessRunner, Tools);
            tool.Add(Project, Arguments, Settings);
        }
    }
}
