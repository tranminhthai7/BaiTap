using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) {
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

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }

        public Task<bool> RemoveOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
