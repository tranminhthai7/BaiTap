using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
	public class PromotionRepository : IPromotionRepository
	{
		private readonly KoiFarmShop2024DbContext _dbContext;

		public PromotionRepository(KoiFarmShop2024DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> AddPromotionAsync(Promotion promotion)
		{
			try
			{
				await _dbContext.Promotions.AddAsync(promotion);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception (you can replace this comment with a logging mechanism)
				return false;
			}
		}

		public async Task<bool> DeletePromotionByIdAsync(int promotionId)
		{
			var objDel = await _dbContext.Promotions.FirstOrDefaultAsync(p => p.PromotionId == promotionId);
			if (objDel == null) return false;

			try
			{
				_dbContext.Promotions.Remove(objDel);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception
				return false;
			}
		}

		public async Task<List<Promotion>> GetAllPromotionsAsync()
		{
			try
			{
				return await _dbContext.Promotions.ToListAsync();
			}
			catch (Exception ex)
			{
				// Log the exception
				return new List<Promotion>(); // Return an empty list if there's an exception
			}
		}

		public async Task<bool> RemovePromotionAsync(Promotion promotion)
		{
			try
			{
				_dbContext.Promotions.Remove(promotion);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception
				return false;
			}
		}

		public async Task<bool> UpdatePromotionAsync(Promotion promotion)
		{
			try
			{
				_dbContext.Promotions.Update(promotion);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception
				return false;
			}
		}

		public async Task<Promotion> GetPromotionByIdAsync(int promotionId)
		{
			try
			{
				return await _dbContext.Promotions.FirstOrDefaultAsync(p => p.PromotionId == promotionId);
			}
			catch (Exception ex)
			{
				// Log the exception
				return null;
			}
		}

		public async Task<Promotion> GetPromotionByProductIdAsync(int productId)
		{
			try
			{
				return await _dbContext.Promotions.FirstOrDefaultAsync(p => p.ProductId == productId);
			}
			catch (Exception ex)
			{
				// Log the exception
				return null;
			}
		}
	}
}