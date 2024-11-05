using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;
using WpfApp1.Models;
using WpfApp1.DAL.Repositories;

namespace WpfApp1.BLL
{
    class RouteService
    {
        private RouteRepository routeRepository;

        public RouteService(BusManagementSystemContext _context)
        {
            routeRepository = new RouteRepository(_context);
        }

        public List<Route> GetRoutes()
        {
            return routeRepository.GetAll();
        }

        public List<Route> GetRoutesGoThroughStation(int from, int to)
        {
            var routes = new List<Route>();

            routes.AddRange(
                routeRepository.GetRoutes()
                .Where(r => r.Stations.Any(s => s.StationId == from) && r.Stations.Any(s => s.StationId == to))
            );

            return routes;
        }
    }
}