namespace Domain.Models;

public abstract class Menu
{
    public Guid MenuGuid { get; set; }
    public int MenuId { get; set; }
    public string MenuName { get; set; } = null!;
    public string MenuDescription { get; set; } = null!;
}

public class MenuItem : Menu
{
    public int? ParentMenuId { get; set; }
    public string MenuRoute { get; set; } = null!;
    public int MenuOrder { get; set; }
}
