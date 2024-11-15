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
    internal class StationService
    {
        private readonly StationRepository _stationRepository;

        public StationService(BusManagementSystemContext _context)
        {
            _stationRepository = new StationRepository(_context);
        }

        public IEnumerable<Station> GetStations()
        {
            return _stationRepository.GetStations();
        }

        public async Task<Station> GetStationAsync(int id)
        {
            return await _stationRepository.GetByIdAsync(id);
        }

        public List<Station> GetStationsNotHaveRoute(IEnumerable<int> routeIds)
        {
            return _stationRepository.GetStationsNotHaveRoute(routeIds);
        }

        public async Task AddStationAsync(Station station)
        {
            await _stationRepository.CreateAsync(station);
        }

        public async Task UpdateStationAsync(Station station)
        {
            await _stationRepository.UpdateAsync(station);
        }

        public async Task DeleteStationAsync(Station station)
        {
            await _stationRepository.RemoveAsync(station);
        }
    }
}
