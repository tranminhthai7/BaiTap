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
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public OrderRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddOrder(Order order)
        {
            try
            {
                _dbContext.Orders.AddAsync(order);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var objDel = await _dbContext.Orders.Where(p => p.OrderId.Equals(orderId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Orders.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = null;
            try
            {
                orders = await _dbContext.Orders.ToListAsync();
            }
            catch (Exception ex) 
            {
                orders?.Add(new Order());
            }
            return orders;
        }

        public Task<bool> RemoveOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Update(order);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
