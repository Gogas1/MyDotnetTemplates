using ef_webapi_template.Configurations;
using ef_webapi_template.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ef_webapi_template.Extensions
{
    public static class WebApplicationBuilderDbContextExtensions
    {
        //public static void SetupYourDbContext(this WebApplicationBuilder builder)
        //{
        //    var config = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsOptions>();

        //    string targetConnectionString = config.YourConnectionString;

        //    ArgumentNullException.ThrowIfNullOrEmpty(targetConnectionString, nameof(targetConnectionString));

        //    builder.Services.AddDbContext<BaseDbContext>(options => options.UseYourDbProvider(options));
        //}
    }
}
