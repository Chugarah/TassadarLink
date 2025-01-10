using Core.DTOs;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class FileService : IFileService , IFileServerDataHandler, IFileServerAdministration
{
    public Task<bool> CheckContactExistAsync(Guid contactGuid)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveContactAsync(IEnumerable<ContactDto> contactDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ContactDto>> LoadContactsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ContactDto> LoadAllContactsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateFileAsync(string fileName)
    {
        throw new NotImplementedException();
    }
}