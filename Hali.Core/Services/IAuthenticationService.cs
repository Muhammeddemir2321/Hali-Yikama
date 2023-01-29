using Hali.Core.DTOs;
using Hali.Shared.DTOs;

namespace Hali.Core.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseDto<TokenDto>> CreateTokenAsync(SignInDto signInDto);
        Task<ResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
        Task<ResponseDto<NoContent>> RevokeRefreshTokenAsync(string refreshToken);
        ResponseDto<ClientTokenDto> CreateTokenByClientAsync(ClientSignInDto clientSignInDto);
    }
}
