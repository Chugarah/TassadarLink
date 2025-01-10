
using Core.DTOs;

namespace Infrastructure.Interfaces;
public interface IFileService
{
    Task<bool> CheckContactExistAsync(Guid contactGuid);
}

public interface IFileServerDataHandler
{
    Task<bool> SaveContactAsync(IEnumerable<ContactDto> contactDto);
    Task<IEnumerable<ContactDto>> LoadContactsAsync();
    Task<ContactDto> LoadAllContactsAsync();
}

public interface IFileServerAdministration
{
    Task<bool> CreateFileAsync(string fileName);
}