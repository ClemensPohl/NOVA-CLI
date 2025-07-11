using System.Text;


namespace PCCore.NOVA_CLI.Config;

internal class AppConfiguration
{
    public Encoding OutputEncoding { get; set; } = Encoding.UTF8;

    public void LoadDefaultConfig()
    {
        Console.OutputEncoding = OutputEncoding;
    }
}
