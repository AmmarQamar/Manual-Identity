using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.ViewModels
{
    public class SalesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int BalanceAmount { get; set; }


    }
}
