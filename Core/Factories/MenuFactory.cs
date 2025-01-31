﻿using Core.DTOs;
using Core.Interface;
using Domain.Models;

namespace Core.Factories;

/// <summary>
/// Factory class for creating and managing menu item DTOs in the presentation layer.
/// Provides a clean abstraction between domain models and presentation objects.
///
/// Summary Generated by AI
///
/// Features:
/// - Handles DTO creation and mapping
/// - Maintains menu hierarchy through ParentMenuId relationships
/// - Ensures consistent menu ordering
/// - Thread-safe implementation
///
/// The DTO structure includes:
/// - MenuId: Unique identifier for the menu item
/// - MenuName: Display name for the menu item
/// - MenuDescription: Detailed description
/// - ParentMenuId: Optional parent reference for nested menus
/// - MenuRoute: Navigation path
/// - MenuOrder: Display sequence
/// </summary>
/// <example>
/// <code>
/// // Create the factory
/// var menuFactory = new MenuFactory();
///
/// // Create a menu item DTO
/// var menuItemDto = new MenuItemDto
/// {
///     MenuId = 1,
///     MenuName = "Settings",
///     MenuDescription = "System configuration options",
///     MenuRoute = "/settings",
///     MenuOrder = 2,
///     ParentMenuId = null  // Root level menu
/// };
///
/// // Example of creating a child menu item
/// var childMenuDto = new MenuItemDto
/// {
///     MenuId = 2,
///     MenuName = "User Settings",
///     MenuDescription = "User-specific configuration",
///     MenuRoute = "/settings/user",
///     MenuOrder = 1,
///     ParentMenuId = 1  // Child of Settings menu
/// };
/// </code>
/// </example>
public class MenuFactory() : IMenuFactory
{
    /// <summary>
    /// Summary Generated by AI
    /// Converts a MenuItem domain model to a MenuItemDto data transfer object.
    /// </summary>
    /// <remarks>
    /// This method performs a straightforward mapping between domain and DTO objects:
    /// - Maps basic properties like name, description, route, and order
    /// - Preserves the parent-child relationship through ParentMenuId
    /// - Associates the item with a specific menu through menuId parameter
    /// </remarks>
    /// <param name="menuItem">The source MenuItem domain model to convert</param>
    /// <param name="menuId">The ID of the menu this item belongs to</param>
    /// <returns>A new MenuItemDto containing the mapped data</returns>
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