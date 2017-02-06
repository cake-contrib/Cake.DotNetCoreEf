﻿using Cake.DotNetCoreEf.Tests.Fixtures.Migration;
using Cake.Testing;
using Xunit;

namespace Cake.DotNetCoreEf.Tests.Unit.Migration
{
    public sealed class DotNetCoreEfMigrationRemoverTests
    {
       
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationRemoverFixture();
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
            var fixture = new DotNetCoreEfMigrationRemoverFixture();
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
            var fixture = new DotNetCoreEfMigrationRemoverFixture();
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
            var fixture = new DotNetCoreEfMigrationRemoverFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef migrations remove", result.Args);
        }

        [Fact]
        public void Should_Add_Path_Arguments()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationRemoverFixture();
            fixture.Project = "./tools/tool/";
            fixture.Arguments = "--args=\"value\"";
            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef migrations remove --args=\"value\"", result.Args);
            Assert.Equal("/Working/tools/tool", result.Process.WorkingDirectory.FullPath);
        }

        [Fact]
        public void Should_Add_Additional_Settings()
        {
            // Given
            var fixture = new DotNetCoreEfMigrationRemoverFixture();
            fixture.Settings.Context = "CakeContext";
            fixture.Settings.Force = true;
            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ef migrations remove --context \"CakeContext\" --force", result.Args);
        }
    }
}
