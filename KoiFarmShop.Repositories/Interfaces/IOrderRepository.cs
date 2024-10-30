using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<bool> AddOrder(Order order);
        Task<bool> RemoveOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<bool> UpdateOrder(Order order);
    }
}
