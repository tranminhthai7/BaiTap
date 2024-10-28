using System;
using System.Collections.Generic;
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

        public Task<List<TbOrderDetail>> GetOrderDetailsAsync()
        {
            return _orderDetailRepository.GetOrderDetailsAsync();
        }

        public Task<int> AddOrderDetailAsync(TbOrderDetail orderDetail)
        {
            return _orderDetailRepository.AddOrderDetailAsync(orderDetail);
        }

        public Task<int> RemoveOrderDetailAsync(int orderDetailId)
        {
            return _orderDetailRepository.RemoveOrderDetailAsync(orderDetailId);
        }

        public Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            return _orderDetailRepository.DeleteOrderDetailAsync(orderDetailId);
        }

        public Task<int> UpdateOrderDetailAsync(TbOrderDetail orderDetail)
        {
            return _orderDetailRepository.UpdateOrderDetailAsync(orderDetail);
        }
    }
}