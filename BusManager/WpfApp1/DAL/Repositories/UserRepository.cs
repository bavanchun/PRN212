using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BOs;

namespace WpfApp1.DAL.Repositories
{
    public class UserRepository
    {
        private BusManagementSystemContext _context;

        public List<User> GetUsers()
        {
            _context = new();
            return _context.Users.ToList();
        }
    }
}
