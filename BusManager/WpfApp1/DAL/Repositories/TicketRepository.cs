using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DAL.Repositories
{
    class TicketRepository : GenericRepository<Ticket>
    {
        public TicketRepository(BusManagementSystemContext context) : base(context)
        {
        }

        public List<Ticket> GetTickets()
        {
            return _context.Tickets
                .Include(t => t.Route)
                .Include(t => t.Order)
                .ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _context.Tickets
                .Include(t => t.Route)
                .Include(t => t.Order)
                .FirstOrDefault(t => t.TicketId == id);
        }

        public List<Ticket> GetTicketsByCustomerId(int id)
        {
            return _context.Tickets
                .Include(t => t.Route)
                .Include(t => t.Order)
                .Where(t => t.Order.UserId == id)
                .ToList();
        }

        public List<Ticket> GetTicketsByRouteId(int id)
        {
            return _context.Tickets
                .Include(t => t.Route)
                .Include(t => t.Order)
                .Where(t => t.RouteId == id)
                .ToList();
        }
    }
}
