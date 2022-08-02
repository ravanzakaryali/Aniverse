using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property(x => x.Id)
                    .HasColumnName("identifier")
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()")
                    .IsRequired();
            builder.Property(s => s.CreatedDate).HasDefaultValueSql("NOW()");
        }
    }
}
