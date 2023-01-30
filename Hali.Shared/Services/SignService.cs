using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hali.Shared.Services
{
    public static class SignService
    {
        public static SecurityKey GetSymmmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
