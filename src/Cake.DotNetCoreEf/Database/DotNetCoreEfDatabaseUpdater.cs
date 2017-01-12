using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DotNetCoreEf.Database
{
    /// <summary>
    /// Support for updating the database using .NET Core cli tooling
    /// </summary>
    public class DotNetCoreEfDatabaseUpdater : DotNetCoreEfTool<DotNetCoreEfDatabaseUpdateSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreEfDatabaseUpdater" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DotNetCoreEfDatabaseUpdater(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner, 
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs the project using the specified path with arguments and settings.
        /// </summary>
        /// <param name="project">The target project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        public void Update(string project, ProcessArgumentBuilder arguments, DotNetCoreEfDatabaseUpdateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(project, arguments, settings));
        }

        private ProcessArgumentBuilder GetArguments(string project, ProcessArgumentBuilder arguments, DotNetCoreEfDatabaseUpdateSettings settings)
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("database");
            builder.Append("drop");

            // Specific path?
            if (project != null)
            {
                settings.WorkingDirectory = project;
            }

            if (!string.IsNullOrEmpty(settings.Context))
            {
                builder.Append("--context");
                builder.AppendQuoted(settings.Context);
            }

            if (!string.IsNullOrWhiteSpace(settings.Migration))
            {
                builder.AppendQuoted(settings.Migration);
            }

            // Arguments
            if (!arguments.IsNullOrEmpty())
            {
                builder.Append("--");
                arguments.CopyTo(builder);
            }

            return builder;
        }
    }
}
