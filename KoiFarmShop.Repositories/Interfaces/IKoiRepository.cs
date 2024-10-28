using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IKoiRepository
    {
        Task<List<TbKoi>> GetKoisAsync();
        Task<int> AddKoiAsync(TbKoi koi);
        Task<int> RemoveKoiAsync(int koiId);
        Task<bool> DeleteKoiAsync(int koiId);
        Task<int> UpdateKoiAsync(TbKoi koi);
    }
}