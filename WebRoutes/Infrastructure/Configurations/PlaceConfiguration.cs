using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasOne(p => p.Point)
            .WithOne()
            .HasForeignKey<Place>(p => p.PointId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}