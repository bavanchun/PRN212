using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;
using WpfApp1.DAL.Repositories;
using WpfApp1.Models;

namespace WpfApp1.BLL
{
    class OrderService
    {
        private readonly OrderRepository _orderRepository;
        public OrderService(BusManagementSystemContext _context)
        {
            _orderRepository = new OrderRepository(_context);
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _orderRepository.GetOrdersByUserId(userId);
        }

        public Order GetOrderById(int id) {
            return _orderRepository.GetOrderById(id);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void RemoveOrder(Order order) {
            _orderRepository.Remove(order);
        }
    }
}
