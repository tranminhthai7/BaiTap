using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<bool> AddContact(Contact contact)
        {
            return _contactRepository.AddContact(contact);
        }

        public Task<bool> DeleteContactAsync(int contactId)
        {
            return _contactRepository.DeleteContactAsync(contactId);
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _contactRepository.GetContacts();
        }

        public Task<bool> RemoveContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContact(Contact contact)
        {
            return _contactRepository.UpdateContact(contact);
        }
    }
}
