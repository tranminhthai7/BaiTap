using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ContactRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbContact>> GetContactsAsync()
        {
            try
            {
                return await _dbContext.TbContacts.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbContact>();
            }
        }

        public async Task<int> AddContactAsync(TbContact contact)
        {
            try
            {
                await _dbContext.TbContacts.AddAsync(contact);
                await _dbContext.SaveChangesAsync();
                return contact.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveContactAsync(int contactId)
        {
            var contact = await _dbContext.TbContacts.FindAsync(contactId);
            if (contact == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbContacts.Remove(contact);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var contact = await _dbContext.TbContacts.FindAsync(contactId);
            if (contact == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbContacts.Remove(contact);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateContactAsync(TbContact contact)
        {
            try
            {
                _dbContext.TbContacts.Update(contact);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}