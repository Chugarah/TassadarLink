using Core.DTOs;
using Core.Interface;
using Domain.Models;

namespace Core.Factories;

public class ContactFactory(IIdHelpers idHelpers) : IContactFactory
{

    /*
     * This class is responsible for creating a domain contact model from contact dto and vice versa
        Correct Flow Should Be:
            View sends ContactDto
            Service receives ContactDto
            Factory converts ContactDto to Contact (for domain operations)
            Factory converts Contact back to ContactDto (for returning to view)

            Some more explanation:
            View (ContactDto) → Service → Factory converts to Domain → Factory converts back to DTO → Storage
     */

    /// <summary>
    /// This method creates a domain contact model from contact dto
    /// </summary>
    /// <param name="contactDto"></param>
    /// <returns></returns>
    public Contact CreateContact(ContactDto contactDto)
    {
        return new Contact
        {
            ContactGuid = idHelpers.CreateGuid(),
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            Email = contactDto.Email,
            PhoneNumber = Convert.ToInt32(contactDto.PhoneNumber.ToString())
        };
    }

    /// <summary>
    /// This method creates a contact dto from a domain contact model
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public ContactDto CreateContact(Contact contact)
    {
        return new ContactDto
        {
            ContactGuid = contact.ContactGuid,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber
        };
    }




}