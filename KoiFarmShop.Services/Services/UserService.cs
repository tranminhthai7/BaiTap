using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities; // Ensure this is the correct namespace for User
using KoiFarmShop.Services.Interfaces; // Ensure this is the correct namespace for IUserService
using KoiFarmShop.Repositories.Interfaces; // Ensure this is the correct namespace for IUserRepository

namespace KoiFarmShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) 
        {
            _repository = repository;
        }

        public bool AddUser(User user) // Ensure you have the User type
        {
            return _repository.AddUser(user);
        }

        public bool DelUser(int Id)
        {
            return _repository.DelUser(Id);
        }

        public bool DelUser(User user)
        {
            return _repository.DelUser(user);
        }

        public Task<User> GetUserById(int Id)
        {
            return _repository.GetUserById(Id);
        }

        public Task<List<User>> GetUsers() // Change method name to match repository interface
        {
            return _repository.GetUsers();
        }

        public bool UpdUser(User user)
        {
            return _repository.UpdUser(user);
        }
    }
}
