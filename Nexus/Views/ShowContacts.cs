using System.Text.Json;
using Core.DTOs;
using Infrastructure.Interfaces;
using Nexus.Interfaces;
using PPlus;
using PPlus.Controls;

namespace Nexus.Views;

/// <summary>
/// ShowContacts view class
/// </summary>
/// <param name="fileServerDataHandler"></param>
public class ShowContacts(
    IFileServerDataHandler fileServerDataHandler) : IShowContacts
{

    /// <summary>
    /// Run the ShowContacts view
    /// </summary>
    public async Task Run()
    {
        Console.Clear();
        Console.WriteLine("===================================== Tassadar Show Contacts =====================================");
        // Get all contacts from the JSON file
        await GetContacts();
    }


    /// <summary>
    /// Get all contacts from the JSON file
    /// </summary>
    private async Task GetContacts()
    {
        // Load all contacts from the JSON file
        var contacts = await fileServerDataHandler.LoadAllContactsAsync();
        // Convert the contacts to a list
        var contactDto = contacts.ToList();

        // Check if there are any contacts
        if (!contactDto.Any())
        {
            PromptPlus.WriteLine("[yellow]No contacts found...[/]");
            Thread.Sleep(1500);
            return;
        }

        // Display contacts in table format
        try
        {
            PromptPlus
                .TableSelect<ContactDto>("Contact List", "Select a contact to view details")
                .AddColumn(x => x.ContactGuid, 36, title: "ID")
                .AddColumn(x => x.FirstName, 15, title: "First Name")
                .AddColumn(x => x.LastName, 15, title: "Last Name")
                .AddColumn(x => x.Email, 30, title: "Email")
                .AddColumn(x => x.PhoneNumber, 15, title: "Phone")
                .Config(cfg =>
                {
                    cfg.ShowTooltip(false);
                    cfg.Description("Contact List");
                })
                .AddItems(contactDto, true)
                .Layout(TableLayout.SingleGridFull)
                .PageSize(10)
                .Run();
        }
        // Catch any exceptions
        catch (Exception)
        {
            PromptPlus.WriteLine("[red]Error displaying contacts table.[/]");
            Thread.Sleep(1500);
        }
    }


}