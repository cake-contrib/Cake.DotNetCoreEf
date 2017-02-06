using Cake.DotNetCoreEf.Migration;

namespace Cake.DotNetCoreEf.Tests.Fixtures.Migration
{
    internal sealed class DotNetCoreEfMigrationRemoverFixture : DotNetCoreEfFixture<DotNetCoreEfMigrationRemoveSettings>
    {
        public string Project { get; set; }

        public string Arguments { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreEfMigrationRemover(FileSystem, Environment, ProcessRunner, Tools);
            tool.Remove(Project, Arguments, Settings);
        }
    }
}
