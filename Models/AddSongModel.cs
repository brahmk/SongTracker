namespace SongTracker.Models
{
    public class AddSongModel
    {
        public int AddedByUserId { get; set; }  
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string LinkUrl { get; set; } = string.Empty;
    }
}
