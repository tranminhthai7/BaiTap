using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public ContactRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.AddAsync(contact);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var objDel = await _dbContext.Contacts.Where(p => p.Id.Equals(contactId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Contacts.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<List<Contact>> GetContacts()
        {
            List<Contact> contacts = null;
            try
            {
                contacts = await _dbContext.Contacts.ToListAsync();
            }
            catch (Exception ex) 
            {
                contacts?.Add(new Contact());
            }
            return contacts;
        }

        public Task<bool> RemoveContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.Update(contact);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
