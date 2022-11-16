using System.ComponentModel.DataAnnotations;

namespace Serve.API.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
