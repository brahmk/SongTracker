using Humanizer.Localisation.DateToOrdinalWords;
using Microsoft.AspNetCore.Mvc;
using SongTracker.Models;
using SongTracker.Services;
using SongTracker.ViewModels;
using System.Diagnostics;

namespace SongTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;
        private readonly SongService _songService;
        private readonly ArtistService _artistService;

        public HomeController(ILogger<HomeController> logger, UserService userService, SongService songService, ArtistService artistService)
        {
            _logger = logger;
            _userService = userService;
            _songService = songService;
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)       
                return View(model);
            
            var userId = await _userService.GetOrCreateUserIdByName(model.UserName);

            if (userId == 0)
            {
                ModelState.AddModelError(string.Empty, "An error occurred.");
                return View(model);
            }

            return RedirectToAction("Profile", "Home", new { userId }); 
        }

        public  async Task<IActionResult> Profile(int userId)
        {
            
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return View(new ProfileViewModel());
            }

            var model = new ProfileViewModel
            {
                Friends = user.Friends ?? [],
                ActiveUserId = userId,
                Songs = user.LikedSongs?.OrderBy(song => song.Artist).ToList() ?? [],
                ProfileName = user.UserName ?? string.Empty
            };
            return View(model);
        }

        public async Task<IActionResult> Feed(int userId)
        {
            var feed = await _songService.GetRecentActivity(userId);
            
            return View(new FeedViewModel { ActiveUserId = userId, Activity = feed });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
