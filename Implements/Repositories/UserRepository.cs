using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext db;

        public UserRepository(AppDbContext db)
        {
            this.db = db;
        }
        public void Delete(User entity)
        {
            db.Users.Remove(entity);
            db.SaveChanges();
        }

        public List<User> FindAll()
        {
            return this.db.Users.ToList();
        }

        public User? FindByEmail(string email)
        {
            return this.db.Users.Where(t => t.Email == email).FirstOrDefault();
        }

        public User? FindById(string id)
        {
            return this.db.Users.Where(t => t.Id == id).FirstOrDefault();
        }

        public User Save(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public User Update(User entity)
        {
            db.Users.Update(entity);
            db.SaveChanges();
            return entity;
        }
    }
}
