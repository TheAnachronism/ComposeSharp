using ComposeSharp.Sections;

namespace ComposeSharp.Builders;

public class ComposeServiceBuilder
{
    private readonly string _serviceName;
    private string _image = null!;
    private string? _containerName;
    private string? _hostname;
    private readonly List<string> _dependsOnServices = new();
    private string? _envFile;
    private readonly Dictionary<string, string> _environmentVariables = new();
    private NetworkModes? _networkMode;
    private readonly List<string> _networks = new();
    private readonly Dictionary<string, string> _portMappings = new();
    private RestartMode? _restartMode;

    public ComposeServiceBuilder(string serviceName)
    {
        _serviceName = serviceName;
    }

    public ComposeServiceBuilder WithImage(string image)
    {
        _image = image;
        return this;
    }

    public ComposeServiceBuilder WithContainerName(string containerName)
    {
        _containerName = containerName;
        return this;
    }

    public ComposeServiceBuilder WithHostName(string hostname)
    {
        _hostname = hostname;
        return this;
    }

    public ComposeServiceBuilder DependsOnService(params string[] otherServiceNames)
    {
        _dependsOnServices.AddRange(otherServiceNames);
        return this;
    }

    public ComposeServiceBuilder WithEnvFile(string envFilePath)
    {
        _envFile = envFilePath;
        return this;
    }

    public ComposeServiceBuilder AddEnvironmentVariable(string name, string value)
    {
        _environmentVariables.Add(name, value);
        return this;
    }

    public ComposeServiceBuilder WithNetworkMode(NetworkModes networkMode)
    {
        _networkMode = networkMode;
        return this;
    }

    public ComposeServiceBuilder AddNetwork(string networkName)
    {
        _networks.Add(networkName);
        return this;
    }

    public ComposeServiceBuilder AddPortMapping(int externalPort, int internalPort, string externalFixedIp = "0.0.0.0", bool isUdp = false)
    {
        var protocolSection = isUdp ? "/udp" : string.Empty;
        _portMappings.Add($"{externalFixedIp}:{externalPort}", $"{internalPort}{protocolSection}");
        return this;
    }

    public ComposeServiceBuilder WithRestartMode(RestartMode restartMode)
    {
        _restartMode = restartMode;
        return this;
    }
}