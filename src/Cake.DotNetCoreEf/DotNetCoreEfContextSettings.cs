namespace Cake.DotNetCoreEf
{
    public class DotNetCoreEfContextSettings : DotNetCoreEfSettings
    {
        /// <summary>
        /// The DbContext to use. If omitted, the default DbContext is used.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Removes the last migration without checking the database. If the last migration has been applied to the database, you will need to manually reverse the changes it made
        /// </summary>
        public bool Force { get; set; }
    }
}
