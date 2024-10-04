namespace SongTracker.ViewModels
{
    public class FeedViewModel
    {
        public required int ActiveUserId {  get; set; } 
        public List<string>? Activity { get; set; }
    }
}
