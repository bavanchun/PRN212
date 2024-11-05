using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.DAL.Repositories;
using WpfApp1.Models;

namespace WpfApp1.BLL
{
    public class BusService
    {

        private readonly BusRepository _busRepository;

        public BusService(BusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public List<Bus> GetAllBuses()
        {
            return _busRepository.GetAll();
        }

        public void AddBus(Bus bus)
        {
            _busRepository.Create(bus);
        }

        public void UpdateBus(Bus bus)
        {
            _busRepository.Update(bus);
        }

        public void DeleteBus(Bus bus)
        {
            _busRepository.Remove(bus);
        }

        public Bus GetBusById(int busId)
        {
            return _busRepository.GetById(busId);
        }

        public List<Bus> GetBusesByRoute(int routeId)
        {
            return _busRepository.GetBusesByRoute(routeId);
        }
    }
}
