using Core.DTOs;
using Core.Interface;
using Domain.Models;

namespace Core.Services;
public class MenuService(IMenuFactory menuFactory, IIdHelpers idHelpers) : IMenuCreateService, IGetMenuService
{
    // Let's create a temporary list to store the menu items, this will be replaced with a database
    private readonly List<MenuItemDto> _menuItems = [];

    // Inject the IMenuFactory interface
    public Task<MenuItemDto> CreateMenuItem(MenuItem menuItem)
    {
        var getNextId = idHelpers.GetNextId(_menuItems, m => m.MenuId);
        var newMenuItem = menuFactory.CreateMenuItemDto(menuItem, getNextId);
         _menuItems.Add(newMenuItem);
         return Task.FromResult(newMenuItem);
    }

    // Implement the GetMenuItems method
    public Task<IEnumerable<MenuItemDto>> GetMenuItems()
    {
        throw new NotImplementedException();
    }
}