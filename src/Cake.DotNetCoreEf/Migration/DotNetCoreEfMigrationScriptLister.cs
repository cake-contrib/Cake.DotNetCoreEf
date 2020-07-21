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
    public class DotNetCoreEfMigrationScriptLister : DotNetCoreEfTool<DotNetCoreEfMigrationScriptListerSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreEfMigrationScriptLister" />.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DotNetCoreEfMigrationScriptLister(
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
        public void Script(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationScriptListerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(project, arguments, settings));
        }

        private ProcessArgumentBuilder GetArguments(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationScriptListerSettings settings)
        {
            ProcessArgumentBuilder builder = new ProcessArgumentBuilder();
            ProcessArgumentBuilder builderArguments = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("migrations");
            builder.Append("script");
            builder.Append("list");

            settings.SetProject(project);

            if (!string.IsNullOrWhiteSpace(settings.From))
            {
                builder.AppendQuoted(settings.From);
            }

            if (!string.IsNullOrWhiteSpace(settings.To))
            {
                builder.AppendQuoted(settings.To);
            }

            if (!string.IsNullOrWhiteSpace(settings.Project))
            {
                builder.Append("--project");
                builder.AppendQuoted(settings.Project);
            }

            if (!string.IsNullOrWhiteSpace(settings.StartupProject))
            {
                builder.Append("--startup-project");
                builder.AppendQuoted(settings.StartupProject);
            }

            if (settings.PrefixOutput)
            {
                builder.Append("--prefix-output");
            }

            if (settings.NoBuild)
            {
                builder.Append("--no-build");
            }

            // return json output
            builder.Append("--json");

            // Arguments
            if (!arguments.IsNullOrEmpty())
            {
                arguments.CopyTo(builder);
            }

            return builder;
        }
    }
}