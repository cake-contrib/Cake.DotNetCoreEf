using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DotNetCoreEf.Database;
using Cake.DotNetCoreEf.Migration;
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
        ///     var settings = new DotNetCoreEfDatabaseDropSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///     
        ///     DotNetCoreEfDatabaseDrop("./src/Project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseDrop")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseDrop(this ICakeContext context, string project, DotNetCoreEfDatabaseDropSettings settings)
        {
            context.DotNetCoreEfDatabaseDrop(project, null, settings);
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
        ///     var settings = new DotNetCoreEfDatabaseUpdateSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///     
        ///     DotNetCoreEfDatabaseUpdate("./src/Project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("DatabaseUpdate")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Database")]
        public static void DotNetCoreEfDatabaseUpdate(this ICakeContext context, string project, DotNetCoreEfDatabaseUpdateSettings settings)
        {
            context.DotNetCoreEfDatabaseUpdate(project, null, settings);
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

        /// <summary>
        /// Add a migration for the context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfMigrationAdd("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationAdd")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationAdd(this ICakeContext context, string project)
        {
            context.DotNetCoreEfMigrationAdd(project, null, null);
        }

        /// <summary>
        /// Add a migration for the context with project and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationAddSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///     
        ///     DotNetCoreEfMigrationAdd("./src/Project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationAdd")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationAdd(this ICakeContext context, string project, DotNetCoreEfMigrationAddSettings settings)
        {
            context.DotNetCoreEfMigrationAdd(project, null, settings);
        }

        /// <summary>
        /// Add a migration for the context with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationAddSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///
        ///     DotNetCoreEfMigrationAdd("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationAdd")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationAdd(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationAddSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreEfMigrationAddSettings();
            }

            var runner = new DotNetCoreEfMigrationAdder(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Add(project, arguments, settings);
        }

        /// <summary>
        /// Remove migrations for the context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfMigrationRemove("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationRemove")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationRemove(this ICakeContext context, string project)
        {
            context.DotNetCoreEfMigrationRemove(project, null, null);
        }

        /// <summary>
        /// Remove migrations for the context with project and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationRemoveSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///     
        ///     DotNetCoreEfMigrationRemove("./src/Project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationRemove")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationRemove(this ICakeContext context, string project, DotNetCoreEfMigrationRemoveSettings settings)
        {
            context.DotNetCoreEfMigrationRemove(project, null, settings);
        }

        /// <summary>
        /// Remove migrations for the context with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationRemoveSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///
        ///     DotNetCoreEfMigrationRemove("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationRemove")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationRemove(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationRemoveSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreEfMigrationRemoveSettings();
            }

            var runner = new DotNetCoreEfMigrationRemover(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Remove(project, arguments, settings);
        }

        /// <summary>
        /// Script migration for the context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreEfMigrationScript("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationScript")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationScript(this ICakeContext context, string project)
        {
            context.DotNetCoreEfMigrationScript(project, null, null);
        }

        /// <summary>
        /// Script migration for the context with project and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationScriptSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///     
        ///     DotNetCoreEfMigrationScript("./src/Project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationScript")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationScript(this ICakeContext context, string project, DotNetCoreEfMigrationScriptSettings settings)
        {
            context.DotNetCoreEfMigrationScript(project, null, settings);
        }

        /// <summary>
        /// Script migration for the context with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationScriptSettings
        ///     {
        ///         Context = SchoolContext
        ///     };
        ///
        ///     DotNetCoreEfMigrationScript("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationScript")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static void DotNetCoreEfMigrationScript(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationScriptSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreEfMigrationScriptSettings();
            }

            var runner = new DotNetCoreEfMigrationScripter(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Script(project, arguments, settings);
        }

        /// <summary>
        /// List all migrations
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreEfMigrationScriptListerSettings
        ///     {
        ///         Context = SchoolContext,
        ///         StartupProject = "./src/MvcProject",
        ///         NoBuild = true
        ///     };
        ///
        ///     DotNetCoreEfMigrationScript("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MigrationScript")]
        [CakeNamespaceImport("Cake.DotNetCoreEf.Migration")]
        public static string DotNetCoreEfMigrationList(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreEfMigrationListerSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreEfMigrationListerSettings();
            }

            var runner = new DotNetCoreEfMigrationLister(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Script(project, arguments, settings);
        }
    }
}