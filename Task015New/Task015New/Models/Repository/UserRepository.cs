using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task015New.Context;

namespace Task015New.Models.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly UserContext _context;

        public UserRepository()
        {
            _context = new UserContext();
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Entry(GetElementById(id)).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetElement(User item)
        {
            return _context.Users.FirstOrDefault(m => m.Name == item.LastName && m.Email == item.Email);
        }

        public User GetElementById(int id)
        {
            return _context.Users.FirstOrDefault(m => m.Id == id);
        }

        public void Update(User item)
        {
            _context.Entry(GetElementById(item.Id)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<User> UsersPerPage(int page, int pageSize)
        {
            return _context.Users.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}