using System.Runtime.InteropServices;
using ComposeSharp.Builders;
using FluentAssertions;

namespace ComposeSharp.Tests;

public class ComposeFileBuilderTests
{
    [Fact]
    public void ComposeFileBuilderConstructor_Should_SetGivenVersionNumber()
    {
        const string testVersion = "3.0";
        
        var builder = new ComposeFileBuilder(testVersion);
        var file = builder.Build();

        file.Version.Should().Be("3.0");
    }

    [Fact]
    public void Test()
    {
        var builder = new ComposeFileBuilder()
            .AddService("postgres", service =>
            {
                service
                    .WithImage("postgres")
                    .WithContainerName("postgres_db")
                    .WithHostName("postgres_db")
                    .WithEnvFile(".env")
                    .AddEnvironmentVariable("TEST", "asdf")
                    .AddEnvironmentVariable("TEST2", "asdf")
                    .WithNetworkMode(NetworkModes.Host)
                    .AddNetwork("my-network")
                    .AddPortMapping(5432, 5432, "127.0.0.1", false);
            });

    }
}