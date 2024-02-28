using AutoMapper;
using Core.Domains;
using Core.Dtos;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Error;
using Implements.Utils;

namespace Implements.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private IMapper mapper;
        private AppDbContext db;
        private IUserRepository userRepository;
        private ICategoryRepository categoryRepository;
        public ProductService(AppDbContext db,IMapper mapper,IUserRepository userRepository,ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            this.db = db;
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.categoryRepository = categoryRepository;
        }
        public ProductDto CreateProduct(ProductInputDto input, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<string> errors = Validate(input);
            if (errors.Count > 0)
            {
                throw new FieldValueException(String.Join(",", errors));
            }
            Product? product = this.productRepository.FindByName(input.ProductName);
            if (product != null)
            {
                throw new BadRequestException("Product Name is used");
            }
            Category? category = this.categoryRepository.FindById(input.CategoryId);
            if (category == null)
            {
                throw new BadRequestException("Category is not found");
            }
            Product data = mapper.Map<ProductInputDto, Product>(input);
            data.Id = UUID.GenerateUUID();
            Product ret = this.productRepository.Save(data);
            return mapper.Map<Product,ProductDto>(ret);
        }

        public void DeleteProduct(string productId, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            Product? product = this.productRepository.FindById(productId);
            if (product == null)
            {
                throw new NotFoundException("Product Not Found");
            }
            this.productRepository.Delete(product);
        }

        public List<ProductDto> FindAllProduct( string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<Product> products = this.productRepository.FindAll();
            if (products.Count == 0)
            {
                throw new NotFoundException("Product Not Found");
            }
            return mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public ProductDto FindProductById(string productId, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            Product? product = this.productRepository.FindById(productId);
            if (product == null)
            {
                throw new NotFoundException("Product Not Found");
            }
            return mapper.Map<Product,ProductDto>(product);
        }

        public ProductDto UpdateProduct(ProductInputDto input, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<string> errors = Validate(input);
            if (errors.Count > 0)
            {
                throw new FieldValueException(String.Join(",", errors));
            }
            Product? product = this.productRepository.FindByName(input.ProductName);
            if (product != null)
            {
                if(input.Id != product.Id)
                {
                    throw new BadRequestException("Product Name is used");
                }
             
            }
            Category? category = this.categoryRepository.FindById(input.CategoryId);
            if (category == null)
            {
                throw new BadRequestException("Category Not Found");
            }
            Product data = mapper.Map<ProductInputDto, Product>(input);
            Product ret = this.productRepository.Update(data);
            return mapper.Map<Product,ProductDto>(ret);
        }

        public List<string> Validate(ProductInputDto data)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(data.ProductName))
            {
                errors.Add("Product Name is required");
            }
            if (string.IsNullOrEmpty(data.Title))
            {
                errors.Add("Product Title is required");
            }
            if (string.IsNullOrEmpty(data.Description))
            {
                errors.Add("Product Description is required");
            }
            if (string.IsNullOrEmpty(data.CategoryId))
            {
                errors.Add("Product Category is required");
            }
            if (data.Price <= 0)
            {
                errors.Add("Product Price is more than 0");
            }
            return errors;
        }
    }
}
