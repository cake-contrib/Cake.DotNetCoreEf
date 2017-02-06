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
    public class DotNetCoreEfMigrationScripter : DotNetCoreEfTool<DotNetCoreEfMigrationScriptSettings>
    {
        private readonly ICakeEnvironment _environment;

        public DotNetCoreEfMigrationScripter(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner, 
            IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
            this._environment = environment;
        }

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
            ProcessArgumentBuilder builder = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("migrations");
            builder.Append("script");

            // Specific path?
            if (project != null)
            {
                settings.WorkingDirectory = project;
            }

            if (!string.IsNullOrWhiteSpace(settings.From))
            {
                builder.AppendQuoted(settings.From);
            }

            if (!string.IsNullOrWhiteSpace(settings.To))
            {
                builder.AppendQuoted(settings.To);
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
