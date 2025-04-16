using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder
            .HasIndex(s => new { s.SubscriberId, s.FolloweeId })
            .IsUnique();
        
        builder
            .HasOne(s => s.Subscriber)
            .WithMany(u => u.Subscriptions)
            .HasForeignKey(s => s.SubscriberId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(s => s.Followee)
            .WithMany()
            .HasForeignKey(s => s.FolloweeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}