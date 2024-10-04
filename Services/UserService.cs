using Microsoft.EntityFrameworkCore;
using SongTracker.Data;
using SongTracker.Models;

namespace SongTracker.Services
{
    public class UserService
    {
        private readonly SongTrackerDbContext _context;

        public UserService(SongTrackerDbContext context)
        {
            _context = context;
        }


        //TODO add xml desc for this service
        public async Task<int> GetOrCreateUserIdByName(string username)
        {


            var user = await _context.Users
                .Include(u => u.LikedSongs).FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null) {
                user = new User { UserName = username };
                await  _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            return user.UserId;

        }

        public async Task<(bool success, string message)> AddFriendByUserName(AddFriendModel model)
        {
            var newFriend = await _context.Users.Include(u=>u.Friends).FirstOrDefaultAsync(u => u.UserName == model.UserNameToAdd);

            if (newFriend == null)
                return (false, "Unable to find anyone by that user name.");

            var activeUser = await _context.Users.Include(u => u.Friends).FirstOrDefaultAsync(u => u.UserId == model.ActiveUserId);

            if (activeUser == null)
                return (false, "An error occurred.");


            if (activeUser.Friends.Contains(newFriend))           
                 return (false, $"You're already friends with {model.UserNameToAdd}!");

            activeUser.Friends.Add(newFriend);
            newFriend.Friends.Add(activeUser);

            _context.Users.Update(activeUser);
            _context.Users.Update(newFriend);
            await _context.SaveChangesAsync();

            return (true, "Friend Added!");
        }


        public async Task<User> GetUserById(int id)
        {

            return await _context.Users.Include(u => u.LikedSongs).Include(u => u.Friends).ThenInclude(f=>f.LikedSongs).FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
