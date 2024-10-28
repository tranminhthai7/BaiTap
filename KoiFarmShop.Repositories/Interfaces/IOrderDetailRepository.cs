using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<List<TbOrderDetail>> GetOrderDetailsAsync();
        Task<int> AddOrderDetailAsync(TbOrderDetail orderDetail);
        Task<int> RemoveOrderDetailAsync(int orderDetailId);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
        Task<int> UpdateOrderDetailAsync(TbOrderDetail orderDetail);
    }
}