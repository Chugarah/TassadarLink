using Core.DTOs;
using Core.Interface;
using Domain.Models;

namespace Core.Services;
public class MenuService(IMenuFactory menuFactory, IIdHelpers idHelpers) : IMenuCreateService, IGetMenuService
{
    // Let's create a temporary list to store the menu items, this will be replaced with a database
    private readonly List<MenuItemDto> _menuItems = [];

    // Inject the IMenuFactory interface
    public MenuItemDto CreateMenuItem(MenuItem menuItem)
    {
        var getNextId = idHelpers.GetNextId(_menuItems, m => m.MenuId);
        var newMenuItem = menuFactory.CreateMenuItemDto(menuItem, getNextId);
         _menuItems.Add(newMenuItem);
         return newMenuItem;
    }

    public void GenerateMenuItems(string route)
    {
        _menuItems.Clear();
        switch (route)
        {
            case "nexus":
                MenuGenerationNexus();
                break;
            default:
                Console.WriteLine("Invalid Route");
                break;
        }
    }

    // Implement the GetMenuItems method
    public IEnumerable<MenuItemDto> GetMenuItems()
    {
        return _menuItems.AsEnumerable();
    }


    private void MenuGenerationNexus()
    {
        // Creating the menu items
        var menuItem = new[]
        {
            new MenuItem
            {
                MenuGuid = idHelpers.CreateGuid(),
                MenuId = 2,
                MenuName = "Show Tassadar Contacts",
                MenuDescription = "Showing Tassadar Contacts",
                MenuRoute = "/show-contact",
                MenuOrder = 2,
                ParentMenuId = null
            },
            new MenuItem
            {
                MenuGuid = idHelpers.CreateGuid(),
                MenuId = 3,
                MenuName = "Create Tassadar Contacts",
                MenuDescription = "Create Tassadar Contacts",
                MenuRoute = "/create-contact",
                MenuOrder = 3,
                ParentMenuId = null
            },
            new MenuItem
            {
                MenuGuid = idHelpers.CreateGuid(),
                MenuId = 3,
                MenuName = "Exit",
                MenuDescription = "Exit the application",
                MenuRoute = "/exit",
                MenuOrder = 4,
                ParentMenuId = null
            },
        };
        // Adding to the menu items list
        // Lets iterating through the menu items and create them
        foreach (var addMenu in menuItem)
        {
            CreateMenuItem(addMenu);
        }
    }



}