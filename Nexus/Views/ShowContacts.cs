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
        PromptPlus.WriteLine("[cyan]Welcome to Tassadar Links, all the contacts are displayed in the table below, enjoy![/]");
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
            // Create a table to display the contacts using PromptPlus
           var table =  PromptPlus
                .TableSelect<ContactDto>("", "You can exit to main menu by pressing [green]Enter[/] key")
                .Title("Contact List")
                .AddColumn(x => x.ContactGuid, 50, title: "User Guid")
                .AddColumn(x => x.FirstName, 25, title: "First Name")
                .AddColumn(x => x.LastName, 25, title: "Last Name")
                .AddColumn(x => x.Email, 30, title: "Email")
                .AddColumn(x => x.PhoneNumber, 15, title: "Phone")
                .Config(cfg =>
                {
                    cfg.ShowTooltip(true);
                    cfg.EnabledAbortKey(false);
                    cfg.ShowTooltip();
                    cfg.Tooltips("Press [green]Enter[/] to view contact details");
                    cfg.ShowOnlyExistingPagination(false);
                })
                .AddItems(contactDto, true)
                .Layout(TableLayout.SingleGridFull)
                .Styles(TableSelectStyle.Lines, Style.Default.Foreground(Color.Red))
                .Styles(TableSelectStyle.Disabled, Style.Default.Foreground(Color.Magenta1))
                .Styles(TableSelectStyle.Selected, Style.Default.Foreground(Color.Aquamarine1))
                .Styles(TableSelectStyle.TableContent, Style.Default.Foreground(Color.Yellow))
                .Styles(TableSelectStyle.TableHeader, Style.Default.Foreground(Color.Blue))
                .Styles(TableSelectStyle.TableTitle, Style.Default.Foreground(Color.Cyan1))
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