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
    /// Contains settings used by <see cref="DotNetCoreEfMigrationRemover"/>.
    /// </summary>
    public class DotNetCoreEfMigrationRemover : DotNetCoreEfTool<DotNetCoreEfMigrationRemoveSettings>
    {
        private readonly ICakeEnvironment _environment;

        public DotNetCoreEfMigrationRemover(
            IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IProcessRunner processRunner, 
            IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
            this._environment = environment;
        }

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
            ProcessArgumentBuilder builder = CreateArgumentBuilder(settings);

            builder.Append("ef");
            builder.Append("migrations");
            builder.Append("remove");

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

            if (settings.Force)
            {
                builder.Append("--force");
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
