namespace Core.DTOs;

public abstract class MenuDto
{
    public int MenuId { get; set; }
    public string MenuName { get; set; } = null!;
    public string MenuDescription { get; set; } = null!;
}

public class MenuItemDto : MenuDto
{
    public int? ParentMenuId { get; set; }
    public string MenuRoute { get; set; } = null!;
    public int MenuOrder { get; set; }
}