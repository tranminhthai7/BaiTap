using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Services.Interfaces
{
    public interface IAboutService
    {
        Task<List<About>> GetAboutsAsync();
        Task<bool> AddAbout(About about);
        Task<bool> RemoveAboutAsync(About about);
        Task<bool> DeleteAboutAsync(int aboutId);
        Task<bool> UpdateAbout(About about);
    }
}
