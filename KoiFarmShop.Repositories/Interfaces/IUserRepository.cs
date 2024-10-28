using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<TbUser>> GetUsersAsync();
        Task<int> AddUserAsync(TbUser user);
        Task<int> RemoveUserAsync(int userId);
        Task<bool> DeleteUserAsync(int userId);
        Task<int> UpdateUserAsync(TbUser user);
    }
}