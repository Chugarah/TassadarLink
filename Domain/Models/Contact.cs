namespace Domain.Models;


/// <summary>
/// Represents a contact entity in the system.
///
/// Generated with AI
///
/// Using null! for FirstName and Email because:
/// 1. It tells the compiler we guarantee these properties will be initialized
/// 2. Removes the nullable warning while maintaining the required constraint
/// 3. Improves code readability by removing green squiggles in the IDE
///
/// LastName uses string.Empty instead of null because:
/// 1. It provides better semantic meaning (empty value vs no value)
/// 2. Prevents null reference exceptions and reduces need for null checks
/// 3. string.Empty is a static readonly field that's memory efficient
/// 4. Makes the code more predictable and easier to maintain
/// 5. Better represents the domain concept (a contact has a LastName field, even if it's empty)
/// </summary>
public class Contact
{
    public Guid ContactGuid { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = null!;
    public int PhoneNumber {get; set;}
    public ContactAdress? ContactAdress { get; set; }
}