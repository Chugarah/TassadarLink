using Core.DTOs;
using Domain.Models;

namespace Core.Interface;

public interface IContactGetService
{
 IEnumerable<ContactDto> GetAllContacts();
}

public interface IContactCreateService
{
 public ContactDto CreateContact(ContactDto contactDto);
}