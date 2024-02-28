using Core.Error;
using Implements.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AbstractController : ControllerBase
    {
        protected ActionResult ValidateException(Exception ex)
        {
            if(ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }else if(ex is FieldValueException)
            {
                return BadRequest(ex.Message);
            }else if(ex is BadRequestException)
            {
                return BadRequest(ex.Message);
            }else if(ex is UnAuthorizeException)
            {
                return Unauthorized(ex.Message);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        protected string ValidateHeader(IConfiguration _config,HttpRequest request)
        {
            var header = request.Headers.Authorization;
            if (string.IsNullOrEmpty(header))
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            var userId = Jwt.ValidateToken(_config,header);
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            return userId;
        }
    }
}
