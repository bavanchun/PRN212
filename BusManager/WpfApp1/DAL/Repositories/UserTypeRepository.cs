using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BOs;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.DAL.Repositories
{
    public class UserTypeRepository
    {
        private BusManagementSystemContext _context;

        public List<UserType> GetAll()
        {
            _context = new();
            return _context.UserTypes.ToList();
        }
    }
}
