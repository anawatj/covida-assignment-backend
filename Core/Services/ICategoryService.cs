using Core.Domains;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICategoryService : IService<CategoryDto>
    {
        public CategoryDto CreateCategory(CategoryDto category,string userId);
        public CategoryDto UpdateCategory(CategoryDto category,string userId);

        public void DeleteCategory(string categoryId,string userId);

        public List<CategoryDto> FindAllCategory(string userId);

        public CategoryDto FindCategoryById(string categoryId,string userId);


       


        public List<ProductDto> FindAllProductInCategory(string categoryId,string userId);
    }
}
