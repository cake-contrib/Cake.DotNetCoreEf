using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DotNetCoreEf.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.DotNetCoreEf
{
    [CakeAliasCategory("DotNetCoreEf")]
    public static class DotNetCoreEfAliases
    {
        /// <summary>
        /// Drop the database with path.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfDatabaseDrop("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseDrop")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseDrop(this ICakeContext context, string project)
        {
            context.DotNetCoreEfDatabaseDrop(project, null, null);
        }

        /// <summary>
        /// Drop the database with path and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfDatabaseDrop("./src/Project", "--args");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseDrop")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseDrop(this ICakeContext context, string project, ProcessArgumentBuilder arguments)
        {
            context.DotNetCoreEfDatabaseDrop(project, arguments, null);
        }

        /// <summary>
        /// Drop the database with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfDatabaseDropSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///
        ///     DotNetCoreEfDatabaseDrop("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseDrop")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseDrop(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreEfDatabaseDropSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreEfDatabaseDropSettings();
            }

            var runner = new DotNetCoreEfDatabaseDropper(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Drop(project, arguments, settings);
        }

        /// <summary>
        /// Update the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfDatabaseUpdate("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseDrop")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseUpdate(this ICakeContext context, string project)
        {
            context.DotNetCoreEfDatabaseUpdate(project, null, null);
        }

        /// <summary>
        /// Update the database with project and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfDatabaseUpdate("./src/Project", "--args");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseUpdate")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseUpdate(this ICakeContext context, string project, ProcessArgumentBuilder arguments)
        {
            context.DotNetCoreEfDatabaseUpdate(project, arguments, null);
        }

        /// <summary>
        /// Update the database with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfDatabaseUpdateSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///
        ///     DotNetCoreEfDatabaseUpdate("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseUpdate")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseUpdate(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreEfDatabaseUpdateSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreEfDatabaseUpdateSettings();
            }

            var runner = new DotNetCoreEfDatabaseUpdater(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Update(project, arguments, settings);
        }
    }
}