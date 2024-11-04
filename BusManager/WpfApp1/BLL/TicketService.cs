using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL.Repositories;
using WpfApp1.DAL;
using WpfApp1.Models;

namespace WpfApp1.BLL
{
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

        public List<Ticket> GetTicketsByCustomerId(int id)
        {
            return _ticketRepository.GetTicketsByCustomerId(id);
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
