using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure.TestDataConfig;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<AdditionalPlace> AddPlaces { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}