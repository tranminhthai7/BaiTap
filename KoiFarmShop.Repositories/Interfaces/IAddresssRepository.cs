using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IAddresssRepository
    {
        Task<List<Addresss>> GetAllAddressesAsync();
        Task<Addresss> GetAddressByIdAsync(int addressId);
        Task AddAddressAsync(Addresss address);
        Task UpdateAddressAsync(Addresss address);
        Task DeleteAddressAsync(int addressId);
        Task<List<Addresss>> GetAddressesByUserNameAsync(string userName);
    }
}