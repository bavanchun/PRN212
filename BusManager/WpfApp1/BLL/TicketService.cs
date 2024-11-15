using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL.Repositories;
using WpfApp1.DAL;
using WpfApp1.Models;
using System.Windows.Documents;

namespace WpfApp1.BLL
{
    class TicketView
    {
        public string Route { get; set; }
        public string Status { get; set; }
        public string Buses { get; set; }
        public int Count { get; set; }
    }
    class TicketService
    {
        private TicketRepository _ticketRepository;

        public TicketService(BusManagementSystemContext context)
        {
            _ticketRepository = new TicketRepository(context);
        }

        public List<Ticket> GetTickets()
        {
            return _ticketRepository.GetTickets();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetTicketById(id);
        }

        public List<TicketView> GetTicketsByCustomerId(int id)
        {
            List<Ticket> tickets = _ticketRepository.GetTicketsByCustomerId(id);

            if (tickets == null)
            {
                return null;
            }

            List<TicketView> data = new List<TicketView>();
            var groups = tickets.GroupBy(ticket => new { route = ticket.RouteId, status = ticket.Status });

            foreach (var group in groups)
            {
                data.Add(group.Select(ticket => new TicketView()
                {
                    Status = ticket.Status,
                    Route = ticket.Route.Name,
                    Buses = string.Join(" | ", ticket.Route.Buses.Select(b => b.LicensePlate)),
                    Count = group.Count(),
                }).OrderBy(t => t.Status == "available" ? 0 : 1).First());
            }

            return data;
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketRepository.Create(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            _ticketRepository.Remove(ticket);
        }

        public void DeleteTicketById(int id)
        {
            var ticket = GetTicketById(id);
            _ticketRepository.Remove(ticket);
        }

        public List<Ticket> GetTicketsByRouteId(int id)
        {
            return _ticketRepository.GetTicketsByRouteId(id);
        }
    }
}
