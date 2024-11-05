using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;

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

        //search
        public List<User> SearchUsersByNameAndRoleId(string? name = null, int? roleId = null)
        {
            List<User> result = _repo.GetUsers();
            if(name.IsNullOrEmpty() && !roleId.HasValue)
            {
                return result;
            } else if (!name.IsNullOrEmpty())
            {
                result = result.Where(u => u.Name.ToLower().Contains(name.ToLower())).ToList(); 
            }
            else if (roleId.HasValue)
            {
                result = result.Where(u => u.RoleId == roleId).ToList();
            }
            return result;
        }
    }
}
