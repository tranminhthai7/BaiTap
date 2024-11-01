using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities; 
using KoiFarmShop.Services.Interfaces; 
using KoiFarmShop.Repositories.Interfaces; 

namespace KoiFarmShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) 
        {
            _repository = repository;
        }

        public bool AddUser(User user)
        {
            return _repository.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _repository.DeleteUser(id);
        }

        public bool DeleteUser(User user)
        {
            return _repository.DeleteUser(user);
        }

        public Task<User> GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public Task<List<User>> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public bool UpdateUser(User user)
        {
            return _repository.UpdateUser(user);
        }
    }
}
