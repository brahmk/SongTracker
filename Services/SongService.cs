using Microsoft.EntityFrameworkCore;
using SongTracker.Data;
using SongTracker.Helpers;
using SongTracker.Models;

namespace SongTracker.Services
{
    public class SongService {

        private readonly SongTrackerDbContext _context;
        public  SongService(SongTrackerDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Adds a song to the users liked songs. If the song already exists in the db,
        /// it links the user to the existing song. Otherwise will create new entry and then link user to created entry.
        /// </summary>
        /// <param name="user">The user who is adding the song to their liked list.</param>
        /// <param name="newSong">Contains details of the song to be added. (artist, title, etc) </param>
        /// <returns>
        /// A tuple containing a boolean and a message:
        /// <description><c>success</c>: True if the song was added successfully, otherwise, false.</description>    
        /// <description><c>message</c>: A message detailing the result of the operation, including errors.</description>
        /// </returns>
        public async Task<(bool success, string message)> AddSongToUserAsync(User user, AddSongModel newSong)
        {
            try
            {
                var mySong = new Song
                {
                    Title = newSong.Title,
                    Artist = newSong.Artist,
                    ArtistLookup = SongHelper.ConvertStringToLookup(newSong.Artist),
                    TitleLookup = SongHelper.ConvertStringToLookup(newSong.Title),
                    LinkUrl = newSong.LinkUrl
                };

                var songExists = await _context.Songs.FirstOrDefaultAsync(x => x.ArtistLookup == mySong.ArtistLookup && x.TitleLookup == x.TitleLookup);
                if (songExists != null) {
                    user.LikedSongs.Add(songExists);
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return (true, "Song Added!");
                }

                await _context.Songs.AddAsync(mySong);
                await _context.SaveChangesAsync();

                user.LikedSongs.Add(mySong);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return (true, "Song Added!");
            }
            catch (Exception ex) {
                return (false, "Error adding song");
                //log exception
            }
            }

        //TODO add xml desc
        public async Task<(bool success, string message)> ToggleLike(ToggleLikeModel model)
        {
            var userId = model.UserId;
            var songId = model.SongId;

            var user = await _context.Users.Include(u => u.LikedSongs) .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                return (false, "User not found.");

            var song = await _context.Songs.FirstOrDefaultAsync(s => s.SongId == songId);

            if (song == null)
                return (false, "Song not found.");

            if (user.LikedSongs.Contains(song))
            {
                user.LikedSongs.Remove(song);
                _context.Users.Update(user); 
                await _context.SaveChangesAsync();
                return (true, "Song unliked.");
            }
            else
            {
                user.LikedSongs.Add(song);
                _context.Users.Update(user); 
                await _context.SaveChangesAsync();
                return (true, "Song liked!.");
            }
        }

        //public async Task<List<string>> GetRecentActivity()
        //{
        //    var activity = await _context.UserSongLikes

        //}


    }
}
