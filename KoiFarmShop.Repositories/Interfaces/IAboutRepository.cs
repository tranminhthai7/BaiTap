using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IAboutRepository
    {
        Task<List<About>> GetAboutsAsync();
        Task<bool> AddAboutAsync(About about);
        Task<bool> RemoveAboutAsync(About about);
        Task<bool> DeleteAboutAsync(int aboutId);
        Task<bool> UpdateAboutAsync(About about);
    }
}
