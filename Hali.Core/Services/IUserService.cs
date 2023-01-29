using Hali.Core.DTOs;
using Hali.Shared.DTOs;

namespace Hali.Core.Services
{
    public interface IUserService
    {
        Task<ResponseDto<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<ResponseDto<CompanyWithUserDto>> CreateCompanyWithUserAsync(CompanyWithUserCreateDto companyWithUserCreateDto);
        Task<ResponseDto<AppUserDto>> GetUserByNameAsync(string userName);
    }
}
