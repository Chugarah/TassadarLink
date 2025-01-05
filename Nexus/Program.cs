using Core.Factories;
using Core.Helpers;
using Core.Interface;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Interfaces;
using Nexus.Views;

namespace Nexus;

internal static class Program
{
    private static void Main()
    {
        // Setting Upp Dependency Injection DI
        // https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
        // https://www.c-sharpcorner.com/article/using-dependency-injection-in-net-console-apps/
        var services = new ServiceCollection();
        ConfigureServices(services);

        // Let's build the service Provider
        var serviceProvider = services.BuildServiceProvider();

        // Now we can get the HomeView and run i
        var homeView = serviceProvider.GetRequiredService<IHomeView>();
        homeView.Run();
    }
    // https://stackoverflow.com/questions/32459670/resolving-instances-with-asp-net-core-di-from-within-configureservices
    // IServiceCollection interface is used for building our dependency injection container
    private static void ConfigureServices(IServiceCollection services)
    {
        // Registering we are using AddSingleton when we need a single state
        // We want to maintain our state a cross our application
        services.AddSingleton<IHomeView, HomeView>();
        services.AddSingleton<IMenuFactory, MenuFactory>();
        services.AddSingleton<IIdHelpers, IdHelpers>();

        // Registering the MenuService
        services.AddSingleton<IMenuCreateService, MenuService>();
        services.AddSingleton<IGetMenuService, MenuService>();
    }

}