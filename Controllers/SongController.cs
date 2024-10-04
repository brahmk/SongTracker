
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
        private readonly UserService _userService;
        private readonly SongService _songService;

        public SongController( UserService userService, SongService songService)
        {
            _userService = userService;
            _songService = songService;
        }

        [HttpPost("AddSong")]
        public async Task<IActionResult> AddSong([FromBody] AddSongModel model)
        {
            try
            {
                var currentUser = await _userService.GetUserById(model.AddedByUserId);
                if (currentUser == null)
                    return Unauthorized();

                var addSong = await _songService.AddSongToUserAsync(currentUser, model);

                if (addSong.success)
                    return Ok(new { addSong.message });

                return StatusCode(500, new { addSong.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred." });
            }
        }

        [HttpPost("ToggleLike")]
        public async Task<IActionResult> ToggleLike([FromBody] ToggleLikeModel model) 
        {
            try
            {
                var toggle = await _songService.ToggleLike(model);

                if (toggle.success)
                    return Ok(new { toggle.message });

                return StatusCode(500, new { toggle.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred." });
            }
        }

        [HttpPost("EditSong")]
        public async Task<IActionResult> EditSong([FromBody] EditSongModel model)
        {
            try
            {
                var edit = await _songService.EditSong(model);

                if (edit.success)
                    return Ok(new { edit.message });

                return StatusCode(500, new { edit.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred." });
            }
        }

    }
         

}
