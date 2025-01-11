using Core.DTOs;
using Core.Interface;

namespace Core.Services;

/*
 * This class is responsible for handling the business logic for the Contact entity.
 * Information Extracted from AI Phind
 * CRUD Operations in services typically include:
        Create (you have this)
        Read (you have GetAllContacts)
        Update (you'll add later)
        Delete (you'll add later)
 */


public class ContactService(IContactFactory contactFactory) : IContactGetService, IContactCreateService
{
    private readonly List<ContactDto> _contacts = [];

    public IEnumerable<ContactDto> GetAllContacts()
    {
        return _contacts.ToList();
    }

    public ContactDto CreateContact(ContactDto contactDto)
    {
        // 1. Convert DTO to Domain Model
        var contact = contactFactory.CreateContact(contactDto);

        // 2. Convert back to DTO for storage and return
        var newContactDto = contactFactory.CreateContact(contact);
        _contacts.Add(newContactDto);
        return newContactDto;
    }
}