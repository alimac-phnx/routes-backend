using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route = WebRoutes.Models.Route;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasIndex(s => new { s.PointId, s.RouteId });
        
        builder.HasOne<Route>()
            .WithMany(r => r.Places)
            .HasForeignKey(m => m.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Point)
            .WithOne()
            .HasForeignKey<Place>(p => p.PointId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}