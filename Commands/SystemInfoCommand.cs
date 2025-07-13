using PCCore.NOVA_CLI.Utils;
using PCCore.NOVA_HardwareInfo.Contracts;
using PCCore.NOVA_HardwareInfo.Models;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace PCCore.NOVA_CLI.Commands;

internal class SystemInfoCommand : AsyncCommand<SystemInfoCommand.Settings>
{
    private readonly IHardwareInfoProvider _hardwareInfoProvider;

    public SystemInfoCommand(IHardwareInfoProvider hardwareInfoProvider)
    {
        _hardwareInfoProvider = hardwareInfoProvider;
    }
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<type>")]
        [Description("The type of system information to display (e.g., cpu, memory, os)")]
        public string Type { get; set; } = "cpu";

    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        switch (settings.Type.ToLowerInvariant())
        {
            case "cpu":
                var cpuInfo = await _hardwareInfoProvider.GetCpuInfoAsync();
                SpectreRenderer.DisplayCpuInfo(cpuInfo);
                break;
            case "ram":
                AnsiConsole.MarkupLine("[grey]Fetching RAM info...[/]");
                var ramInfo = await _hardwareInfoProvider.GetRamInfoAsync();
                SpectreRenderer.DisplayRamInfo(ramInfo);
                break;
            default:
                AnsiConsole.MarkupLine($"[red]Unknown type:[/] '{settings.Type}'. Use [green]cpu[/], [green]ram[/], [green]os[/], or [green]info[/].");
                break;
        }

        return 0;
    }

    




}
