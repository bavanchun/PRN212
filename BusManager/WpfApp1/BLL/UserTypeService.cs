using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BOs;
using WpfApp1.DAL.Repositories;

namespace WpfApp1.BLL
{
    public class UserTypeService
    {
        private UserTypeRepository _repo = new();

        public List<UserType> GetAll()
        {
            return _repo.GetAll();
        }

    }
}
