using AutoMapper;
using Core.Domains;
using Core.Dtos;
using Core.Error;
using Core.Repositories;
using Core.Services;
using Implements.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Services
{
    public class CategoryService : ICategoryService
    {
        private AppDbContext db;
        private IMapper mapper;
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public CategoryService(AppDbContext db,IMapper mapper,IUserRepository userRepository,ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            this.db = db;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }

        public CategoryDto CreateCategory(CategoryDto input, string userId)
        {
            
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }

            List<string> errors = Validate(input);
            if(errors.Count > 0)
            {
                throw new FieldValueException(string.Join(",", errors));
            }
            Category? category = this.categoryRepository.FindByName(input.CategoryName);
            if (category != null)
            {
                throw new BadRequestException("category name in used");
            }
            Category data = mapper.Map<CategoryDto, Category>(input);
            data.Id = UUID.GenerateUUID();
            Category ret = this.categoryRepository.Save(data);
            return mapper.Map<Category,CategoryDto>(data);
        }

        public void DeleteCategory(string categoryId, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            Category? category = this.categoryRepository.FindById(categoryId);
            if (category == null)
            {
                throw new NotFoundException("Category Not Found");
            }
            this.categoryRepository.Delete(category);
        }

        public List<CategoryDto> FindAllCategory( string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<Category> categories = this.categoryRepository.FindAll();
            if (categories.Count == 0)
            {
                throw new NotFoundException("Category Not Found");
            }
            return mapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public List<ProductDto> FindAllProductInCategory(string categoryId, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<Product> products = this.productRepository.FindProductByCategory(categoryId);
            if (products.Count == 0)
            {
                throw new NotFoundException("Product Not Found");
            }
            return mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public CategoryDto FindCategoryById(string categoryId, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            Category? category = this.categoryRepository.FindById(categoryId);
            if (category == null)
            {
                throw new NotFoundException("Category Not Found");
            }
            return mapper.Map<Category,CategoryDto>(category);
        }

        public CategoryDto UpdateCategory(CategoryDto input, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<string> errors = Validate(input);
            if (errors.Count > 0)
            {
                throw new FieldValueException(string.Join(",", errors));
            }
            Category? category = this.categoryRepository.FindByName(input.CategoryName);
            if (category != null)
            {
                if (input.Id != category.Id)
                {
                    throw new BadRequestException("category name in used");
                }
                
            }
            Category data = mapper.Map<CategoryDto, Category>(input);
            Category ret = this.categoryRepository.Update(data);
            return mapper.Map<Category,CategoryDto>(ret);
        }

        public List<string> Validate(CategoryDto data)
        {

            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(data.CategoryName))
            {
                errors.Add("Category Name is Required");
            }
            if (string.IsNullOrEmpty(data.Title))
            {
                errors.Add("Title Name is Required");
            }
            if (string.IsNullOrEmpty(data.Description))
            {
                errors.Add("Description is Required");
            }

            return errors;
        }
    }
}
