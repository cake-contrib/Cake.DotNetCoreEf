using Cake.DotNetCoreEf.Tests.Fixtures.Migration;
using Cake.Testing;
using Xunit;

namespace Cake.DotNetCoreEf.Tests.Unit.Migration
{
    public sealed class DotNetCoreEfMigrationScriptListerTests
    {

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationListerFixture();
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
            var fixture = new DotNetCoreEfMigrationListerFixture();
            fixture.Project = "./src/";
            fixture.GivenProcessCannotStart();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            AssertExtensions.IsCakeException(result, ".NET Core CLI: Process was not started.");
        }

        // Removed. Process returns json
        //[Fact]
        //public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
        //{
        //    // Given
        //    var fixture = new DotNetCoreEfMigrationScriptListerFixture();
        //    fixture.Project = "./src/";
        //    fixture.GivenProcessExitsWithCode(1);

        //    // When
        //    var result = Record.Exception(() => fixture.Run());

        //    // Then
        //    AssertExtensions.IsCakeException(result, ".NET Core CLI: Process returned an error (exit code 1).");
        //}

        [Fact]
        public void Should_Add_Mandatory_Arguments()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationListerFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef migrations list --no-build --json", result.Args);
        }

        [Fact]
        public void Should_Add_Path_Arguments()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationListerFixture();
            fixture.Project = "./tools/tool/";
            fixture.Arguments = "--args=\"value\"";
            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef migrations list --no-build --json --args=\"value\"", result.Args);
            Assert.Equal("/Working/tools/tool", result.Process.WorkingDirectory.FullPath);
        }

        [Fact]
        public void Should_Add_Additional_Settings()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationListerFixture();
            fixture.Settings.StartupProject = "./src/MyMvcProject";
            fixture.Settings.Project = "./src/MyDataProject";
            fixture.Settings.Configuration = "release";
            fixture.Settings.PrefixOutput = true;
            fixture.Settings.NoBuild = true;
            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef migrations list --project \"./src/MyDataProject\" --startup-project \"./src/MyMvcProject\" --prefix-output --no-build --json", result.Args);
        }
    }
}