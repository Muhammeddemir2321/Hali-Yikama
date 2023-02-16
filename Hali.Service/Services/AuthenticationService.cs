using Hali.Core.Configurations;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Hali.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepository<UserRefreshToken> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IOptions<List<Client>> options, ITokenService tokenService, UserManager<AppUser> userManager, IGenericRepository<UserRefreshToken> repository, IUnitOfWork unitOfWork)
        {
            _clients = options.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenAsync(SignInDto signInDto)
        {
            if (signInDto == null) throw new ArgumentNullException(nameof(signInDto));

            var user = await _userManager.FindByEmailAsync(signInDto.Email);

            if (user == null) ResponseDto<TokenDto>.Fail("Email or Password is wrong", StatusCodes.Status400BadRequest, true);
            if (user != null)
            {
                if (!await _userManager.CheckPasswordAsync(user, signInDto.Password))
                    return ResponseDto<TokenDto>.Fail("Email or Password is wrong", StatusCodes.Status400BadRequest, true);
                var tokenDto = _tokenService.CreateToken(user);

                var userRefreshToken = await _repository.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

                if (userRefreshToken == null)
                {
                    await _repository.AddAsync(new UserRefreshToken { UserId = user.Id, Code = tokenDto.RefreshToken, Expiration = tokenDto.RefreshTokenExpiration });
                }
                else
                {
                    userRefreshToken.Code = tokenDto.RefreshToken;
                    userRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
                }

                await _unitOfWork.CommitAsync();

                return ResponseDto<TokenDto>.Succes(tokenDto, StatusCodes.Status201Created);
            }

            return ResponseDto<TokenDto>.Fail("Bilinmeyen bir hata oluştu", StatusCodes.Status500InternalServerError, false);

        }

        public ResponseDto<ClientTokenDto> CreateTokenByClientAsync(ClientSignInDto clientSignInDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientSignInDto.ClientId && x.Secret == clientSignInDto.ClientSecret);

            if (client == null)
            {
                ResponseDto<ClientTokenDto>.Fail("ClientId or ClientSecret not Found", StatusCodes.Status404NotFound, true);
            }

            var clientTokenDto = _tokenService.CreateTokenByClient(client);

            return  ResponseDto<ClientTokenDto>.Succes(clientTokenDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _repository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null) ResponseDto<TokenDto>.Fail("Refresh token not found", StatusCodes.Status404NotFound, true);

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);

            if (user == null) ResponseDto<TokenDto>.Fail("User not found", StatusCodes.Status404NotFound, true);

            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();

            return ResponseDto<TokenDto>.Succes(tokenDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<NoContent>> RevokeRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _repository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null) ResponseDto<TokenDto>.Fail("Refresh token not found", StatusCodes.Status404NotFound, true);

            _repository.Remove(existRefreshToken);

            await _unitOfWork.CommitAsync();

            return ResponseDto<NoContent>.Succes(200);

        }
    }
}
