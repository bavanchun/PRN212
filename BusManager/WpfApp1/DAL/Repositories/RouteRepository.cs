using Microsoft.EntityFrameworkCore;
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
    class RouteRepository: GenericRepository<Route>
    {

        public RouteRepository(BusManagementSystemContext _context): base(_context)
        {
        }

        public List<Route> GetRoutes()
        {
            return _context.Routes
                .Include(r => r.Stations)
                .Include(r => r.Buses)
                .ToList();
        }
    }
}
