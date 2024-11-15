using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Service.Services
{
	public class AddresssService : IAddresssService
	{
		private readonly IAddresssRepository _addresssRepository;

		public AddresssService(IAddresssRepository addresssRepository)
		{
			_addresssRepository = addresssRepository;
		}

		public async Task<List<Addresss>> GetAllAddressesAsync()
		{
			return await _addresssRepository.GetAllAddressesAsync();
		}

		public async Task<Addresss> GetAddressByIdAsync(int addressId)
		{
			return await _addresssRepository.GetAddressByIdAsync(addressId);
		}

		public async Task AddAddressAsync(Addresss address)
		{
			await _addresssRepository.AddAddressAsync(address);
		}

		public async Task UpdateAddressAsync(Addresss address)
		{
			await _addresssRepository.UpdateAddressAsync(address);
		}

		public async Task DeleteAddressAsync(int addressId)
		{
			await _addresssRepository.DeleteAddressAsync(addressId);
		}
	}
}
