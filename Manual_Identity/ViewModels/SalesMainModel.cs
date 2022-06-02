using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manual_Identity.ViewModels
{
    public class SalesMainModel
    {
        [Key]
        public int SalesMain_Id { get; set; }

        [Required]
        //[MinLength(4, ErrorMessage = "Minmum 4 number digits Required")]
        public int InvoiceNumber { get; set; }

        //[NotMapped]

        public int CustomerId { get; set; }

        [NotMapped]
        public int ItemId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime SalesDate { get; set; }

        [NotMapped]
        public int Quantity { get; set; }
       
        [NotMapped]
        public int UnitPrice { get; set; }

        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int BalanceAmount { get; set; }


    }
}
