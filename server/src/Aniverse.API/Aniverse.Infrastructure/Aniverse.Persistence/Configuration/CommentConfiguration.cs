using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("identifier")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()")
                   .IsRequired();
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("NOW()");
        }
    }
}
