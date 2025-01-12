using Core.DTOs;
using Core.Interface;
using Nexus.Interfaces;
using PPlus;

namespace Nexus.Services;

public class MenuNavigationService(
    IGetMenuService getMenuService,
    IMenuCreateService menuCreateService,
    IAddContacts addContacts,
    IShowContacts showContacts)
    : IMenuNavigationService
{
    public async Task DisplayMenu(string route)
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
        await HandleMenuSelection(selectedMenuItem, route);
    }

    private async Task HandleMenuSelection(MenuItemDto selectedMenuItem, string route)
    {
        switch (selectedMenuItem.MenuId)
        {
            case 1:
                await showContacts.Run();
                await DisplayMenu(route);
                break;
            case 2:
                await addContacts.Run();
                await DisplayMenu(route);
                break;
            case 3:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                await DisplayMenu(route);
                break;
        }
    }
}