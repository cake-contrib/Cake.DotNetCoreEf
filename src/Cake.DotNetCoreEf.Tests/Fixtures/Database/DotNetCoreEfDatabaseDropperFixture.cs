using Cake.DotNetCoreEf.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf.Tests.Fixtures.Database
{
    internal sealed class DotNetCoreEfDatabaseDropperFixture : DotNetCoreEfFixture<DotNetCoreEfDatabaseDropSettings>
    {
        public string Project { get; set; }

        public string Arguments { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreEfDatabaseDropper(FileSystem, Environment, ProcessRunner, Tools);
            tool.Drop(Project, Arguments,  Settings);
        }
    }
}
