using Backend.BO.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend.DAL.Databases
{
    public partial class DenticareContext : DbContext
    {
        public DenticareContext()
        {
        }

        public DenticareContext(DbContextOptions<DenticareContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString(), serverVersion: ServerVersion.AutoDetect(GetConnectionString()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
