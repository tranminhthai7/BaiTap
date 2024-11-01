using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IKoiService
    {
        Task<List<Koi>> GetKois();
        Task<bool> AddKoi(Koi koi);
        Task<bool> RemoveKoiAsync(Koi koi);
        Task<bool> DeleteKoiAsync(int koiId);
        Task<bool> UpdateKoi(Koi koi);
    }
}
