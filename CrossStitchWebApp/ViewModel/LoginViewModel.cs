using System.ComponentModel.DataAnnotations;

namespace CrossStitchWebApp.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email adress is required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
