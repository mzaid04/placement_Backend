using Microsoft.EntityFrameworkCore;
using placement_Backend.Models;

namespace placement_Backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("dbConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<PlacementApplication> PlacementApplications { get; set; }

        public DbSet<Placement> Placements { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
