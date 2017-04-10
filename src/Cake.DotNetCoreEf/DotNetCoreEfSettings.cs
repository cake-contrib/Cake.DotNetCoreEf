using Cake.Common.Tools.DotNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf
{
    /// <summary>
    /// Contains common settings used by <see cref="DotNetCoreEfTool{TSettings}" />.
    /// </summary>
    public class DotNetCoreEfSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Show help information
        /// </summary>
        public bool Help { get; set; }

        /// <summary>
        /// The environment to use. If omitted, "Development" is used.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// The startup project to use.
        /// </summary>
        public string StartupProject { get; set; }

        /// <summary>
        /// The project to use.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// The target framework.
        /// </summary>
        public string Framework { get; set; }

        /// <summary>
        /// The configuration to use.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// The MSBuild project extensions path. Defaults to "obj".
        /// </summary>
        public string MsBuildProjectExtensionsPath { get; set; }

        public void SetProject(string project)
        {
            if (string.IsNullOrWhiteSpace(project))
            {
                return;   
            }

            this.WorkingDirectory = project;
        }
    }
}
