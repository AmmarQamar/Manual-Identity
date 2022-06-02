using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manual_Identity.Models
{
    public class Sales_Item
    {
        [Key]
        public int SalesItem_Id { get; set; }

        [Required]
        //[MinLength(4, ErrorMessage = "Minmum 4 number digits Required")]
        public int InvoiceNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }

        //[NotMapped]
        //public int CustomerId { get; set; }

        [Required]
        public int ItemId { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }
    }
}
