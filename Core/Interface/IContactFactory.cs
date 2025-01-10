using Core.DTOs;
using Domain.Models;

namespace Core.Interface;

public interface IContactFactory
{
    Contact CreateContact(ContactDto contactDto);
    ContactDto CreateContact(Contact contact);
}