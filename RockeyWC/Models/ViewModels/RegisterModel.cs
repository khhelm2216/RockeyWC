using System.ComponentModel.DataAnnotations;

namespace RockeyWC.Models.ViewModels
{

    public class RegisterModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
        public string Role { get; set; }
    }
}
