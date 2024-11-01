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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<bool> AddOrder(Order order)
        {
            return _orderRepository.AddOrder(order);
        }

        public Task<bool> DeleteOrderAsync(int orderId)
        {
            return _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrders();
        }

        public Task<bool> RemoveOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }
    }
}
