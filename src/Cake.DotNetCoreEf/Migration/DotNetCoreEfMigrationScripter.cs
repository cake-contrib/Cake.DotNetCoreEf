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
    /// Support for script migrations using .NET Core cli tooling
    /// </summary>
    public class DotNetCoreEfMigrationScripter : DotNetCoreEfTool<DotNetCoreEfMigrationScriptSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreEfMigrationScripter" />.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DotNetCoreEfMigrationScripter(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner, 
            IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
            this._environment = environment;
        }

        /// <summary>
        /// Script migrations for the project using the specified path with arguments and settings.
        /// </summary>
        /// <param name="project">The target project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        public void Script(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationScriptSettings settings)
        {
            if(settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(project, arguments, settings));
        }

        private ProcessArgumentBuilder GetArguments(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationScriptSettings settings)
        {
            ProcessArgumentBuilder builder = new ProcessArgumentBuilder();
            ProcessArgumentBuilder builderArguments = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("migrations");
            builder.Append("script");

            settings.SetProject(project);

            if (!string.IsNullOrWhiteSpace(settings.From))
            {
                builder.AppendQuoted(settings.From);
            }

            if (!string.IsNullOrWhiteSpace(settings.To))
            {
                builder.AppendQuoted(settings.To);
            }

            foreach (IProcessArgument argument in builderArguments)
            {
                builder.Append(argument);
            }

            if (!string.IsNullOrWhiteSpace(settings.Output))
            {
                builder.Append("--output");
                builder.AppendQuoted(settings.Output);
            }

            if (!string.IsNullOrEmpty(settings.Context))
            {
                builder.Append("--context");
                builder.AppendQuoted(settings.Context);
            }

            if (settings.Idempotent)
            {
                builder.Append("--idempotent");
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
