namespace Cake.DotNetCoreEf.Database
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreEfDatabaseUpdater"/>
    /// </summary>
    public class DotNetCoreEfDatabaseUpdateSettings : DotNetCoreEfSettings
    {
        /// <summary>
        /// The DbContext to use. If omitted, the default DbContext is used
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// The target migration. If '0', all migrations will be reverted. If omitted, all pending migrations will be applied
        /// </summary>
        public string Migration { get; set; }  
    }
}
