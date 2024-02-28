using Core.Domains;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : AbstractController
    {
        private ICategoryService categoryService;
        private IConfiguration configuration;
        public CategoriesController(IConfiguration configuration,ICategoryService categoryService)
        {
            this.configuration = configuration;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategory()
        {
            try
            {
                var userId = ValidateHeader(configuration, Request);
                List<CategoryDto> datas = categoryService.FindAllCategory(userId);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory(CategoryDto category)
        {
            try
            {
                var userId = ValidateHeader(configuration, Request);
                CategoryDto data = categoryService.CreateCategory(category,userId);
                return Ok(data);
            }catch(Exception ex)
            {
                return ValidateException(ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategoryById(string id)
        {
            try
            {
                var userId = ValidateHeader(configuration, Request);
                CategoryDto data = categoryService.FindCategoryById(id, userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }

        [HttpPut]
        public ActionResult<CategoryDto> UpdateCategory(CategoryDto category)
        {
            try
            {
                var userId = ValidateHeader(configuration, Request);
                CategoryDto data = categoryService.UpdateCategory(category, userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }

        [HttpGet("{id}/Products")]
        public ActionResult<IEnumerable<ProductDto>> GetAllCategory(string id)
        {
            try
            {
                var userId = ValidateHeader(configuration, Request);
                List<ProductDto> datas = categoryService.FindAllProductInCategory(id, userId);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCategory(string id)
        {
            try
            {
                var userId = ValidateHeader(configuration, Request);
                categoryService.DeleteCategory(id, userId);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
    }
}
