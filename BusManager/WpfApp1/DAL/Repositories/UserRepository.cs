using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DAL.Repositories
{
    public class UserRepository
    {
        private BusManagementSystemContext _context;

        public User? GetOne(string username, string password)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        }

        public List<User> GetUsers()
        {
            _context = new();
            return _context.Users.Include("Role").Include("UserType").ToList();
        }

        public void Add(User users)
        {
            _context = new();
            _context.Users.Add(users);
            _context.SaveChanges();
        }

        public void Update(User users)
        {
            _context = new();

            var existingUser = _context.Users.FirstOrDefault(u => u.UserId == users.UserId);
            if (existingUser != null)
            {
                if (_context.Users.Any(u => u.Username == users.Username && u.UserId != users.UserId))
                {
                    throw new Exception("Username already exists.");
                }

                existingUser.Password = users.Password;
                existingUser.Name = users.Name;
                existingUser.RoleId = users.RoleId;
                existingUser.UserTypeId = users.UserTypeId;
                existingUser.Username = users.Username; // Ensure this is updated correctly
            }
            _context.Users.Update(existingUser);
            _context.SaveChanges();
        }

        public void Delete(User users)
        {
            _context = new();
            _context.Users.Remove(users);
            _context.SaveChanges();
        }

        
    }
}
