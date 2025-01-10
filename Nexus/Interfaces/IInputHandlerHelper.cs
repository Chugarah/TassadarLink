using Core.DTOs;

namespace Nexus.Interfaces;

public interface IInputHandlerHelper
{
   string GetMenuInput(List<MenuItemDto> menuItemDtos, string inputPrompt);
   string GetContactInput(ContactDto contact, string field);
}