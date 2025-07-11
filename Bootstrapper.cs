using Microsoft.Extensions.DependencyInjection;
using PCCore.NOVA_CLI.Config;
using PCCore.NOVA_HardwareInfo.Contracts;
using PCCore.NOVA_HardwareInfo.InfoProvider;

internal class Bootstrapper
{
    public static IServiceCollection CreateServiceCollection()
    {
        var services = new ServiceCollection();

        services.AddSingleton<AppConfiguration>();
        services.AddTransient<IHardwareInfoProvider, WindowsHardwareInfoProvider>();

        return services;
    }
}
