using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public Task<bool> AddOrderDetail(OrderDetail orderDetail)
        {
            return _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            return _orderDetailRepository.DeleteOrderDetailAsync(orderDetailId);
        }

        public async Task<List<OrderDetail>> GetOrderDetailsAsync()
        {
            return await _orderDetailRepository.GetOrderDetails();
        }

        public Task<bool> RemoveOrderDetailAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            return _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
