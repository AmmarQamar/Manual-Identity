using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string CustomerName { get; set; }
    }
}
