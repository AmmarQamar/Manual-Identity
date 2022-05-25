using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        //[MinLength(4, ErrorMessage = "Minmum 4 number digits Required")]
        public int InvoiceNumber { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }
    }
}
