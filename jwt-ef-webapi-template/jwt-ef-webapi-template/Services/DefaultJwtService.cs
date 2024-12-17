using jwt_ef_webapi_template.Configurations;
using jwt_ef_webapi_template.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using jwt_ef_webapi_template.Helpers;

namespace jwt_ef_webapi_template.Services
{
    public class DefaultJwtService : IJwtService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public DefaultJwtService(IOptions<JwtOptions> jwtOptions)
        {            
            _jwtOptions = jwtOptions?.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(_jwtOptions.Key, nameof(_jwtOptions.Key));

            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string CreateToken(ICollection<Claim> claims)
        {
            if(claims == null || !claims.Any())
            {
                throw new ArgumentNullException(nameof(claims));
            }

            var securityKey = KeyHelper.GetSymmetricSecurityKey(_jwtOptions.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(_jwtOptions.MinutesLifetime)),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }
    }
}
