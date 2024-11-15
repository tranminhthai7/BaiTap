using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Service.Interfaces
{
	public interface IAddresssService
	{
		Task<List<Addresss>> GetAllAddressesAsync();
		Task<Addresss> GetAddressByIdAsync(int addressId);
		Task AddAddressAsync(Addresss address);
		Task UpdateAddressAsync(Addresss address);
		Task DeleteAddressAsync(int addressId);
	}
}
