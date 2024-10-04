using Microsoft.EntityFrameworkCore;
using SongTracker.Models;

namespace SongTracker.Data
{
    public class SongTrackerDbContext : DbContext
    {
        public SongTrackerDbContext(DbContextOptions<SongTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
          .HasMany(u => u.LikedSongs)
          .WithMany(s => s.LikedBy)
          .UsingEntity<Dictionary<string, object>>(
              "UserSongLikes",
              j => j.HasOne<Song>().WithMany().HasForeignKey("SongId"),
              j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
            .HasMany(u => u.Friends)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserFriends",
                j => j.HasOne<User>().WithMany().HasForeignKey("FriendId"),
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));
        }
    }
}
