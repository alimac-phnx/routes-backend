using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.Configurations;

public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}