using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Task<List<TbContact>> GetContactsAsync()
        {
            return _contactRepository.GetContactsAsync();
        }

        public Task<int> AddContactAsync(TbContact contact)
        {
            return _contactRepository.AddContactAsync(contact);
        }

        public Task<int> RemoveContactAsync(int contactId)
        {
            return _contactRepository.RemoveContactAsync(contactId);
        }

        public Task<bool> DeleteContactAsync(int contactId)
        {
            return _contactRepository.DeleteContactAsync(contactId);
        }

        public Task<int> UpdateContactAsync(TbContact contact)
        {
            return _contactRepository.UpdateContactAsync(contact);
        }
    }
}