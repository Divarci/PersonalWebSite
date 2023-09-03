using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ServiceLayer.AuthServer.Helpers.SignHelpers
{
    public static class SignHelper
    {
        public static SecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
