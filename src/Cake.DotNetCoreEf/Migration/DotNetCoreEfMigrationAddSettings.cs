using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf.Migration
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreEfMigrationAdder"/>.
    /// </summary>
    public class DotNetCoreEfMigrationAddSettings : DotNetCoreEfSettings
    {
        /// <summary>
        /// The DbContext to use. If omitted, the default DbContext is used.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// The directory (and sub-namespace) to use. If omitted, "Migrations" is used. Relative paths are relative the directory in which the command is executed.
        /// </summary>
        public string OutputDir { get; set; }

        /// <summary>
        /// Use json output. JSON is wrapped by '//BEGIN' and '//END'
        /// </summary>
        public bool Json { get; set; }

        public string Migration { get; set; }
    }
}
