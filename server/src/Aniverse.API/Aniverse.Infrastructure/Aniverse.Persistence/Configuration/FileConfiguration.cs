using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
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
