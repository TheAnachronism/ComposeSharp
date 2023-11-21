using ComposeSharp.Interfaces;
using YamlDotNet.RepresentationModel;

namespace ComposeSharp.Sections;

public class ComposeFile : IComposeSection
{
    public string Version { get; }

    public ComposeFile(string composeVersion)
    {
        Version = composeVersion;
    }

    public YamlMappingNode ToYaml()
    {
        throw new NotImplementedException();
    }
}