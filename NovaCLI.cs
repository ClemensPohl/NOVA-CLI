using NOVA_CLI.Commands;
using Spectre.Console.Cli;

namespace NOVA_CLI;
public class NovaCLI
{
    private readonly CommandApp _app;

    public NovaCLI()
    {
        _app = new CommandApp();
        _app.Configure(config =>
        {
            config.AddCommand<SystemInfoCommand>("sys");

            
        });
    }

    public Task<int> RunAsync(string[] args) => _app.RunAsync(args);
}
