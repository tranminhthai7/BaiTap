using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository) {
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

        public async Task<List<Contact>> GetContacts()
        {
            return await _contactRepository.GetContacts();
        }

        public Task<bool> UpdateContact(Contact contact)
        {
            return _contactRepository.UpdateContact(contact);
        }

        public Task<bool> RemoveContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
