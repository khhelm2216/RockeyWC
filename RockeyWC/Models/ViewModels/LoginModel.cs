using System.ComponentModel.DataAnnotations;

namespace RockeyWC.Models.ViewModels {

    public class LoginModel {

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        /*public string ReturnUrl { get; set; } = "/";*/
    }
}
