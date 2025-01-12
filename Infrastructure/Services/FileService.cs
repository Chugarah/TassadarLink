using Core.DTOs;
using Core.Interface;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Services;

public class FileService(IContactFactory contactFactory) :
    IFileService, IFileServerDataHandler, IFileServerAdministration
{
    // Setting up some local vars for folder name and file name
    private const string FolderName = "TassaDarLink";
    private const string FileName = "tassadar-contact.json";

    // Creating a folder in AppData, used Rider to help me to refactor this
    private static readonly string AppDataPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        FolderName);
    private readonly string _filePath = Path.Combine(AppDataPath, FileName);

    // Using Dependency Injection to inject the ContactFactory
    private readonly IContactFactory _contactFactory = contactFactory;

    // Settings for JSON serialization
    private static readonly JsonSerializerSettings JsonSettings = new()
    {
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

    public async Task<bool> CheckContactExistAsync(Guid contactGuid)
    {
        // Load all contacts from the file
        var contacts = await LoadAllContactsAsync();
        // Check if the contactGuid exists in the list of contacts
        return contacts.Any(g => g.ContactGuid == contactGuid);
    }

    /// <summary>
    ///  Save the contactDto to the file
    /// Inspired by Hans
    /// </summary>
    /// <param name="contactDto"></param>
    /// <returns></returns>
    public async Task<bool> SaveContactAsync(List<ContactDto> contactDto)
    {
        try
        {
            var json = JsonConvert.SerializeObject(contactDto, JsonSettings);
            await File.WriteAllTextAsync(_filePath, json);
            return true;
        }
        catch (Exception)
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
    /// Load all contacts from the file
    /// Inspired by Hans
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ContactDto>> LoadAllContactsAsync()
    {
        try
        {
            // Check if the file exists
            if (!CheckIfFileExist(_filePath))
            {
                return Enumerable.Empty<ContactDto>();
            }

            // Read the file and deserialize the content
            var jsonContent = await File.ReadAllTextAsync(_filePath);
            // Deserialize the content to a list of ContactDto
            var contacts = JsonConvert.DeserializeObject<List<ContactDto>>(jsonContent);

            // Return the list of contacts
            return contacts ?? Enumerable.Empty<ContactDto>();
        }
        // Catch any exceptions and return an empty list
        catch (Exception)
        {
            return Enumerable.Empty<ContactDto>();
        }
    }

    /// <summary>
    /// Create the file if it does not exist
    /// </summary>
    /// <returns></returns>
    public async Task<bool> CreateFileAsync()
    {
        try
        {
            // Check if the folder exists and create it if it does not
            if (!Directory.Exists(AppDataPath))
            {
                Directory.CreateDirectory(AppDataPath);
            }

            // Check if the file exists and create it if it does not
            if (!CheckIfFileExist(_filePath))
            {
                await File.WriteAllTextAsync(_filePath, "[]");
            }
            return true;
        }
        // Catch any exceptions and return false
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Check if the file exists
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    private static bool CheckIfFileExist(string filePath)
    {
        return File.Exists(filePath);
    }
}