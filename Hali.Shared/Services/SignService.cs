using System.Text;
using Microsoft.IdentityModel.Tokens;

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
