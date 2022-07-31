using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class SavePostConfiguration : IEntityTypeConfiguration<SavePost>
    {
        public void Configure(EntityTypeBuilder<SavePost> builder)
        {
            builder.Property(sp => sp.CreatedDate).HasDefaultValueSql("CURRENT_DATE");
            builder.Property(sp => sp.Id).HasIdentityOptions<string>();
        }
    }
}
