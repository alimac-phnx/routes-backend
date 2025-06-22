using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route = WebRoutes.Models.Route;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

internal class AdditionalPlaceConfiguration : IEntityTypeConfiguration<AdditionalPlace>
{
    public void Configure(EntityTypeBuilder<AdditionalPlace> builder)
    {
        builder.HasKey(ap => ap.Id);
        
        builder.Property(ap => ap.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasIndex(s => new { s.PointId, s.RouteId });
        
        builder.HasOne<Route>()
            .WithMany(r => r.AdditionalPlaces)
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Point)
            .WithOne()
            .HasForeignKey<AdditionalPlace>(p => p.PointId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}