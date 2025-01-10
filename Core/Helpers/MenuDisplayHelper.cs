﻿using Core.DTOs;
using Core.Interface;

namespace Core.Helpers;


/// <summary>
/// Helper class for formatting and organizing menu items in a hierarchical structure.
///
/// Generated by AI Summary Section
///
/// Provides methods to sort and arrange MenuItemDto collections for display purposes.
/// </summary>
/// <remarks>
/// This helper ensures consistent menu ordering by:
/// - Placing root menu items (no parent) first
/// - Grouping child items under their parents
/// - Maintaining menu order within each level
/// </remarks>
/// <example>
/// <code>
/// var helper = new MenuDisplayHelper();
/// var menuItems = new List&lt;MenuItemDto&gt;
/// {
///     new() { MenuId = 1, MenuName = "Home", ParentMenuId = null, MenuOrder = 1 },
///     new() { MenuId = 2, MenuName = "Settings", ParentMenuId = 1, MenuOrder = 1 }
/// };
///
/// var formattedList = helper.GetMenuFormatedList(menuItems);
/// // Results in ordered list with parent items followed by their children
/// </code>
/// </example>
public class MenuDisplayHelper : IMenuDisplayHelper
{
    /// <summary>
    /// Formats a collection of menu items into a hierarchically ordered list.
    ///
    /// Generated by AI Summary Section
    ///
    /// Inspired https://stackoverflow.com/questions/3760001/linq-orderby-versus-thenby
    /// </summary>
    /// <param name="menuItems">The source collection of menu items to format</param>
    /// <returns>An ordered enumerable of menu items, sorted by parent relationship and menu order</returns>
    /// <remarks>
    /// The ordering is performed using the following criteria:
    /// 1. Root items (null ParentMenuId) appear first
    /// 2. Child items are grouped by their ParentMenuId
    /// 3. Items within each group are sorted by MenuOrder
    /// </remarks>
    public IEnumerable<MenuItemDto> GetMenuFormatedList(IEnumerable<MenuItemDto> menuItems)
    {
        // Order the menu items by ParentMenuId, MenuId, and MenuOrder
        return menuItems
            .OrderBy(m => m.ParentMenuId.HasValue)
            .ThenBy(m => m.ParentMenuId)
            .ThenBy(m => m.MenuOrder);
    }
}
