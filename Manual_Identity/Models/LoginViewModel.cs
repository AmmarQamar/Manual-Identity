using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter Valid Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter Valid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
