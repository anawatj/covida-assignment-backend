using Core.Domains;
using Core.Dtos;
using Core.Error;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : AbstractController
    {
        private IUserService userService;
        private IConfiguration configuration;
        public UsersController(IConfiguration configuration,IUserService userService)
        {
            this.userService = userService;
            this.configuration = configuration;
        }
      
        [HttpPost]
        public ActionResult<UserDto> SignUp(User user)
        {
            try
            {
                UserDto data = userService.SignUp(user);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUser()
        {
            try
            {
                var userId=ValidateHeader(configuration,Request);
                List<UserDto> datas = userService.FindAllUser(userId);
                return Ok(datas);
            }catch(Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            try
            {
                var userId=ValidateHeader(configuration,Request);
                User data = userService.FindUserById(id,userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }

        [HttpPut]
        public ActionResult<User> UpdateUser(User user)
        {
            try
            {
                var userId=ValidateHeader(configuration,Request);
                User data = userService.Update(user,userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteUser(string id)
        {
            try
            {
                var userId=ValidateHeader(configuration,Request);
                userService.DeleteUser(id,userId);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpPatch]
        public ActionResult<User> ChangePassword(User user)
        {
            try
            {
                var userId=ValidateHeader(configuration,Request);
                var data = userService.ChangePassword(user,userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
        [HttpPost("/login")]
        public ActionResult<UserDto> Login(LoginDto data)
        {
            try
            {
                UserDto user = userService.Login(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return ValidateException(ex);
            }
        }
    }
}
