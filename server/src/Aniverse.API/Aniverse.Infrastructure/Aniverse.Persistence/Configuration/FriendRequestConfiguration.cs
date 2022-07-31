using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.Property(fr => fr.Id).HasIdentityOptions<string>();
            builder.Property(fr => fr.CreatedDate).HasDefaultValueSql("CURRENT_DATE");
            builder.Property(fr => fr.DeclinedCount).HasDefaultValue(0);
        }
    }
}
