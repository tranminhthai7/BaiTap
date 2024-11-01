using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository) {
            _configRepository = configRepository;
        }

        public Task<bool> AddConfig(Config config)
        {
            return _configRepository.AddConfig(config);
        }

        public Task<bool> DeleteConfigAsync(int configId)
        {
            return _configRepository.DeleteConfigAsync(configId);
        }

        public async Task<List<Config>> GetConfigs()
        {
            return await _configRepository.GetConfigs();
        }

        public Task<bool> UpdateConfig(Config config)
        {
            return _configRepository.UpdateConfig(config);
        }

        public Task<bool> RemoveConfigAsync(Config config)
        {
            throw new NotImplementedException();
        }
    }
}
