using Microsoft.Extensions.DependencyInjection;
using NOVA_CLI.Config;

namespace NOVA_CLI;

internal class Bootstrapper
{
    public static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddSingleton<AppConfiguration>();
        services.AddSingleton<NovaCLI>();

        return services.BuildServiceProvider();
    }

}
