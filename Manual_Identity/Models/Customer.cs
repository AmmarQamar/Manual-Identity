using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
       
        [Required(ErrorMessage = "*Required")]
        public string CustomerName { get; set; }
    }
}
