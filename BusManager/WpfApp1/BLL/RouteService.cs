using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;
using WpfApp1.BOs;

namespace WpfApp1.BLL
{
    class RouteService
    {
        private RouteDAO routeDAO;

        public RouteService(BusManagementSystemContext _context)
        {
            routeDAO = new RouteDAO(_context);
        }

        public List<Route> GetRoutes()
        {
            return routeDAO.GetRoutes();
        }

        public List<Route> GetRoutesGoThroughStation(int from, int to)
        {
            var routes = new List<Route>();

            routes.AddRange(
                routeDAO.GetRoutes()
                .Where(r => r.Stations.Any(s => s.StationId == from) && r.Stations.Any(s => s.StationId == to))
            );

            return routes;
        }
    }
}
