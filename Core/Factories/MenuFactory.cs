using Core.DTOs;
using Core.Interface;
using Domain.Models;

namespace Core.Factories;

/// <summary>
/// Generated using AI (Summary)
/// Factory class for creating MenuItemDto objects from MenuItem domain models.
/// Follows Single Responsibility Principle by focusing solely on DTO creation.
///
/// Features:
/// - Performs stateless one-way mapping from domain model to DTO
/// - Uses IIdHelpers for ID generation
/// - Thread-safe primary constructor pattern
/// - Pure factory pattern implementation
///
/// Example usage:
/// var factory = new MenuFactory(idHelpers);
/// var dto = factory.CreateMenuItemDto(menuItem, createdMenuItems);
/// </summary>
public class MenuFactory() : IMenuFactory
{
    /// <summary>
    /// Creates a new MenuItemDto from a MenuItem domain model.
    /// Generated using AI assistance.
    ///
    /// Features:
    /// - Pure mapping function with no side effects
    /// - Uses provided collection for ID generation
    /// - Maintains referential integrity with ParentMenuId
    ///
    /// Implementation notes:
    /// - Inspired by Hans Video using LINQ
    /// - Uses AI-generated GetNextId helper method
    /// </summary>
    /// <param name="menuItem">The source MenuItem domain model to convert</param>
    /// <param name="menuId"></param>
    /// <returns>A new MenuItemDto with generated ID and mapped properties</returns>
    public MenuItemDto CreateMenuItemDto(MenuItem menuItem, int menuId)
    {
        var menuItemDto = new MenuItemDto
        {
            // Inspired by Hans Video using Linq and used AI to create GetNextId helper Method
            MenuId = menuId,
            MenuName = menuItem.MenuName,
            MenuDescription = menuItem.MenuDescription,
            ParentMenuId = menuItem.ParentMenuId,
            MenuRoute = menuItem.MenuRoute,
            MenuOrder = menuItem.MenuOrder
        };
        return menuItemDto;
    }
}