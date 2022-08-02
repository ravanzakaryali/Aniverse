using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Id)
                    .HasColumnName("identifier")
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()")
                    .IsRequired();
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("NOW()");
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

        }
    }
}
