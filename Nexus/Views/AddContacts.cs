using Core.DTOs;
using Core.Interface;
using Infrastructure.Interfaces;
using Nexus.Interfaces;
using PPlus;
using PPlus.Controls;

namespace Nexus.Views;

public class AddContacts(
    IInputValidationHelper inputValidationHelper,
    IContactCreateService contactCreateService,
    IFileServerAdministration fileServerAdministration,
    IFileServerDataHandler fileServerDataHandler,
    IFileService fileService) : IShowContacts
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
    public Task Run()
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
            // Save the contact to the JSON file
            SaveContact(createdContact);

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

        return Task.CompletedTask;
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


    /// <summary>
    /// Save the contact to the JSON file
    /// </summary>
    /// <param name="createdContact"></param>
    private async void SaveContact(ContactDto createdContact)
    {
        // Check if the file exists and create it if it does not
        if (await fileServerAdministration.CreateFileAsync("TassaDarLink", "tassadar-contact.json"))
        {
            // Check if the contact already exists in the file
            if (await fileService.CheckContactExistAsync(createdContact.ContactGuid))
            {
                PromptPlus.WriteLine("[yellow]Contact already exists in the file.[/]");
                Thread.Sleep(1500);
            }
            // If the contact does not exist in the file
            else
            {
                // Load existing contacts
                var existingContacts = (await fileServerDataHandler.LoadAllContactsAsync()).ToList();
                // Add new contact
                existingContacts.Add(createdContact);

                // Save the contact to the file
                if (await fileServerDataHandler.SaveContactAsync(existingContacts))
                {
                    PromptPlus.WriteLine($"[green] {createdContact.ContactGuid}: {createdContact.FirstName} saved successfully to file![/]");
                    Thread.Sleep(1500);
                }
                // If the contact could not be saved to the file
                else
                {
                    // Display an error message using the PromptPlus library
                    PromptPlus.WriteLine("[red]Failed to save contact to file. Please try again.[/]");
                    Thread.Sleep(1500);
                }
            }
        }
        else
        {
            // Display an error message using the PromptPlus library
            PromptPlus.WriteLine("[red]Failed to create file. Please try again.[/]");
            Thread.Sleep(1500);
        }
    }
}