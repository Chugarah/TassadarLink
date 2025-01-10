using Core.DTOs;
using Domain.Models;

namespace Core.Interface;

public interface IMenuCreateService
{
    public MenuItemDto CreateMenuItem(MenuItem menuItem);
    public void GenerateMenuItems(string route);
}

public interface IGetMenuService
{
    IEnumerable<MenuItemDto> GetMenuItems();
}