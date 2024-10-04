using Microsoft.IdentityModel.Tokens;

namespace SongTracker.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required string ArtistLookup { get; set; }
        public required string TitleLookup { get; set; }    
        public virtual List<User> LikedBy { get; set; } = new List<User>();
        
        public string? LinkUrl { get; set; }
        public string? LinkIcon
        {
            get
            {
                if (LinkUrl.IsNullOrEmpty())
                    return "/img/generic-icon.png";

                if (LinkUrl.Contains("spotify", StringComparison.OrdinalIgnoreCase))
                    return "/img/spotify-icon.png";

                if (LinkUrl.Contains("youtube", StringComparison.OrdinalIgnoreCase) || LinkUrl.Contains("youtu.be", StringComparison.OrdinalIgnoreCase))
                    return "/img/youtube-icon.png";

                return "/img/generic-icon.png";
            }
        }
    }
}
