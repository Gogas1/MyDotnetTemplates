using jwt_ef_webapi_template.Configurations;
using jwt_ef_webapi_template.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace jwt_ef_webapi_template.Extensions
{
    public static class WebApplicationBuilderJwtExtensions
    {
        public static void ConfigureJwtAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var config = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

                    ArgumentNullException.ThrowIfNull(config, nameof(config));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = config.ValidateIssuer,
                        ValidIssuer = config.Issuer,
                        ValidateAudience = config.ValidateAudience,
                        ValidAudience = config.Audience,
                        ValidateLifetime = config.ValidateLifetime,
                        IssuerSigningKey = KeyHelper.GetSymmetricSecurityKey(config.Key),
                        ValidateIssuerSigningKey = config.ValidateKey,                        
                    };
                });
        }
    }
}
