using PCCore.NOVA_HardwareInfo.Contracts;
using Spectre.Console.Cli;

namespace PCCore.NOVA_CLI.Commands;

internal class SystemInfoCommand : AsyncCommand<SystemInfoCommand.Settings>
{

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<info>")]
        public string Info { get; set; } = "all";
    }

    private readonly IHardwareInfoProvider _hardwareInfoProvider;

    public SystemInfoCommand(IHardwareInfoProvider hardwareInfoProvider)
    {
        _hardwareInfoProvider = hardwareInfoProvider;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var cpuName = await _hardwareInfoProvider.GetCPUName();
        Console.WriteLine(cpuName);
        return 0;
    }

    
}
