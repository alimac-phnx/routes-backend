using Microsoft.EntityFrameworkCore;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        
        public DbSet<Mark> Marks { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Point> Points { get; set; }
        
        public DbSet<Place> Places { get; set; }
        
        public DbSet<AdditionalPlace> AdditionalPlaces { get; set; }
        
        public DbSet<Subscription> Subscriptions { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}