using Core.DTOs;

namespace Core.Interface;

public interface IMenuDisplayHelper
{
    public IEnumerable<MenuItemDto> GetMenuFormatedList(IEnumerable<MenuItemDto> menuItems);
}