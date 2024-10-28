using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public Task<List<TbConfig>> GetConfigsAsync()
        {
            return _configRepository.GetConfigsAsync();
        }

        public Task<int> AddConfigAsync(TbConfig config)
        {
            return _configRepository.AddConfigAsync(config);
        }

        public Task<int> RemoveConfigAsync(int configId)
        {
            return _configRepository.RemoveConfigAsync(configId);
        }

        public Task<bool> DeleteConfigAsync(int configId)
        {
            return _configRepository.DeleteConfigAsync(configId);
        }

        public Task<int> UpdateConfigAsync(TbConfig config)
        {
            return _configRepository.UpdateConfigAsync(config);
        }
    }
}