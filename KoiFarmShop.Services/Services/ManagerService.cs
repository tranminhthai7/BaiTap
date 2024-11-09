using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Services.Interfaces;

using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace KoiFarmShop.Services.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<List<Manager>> GetManagersAsync()
        {
            return await _managerRepository.GetManagers();
        }

        public async Task<bool> AddManagerAsync(Manager manager)
        {
            return await _managerRepository.AddManager(manager);
        }

        public async Task<bool> RemoveManagerAsync(Manager manager)
        {
            return await _managerRepository.RemoveManagerAsync(manager);
        }

        public async Task<bool> DeleteManagerAsync(int managerId)
        {
            return await _managerRepository.DeleteManagerAsync(managerId);
        }

        public async Task<bool> UpdateManagerAsync(Manager manager)
        {
            return await _managerRepository.UpdateManager(manager);
        }
    }
}