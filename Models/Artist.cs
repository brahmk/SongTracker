namespace SongTracker.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }   
        public required string Name { get; set; }
        public required string LookupName { get; set; } 
        public List<Song>? Songs { get; set; }   
    }
}
