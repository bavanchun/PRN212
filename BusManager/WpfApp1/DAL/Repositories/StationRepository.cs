using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DAL.Repositories
{
    class StationRepository : GenericRepository<Station>
    {

        public StationRepository(BusManagementSystemContext _context) : base(_context)
        {
        }

        public List<Station> GetStations()
        {
            return _context.Stations
                .Include(s => s.Routes)
                .ToList();
        }

        public List<Station> GetStationsNotHaveRoute(IEnumerable<int> routeIds)
        {
            return _context.Stations
            .Include(s => s.Routes)
            .Where(s => !s.Routes.Any(r => routeIds.Contains(r.RouteId)))
            .ToList();
        }
    }
}
