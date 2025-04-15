using MediaNest.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MediaNest.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Creates a relationshi[ between userCollection and user
            // 1:1 relationship between ApplicationUser and UserCollection
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.UserCollection)
                .WithOne()
                .HasForeignKey<ApplicationUser>(u => u.UserCollectionId);

            // Many-to-many relationship between UserCollection and MediaItem through UserCollectionItems
            builder.Entity<UserCollectionItems>()
                .HasOne(uci => uci.UserCollection)
                .WithMany(uc => uc.Items) // <- needed
                .HasForeignKey(uci => uci.UserCollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserCollectionItems>()
                .HasOne(uci => uci.MediaItem)
                .WithMany(mi => mi.InCollections) // <- needed
                .HasForeignKey(uci => uci.MediaItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // makes enum string instead of value
            builder.Entity<UserCollectionItems>().Property(ucollection => ucollection.Progress).HasConversion<string>();
            builder.Entity<UserCollectionItems>().Property(u => u.Progress).HasDefaultValue(Progress.NotStarted);
        }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<UserCollection> UserCollections { get; set; }
        public DbSet<UserCollectionItems> UserCollectionItems { get; set; }

    }
}