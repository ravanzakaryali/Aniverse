using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class HastagConfiguration : IEntityTypeConfiguration<HasTag>
    {
        public void Configure(EntityTypeBuilder<HasTag> builder)
        {
            builder.Property(x => x.Id)
                     .HasColumnName("identifier")
                     .HasColumnType("uuid")
                     .HasDefaultValueSql("gen_random_uuid()")
                     .IsRequired();
            builder.Property(p => p.UpdatedDate).HasDefaultValue(null);
            builder.Property(ht=>ht.Name).IsRequired().HasMaxLength(64);
            builder.Property(ht => ht.CreatedDate).HasDefaultValueSql("NOW()");
        }
    }
}
