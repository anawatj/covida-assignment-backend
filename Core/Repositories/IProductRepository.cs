using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository : IRepository<Product,string>
    {

        List<Product> FindProductByCategory(string categoryId);

        Product? FindByName(string productName);
    }
}
