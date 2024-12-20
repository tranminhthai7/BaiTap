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
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;

        public KoiService(IKoiRepository koiRepository) {
            _koiRepository = koiRepository;
        }

        public Task<bool> AddKoi(Koi koi)
        {
            return _koiRepository.AddKoi(koi);
        }

        public Task<bool> DeleteKoiAsync(int koiId)
        {
            return _koiRepository.DeleteKoiAsync(koiId);
        }

        public async Task<List<Koi>> GetKois()
        {
            return await _koiRepository.GetKois();
        }

        public Task<bool> UpdateKoi(Koi koi)
        {
            return _koiRepository.UpdateKoi(koi);
        }

        public Task<bool> RemoveKoiAsync(Koi koi)
        {
            throw new NotImplementedException();
        }
    }
}
