using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;

        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }

        public Task<List<TbKoi>> GetKoisAsync()
        {
            return _koiRepository.GetKoisAsync();
        }

        public Task<int> AddKoiAsync(TbKoi koi)
        {
            return _koiRepository.AddKoiAsync(koi);
        }

        public Task<int> RemoveKoiAsync(int koiId)
        {
            return _koiRepository.RemoveKoiAsync(koiId);
        }

        public Task<bool> DeleteKoiAsync(int koiId)
        {
            return _koiRepository.DeleteKoiAsync(koiId);
        }

        public Task<int> UpdateKoiAsync(TbKoi koi)
        {
            return _koiRepository.UpdateKoiAsync(koi);
        }
    }
}