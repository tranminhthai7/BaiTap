using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<TbOrder>> GetOrdersAsync();
        Task<int> AddOrderAsync(TbOrder order);
        Task<int> RemoveOrderAsync(int orderId);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<int> UpdateOrderAsync(TbOrder order);
    }
}