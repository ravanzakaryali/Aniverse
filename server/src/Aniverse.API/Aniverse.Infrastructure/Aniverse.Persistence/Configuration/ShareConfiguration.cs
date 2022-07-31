using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.Property(s => s.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(s => s.Id).HasDefaultValueSql("GETID()");
            builder.Property(s=>s.PostUrl).IsRequired();
        }
    }
}
