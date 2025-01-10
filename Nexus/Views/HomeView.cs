using Nexus.Interfaces;

namespace Nexus.Views;

public class HomeView(IMenuNavigationService menuNavigationService) : IHomeView
{
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("===================================== Tassadar Link System =====================================");
        Console.WriteLine("Welcome Tassadar, what do you want to do today? \n");
        menuNavigationService.DisplayMenu("nexus");
        Console.WriteLine("================================================================================================");
    }
}