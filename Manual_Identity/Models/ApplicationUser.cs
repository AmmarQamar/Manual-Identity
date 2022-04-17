using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manual_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
       public string Gender { get; set; }
   //     public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
    }

    //public enum Gender
    //{
    //    Male,
    //    Female
    //}
}
