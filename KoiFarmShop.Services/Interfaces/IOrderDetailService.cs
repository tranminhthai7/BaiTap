using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<List<TbOrderDetail>> GetOrderDetailsAsync();
        Task<int> AddOrderDetailAsync(TbOrderDetail orderDetail);
        Task<int> RemoveOrderDetailAsync(int orderDetailId);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
        Task<int> UpdateOrderDetailAsync(TbOrderDetail orderDetail);
    }
}