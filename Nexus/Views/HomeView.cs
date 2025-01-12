using Nexus.Interfaces;

namespace Nexus.Views;

public class HomeView(IMenuNavigationService menuNavigationService) : IHomeView
{
    /// <summary>
    /// Run the HomeView
    /// </summary>
    public async Task Run()
    {
        Console.Clear();
        Console.WriteLine("===================================== Tassadar Link System =====================================");
        Console.WriteLine("Welcome Tassadar, what do you want to do today? \n");
        await Task.Run(() => menuNavigationService.DisplayMenu("nexus"));
        Console.WriteLine("================================================================================================");
    }
}