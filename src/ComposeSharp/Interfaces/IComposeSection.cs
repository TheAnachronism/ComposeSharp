using YamlDotNet.RepresentationModel;

namespace ComposeSharp.Interfaces;

public interface IComposeSection
{
    public YamlMappingNode ToYaml();
}