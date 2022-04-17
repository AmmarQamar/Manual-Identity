using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manual_Identity.Models
{
    public class RegisterViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Match with Password")]
        public string ConfirmPassword { get; set; }
        public string? ImgPath { get; set; }

        //[NotMapped]
        //[DisplayName("Choose Profile Pic")]
        //public string Photo { get; set; }
    }
}
