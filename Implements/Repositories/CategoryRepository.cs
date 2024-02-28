using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext db;
        public CategoryRepository(AppDbContext db)
        {
            this.db = db;
        }
        public void Delete(Category entity)
        {
            this.db.Categories.Remove(entity);
            this.db.SaveChanges();
        }

        public List<Category> FindAll()
        {
            return this.db.Categories.ToList();
        }

        public Category? FindById(string id)
        {
            return this.db.Categories.Where(t => t.Id == id).FirstOrDefault();
        }

        public Category? FindByName(string categoryName)
        {
            return this.db.Categories.Where(t => t.CategoryName == categoryName).FirstOrDefault();
        }

        public Category Save(Category entity)
        {
            this.db.Categories.Add(entity);
            this.db.SaveChanges();
            return entity;
        }

        public Category Update(Category entity)
        {
            this.db.Categories.Update(entity);
            this.db.SaveChanges();
            return entity;
        }
    }
}
