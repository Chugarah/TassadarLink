
using Core.DTOs;

namespace Infrastructure.Interfaces;
public interface IFileService
{
    Task<bool> CheckContactExistAsync(Guid contactGuid);
}

public interface IFileServerDataHandler
{
    Task<bool> SaveContactAsync(List<ContactDto> contactDto);
    Task<IEnumerable<ContactDto>> LoadContactByGuid();
    Task<IEnumerable<ContactDto>> LoadAllContactsAsync();


}

public interface IFileServerAdministration
{
    public Task<bool> CreateFileAsync(string folderName, string fileName);
}