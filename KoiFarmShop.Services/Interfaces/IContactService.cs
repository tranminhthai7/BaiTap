using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<TbContact>> GetContactsAsync();
        Task<int> AddContactAsync(TbContact contact);
        Task<int> RemoveContactAsync(int contactId);
        Task<bool> DeleteContactAsync(int contactId);
        Task<int> UpdateContactAsync(TbContact contact);
    }
}