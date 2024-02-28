using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : AbstractController
    {
        private IProductService productService;
        private IConfiguration configuration;
        public ProductsController(IConfiguration configuration,IProductService productService)
        {
            this.productService = productService;
            this.configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAllProduct()
        {
            try
            {
                string userId = ValidateHeader(configuration, Request);
                List<ProductDto> datas = productService.FindAllProduct(userId);
                return Ok(datas);
            }catch(Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductInputDto product)
        {
            try
            {
                string userId = ValidateHeader(configuration, Request);
                ProductDto data = productService.CreateProduct(product,userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductById(string id)
        {
            try
            {
                string userId = ValidateHeader(configuration, Request);
                ProductDto data = productService.FindProductById(id, userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }

        [HttpPut]
        public ActionResult<ProductDto> UpdateProduct(ProductInputDto product)
        {
            try
            {
                string userId = ValidateHeader(configuration, Request);
                ProductDto data = productService.UpdateProduct(product, userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            try
            {
                string userId = ValidateHeader(configuration, Request);
                productService.DeleteProduct(id, userId);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
    }
}
