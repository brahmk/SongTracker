using SongTracker.Models;

namespace SongTracker.ViewModels
{
    public class ProfileViewModel
    {
        public int ActiveUserId { get; set; }
        public  string? ProfileName { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public List<User> Friends { get; set; } = new List<User>();

    }
}
