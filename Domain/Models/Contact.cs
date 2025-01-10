namespace Domain.Models;


public class Contact
{
    public Guid ContactGuid { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = null!;
    public int PhoneNumber {get; set;}
}