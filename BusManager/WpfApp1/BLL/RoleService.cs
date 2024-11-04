using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.DAL.Repositories;

namespace WpfApp1.BLL
{
    public class RoleService
    {
        private RoleRepository _repo = new();

        public List<Role> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
