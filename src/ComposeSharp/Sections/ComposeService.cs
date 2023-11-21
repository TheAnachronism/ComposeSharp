namespace ComposeSharp.Sections;

public class ComposeService
{
    public ComposeService(string name, string image, string containerName, string hostName, string[] command)
    {
        Name = name;
        Image = image;
        ContainerName = containerName;
        HostName = hostName;
        Command = command;
    }

    public string Name { get; }
    public string Image { get; }
    public string ContainerName { get; }
    public string HostName { get; }
    public string[] Command { get; }
    
}