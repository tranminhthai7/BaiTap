using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public OrderRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbOrder>> GetOrdersAsync()
        {
            try
            {
                return await _dbContext.TbOrders.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbOrder>();
            }
        }

        public async Task<int> AddOrderAsync(TbOrder order)
        {
            try
            {
                await _dbContext.TbOrders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return order.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveOrderAsync(int orderId)
        {
            var order = await _dbContext.TbOrders.FindAsync(orderId);
            if (order == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbOrders.Remove(order);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.TbOrders.FindAsync(orderId);
            if (order == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbOrders.Remove(order);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateOrderAsync(TbOrder order)
        {
            try
            {
                _dbContext.TbOrders.Update(order);
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