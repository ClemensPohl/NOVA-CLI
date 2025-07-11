using Spectre.Console;

namespace NOVA_CLI.Utils;

internal static class Startup
{
    internal static void ShowGreeting()
    {
        AnsiConsole.Write(new FigletText("Nova-CLI").Color(Color.Cyan1));
        AnsiConsole.MarkupLine("[grey]Nova CLI v1.0[/]");
    }
}
