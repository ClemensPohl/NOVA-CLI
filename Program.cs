namespace PCCore.NOVA_CLI;
internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var services = Bootstrapper.CreateServiceCollection();
        var cli = new NovaCLI(services);
        return await cli.RunAsync(args);

    }
}