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
        /// <param name="user">Object representing the user that generated the request.</param>
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
                    LinkUrl = newSong.LinkUrl,
                    DateAdded = DateTime.Now
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
            try
            {
                var userId = model.UserId;
                var songId = model.SongId;

                var user = await _context.Users.Include(u => u.LikedSongs).FirstOrDefaultAsync(u => u.UserId == userId);

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
            catch (Exception ex)
            {
                return (false, "An error occured.");
                //log exception
            }
        }

        public async Task<(bool success, string message)> EditSong(EditSongModel model)
        {
            try
            {
                var songId = model.SongId;


                

                var song = await _context.Songs.FirstOrDefaultAsync(s => s.SongId == songId);

                if (song == null)
                    return (false, "Song not found.");

                song.Title = model.Title;
                song.Artist = model.Artist; 
                song.ArtistLookup = SongHelper.ConvertStringToLookup(model.Artist);
                song.TitleLookup = SongHelper.ConvertStringToLookup(model.Title);
                song.LinkUrl = model.LinkUrl;
                song.DateModified = DateTime.Now;   

                _context.Songs.Update(song);
                await _context.SaveChangesAsync();

                return (true, "Song updated.");


            }
            catch (Exception ex)
            {
                return (false, "An error occured.");
                //log exception
            }
        }

        public async Task<List<string>> GetRecentActivity()
        {
            try
            {
                var activity = new List<string>();
                var query = await (from users in _context.Users
                                   join songs in _context.Songs on users.Friends equals songs.LikedBy
                                   orderby songs.DateAdded descending
                                   select new { users.UserName, songs.Title, songs.Artist }).Take(5).ToListAsync();
                //this throws exception, cant  query by navigation property in ef
                //will  need to create instance of junction table in my dbcontext and join off of that 
                foreach (var item in query)
                {
                    activity.Add($"{item.UserName} liked {item.Title} by {item.Artist}");
                }


                if (query.Count == 0)
                {
                    activity.Add("No recent activity found.");
                }

                return activity;
            }
            catch (Exception ex)
            {
                //log exception
                return new List<string>();
            }

        }


    }
}
