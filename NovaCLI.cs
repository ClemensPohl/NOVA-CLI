using NOVA_CLI.Commands;
using NOVA_CLI.Utils;
using Spectre.Console;
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

    public async Task<int> RunAsync(string[] args)
    {
        Startup.ShowGreeting();

        while(true)
        {
            var input = AnsiConsole.Ask<string>("[cyan1]> [/]");

            // prevents processing blank lines!
            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (input.Equals("cls", StringComparison.OrdinalIgnoreCase) || input.Equals("clear", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                continue;
            }

            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                await _app.RunAsync(inputArgs);
            }catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
                return 1;
            }
        }

        return 0;
    }
}
