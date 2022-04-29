using System.ComponentModel.DataAnnotations;

namespace Manual_Identity.Models
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { set; get; }

        [Required(ErrorMessage ="*Required")]
        public string StudentName { set; get; }

        [Required(ErrorMessage = "*Required")]
        public string FatherName { set; get; }

        [Required(ErrorMessage = "*Required")]
        public int CourseId { set; get; }

        [Required(ErrorMessage = "*Required")]
        public string Address { set; get; }
    }
}
