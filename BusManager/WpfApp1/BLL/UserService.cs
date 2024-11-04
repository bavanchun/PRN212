using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.DAL.Repositories;

namespace WpfApp1.BLL
{
    public class UserService
    {
        private UserRepository _repo = new();

        public List<User> GetAllUser()
        {
           return _repo.GetUsers();
        }

        public void AddUser(User users)
        {
            _repo.Add(users);
        }

        public void UpdateUser(User users)
        {
            _repo.Update(users);
        }

        public void DeleteUser(User users)
        {
            _repo.Delete(users);
        }
    }
}
