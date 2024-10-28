using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IConfigRepository
    {
        Task<List<TbConfig>> GetConfigsAsync();
        Task<int> AddConfigAsync(TbConfig config);
        Task<int> RemoveConfigAsync(int configId);
        Task<bool> DeleteConfigAsync(int configId);
        Task<int> UpdateConfigAsync(TbConfig config);
    }
}