using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Task<List<Manager>> GetManagers();
        Task<bool> AddManager(Manager manager);
        Task<bool> RemoveManagerAsync(Manager manager);
        Task<bool> DeleteManagerAsync(int managerId);
        Task<bool> UpdateManager(Manager manager);
    }
}