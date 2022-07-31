using Aniverse.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.Firstname).IsRequired();
            builder.Property(u => u.Lastname).HasDefaultValue("XXX");
            builder.Property(u => u.Bio).HasMaxLength(350);
            builder.Property(u => u.RegisterDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
