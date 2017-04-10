using Cake.Common.Tools.DotNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DotNetCoreEf
{
    /// <summary>
    /// Base class for .NET Core EntityFrameworkCore  tools.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public class DotNetCoreEfTool<TSettings> : DotNetCoreTool<TSettings> where TSettings : DotNetCoreEfSettings
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public DotNetCoreEfTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Creates a <see cref="ProcessArgumentBuilder"/> and adds common commandline arguments.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>Instance of <see cref="ProcessArgumentBuilder"/>.</returns>
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        protected ProcessArgumentBuilder CreateArgumentBuilder(TSettings settings)
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            ProcessArgumentBuilder builder = base.CreateArgumentBuilder(settings);

            if (settings.Help)
            {
                builder.Append("--help");
            }

            if (!string.IsNullOrEmpty(settings.Environment))
            {
                builder.Append("--environment");
                builder.AppendQuoted(settings.Environment);
            }

            if (!string.IsNullOrWhiteSpace(settings.StartupProject))
            {
                builder.Append("--startup-project");
                builder.AppendQuoted(settings.StartupProject);
            }

            if (!string.IsNullOrWhiteSpace(settings.Project))
            {
                builder.Append("--project");
                builder.AppendQuoted(settings.Project);
            }

            if (!string.IsNullOrWhiteSpace(settings.Configuration))
            {
                builder.Append("--configuration");
                builder.AppendQuoted(settings.Configuration);
            }
            if (!string.IsNullOrWhiteSpace(settings.Framework))
            {
                builder.Append("--framework");
                builder.AppendQuoted(settings.Framework);
            }

            if (!string.IsNullOrWhiteSpace(settings.MsBuildProjectExtensionsPath))
            {
                builder.Append("--msbuildprojectextensionspath");
                builder.AppendQuoted(settings.MsBuildProjectExtensionsPath);
            }


            return builder;
        }
    }
}
