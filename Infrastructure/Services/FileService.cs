using System.Text.Json;
using Core.DTOs;
using Core.Interface;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class FileService(IContactFactory contactFactory) :
    IFileService, IFileServerDataHandler, IFileServerAdministration
{

    private readonly IContactFactory _contactFactory = contactFactory;
    private string _filePath = null!;
    // Got CA1869 it's better to create it once instead of every serialization
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { WriteIndented = true };
    private readonly List<ContactDto> _jsonContactList = [];

    public async Task<bool> CheckContactExistAsync(Guid contactGuid)
    {
        // Load all contacts from the file
        var contacts = await LoadAllContactsAsync();
        // Check if the contactGuid exists in the list of contacts
        return contacts.Any(g => g.ContactGuid == contactGuid);
    }

    /// <summary>
    ///  Save the contactDto to the file
    /// </summary>
    /// <param name="contactDto"></param>
    /// <returns></returns>
    public async Task<bool> SaveContactAsync(List<ContactDto> contactDto)
    {
        try
        {
            // Serialize the contactDto to JSON
            var json = JsonSerializer.Serialize(contactDto, JsonOptions);

            // Write the JSON to the file
            await File.WriteAllTextAsync(_filePath, json);
            return true;
        }
        // Catch any exceptions and return false
        catch (Exception e)
        {
            return false;
        }
    }

    /// <summary>
    /// Load the contact by Guid
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<ContactDto>> LoadContactByGuid()
    {
        throw new NotImplementedException();
    }


    /// <summary>
    ///  Load all contacts from the file
    /// https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-9.0
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<ContactDto>> LoadAllContactsAsync()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return Enumerable.Empty<ContactDto>();
            }

            var jsonContent = await File.ReadAllTextAsync(_filePath);
            var contacts = JsonSerializer.Deserialize<List<ContactDto>>(jsonContent, JsonOptions);

            return contacts ?? Enumerable.Empty<ContactDto>();
        }
        catch (Exception)
        {
            return Enumerable.Empty<ContactDto>();
        }
    }
    public async Task<bool> CreateFileAsync(string folderName, string fileName)
    {
        try
        {
            // Creating a folder in AppData
            var appDataPath = Path.Combine(
                // C:\Users\User\AppData\Roaming\TassaDarLink\tassadar-contact.json
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                folderName);

            // Create directory if it doesn't exist
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            // Creating a file in the folder
            _filePath = Path.Combine(appDataPath, fileName);

            // Check if the file exists
            if (!CheckIfFileExist(_filePath))
            {
                // Create the file if it doesn't exist with an empty JSON array
                await File.WriteAllTextAsync(_filePath, "[]");
            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /// <summary>
    /// Check if the file exists
    /// </summary>
    /// <returns></returns>
    private static bool CheckIfFileExist(string filePath)
    {
        return File.Exists(filePath);
    }

}