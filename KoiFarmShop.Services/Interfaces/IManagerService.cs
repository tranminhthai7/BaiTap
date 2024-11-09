using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Services
{
    public interface IManagerService
    {
        Task<List<Manager>> GetManagersAsync();
        Task<bool> AddManagerAsync(Manager manager);
        Task<bool> RemoveManagerAsync(Manager manager);
        Task<bool> DeleteManagerAsync(int managerId);
        Task<bool> UpdateManagerAsync(Manager manager);
    }
}