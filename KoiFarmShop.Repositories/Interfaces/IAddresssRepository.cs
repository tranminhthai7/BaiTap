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
		Task<Addresss> AddAddressFromDetailsAsync(string phone, string company, string address);
		Task<Addresss> AddAddressAsync(string phone, string company, string address);
		Task<List<Addresss>> GetAddressesByUserNameAsync(string userName);
		Task<List<Addresss>> GetAddresssByEmailAsync(string email);
	}
}
