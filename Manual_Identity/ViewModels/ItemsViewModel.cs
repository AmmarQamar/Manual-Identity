using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.ViewModels
{
    public class ItemsViewModel
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string ItemName { get; set; }
    }
}
