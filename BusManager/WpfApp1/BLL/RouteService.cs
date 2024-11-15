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
    public class RouteService
    {
        private RouteRepository routeRepository;

        public RouteService(BusManagementSystemContext _context)
        {
            routeRepository = new RouteRepository(_context);
        }

        public List<Route> GetRoutes()
        {
            return routeRepository.GetRoutes();
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

        public List<Route> GetRoutesNotGoThroughStation(int from, int to)
        {
            var routes = new List<Route>();

            routes.AddRange(
                routeRepository.GetRoutes()
                .Where(r => r.Stations.Any(s => s.StationId != from) && r.Stations.Any(s => s.StationId != to))
            );

            return routes;
        }

        public void AddRoute(Route route)
        {
            routeRepository.Create(route);
        }

        public void UpdateRoute(Route route)
        {
            routeRepository.Update(route);
        }

        public void DeleteRoute(Route route)
        {
            routeRepository.Remove(route);
        }

    }
}