using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;
using WpfApp1.BOs;

namespace WpfApp1.BLL
{
    internal class StationService
    {
        private readonly GenericRepository<Station> _stationRepository;

        public StationService(BusManagementSystemContext _context)
        {
            _stationRepository = new GenericRepository<Station>(_context);
        }

        public async Task<IEnumerable<Station>> GetStationsAsync()
        {
            return await _stationRepository.GetAllAsync();
        }

        public async Task<Station> GetStationAsync(int id)
        {
            return await _stationRepository.GetByIdAsync(id);
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
