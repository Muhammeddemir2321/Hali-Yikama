using Hali.Core.DTOs;
using Hali.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Sources;

namespace Hali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return CreateActionResult(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return CreateActionResult(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompanyWithUser(CompanyWithUserCreateDto companyWithUserCreateDto)
        {
            return CreateActionResult(await _userService.CreateCompanyWithUserAsync(companyWithUserCreateDto));
        }
    }
}
