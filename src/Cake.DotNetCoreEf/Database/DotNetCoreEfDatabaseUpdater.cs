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
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreEfDatabaseUpdater" />.
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
            this._environment = environment;
        }

        /// <summary>
        /// Update the database for the project using the specified path with arguments and settings.
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
            ProcessArgumentBuilder builder = new ProcessArgumentBuilder();
            ProcessArgumentBuilder builderArguments = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("database");
            builder.Append("update");

            settings.SetProject(project);

            if (!string.IsNullOrWhiteSpace(settings.Migration))
            {
                builder.AppendQuoted(settings.Migration);
            }

            foreach (IProcessArgument argument in builderArguments)
            {
                builder.Append(argument);
            }

            if (!string.IsNullOrEmpty(settings.Context))
            {
                builder.Append("--context");
                builder.AppendQuoted(settings.Context);
            }

            // Arguments
            if (!arguments.IsNullOrEmpty())
            {
                arguments.CopyTo(builder);
            }

            return builder;
        }
    }
}
