using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public OrderDetailRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbOrderDetail>> GetOrderDetailsAsync()
        {
            try
            {
                return await _dbContext.TbOrderDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbOrderDetail>();
            }
        }

        public async Task<int> AddOrderDetailAsync(TbOrderDetail orderDetail)
        {
            try
            {
                await _dbContext.TbOrderDetails.AddAsync(orderDetail);
                await _dbContext.SaveChangesAsync();
                return orderDetail.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveOrderDetailAsync(int orderDetailId)
        {
            var orderDetail = await _dbContext.TbOrderDetails.FindAsync(orderDetailId);
            if (orderDetail == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbOrderDetails.Remove(orderDetail);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            var orderDetail = await _dbContext.TbOrderDetails.FindAsync(orderDetailId);
            if (orderDetail == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbOrderDetails.Remove(orderDetail);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateOrderDetailAsync(TbOrderDetail orderDetail)
        {
            try
            {
                _dbContext.TbOrderDetails.Update(orderDetail);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}