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
            fixture.Project = "./src/";
            fixture.Settings = null;
            fixture.GivenDefaultToolDoNotExist();

            // When 
            var result = Record.Exception(() => fixture.Run());

            // Then
            AssertExtensions.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_Process_Was_Not_Started()
        {
            // Given
            var fixture = new DotNetCoreEfDatabaseDropperFixture();
            fixture.Project = "./src/";
            fixture.GivenProcessCannotStart();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            AssertExtensions.IsCakeException(result, ".NET Core CLI: Process was not started.");
        }

        [Fact]
        public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
        {
            // Given
            var fixture = new DotNetCoreEfDatabaseDropperFixture();
            fixture.Project = "./src/";
            fixture.GivenProcessExitsWithCode(1);

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            AssertExtensions.IsCakeException(result, ".NET Core CLI: Process returned an error (exit code 1).");
        }

        [Fact]
        public void Should_Add_Mandatory_Arguments()
        {
            // Given
            var fixture = new DotNetCoreEfDatabaseDropperFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef database drop", result.Args);
        }

        [Fact]
        public void Should_Add_Path_Arguments()
        {
            // Given
            var fixture = new DotNetCoreEfDatabaseDropperFixture();
            fixture.Project = "./tools/tool/";
            fixture.Arguments = "--args=\"value\"";
            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef database drop --args=\"value\"", result.Args);
            Assert.Equal("/Working/tools/tool", result.Process.WorkingDirectory.FullPath);
        }

        [Fact]
        public void Should_Add_Additional_Settings()
        {
            // Given
            var fixture = new DotNetCoreEfDatabaseDropperFixture();
            fixture.Settings.Context = "CakeContext";
            fixture.Settings.Force = true;
            fixture.Settings.Configuration = "release";
            fixture.Settings.MsBuildProjectExtensionsPath = "test-obj";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef database drop --configuration \"release\" --msbuildprojectextensionspath \"test-obj\" --context \"CakeContext\" --force", result.Args);
        }
    }
}
