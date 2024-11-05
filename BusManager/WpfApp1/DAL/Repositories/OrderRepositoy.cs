using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfApp1.Models;

namespace WpfApp1.DAL.Repositories
{
    class OrderRepository : GenericRepository<Order>
    {
        private readonly BusManagementSystemContext _context;

        public OrderRepository(BusManagementSystemContext context) : base(context)
        {
        }

        public List<Order> GetOrders()
        {
            return _context.Orders
                .Include(o => o.Tickets)
                .ToList();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders
                .Include(o => o.Tickets)
                .Where(o => o.UserId == userId)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Tickets)
                .FirstOrDefault(o => o.OrderId == id);
        }
    }
}
