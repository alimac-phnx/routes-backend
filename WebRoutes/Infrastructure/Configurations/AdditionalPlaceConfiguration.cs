using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

public class AdditionalPlaceConfiguration : IEntityTypeConfiguration<AdditionalPlace>
{
    public void Configure(EntityTypeBuilder<AdditionalPlace> builder)
    {
        builder.HasOne(p => p.Point)
            .WithOne()
            .HasForeignKey<AdditionalPlace>(p => p.PointId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}