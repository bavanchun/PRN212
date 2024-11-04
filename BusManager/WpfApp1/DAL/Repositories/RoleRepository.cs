using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BOs;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.DAL.Repositories
{
    public class RoleRepository
    {
        private BusManagementSystemContext _context;

        public List<Role> GetAll()
        {
            _context = new();
            return _context.Roles.ToList();
        }    
    }


}

