using System.ComponentModel.DataAnnotations;

namespace SongTracker.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;
    }
}
