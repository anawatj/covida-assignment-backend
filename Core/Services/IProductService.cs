using Core.Domains;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductService : IService<Product>
    {
        public Product CreateProduct(Product product,string userId);

        public Product UpdateProduct(Product product,string userId);

        public void DeleteProduct(string productId,string userId);

        public List<ProductDto> FindAllProduct(string userId);

        public Product FindProductById(string productId,string userId);


   
    }
}
