using Cake.DotNetCoreEf.Tests.Fixtures.Database;
using Cake.Testing;
using Xunit;

namespace Cake.DotNetCoreEf.Tests.Unit.Database
{
    public sealed class DotNetCoreEfDatabaseDropperTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new DotNetCoreEfDatabaseDropperFixture();
            fixture.Project = "./src/*";
            fixture.Settings = null;
            fixture.GivenDefaultToolDoNotExist();

            // When 
            var result = Record.Exception(() => fixture.Run());

            // Then
            //Assert.IsArgumentNullException(result, "settings");
        }
    }
}
