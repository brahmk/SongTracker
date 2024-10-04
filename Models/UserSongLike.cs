namespace SongTracker.Models
{

    public class UserSongLike
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public DateTime DateLiked { get; set; }


        public UserSongLike(User user, Song song)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));  //these should never be null
            Song = song ?? throw new ArgumentNullException(nameof(song));  
        }

    }
}