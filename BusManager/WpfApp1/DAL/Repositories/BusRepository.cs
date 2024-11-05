using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DAL.Repositories
{
    public class BusRepository : GenericRepository<Bus>
    {
    
        public BusRepository(BusManagementSystemContext context) : base(context)
        {
        }
        
        public List<Bus> GetBusesByRoute(int routeId)
        {
            return _context.Buses.Where(b => b.RouteId == routeId).ToList();
        }
    }
}

