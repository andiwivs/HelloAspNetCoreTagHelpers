using System.ComponentModel.DataAnnotations;

namespace HelloAspNetCoreTagHelpers.Site.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
