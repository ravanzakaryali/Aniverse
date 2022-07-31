using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c=>c.Id).HasIdentityOptions<string>();
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("CURRENT_DATE");
        }
    }
}
