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
    public void CreateContact_ShouldReturnContact()
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
        var contact = _contactFactory.CreateContact(contactDto);

        // ASSERT
        Assert.NotNull(contact);
        Assert.NotEqual(Guid.Empty, contact.ContactGuid);
        Assert.Equal(contactDto.ContactGuid, contact.ContactGuid);
        Assert.Equal("Hans", contact.FirstName);
        Assert.Equal("Code", contact.LastName);
        Assert.Equal("hans@outlook.com", contact.Email);
        Assert.Equal(1234567890, contact.PhoneNumber);
    }

    /// <summary>
    /// Test to create a contact dto from a valid contact domain.
    /// </summary>
    [Fact]
    public void CreateContact_FromDomainModel_ShouldReturnContactDto()
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
        var dtoContact = _contactFactory.CreateContact(contact);

        // ASSERT
        Assert.NotNull(dtoContact);
        Assert.Equal(contact.ContactGuid, dtoContact.ContactGuid);
        Assert.Equal("Starcraft", dtoContact.FirstName);
        Assert.Equal("BroodWar", dtoContact.LastName);
        Assert.Equal("zealot@outlook.com", dtoContact.Email);
        Assert.Equal(6652234, dtoContact.PhoneNumber);
    }
}