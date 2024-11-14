using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public UserRepository(KoiFarmShop2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public bool AddUser(User user)
        {
            try
            {
                _dbContext.Users.AddAsync(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelUser(int id)
        {
            try
            {
                var objDel = _dbContext.Users.Where(u => u.Id.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Users.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelUser(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public Task<List<User>> GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public bool UpdUser(User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
