using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DotNetCoreEf.Migration
{
    /// <summary>
    /// Support for removing migrations using .NET CLI tooling
    /// </summary>
    public class DotNetCoreEfMigrationRemover : DotNetCoreEfTool<DotNetCoreEfMigrationRemoveSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreEfMigrationRemover" />.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DotNetCoreEfMigrationRemover(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner, 
            IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
            this._environment = environment;
        }

        /// <summary>
        /// Remove migrations for the project using the specified path with arguments and settings.
        /// </summary>
        /// <param name="project">The target project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        public void Remove(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationRemoveSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(project, arguments, settings));
        }

        private ProcessArgumentBuilder GetArguments(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationRemoveSettings settings)
        {
            ProcessArgumentBuilder builder = new ProcessArgumentBuilder();
            ProcessArgumentBuilder builderArguments = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("migrations");
            builder.Append("remove");

            builder.AppendBuilder(builderArguments);

            builder.SetContextSettings(arguments, project, settings);

            return builder;
        }
    }
}
