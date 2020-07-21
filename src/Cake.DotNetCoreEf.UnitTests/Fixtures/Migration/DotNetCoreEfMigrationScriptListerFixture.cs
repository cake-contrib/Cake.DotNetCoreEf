using Cake.DotNetCoreEf.Migration;

namespace Cake.DotNetCoreEf.Tests.Fixtures.Migration
{
    internal sealed class DotNetCoreEfMigrationScriptListerFixture : DotNetCoreEfFixture<DotNetCoreEfMigrationScriptListerSettings>
    {
        public string Project { get; set; }

        public string Arguments { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreEfMigrationScriptLister(FileSystem, Environment, ProcessRunner, Tools);
            tool.Script(Project, Arguments, Settings);
        }
    }
}