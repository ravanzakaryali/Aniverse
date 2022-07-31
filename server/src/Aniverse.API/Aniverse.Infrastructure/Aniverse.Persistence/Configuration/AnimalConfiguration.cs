using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.Id).HasDefaultValueSql("NEWID()");
            builder.Property(a => a.Name).IsRequired().HasMaxLength(128);
            builder.Property(a => a.Bio).IsRequired().HasMaxLength(350);
            builder.Property(a => a.CreatedDate).HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
