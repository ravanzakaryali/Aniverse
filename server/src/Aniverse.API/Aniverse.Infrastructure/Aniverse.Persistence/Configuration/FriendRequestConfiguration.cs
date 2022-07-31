using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.Property(fr => fr.Id).HasDefaultValueSql("NEWID()");
            builder.Property(fr => fr.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(fr => fr.DeclinedCount).HasDefaultValue(0);
        }
    }
}
