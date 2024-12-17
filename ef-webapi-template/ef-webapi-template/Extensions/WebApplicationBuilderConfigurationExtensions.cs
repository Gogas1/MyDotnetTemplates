using ef_webapi_template.Configurations;

namespace ef_webapi_template.Extensions
{
    public static class WebApplicationBuilderConfigurationExtensions
    {
        /// <summary>
        /// Configures connections strings options using <see cref="IOptions{ConnectionStringsOptions}"/> and the <see cref="ConnectionStringsOptions"/> class.
        /// </summary>
        public static void ConfigureConnectionStringsOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection("ConnectionStrings"));
        }
    }
}
