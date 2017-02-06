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
    public class DotNetCoreEfMigrationAdder : DotNetCoreEfTool<DotNetCoreEfMigrationAddSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreEfMigrationAdder" />.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DotNetCoreEfMigrationAdder(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner,
            IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
            this._environment = environment;
        }

        public void Add(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationAddSettings settings)
        {
            if(settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(project, arguments, settings));
        }

        private ProcessArgumentBuilder GetArguments(string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationAddSettings settings)
        {
            ProcessArgumentBuilder builder = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("migrations");
            builder.Append("add");

            // Specific path?
            if (project != null)
            {
                settings.WorkingDirectory = project;
            }

            if (!string.IsNullOrWhiteSpace(settings.Migration))
            {
                builder.AppendQuoted(settings.Migration);
            }

            if (!string.IsNullOrWhiteSpace(settings.OutputDir))
            {
                builder.Append("--output-dir");
                builder.AppendQuoted(settings.OutputDir);
            }

            if (!string.IsNullOrEmpty(settings.Context))
            {
                builder.Append("--context");
                builder.AppendQuoted(settings.Context);
            }

            if (settings.Json)
            {
                builder.Append("--json");
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
