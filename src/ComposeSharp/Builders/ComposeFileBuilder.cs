using ComposeSharp.Sections;

namespace ComposeSharp.Builders;

public class ComposeFileBuilder
{
    private readonly string _composeVersion;
    private readonly Dictionary<string, Action<ComposeServiceBuilder>> _serviceBuilders = new();

    public ComposeFileBuilder(string  composeVersion = "3")
    {
        _composeVersion = composeVersion;
    }

    public ComposeFileBuilder AddService(string name, Action<ComposeServiceBuilder> serviceBuilder)
    {
        _serviceBuilders.Add(name, serviceBuilder);
        return this;
    }

    public ComposeFile Build()
    {
        var composeFile = new ComposeFile(_composeVersion);

        return composeFile;
    }
}