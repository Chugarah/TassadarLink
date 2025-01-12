using Core.Factories;
using Domain.Models;

namespace Core.Tests.Factories;

public class MenuFactoryTest
{
    /// <summary>
    /// Test to create a menu item DTO from a valid menu item.
    /// </summary>
    [Fact]
    public void CreateMenuItem_WithValidMenuItem_ReturnsMenuItemDto()
    {
        // ARRANGE
        var menuFactory = new MenuFactory();
        var menuItem = new MenuItem
        {
            MenuId = 1,
            MenuName = "Settings",
            MenuDescription = "System configuration options",
            MenuRoute = "/settings",
            MenuOrder = 2,
            ParentMenuId = null
        };

        // ACT
        var menuItemDto = menuFactory.CreateMenuItemDto(menuItem, menuItem.MenuId);

        // ASSERT
        Assert.NotNull(menuItemDto);
        Assert.Equal(menuItem.MenuId, menuItemDto.MenuId);
        Assert.Equal(menuItem.MenuName, menuItemDto.MenuName);
        Assert.Equal(menuItem.MenuDescription, menuItemDto.MenuDescription);
        Assert.Equal(menuItem.MenuRoute, menuItemDto.MenuRoute);
        Assert.Equal(menuItem.MenuOrder, menuItemDto.MenuOrder);
        Assert.Equal(menuItem.ParentMenuId, menuItemDto.ParentMenuId);
    }
}