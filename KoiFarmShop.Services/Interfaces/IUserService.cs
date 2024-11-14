using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IUserService
    {
        // lay danh sách acccount
        Task<List<User>> GetUsers(); // Change method name to match repository interface
        Boolean DelUser(int Id);
        Boolean DelUser(User account);
        Boolean AddUser(User account);
        Boolean UpdUser(User account);
        //Task<bool> RegisterUserAsync(string email, string password);
        Task<User> GetUserById(int Id);
        //Task<bool> RegisterUserAsync(User user);
        Task<User?> LoginAsync(string email, string password);
        Task<User> RegisterAsync(string userName, string password, string fullName, string email, string phone, string address);
        Task<bool> RegisterUserAsync(User user);
        Task AddUserAsync(User newUser);
    }
}

