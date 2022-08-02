using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("identifier")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()")
                   .IsRequired();
            builder.Property(p => p.UpdatedDate).HasDefaultValue(null);
            builder.Property(fr => fr.CreatedDate).HasDefaultValueSql("NOW()");
            builder.Property(fr => fr.DeclinedCount).HasDefaultValue(0);
        }
    }
}
