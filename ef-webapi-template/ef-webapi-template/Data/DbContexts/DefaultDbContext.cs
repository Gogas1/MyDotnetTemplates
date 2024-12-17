using Microsoft.EntityFrameworkCore;

namespace ef_webapi_template.Data.DbContexts
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
