using Spectre.Console.Cli;

namespace NOVA_CLI.Settings;

class SystemInformationSettings : CommandSettings
{
    [CommandArgument(0, "<info>")]
    public string Info { get; set; } = "all";

}
