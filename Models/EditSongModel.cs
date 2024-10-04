namespace SongTracker.Models
{
    public class EditSongModel
    {
          
            public int SongId { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Artist { get; set; } = string.Empty;
            public string LinkUrl { get; set; } = string.Empty;
        
    }


}
