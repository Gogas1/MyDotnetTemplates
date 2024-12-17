using System.Security.Claims;

namespace jwt_ef_webapi_template.Interfaces.Services
{
    public interface IJwtService
    {
        string CreateToken(ICollection<Claim> claims);
    }
}
