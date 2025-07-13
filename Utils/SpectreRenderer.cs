using PCCore.NOVA_HardwareInfo.Models;
using Spectre.Console;

namespace PCCore.NOVA_CLI.Utils;

internal static class SpectreRenderer
{
    internal static void ShowGreeting()
    {
        AnsiConsole.Write(
            new FigletText("Nova-CLI")
                .LeftJustified()
                .Color(Color.Red));

        AnsiConsole.MarkupLine("[grey]Nova CLI v1.0[/]");
    }

    internal static void DisplayCpuInfo(CpuInfo cpu)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .Title("[bold yellow3]== CPU Information ==[/]")
            .Centered();

        table.AddColumn(new TableColumn("[bold green]Property[/]").Centered());
        table.AddColumn(new TableColumn("[bold deepskyblue1]Value[/]").Centered());

        // Zebra effect with color alternation
        var rows = new List<(string, string)>
    {
        ("[blue]Name[/]", $"[white]{cpu.Name}[/]"),
        ("[blue]Manufacturer[/]", $"[white]{cpu.Manufacturer}[/]"),
        ("[blue]Physical Cores[/]", $"[white]{cpu.PhysicalCores}[/]"),
        ("[blue]Logical Cores[/]", $"[white]{cpu.LogicalCores}[/]"),
        ("[blue]Max Clock Speed[/] [dim](MHz)[/]", $"[white]{cpu.MaxClockSpeedMHz}[/]")
    };

        bool shaded = false;
        foreach (var (label, value) in rows)
        {
            if (shaded)
            {
                table.AddRow($"[black]{label}[/]", $"[black]{value}[/]");
            }
            else
            {
                table.AddRow(label, value);
            }

            shaded = !shaded;
        }


        AnsiConsole.Write(new Panel(table)
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Orange1))
            .Header("[bold orange1]> System .[/]", Justify.Center)
            .Padding(1, 1, 1, 1));
    }

    internal static void DisplayRamInfo(IEnumerable<RamInfo> ramModules)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .Title("[bold yellow3]== RAM Information ==[/]")
            .Centered();

        table.AddColumn(new TableColumn("[bold green]Slot[/]").Centered());
        table.AddColumn(new TableColumn("[bold green]Manufacturer[/]").Centered());
        table.AddColumn(new TableColumn("[bold green]Part Number[/]").Centered());
        table.AddColumn(new TableColumn("[bold green]Serial Number[/]").Centered());
        table.AddColumn(new TableColumn("[bold green]Capacity (MB)[/]").Centered());
        table.AddColumn(new TableColumn("[bold green]Speed (MHz)[/]").Centered());

        int index = 1;
        foreach (var ram in ramModules)
        {
            table.AddRow(
                $"#{index}",
                Markup.Escape(ram.Manufacturer ?? "N/A"),
                Markup.Escape(ram.PartNumber ?? "N/A"),
                Markup.Escape(ram.SerialNumber ?? "N/A"),
                ram.CapacityMB.ToString(),
                ram.SpeedMHz.ToString()
            );

            index++;
        }

        AnsiConsole.Write(new Panel(table)
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Orange1))
            .Header("[bold orange1]> Memory .[/]", Justify.Center)
            .Padding(1, 1, 1, 1));
    }


}
