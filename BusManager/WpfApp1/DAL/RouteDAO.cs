using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BOs;

namespace WpfApp1.DAL
{
    class RouteDAO : GenericRepository<Route>
    {
        public RouteDAO(BusManagementSystemContext context) : base(context)
        {
        }

        public List<Route> GetRoutes()
        {
            return _context.Routes
                .Include(r => r.Buses)
                .Include(r => r.Stations)
                .ToList();
        }

        public Route GetRouteByName(string name)
        {
            return _context.Routes
                .Include(r => r.Buses)
                .Include(r => r.Stations)
                .FirstOrDefault(r => r.Name == name);
        }

        public Route GetRouteById(int id)
        {
            return _context.Routes
                .Include(r => r.Buses)
                .Include(r => r.Stations)
                .FirstOrDefault(r => r.RouteId == id);
        }
    }
}
