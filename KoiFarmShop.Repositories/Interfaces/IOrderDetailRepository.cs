using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetOrderDetails();
        Task<bool> AddOrderDetail(OrderDetail orderDetail);
        Task<bool> RemoveOrderDetailAsync(OrderDetail orderDetail);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
        Task<bool> UpdateOrderDetail(OrderDetail orderDetail);
    }
}
