﻿using Aniverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aniverse.Persistence.Configuration
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property(s => s.CreatedDate).HasDefaultValueSql("CURRENT_DATE");
            builder.Property(s => s.Id).HasIdentityOptions<string>();
        }
    }
}
