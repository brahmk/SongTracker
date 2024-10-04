namespace SongTracker.Models
{
    public class ToggleLikeModel
    {
        public required int SongId { get; set; }    
        public required int UserId { get; set; }
    }
}
