using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<TbOrder>> GetOrdersAsync()
        {
            return _orderRepository.GetOrdersAsync();
        }

        public Task<int> AddOrderAsync(TbOrder order)
        {
            return _orderRepository.AddOrderAsync(order);
        }

        public Task<int> RemoveOrderAsync(int orderId)
        {
            return _orderRepository.RemoveOrderAsync(orderId);
        }

        public Task<bool> DeleteOrderAsync(int orderId)
        {
            return _orderRepository.DeleteOrderAsync(orderId);
        }

        public Task<int> UpdateOrderAsync(TbOrder order)
        {
            return _orderRepository.UpdateOrderAsync(order);
        }
    }
}