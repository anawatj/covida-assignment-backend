using Core.Domains;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductService : IService<ProductInputDto>
    {
        public ProductDto CreateProduct(ProductInputDto product,string userId);

        public ProductDto UpdateProduct(ProductInputDto product,string userId);

        public void DeleteProduct(string productId,string userId);

        public List<ProductDto> FindAllProduct(string userId);

        public ProductDto FindProductById(string productId,string userId);


   
    }
}
