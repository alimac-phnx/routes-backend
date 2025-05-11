using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.Configurations;

internal class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasOne(r => r.User)
            .WithMany(u => u.Routes)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Places)
            .WithOne()
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.AdditionalPlaces)
            .WithOne()
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(r => r.Reviews)
            .WithOne()
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}