using Nexus.Interfaces;

namespace Nexus.Views;

public class HomeView : IHomeView
{
    public void Run()
    {
        Console.WriteLine("Welcome to the Home View!");
    }
}