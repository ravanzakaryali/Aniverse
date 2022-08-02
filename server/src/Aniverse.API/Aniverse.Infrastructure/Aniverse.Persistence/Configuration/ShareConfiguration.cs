using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("identifier")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()")
                   .IsRequired();
            builder.Property(s => s.CreatedDate).HasDefaultValueSql("NOW()");
            builder.Property(s=>s.PostUrl).IsRequired();
        }
    }
}
