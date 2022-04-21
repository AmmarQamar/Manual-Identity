using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage ="Role Name Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
