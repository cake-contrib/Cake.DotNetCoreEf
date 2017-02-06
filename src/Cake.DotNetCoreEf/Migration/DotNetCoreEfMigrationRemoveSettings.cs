using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf.Migration
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreEfMigrationRemover"/>.
    /// </summary>
    public class DotNetCoreEfMigrationRemoveSettings : DotNetCoreEfSettings
    {
        /// <summary>
        /// The DbContext to use. If omitted, the default DbContext is used.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Removes the last migration without checking the database. If the last migration has been applied to the database, you will need to manually reverse the changes it made
        /// </summary>
        public bool Force { get; set; }
    }
}
