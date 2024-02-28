using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Implements.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext db;
        public ProductRepository(AppDbContext db)
        {
            this.db = db;
        }
        public void Delete(Product entity)
        {
            this.db.Products.Remove(entity);
            this.db.SaveChanges();
        }

        public List<Product> FindAll()
        {
            return this.db.Products.Include(t => t.Category).ToList();
        }

        public Product? FindById(string id)
        {
            return this.db.Products.Include(t=>t.Category).Where(t => t.Id == id).FirstOrDefault();
        }

        public Product? FindByName(string productName)
        {
            return this.db.Products.Include(t => t.Category).Where(t => t.ProductName == productName).FirstOrDefault();
        }

        public List<Product> FindProductByCategory(string categoryId)
        {
            return this.db.Products.Include(t => t.Category).Where(t => t.CategoryId == categoryId).ToList();
        }

        public Product Save(Product entity)
        {
            this.db.Products.Add(entity);
            this.db.SaveChanges();
            return entity;
        }

        public Product Update(Product entity)
        {
            this.db.Products.Update(entity);
            this.db.SaveChanges();
            return entity;
        }
    }
}
