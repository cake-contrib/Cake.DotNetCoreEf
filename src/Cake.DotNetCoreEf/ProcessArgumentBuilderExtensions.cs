using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf
{
    public static class ProcessArgumentBuilderExtensions
    { 
        public static void AppendBuilder(this ProcessArgumentBuilder builder, ProcessArgumentBuilder arguments)
        {
            foreach (IProcessArgument argument in arguments)
            {
                builder.Append(argument);
            }
        }

        public static void SetContextSettings(this ProcessArgumentBuilder builder, ProcessArgumentBuilder arguments, string project, DotNetCoreEfContextSettings settings)
        {
            settings.SetProject(project);

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
        }
    }
}
