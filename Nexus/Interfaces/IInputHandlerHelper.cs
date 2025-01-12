using Core.DTOs;

namespace Nexus.Interfaces;

public interface IInputHandlerHelper
{
   string GetMenuInput(List<MenuItemDto> menuItemDto, string inputPrompt);
   string GetContactInput(ContactDto contact, string field);
}