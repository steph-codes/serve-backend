using System.ComponentModel.DataAnnotations;

namespace Serve.API.Data
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter Business Name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is Invalid")]
        // Email as Username[StringLength(45, ErrorMessage = "Maximum Password Length Exceeded, Up to 45 characters expected!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[StringLength(45, ErrorMessage = "Maximum Password Length Exceeded! only up to 45 characters expected!")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirm Password is required.")]
        //[Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
        //public string ConfirmPassword { get; set; }
    }
}
