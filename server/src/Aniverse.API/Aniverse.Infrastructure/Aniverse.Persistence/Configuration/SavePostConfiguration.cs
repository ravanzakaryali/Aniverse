using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class SavePostConfiguration : IEntityTypeConfiguration<SavePost>
    {
        public void Configure(EntityTypeBuilder<SavePost> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("identifier")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()")
                   .IsRequired();
            builder.Property(sp => sp.CreatedDate).HasDefaultValueSql("NOW()");
        }
    }
}
