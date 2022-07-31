using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            builder.Property(s => s.Id).HasDefaultValueSql("GETID()");
            builder.Property(s => s.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
