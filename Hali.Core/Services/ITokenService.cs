using Hali.Core.Configurations;
using Hali.Core.DTOs;
using Hali.Core.Models;

namespace Hali.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
