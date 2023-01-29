using Hali.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDto<T> responce)
        {
            if (responce.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = responce.StatusCode };
            }

            return new ObjectResult(responce) { StatusCode = responce.StatusCode };
        }
    }
}

