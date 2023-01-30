using Hali.Core.DTOs;
using Hali.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(SignInDto signInDto)
        {
            return CreateActionResult(await _authenticationService.CreateTokenAsync(signInDto));
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientSignInDto clientSignInDto)
        {
            return CreateActionResult(_authenticationService.CreateTokenByClientAsync(clientSignInDto));
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateActionResult(await _authenticationService.RevokeRefreshTokenAsync(refreshTokenDto.Token));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateActionResult(await _authenticationService.CreateTokenByRefreshTokenAsync(refreshTokenDto.Token));
        }
    }
}
