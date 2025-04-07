using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => new { s.UserId, s.FollowedUserId });

        builder.HasOne<User>(s => s.User)
            .WithMany(u => u.Subscriptions)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>(s => s.FollowedUser)
            .WithMany()
            .HasForeignKey(s => s.FollowedUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}