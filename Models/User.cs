namespace SongTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }

        public virtual List<Song> LikedSongs { get; set; } = new List<Song>();
        public virtual List<User>? Friends { get; set; }
    }
}
