using Cake.Common.Tools.DotNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf.Database
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreEfDatabaseDropper"/>
    /// </summary>
    public class DotNetCoreEfDatabaseDropSettings : DotNetCoreEfSettings
    {       
        /// <summary>
        /// The DbContext to use. If omitted, the default DbContext is used
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Drop without confirmation
        /// </summary>
        public bool Force { get; set; }
    }
}
