using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //public int CourseId { set; get; }

        [Required(ErrorMessage = "*Required")]
        public string Address { set; get; }


        [Required(ErrorMessage = "*Required")]
        public int CourseId { get; set; }
        //public CourseViewModel Courses { get; set; }
    }
    //public enum CourseName
    //{
    //    CS,
    //    SE,
    //    ME,
    //    BBA,
    //    CA

    //}
}
