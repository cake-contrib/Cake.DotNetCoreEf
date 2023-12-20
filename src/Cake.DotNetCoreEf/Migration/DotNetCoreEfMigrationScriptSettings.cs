﻿namespace Cake.DotNetCoreEf.Migration
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreEfMigrationScripter"/>.
    /// </summary>
    public class DotNetCoreEfMigrationScriptSettings : DotNetCoreEfSettings
    {
        /// <summary>
        /// The starting migration. If omitted, '0' (the initial database) is used.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The ending migration. If omitted, the last migration is used.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The file to write the script to instead of stdout.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Generates an idempotent script that can used on a database at any migration.
        /// </summary>
        public bool Idempotent { get; set; }

        /// <summary>
        /// The DbContext to use. If omitted, the default DbContext is used.
        /// </summary>
        public string Context { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to not to build the project before publishing.
        /// This makes build faster, but requires build to be done before publish is executed. 
        /// </summary>
        public bool NoBuild { get; set; }
    }
}
