using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.HasOne<Review>()
            .WithMany()
            .HasForeignKey(m => m.ReviewId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}