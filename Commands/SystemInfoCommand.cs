using NOVA_CLI.Utils;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NOVA_CLI.Commands;

internal class SystemInfoCommand : AsyncCommand<SystemInfoCommand.Settings>
{


    internal class Settings : CommandSettings
    {
        [CommandArgument(0, "<info>")]
        public string Info { get; set; } = "all";

    }
    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var hardwareInfo = new HardwareInfo();

        switch (settings.Info.ToLower())
        {
            case "info":
                await LoadingUtils.WithSpinnerAsync("Fetching system info...", async () =>
                {
                    await Task.Run(() =>
                    {
                        hardwareInfo.RefreshCPUList();
                        hardwareInfo.RefreshMemoryStatus();
                        hardwareInfo.RefreshOperatingSystem();
                    });

                    ShowCpuInfo(hardwareInfo);
                    ShowOsInfo(hardwareInfo);
                    ShowRamInfo(hardwareInfo);
                });
                break;

            case "cpu":
                await LoadingUtils.WithSpinnerAsync("Fetching CPU info...", async () =>
                {
                    await Task.Run(() => hardwareInfo.RefreshCPUList());
                    ShowCpuInfo(hardwareInfo);
                });
                break;

            case "ram":
                await LoadingUtils.WithSpinnerAsync("Fetching RAM info...", async () =>
                {
                    await Task.Run(() => hardwareInfo.RefreshMemoryStatus());
                    ShowRamInfo(hardwareInfo);
                });
                break;

            case "os":
                await LoadingUtils.WithSpinnerAsync("Fetching OS info...", async () =>
                {
                    await Task.Run(() => hardwareInfo.RefreshOperatingSystem());
                    ShowOsInfo(hardwareInfo);
                });
                break;

            default:
                ShowUnkownTypeMessage(settings.Info);
                break;
        }

        return 0;
    }

    private void ShowCpuInfo(HardwareInfo hardwareInfo)
    {
        var cpu = hardwareInfo.CpuList[0];
        AnsiConsole.MarkupLine($"[bold yellow]CPU:[/] {cpu.Name}");
        AnsiConsole.MarkupLine($"[yellow]Cores:[/] {cpu.NumberOfCores}");
        AnsiConsole.MarkupLine($"[yellow]Threads:[/] {cpu.NumberOfLogicalProcessors}");
    }

    private void ShowRamInfo(HardwareInfo hardwareInfo)
    {
        var memory = hardwareInfo.MemoryStatus;
        AnsiConsole.MarkupLine($"[bold yellow]RAM:[/] Total: {memory.TotalPhysical / 1024 / 1024} MB");
        AnsiConsole.MarkupLine($"[yellow]Available:[/] {memory.AvailablePhysical / 1024 / 1024} MB");
    }

    private void ShowOsInfo(HardwareInfo hardwareInfo)
    {
        var os = hardwareInfo.OperatingSystem;
        AnsiConsole.MarkupLine($"[bold yellow]OS:[/] {os.Name} {os.Version}");
    }

    private void ShowUnkownTypeMessage(string message)
    {
        AnsiConsole.MarkupLine($"[red]Unknown type:[/] '{message}'. Use [green]cpu[/], [green]ram[/], [green]os[/], or [green]info[/].");
    }
}
