using Core.DTOs;
using Core.Interface;
using Nexus.Interfaces;
using PPlus;

namespace Nexus.Services;

public class MenuNavigationService(
    IGetMenuService getMenuService,
    IMenuCreateService menuCreateService,
    IShowContacts showContacts)
    : IMenuNavigationService
{
    public void DisplayMenu(string route)
    {
        // Generate initial menu items
        Console.Clear();
        menuCreateService.GenerateMenuItems(route);
        var menuItems = getMenuService.GetMenuItems().ToList();

        var selection = PromptPlus
            .Select<MenuItemDto>("Selected Option:")
            .Separator()
            .AddItems(menuItems)
            .TextSelector(item => $"{item.MenuId}. {item.MenuName}")
            .Config(cfg =>
            {
                cfg.ShowTooltip(false);
                cfg.ShowOnlyExistingPagination(false);
                cfg.Description($"Menu - {route}");
                cfg.HideAfterFinish();
                cfg.EnabledAbortKey();
            })
            .Run();

        if (selection.IsAborted)
        {
            Environment.Exit(0);
            return;
        }

        var selectedMenuItem = selection.Value;
        HandleMenuSelection(selectedMenuItem, route);
    }

    private void HandleMenuSelection(MenuItemDto selectedMenuItem, string route)
    {
        switch (selectedMenuItem.MenuId)
        {
            case 1:
                DisplayMenu(selectedMenuItem.MenuRoute);
                break;
            case 2:
                showContacts.Run();
                DisplayMenu(route);
                break;
            case 3:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                DisplayMenu(route);
                break;
        }
    }
}