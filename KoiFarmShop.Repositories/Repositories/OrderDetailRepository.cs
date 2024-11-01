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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public OrderDetailRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _dbContext.OrderDetails.AddAsync(orderDetail);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            var objDel = await _dbContext.OrderDetails.Where(p => p.OrderId.Equals(orderDetailId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.OrderDetails.Remove(objDel);
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

        public async Task<List<OrderDetail>> GetOrderDetails()
        {
            List<OrderDetail> orderDetails = null;
            try
            {
                orderDetails = await _dbContext.OrderDetails.ToListAsync();
            }
            catch (Exception ex) 
            {
                orderDetails?.Add(new OrderDetail());
            }
            return orderDetails;
        }

        public Task<bool> RemoveOrderDetailAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _dbContext.OrderDetails.Update(orderDetail);
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
