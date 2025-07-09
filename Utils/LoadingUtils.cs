using Spectre.Console;

namespace NOVA_CLI.Utils;

internal static class LoadingUtils
{
    public static async Task WithSpinnerAsync(string message, Func<Task> action)
    {
        await AnsiConsole.Status()
         .Spinner(Spinner.Known.Dots5)
         .SpinnerStyle(Style.Parse("green"))
         .StartAsync(message, async ctx =>
         {
             await action();
         });
    }
}
