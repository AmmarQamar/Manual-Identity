using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage ="*Required")]
        public string ItemName { get; set; }
    }
}
