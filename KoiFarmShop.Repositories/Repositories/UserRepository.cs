using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
			_dbContext.Users.Add(user);
			_dbContext.SaveChanges();
			return true;
		}

		public bool DelUser(int id)
		{
			var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
			if (user != null)
			{
				_dbContext.Users.Remove(user);
				_dbContext.SaveChanges();
				return true;
			}
			return false;
		}

		public bool DelUser(User user)
		{
			_dbContext.Users.Remove(user);
			_dbContext.SaveChanges();
			return true;
		}

		public async Task<List<User>> GetUsers()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<User> GetUserById(int id)
		{
			return await _dbContext.Users.FindAsync(id);
		}

		public async Task<User> GetUserByUserNameAsync(string userName)
		{
			return await _dbContext.Users
				.FirstOrDefaultAsync(u => u.UserName == userName);
		}

		public bool UpdUser(User user)
		{
			_dbContext.Users.Update(user);
			_dbContext.SaveChanges();
			return true;
		}
	}
}
