

using Spectre.Console;

namespace NOVA_CLI;

public static class Startup
{
    public static void ShowGreeting()
    {
        AnsiConsole.Write(new FigletText("Nova-CLI").Color(Color.Cyan1));
        AnsiConsole.MarkupLine("[grey]Nova CLI v1.0[/]");

        AnsiConsole.WriteLine();
    }
}
