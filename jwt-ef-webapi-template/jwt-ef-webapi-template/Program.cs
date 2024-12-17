
using jwt_ef_webapi_template.Extensions;
using System.Text.Json.Serialization;

namespace jwt_ef_webapi_template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configurations and addition of target db context
            //builder.SetupYourDbContext();
         
            builder.ConfigureJwtOptions();
            builder.ConfigureConnectionStringsOptions();
            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            //Configure jwt authentication
            builder.ConfigureJwtAuthentication();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}