using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c=>c.Id).HasDefaultValueSql("NEWID()");
            builder.Property(c => c.PostId).IsRequired();
            builder.Property(c=>c.UserId).IsRequired();
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
