using Core.DTOs;
using Domain.Models;

namespace Core.Interface;

public interface IMenuFactory
{
    public MenuItemDto CreateMenuItemDto(MenuItem menuItem, int menuId);
}