using Microsoft.Extensions.DependencyInjection;
using NOVA_CLI.Config;

namespace NOVA_CLI;
internal class Program
{
    static async Task<int> Main(string[] args)
    {
        var serviceProvider = Bootstrapper.CreateServiceProvider();

        // Load App Default Config
        var config = serviceProvider.GetRequiredService<AppConfiguration>();
        config.LoadDefaultConfig();


        NovaCLI app = serviceProvider.GetRequiredService<NovaCLI>();
        return await app.RunAsync(args);

    }
}