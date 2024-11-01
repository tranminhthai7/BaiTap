using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
        Task<bool> AddContact(Contact contact);
        Task<bool> RemoveContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int contactId);
        Task<bool> UpdateContact(Contact contact);
    }
}
