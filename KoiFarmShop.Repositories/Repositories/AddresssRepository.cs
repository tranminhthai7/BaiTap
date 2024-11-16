using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
	public class AddresssRepository : IAddresssRepository
	{
		private readonly KoiFarmShop2024DbContext _context;

		public AddresssRepository(KoiFarmShop2024DbContext context)
		{
			_context = context;
		}

		public async Task<List<Addresss>> GetAllAddressesAsync()
		{
			return await _context.Addresss.ToListAsync();
		}

		public async Task<Addresss> GetAddressByIdAsync(int addressId)
		{
			return await _context.Addresss.FindAsync(addressId);
		}

		public async Task AddAddressAsync(Addresss address)
		{
			await _context.Addresss.AddAsync(address);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAddressAsync(Addresss address)
		{
			_context.Addresss.Update(address);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAddressAsync(int addressId)
		{
			var address = await _context.Addresss.FindAsync(addressId);
			if (address != null)
			{
				_context.Addresss.Remove(address);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Addresss> AddAddressFromDetailsAsync(string phone, string company, string address)
		{
			var newAddress = new Addresss
			{
				Company = company,
				Address = address,
				CreatedDate = DateTime.Now
			};

			await _context.Addresss.AddAsync(newAddress);
			await _context.SaveChangesAsync();

			return newAddress;
		}

		public async Task<Addresss> AddAddressAsync(string phone, string company, string address)
		{
			var newAddress = new Addresss
			{
				Company = company,
				Address = address,
				CreatedDate = DateTime.Now
			};

			await _context.Addresss.AddAsync(newAddress);
			await _context.SaveChangesAsync();

			return newAddress;
		}

		public async Task<List<Addresss>> GetAddressesByUserNameAsync(string userName)
		{
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.UserName == userName);

			if (user == null)
			{
				return new List<Addresss>();
			}

			return await _context.Addresss
				.Where(a => a.UserID == user.Id)
				.ToListAsync();
		}

		public Task<List<Addresss>> GetAddresssByEmailAsync(string email)
		{
			throw new NotImplementedException();
		}
	}
}
