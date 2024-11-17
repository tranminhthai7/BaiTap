using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<User>> GetUsers();
		bool DelUser(int Id);
		bool DelUser(User user);
		bool AddUser(User user);
		bool UpdUser(User user);
		Task<User> GetUserById(int Id);
		Task<User?> GetUserByEmailAsync(string email);
		Task<User> RegisterUserAsync(User user);
		Task<User> GetUserByUserNameAsync(string userName);  // Phương thức để lấy User theo UserName
	}
}
