using Core.DTOs;
using Core.Interface;
using Nexus.Interfaces;
using PPlus;
using PPlus.Controls;

namespace Nexus.Views;

public class AddContacts(
    IInputValidationHelper inputValidationHelper,
    IContactCreateService contactCreateService) : IShowContacts
{
    /// <summary>
    /// Contact fields to be displayed in the view using the PromptPlus library
    /// </summary>
    private static readonly (string Property, string Display, string Description, string Pattern)[] ContactFields =
    {
        (nameof(ContactDto.FirstName), "First Name", "Your first name","^[a-zA-Z]+$"),
        (nameof(ContactDto.LastName), "Last Name", "Your first name",  "^[a-zA-Z]+$"),
        (nameof(ContactDto.Email), "Email", "Your email adress", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
        (nameof(ContactDto.PhoneNumber), "Phone Number", "Your mobile number", @"^\d{4,}$")
    };

    /// <summary>
    /// Run the Add Contacts view
    /// </summary>
    public void Run()
    {
        do
        {
            // Clear console and display header
            Console.Clear();
            Console.WriteLine("===================================== Tassadar Contact System =====================================");
            Console.WriteLine("Please add contact details: \n");

            // Get input for each field in the ContactFields array
            var contactDto = new ContactDto();
            foreach (var field in ContactFields)
            {
                var input = GetContactInput(field);
                object value = field.Property == nameof(ContactDto.PhoneNumber) ? Convert.ToInt32(input) : input;
                typeof(ContactDto).GetProperty(field.Property)?.SetValue(contactDto, value);
            }

            // Create contact using the service which internally uses the factory pattern
            var createdContact = contactCreateService.CreateContact(contactDto);
            Console.WriteLine($"Contact {createdContact.ContactGuid}: {createdContact.FirstName} added successfully!");

            // Prompt user to add another contact if they wish
            var addAnother = PromptPlus
                .Confirm("Would you like to add another contact?")
                .Config(cfg =>
                {
                    cfg.EnabledAbortKey(false);
                    cfg.ShowTooltip(true);
                    cfg.Tooltips("Press Y for Yes, N for No");
                })
                .Run();

            // Break loop if a user does not want to add another contact
            if (addAnother.Value.Key != ConsoleKey.Y)
            {
                break;
            }
        } while (true);
    }


    /// <summary>
    /// Get input for a contact field
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    private string GetContactInput((string Property, string Display, string Description, string Pattern) field)
    {
        var result = PromptPlus
            .Input($"Enter {field.Display}", field.Description)
            .AddValidators(
                text => inputValidationHelper.ValidateRequired(text.ToString(), field.Display),
                text => inputValidationHelper.ValidateMinLength(text.ToString(), field.Display),
                text => inputValidationHelper.ValidatePattern(text.ToString(), field.Pattern, field.Property, field.Display)
            )
            .Config(cfg =>
            {
                cfg.EnabledAbortKey(false)
                    .ShowTooltip()
                    .Tooltips($"Enter {field.Display}");
            })
            .Styles(InputStyles.Answer, Style.Default.Foreground(Color.Cyan1))
            .Run();

        return result.Value;
    }
}