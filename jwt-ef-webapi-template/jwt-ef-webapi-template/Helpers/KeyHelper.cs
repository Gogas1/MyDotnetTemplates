using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace jwt_ef_webapi_template.Helpers
{
    public static class KeyHelper
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
