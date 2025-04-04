using Microsoft.EntityFrameworkCore;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
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
            modelBuilder.Entity<Route>()
                .HasOne(r => r.User)
                .WithMany(u => u.Routes)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Route>()
                .HasMany(r => r.Places)
                .WithMany(p => p.Routes);

            modelBuilder.Entity<Route>()
                .HasMany(r => r.AdditionalPlaces)
                .WithMany(ap => ap.Routes);

            modelBuilder.Entity<Media>()
                .HasOne<Review>()
                .WithMany()
                .HasForeignKey(m => m.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mark>()
                .HasOne<Route>()
                .WithMany()
                .HasForeignKey(m => m.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mark>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne<Route>()
                .WithMany()
                .HasForeignKey(r => r.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<Review>()
                .WithMany()
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mark>()
                .HasKey(m => new { m.UserId, m.RouteId });

            modelBuilder.Entity<Subscription>()
                .HasKey(s => new { s.UserId, s.FollowedUserId });

            modelBuilder.Entity<Subscription>()
                .HasOne<User>(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subscription>()
                .HasOne<User>(s => s.FollowedUser)
                .WithMany()
                .HasForeignKey(s => s.FollowedUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}