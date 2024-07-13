using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data;
public class ApplicationDbContext : DbContext
{
    // public ApplicationDbContext(DbContextOptions options) : base(options) { }
     protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    public DbSet<Product> Products { get; set; }
}