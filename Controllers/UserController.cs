using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SongTracker.Data;
using SongTracker.Helpers;
using SongTracker.Models;
using SongTracker.Services;

namespace SongTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly SongTrackerDbContext _context;
        private readonly UserService _userService;

        public UserController(SongTrackerDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("AddFriend")]
        public async Task<IActionResult> AddFriend([FromBody] AddFriendModel model)
        {
            var addFriend = await _userService.AddFriendByUserName( model);

            if (addFriend.success)
                return Ok(new { addFriend.message });

            return Unauthorized(new { addFriend.message });
        }

    }
}
