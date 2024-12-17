using jwt_ef_webapi_template.Configurations;

namespace jwt_ef_webapi_template.Extensions
{
    public static class WebApplicationBuilderConfigurationExtensions
    {
        /// <summary>
        /// Configures JWT options using <see cref="IOptions{JwtOptions}"/> and the <see cref="JwtOptions"/> class.
        /// </summary>
        public static void ConfigureJwtOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
        }

        /// <summary>
        /// Configures connections strings options using <see cref="IOptions{ConnectionStringsOptions}"/> and the <see cref="ConnectionStringsOptions"/> class.
        /// </summary>
        public static void ConfigureConnectionStringsOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection("ConnectionStrings"));
        }
    }
}
