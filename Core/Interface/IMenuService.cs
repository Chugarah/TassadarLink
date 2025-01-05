using Core.DTOs;
using Domain.Models;

namespace Core.Interface;

public interface IMenuCreateService
{
   Task<MenuItemDto> CreateMenuItem(MenuItem menuItem);
}

public interface IGetMenuService
{
    Task<IEnumerable<MenuItemDto>> GetMenuItems();
}