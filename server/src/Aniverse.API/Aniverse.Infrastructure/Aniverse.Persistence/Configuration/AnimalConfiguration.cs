using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("identifier")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()") 
                   .IsRequired();
            builder.Property(a=>a.Animalname).IsRequired().HasMaxLength(64);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(128);
            builder.Property(a => a.Bio).IsRequired().HasMaxLength(350);
            builder.Property(a => a.CreatedDate).HasDefaultValueSql("NOW()");

        }
    }
}
