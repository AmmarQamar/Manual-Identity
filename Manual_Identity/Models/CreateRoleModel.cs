using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
