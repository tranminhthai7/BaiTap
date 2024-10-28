using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<TbUser>> GetUsersAsync()
        {
            return _userRepository.GetUsersAsync();
        }

        public Task<int> AddUserAsync(TbUser user)
        {
            return _userRepository.AddUserAsync(user);
        }

        public Task<int> RemoveUserAsync(int userId)
        {
            return _userRepository.RemoveUserAsync(userId);
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            return _userRepository.DeleteUserAsync(userId);
        }

        public Task<int> UpdateUserAsync(TbUser user)
        {
            return _userRepository.UpdateUserAsync(user);
        }
    }
}