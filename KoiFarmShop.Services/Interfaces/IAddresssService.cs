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
		Task<Addresss> AddAddressFromCookieAsync(string phone, string company, string address);

		// Đảm bảo phương thức này có mặt trong interface
		Task<Addresss> AddAddressFromDetailsAsync(string phone, string company, string address);
		Task<List<Addresss>> GetAddressesByUserNameAsync(string userName);
	}
}
