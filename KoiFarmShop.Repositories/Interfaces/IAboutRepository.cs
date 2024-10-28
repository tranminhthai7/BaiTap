using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IAboutRepository
    {
        Task<List<TbAbout>> GetAboutsAsync();
        Task<int> AddAboutAsync(TbAbout about);
        Task<int> RemoveAboutAsync(int aboutId);
        Task<bool> DeleteAboutAsync(int aboutId);
        Task<int> UpdateAboutAsync(TbAbout about);
    }
}
