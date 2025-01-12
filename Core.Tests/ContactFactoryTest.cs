using Core.DTOs;
using Core.Factories;
using Core.Helpers;
using Domain.Models;

namespace Core.Tests;

public class ContactFactoryTest
{
    private readonly ContactFactory _contactFactory = new(new IdHelpers());
    private readonly Guid _contactGuid = new IdHelpers().CreateGuid();

    /// <summary>
    /// Test to create a contact domain from a valid contact dto.
    /// </summary>
    [Fact]
    public void CreateContact_FromDto_Domain()
    {
        // ARRANGE
        var contactDto = new ContactDto
        {
            ContactGuid = _contactGuid,
            FirstName = "Hans",
            LastName = "Code",
            Email = "hans@outlook.com",
            PhoneNumber = 1234567890
        };

        // ACT
        var domainResult = _contactFactory.CreateContact(contactDto);

        // ASSERT
        Assert.NotNull(contactDto);
        Assert.NotEqual(Guid.Empty, contactDto.ContactGuid);
        Assert.Equal(contactDto.ContactGuid, contactDto.ContactGuid);
        Assert.Equal(contactDto.FirstName, domainResult.FirstName);
        Assert.Equal(contactDto.LastName, domainResult.LastName);
        Assert.Equal(contactDto.Email, domainResult.Email);
        Assert.Equal(contactDto.PhoneNumber, domainResult.PhoneNumber);
    }

    /// <summary>
    /// Test to create a contact dto from a valid contact domain.
    /// </summary>
    [Fact]
    public void CreateContact_FromDomain_ToDto()
    {
        // ARRANGE
        var contact = new Contact
        {
            ContactGuid = _contactGuid,
            FirstName = "Starcraft",
            LastName = "BroodWar",
            Email = "zealot@outlook.com",
            PhoneNumber = 6652234
        };

        // ACT
        var dtoResult = _contactFactory.CreateContact(contact);

        // ASSERT
        Assert.NotNull(dtoResult);
        Assert.IsType<ContactDto>(dtoResult);
        Assert.Equal(contact.ContactGuid, dtoResult.ContactGuid);
        Assert.Equal(contact.FirstName, dtoResult.FirstName);
        Assert.Equal(contact.LastName, dtoResult.LastName);
        Assert.Equal(contact.Email, dtoResult.Email);
        Assert.Equal(contact.PhoneNumber, dtoResult.PhoneNumber);
    }
}