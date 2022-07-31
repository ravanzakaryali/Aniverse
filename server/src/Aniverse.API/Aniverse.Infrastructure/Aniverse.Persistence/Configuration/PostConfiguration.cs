using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_DATE");
            builder.Property(p => p.Id).HasIdentityOptions<string>();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}
