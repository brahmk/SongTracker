
using Microsoft.AspNetCore.Mvc;
using SongTracker.Data;

using SongTracker.Models;
using SongTracker.Services;

namespace SongTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly SongTrackerDbContext _context;
        private readonly UserService _userService;
        private readonly SongService _songService;

        public SongController(SongTrackerDbContext context, UserService userService, SongService songService)
        {
            _context = context;
            _userService = userService;
            _songService = songService;
        }

        [HttpPost("AddSong")]
        public async Task<IActionResult> AddSong([FromBody] AddSongModel model)
        {

            var currentUser = await _userService.GetUserById(model.AddedByUserId);
            if (currentUser == null)
                return Unauthorized();

            var addSong = await _songService.AddSongToUserAsync(currentUser, model);

            if (addSong.success)
                return Ok(new { addSong.message });

            return Unauthorized(new { addSong.message });
        }

        [HttpPost("ToggleLike")]
        public async Task<IActionResult> ToggleLike([FromBody] ToggleLikeModel model) 
        {
            var toggle = await _songService.ToggleLike(model);

            if (toggle.success)
                return Ok(new { toggle.message });

            return Unauthorized(new { toggle.message });
        }

    }
         

}
