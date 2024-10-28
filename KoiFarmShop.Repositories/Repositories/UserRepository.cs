using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public UserRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbUser>> GetUsersAsync()
        {
            try
            {
                return await _dbContext.TbUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbUser>();
            }
        }

        public async Task<int> AddUserAsync(TbUser user)
        {
            try
            {
                await _dbContext.TbUsers.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveUserAsync(int userId)
        {
            var user = await _dbContext.TbUsers.FindAsync(userId);
            if (user == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbUsers.Remove(user);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _dbContext.TbUsers.FindAsync(userId);
            if (user == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbUsers.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateUserAsync(TbUser user)
        {
            try
            {
                _dbContext.TbUsers.Update(user);
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