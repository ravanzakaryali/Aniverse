using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class HastagConfiguration : IEntityTypeConfiguration<HasTag>
    {
        public void Configure(EntityTypeBuilder<HasTag> builder)
        {
            builder.Property(ht=>ht.Name).IsRequired().HasMaxLength(64);
            builder.Property(ht => ht.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(ht => ht.Id).HasDefaultValueSql("GETID()");
        }
    }
}
