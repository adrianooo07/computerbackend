using Microsoft.EntityFrameworkCore;

namespace webshop.Models
{
    public class shopDbContext : DbContext
    {
        public shopDbContext(DbContextOptions options) : base(options)
        {
        }

        public shopDbContext()
        {
        }

        public DbSet<Osystem> Osystems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var con = "server=localhost;database=computershop;uid=root;password=";

            optionsBuilder.UseMySql(con, ServerVersion.AutoDetect(con));
        }
    }
}
