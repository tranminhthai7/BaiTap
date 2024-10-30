using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IConfigRepository
    {
        Task<List<Config>> GetConfigs();
        Task<bool> AddConfig(Config config);
        Task<bool> RemoveConfigAsync(Config config);
        Task<bool> DeleteConfigAsync(int configId);
        Task<bool> UpdateConfig(Config config);
    }
}
