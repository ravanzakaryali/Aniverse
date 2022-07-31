using Aniverse.Domain.Entities;
using Aniverse.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aniverse.Persistence.Context
{
    public class AniverseDbContext : DbContext
    {
        public AniverseDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalFollow> AnimalFollows { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<HasTag> HasTags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SavePost> SavePosts { get; set; }
        public DbSet<Share> Shares { get; set; }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
            DateTime utcNow = DateTime.UtcNow;
            foreach (EntityEntry entry in entries)
            {
                if(entry.Entity is ICreatedDate createdEntity && entry.State is EntityState.Added)
                {
                    createdEntity.CreatedDate = utcNow;
                }
                if(entry.Entity is IUpdatedDate updatedEntity && entry.State is EntityState.Modified)
                {
                    updatedEntity.UpdatedDate = utcNow;
                }
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
